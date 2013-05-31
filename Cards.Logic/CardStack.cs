namespace CardGame.Logic
{
    using System.Collections.Generic;
    using AdamSpeight2008.Cards.Implementations.Card;
    using AdamSpeight2008.Cards.Interfaces.Card;

    public class CardStack : Stack<PlayingCard>
    {
        public int? TopValue 
        {
            get
            {
                if (this.Count > 0)
                {
                    return (int)this.TopCard.Face;
                }

                return null;
            }
        }

        public string TopSuit 
        {
            get
            {
                if (this.Count > 0)
                {
                    return this.TopCard.Suit.ToString();
                }

                return null;
            }
        }

        public PlayingCard TopCard 
        {
            get
            {
                if (this.Count > 0)
                {
                    return ((PlayingCard)this.Peek());
                }

                return null;
            }
        }
    }
}
