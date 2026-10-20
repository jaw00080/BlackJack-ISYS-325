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
            if (value is not Card card)
                return null;

            int iIndex;

            if (card.Rank == 13)
            {
                iIndex = 0;

            }
            else
            {
                iIndex = card.Rank;
            }

            int suitIndex = 0;

            switch (card.Suit)
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
            int imageNum = suitIndex + iIndex;
            return $"/Images/p{imageNum}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
