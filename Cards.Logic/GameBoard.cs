namespace CardGame.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using AdamSpeight2008.Cards.Implementations.Card;
    using AdamSpeight2008.Cards.Implementations.Generators;
    using AdamSpeight2008.Cards.Implementations.Shuffle;
    using AdamSpeight2008.Cards.Interfaces.Deck;
    
    public class GameBoard
    {
        public CardStack Slot1 { get; private set; }
        public CardStack Slot2 { get; private set; }
        public CardStack Slot3 { get; private set; }
        public CardStack Slot4 { get; private set; }

        public IDeck<PlayingCard> CardDeck { get; private set; }

        public int Rounds { get; private set; }

        public int Plays { get; private set; }

        public int ClearSlotCount 
        {
            get 
            {
                var i = 0;
                if (this.Slot1.Count == 0)
                {
                    i++;
                }

                if (this.Slot2.Count == 0)
                {
                    i++;
                }

                if (this.Slot3.Count == 0)
                {
                    i++;
                }

                if (this.Slot4.Count == 0)
                {
                    i++;
                }

                return i;
            }
        }

        public bool HasClearSlot
        {
            get
            {
                return this.ClearSlotCount > 0;
            }
        }

        public event EventHandler<EventArgs> MessageEvent;

        public CardStack HighestValueCardStack
        {
            get
            {
                int v1 = this.Slot1.Count > 1 ? (int)this.Slot1.Peek().Face : 0;
                int v2 = this.Slot2.Count > 1 ? (int)this.Slot2.Peek().Face : 0;
                int v3 = this.Slot3.Count > 1 ? (int)this.Slot3.Peek().Face : 0;
                int v4 = this.Slot4.Count > 1 ? (int)this.Slot4.Peek().Face : 0;
                var list = new List<int> { v1, v2, v3, v4 };
                var maxValue = list.Max();
                if (maxValue == 0)
                {
                    return null;
                }

                if (v1 == maxValue)
                {
                    return this.Slot1;
                }

                if (v2 == maxValue)
                {
                    return this.Slot2;
                }

                if (v3 == maxValue)
                {
                    return this.Slot3;
                }

                if (v4 == maxValue)
                {
                    return this.Slot4;
                }

                return null;
            }
        }

        public CardStack FirstClearStack
        {
            get
            {
                if (this.Slot1.Count == 0)
                {
                    return this.Slot1;
                }

                if (this.Slot2.Count == 0)
                {
                    return this.Slot2;
                }

                if (this.Slot3.Count == 0)
                {
                    return this.Slot3;
                }

                if (this.Slot4.Count == 0)
                {
                    return this.Slot4;
                }

                return null;
            }
        }

        public bool HasNontrivialStack
        {
            get
            {
                if (this.Slot1.Count > 1)
                {
                    return true;
                }

                if (this.Slot2.Count > 1)
                {
                    return true;
                }

                if (this.Slot3.Count > 1)
                {
                    return true;
                }

                if (this.Slot4.Count > 1)
                {
                    return true;
                }

                return false;
            }
        }

        public bool CanDeal
        {
            get
            {
                return this.CardDeck.CardsLeft() > 0;
            }
        }

        public bool CanPlay
        {
            get
            {
                if (this.ClearSlotCount > 0)
                {
                    return false;
                }

                if (Slot1.TopSuit == Slot2.TopSuit)
                {
                    return true;
                }

                if (Slot1.TopSuit == Slot3.TopSuit)
                {
                    return true;
                }

                if (Slot1.TopSuit == Slot4.TopSuit)
                {
                    return true;
                }

                if (Slot2.TopSuit == Slot3.TopSuit)
                {
                    return true;
                }

                if (Slot2.TopSuit == Slot4.TopSuit)
                {
                    return true;
                }

                if (Slot3.TopSuit == Slot4.TopSuit)
                {
                    return true;
                }

                return false;
            }
        }

        public GameBoard()
        {
            this.CardDeck = new PlayingCards_Gen().GenerateDeck();
            var s = new RandomShuffle<PlayingCard>();
            this.CardDeck.Shuffle(s);
            InitializeSlots();
        }

        public GameBoard(IDeck<PlayingCard> deck)
        {
            this.CardDeck = deck;
            InitializeSlots();
        }

        public void DealRound()
        {
            if (this.CanDeal)
            {
                this.Slot1.Push(this.CardDeck.Deal());
                this.Slot2.Push(this.CardDeck.Deal());
                this.Slot3.Push(this.CardDeck.Deal());
                this.Slot4.Push(this.CardDeck.Deal());
                this.Rounds++;
            }
        }

        public void Play()
        {
            while (this.CanPlay)
            {
                CompareSlots(this.Slot1, this.Slot2);
                CompareSlots(this.Slot1, this.Slot3);
                CompareSlots(this.Slot1, this.Slot4);
                CompareSlots(this.Slot2, this.Slot3);
                CompareSlots(this.Slot2, this.Slot4);
                CompareSlots(this.Slot3, this.Slot4);
                this.Plays++;
            }

            while (this.HasClearSlot && this.HasNontrivialStack)
            {
                MoveHighest();
            }
        }

        public void StartGame()
        {
            while (this.CanDeal)
            {
                this.DealRound();
                this.Play();
            }

            Message("Deals: " + this.Rounds + ", Plays: " + this.Plays);
            Message("Cards in slot 1: " + this.Slot1.Count);
            Message("Cards in slot 2: " + this.Slot2.Count);
            Message("Cards in slot 3: " + this.Slot3.Count);
            Message("Cards in slot 4: " + this.Slot4.Count);
        }

        private void Message(string message)
        {
            if (this.MessageEvent != null)
            {
                this.MessageEvent(message, new EventArgs());
            }
        }

        private void InitializeSlots()
        {
            this.Slot1 = new CardStack();
            this.Slot2 = new CardStack();
            this.Slot3 = new CardStack();
            this.Slot4 = new CardStack();
        }

        private void MoveHighest()
        {
            if (this.HighestValueCardStack != null)
            {
                var clearStack = this.FirstClearStack;
                var card = this.HighestValueCardStack.Pop();
                clearStack.Push(card);
            }
        }

        private static void CompareSlots(CardStack cardStack1, CardStack cardStack2)
        {
            if (cardStack1.TopSuit == cardStack2.TopSuit)
            {
                if (cardStack1.TopValue.HasValue && cardStack2.TopValue.HasValue)
                {
                    if (cardStack1.TopValue > cardStack2.TopValue)
                    {
                        cardStack2.Pop();
                    }
                    else
                    {
                        cardStack1.Pop();
                    }
                }
            }
        }
    }
}
