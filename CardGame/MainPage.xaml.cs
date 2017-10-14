using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Deck myDeck = new Deck();
        int ValueOfLastCard;
        int NextCardTop;
        int NextCardBottom;

        public MainPage()
        {
            this.InitializeComponent();
            Player1Button.IsEnabled = false;
            Player2Button.IsEnabled = false;
        }

        private void PlayArea_Loaded(object sender, RoutedEventArgs e)
        {
            this.PlayArea.Text = "Welcome to the game of Up n' Down\n" +
                "The Aim of this game is to outlast your opponent\n" +
                "Rules:\n" +
                "To start the game, simply click the 'Deal' Button\n" +
                "Then you and your opponent take turns at clicking the 'Player 1 Turn' and 'Player 2 Turn' buttons\n" +
                "The program will automatically choose a card that is either 1 above or 1 below the card that was just played\n" +
                "The last person who can still play cards is the winner\n" +
                "Press 'Deal' now to start playing!" +
                "\n\n\n\n\n\n";
        }

        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            myDeck.DealDeck();    
            
            Player1Text();
            Player2Text();
            PlayArea.Text = "";

            DealButton.IsEnabled = false;
            Player1Button.IsEnabled = true;
            Player2Button.IsEnabled = false;
        }

        private void Player1Button_Click(object sender, RoutedEventArgs e)
        {
            if (PlayArea.Text == "")
            {
                myDeck.player1Hand[0].SetStatus(true);
                myDeck.deck[0].SetStatus(true);
                ValueOfLastCard = myDeck.player1Hand[0].GetValue();
                PlayArea.Text = "Last card played: " + myDeck.player1Hand[0].GetValue().ToString() + " of " + myDeck.player1Hand[0].GetSuit().ToString();
                Player1Text();
            }
            else
            {
                SetNextCardValues();

                for (int i = 0; i < myDeck.deckSize / 2; i++)
                {
                    if ((myDeck.player1Hand[i].GetValue() == NextCardTop || myDeck.player1Hand[i].GetValue() == NextCardBottom) &&
                    myDeck.player1Hand[i].GetStatus() != true)
                    {
                        myDeck.player1Hand[i].SetStatus(true);
                        myDeck.deck[i].SetStatus(true);
                        ValueOfLastCard = myDeck.player1Hand[i].GetValue();
                        PlayArea.Text = "Last card played: " + myDeck.player1Hand[i].GetValue().ToString() + " of " + myDeck.player1Hand[i].GetSuit().ToString();
                        break;
                    } else if (i == (myDeck.deckSize / 2) - 1)
                        EndGameAsync(2);                    
                }

                Player1Text();
            }

            Player1Button.IsEnabled = false;
            Player2Button.IsEnabled = true;
        }

        private void Player2Button_Click(object sender, RoutedEventArgs e)
        {
            SetNextCardValues();

            for (int i = 0; i < myDeck.deckSize / 2; i++)
            {
                if ((myDeck.player2Hand[i].GetValue() == NextCardTop || myDeck.player2Hand[i].GetValue() == NextCardBottom) &&
                myDeck.player2Hand[i].GetStatus() != true)
                {
                    myDeck.player2Hand[i].SetStatus(true);
                    myDeck.deck[i].SetStatus(true);
                    ValueOfLastCard = myDeck.player2Hand[i].GetValue();
                    PlayArea.Text = "Last card played: " + myDeck.player2Hand[i].GetValue().ToString() + " of " + myDeck.player2Hand[i].GetSuit().ToString();
                    break;
                } else if (i == (myDeck.deckSize / 2) - 1)
                    EndGameAsync(1);                
            }

            Player2Text();

            Player1Button.IsEnabled = true;
            Player2Button.IsEnabled = false;
        }

        private void Player1Text()
        {
            Player1HandBox.Text = "";
            for (int i = 0; i < myDeck.deckSize / 2; i++)
                if (myDeck.player1Hand[i].GetStatus() != true)
                    this.Player1HandBox.Text += myDeck.player1Hand[i].GetValue().ToString() + " of " + myDeck.player1Hand[i].GetSuit().ToString() + "\n";
        }

        private void Player2Text()
        {
            Player2HandBox.Text = "";
            for (int i = 0; i < myDeck.deckSize / 2; i++)
                if (myDeck.player2Hand[i].GetStatus() != true)
                    this.Player2HandBox.Text += myDeck.player2Hand[i].GetValue().ToString() + " of " + myDeck.player2Hand[i].GetSuit().ToString() + "\n";
        }

        private void SetNextCardValues()
        {           
            NextCardTop = ValueOfLastCard + 1;
            NextCardBottom = ValueOfLastCard - 1;
            if (NextCardTop == 14)
                NextCardTop = 1;
            if (NextCardBottom == 0)
                NextCardBottom = 13;
        }

        private async void EndGameAsync(int p)
        {
            PlayArea.Text = "Game over";
            var dialog = new MessageDialog("Player " + p + " Wins!\nPress 'Close' to exit the application");
            await dialog.ShowAsync();
            Application.Current.Exit();
        }
    }
}
