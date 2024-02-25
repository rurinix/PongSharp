using System;
using System.Drawing;

namespace Pong
{
	/// <summary>
	/// Summary description for PongTool.
	/// </summary>
	public class PongTool
	{
		int top;
		int bottom;
		int middle;
		int left;
		int right;
		int width;
		int height;

		Image image;


		public PongTool()
		{
			top = 0;
			bottom = 0;
			middle = 0;
			left = 0;
			right = 0;
		}

		
		public PongTool (int x, int y, int wide, int high, Image i)
		{
			top = y;
			left = x;
			width = wide;
			height = high;
			setBottom();
			setRight();
			setMiddle();

			image = i;

		}

			
		public int getWidth()
		{
			return width;
		}

		public int getHeight()
		{
			return height;
		}

		public int getTop()
		{
			return top;
		}

		public int getBottom()
		{
			setBottom();
			return bottom;
		}
		
		public int getLeft ()
		{
			return left;
		}

		public int getRight ()
		{
			right = left + width;
			return right;
		}

		public int getMiddle ()
		{
			setMiddle();
			return middle;
		}

		public Image getImage ()
		{
			return image;
		}

		public void setImage (Image i)
		{
			image = i;
		}

		public void setTop (int i)
		{
			top = i;
			setBottom();
			setMiddle();
		}

		public void setLeft (int i)
		{
			left = i;
			setRight();
		}

		public void setBottom ()
		{
			bottom = top + height;
		}

		public void setRight ()
		{
			right = left + width;
		}

		public void setMiddle ()
		{
			middle = top + (height / 2);
		}

		public void setWidth(int i)
		{
			width = i;
		}

		public void setHeight (int i)
		{
			height = i;
		}
	}
}
