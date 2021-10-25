using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Deck
    {
        private List<Card> deck = null;
        public Deck()
        {
            deck = new List<Card>();
            NewDeck();
        }
        public void NewDeck()
        {
            foreach (Suite suite in Enum.GetValues(typeof(Suite)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    Card currCard = new Card();

                    currCard.SetCardValue(value);
                    currCard.SetCardSuite(suite);

                    deck.Add(currCard); //добавяне на нова карта към тестето
                }
            }
        }

        public void ShuffleDeck()
        {
            Random rnd = new Random();
            Card curCard = new Card();

            for (int i = 0; i < 500; i++)
            {
                int randomint = rnd.Next(deck.Count);
                curCard = deck[randomint];
                deck.RemoveAt(randomint);   // Изтриване на рандом карта от тестето
                deck.Add(curCard);      //добавяне на изтритата карта в края на тестето
            }

        }

        public void PrintDeck()
        {
            foreach (var card in deck)
            {
                Console.WriteLine(card.ToString() );
            }
        }
    }
}
