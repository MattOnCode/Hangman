using System;
using System.Text.RegularExpressions;

namespace Hangman {
    class GameEngine {

        public bool validateGuess(String guess) {
            if (guess.Length == 1) {
                if (Regex.IsMatch(guess, @"^[a-zA-Z]+$")) {
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