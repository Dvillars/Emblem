using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SigilOfFlame
{
    public class WeaponTest : IDisposable
    {
        public static Weapon theDeity = new Weapon("Deity", "Spear", 1, 10, 95, 0, "Sword", "Ax", "Null");
        public static Weapon theShot = new Weapon("Shot", "Bow", 2, 15, 100, 5, "Null", "Null", "Pegasus Knight");
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
            theDeity.Save();

            //Act
            List<Weapon> weaponList = Weapon.GetAll();

            //Assert
            Assert.Equal(theDeity.GetWeaponName(), weaponList[0].GetWeaponName());
        }

        [Fact]
        public void WeaponTest_Save_AssignsIdToWeaponObject()
        {
            //Arrange, Act
            theDeity.Save();
            List<Weapon> weaponList = Weapon.GetAll();

            //Assert
            Assert.Equal(theDeity.GetWeaponId(), weaponList[0].GetWeaponId());
        }

        [Fact]
        public void WeaponTest_Equal_ReturnsTrueForSameName()
        {
            // Arrange, Act
            theDeity.Save();
            List<Weapon> weaponList = Weapon.GetAll();

            // Assert
            Assert.Equal(theDeity.GetWeaponName(), weaponList[0].GetWeaponName());
        }

        [Fact]
        public void WeaponTest_Find_FindsWeaponInDatabase()
        {
            // Arrange, Act
            theDeity.Save();
            Weapon foundWeapon = Weapon.Find(theDeity.GetWeaponId());

            // Assert
            Assert.Equal(theDeity, foundWeapon);
        }

        public void Dispose()
        {
          Weapon.DeleteAll();
        }
    }
}
