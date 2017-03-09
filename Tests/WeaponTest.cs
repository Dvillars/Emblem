using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using SigilOfFlame.Objects;


namespace SigilOfFlame
{
    public class WeaponTest : IDisposable
    {
        public static Weapon coolPokey = new Weapon("Cool Pokey", "Spear", 1, 10, 95, 0, "Sword", "Ax", "Null");
        public static Weapon superShot = new Weapon("Super Shot", "Bow", 2, 15, 100, 5, "Null", "Null", "Pegasus Knight");
        public static int weaponCount = Weapon.GetAll().Count;

        public WeaponTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=sigil_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void WeaponTest_CategoriesEmptyAtFirst()
        {
            //Arrange, Act, Assert
            Assert.Equal(0, weaponCount);

        }

        [Fact]
        public void WeaponTest_Save_SavesWeaponToDatabase()
        {
            //Arrange
            coolPokey.Save();

            //Act
            List<Weapon> weaponList = Weapon.GetAll();

            //Assert
            Assert.Equal(coolPokey.GetWeaponName(), weaponList[0].GetWeaponName());
        }

        [Fact]
        public void WeaponTest_Save_AssignsIdToWeaponObject()
        {
            //Arrange, Act
            coolPokey.Save();
            List<Weapon> weaponList = Weapon.GetAll();

            //Assert
            Assert.Equal(coolPokey.GetWeaponId(), weaponList[0].GetWeaponId());
        }

        [Fact]
        public void WeaponTest_Equal_ReturnsTrueForSameName()
        {
            // Arrange, Act
            coolPokey.Save();
            List<Weapon> weaponList = Weapon.GetAll();

            // Assert
            Assert.Equal(coolPokey.GetWeaponName(), weaponList[0].GetWeaponName());
        }

        [Fact]
        public void WeaponTest_Find_FindsWeaponInDatabase()
        {
            // Arrange, Act
            coolPokey.Save();
            Weapon foundWeapon = Weapon.Find(coolPokey.GetWeaponId());

            // Assert
            Assert.Equal(coolPokey, foundWeapon);
        }

        public void Dispose()
        {
          Weapon.DeleteAll();
          Unit.DeleteAll();
        }
    }
}
