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
        public Card[] deck = new Card[sizeOfDeck];

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
    }
}
