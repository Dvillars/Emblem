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

        public Weapon (string wepName, string wepType, int rng, int dmg, int hit, int crt, string triStrong, string triWeak, string effect, int id=0)
        {
            _id = id;
            _wepName = wepName;
            _wepType = wepType;
            _rng = rng;
            _dmg = dmg;
            _hit = hit;
            _crt = crt;
            _triStrong = triStrong;
            _triWeak = triWeak;
            _effect = effect;
        }


        public int GetId()
        {
            return _id;
        }

        public string GetWeaponName()
        {
            return _wepName;
        }
        public void SetWeaponName(string wepNameNew)
        {
            _wepName = wepNameNew;
        }

        public string GetWeaponType()
        {
            return _wepType;
        }
        public void SetWeaponType(string wepTypeNew)
        {
            _wepType = wepTypeNew;
        }

        public int GetRange()
        {
            return _rng;
        }
        public void SetRange(int rngNew)
        {
            _rng = rngNew;
        }

        public int GetDamage()
        {
            return _dmg;
        }
        public void SetDamage(int dmgNew)
        {
            _dmg = dmgNew;
        }

        public int GetHit()
        {
            return _hit;
        }
        public void SetHit(int hitNew)
        {
            _hit = hitNew;
        }

        public int GetCrit()
        {
            return _crt;
        }
        public void SetCrit(int crtNew)
        {
            _crt = crtNew;
        }

        public string GetTriStrong()
        {
            return _triStrong;
        }
        public void SetTriStrong(string triStrongNew)
        {
            _triStrong = triStrongNew;
        }

        public string GetTriWeak()
        {
            return _triWeak;
        }
        public void SetTriWeak(string triWeakNew)
        {
            _triWeak = triWeakNew;
        }

        public string GetEffect()
        {
            return _effect;
        }
        public void SetEffect(string effectNew)
        {
            _effect = effectNew;
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
                bool wepNameEquality = this.GetWeaponName() == newWeapon.GetWeaponName();
                bool wepTypeEquality = this.GetWeaponType() == newWeapon.GetWeaponType();
                bool rngEquality = this.GetRange() == newWeapon.GetRange();
                bool dmgEquality = this.GetDamage() == newWeapon.GetDamage();
                bool hitEquality = this.GetHit() == newWeapon.GetHit();
                bool crtEquality = this.GetCrit() == newWeapon.GetCrit();
                bool triStrongEquality = this.GetTriStrong() == newWeapon.GetTriStrong();
                bool triWeakEquality = this.GetTriWeak() == newWeapon.GetTriWeak();
                bool effectEquality = this.GetEffect() == newWeapon.GetEffect();
                bool idEquality = this.GetId() == newWeapon.GetId();

                return (wepNameEquality && wepTypeEquality && rngEquality && dmgEquality && hitEquality && crtEquality && triStrongEquality && triWeakEquality && idEquality);
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
                string weaponWepNameEquality = rdr.GetString(1);
                string weaponWepTypeEquality = rdr.GetString(2);
                int weaponRngEquality = rdr.GetInt32(3);
                int weaponDmgEquality = rdr.GetInt32(4);
                int weaponHitEquality = rdr.GetInt32(5);
                int weaponCrtEquality = rdr.GetInt32(6);
                string weaponTriStrongEquality = rdr.GetString(7);
                string weaponTriWeakEquality = rdr.GetString(8);
                string weaponEffectEquality = rdr.GetString(9);
                int weaponIdEquality = rdr.GetInt32(0);

                Weapon newWeapon = new Weapon(weaponWepNameEquality, weaponWepTypeEquality, weaponRngEquality, weaponHitEquality, weaponDmgEquality, weaponCrtEquality, weaponTriStrongEquality, weaponTriWeakEquality, weaponEffectEquality, weaponIdEquality);
                allWeapons.Add(newWeapon);
            }

            DB.CloseSqlConnection(rdr, conn);

            return allWeapons;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO weapons (wep_name, wep_type, rng, dmg, hit, crt, tri_strong, tri_weak, effect) OUTPUT INSERTED.id VALUES (@WeaponName, @WeaponType, @Range, @Damage, @Hit, @Crit, @TriStrong, @TriWeak, @Effect);", conn);

            cmd.Parameters.Add(new SqlParameter("@WeaponName", this.GetWeaponName()));
            cmd.Parameters.Add(new SqlParameter("@WeaponType", this.GetWeaponType()));
            cmd.Parameters.Add(new SqlParameter("@Range", this.GetRange()));
            cmd.Parameters.Add(new SqlParameter("@Damage", this.GetDamage()));
            cmd.Parameters.Add(new SqlParameter("@Hit", this.GetHit()));
            cmd.Parameters.Add(new SqlParameter("@Crit", this.GetCrit()));
            cmd.Parameters.Add(new SqlParameter("@TriStrong", this.GetTriStrong()));
            cmd.Parameters.Add(new SqlParameter("@TriWeak", this.GetTriWeak()));
            cmd.Parameters.Add(new SqlParameter("@Effect", this.GetEffect()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            DB.CloseSqlConnection(rdr, conn);
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

            string foundWeaponWepName = null;
            string foundWeaponWepType = null;
            int foundWeaponRng = 0;
            int foundWeaponDmg = 0;
            int foundWeaponHit = 0;
            int foundWeaponCrt = 0;
            string foundWeaponTriStrong = null;
            string foundWeaponTriWeak = null;
            string foundWeaponEffect = null;
            int foundWeaponId = 0;


            while(rdr.Read())
            {
                foundWeaponWepName = rdr.GetString(1);
                foundWeaponWepType = rdr.GetString(2);
                foundWeaponRng = rdr.GetInt32(3);
                foundWeaponDmg = rdr.GetInt32(4);
                foundWeaponHit = rdr.GetInt32(5);
                foundWeaponCrt = rdr.GetInt32(6);
                foundWeaponTriStrong = rdr.GetString(7);
                foundWeaponTriWeak = rdr.GetString(8);
                foundWeaponEffect = rdr.GetString(9);
                foundWeaponId = rdr.GetInt32(0);
            }

            Weapon foundWeapon = new Weapon(foundWeaponWepName, foundWeaponWepType, foundWeaponRng, foundWeaponDmg, foundWeaponHit, foundWeaponCrt, foundWeaponTriStrong, foundWeaponTriWeak, foundWeaponEffect, foundWeaponId);

            DB.CloseSqlConnection(rdr, conn);

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
             DB.TableDeleteAll("weapons");
        }
    }
}
