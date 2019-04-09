using System;
using System.Configuration;
using Hangman.View;

namespace Hangman {
    class Program {

        // Possible words the user has to guess
        private static readonly string[] HangmanWords = {
            "HANGMAN", "APPLE", "TOWER", "SMARTPHONE", "PROGRAMMING", "AWKWARD", "BANJO",
            "DWARVES", "FISHHOOK", "JAZZY", "JUKEBOX", "MEMENTO", "MYSTIFY", "OXYGEN", "PIXEL",
            "ZOMBIE", "NUMBSKULL", "BAGPIPES", "COMPUTER", "EASTER", "CHRISTMAS", "COFFEE"
        };
        
        static void Main(string[] args)
        {
            var random = new Random();
            var visualizer = new TextVisualizer();
            var game = new Game(visualizer, HangmanWords[random.Next(HangmanWords.Length)]);
        }
    }
}
