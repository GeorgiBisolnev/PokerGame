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

            var player1 = new Player("Georgi");
            var player2 = new Player("Ivan");

            for (int i = 0; i < 5; i++)
            {
                player1.addCard(deck.NextCard());
                player2.addCard(deck.NextCard());
            }

            player1.printHand();
            player2.printHand();
        }
    }
}
