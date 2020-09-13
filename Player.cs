using System.Collections.Generic;
using System.Linq;

namespace Examination_3
{
    /// <summary>
    /// The Player class to create a player.
    /// </summary>
    class Player
      {
        /// <summary>
        /// The player hand.
        /// </summary>
        private List<Card> _hand = new List<Card>();

        /// <summary>
        /// The value of the player hand.
        /// </summary>
        private int _handValue;

        /// <summary>
        /// Returns _hand as read-only to protect against privacy leak.
        /// </summary>
        public IReadOnlyList<Card> Hand
        {
            get
            {
                return _hand.AsReadOnly();
            }
        }

        /// <summary>
        /// Sets the sum of player hand.
        /// </summary>
        public int HandValue
        {
            get
            {
                _handValue = _hand.Sum(i => i.CardValue);
                if (_handValue > 21)
                {
                    int aces = _hand.Count(i => i.Rank == Rank.A);
                    while (_handValue > 21 && aces-- > 0)
                    {
                        _handValue -= 13;
                    }
                }
                return _handValue;
            }
        }

        /// <summary>
        /// Sets the player stop value.
        /// </summary>
        private int StopValue { get; }

        /// <summary>
        /// Sets the player name.
        /// </summary>
        public string PlayerName { get; }

        /// <summary>
        /// Boolean to check if player wants another card.
        /// </summary>
        public bool AskForCard { get => HandValue < StopValue ? true : false; }

        /// <summary>
        /// Constructor to set the name and stop value for the player.
        /// </summary>
        public Player(string playerName = "Player", int stopValue = 12)
        {
            PlayerName = playerName;
            StopValue = stopValue;
        }

        /// <summary>
        /// Adds a card to the player hand.
        /// </summary>
        public void AddCard(Card card)
        {
            _hand.Add(card);
        }

        /// <summary>
        /// Removes the cards from the player hand, and adds it to the discarded card list.
        /// </summary>
        public IEnumerable<Card> DiscardCards()
        {
            IEnumerable<Card> discardedCards = _hand.ToList();
            _hand.Clear();
            return discardedCards;
        }
    }
}
