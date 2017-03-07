using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SigilOfFlame
{
    public class WeaponTest : IDisposable
    {
        [Fact]
        public void WeaponTest_CategoriesEmptyAtFirst()
        {
          var weaponCount = Weapon.GetAll().Count;

          Assert.Equal(0, weaponCount);
        }

        public void Dispose()
        {
          Unit.DeleteAll();
        }
    }
}
