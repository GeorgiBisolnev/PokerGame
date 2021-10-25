using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Player
    {
        List<Card> Hand = null;

        public string Name { get; set; }

        public Player(string name)
        {
            Hand = new List<Card>();
            Name = name;
        }

        public void addCard(Card c)
        {
            Hand.Add(c);
        }

        public string printHand()
        {
            var str = new StringBuilder();
            str.AppendLine($"Player {Name}:");
            str.AppendLine(string.Join(" ",Hand));
            return str.ToString();
        }
        public int GetNumberOfCards() => Hand.Count;
    }
}
