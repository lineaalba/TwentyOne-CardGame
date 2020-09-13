using System;

namespace Examination_3
{
    /// <summary>
    /// Options the user chooses between.
    /// </summary>
    enum Options { Indefinite, One, Two, Three, Four, Five, Six, Seven };
    class Program
    {
        /// <summary>
        /// The starting point of the application
        /// </summary>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            try
            {
                StartApp();
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Checks what shapes the user wants to see.
        /// </summary>
        public static void StartApp()
        {
            bool exit = false;
            Options type = Options.Indefinite;

            do
            {
                
                switch (MenuChoices())
                {
                    case 0:
                        exit = true;
                        break;

                    case 1:
                        type = Options.One;
                        break;

                    case 2:
                        type = Options.Two;
                        break;

                    case 3:
                        type = Options.Three;
                        break;

                    case 4:
                        type = Options.Four;
                        break;

                    case 5:
                        type = Options.Five;
                        break;

                    case 6:
                        type = Options.Six;
                        break;

                    case 7:
                        type = Options.Seven;
                        break;
                }
                Console.Clear();
              
                if (type == Options.One)
                {
                    Game game = new Game(1);
                    game.StartGame();

                }
                else if (type == Options.Two)
                {
           
                    Game game = new Game(2);
                    game.StartGame();
                }
                else if (type == Options.Three)
                {
           
                    Game game = new Game(3);
                    game.StartGame();
                }
                else if (type == Options.Four)
                {
           
                    Game game = new Game(4);
                    game.StartGame();
                }
                else if (type == Options.Five)
                {
           
                    Game game = new Game(5);
                    game.StartGame();
                }
                else if (type == Options.Six)
                {
           
                    Game game = new Game(6);
                    game.StartGame();
                }
                else if (type == Options.Seven)
                {
           
                    Game game = new Game(7);
                    game.StartGame();
                }
                ContinueOnKeyPressed();
            } while (!exit);
        }

        /// <summary>
        /// Creates a menu with options.
        /// </summary>
        private static int MenuChoices()
        {
            int index;

            do
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════════\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Welcome to twenty-one card game simulator!");
                Console.WriteLine("Please choose number of players or press 0 to exit.");
                Console.ResetColor();
                Console.WriteLine("\n═══════════════════════════════════════════\n");
                Console.Write("Choose number of players [1-7]: ");
              

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 7)
                {
                    return index;
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Not a valid option!\n");
                Console.ResetColor();
                ContinueOnKeyPressed();
            } while (true);
        }
        
        /// <summary>
        /// Reads user key press.
        /// </summary>
        private static void ContinueOnKeyPressed()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("   Press any key to continue   ");
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = true;
        }
    }
}