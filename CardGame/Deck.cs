using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck
    {
        Card[] deck;

        public Deck()
        {

        }

        public void BuildDeck()
        {
            
            for (int i = 0; i < 52; i++)
            {
                Card test = new Card(i, i, 'a');
            }
        }

    }
}
