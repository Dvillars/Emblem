using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SigilOfFlame
{
    public class CategoryTest : IDisposable
    {
      public static Unit theDeity = new Unit("Deity", "General", 1, 60, 45, 20, 10, 14, 58, 58);
      public static Unit thePansy = new Unit("Pansy", "Bard", 1, 20, 1, 8, 8, 8, 8, 60);
      public CategoryTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=sigil_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CategoriesEmptyAtFirst()
    {
      var unitCount = Unit.GetAll().Count;

      Assert.Equal(0, unitCount);
    }


    // [Fact]
    // public void Test_Save_SavesCategoryToDatabase()
    // {
    // }
    //
    //
    // [Fact]
    // public void Test_Save_AssignsIdToCategoryObject()
    // {
    // }
    //
    //
    // [Fact]
    // public void Test_Equal_ReturnsTrueForSameName()
    // {
    // }
    //
    //
    // [Fact]
    // public void Test_Find_FindsCategoryInDatabase()
    // {
    // }
    //
    // [Fact]
    // public void Test_Delete_DeletesCategoryFromDatabase()
    // {
    // }

    public void Dispose()
    {
      Unit.DeleteAll();
    }




    }
}
