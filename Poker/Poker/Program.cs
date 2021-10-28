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
                if (deck.GetNumberOfLeftCards()<10)
                {
                    deck.NewDeck();
                    deck.ShuffleDeck();
                }
                count++;
                for (int i = 0; i < 5; i++)
                {
                    player1.addCard(deck.NextCard());
                    table.addCard(deck.NextCard());

                }
            } while (EvaluateTwoListOfCards(player1.GetPlayersCards(), table.GetPlayersCards()) == 0);

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
            int indexClubs = FindIndexOfHighValueCardBySuite(sortedCards, Suite.Clubs);
            int indexDiamonds = FindIndexOfHighValueCardBySuite(sortedCards, Suite.Diamonds);
            int indexHearts = FindIndexOfHighValueCardBySuite(sortedCards, Suite.Hearts);
            int indexSpides = FindIndexOfHighValueCardBySuite(sortedCards, Suite.Spides);

            bool Clubs5Found = false, Diamonds5Found = false, Hearts5Found = false, Spides5Found = false;
            if ((sortedCards.Count - indexClubs) >= 5 && indexClubs>=0)
            {
                if (sortedCards[indexClubs].GetCardSuite() == sortedCards[indexClubs + 1].GetCardSuite() &&
                    sortedCards[indexClubs].GetCardSuite() == sortedCards[indexClubs + 2].GetCardSuite() &&
                    sortedCards[indexClubs].GetCardSuite() == sortedCards[indexClubs + 3].GetCardSuite() &&
                    sortedCards[indexClubs].GetCardSuite() == sortedCards[indexClubs + 4].GetCardSuite() &&
                    sortedCards[indexClubs].GetCardValueInt() == sortedCards[indexClubs + 1].GetCardValueInt() + 1 &&
                    sortedCards[indexClubs].GetCardValueInt() == sortedCards[indexClubs + 2].GetCardValueInt() + 2 &&
                    sortedCards[indexClubs].GetCardValueInt() == sortedCards[indexClubs + 3].GetCardValueInt() + 3 &&
                    sortedCards[indexClubs].GetCardValueInt() == sortedCards[indexClubs + 4].GetCardValueInt() + 4
                    )
                {
                    Clubs5Found = true;
                }
            }
            if ((sortedCards.Count - indexDiamonds) >= 5 && indexDiamonds >= 0)
            {
                if (sortedCards[indexDiamonds].GetCardSuite() == sortedCards[indexDiamonds + 1].GetCardSuite() &&
                    sortedCards[indexDiamonds].GetCardSuite() == sortedCards[indexDiamonds + 2].GetCardSuite() &&
                    sortedCards[indexDiamonds].GetCardSuite() == sortedCards[indexDiamonds + 3].GetCardSuite() &&
                    sortedCards[indexDiamonds].GetCardSuite() == sortedCards[indexDiamonds + 4].GetCardSuite() &&
                    sortedCards[indexDiamonds].GetCardValueInt() == sortedCards[indexDiamonds + 1].GetCardValueInt() + 1 &&
                    sortedCards[indexDiamonds].GetCardValueInt() == sortedCards[indexDiamonds + 2].GetCardValueInt() + 2 &&
                    sortedCards[indexDiamonds].GetCardValueInt() == sortedCards[indexDiamonds + 3].GetCardValueInt() + 3 &&
                    sortedCards[indexDiamonds].GetCardValueInt() == sortedCards[indexDiamonds + 4].GetCardValueInt() + 4
                    )
                {
                    Diamonds5Found = true;
                }
            }
            if ((sortedCards.Count - indexHearts) >= 5 && indexHearts >= 0)
            {
                if (sortedCards[indexHearts].GetCardSuite() == sortedCards[indexHearts + 1].GetCardSuite() &&
                    sortedCards[indexHearts].GetCardSuite() == sortedCards[indexHearts + 2].GetCardSuite() &&
                    sortedCards[indexHearts].GetCardSuite() == sortedCards[indexHearts + 3].GetCardSuite() &&
                    sortedCards[indexHearts].GetCardSuite() == sortedCards[indexHearts + 4].GetCardSuite() &&
                    sortedCards[indexHearts].GetCardValueInt() == sortedCards[indexHearts + 1].GetCardValueInt() + 1 &&
                    sortedCards[indexHearts].GetCardValueInt() == sortedCards[indexHearts + 2].GetCardValueInt() + 2 &&
                    sortedCards[indexHearts].GetCardValueInt() == sortedCards[indexHearts + 3].GetCardValueInt() + 3 &&
                    sortedCards[indexHearts].GetCardValueInt() == sortedCards[indexHearts + 4].GetCardValueInt() + 4
                    )
                {
                    Hearts5Found = true;
                }
            }
            if ((sortedCards.Count - indexSpides) >= 5 && indexSpides >= 0)
            {
                if (sortedCards[indexSpides].GetCardSuite() == sortedCards[indexSpides + 1].GetCardSuite() &&
                    sortedCards[indexSpides].GetCardSuite() == sortedCards[indexSpides + 2].GetCardSuite() &&
                    sortedCards[indexSpides].GetCardSuite() == sortedCards[indexSpides + 3].GetCardSuite() &&
                    sortedCards[indexSpides].GetCardSuite() == sortedCards[indexSpides + 4].GetCardSuite() &&
                    sortedCards[indexSpides].GetCardValueInt() == sortedCards[indexSpides + 1].GetCardValueInt() + 1 &&
                    sortedCards[indexSpides].GetCardValueInt() == sortedCards[indexSpides + 2].GetCardValueInt() + 2 &&
                    sortedCards[indexSpides].GetCardValueInt() == sortedCards[indexSpides + 3].GetCardValueInt() + 3 &&
                    sortedCards[indexSpides].GetCardValueInt() == sortedCards[indexSpides + 4].GetCardValueInt() + 4
                    )
                {
                    Spides5Found = true;
                }
            }

            if (Clubs5Found == true || Diamonds5Found == true || Hearts5Found == true || Spides5Found == true)
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
    }
}
