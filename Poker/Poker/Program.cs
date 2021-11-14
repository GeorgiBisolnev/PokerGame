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
            Evaluation Evaluation = new Evaluation();

            //Card card1 = new Card(); Card card2 = new Card(); Card card3 = new Card(); Card card4 = new Card(); Card card5 = new Card(); Card card6 = new Card();
            //Card card7 = new Card();
            //card1.SetCardValue(Value.Ace);
            //card1.SetCardSuite(Suite.Clubs);

            //card2.SetCardValue(Value.King);
            //card2.SetCardSuite(Suite.Clubs);

            //card3.SetCardValue(Value.Queen);
            //card3.SetCardSuite(Suite.Clubs);

            //card4.SetCardValue(Value.Jack);
            //card4.SetCardSuite(Suite.Clubs);

            //card5.SetCardValue(Value.ten);
            //card5.SetCardSuite(Suite.Clubs);

            //card6.SetCardValue(Value.seven);
            //card6.SetCardSuite(Suite.Spides);

            //card7.SetCardValue(Value.five);
            //card7.SetCardSuite(Suite.Clubs);
            //List<Card> testList = new List<Card> { card1, card2, card3, card4, card5,card6, card7 };

            ////double test = Straight(testList);
            //Evaluation.Evaluate(testList);
            //double test1 = Evaluation.HandEvaluation;
            //string pokerhand = Evaluation.PokerHand;

            
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
                //if (deck.GetNumberOfLeftCards()<players.Count*2+5)
                //{
                    deck.NewDeck(); deck.ShuffleDeck();
                //}
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
                        Evaluation.Evaluate(conc);
                        string result = Evaluation.PokerHand;
                        double evaluationScore = Evaluation.HandEvaluation;
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
                        string result = Evaluation.PokerHand;
                        double evaluationScore = Evaluation.HandEvaluation;
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
    }
}
