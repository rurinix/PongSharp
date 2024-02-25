using System;
using System.Drawing;

namespace Pong
{
	/// <summary>
	/// Summary description for Player.
	/// </summary>
	public class Player : PongTool
	{
		
		int score;
		int scoreX;
		int scoreY;

		public bool inZone;

		public Player()
		{
			setTop(0);
			setBottom();
			setMiddle();
			setLeft(0);
			setRight();
			setScore (0);
			scoreX = 0;
			scoreY = 0;
			inZone = false;
		}

		
		public Player (int x, int y, int wide, int high, Image i)
		{
			setTop(y);
			setLeft(x);
			setWidth(wide);
			setHeight(high);
			setBottom();
			setRight();
			setMiddle();

			setImage(i);

			setScore(0);

			scoreX = 0;
			scoreY = 0;
			inZone = false;

		}

		public Player (int x, int y, int wide, int high, int sX, int sY, Image i)
		{
			setTop(y);
			setLeft(x);
			setWidth(wide);
			setHeight(high);
			setBottom();
			setRight();
			setMiddle();

			scoreX = sX;
			scoreY = sY;

			setImage(i);

			setScore(0);
			inZone = false;

		}

		public int getScore ()
		{
			return score;
		}

		public void setScore (int i)
		{
			score = i;
		}


	}
}
