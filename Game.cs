using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_3
{
    /// <summary>
    /// Card game twenty one.
    /// </summary>
    class Game
    {
        /// <summary>
        /// List with the players.
        /// </summary>
        private List<Player> _players = new List<Player>();

        /// <summary>
        /// The number of players.
        /// </summary>
        private int _numOfPlayers;

        /// <summary>
        /// Creates a new dealer with name and a stop value.
        /// </summary>
        private Dealer dealer = new Dealer("Dealer:", 15);

        /// <summary>
        /// Set the number of players.
        /// </summary>
        public int NumOfPlayers
        {
            get { return _numOfPlayers; }
            set
            {
                if (value >= 30)
                {
                    throw new ArgumentOutOfRangeException("It's too many players");
                }
                else if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("You need to choose at least one player");
                }
                _numOfPlayers = value;
            }
        }

        /// <summary>
        /// Constructor to set number of players.
        /// </summary>
        public Game(int numOfPlayers)
        {
            NumOfPlayers = numOfPlayers;
        }

        /// <summary>
        /// Creates players based on the amount of players.
        /// </summary>
        public void CreatePlayers()
        {
            for (int i = 0; i < _numOfPlayers; i++)
            {
                string playerName = ($"Player #{i + 1}:");
                Player player = new Player(playerName, 15);
                _players.Add(player);
            }
        }

        /// <summary>
        /// Generates a new deck and iterates through each player
        /// and calls the CheckForCondition method.
        /// </summary>
        public void StartGame()
        {
            dealer.NewDeck();
            CreatePlayers();

            for (int i = 0; i < _players.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Game #" + (1+i));
                Console.ResetColor();
                
                Player player = _players[i];
                CheckForCondition(player);
            }
        }

        /// <summary>
        /// Gives cards and checks if players and dealer wants more cards
        /// or if someone wins or loses.
        /// </summary>
        public void CheckForCondition(Player player)
        {
            while (player.AskForCard) player.AddCard(dealer.Deal());
            ShowHand(player);
            if (player.HandValue < 21)
            {
                while (dealer.AskForCard) dealer.AddCard(dealer.Deal());
                ShowHand(dealer);
            }
            else
            {
                Console.Write($"{dealer.PlayerName} - \n");
            }

            if (player.HandValue > dealer.HandValue && player.HandValue <= 21 ||
                player.Hand.Count() >= 5 && player.HandValue <= 21 ||
                dealer.HandValue > 21)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n PLAYER WINS! \n");
                Console.ResetColor();
                Console.WriteLine("═══════════════════════════════════════════\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n DEALER WINS! \n");
                Console.ResetColor();
                Console.WriteLine("═══════════════════════════════════════════\n");
            }

            dealer.DiscardedCards(player.DiscardCards());
            dealer.DiscardedCards(dealer.DiscardCards());
        }

        /// <summary>
        /// Displays the player and dealers cards, name and total value.
        /// </summary>
        public void ShowHand(Player player)
        {
            Console.Write($"{player.PlayerName}");

            foreach (Card card in player.Hand)
            {
                Console.Write(card);
            }
            if (player.HandValue > 21)
            {
                
                Console.Write($" ({player.HandValue})");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" BUSTED! \n");
                Console.ResetColor();
            }
            else
            {
                Console.Write($" ({player.HandValue}) \n");
            }
        }
    }
}