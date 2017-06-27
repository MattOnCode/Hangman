using System;

namespace Hangman {
    class GameManager {

        public void newGame() {
            Random random = new Random();
            int randomWord = random.Next(Program.hangmanWords.Length);
            String hangmanWord = Program.hangmanWords[randomWord];

            Program.incorrectPlayerGuesses.Clear();
            Program.playerGuesses.Clear();
            Program.incorrectGuesses = 0;
            Program.gameWord.AddRange(hangmanWord);
            for (int x = 0; x < Program.gameWord.Count; x++) {
                Program.guessedWord.Add('_');
            }
        }
    }
}