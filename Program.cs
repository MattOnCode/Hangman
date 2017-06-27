using System;
using System.Collections.Generic;

namespace Hangman {
    class Program {

        public static String[] hangmanWords = {
            "HANGMAN", "APPLE", "TOWER", "SMARTPHONE", "PROGRAMMING", "AWKWARD", "BANJO",
            "DWARVES", "FISHHOOK", "JAZZY", "JUKEBOX", "MEMENTO", "MYSTIFY", "OXYGEN", "PIXEL",
            "ZOMBIE", "NUMBSKULL", "BAGPIPES", "COMPUTER", "EASTER", "CHRISTMAS", "COFFEE"
        };
        public static List<char> gameWord = new List<char>();
        public static List<char> guessedWord = new List<char>();
        public static List<char> incorrectPlayerGuesses = new List<char>();
        public static List<char> playerGuesses = new List<char>();
        public static int incorrectGuesses;

        static void Main(string[] args) {

            GameManager _gameManager = new GameManager();
            GameEngine _gameEngine = new GameEngine();
            GameVisualizer _gameVisualizer = new GameVisualizer();

            _gameVisualizer.outputWelcome();

            _gameManager.newGame();

            while (guessedWord.Contains('_')) {
                Console.Clear();
                _gameVisualizer.outputWord(guessedWord);
                _gameVisualizer.outputGuessedLetters();
                Console.WriteLine(Environment.NewLine + "Enter a guess");
                String playerGuess = Console.ReadLine().ToUpper();
                if (_gameEngine.validateGuess(playerGuess)) {
                    char guess = Convert.ToChar(playerGuess);
                    if (!playerGuesses.Contains(guess)) {
                        if (gameWord.Contains(guess)) {
                            playerGuesses.Add(guess);
                            for (int x = 0; x < gameWord.Count; x++) {
                                if (gameWord[x] == guess) {
                                    guessedWord[x] = guess;
                                }
                            }
                        } else {
                            playerGuesses.Add(guess);
                            incorrectPlayerGuesses.Add(guess);
                            incorrectGuesses++;
                            if (incorrectGuesses >= 6) {
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

            _gameVisualizer.outputWinMessage();
        }
    }
}
