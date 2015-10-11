using System;

namespace Pong
{
    public class Ball
    {
        private int ballx;
        private int bally;
        private int ballh;
        private int ballw;
        private int dx;
        private int dy;
        public Ball(int ballx, int bally, int ballh, int ballw, int dx, int dy)
        {
            this.ballx = ballx;
            this.bally = bally;
            this.ballh = ballh;
            this.ballw = ballw;
            this.dx = dx;
            this.dy = dy;
        }

        public int getx()
        {
            return ballx;
        }
        public int gety()
        {
            return bally;
        }
        public int getw()
        {
            return ballw;
        }
        public int geth()
        {
            return ballh;
        }
        private int getdx()
        {
            return dx;
        }
        private int getdy()
        {
            return dy;
        }
        public bool offscreen()
        {
            if (ballx>600 || ballx+ballw<0 || bally+ballh<0 || bally > 600)
            {
                return true;
            }
            return false;
        }
        public void move(Paddle pad1, Paddle pad2, Paddle pad3, Paddle pad4)
        {
            ballx += dx;
            bally += dy;
            collision(pad1);
            collision(pad2);
            collision(pad3);
            collision(pad4);
        }
        public int randomneg()
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 3);
            if (chance == 1)
            {
                return -1;
                System.Console.WriteLine("1");
            }
            else
            {
                return 1;
                System.Console.WriteLine("-1");
            }
            
        }
        public void reset(int windoww, int windowh)
        {
            Random rnd = new Random();
            ballx = windoww / 2 - ballw / 2;
            bally = windowh / 2 - ballh / 2;
            dx = rnd.Next(5, 10) * randomneg();
            dy = rnd.Next(5, 10) * randomneg();
        }
        public void collision(Paddle pad)
        { //checks if a bullet has collided with another bullet
            int padx = pad.getX();
            int pady = pad.getY();
            int padw = pad.getWidth();
            int padh = pad.getHeight();
            // Console.WriteLine(padx + " " + pady + " " + ballx + " " + bally + " " + (padx <= ballx) + " " + (ballx <= padx + padw) + " " + (pady <= bally) + " " + (bally <= pady + padh));
            var bx = ballx + ballw / 2f;
            var by = bally + ballh / 2f;
            if (padx <= bx && bx <= padx + padw && pady <= by && by <= pady + padh)
            {
                dx *= -1;
                dy *= -1;
                /*if (pad.getPlayer() == 1)
                {
                    dx *= -1;
                    dy *= randomneg();
                }
                if (pad.getPlayer() == 2)
                {
                    dx *= -1;
                    dy *= randomneg();
                }
                if (pad.getPlayer() == 3)
                {
                    dx *= randomneg();
                    dy *= -1;
                }
                if (pad.getPlayer() == 4)
                {
                    dx *= randomneg();
                    dy *= -1;
                }*/
    

               
                //dx += 1;
                //dy += 1; */
            }
        }
    }
}