using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Card
    {
        int id;    // 0 ... 51
        int value; // 1 ... 13
        char suit; // s, h, c, d

        public Card(int i, int v, char c) {
            id = i;
            value = v;
            suit = c;
        }

        public char getSuit()
        {
            return suit;
        }

        public int getValue()
        {
            return value;
        }
    }
}
