using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack_ISYS_325
{
    public class Card
    {
        public String Suit { get; set; }
        public int Value { get; set; }
        public int Rank { get; set; }
        public String Name { get; set; }

        public Card(String suit, int value, int rank, String name)
        {
            Suit = suit;
            Value = value;
            Rank = rank;
            Name = name;
        }
    }
}
