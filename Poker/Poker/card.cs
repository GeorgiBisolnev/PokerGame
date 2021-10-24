using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public enum Suite
    {
        Hearts,
        Tiles,
        Clovers,
        Pikes
    }
    public enum Value
    {
        two2=2, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace
    }
    public class Card
    {
        private Suite CardSuite { get; set; }
        private Value CardValue { get; set; }

        public Suite GetCardSuite()
        {
            return CardSuite;
        }

        public void SetCardSuite(Suite c)
        {
            CardSuite = c;
        }
        public Suite GetCardValue()
        {
            return CardSuite;
        }

        public void SetCardValue(Value v)
        {
            CardValue = v;
        }

        public override string ToString()
        {
            return $"{CardValue.} of {CardSuite}";
        }        
    }
}
