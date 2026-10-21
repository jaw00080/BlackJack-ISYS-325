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

        private void DeckListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // This method is called when the selection in the DeckListBox changes. It updates the SelectedCardImage to display the image of the selected card.
        {
            if (DeckListBox.SelectedItem is Card card)
            {
                string imagePath = (string)new CardImageConverter().Convert(card,typeof(string),null!,System.Globalization.CultureInfo.CurrentCulture); // Use the CardImageConverter to get the image path for the selected card

                SelectedCardImage.Source = new BitmapImage(
                    new Uri("pack://application:,,," + imagePath)); // Uses the image path to create a new BitmapImage and sets it as the source for the SelectedCardImage control
            }
            else
            {
                SelectedCardImage.Source = null;
            }
        }

        private void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeckListBox.SelectedItem is Card selectedCard) // This checks if the selected item in the DeckListBox is a Card object. If it is, it proceeds to move the card up in the list.
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

            if (index >= 0 && index < deck.Cards.Count - 1) // This checks if the selected index is valid and not the last item in the list.
            {
                deck.Cards.Move(index, index + 1);
                DeckListBox.SelectedIndex = index + 1;
            }
        }
    }
}
