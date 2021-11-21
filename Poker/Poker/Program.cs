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
            Evaluation Evaluation = new Poker.Evaluation();

            Console.Write("Number of players= ");
            int numberOfPlaeyrs = int.Parse(Console.ReadLine());

            Dictionary<Player,string []> players = new Dictionary<Player, string[]>();

            for (int i = 1; i <= numberOfPlaeyrs; i++)
            {
                Console.Write($"Player {i} name is - > ");
                Player curPlayer = new Player(Console.ReadLine());
                players.Add(curPlayer,new string[2]);
            }
            Deck deck = new Deck(); deck.NewDeck();
            deck.ShuffleDeck();
            Player table = new Player("Table");

            do
            {
                players = players.OrderBy(x => x.Key.Name).ToDictionary(x => x.Key, x => x.Value);

                if (table.GetNumberOfCards()==5)
                {
                    deck.NewDeck(); 
                    deck.ShuffleDeck();
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
                    for (int i = 0; i < 3; i++)
                    {
                        Card curCard = new Card();
                        curCard = deck.NextCard();
                        table.addCard(curCard);
                    }
                    deck.NextCard();                
                } 
                else
                {
                    Card curCard = new Card();
                    curCard = deck.NextCard();
                    table.addCard(curCard);
                }                           
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
                Console.WriteLine("---  Table cards  ---");
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
