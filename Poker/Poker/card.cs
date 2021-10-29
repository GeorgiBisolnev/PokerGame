using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public enum Suite
    {
        Hearts,        
        Clubs,
        Diamonds,
        Spides
    }
    public enum Value
    {
        two=2, three, four, five, six, seven, eight, nine, ten, Jack, Queen, King, Ace
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
        public int GetCardValueInt()
        {
            return (int)CardValue;
        }

        public void SetCardValue(Value v)
        {
            CardValue = v;
        }

        public override string ToString()
        {
            string value = "n/a";
            switch (CardValue)
            {
                case Value.two:
                    value = "2";
                    break;
                case Value.three:
                    value = "3";
                    break;
                case Value.four:
                    value = "4";
                    break;
                case Value.five:
                    value = "5";
                    break;
                case Value.six:
                    value = "6";
                    break;
                case Value.seven:
                    value = "7";
                    break;
                case Value.eight:
                    value = "8";
                    break;
                case Value.nine:
                    value = "9";
                    break;
                case Value.ten:
                    value = "T";
                    break;
                case Value.Jack:
                    value = "J";
                    break;
                case Value.Queen:
                    value = "Q";
                    break;
                case Value.King:
                    value = "K";
                    break;
                case Value.Ace:
                    value = "A";
                    break;
                default:
                    break; 
            }
            string strSuite = "n/a";
            switch (CardSuite)
            {
                case Suite.Hearts:
                    strSuite = "\u2665";
                    break;
                case Suite.Diamonds:
                    strSuite = "\u2666";
                    break;
                case Suite.Clubs:
                    strSuite = "\u2663";
                    break;
                case Suite.Spides:
                    strSuite = "\u2660";
                    break;
                default:
                    break;
            }
            return $"({value}{strSuite})"; 

        }        
    }
}
