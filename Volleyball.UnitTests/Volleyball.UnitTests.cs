using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
//using Volleyball;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestInitialize]
        //public void InitializeInfo()
        //{
        //    DataBaseSpy emulationDB = new DataBaseSpy();

        //    Game.SetDataBase(emulationDB);
        //    Team.SetDataBase(emulationDB);
        //    Player.SetDataBase(emulationDB);
        //}

        //[TestMethod]
        //public void PlayerIsCreated()
        //{
        //    var player = new Player("test", 1);
        //    Assert.IsNotNull(player);
        //}

        //[TestMethod]
        //public void TeamIsCreated()
        //{
        //    var team = new  Team("test");
        //    Assert.IsNotNull(team);
        //}

        //[TestMethod]
        //public void GameIsCreated()
        //{
        //    var game = new Game();
        //    Assert.IsNotNull(game);
        //}

        //[TestMethod]
        //public void PlayerIsBaseInstance()
        //{
        //    var player = new Player("test", 1);
        //    Assert.IsInstanceOfType(player, typeof(Base<Player>));
        //}

        //[TestMethod]
        //public void PlayerIsNotTeamInstance()
        //{
        //    var player = new Player("test", 1);
        //    Assert.IsNotInstanceOfType(player, typeof(Base<Team>));
        //}

        //[TestMethod]
        //public void UniqueIdIsSet()
        //{
        //    Team t1 = new Team("test");
        //    Team t2 = new Team("test");
        //    Assert.AreNotEqual(t1.Id, t2.Id);
        //}

        //[TestMethod]
        //public void AddGameToDB()
        //{
        //    Game game = new Game();
        //    game.Save();
        //    Assert.AreSame(game, DataBaseSpy.GamesList.Values.Last());
        //}

        //[TestMethod]
        //public void AddTeamToDB()
        //{
        //    Team team = new Team("test");
        //    team.Save();
        //    Assert.AreSame(team, DataBaseSpy.TeamsList.Values.Last());
        //}

        //[TestMethod]
        //public void AddPlayerToDB()
        //{
        //    Player pl = new Player("test", 0);
        //    pl.Save();
        //    Assert.AreSame(pl, DataBaseSpy.PlayersList.Values.Last());
        //}

        //[TestMethod]
        //public void ReadGameFromDB()
        //{
        //    Game game = new Game("test1", "test2", "test3", "test4");
        //    Game restoredGame = new Game();
            
        //    game.Save();
        //    restoredGame = game.Read();
        //    Assert.ReferenceEquals(game, restoredGame);
        //}

        //[TestMethod]
        //public void ReadTeamFromDB()
        //{
        //    Team team = new Team("test1");
        //    Team restoredTeam;
        //    team.Save();
            
        //    restoredTeam = team.Read();
        //    Assert.ReferenceEquals(team, restoredTeam);
        //}

        //[TestMethod]
        //public void ReadPlayerFromDB()
        //{
        //    Player pl = new Player("test1", 1);
        //    Player restoredPl;
        //    pl.Save();

        //    restoredPl = pl.Read();
        //    Assert.ReferenceEquals(pl, restoredPl);
        //}

        //[TestMethod]
        //public void UpdateGameInDB()
        //{
        //    Game game = new Game("test1", "test2", "test3", "test4");
        //    game.Save();

        //    game.League = "test5";
        //    game.Update();
        //    Assert.AreEqual(DataBaseSpy.GamesList.Values.Last().League, "test5");
        //}

        //[TestMethod]
        //public void UpdateTeamInDB()
        //{
        //    Team team = new Team("test1");
        //    team.Save();

        //    team.Name = "test2";
        //    team.Update();
        //    Assert.AreEqual(DataBaseSpy.TeamsList.Values.Last().Name, "test2");
        //}

        //[TestMethod]
        //public void UpdatePlayerInDB()
        //{
        //    Player pl = new Player("test1", 1);
        //    pl.Save();

        //    pl.Name = "test2";
        //    pl.Update();
        //    Assert.AreEqual(DataBaseSpy.PlayersList.Values.Last().Name, "test2");
        //}

        //[TestMethod]
        //public void DeleteGameFromDB()
        //{
        //    Game game;

        //    game = new Game();
        //    game.Save();
        //    game.Delete();
        //    Assert.IsFalse(DataBaseSpy.GamesList.Values.Contains(game));
        //}

        //[TestMethod]
        //public void DeleteTeamFromDB()
        //{
        //    Team team;
            
        //    team = new Team("test");
        //    team.Save();
        //    team.Delete();
        //    Assert.IsFalse(DataBaseSpy.TeamsList.Values.Contains(team));
        //}

        //[TestMethod]
        //public void DeletePlayerFromDB()
        //{
        //    Player pl;

        //    pl = new Player("test", 0);
        //    pl.Save();
        //    pl.Delete();
        //    Assert.IsFalse(DataBaseSpy.PlayersList.Values.Contains(pl));
        //}
    }
}
