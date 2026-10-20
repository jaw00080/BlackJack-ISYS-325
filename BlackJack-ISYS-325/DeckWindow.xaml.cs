using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlackJack_ISYS_325
{
    /// <summary>
    /// Interaction logic for DeckWindow.xaml
    /// </summary>
    public partial class DeckWindow : Window
    {

        private Deck deck = new Deck();
        public DeckWindow(Deck deck)
        {
            InitializeComponent();

            this.deck = deck;
            DeckListBox.ItemsSource = deck.Cards;
        }

        private void DeckListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeckListBox.SelectedItem is Card card)
            {
                string imagePath = (string)new CardImageConverter().Convert(card,typeof(string),null!,System.Globalization.CultureInfo.CurrentCulture);

                SelectedCardImage.Source = new BitmapImage(
                    new Uri("pack://application:,,," + imagePath));
            }
            else
            {
                SelectedCardImage.Source = null;
            }
        }

        private void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeckListBox.SelectedItem is Card selectedCard)
            {
                int index = DeckListBox.SelectedIndex;
                if (index > 0)
                {
                    deck.Cards.Move(index, index - 1);
                    DeckListBox.SelectedIndex = index - 1;
                }
            }
        }

        private void MoveDownButton_Click(object sender, RoutedEventArgs e)
        {
            int index = DeckListBox.SelectedIndex;

            if (index >= 0 && index < deck.Cards.Count - 1)
            {
                deck.Cards.Move(index, index + 1);
                DeckListBox.SelectedIndex = index + 1;
            }
        }
    }
}
