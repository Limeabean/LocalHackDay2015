using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace Pong
{
	public class Paddle
	{
		int x, y, player, lives=3, length=100, width=10;

		public Paddle(int newPlayer)
		{
            player = newPlayer;

			if (player == 1) 
			{
				x = 20;
				y = 300;
			} 
			else if (player == 2)
			{
				x = 570;
				y = 300;
			} 
			else if (player == 3)
			{
				x = 300;
				y = 20;
			} 
			else if (player == 4)
			{
				x = 300;
				y = 570;
			}
		}

		public void move(KeyboardState state)
		{
			if (player == 1)
			{
				if (state.IsKeyDown(Keys.Up))
				{
					y -= 10;
				}
				if (state.IsKeyDown(Keys.Down))
				{
					y += 10;
				}
			}
			if (player == 2)
			{
				if (state.IsKeyDown(Keys.O))
				{
					y -= 10;
				}
				if (state.IsKeyDown(Keys.L))
				{
					y += 10;
				}
			}
			if (player == 3)
			{
				if (state.IsKeyDown(Keys.S))
				{
					x += 10;
				}
				if (state.IsKeyDown(Keys.A))
				{
					x -= 10;
				}
			}
			if (player == 4)
			{
				if (state.IsKeyDown(Keys.V))
				{
					x += 10;
				}
				if (state.IsKeyDown(Keys.C))
				{
					x -= 10;
				}
			}
		}

		// Get methods
		public int getX()
		{
			return x;
		}
		public int getY()
		{
			return y;
		}
		public int getWidth()
		{
			return width;
		}
		public int getHeight()
		{
            return length ;
		}
		public int getPlayer()
		{
			return player;
		}
	}
}