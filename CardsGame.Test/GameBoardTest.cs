namespace CardsGame.Test
{
    using System;
    using System.IO;
    using AdamSpeight2008.Cards.Implementations.Card;
    using AdamSpeight2008.Cards.Interfaces.Deck;
    using CardGame.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestGameBoard
    {
        [TestMethod]
        public void TestInitialState()
        {
            var board = new GameBoard();
            Assert.IsNotNull(board.Slot1);
            Assert.IsNotNull(board.Slot2);
            Assert.IsNotNull(board.Slot3);
            Assert.IsNotNull(board.Slot4);
        }

        [TestMethod]
        public void TestDealHand()
        {
            var board = new GameBoard();
            board.DealRound();

            Assert.AreEqual(1, board.Slot1.Count);
            Assert.AreEqual(1, board.Slot2.Count);
            Assert.AreEqual(1, board.Slot3.Count);
            Assert.AreEqual(1, board.Slot4.Count);
            Assert.AreEqual(1, board.Rounds);
        }

        [TestMethod]
        public void TestDealHands()
        {
            var board = new GameBoard();
            board.DealRound();
            board.DealRound();

            Assert.AreEqual(2, board.Slot1.Count);
            Assert.AreEqual(2, board.Slot2.Count);
            Assert.AreEqual(2, board.Slot3.Count);
            Assert.AreEqual(2, board.Slot4.Count);
            Assert.AreEqual(2, board.Rounds);
        }

        [TestMethod]
        public void TestSlot1And2ComparisonSlot1Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot1.Count);
        }

        [TestMethod]
        public void TestSlot1And2ComparisonSlot2Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot2.Count);
        }

        [TestMethod]
        public void TestSlot1And3ComparisonSlot1Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot1.Count);
        }

        [TestMethod]
        public void TestSlot1And3ComparisonSlot3Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot3.Count);
        }
        
        [TestMethod]
        public void TestSlot1And4ComparisonSlot1Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot1.Count);
        }

        [TestMethod]
        public void TestSlot1And4ComparisonSlot4Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot4.Count);
        }

        [TestMethod]
        public void TestSlot2And3ComparisonSlot2Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot2.Count);
        }

        [TestMethod]
        public void TestSlot2And3ComparisonSlot3Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot3.Count);
        }

        [TestMethod]
        public void TestSlot2And4ComparisonSlot2Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot2.Count);
        }

        [TestMethod]
        public void TestSlot2And4ComparisonSlot4Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot4.Count);
        }

        [TestMethod]
        public void TestSlot3And4ComparisonSlot3Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot3.Count);
        }

        [TestMethod]
        public void TestSlot3And4ComparisonSlot4Lower()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Clubs))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(1, board.ClearSlotCount);
            Assert.AreEqual(0, board.Slot4.Count);
        }
        
        [TestMethod]
        public void TestAllOneSuit()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Eight, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Play();

            Assert.AreEqual(3, board.ClearSlotCount);
            Assert.AreEqual(1, board.Slot2.Count);
        }

        [TestMethod]
        public void TestCanPlay()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Eight, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            Assert.IsTrue(board.CanPlay);
        }

        [TestMethod]
        public void TestMaxThirteenRounds()
        {
            var board = new GameBoard();
            for (var i = 0; i < 20; i++)
            {
                board.DealRound();
            }

            Assert.AreEqual(13, board.Rounds);
        }

        [TestMethod]
        public void IntegrationTestPlayGame()
        {
            var board = new GameBoard();
            board.MessageEvent += board_MessageEvent;
            board.StartGame();

            Assert.IsFalse(board.CanDeal);
            Assert.IsFalse(board.CanPlay);

            Assert.AreEqual(13, board.Rounds);
            Assert.IsTrue(board.Plays > 0);
        }

        [TestMethod]
        public void TestHighestCardStack()
        {
            var highestCard = new PlayingCard(PlayingCard.CardFace.Eight, PlayingCard.CardSuit.Hearts);

            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(highestCard)
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();
            board.DealRound();

            Assert.AreEqual(highestCard, board.HighestValueCardStack.Peek());
        }

        [TestMethod]
        public void TestHighestCardStackInitial()
        {
            var board = new GameBoard();
            Assert.IsNull(board.HighestValueCardStack);
        }

        [TestMethod]
        public void TestFirstClearCardStack()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            board.Slot3.Pop();

            Assert.AreEqual(board.Slot3, board.FirstClearStack);
        }

        [TestMethod]
        public void TestFirstClearCardStackInitial()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            Assert.IsNull(board.FirstClearStack);
        }

        [TestMethod]
        public void TestHasNontrivialStack()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Spades))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Spades));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();
            board.DealRound();

            Assert.IsTrue(board.HasNontrivialStack);
        }

        [TestMethod]
        public void TestHasNontrivialStackOneCard()
        {
            var mDeck = new Mock<IDeck<PlayingCard>>();
            mDeck.Setup(m => m.CardsLeft()).Returns(4);
            mDeck.SetupSequence(m => m.Deal())
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Three, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Five, PlayingCard.CardSuit.Hearts))
                .Returns(new PlayingCard(PlayingCard.CardFace.Two, PlayingCard.CardSuit.Hearts));
            var board = new GameBoard(mDeck.Object);
            board.DealRound();

            Assert.IsFalse(board.HasNontrivialStack);
        }

        [TestMethod]
        public void TestHasNontrivialStackInitial()
        {
            var board = new GameBoard();
            Assert.IsFalse(board.HasNontrivialStack);
        }

        private void board_MessageEvent(object message, EventArgs e)
        {
            Console.WriteLine(message);
        }
    }
}