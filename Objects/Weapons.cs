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

        public Unit (string wepName, string wepType, int rng, int dmg, int hit, int crt, string triStrong, string triWeak, string effect, int id=0)
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

        
    }
}
