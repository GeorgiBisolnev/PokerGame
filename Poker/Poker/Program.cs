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
            //Card card1 = new Card(); Card card2 = new Card(); Card card3 = new Card(); Card card4 = new Card(); Card card5 = new Card(); Card card6 = new Card();
            //Card card7 = new Card();
            //card1.SetCardValue(Value.King);
            //card1.SetCardSuite(Suite.Hearts);

            //card2.SetCardValue(Value.ten);
            //card2.SetCardSuite(Suite.Hearts);

            //card3.SetCardValue(Value.ten);
            //card3.SetCardSuite(Suite.Clubs);

            //card4.SetCardValue(Value.ten);
            //card4.SetCardSuite(Suite.Diamonds);

            //card5.SetCardValue(Value.three);
            //card5.SetCardSuite(Suite.Hearts);

            //card6.SetCardValue(Value.two);
            //card6.SetCardSuite(Suite.Hearts);

            //card7.SetCardValue(Value.two);
            //card7.SetCardSuite(Suite.Diamonds);
            //List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            //int test = FullHouse(testList);

            //Console.BackgroundColor = ConsoleColor.DarkMagenta;
            //Deck deck = new Deck();

            //deck.NewDeck();

            //deck.ShuffleDeck();

            //var player1 = new Player("Georgi");
            //var player2 = new Player("Ivan");
            //var table = new Player("Table");
            //do
            //{
            //    player1.ClearHand();
            //    table.ClearHand();
            //    if (deck.GetNumberOfLeftCards()<7)
            //    {
            //        deck.NewDeck();
            //        deck.ShuffleDeck();
            //    }
            //    for (int i = 0; i < 2; i++)
            //    {
            //        player1.addCard(deck.NextCard());

            //    }
            //    for (int i = 0; i < 5; i++)
            //    {
            //        table.addCard(deck.NextCard());

            //    }
            //    List<Card> concat = player1.GetPlayersCards().Concat(table.GetPlayersCards()).ToList();



            //    Console.WriteLine(Evaluate(concat));
            //        Console.ForegroundColor = ConsoleColor.Gray;
            //        Console.WriteLine("------------------------");
            //        player1.printColoredHand();
            //        table.printColoredHand();
            //        Console.WriteLine("------------------------");
            //        Console.WriteLine();

            //} while (true);

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

            Console.Write("Number of players= ");
            int numberOfPlaeyrs = int.Parse(Console.ReadLine());

            Dictionary<Player,string []> players = new Dictionary<Player, string[]>();

            for (int i = 0; i < numberOfPlaeyrs; i++)
            {
                Console.Write($"Player {i} name is - > ");
                Player curPlayer = new Player(Console.ReadLine());
                players.Add(curPlayer,new string[2]);
            }
            Deck deck = new Deck(); deck.NewDeck(); deck.ShuffleDeck();
            Player table = new Player("Table");
            do
            {
                players = players.OrderByDescending(x => x.Key.Name).ToDictionary(x => x.Key, x => x.Value);
                if (deck.GetNumberOfLeftCards()<players.Count*2+5)
                {
                    deck.NewDeck(); deck.ShuffleDeck();
                }
                if (table.GetNumberOfCards()==5)
                {
                    table.ClearHand();
                    foreach (var player in players)
                    {
                        player.Key.ClearHand();
                    }
                }


                if (table.GetNumberOfCards() == 0)
                {
                    foreach (var player in players)
                    {
                        Card curCard = new Card();
                        curCard = deck.NextCard();
                        player.Key.addCard(curCard);
                    }
                    foreach (var player in players)
                    {
                        Card curCard = new Card();
                        curCard = deck.NextCard();
                        player.Key.addCard(curCard);
                    }
                }
                

                if (table.GetPlayersCards().Count==0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Card curCard = new Card();
                        curCard = deck.NextCard();
                        table.addCard(curCard);
                    }
                    deck.NextCard();
                }
                else if (table.GetPlayersCards().Count == 0)
                {
                    Card curCard = new Card();
                    curCard = deck.NextCard();
                    table.addCard(curCard);
                    deck.NextCard();
                } else
                {
                    Card curCard = new Card();
                    curCard = deck.NextCard();
                    table.addCard(curCard);
                }
                Console.Clear();
                double max = 0;
                string winner = "";
                Console.WriteLine("--------------------------------------------------------------");                
                string playerStr= "Player name", handStr="Players hand", evaluationStr="Evaluation";
                Console.WriteLine($"{playerStr,15} |{ handStr,15 }   |   {evaluationStr,14}   ");
                Console.WriteLine("                |                  |                    ");
                Console.WriteLine("--------------------------------------------------------------");
                if (table.GetNumberOfCards() == 5)
                {
                    foreach (var player in players)
                    {
                        List<Card> conc = player.Key.GetPlayersCards().Concat(table.GetPlayersCards()).ToList();
                        string result = Evaluate(conc)[0];
                        double evaluationScore = double.Parse(Evaluate(conc)[1]);
                        player.Value[0] = result;
                        player.Value[1] = evaluationScore.ToString();
                    }

                    players = players.OrderByDescending(x => double.Parse(x.Value[1])).ToDictionary(x=>x.Key, x=>x.Value);
                }
                foreach (var player in players)
                {
                    
                    if (table.GetNumberOfCards() == 5)
                    {
                        
                        //List<Card> conc = player.Key.GetPlayersCards().Concat(table.GetPlayersCards()).ToList();
                        //string result = Evaluate(conc)[0];
                        //double evaluationScore = double.Parse(Evaluate(conc)[1]);
                        Console.WriteLine($"{player.Key.Name,15} | {player.Key.printHand(),15}  |{player.Value[0],15}  |{player.Value[1],7}");
                    }
                    else 
                    {
                        Console.WriteLine($"{player.Key.Name,15} | {player.Key.printHand(),15}");
                    }
                }
                if (max>0)
                {
                    
                    Console.WriteLine($"Winner is {winner}");
                }
                Console.WriteLine();
                Console.WriteLine("--- Table cards ---");
                Console.WriteLine(table.printHand());
            Console.ReadKey();
            Console.Clear();
            } while (true);
        }
        public static string[] Evaluate(List<Card> list)
        {
            int evaluationScore = 0;
            string returnString = "";
            if ( StraightFlush(list)>80000)
            {
                evaluationScore = StraightFlush(list);
            }
            else if (FourOfAKind(list)>70000)
            {
                evaluationScore= FourOfAKind(list);
            }
            else if (FullHouse(list)>60000)
            {
                evaluationScore= FullHouse(list);
            }
            else if (Flush(list)>50000)
            {
                evaluationScore= Flush(list);
            }
            else if (Straight(list)>40000)
            {
                evaluationScore= Straight(list);
            }
            else if (ThreeOfAKind(list)>30000)
            {
                evaluationScore= ThreeOfAKind(list);
            }
            else if (TwoPair(list)>20000)
            {
                evaluationScore= TwoPair(list);
            }
            else if (OnePair(list)>10000)
            {
                evaluationScore= OnePair(list);
            } else
            {
                evaluationScore= HighCard(list);
            }
            returnString= ($"Evaluation Score: {evaluationScore}");
                if (evaluationScore > 80000)
                {
                    if (evaluationScore == 80014)
                    {
                        returnString=("--Royal Fluash!--");
                    }
                    else
                    {
                        returnString=("Straight Flush");
                    }
                }
                else if (evaluationScore > 70000)
                {
                    returnString=("Four-of-a-kind");
                }
                else if (evaluationScore > 60000)
                {                    
                    returnString=("Full House");
                }
                else if (evaluationScore > 50000)
                {
                    returnString=("Flush");
                }
                else if (evaluationScore > 40000)
                {
                    returnString=("Staight");
                }
                else if (evaluationScore > 30000)
                {
                    returnString=("Three Of A Kind");
                }
                else if (evaluationScore > 20000)
                {
                    returnString=("Two pairs");
                }
                else if (evaluationScore > 10000)
                {
                    returnString=("One pair");
                }
                else
                {
                    returnString=("High card");
                }

            double d = evaluationScore / 10000.0;
            return  new string[] { returnString, d.ToString() };
        }
        private static int StraightFlush(List<Card> list)
        {
            int score = 80000;
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
                    score += 70000 + sortedCards[i].GetCardValueInt();
                    return score;
                }
            }
            return score;
        }

        public static int FullHouse(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();
            for (int i = 0; i < list.Count-3; i++)
            {
                if (sortedCards[i].GetCardValueInt()== sortedCards[i+1].GetCardValueInt()&& sortedCards[i].GetCardValueInt()== sortedCards[i+2].GetCardValueInt())
                {
                    int intThree = sortedCards[i].GetCardValueInt();
                    var sortedlist2 = sortedCards.Where(v => v.GetCardValueInt() != intThree).ToList();

                    for (int j = 0; j < sortedlist2.Count-2; j++)
                    {
                        if (sortedlist2[j].GetCardValueInt()== sortedlist2[j+1].GetCardValueInt())
                        {
                            score = 60000 +intThree * 10 * 3 + sortedlist2[j].GetCardValueInt() * 2;
                            return score;
                        }
                    }
                }
            }

            return score;
        }

        public static int Flush(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardSuite()).ThenByDescending(v=>v.GetCardValueInt()).ToList();

            for (int i = 0; i < 3; i++)
            {
                if (sortedCards[i].GetCardSuite() == sortedCards[i+1].GetCardSuite() && sortedCards[i].GetCardSuite() == sortedCards[i+2].GetCardSuite() &&
                sortedCards[i].GetCardSuite() == sortedCards[i+3].GetCardSuite() && sortedCards[i].GetCardSuite() == sortedCards[i+4].GetCardSuite())
                {
                    score = 50000 + sortedCards[i].GetCardValueInt();
                    return score;
                }
            }
            

            return score;
        }

        public static int Straight(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();

            for (int i = 0; i < 3; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt()+1 && sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt()+2 &&
                sortedCards[i].GetCardValueInt() == sortedCards[i + 3].GetCardValueInt()+3 && sortedCards[i].GetCardValueInt() == sortedCards[i + 4].GetCardValueInt()+4)
                {
                    score = 40000 + sortedCards[i].GetCardValueInt();
                    return score;
                }
            }


            return score;
        }

        public static int ThreeOfAKind(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();

            for (int i = 0; i < 5; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt() && sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt())
                {
                    int intThreeOfAKind = sortedCards[i].GetCardValueInt();
                    score = 30000 + sortedCards[i].GetCardValueInt()*3*30;
                    sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).Where(v => v.GetCardValueInt() != intThreeOfAKind).ToList();
                    score += sortedCards[0].GetCardValueInt() * 10 + sortedCards[1].GetCardValueInt();
                    return score;
                }
            }


            return score;
        }

        public static int TwoPair(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();

            for (int i = 0; i < sortedCards.Count-1; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt())
                {
                    int intTwoOfAKind = sortedCards[i].GetCardValueInt();
                    
                    var sortedCards2 = list.OrderByDescending(x => x.GetCardValueInt()).Where(v => v.GetCardValueInt() != intTwoOfAKind).ToList();
                    for (int j = 0; j < sortedCards2.Count-1; j++)
                    {
                        if (sortedCards2[j].GetCardValueInt() == sortedCards2[j + 1].GetCardValueInt())
                        {
                            int intTwoOfAKind2 = sortedCards2[j].GetCardValueInt();
                            int intHighCard = sortedCards2.First(v => v.GetCardValueInt() != intTwoOfAKind2).GetCardValueInt();
                            score = 20000 + intTwoOfAKind * 2 * 30 + intTwoOfAKind2*2*10 + intHighCard;
                            return score;
                        }
                    }                   
                }
            }


            return score;
        }

        public static int OnePair(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();

            for (int i = 0; i < sortedCards.Count - 1; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt())
                {
                    int intTwoOfAKind = sortedCards[i].GetCardValueInt();

                    var sortedCards2 = list.OrderByDescending(x => x.GetCardValueInt()).Where(v => v.GetCardValueInt() != intTwoOfAKind).ToList();

                    int intHightCard1 = sortedCards2[0].GetCardValueInt();
                    int intHightCard2 = sortedCards2[1].GetCardValueInt();
                    int intHightCard3 = sortedCards2[2].GetCardValueInt();

                    score = 10000 + 2 * intTwoOfAKind * 8 + intHightCard1 + intHightCard2+ intHightCard3;

                    return score;
                }
            }


            return score;
        }
        public static int HighCard(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();

            score = sortedCards[0].GetCardValueInt() + sortedCards[1].GetCardValueInt() + sortedCards[2].GetCardValueInt() +
                sortedCards[3].GetCardValueInt() + sortedCards[4].GetCardValueInt();

            return score;
        }
    }
}
