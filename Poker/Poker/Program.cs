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
            //card1.SetCardValue(Value.four);
            //card1.SetCardSuite(Suite.Clubs);

            //card2.SetCardValue(Value.Jack);
            //card2.SetCardSuite(Suite.Diamonds);

            //card3.SetCardValue(Value.King);
            //card3.SetCardSuite(Suite.Spides);

            //card4.SetCardValue(Value.Jack);
            //card4.SetCardSuite(Suite.Clubs);

            //card5.SetCardValue(Value.four);
            //card5.SetCardSuite(Suite.Spides);

            //card6.SetCardValue(Value.six);
            //card6.SetCardSuite(Suite.Spides);

            //card7.SetCardValue(Value.four);
            //card7.SetCardSuite(Suite.Clubs);
            //List<Card> testList = new List<Card> { card1, card2, card3, card4, card5 };

            //double test = FullHouse(testList);
            //double test1 = StraightFlush(testList);

            Console.Write("Number of players= ");
            int numberOfPlaeyrs = int.Parse(Console.ReadLine());

            Dictionary<Player,string []> players = new Dictionary<Player, string[]>();

            for (int i = 1; i <= numberOfPlaeyrs; i++)
            {
                Console.Write($"Player {i} name is - > ");
                Player curPlayer = new Player(Console.ReadLine());
                players.Add(curPlayer,new string[2]);
            }
            Deck deck = new Deck(); deck.NewDeck(); deck.ShuffleDeck();
            Player table = new Player("Table");
            do
            {
                players = players.OrderBy(x => x.Key.Name).ToDictionary(x => x.Key, x => x.Value);
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
                        player.Key.addCard(deck.NextCard());
                    }
                    foreach (var player in players)
                    {
                        player.Key.addCard(deck.NextCard());
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
                Console.WriteLine("--------------------------------------------------------------");                
                string playerStr= "Player name", handStr="Players hand", evaluationStr="Evaluation";
                Console.WriteLine($"{playerStr,15} |{ handStr,15 }   |   {evaluationStr,14}   ");
                Console.WriteLine("                |                  |                    ");
                Console.WriteLine("--------------------------------------------------------------");
                double maxEvaluationResult = 0;

                    foreach (var player in players)
                    {
                        List<Card> conc = player.Key.GetPlayersCards().Concat(table.GetPlayersCards()).ToList();
                        string result = Evaluate(conc)[0];
                        double evaluationScore = double.Parse(Evaluate(conc)[1]);
                        player.Value[0] = result;
                        player.Value[1] = evaluationScore.ToString();
                        if (evaluationScore > maxEvaluationResult)
                        {
                            maxEvaluationResult = evaluationScore;
                        }
                    }

                    players = players.OrderByDescending(x => double.Parse(x.Value[1])).ToDictionary(x=>x.Key, x=>x.Value);
                
                foreach (var player in players)
                {
                        List<Card> conc = player.Key.GetPlayersCards().Concat(table.GetPlayersCards()).ToList();
                        string result = Evaluate(conc)[0];
                        double evaluationScore = double.Parse(Evaluate(conc)[1]);
                        if (double.Parse(player.Value[1])== maxEvaluationResult)
                        {
                            if (table.GetNumberOfCards() == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{player.Key.Name,15} | {player.Key.printHand(),15}  |{player.Value[0],15}  |{player.Value[1],7}  - Winner hand");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{player.Key.Name,15} | {player.Key.printHand(),15}  |{player.Value[0],15}  |{player.Value[1],7}");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{player.Key.Name,15} | {player.Key.printHand(),15}  |{player.Value[0],15}  |{player.Value[1],7}");
                        }                        
                }
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("--- Table cards ---");
                Console.WriteLine(table.printHand());
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press any kay to continue ...");
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
            var sortedCards = list.OrderBy(x => (int)x.GetCardSuite()).ThenByDescending(x =>x.GetCardValueInt()).ToList();

            for (int i = 0; i <= list.Count-5; i++)
            {
                if (sortedCards[i].GetCardSuite() == sortedCards[i+1].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i+2].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i+3].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i+4].GetCardSuite() &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i+1].GetCardValueInt() + 1 &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i+2].GetCardValueInt() + 2 &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i+3].GetCardValueInt() + 3 &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i+4].GetCardValueInt() + 4
                    )
                {
                    return score + sortedCards[i].GetCardValueInt();
                }
            }          
            return score;
        }

        public static int FourOfAKind(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x =>x.GetCardValueInt()).ToList();
            for (int i = 0; i <= sortedCards.Count-4; i++)
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
            for (int i = 0; i <= list.Count-3; i++)
            {
                if (sortedCards[i].GetCardValueInt()== sortedCards[i+1].GetCardValueInt()&& 
                    sortedCards[i].GetCardValueInt()== sortedCards[i+2].GetCardValueInt())
                {
                    int intThree = sortedCards[i].GetCardValueInt();
                    var sortedlist2 = sortedCards.Where(v => v.GetCardValueInt() != intThree).ToList();

                    for (int j = 0; j < sortedlist2.Count-1; j++)
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

            for (int i = 0; i <= sortedCards.Count-5; i++)
            {
                if (sortedCards[i].GetCardSuite() == sortedCards[i+1].GetCardSuite() && 
                    sortedCards[i].GetCardSuite() == sortedCards[i+2].GetCardSuite() &&
                sortedCards[i].GetCardSuite() == sortedCards[i+3].GetCardSuite() &&
                sortedCards[i].GetCardSuite() == sortedCards[i+4].GetCardSuite())
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

            for (int i = 0; i <= sortedCards.Count - 5; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt()+1 && 
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt()+2 &&
                sortedCards[i].GetCardValueInt() == sortedCards[i + 3].GetCardValueInt()+3 &&
                sortedCards[i].GetCardValueInt() == sortedCards[i + 4].GetCardValueInt()+4)
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

            for (int i = 0; i <= sortedCards.Count-3; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt() &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt())
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
