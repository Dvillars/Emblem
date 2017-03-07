using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SigilOfFlame
{
    public class Weapon
    {
        private int _id;
        private string _wepName;
        private string _wepType;
        private int _rng;
        private int _dmg;
        private int _hit;
        private int _crt;
        private string _triStrong;
        private string _triWeak;
        private string _effect;

        public Unit (
        string wepName,
        string wepType,
        int rng,
        int dmg,
        int hit,
        int crt,
        string triStrong,
        string triWeak,
        string effect,
        int id=0)
        {
            _id = id
            _wepName = wepName
            _wepType = wepType
            _rng = rng
            _dmg = dmg
            _hit = hit
            _crt = crt
            _triStrong = triStrong
            _triWeak = triWeak
            _effect = effect
        }


        public int GetId()
        {
            return _id
        }

        public string GetWepName()
        {
            return _wepName
        }
        public void SetWepName(string wepNameNew)
        {
            _wepName = wepNameNew
        }

        public string GetWepType()
        {
            return _wepType
        }
        public void SetWepType(string wepTypeNew)
        {
            _wepType = wepTypeNew
        }

        public int GetRng()
        {
            return _rng
        }
        public void SetRng(int rngNew)
        {
            _rng = rngNew
        }

        public int GetDmg()
        {
            return _dmg
        }
        public void SetDmg(int dmgNew)
        {
            _dmg = dmgNew
        }

        public int GetHit()
        {
            return _hit
        }
        public void SetHit(int hitNew)
        {
            _hit = hitNew
        }

        public int GetCrt()
        {
            return _crt
        }
        public void SetCrt(int crtNew)
        {
            _crt = crtNew
        }

        public string GetTriStrong()
        {
            return _triStrong
        }
        public void SetTriStrong(string triStrongNew)
        {
            _triStrong = triStrongNew
        }

        public string GetTriWeak()
        {
            return _triWeak
        }
        public void SetTriWeak(string triWeakNew)
        {
            _triWeak = triWeakNew
        }

        public string GetEffect()
        {
            return _effect
        }
        public void SetEffect(string effectNew)
        {
            _effect = effectNew
        }

        public override bool Equals(System.Object otherWeapon)
        {
            if (!(otherWeapon is Weapon))
            {
                return false;
            }
            else
            {
                Weapon newWeapon = (Weapon) otherWeapon;
                bool wepNameEquality = this.GetWepName() == newWeapon.GetWepName();
                bool wepTypeEquality = this.GetWepType() == newWeapon.GetWepType();
                bool rngEquality = this.GetRng() == newWeapon.GetRng();
                bool dmgEquality = this.GetDmg() == newWeapon.GetDmg();
                bool hitEquality = this.GetHit() == newWeapon.GetHit();
                bool crtEquality = this.GetCrt() == newWeapon.GetCrt();
                bool triStrongEquality = this.GetTriStrong() == newWeapon.GetTriStrong();
                bool triWeakEquality = this.GetTriWeak() == newWeapon.GetTriWeak();
                bool effectEquality = this.GetEffect() == newWeapon.GetEffect();
                bool idEquality = this.GetId() == newWeapon.GetId();
                return (wepNameEquality && wepTypeEquality && rngEquality && dmgEquality && crtEquality && triStrongEquality && triWeakEquality && idEquality);
            }
        }

        public static List<Weapon> GetAll()
        {
            List<Weapon> allWeapons = new List<Weapon>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM weapons;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                string weaponWepName = rdr.GetString(1);
                string weaponWepType = rdr.GetString(2);
                int weaponRng = rdr.GetInt32(3);
                int weaponDmg = rdr.GetInt32(4);
                int weaponHit = rdr.GetInt32(5);
                int weaponCrt = rdr.GetInt32(6);
                string weaponTriStrong = rdr.GetString(7);
                string weaponTriWeak = rdr.GetString(8);
                string weaponEffect = rdr.GetString(9);
                int weaponId = rdr.GetInt32(0);
                Weapon newWeapon = new Weapon(weaponWepNameEquality && weaponWepTypeEquality && weaponRngEquality && weaponDmgEquality && weaponCrtEquality && weaponTriStrongEquality && weaponTriWeakEquality && weaponEffect && weaponIdEquality);
                allWeapons.Add(newWeapon);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return allWeapons;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO weapons (name) OUTPUT INSERTED.id VALUES (@WeaponName);", conn);

            SqlParameter nameParameter = new SqlParameter();
            nameParameter.ParameterName = "@WeaponName";
            nameParameter.Value = this.GetName();

            cmd.Parameters.Add(nameParameter);

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

        public static Weapon Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM weapons WHERE id = @WeaponId;", conn);
            SqlParameter weaponIdParameter = new SqlParameter();
            weaponIdParameter.ParameterName = "@WeaponId";
            weaponIdParameter.Value = id.ToString();
            cmd.Parameters.Add(weaponIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundWeaponId = 0;
            string foundWeaponName = null;

            while(rdr.Read())
            {
                foundWeaponId = rdr.GetInt32(0);
                foundWeaponName = rdr.GetString(1);
            }
            Weapon foundWeapon = new Weapon(foundWeaponName,  foundWeaponId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundWeapon;
        }

        // public void Delete()
        // {
        //   SqlConnection conn = DB.Connection();
        //   conn.Open();
        //
        //   SqlCommand cmd = new SqlCommand("DELETE FROM weapons WHERE id = @WeaponId; DELETE FROM categories_weapons WHERE weapon_id = @WeaponId;", conn);
        //   SqlParameter weaponIdParameter = new SqlParameter();
        //   weaponIdParameter.ParameterName = "@WeaponId";
        //   weaponIdParameter.Value = this.GetId();
        //
        //   cmd.Parameters.Add(weaponIdParameter);
        //   cmd.ExecuteNonQuery();
        //
        //   if (conn != null)
        //   {
        //     conn.Close();
        //   }
        // }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM weapons;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
