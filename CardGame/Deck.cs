using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck
    {
        static int sizeOfDeck = 52;
        public int deckSize = sizeOfDeck; // Used to allow for loops in other files to work more dynamically
        public Card[] deck = new Card[sizeOfDeck];
        public Card[] player1Hand = new Card[sizeOfDeck / 2];
        public Card[] player2Hand = new Card[sizeOfDeck / 2];

        

        public Deck()
        {
            BuildDeck();
        }

        public void BuildDeck()
        {
            int value;
            for (int i = 0; i < sizeOfDeck; i++)
            {
                value = i + 1;
                if (i < sizeOfDeck / 4)
                    deck[i] = new Card(i, value, 's');
                else if (i < sizeOfDeck / 2)
                    deck[i] = new Card(i, value - (sizeOfDeck / 4), 'h');
                else if (i < (sizeOfDeck / 2) + (sizeOfDeck / 4))
                    deck[i] = new Card(i, value - (sizeOfDeck / 2), 'c');
                else
                    deck[i] = new Card(i, value - ((sizeOfDeck / 4) + (sizeOfDeck / 2)), 'd');
            }
        }

        public void ShuffleDeck()
        {

        }

        public void DealDeck()
        {
            ShuffleDeck();

            // Player 1 hand
            for (int i = 0; i < sizeOfDeck / 2; i++)
            {
                player1Hand[i] = new Card(deck[i].GetId(), deck[i].GetValue(), deck[i].GetSuit());
            }

            // Player 2 hand
            for (int i = 0; i < sizeOfDeck / 2; i++)
            {
                player2Hand[i] = new Card(deck[i + (sizeOfDeck / 2)].GetId(), deck[i + (sizeOfDeck / 2)].GetValue(), deck[i + (sizeOfDeck / 2)].GetSuit());
            }
        }
    }
}
