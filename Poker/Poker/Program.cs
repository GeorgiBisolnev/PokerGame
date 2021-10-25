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
            var table = new Player("Table");

            //for (int i = 0; i < 5; i++)
            //{
            //    player1.addCard(deck.NextCard());
            //    player2.addCard(deck.NextCard());
            //}
            Console.WriteLine(player1.GetNumberOfCards());
            while (player1.GetNumberOfCards() < 5)
            {
                Console.WriteLine("-------------------");
                if (player1.GetNumberOfCards()==0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        player1.addCard(deck.NextCard());                        
                        player2.addCard(deck.NextCard());
                        table.addCard(deck.NextCard());
                    }

                    Console.WriteLine(player1.printHand());
                    Console.WriteLine(table.printHand());
                    Console.WriteLine(player2.printHand());
                }
                else if (player1.GetNumberOfCards() == 3)
                {
                    player1.addCard(deck.NextCard()); 
                    player2.addCard(deck.NextCard()); 
                    table.addCard(deck.NextCard());

                    Console.WriteLine(player1.printHand());
                    Console.WriteLine(table.printHand());
                    Console.WriteLine(player2.printHand());
                } else
                {
                    player1.addCard(deck.NextCard());
                    player2.addCard(deck.NextCard());
                    table.addCard(deck.NextCard());

                    Console.WriteLine(player1.printHand());
                    Console.WriteLine(table.printHand());
                    Console.WriteLine(player2.printHand());
                }
            }
        }
    }
}
