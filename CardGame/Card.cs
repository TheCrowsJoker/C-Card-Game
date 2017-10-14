using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Card
    {
        int id; // 0 ... 51
        int value; // 1 ... 13
        char suit; // s, h, c, d

        public Card(int i, int v, char c) {
            id = i;
            value = v;
            suit = c;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int i)
        {
            id = i;
        }

        public char GetSuit()
        {
            return suit;
        }

        public void SetSuit(char s)
        {
            suit = s;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int v)
        {
            value = v;
        }
    }
}
