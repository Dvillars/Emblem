using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using SigilOfFlame.Objects;


namespace SigilOfFlame
{
    public class PlayerTest : IDisposable
    {
        public static Unit theDeity = new Unit("Deity", "General", 1, 60, 45, 20, 10, 14, 58, 58);
        public static Unit thePansy = new Unit("Pansy", "Bard", 1, 20, 1, 8, 8, 8, 8, 60);
        public static Player marc = new Player("Marc");
        public PlayerTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=sigil_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void PlayerTest_DatabaseEmptyAtFirst()
        {
            //Arrange, Act
            int result = Player.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void PlayerTest_Save_SavesToDatabase()
        {
            //Arrange


            //Act
            marc.Save();
            List<Player> result = Player.GetAll();
            List<Player> testList = new List<Player>{marc};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void PlayerTest_Save_AssignsIdToObject()
        {
            //Arrange


            //Act
            marc.Save();
            Player savedPlayer = Player.GetAll()[0];

            int result = savedPlayer.GetId();
            int testId = marc.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void Test_FindFindsPlayerInDatabase()
        {
            //Arrange


            marc.Save();

            //Act
            Player foundPlayer = Player.Find(marc.GetId());

            //Assert
            Assert.Equal(marc, foundPlayer);
        }

        [Fact]
        public void PlayerTest_AddUnitsToPlayerRoster()
        {
            theDeity.Save();
            thePansy.Save();
            marc.Save();

            marc.AddUnit(theDeity);
            marc.AddUnit(thePansy);

            var roster = marc.GetUnits();
            Assert.Equal(theDeity.GetUnitId(), roster[0].GetUnitId());
        }

        public void Dispose()
        {
            Player.DeleteAll();
            Unit.DeleteAll();
        }
    }
}
