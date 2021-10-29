using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Poker
{
    public class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            deck.NewDeck();

            deck.ShuffleDeck();

            //var test1 = new Player("test1");
            //var testTable = new Player("TestTable");

            //for (int i = 0; i < 5; i++)
            //{
            //    test1.addCard(deck.NextCard());
            //    testTable.addCard(deck.NextCard());

            //}
            //Console.WriteLine(EvaluateTwoListOfCards(test1.GetPlayersCards(), testTable.GetPlayersCards()));
            //Console.WriteLine(test1.printHand());
            //Console.WriteLine(testTable.printHand());


            var player1 = new Player("Georgi");
            var player2 = new Player("Ivan");
            var table = new Player("Table");
            int count = 0;
            do
            {
                player1.ClearHand();
                table.ClearHand();
                if (deck.GetNumberOfLeftCards()<7)
                {
                    deck.NewDeck();
                    deck.ShuffleDeck();
                }
                for (int i = 0; i < 2; i++)
                {
                    player1.addCard(deck.NextCard());
                    //table.addCard(deck.NextCard());

                }
                for (int i = 0; i < 5; i++)
                {
                    table.addCard(deck.NextCard());
                    //table.addCard(deck.NextCard());

                }
                if (EvaluateTwoListOfCards(player1.GetPlayersCards(), table.GetPlayersCards()) == 1)
                {
                    Console.WriteLine("------------------------");
                    player1.printColoredHand();
                    table.printColoredHand();
                    Console.WriteLine("------------------------");
                    Console.WriteLine();
                }
            } while (true);

            player1.SortPlayerHand(); table.SortPlayerHand();
            Console.WriteLine(count);
            Console.WriteLine(player1.printHand() +"\n" + table.printHand());
            
           
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
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine(table.printHand(false)); 
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine(player2.printHand());
                }
                else if (player1.GetNumberOfCards() == 3)
                {
                    player1.addCard(deck.NextCard()); 
                    player2.addCard(deck.NextCard()); 
                    table.addCard(deck.NextCard());

                    Console.WriteLine(player1.printHand());
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine(table.printHand(false));
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine(player2.printHand());
                } else
                {
                    player1.addCard(deck.NextCard());
                    player2.addCard(deck.NextCard());
                    table.addCard(deck.NextCard());

                    Console.WriteLine(player1.printHand());
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine(table.printHand(false));
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine(player2.printHand());
                }
                Console.WriteLine("Pres any key to continue ...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static int EvaluateTwoListOfCards(List<Card> cards1, List<Card> cards2)
        {
            int evaluation = 0;
            List<Card> cards = cards1.Concat(cards2).ToList();
            //Royal Flush
            var sortedCards = cards.OrderBy(x => (int)x.GetCardSuite()).ThenByDescending(x => (int)x.GetCardValueInt()).ToList();

            if (StraightFlush(cards))
            {
                return 1;
            }

            return evaluation;
        }

        private static int FindIndexOfHighValueCardBySuite(List<Card> cards, Suite s)
        {
            //var sortedCards = cards.OrderBy(x => (int)x.GetCardSuite()).ThenByDescending(x => (int)x.GetCardValueInt()).ToList();
            int max = 0;
            int maxIndex = -1;
            if (cards.Count > 0)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    if (s == cards[i].GetCardSuite() && cards[i].GetCardValueInt() > max)
                    {
                        max = (int)cards[i].GetCardValueInt();
                        maxIndex = i;
                    }
                }
            }
            return maxIndex;
        }

        private static bool StraightFlush(List<Card> list)
        {
            var sortedCards = list.OrderBy(x => (int)x.GetCardSuite()).ThenByDescending(x => (int)x.GetCardValueInt()).ToList();

            if (sortedCards[0].GetCardSuite() == sortedCards[1].GetCardSuite() &&
                    sortedCards[0].GetCardSuite() == sortedCards[2].GetCardSuite() &&
                    sortedCards[0].GetCardSuite() == sortedCards[3].GetCardSuite() &&
                    sortedCards[0].GetCardSuite() == sortedCards[4].GetCardSuite() &&
                    sortedCards[0].GetCardValueInt() == sortedCards[1].GetCardValueInt() + 1 &&
                    sortedCards[0].GetCardValueInt() == sortedCards[2].GetCardValueInt() + 2 &&
                    sortedCards[0].GetCardValueInt() == sortedCards[3].GetCardValueInt() + 3 &&
                    sortedCards[0].GetCardValueInt() == sortedCards[4].GetCardValueInt() + 4
                    )
            {
                return true;
            }
            if (sortedCards[1].GetCardSuite() == sortedCards[2].GetCardSuite() &&
                    sortedCards[1].GetCardSuite() == sortedCards[3].GetCardSuite() &&
                    sortedCards[1].GetCardSuite() == sortedCards[4].GetCardSuite() &&
                    sortedCards[1].GetCardSuite() == sortedCards[5].GetCardSuite() &&
                    sortedCards[1].GetCardValueInt() == sortedCards[2].GetCardValueInt() + 1 &&
                    sortedCards[1].GetCardValueInt() == sortedCards[3].GetCardValueInt() + 2 &&
                    sortedCards[1].GetCardValueInt() == sortedCards[4].GetCardValueInt() + 3 &&
                    sortedCards[1].GetCardValueInt() == sortedCards[5].GetCardValueInt() + 4
                    )
            {
                return true;
            }
            if (sortedCards[2].GetCardSuite() == sortedCards[3].GetCardSuite() &&
                    sortedCards[2].GetCardSuite() == sortedCards[4].GetCardSuite() &&
                    sortedCards[2].GetCardSuite() == sortedCards[5].GetCardSuite() &&
                    sortedCards[2].GetCardSuite() == sortedCards[6].GetCardSuite() &&
                    sortedCards[2].GetCardValueInt() == sortedCards[3].GetCardValueInt() + 1 &&
                    sortedCards[2].GetCardValueInt() == sortedCards[4].GetCardValueInt() + 2 &&
                    sortedCards[2].GetCardValueInt() == sortedCards[5].GetCardValueInt() + 3 &&
                    sortedCards[2].GetCardValueInt() == sortedCards[6].GetCardValueInt() + 4
                    )
            {
                return true;
            }

            return false;
        }
    }
}
