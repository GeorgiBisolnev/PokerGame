using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    class Evaluation
    {
        private double handEvaluation;
        private string pokerHand;
        public double HandEvaluation { get=> handEvaluation / 10000.0; set { handEvaluation = value; } }
        public string PokerHand { get=>pokerHand; set { pokerHand = value; } }
        public void Evaluate(List<Card> list)
        {
            double evaluatonScore = 0;
                string returnString = "";
                if ((evaluatonScore = StraightFlush(list)) > 80000)
                {
                HandEvaluation = evaluatonScore;
            }
                else if ((evaluatonScore = FourOfAKind(list)) > 70000)
                {
                HandEvaluation = evaluatonScore;
            }
                else if ((evaluatonScore = FullHouse(list)) > 60000)
                {
                HandEvaluation = evaluatonScore;
            }
                else if ((evaluatonScore = Flush(list)) > 50000)
                {
                HandEvaluation = evaluatonScore;
            }
                else if ((evaluatonScore = Straight(list)) > 40000)
                {
                HandEvaluation = evaluatonScore;
            }
                else if ((evaluatonScore = ThreeOfAKind(list)) > 30000)
                {
                HandEvaluation = evaluatonScore;
            }
                else if ((evaluatonScore = TwoPair(list)) > 20000)
                {
                HandEvaluation = evaluatonScore;
            }
                else if ((evaluatonScore = OnePair(list)) > 10000)
                {
                    HandEvaluation = evaluatonScore;
                }
                else
                {
                    HandEvaluation = HighCard(list);
                }

                if (HandEvaluation > 8)
                {
                    if (HandEvaluation == 8.01)
                    {
                        returnString = ("* Royal Fluash! *");
                    }
                    else
                    {
                        returnString = ("Straight Flush");
                    }
                }
                else if (HandEvaluation > 7)
                {
                    returnString = ("Four-of-a-kind");
                }
                else if (HandEvaluation > 6)
                {
                    returnString = ("Full House");
                }
                else if (HandEvaluation > 5)
                {
                    returnString = ("Flush");
                }
                else if (HandEvaluation > 4)
                {
                    returnString = ("Staight");
                }
                else if (HandEvaluation > 3)
                {
                    returnString = ("Three Of A Kind");
                }
                else if (HandEvaluation > 2)
                {
                    returnString = ("Two pairs");
                }
                else if (HandEvaluation > 1)
                {
                    returnString = ("One pair");
                }
                else
                {
                    returnString = ("High card");
                }
            PokerHand = returnString;


        }
        private static int StraightFlush(List<Card> list)
        {
            int score = 80000;
            var sortedCards = list.OrderBy(x => (int)x.GetCardSuite()).ThenByDescending(x => x.GetCardValueInt()).ToList();

            for (int i = 0; i <= list.Count - 5; i++)
            {
                if (sortedCards[i].GetCardSuite() == sortedCards[i + 1].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i + 2].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i + 3].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i + 4].GetCardSuite() &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt() + 1 &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt() + 2 &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 3].GetCardValueInt() + 3 &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 4].GetCardValueInt() + 4
                    )
                {
                    return score + sortedCards[i + 4].GetCardValueInt();
                }
            }
            //Check for baby StraightFlush starting with ACE
            sortedCards = list.OrderBy(x => (int)x.GetCardSuite()).ThenByDescending(x => x.GetCardValueIntAceReduced()).ToList();

            for (int i = 0; i <= list.Count - 5; i++)
            {
                if (sortedCards[i].GetCardSuite() == sortedCards[i + 1].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i + 2].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i + 3].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i + 4].GetCardSuite() &&
                    sortedCards[i].GetCardValueIntAceReduced() == sortedCards[i + 1].GetCardValueIntAceReduced() + 1 &&
                    sortedCards[i].GetCardValueIntAceReduced() == sortedCards[i + 2].GetCardValueIntAceReduced() + 2 &&
                    sortedCards[i].GetCardValueIntAceReduced() == sortedCards[i + 3].GetCardValueIntAceReduced() + 3 &&
                    sortedCards[i].GetCardValueIntAceReduced() == sortedCards[i + 4].GetCardValueIntAceReduced() + 4
                    )
                {
                    return score + sortedCards[i + 4].GetCardValueIntAceReduced();
                }
            }

            return score;
        }

        public static int FourOfAKind(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();
            for (int i = 0; i <= sortedCards.Count - 4; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt() &&
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
            for (int i = 0; i <= list.Count - 3; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt() &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt())
                {
                    int intThree = sortedCards[i].GetCardValueInt();
                    var sortedlist2 = sortedCards.Where(v => v.GetCardValueInt() != intThree).ToList();

                    for (int j = 0; j < sortedlist2.Count - 1; j++)
                    {
                        if (sortedlist2[j].GetCardValueInt() == sortedlist2[j + 1].GetCardValueInt())
                        {
                            score = 60000 + intThree * 10 * 3 + sortedlist2[j].GetCardValueInt() * 2;
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
            var sortedCards = list.OrderByDescending(x => x.GetCardSuite()).ThenByDescending(v => v.GetCardValueInt()).ToList();

            for (int i = 0; i <= sortedCards.Count - 5; i++)
            {
                if (sortedCards[i].GetCardSuite() == sortedCards[i + 1].GetCardSuite() &&
                    sortedCards[i].GetCardSuite() == sortedCards[i + 2].GetCardSuite() &&
                sortedCards[i].GetCardSuite() == sortedCards[i + 3].GetCardSuite() &&
                sortedCards[i].GetCardSuite() == sortedCards[i + 4].GetCardSuite())
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
                if ((sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt() + 1 &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt() + 2 &&
                sortedCards[i].GetCardValueInt() == sortedCards[i + 3].GetCardValueInt() + 3 &&
                sortedCards[i].GetCardValueInt() == sortedCards[i + 4].GetCardValueInt() + 4))
                {
                    score = 40000 + sortedCards[i].GetCardValueInt();
                    return score;
                }
            }
            //Check for baby Straight starting with ACE
            sortedCards = list.OrderByDescending(x => x.GetCardValueIntAceReduced()).ToList();

            for (int i = 0; i <= sortedCards.Count - 5; i++)
            {
                if ((sortedCards[i].GetCardValueIntAceReduced() == sortedCards[i + 1].GetCardValueIntAceReduced() + 1 &&
                    sortedCards[i].GetCardValueIntAceReduced() == sortedCards[i + 2].GetCardValueIntAceReduced() + 2 &&
                sortedCards[i].GetCardValueIntAceReduced() == sortedCards[i + 3].GetCardValueIntAceReduced() + 3 &&
                sortedCards[i].GetCardValueIntAceReduced() == sortedCards[i + 4].GetCardValueIntAceReduced() + 4))
                {
                    score = 40000 + sortedCards[i].GetCardValueIntAceReduced();
                    return score;
                }
            }


            return score;
        }

        public static int ThreeOfAKind(List<Card> list)
        {
            int score = 0;
            var sortedCards = list.OrderByDescending(x => x.GetCardValueInt()).ToList();

            for (int i = 0; i <= sortedCards.Count - 3; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt() &&
                    sortedCards[i].GetCardValueInt() == sortedCards[i + 2].GetCardValueInt())
                {
                    int intThreeOfAKind = sortedCards[i].GetCardValueInt();
                    score = 30000 + sortedCards[i].GetCardValueInt() * 3 * 30;
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

            for (int i = 0; i < sortedCards.Count - 1; i++)
            {
                if (sortedCards[i].GetCardValueInt() == sortedCards[i + 1].GetCardValueInt())
                {
                    int intTwoOfAKind = sortedCards[i].GetCardValueInt();

                    var sortedCards2 = list.OrderByDescending(x => x.GetCardValueInt()).Where(v => v.GetCardValueInt() != intTwoOfAKind).ToList();
                    for (int j = 0; j < sortedCards2.Count - 1; j++)
                    {
                        if (sortedCards2[j].GetCardValueInt() == sortedCards2[j + 1].GetCardValueInt())
                        {
                            int intTwoOfAKind2 = sortedCards2[j].GetCardValueInt();
                            int intHighCard = sortedCards2.First(v => v.GetCardValueInt() != intTwoOfAKind2).GetCardValueInt();
                            score = 20000 + intTwoOfAKind * 2 * 30 + intTwoOfAKind2 * 2 * 10 + intHighCard;
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

                    score = 10000 + 2 * intTwoOfAKind * 8 + intHightCard1 + intHightCard2 + intHightCard3;

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
