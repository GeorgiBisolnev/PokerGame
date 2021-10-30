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
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Deck deck = new Deck();

            deck.NewDeck();

            deck.ShuffleDeck();
 
            var player1 = new Player("Georgi");
            var player2 = new Player("Ivan");
            var table = new Player("Table");
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

                }
                for (int i = 0; i < 5; i++)
                {
                    table.addCard(deck.NextCard());

                }
                List<Card> concat = player1.GetPlayersCards().Concat(table.GetPlayersCards()).ToList();
                int score = Evaluate(concat);
                
                if (score>0)
                {
                    Console.WriteLine($"Evaluation Score: {score}");
                    if (score>8000 )
                    {
                        if (score==8014)
                        {
                            Console.WriteLine("Royal Fluash!");
                        }
                        else
                        {
                            Console.WriteLine("Straight Flush");
                        }
                    }
                    else if (score>7000)
                    {
                        Console.WriteLine("Four-of-a-kind");
                    }
                    else if (score > 6000)
                    {
                        Console.WriteLine("Full House");

                    }
                    else if (score>5000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Flush");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.WriteLine("Something else!");
                    }
                    Console.WriteLine("------------------------");
                    player1.printColoredHand();
                    table.printColoredHand();
                    Console.WriteLine("------------------------");
                    Console.WriteLine();
                }
            } while (true);

            //player1.SortPlayerHand(); table.SortPlayerHand();
            //Console.WriteLine(count);
            //Console.WriteLine(player1.printHand() +"\n" + table.printHand());
            
           
            //while (player1.GetNumberOfCards() < 5)
            //{
            //    Console.WriteLine("-------------------");
            //    if (player1.GetNumberOfCards()==0)
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            player1.addCard(deck.NextCard());                        
            //            player2.addCard(deck.NextCard());
            //            table.addCard(deck.NextCard());
            //        }

            //        Console.WriteLine(player1.printHand());
            //        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
            //        Console.WriteLine(table.printHand(false)); 
            //        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
            //        Console.WriteLine(player2.printHand());
            //    }
            //    else if (player1.GetNumberOfCards() == 3)
            //    {
            //        player1.addCard(deck.NextCard()); 
            //        player2.addCard(deck.NextCard()); 
            //        table.addCard(deck.NextCard());

            //        Console.WriteLine(player1.printHand());
            //        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
            //        Console.WriteLine(table.printHand(false));
            //        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
            //        Console.WriteLine(player2.printHand());
            //    } else
            //    {
            //        player1.addCard(deck.NextCard());
            //        player2.addCard(deck.NextCard());
            //        table.addCard(deck.NextCard());

            //        Console.WriteLine(player1.printHand());
            //        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
            //        Console.WriteLine(table.printHand(false));
            //        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
            //        Console.WriteLine(player2.printHand());
            //    }
            //    Console.WriteLine("Pres any key to continue ...");
            //    Console.ReadKey();
            //    Console.Clear();
            //}
        }

        public static int Evaluate(List<Card> list)
        {
            int score = 0;

            if ( StraightFlush(list)>8000)
            {
                return StraightFlush(list);
            }
            else if (FourOfAKind(list)>7000)
            {
                return FourOfAKind(list);
            }
            else if (FullHouse(list)>6000)
            {
                return FullHouse(list);
            }
            else if (Flush(list)>5000)
            {
                return Flush(list);
            }   

            return score;
        }
        private static int StraightFlush(List<Card> list)
        {
            int score = 8000;
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
                return score + sortedCards[0].GetCardValueInt();
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
                return score + sortedCards[1].GetCardValueInt();
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
                return score + sortedCards[2].GetCardValueInt();
            }

            return score;
        }

        public static int FourOfAKind(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x =>x.GetCardValueInt()).ToList();
            for (int i = 0; i < 4; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i+1].GetCardValueInt()&&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt() &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 3].GetCardValueInt())
                {
                    score = sortedCards.First(x => x.GetCardValueInt() != sortedCards[i].GetCardValueInt()).GetCardValueInt();
                    score += 7000 + sortedCards[i].GetCardValueInt();
                    return score;
                }
            }
            return score;
        }

        public static int FullHouse(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();

            sortedCards.RemoveAt(sortedCards.Count - 1);
            sortedCards.RemoveAt(sortedCards.Count - 1);

            if (sortedCards[0].GetCardValueInt()== sortedCards[1].GetCardValueInt() && sortedCards[0].GetCardValueInt()== sortedCards[2].GetCardValueInt() &&
                sortedCards[3].GetCardValueInt()== sortedCards[4].GetCardValueInt()||
                sortedCards[0].GetCardValueInt()== sortedCards[1].GetCardValueInt()&&
                sortedCards[2].GetCardValueInt()== sortedCards[3].GetCardValueInt() && sortedCards[2].GetCardValueInt()== sortedCards[4].GetCardValueInt())
            {
                foreach (var card in sortedCards)
                {
                    score += card.GetCardValueInt();
                }
                return score+6000;
            }

            return score;
        }

        public static int Flush(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardSuite()).ThenByDescending(v=>v.GetCardValueInt()).ToList();

            if (sortedCards[0].GetCardSuite()== sortedCards[1].GetCardSuite()&& sortedCards[0].GetCardSuite()== sortedCards[2].GetCardSuite()&&
                sortedCards[0].GetCardSuite()== sortedCards[3].GetCardSuite()&& sortedCards[0].GetCardSuite()== sortedCards[4].GetCardSuite()) 
            {
                score = 5000 + sortedCards[0].GetCardValueInt();
                return score;
            }

            for (int i = 0; i < 3; i++)
            {
                if (sortedCards[i].GetCardSuite() == sortedCards[i+1].GetCardSuite() && sortedCards[i].GetCardSuite() == sortedCards[i+2].GetCardSuite() &&
                sortedCards[i].GetCardSuite() == sortedCards[i+3].GetCardSuite() && sortedCards[i].GetCardSuite() == sortedCards[i+4].GetCardSuite())
                {
                    score = 5000 + sortedCards[i].GetCardValueInt();
                    return score;
                }
            }
            

            return score;
        }

    }
}
