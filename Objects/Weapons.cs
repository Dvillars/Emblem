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


    }
}
