using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_3
{
    /// <summary>
    /// The Deck class represents a deck with 52 cards.
    /// </summary>
    public class Deck
   {
        /// <summary>
        /// A list with cards.
        /// </summary>
        private List<Card> _cards = new List<Card>();

        /// <summary>
        /// A read only list with cards to prevent privacy leak.
        /// </summary>
       public IReadOnlyList<Card> Cards
       {
           get
           {
               return _cards.AsReadOnly();
           }
       }
       
        /// <summary>
        /// Loops through and creates cards from the available different values, 
        /// then adds it to the cards list.
        /// </summary>
        public void InstansiateDeck()
        {
            _cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card(rank, suit));
                }
            }
            Shuffle();
        }

        /// <summary>
        /// Shuffles the cards.
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random();
            int numberOfCards = _cards.Count();
            Card tempValue;
            int randomIndex;
    
            while (numberOfCards != 0)
            {
                randomIndex = random.Next(numberOfCards);
                numberOfCards -= 1;
                tempValue = _cards[numberOfCards];
                _cards[numberOfCards] = _cards[randomIndex];
                _cards[randomIndex] = tempValue;
            }
        }
    }
}