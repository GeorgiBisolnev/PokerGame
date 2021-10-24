﻿using System;
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

                    deck.Add(currCard);
                }
            }
        }

        public void ShufleDeck()
        {
            Random rnd = new Random();
            Card curCard = new Card();

            for (int i = 0; i < 500; i++)
            {
                int randomint = rnd.Next(deck.Count);
                curCard = deck[randomint];
                deck.RemoveAt(randomint);
                deck.Add(curCard);
            }

        }

        public void PrintDeck()
        {
            foreach (var card in deck)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
