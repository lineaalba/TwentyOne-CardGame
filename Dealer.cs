
using System.Collections.Generic;
using System.Linq;

namespace Examination_3
{
    /// <summary>
    /// Inherits from player.
    /// </summary>
    class Dealer : Player
    {
        /// <summary>
        /// A list representing the cards in a deck.
        /// </summary>
        private List<Card> _cards;

        /// <summary>
        /// A list representing the discarded cards.
        /// </summary>
        private List<Card> _discardedCards = new List<Card>();

        /// <summary>
        /// Creates a new deck.
        /// </summary>
        private Deck _deck = new Deck();

        /// <summary>
        /// Constructor to set the dealer name and stop value.
        /// </summary>
        public Dealer(string dealerName = "Dealer:", int stopValue = 12) : base(dealerName, stopValue)
        {
            /// Empty.
        }

        /// <summary>
        /// Creates and shuffles a deck.
        /// </summary>
        public void NewDeck()
        {
            _deck.InstansiateDeck();
            _cards = new List<Card>(_deck.Cards);
        }

        /// <summary>
        /// Deals a card to player.
        /// </summary>
        public Card Deal()
        {
            if (_cards.Count() <= 1)
            {
                foreach (var card in _discardedCards)
                {
                    _cards.Add(card);
                }
                _discardedCards.Clear();
                _deck.Shuffle();
            }

            // Draw and deal first card in deck.
            Card firstCard = _cards.First();
            _cards.Remove(firstCard);
            return firstCard;
        }

        /// <summary>
        /// Throws all the cards in the discarded cards list.
        /// </summary>
        public void DiscardedCards(IEnumerable<Card> cards)
        {
            _discardedCards.AddRange(cards);
        }
    }  
}
