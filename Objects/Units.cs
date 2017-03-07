using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SigilOfFlame
{
    public class Unit
    {
        private string _unitName;
        private string _unitType;
        private int _weaponId;
        private int _hp;
        private int _str;
        private int _skl;
        private int _spd;
        private int _lck;
        private int _def;
        private int _res;
        private int _id;

        public Unit (string unitName, string unitType, int weaponId, int hp, int str, int skl, int spd, int lck, int def, int res, int id=0)
        {
            _unitName = unitName;
            _unitType = unitType;
            _weaponId = weaponId;
            _hp = hp;
            _str = str;
            _skl = skl;
            _spd = spd;
            _lck = lck;
            _def = def;
            _res = res;
            _id = id;
        }

        public string GetUnitName()
        {
            return _unitName;
        }

        public string GetUnitType()
        {
            return _unitType;
        }

        public int GetWeaponId()
        {
            return _weaponId;
        }

        public int GetHitpoints()
        {
            return _hp;
        }

        public int GetStrength()
        {
            return _str;
        }

        public int GetSkill()
        {
            return _skl;
        }

        public int GetSpeed()
        {
            return _spd;
        }

        public int GetLuck()
        {
            return _lck;
        }

        public int GetDefense()
        {
            return _def;
        }

        public int GetResistance()
        {
            return _res;
        }

        public void SetUnitName(string unitNameNew)
        {
            _unitName = unitNameNew;
        }

        public void SetUnitType(string unitTypeNew)
        {
            _unitType = unitTypeNew;
        }

        public void SetWeaponId(int weaponIdNew)
        {
            _weaponId = weaponIdNew;
        }

        public void SetHitpoints(int hpNew)
        {
            _hp = hpNew;
        }

        public void SetStrength(int strNew)
        {
            _str = strNew;
        }

        public void SetSkill(int sklNew)
        {
            _skl = sklNew;
        }

        public void SetSpeed(int spdNew)
        {
            _spd = spdNew;
        }

        public void SetLuck(int lckNew)
        {
            _lck = lckNew;
        }

        public void SetDefense(int defNew)
        {
            _def = defNew;
        }

        public void SetResistance(int resNew)
        {
            _res = resNew;
        }

        public int GetUnitId()
        {
            return _id;
        }

        public override bool Equals(System.Object otherUnit)
        {
            if (!(otherUnit is Unit))
            {
                return false;
            }
            else
            {
                Unit newUnit = (Unit) otherUnit;
                bool unitNameEquality = this.GetUnitName() == newUnit.GetUnitName();
                bool unitTypeEquality = this.GetUnitType() == newUnit.GetUnitType();
                bool weaponIdEquality = this.GetWeaponId() == newUnit.GetWeaponId();
                bool hitpointsEquality = this.GetHitpoints() == newUnit.GetHitpoints();
                bool strengthEquality = this.GetStrength() == newUnit.GetStrength();
                bool skillEquality = this.GetSkill() == newUnit.GetSkill();
                bool speedEquality = this.GetSpeed() == newUnit.GetSpeed();
                bool luckEquality = this.GetLuck() == newUnit.GetLuck();
                bool defenseEquality = this.GetDefense() == newUnit.GetDefense();
                bool resistanceEquality = this.GetResistance() == newUnit.GetResistance();
                bool unitIdEquality = this.GetUnitId() == newUnit.GetUnitId();
                return (unitNameEquality && unitTypeEquality && weaponIdEquality && hitpointsEquality && strengthEquality && skillEquality && speedEquality && luckEquality && defenseEquality && resistanceEquality && unitIdEquality);
            }
        }

        public static List<Unit> GetAll()
        {
            List<Unit> allUnits = new List<Unit>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM units;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                string unitName = rdr.GetString(1);
                string unitType = rdr.GetString(2);
                int weaponId = rdr.GetInt32(3);
                int hp = rdr.GetInt32(4);
                int str = rdr.GetInt32(5);
                int skl = rdr.GetInt32(6);
                int spd = rdr.GetInt32(7);
                int lck = rdr.GetInt32(8);
                int def = rdr.GetInt32(9);
                int res = rdr.GetInt32(10);
                int id = rdr.GetInt32(0);
                Unit newUnit = new Unit(unitName, unitType, weaponId, hp, str, skl, spd, lck, def, res, id);
                allUnits.Add(newUnit);
            }

            DB.CloseSqlConnection(rdr, conn);

            return allUnits;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO units (unit_name, unit_type, weapon_id, hp, str, skl, spd, lck, def, res) OUTPUT INSERTED.id VALUES (@UnitName, @UnitType, @WeaponId, @Hitpoints, @Strength, @Skill, @Speed, @Luck, @Defense, @Resistance);", conn);

            cmd.Parameters.Add(new SqlParameter("@UnitName", this.GetUnitName()));
            cmd.Parameters.Add(new SqlParameter("@UnitType", this.GetUnitType()));
            cmd.Parameters.Add(new SqlParameter("@WeaponId", this.GetWeaponId()));
            cmd.Parameters.Add(new SqlParameter("@Hitpoints", this.GetHitpoints()));
            cmd.Parameters.Add(new SqlParameter("@Strength", this.GetStrength()));
            cmd.Parameters.Add(new SqlParameter("@Skill", this.GetSkill()));
            cmd.Parameters.Add(new SqlParameter("@Speed", this.GetSpeed()));
            cmd.Parameters.Add(new SqlParameter("@Luck", this.GetLuck()));
            cmd.Parameters.Add(new SqlParameter("@Defense", this.GetDefense()));
            cmd.Parameters.Add(new SqlParameter("@Resistance", this.GetResistance()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            DB.CloseSqlConnection(rdr, conn);
        }

        public static Unit Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM units WHERE id = @UnitId;", conn);
            SqlParameter taskIdParameter = new SqlParameter();
            taskIdParameter.ParameterName = "@UnitId";
            taskIdParameter.Value = id.ToString();
            cmd.Parameters.Add(taskIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            string unitNameFound = null;
            string unitTypeFound = null;
            int weaponIdFound = 0;
            int hpFound = 0;
            int strFound = 0;
            int sklFound = 0;
            int spdFound = 0;
            int lckFound = 0;
            int defFound = 0;
            int resFound = 0;
            int idFound = 0;

            while(rdr.Read())
            {
                unitNameFound = rdr.GetString(1);
                unitTypeFound = rdr.GetString(2);
                weaponIdFound = rdr.GetInt32(3);
                hpFound = rdr.GetInt32(4);
                strFound = rdr.GetInt32(5);
                sklFound = rdr.GetInt32(6);
                spdFound = rdr.GetInt32(7);
                lckFound = rdr.GetInt32(8);
                defFound = rdr.GetInt32(9);
                resFound = rdr.GetInt32(10);
                idFound = rdr.GetInt32(0);
            }
            Unit foundUnit = new Unit(unitNameFound, unitTypeFound, weaponIdFound, hpFound, strFound, sklFound, spdFound, lckFound, defFound, resFound, idFound);

            DB.CloseSqlConnection(rdr, conn);

            return foundUnit;
        }

        public static void DeleteAll()
        {
            DB.TableDeleteAll("units");
        }




    }
}
