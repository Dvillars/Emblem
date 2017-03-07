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
            _unitName = unitName
            _unitType = unitType
            _weaponId = weaponId
            _hp = hp
            _str = str
            _skl = skl
            _spd = spd
            _lck = lck
            _def = def
            _res = res
            _id = id
        }

        public string GetUnitName()
        {
            return unitName;
        }

        public string GetUnitType()
        {
            return unitType;
        }

        public int GetWeaponId()
        {
            return weaponId;
        }

        public int GetHitpoints()
        {
            return hp;
        }

        public int GetStrength()
        {
            return str;
        }

        public int GetSkill()
        {
            return skl;
        }

        public int GetSpeed()
        {
            return spd;
        }

        public int GetLuck()
        {
            return lck;
        }

        public int GetDefense()
        {
            return def;
        }

        public int GetResistance()
        {
            return res;
        }

        public void SetUnitName(int unitNameNew)
        {
            _unitName = unitNameNew;
        }

        public void SetUnitType(int unitTypeNew)
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
            return _Id;
        }

        public override bool Equals(System.Object otherPlayer)
        {
            if (!(otherPlayer is Player))
            {
                return false;
            }
            else
            {
                Player newPlayer = (Player) otherPlayer;
                bool unitNameEquality = this.GetUnitName() == newPlayer.GetUnitName();
                bool unitTypeEquality = this.GetUnitType() == newPlayer.GetUnitType();
                bool weaponIdEquality = this.GetWeaponId() == newPlayer.GetWeaponId();
                bool hitpointsEquality = this.GetHitpoints() == newPlayer.GetHitpoints();
                bool strengthEquality = this.GetStrength() == newPlayer.GetStrength();
                bool skillEquality = this.GetSkill() == newPlayer.GetSkill();
                bool speedEquality = this.GetSpeed() == newPlayer.GetSpeed();
                bool luckEquality = this.GetLuck() == newPlayer.GetLuck();
                bool defenseEquality = this.GetDefense() == newPlayer.GetDefense();
                bool resistanceEquality = this.GetResistance() == newPlayer.GetResistance();
                bool unitIdEquality = this.GetUnitId() == newPlayer.GetUnitId();
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
                string unitName = rdr.GetInt32(1);
                string unitType = rdr.GetInt32(2);
                int weaponId = rdr.GetInt32(3);
                int hp = rdr.GetInt32(4);
                int str = rdr.GetInt32(5);
                int skl = rdr.GetInt32(6);
                int spd = rdr.GetInt32(7);
                int lck = rdr.GetInt32(8);
                int def = rdr.GetString(9);
                int res = rdr.GetString(10);
                int id = rdr.GetString(0);
                Unit newUnit = new Unit(unitName, unitType, weaponId, hp, str, skl, spd, lck, def, res, id);
                allUnits.Add(newUnit);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return allUnits;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO units (unitName, unitType, weaponId, hp, str, skl, spd, lck, def, res) OUTPUT INSERTED.id VALUES (@UnitName, @UnitType, @WeaponId, @Hitpoints, @Strength, @Skill, @Speed, @Luck, @Defense, @Resistance);", conn);

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

            cmd.Parameters.Add(UnitNameParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Unit Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM tasks WHERE id = @UnitId;", conn);
            SqlParameter taskIdParameter = new SqlParameter();
            taskIdParameter.ParameterName = "@UnitId";
            taskIdParameter.Value = id.ToString();
            cmd.Parameters.Add(taskIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            string unitName = null;
            string unitType = null;
            int weaponId = 0;
            int hp = 0;
            int str = 0;
            int skl = 0;
            int spd = 0;
            int lck = 0;
            int def = 0;
            int res = 0;
            int id = 0;

            while(rdr.Read())
            {
                string unitName = rdr.GetInt32(1);
                string unitType = rdr.GetInt32(2);
                int weaponId = rdr.GetInt32(3);
                int hp = rdr.GetInt32(4);
                int str = rdr.GetInt32(5);
                int skl = rdr.GetInt32(6);
                int spd = rdr.GetInt32(7);
                int lck = rdr.GetInt32(8);
                int def = rdr.GetString(9);
                int res = rdr.GetString(10);
                int id = rdr.GetString(0);
            }
            Unit foundUnit = new Unit(unitName, unitType, weaponId, hp, str, skl, spd, lck, def, res, id);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundUnit;
        }



    }
}
