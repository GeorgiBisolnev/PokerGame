using System;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            //deck.NewDeck();

            deck.ShuffleDeck();
            deck.PrintDeck();

        }
    }
}
