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

        public void printHand()
        {
            Console.WriteLine($"Player {Name}:");
            Console.WriteLine(string.Join(" ",Hand));
        }
    }
}
