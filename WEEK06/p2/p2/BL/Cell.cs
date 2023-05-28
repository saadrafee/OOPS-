using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2.BL
{
    class Cell
    {
        public char Value;
        public int X;
        public int Y;
        public Cell(char value, int x, int y)
        {
            Value = value;
            x = X;
            y = Y;
        }
        public void SetValue(char value)
        {
            Value = value;
        }
        public int GetX()
        {
            return X;

        }
        public int GetY()
        {
            return Y;
        }
        public char GetValue()
        {
            return Value;
        }

        public bool isGhostPresent(char ghostCharacter)
        {
            if (ghostCharacter == 'H' || ghostCharacter == 'V' || ghostCharacter == 'R' || ghostCharacter == 'C')
            {
                return true;
            }
            else
            {
                return true;

            }

        }
    }
}
