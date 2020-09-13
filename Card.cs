using System;

namespace Examination_3
{
    /// <summary>
    /// The Card class represents a card in a deck.
    /// </summary>
    public class Card
     {
        /// <summary>
        /// Autoimplemented get that sets the suit.
        /// </summary>
        public Suit Suit { get; }

        /// <summary>
        /// Autoimplemented get that sets the rank.
        /// </summary>
        public Rank Rank { get; }

        /// <summary>
        /// Sets the value of a card by using the enum Rank value.
        /// </summary>
        public int CardValue
        { 
            get { return (int)Rank; }
        }

        /// <summary>
        /// Constructor that sets the rank and suit for a card.
        /// </summary>
        public Card(Rank rank, Suit suit)
        {
            // Boolean to check if Rank and Suit is defined in its Enum. 
            // If true, Rank and Suit gets value from Enum. If false, an exception is thrown.
            Rank = Enum.IsDefined(typeof(Rank), rank) ? rank : throw new ArgumentException(nameof(rank));
            Suit = Enum.IsDefined(typeof(Suit), suit) ? suit : throw new ArgumentException(nameof(suit));
        }

        /// <summary>
        /// Overrides default ToString method.
        /// </summary>
        public override string ToString()
        {
            if (CardValue > 1 & CardValue < 11)
            {
               return $" {CardValue.ToString() : Rank.ToString())}{(char)Suit}";
            }
            else
            {
                 return $" {(Rank.ToString())}{(char)Suit}";
                
            }
        }
    }
}
