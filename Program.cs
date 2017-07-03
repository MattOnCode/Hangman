using System;
using System.Collections.Generic;

namespace Hangman {
    class Program {

        // Creates a list of possible words the user has to guess
        public static String[] hangmanWords = {
            "HANGMAN", "APPLE", "TOWER", "SMARTPHONE", "PROGRAMMING", "AWKWARD", "BANJO",
            "DWARVES", "FISHHOOK", "JAZZY", "JUKEBOX", "MEMENTO", "MYSTIFY", "OXYGEN", "PIXEL",
            "ZOMBIE", "NUMBSKULL", "BAGPIPES", "COMPUTER", "EASTER", "CHRISTMAS", "COFFEE"
        };

        // Declaration of lists used for the game
        public static List<char> gameWord = new List<char>();
        public static List<char> guessedWord = new List<char>();
        public static List<char> incorrectPlayerGuesses = new List<char>();
        public static List<char> playerGuesses = new List<char>();
        public static int incorrectGuesses;

        static void Main(string[] args) {

            // Initalising instances of the game classes
            GameManager _gameManager = new GameManager();
            GameEngine _gameEngine = new GameEngine();
            GameVisualizer _gameVisualizer = new GameVisualizer();

            _gameVisualizer.outputWelcome(); // Displays the welcome message

            _gameManager.newGame(); // Creates a new Hangman Game

            while (guessedWord.Contains('_')) { // Loops while there are still letters to guess
                Console.Clear(); // Clears the console
                _gameVisualizer.outputWord(guessedWord); // Outputs the word the user needs to guess
                _gameVisualizer.outputGuessedLetters(); // Outputs the incorrect letters the users guessed
                Console.WriteLine(Environment.NewLine + "Enter a guess"); // Prompts user to enter a guess
                String playerGuess = Console.ReadLine().ToUpper();
                if (_gameEngine.validateGuess(playerGuess)) { // Validates the guess is a single letter and alphabetical
                    char guess = Convert.ToChar(playerGuess);
                    if (!playerGuesses.Contains(guess)) { // Checks to see if the letter has been guessed before
                        if (gameWord.Contains(guess)) { // Checks to see if the word contains the letter
                            playerGuesses.Add(guess); // Adds to the list of guessed letters
                            for (int x = 0; x < gameWord.Count; x++) { // Shows ALL letters that match in the word
                                if (gameWord[x] == guess) {
                                    guessedWord[x] = guess;
                                }
                            }
                        } else {
                            playerGuesses.Add(guess);
                            incorrectPlayerGuesses.Add(guess); // Adds to the list of incorrect guesses
                            incorrectGuesses++; // Increments the amount of incorrect guesses the user has done
                            if (incorrectGuesses >= 6) { // If the user has had 6 or more incorrect guesses, they lose.
                                _gameVisualizer.outputLoseMessage();
                            }
                        }
                    } else {
                        Console.WriteLine(Environment.NewLine + "You have already guessed that letter!");
                    }
                } else {
                    Console.WriteLine(Environment.NewLine + "Invalid Guess. Guesses must be a single alphabetical letter.");
                }
            }

            _gameVisualizer.outputWinMessage(); // Outputs the win message
        }
    }
}
