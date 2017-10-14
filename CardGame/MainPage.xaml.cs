using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        public MainPage()
        {
            this.InitializeComponent();
            Player1Button.IsEnabled = false;
            Player2Button.IsEnabled = false;
        }

        private void PlayArea_Loaded(object sender, RoutedEventArgs e)
        {
            this.PlayArea.Text = "";
            for (int i = 0; i < myDeck.deckSize; i++)
            {
                this.PlayArea.Text += myDeck.deck[i].GetValue().ToString() + " of " + myDeck.deck[i].GetSuit().ToString() + "\n";
            }
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
            } else
            {

            }

            PlayAreaText();
            Player1Text();

            Player1Button.IsEnabled = false;
            Player2Button.IsEnabled = true;
        }

        private void Player2Button_Click(object sender, RoutedEventArgs e)
        {
            Player1Button.IsEnabled = true;
            Player2Button.IsEnabled = false;
        }

        private void PlayAreaText()
        {
            PlayArea.Text = "";
            for (int i = 0; i < myDeck.deckSize; i++)
                if (myDeck.deck[i].GetStatus() == true)
                    this.PlayArea.Text += myDeck.deck[i].GetValue().ToString() + " of " + myDeck.deck[i].GetSuit().ToString() + "\n";
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
    }
}
