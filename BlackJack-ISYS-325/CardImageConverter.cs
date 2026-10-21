using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Text;
using System.Windows;

namespace BlackJack_ISYS_325
{
    public class CardImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Card card) // Check if the value is not of type Card, if not, return null
                return null;

            int iIndex;

            if (card.Rank == 13) // If the card's rank is 13 (King), set the index to 0, otherwise set it to the card's rank
            {
                iIndex = 0;

            }
            else
            {
                iIndex = card.Rank;
            }

            int suitIndex = 0;

            switch (card.Suit) // Uses a switch statement to determine the suit index based on the card's suit
            {
                case "Clubs":
                    suitIndex = 0;
                    break;
                case "Diamonds":
                    suitIndex = 13;
                    break;
                case "Hearts":
                    suitIndex = 26;
                    break;
                case "Spades":
                    suitIndex = 39;
                    break;
            }
            int imageNum = suitIndex + iIndex; // Calculate the image number by adding the suit index and the card's rank index
            return $"/Images/p{imageNum}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        {
            return null;
        }
    }
}
