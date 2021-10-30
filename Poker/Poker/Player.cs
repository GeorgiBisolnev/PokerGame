using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            SortPlayerHand();
            var str = new StringBuilder();
            if (Name.ToLower()=="table")
            {
                str.AppendLine($"{Name}:");
            }
            else
            {
                str.AppendLine($"Player {Name}:");
            }
            

            str.AppendLine(string.Join(" ",Hand));
            return str.ToString();
        }
        public string printHand(bool sorting)
        {
            if (sorting)
            {
                SortPlayerHand();   
            }
            var str = new StringBuilder();
            if (Name.ToLower() == "table")
            {
                str.AppendLine($"{Name}:");
            }
            else
            {
                str.AppendLine($"Player {Name}:");
            }
            str.AppendLine(string.Join(" ", Hand));
            return str.ToString();
        }

        public void printColoredHand()
        {
            if (Name.ToLower()=="table")
            {
                Console.WriteLine($"{Name} cards:");
            } else
            Console.WriteLine($"Player {Name}:");
            foreach (var card in Hand)
            {
                if (card.GetCardSuite()==Suite.Diamonds || card.GetCardSuite() == Suite.Hearts)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(card.ToString() + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(card.ToString() + " ");
                }

            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public int GetNumberOfCards() => Hand.Count;

        public void SortPlayerHand()
        {
            var newList = new List<Card>();

            var sortedHand = Hand.OrderBy(x => (int)x.GetCardSuite()).ThenByDescending(x => x.GetCardValueInt()).ToList();
            Hand = sortedHand;

        }

        public List<Card> GetPlayersCards()
        {
            return Hand;
        }
        public void ClearHand()
        {
            Hand.Clear();


        }
    }
}
