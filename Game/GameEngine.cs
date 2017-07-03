using System;
using System.Text.RegularExpressions;

namespace Hangman {
    class GameEngine {

        /// <summary>
        /// Validates whether or not the guess is valid.
        /// The guess must be alphabetical, and a single char.
        /// </summary>
        /// <param name="guess">The users guess</param>
        /// <returns></returns>
        public bool validateGuess(String guess) {
            if (guess.Length == 1) { // Makes sure the guess is a singel letter
                if (Regex.IsMatch(guess, @"^[a-zA-Z]+$")) { // Uses regex to determine if the guess is alphabetical
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
    }
}