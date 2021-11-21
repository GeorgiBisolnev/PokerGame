using NUnit.Framework;
using Poker;
using System.Collections.Generic;

namespace PokerHandsTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void RoyalFlushHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.Ace);
            var card2 = new Card(Suite.Hearts, Value.King);
            var card3 = new Card(Suite.Diamonds, Value.Ace);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Clubs, Value.ten);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Clubs, Value.King);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.AreEqual(Evaluation.HandEvaluation, 8.0001);
        }
        [Test]
        public void StraightFlushHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.King);
            var card3 = new Card(Suite.Diamonds, Value.Ace);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Clubs, Value.ten);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Clubs, Value.King);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 8);
            Assert.AreNotEqual(Evaluation.HandEvaluation, 8.0001);

            card1 = new Card(Suite.Clubs, Value.Ace);
            card2 = new Card(Suite.Hearts, Value.King);
            card3 = new Card(Suite.Diamonds, Value.Ace);
            card4 = new Card(Suite.Clubs, Value.two);
            card5 = new Card(Suite.Clubs, Value.three);
            card6 = new Card(Suite.Clubs, Value.four);
            card7 = new Card(Suite.Clubs, Value.five);
            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 8);
            Assert.AreNotEqual(Evaluation.HandEvaluation, 8.0001);
        }
        [Test]
        public void FlushHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.eight);
            var card2 = new Card(Suite.Hearts, Value.King);
            var card3 = new Card(Suite.Diamonds, Value.Ace);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Clubs, Value.ten);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Clubs, Value.King);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 5);
            Assert.Less(Evaluation.HandEvaluation, 6);
        }
        [Test]
        public void FourOfAKindHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.nine);
            var card3 = new Card(Suite.Diamonds, Value.two);
            var card4 = new Card(Suite.Diamonds, Value.nine);
            var card5 = new Card(Suite.Spides, Value.three);
            var card6 = new Card(Suite.Clubs, Value.three);
            var card7 = new Card(Suite.Spides, Value.nine);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 7);
            Assert.Less(Evaluation.HandEvaluation, 8);
        }
        [Test]
        public void FullHouseHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.nine);
            var card3 = new Card(Suite.Diamonds, Value.two);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Spides, Value.three);
            var card6 = new Card(Suite.Clubs, Value.three);
            var card7 = new Card(Suite.Spides, Value.nine);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 6);
            Assert.Less(Evaluation.HandEvaluation, 7);
        }
        [Test]
        public void StraightHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.King);
            var card3 = new Card(Suite.Diamonds, Value.four);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Spides, Value.ten);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Clubs, Value.King);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 4);
            Assert.Less(Evaluation.HandEvaluation, 5);

            card1 = new Card(Suite.Clubs, Value.nine);
            card2 = new Card(Suite.Hearts, Value.King);
            card3 = new Card(Suite.Diamonds, Value.Queen);
            card4 = new Card(Suite.Clubs, Value.Jack);
            card5 = new Card(Suite.Spides, Value.ten);
            card6 = new Card(Suite.Clubs, Value.Queen);
            card7 = new Card(Suite.Clubs, Value.King);
            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 4);
            Assert.Less(Evaluation.HandEvaluation, 5);

            card1 = new Card(Suite.Clubs, Value.nine);
            card2 = new Card(Suite.Hearts, Value.Queen);
            card3 = new Card(Suite.Diamonds, Value.Jack);
            card4 = new Card(Suite.Clubs, Value.ten);
            card5 = new Card(Suite.Spides, Value.nine);
            testList = new List<Card> { card1, card2, card3, card4, card5 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 1);
            Assert.Less(Evaluation.HandEvaluation, 2);

            //Baby straight
            card1 = new Card(Suite.Clubs, Value.Ace);
            card2 = new Card(Suite.Hearts, Value.two);
            card3 = new Card(Suite.Diamonds, Value.Queen);
            card4 = new Card(Suite.Clubs, Value.three);
            card5 = new Card(Suite.Spides, Value.ten);
            card6 = new Card(Suite.Clubs, Value.four);
            card7 = new Card(Suite.Clubs, Value.five);
            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 4);
            Assert.Less(Evaluation.HandEvaluation, 5);
        }
        [Test]
        public void ThreeOfAKindHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.nine);
            var card3 = new Card(Suite.Diamonds, Value.two);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Spides, Value.ten);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Spides, Value.nine);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 3);
            Assert.Less(Evaluation.HandEvaluation, 4);
        }
        [Test]
        public void TwoPairsHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.nine);
            var card3 = new Card(Suite.Diamonds, Value.two);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Spides, Value.Jack);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Spides, Value.six);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 2);
            Assert.Less(Evaluation.HandEvaluation, 3);
        }
        [Test]
        public void PairHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.nine);
            var card3 = new Card(Suite.Diamonds, Value.two);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Spides, Value.four);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Spides, Value.six);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 1);
            Assert.Less(Evaluation.HandEvaluation, 2);
        }
        [Test]
        public void HighCardHandTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.eight);
            var card3 = new Card(Suite.Diamonds, Value.two);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Spides, Value.four);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Spides, Value.six);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            Assert.Greater(Evaluation.HandEvaluation, 0);
            Assert.Less(Evaluation.HandEvaluation, 1);
        }

        [Test]
        public void EvaluatingTwoStraightHandsTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.nine);
            var card2 = new Card(Suite.Hearts, Value.nine);
            var card3 = new Card(Suite.Diamonds, Value.nine);
            var card4 = new Card(Suite.Clubs, Value.Ace);
            var card5 = new Card(Suite.Spides, Value.two);
            var card6 = new Card(Suite.Clubs, Value.three);
            var card7 = new Card(Suite.Spides, Value.four);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            double hand1 = Evaluation.HandEvaluation;

            card4 = new Card(Suite.Clubs, Value.King);
            card5 = new Card(Suite.Spides, Value.Queen);
            card6 = new Card(Suite.Clubs, Value.Jack);
            card7 = new Card(Suite.Spides, Value.eight);
            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            double hand2 = Evaluation.HandEvaluation;
            Assert.Greater(hand1, hand2);

        }

        [Test]
        public void EvaluatingTwoStraightFlushHandsTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.seven);
            var card2 = new Card(Suite.Clubs, Value.eight);
            var card3 = new Card(Suite.Clubs, Value.nine);
            var card4 = new Card(Suite.Clubs, Value.ten);
            var card5 = new Card(Suite.Clubs, Value.Ace);
            var card6 = new Card(Suite.Clubs, Value.six);
            var card7 = new Card(Suite.Clubs, Value.four);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            double hand1 = Evaluation.HandEvaluation;

            card1 = new Card(Suite.Clubs, Value.seven);
            card2 = new Card(Suite.Clubs, Value.eight);
            card3 = new Card(Suite.Clubs, Value.nine);
            card4 = new Card(Suite.Clubs, Value.ten);
            card5 = new Card(Suite.Clubs, Value.Jack);
            card6 = new Card(Suite.Clubs, Value.three);
            card7 = new Card(Suite.Clubs, Value.four);

            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            double hand2 = Evaluation.HandEvaluation;

            Assert.Greater(hand2, hand1);

        }
        [Test]
        public void TwoPairsHandsTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.ten);
            var card2 = new Card(Suite.Spides, Value.ten);
            var card3 = new Card(Suite.Clubs, Value.two);
            var card4 = new Card(Suite.Spides, Value.two);
            var card5 = new Card(Suite.Clubs, Value.Ace);
            var card6 = new Card(Suite.Clubs, Value.King);
            var card7 = new Card(Suite.Spides, Value.Queen);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            double hand1 = Evaluation.HandEvaluation;

            card1 = new Card(Suite.Clubs, Value.ten);
            card2 = new Card(Suite.Spides, Value.ten);
            card3 = new Card(Suite.Clubs, Value.nine);
            card4 = new Card(Suite.Spides, Value.nine);
            card5 = new Card(Suite.Clubs, Value.two);
            card6 = new Card(Suite.Clubs, Value.three);
            card7 = new Card(Suite.Spides, Value.four);

            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            double hand2 = Evaluation.HandEvaluation;

            Assert.Greater(hand2, hand1);

        }

        [Test]
        public void OnePairHandsTest()
        {
            Evaluation Evaluation = new Poker.Evaluation();

            var card1 = new Card(Suite.Clubs, Value.three);
            var card2 = new Card(Suite.Spides, Value.three);
            var card3 = new Card(Suite.Clubs, Value.two);
            var card4 = new Card(Suite.Spides, Value.five);
            var card5 = new Card(Suite.Clubs, Value.six);
            var card6 = new Card(Suite.Clubs, Value.King);
            var card7 = new Card(Suite.Spides, Value.eight);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            double hand1 = Evaluation.HandEvaluation;

            card1 = new Card(Suite.Clubs, Value.two);
            card2 = new Card(Suite.Spides, Value.two);
            card3 = new Card(Suite.Clubs, Value.Ace);
            card4 = new Card(Suite.Spides, Value.King);
            card5 = new Card(Suite.Clubs, Value.Queen);
            card6 = new Card(Suite.Clubs, Value.three);
            card7 = new Card(Suite.Spides, Value.ten);

            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            double hand2 = Evaluation.HandEvaluation;

            Assert.Greater(hand1, hand2);

            card1 = new Card(Suite.Clubs, Value.two);
            card2 = new Card(Suite.Spides, Value.two);
            card3 = new Card(Suite.Clubs, Value.Ace);
            card4 = new Card(Suite.Spides, Value.King);
            card5 = new Card(Suite.Clubs, Value.Queen);
            card6 = new Card(Suite.Clubs, Value.three);
            card7 = new Card(Suite.Spides, Value.ten);

            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            hand1 = Evaluation.HandEvaluation;

            card1 = new Card(Suite.Clubs, Value.two);
            card2 = new Card(Suite.Spides, Value.two);
            card3 = new Card(Suite.Clubs, Value.Ace);
            card4 = new Card(Suite.Spides, Value.King);
            card5 = new Card(Suite.Clubs, Value.Jack);
            card6 = new Card(Suite.Clubs, Value.three);
            card7 = new Card(Suite.Spides, Value.nine);

            testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

            Evaluation.Evaluate(testList);
            hand2 = Evaluation.HandEvaluation;

            Assert.Greater(hand1, hand2);

        }


    }
}