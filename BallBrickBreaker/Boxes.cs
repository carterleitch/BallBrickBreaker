using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBrickBreaker
{
    class Boxes
    {
        public float x2, y2, size2;

        public Boxes(int _x2, int _y2, int _size2)
        {
            x2 = _x2;
            y2 = _y2;
            size2 = _size2;
        }

        public void BoxShift()
        {
            y2++;
        }
    }
}
