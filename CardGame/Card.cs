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
        bool status; // true or false (used or not used)

        public Card(int i, int v, char c) {
            id = i;
            value = v;
            suit = c;
            status = false;
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

        public bool GetStatus()
        {
            return status;
        }

        public void SetStatus(bool s)
        {
            status = s;
        }
    }
}
