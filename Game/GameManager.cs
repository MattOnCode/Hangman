using System;

namespace Hangman {
    class GameManager {

        /// <summary>
        /// Creates a new game.
        /// Resets all variables and lists.
        /// Chooses a random word from the list of game words to use within the game.
        /// Sets up lists containing the game word.
        /// </summary>
        public void newGame() {
            // Chooses the hangman word
            Random random = new Random();
            int randomWord = random.Next(Program.hangmanWords.Length);
            String hangmanWord = Program.hangmanWords[randomWord];

            // Resets variables and lists
            Program.incorrectPlayerGuesses.Clear();
            Program.playerGuesses.Clear();
            Program.incorrectGuesses = 0;

            // Inputs the newly created word into the game lists
            Program.gameWord.AddRange(hangmanWord);
            for (int x = 0; x < Program.gameWord.Count; x++) {
                Program.guessedWord.Add('_');
            }
        }
    }
}