using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SigilOfFlame
{
    public class UnitTest : IDisposable
    {
        public static Unit theDeity = new Unit("Deity", "General", 1, 60, 45, 20, 10, 14, 58, 58);
        public static Unit thePansy = new Unit("Pansy", "Bard", 1, 20, 1, 8, 8, 8, 8, 60);
        public static int unitCount = Unit.GetAll().Count;
        // public static List<Unit> unitList = Unit.GetAll();
        public UnitTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=sigil_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void UnitTest_CategoriesEmptyAtFirst()
        {
            //Arrange, Act, Assert
            Assert.Equal(0, unitCount);

        }


        [Fact]
        public void UnitTest_Save_SavesCategoryToDatabase()
        {
            //Arrange
            theDeity.Save();

            //Act
            List<Unit> unitList = Unit.GetAll();

            //Assert
            Assert.Equal(theDeity, unitList[0]);

        }


        [Fact]
        public void UnitTest_Save_AssignsIdToCategoryObject()
        {
            //Arrange, Act
            theDeity.Save();
            List<Unit> unitList = Unit.GetAll();

            //Assert
            Assert.Equal(theDeity.GetUnitId(), unitList[0].GetUnitId());

        }


        [Fact]
        public void UnitTest_Equal_ReturnsTrueForSameName()
        {
            // Arrange, Act
            theDeity.Save();
            List<Unit> unitList = Unit.GetAll();

            // Assert
            Assert.Equal(theDeity.GetUnitName(), unitList[0].GetUnitName());


        }


        [Fact]
        public void UnitTest_Find_FindsCategoryInDatabase()
        {
            // Arrange, Act
            theDeity.Save();
            Unit foundUnit = Unit.Find(theDeity.GetUnitId());

            // Assert
            Assert.Equal(theDeity, foundUnit);

        }
        //
        // [Fact]
        // public void UnitTest_Delete_DeletesCategoryFromDatabase()
        // {
        //Arrange

        //Act

        //Assert

        // }

        public void Dispose()
        {
            Unit.DeleteAll();
            Player.DeleteAll();
        }




    }
}
