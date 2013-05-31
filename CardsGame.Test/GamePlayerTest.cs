namespace CardGame.Test
{
    using System;
    using System.Diagnostics;
    using CardGame.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GamePlayerTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var val = 5;
            var player = new GamePlayer(val);
            Assert.AreEqual(val, player.PendingGames);
        }

        [TestMethod]
        public void TestPlayGame()
        {
            var val = 5;
            var player = new GamePlayer(val);
            player.PlaySingleGame();
            Assert.AreEqual(1, player.GamesPlayed);
        }

        [TestMethod]
        public void TestPlayGames()
        {
            var val = 5;
            var player = new GamePlayer(val);
            player.PlayGames();
            Assert.AreEqual(val, player.GamesPlayed);
        }

        [TestMethod]
        public void TestWinCount()
        {
            var val = 5;
            var player = new GamePlayer(val);
            player.PlaySingleGame();
            Assert.AreNotEqual(0, player.Wins);
        }

        [TestMethod]
        public void TestWinCountInitial()
        {
            var val = 5;
            var player = new GamePlayer(val);
            Assert.AreEqual(0, player.Wins);
        }

        [TestMethod]
        public void IntegrationTestFindWin()
        {
            var timer = new Stopwatch();
            timer.Start();
            var player = new GamePlayer(1);
            while (player.Wins == 0)
            {
                player.PlaySingleGame();
                if (player.Wins == 0)
                {
                    player.PendingGames++;
                }
            }

            timer.Stop();
            Console.Write(timer.Elapsed);
        }
    }
}
