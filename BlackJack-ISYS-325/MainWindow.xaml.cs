using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack_ISYS_325
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            StartGame();

        }

        public ObservableCollection<Card> PlayerHand { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Card> DealerHand { get; set; } = new ObservableCollection<Card>();

        private Deck deck = new Deck();

        private DeckWindow deckwindow;

        public void DealPlayer()
        {
            if (deck.Cards.Count > 0)
            {
                PlayerHand.Add(deck.Cards[0]); // adds a card to the collection
                deck.Cards.RemoveAt(0); // removes it from the list of cards in the deck
            }
        }

        public void DealDealer()
        {
            if (deck.Cards.Count > 0)
            {
                DealerHand.Add(deck.Cards[0]); // Adds a card to the collection
                deck.Cards.RemoveAt(0); // removes it from the list of cards in the deck
            }
        }

        public int CalculateScore(ObservableCollection<Card> hand)
        {
            int total = 0;
            int aceCount = 0;
            foreach (var card in hand)
            {
                total += card.Value;
                if (card.Rank == 1) // Ace
                {
                    aceCount++;
                    total += 10; // Count Ace as 11 initially
                }
            }
            // Adjust for Aces if total is over 21
            while (total > 21 && aceCount > 0)
            {
                total -= 10; // Count Ace as 1 instead of 11
                aceCount--;
            }
            return total;
        }

        public void UpdateScores()
        {
            int playerScore = CalculateScore(PlayerHand);
            int dealerScore = CalculateScore(DealerHand);
            playerScoreText.Text = $"Player Score: {playerScore}";
            dealerScoreText.Text = $"Dealer Score: {dealerScore}";
        }

        public void StartGame()
        {
            deck.Cards.Clear();
            PlayerHand.Clear();
            DealerHand.Clear();
            deck.CreateDeck();
            deck.ShuffleDeck();
            // Deal two cards to the player
            DealPlayer();
            DealPlayer();
            // Deal two cards to the dealer
            DealDealer();
            DealDealer();
            UpdateScores();
        }

        private void deckInspect_Click(object sender, RoutedEventArgs e)
        {
            if (deckwindow == null)
            {
                deckwindow = new DeckWindow(deck);
                deckwindow.Closed += (closedSender, args) => deckwindow = null; // Reset the reference when closed
                deckwindow.Show();
            }
            else
            {
                deckwindow.Activate(); // Pulls the existing window to the front if it's already open
            }
            
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            DealPlayer();
            UpdateScores();
            int playerScore = CalculateScore(PlayerHand);
            if (playerScore > 21) // Starts the game over if the player busts
            {
                MessageBox.Show("Player busts! Dealer wins.");
                StartGame();
            }
        }
    }
}
