using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BallBrickBreaker
{
    class Balls
    {
        public float x, y, size;
        public float xStep, yStep;

        public Balls(int _x, int _y, int _size, float _xStep, float _yStep)
        {
            x = _x;
            y = _y;
            size = _size;
            xStep = _xStep;
            yStep = _yStep;
        }

        public void Move()
        {
            x += xStep;
            y += yStep;
            
        }

        public void Collision(Form f)
        {
            if (x < 0 || x > f.Width - size * 2)
            {
                xStep *= -1;
            }

            if (y < 0 )
            {

                yStep *= -1;
            }
        }
    }
}
