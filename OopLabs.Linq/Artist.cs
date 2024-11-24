using System;

namespace OopLabs.Linq
{
    internal class Artist
    {
        public string Name { get; set; }

        public Artist(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}