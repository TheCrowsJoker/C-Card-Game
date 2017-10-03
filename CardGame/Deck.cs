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
        Card[] deck = new Card[sizeOfDeck];

        public Deck()
        {
            BuildDeck();
        }

        public void BuildDeck()
        {
            for (int i = 0; i < sizeOfDeck; i++)
            {
                if (i < sizeOfDeck / 4)
                    deck[i] = new Card(i, i, 's');
                else if (i < sizeOfDeck / 2)
                    deck[i] = new Card(i, i - (sizeOfDeck / 4), 'h');
                else if (i < (sizeOfDeck / 2) + (sizeOfDeck / 4))
                    deck[i] = new Card(i, i - (sizeOfDeck / 2), 'c');
                else
                    deck[i] = new Card(i, i - ((sizeOfDeck / 4) + (sizeOfDeck / 2)), 'd');
            }
        }
    }
}
