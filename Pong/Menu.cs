using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Pong
{
    class Menu
    {
        
        //method
        public int getSelection(int X, int Y, bool pressed)
        {
            if (180 < X && X < 430 && 284 < Y && Y < 358 && pressed)
            {
                return 1;
            }
            if (180 < X && X < 430 && 406 < Y && Y < 479 && pressed)
            {
                return 2;
            }
            return 0;
        }
    }
}
