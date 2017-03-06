using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SigilOfFlame
{
    public class PlayerTest : IDisposable
    {
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
            Player testPlayer = new Player("Derek");

            //Act
            testPlayer.Save();
            List<Player> result = Player.GetAll();
            List<Player> testList = new List<Player>{testPlayer};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void PlayerTest_Save_AssignsIdToObject()
        {
            //Arrange
            Player testPlayer = new Player("Derek");

            //Act
            testPlayer.Save();
            Player savedPlayer = Player.GetAll()[0];

            int result = savedPlayer.GetId();
            int testId = testPlayer.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void Test_FindFindsPlayerInDatabase()
        {
            //Arrange

            Player testPlayer = new Player("Derek");
            testPlayer.Save();

            //Act
            Player foundPlayer = Player.Find(testPlayer.GetId());

            //Assert
            Assert.Equal(testPlayer, foundPlayer);
        }

        [Fact]
        public void Test_Delete_DeletesTaskAssociationsFromDatabase()
        {
            //Arrange
            Category testCategory = new Category("Home stuff");
            testCategory.Save();

            Task testTask = new Task("Mow the lawn");
            testTask.Save();

            //Act
            testTask.AddCategory(testCategory);
            testTask.Delete();

            List<Task> resultCategoryTasks = testCategory.GetTasks();
            List<Task> testCategoryTasks = new List<Task> {};

            //Assert
            Assert.Equal(testCategoryTasks, resultCategoryTasks);
        }

        public void Dispose()
        {
            Player.DeleteAll();
        }
    }
}
