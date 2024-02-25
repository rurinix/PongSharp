using System;
using System.Drawing;

namespace Pong
{
	/// <summary>
	/// Summary description for Ball.
	/// </summary>
	public class Ball : PongTool
	{
		
		private int changeX;
		private int changeY;
		int bounces;

		Random random;

		public Ball()
		{
			setTop(0);
			setBottom();
			setMiddle();
			setLeft(0);
			setRight();

			bounces = 0;
			changeX = -1;
			changeY = 1;

			random = new Random();
		}

		public Ball (int x, int y, int wide, int high, Image i)
		{
			setTop(y);
			setLeft(x);
			setWidth(wide);
			setHeight(high);
			setBottom();
			setRight();
			setMiddle();

			setImage(i);

			bounces = 0;
			changeX = -1;
			changeY = 1;

			random = new Random();
		}

		public Ball (int x, int y, int wide, int high, int incX, int incY, Image i)
		{
			setTop(y);
			setLeft(x);
			setWidth(wide);
			setHeight(high);
			setBottom();
			setRight();
			setMiddle();

			setImage(i);

			bounces = 0;
			changeX = incX;
			changeY = incY;

			random = new Random();
		}

		public int getChangeX ()
		{
			return changeX;
		}

		public int getChangeY ()
		{
			return changeY;
		}

		public int getBounceCount ()
		{
			return bounces;
		}
		public void setChangeX (int i)
		{
			changeX = i;
		}

		public void setChangeY (int i)
		{
			changeY = i;
		}

		public void setBounceCount (int i)
		{
			bounces = i;
		}

		public void bounceRight(int cap)
		{
			
			if (bounces < cap * 2)
				setChangeY( getChangeY() + random.Next(0, bounces));
			else
				setChangeY(getChangeY() + random.Next(0, cap*2));
			if (getChangeX() < 0)
				setChangeX( getChangeX() * -1);

			if (getChangeX() + cap >= cap * 4)
				setChangeX(cap * 4);
			else
				setChangeX(getChangeX() + cap);

			bounces++;
		}

		public void bounceLeft (int cap)
		{
			
			if (bounces < cap * 2)
				setChangeY( getChangeY() + random.Next(0, bounces));
			else
				setChangeY( getChangeY() + random.Next(0, cap *2));

			if (getChangeX() > 0)
				setChangeX(getChangeX() * -1);
			
			if (getChangeX() - cap <= cap * (-4))
				setChangeX(cap * (-4));
			else 
				setChangeX(getChangeX() - cap);
			
			bounces++;
		}

		public void bounceUp (int cap)
		{
			if (getChangeY() > 0)
				setChangeY(getChangeY() * -1);
			if (getChangeY() < cap * (-5))
				setChangeY(cap * (-5));

			bounces ++;
		}

		public void bounceUp (int cap, int m)
		{
			setChangeY(getChangeY() * m);
			bounceUp(cap);

			
		}

		public void bounceDown (int cap)
		{
			if (getChangeY() < 0)
				setChangeY(getChangeY() * -1);
			if (getChangeY() > cap * 5)
				setChangeY(cap * 5);

			bounces++;
		}

		public void bounceDown (int cap, int m)
		{
			setChangeY(getChangeY() * -m);
			bounceDown(cap);			
		}


		

	}
}
