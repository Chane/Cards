namespace CardGame.Test
{
    using System;
    using AdamSpeight2008.Cards.Implementations.Card;
    using CardGame.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CardStackTest
    {
        [TestMethod]
        public void TestTopCard()
        {
            var card = new PlayingCard(PlayingCard.CardFace.Eight, PlayingCard.CardSuit.Hearts);
            var stack = new CardStack();

            stack.Push(card);

            Assert.AreEqual(card, stack.TopCard);
        }

        [TestMethod]
        public void TestTopValue()
        {
            var card = new PlayingCard(PlayingCard.CardFace.Eight, PlayingCard.CardSuit.Hearts);
            var stack = new CardStack();

            stack.Push(card);

            Assert.AreEqual(8, stack.TopValue);
        }

        [TestMethod]
        public void TestNullValues()
        {
            var stack = new CardStack();
            Assert.IsNull(stack.TopCard);
            Assert.IsNull(stack.TopSuit);
            Assert.IsNull(stack.TopValue);
        }

        [TestMethod]
        public void TestTopSuit()
        {
            var card = new PlayingCard(PlayingCard.CardFace.Eight, PlayingCard.CardSuit.Hearts);
            var stack = new CardStack();

            stack.Push(card);

            Assert.AreEqual("Hearts", stack.TopSuit);
        }
    }
}
