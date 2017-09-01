using System;
using System.Collections.Generic;
using System.Text;

namespace CompressionAlgorithm
{
    class Pattern
    {
        public string _characters;
        public int _occurances = 1;

        public Pattern (string characters)
        {
            _characters = characters;
        }

        public void AddOccurance()
        {
            _occurances++;
        }

        // Default comparer for Pattern type.
        public int CompareTo(Pattern comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;
            else
                return this._occurances.CompareTo(comparePart._occurances);
        }
    }
}
