using System;
using System.Collections.Generic;
using System.Text;

namespace CompressionAlgorithm
{
    class Pattern
    {
        private string _characters;
        private int _occurrences;
        private int _score;

        public string characters
        {
            get { return _characters; }
        }

        public int occurrences
        {
            get { return _occurrences; }
        }
        public int score
        {
            get { return _score; }
        }


        public Pattern (string characters, int occurances = 1)
        {
            _characters = characters;
            _occurrences = occurances;

            SetScore();
        }

        public void AddOccurence()
        {
            _occurrences++;

            SetScore();
        }

        public void SetScore()
        {
            _score = (_characters.Length * _occurrences) - (_characters.Length + _occurrences + 3);
        }
    }
}
