using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BlackJack_ISYS_325
{
    public class Deck
    {
        public ObservableCollection<Card> Cards { get; set; } = new ObservableCollection<Card>();

        public void CreateDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] names = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            foreach (string suit in suits)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    int value = (i >= 10) ? 10 : i + 1; // Face cards are worth 10
                    Cards.Add(new Card(suit, value, i + 1, names[i] + " of " + suit));
                }
            }
        }

        public void ShuffleDeck()
        {
            Random rng = new Random(); // This was autofilled, but it works.
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
    }
}
