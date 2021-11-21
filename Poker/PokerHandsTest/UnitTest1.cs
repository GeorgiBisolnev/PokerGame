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
            var card3 = new Card(Suite.Diamonds, Value.two);
            var card4 = new Card(Suite.Clubs, Value.Jack);
            var card5 = new Card(Suite.Spides, Value.ten);
            var card6 = new Card(Suite.Clubs, Value.Queen);
            var card7 = new Card(Suite.Clubs, Value.King);
            List<Card> testList = new List<Card> { card1, card2, card3, card4, card5, card6, card7 };

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

    }
}