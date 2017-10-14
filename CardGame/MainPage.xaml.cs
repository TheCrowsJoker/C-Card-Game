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
            
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            this.playArea.Text = "";
            for (int i = 0; i < myDeck.deckSize; i++)
            {
                this.playArea.Text += myDeck.deck[i].GetValue().ToString() + " of " + myDeck.deck[i].GetSuit().ToString() + "\n";
            }
        }

        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            myDeck.DealDeck();

            this.Player1HandBox.Text = "";
            this.Player2HandBox.Text = "";

            for (int i = 0; i < myDeck.deckSize / 2; i++)
            {
                this.playArea.Text = "";
                this.Player1HandBox.Text += myDeck.player1Hand[i].GetValue().ToString() + " of " + myDeck.player1Hand[i].GetSuit().ToString() + "\n";
                this.Player2HandBox.Text += myDeck.player2Hand[i].GetValue().ToString() + " of " + myDeck.player2Hand[i].GetSuit().ToString() + "\n";
            }
        }
    }
}
