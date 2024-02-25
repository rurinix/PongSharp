using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
	/// <summary>
	/// Summary description for AboutForm.
	/// </summary>
	public class AboutForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer aboutTimer;
		private System.ComponentModel.IContainer components;

		Ball ball;

		private System.Windows.Forms.Timer delayTimer;

		Random random;

		public AboutForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			random = new Random();

			ball = new Ball (random.Next(this.ClientSize.Width), random.Next(this.ClientSize.Height), 24, 24, Image.FromFile("images\\Ball.gif"));

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public AboutForm(Point p)
		{
			InitializeComponent ();
			p.X -= this.ClientSize.Width/2;
			p.Y -= this.ClientSize.Height/2;
			this.Location = p;
			
			ball = new Ball (25, 25, 24, 24, -2, 2, Image.FromFile("images\\Ball.gif"));
			random = new Random();

			//Enable double buffering
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer,true);			
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutForm));
			this.aboutTimer = new System.Windows.Forms.Timer(this.components);
			this.delayTimer = new System.Windows.Forms.Timer(this.components);
			// 
			// aboutTimer
			// 
			this.aboutTimer.Interval = 30;
			this.aboutTimer.Tick += new System.EventHandler(this.aboutTimer_Tick);
			// 
			// delayTimer
			// 
			this.delayTimer.Enabled = true;
			this.delayTimer.Interval = 2000;
			this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(194, 218);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "About Pong!#";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.AboutForm_Load);

		}
		#endregion

		protected override void OnPaint (PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (ball.getBounceCount() % 2 == 1)
				drawInfo(g);

			g.DrawImage(ball.getImage(), ball.getLeft(), ball.getTop());

			if (ball.getBounceCount() % 2 == 0)
				drawInfo(g);
		}

		private void aboutTimer_Tick(object sender, System.EventArgs e)
		{
				ball.setLeft(ball.getLeft() + ball.getChangeX());
				ball.setTop(ball.getTop() + ball.getChangeY());
			
			aboutBounce();

			Invalidate();
		}

		private void aboutBounce()
		{
			//check walls

			// bounce off ceiling
			if (ball.getTop() <= 0)
			{
				ball.setTop(0);
				ball.bounceDown(2);
			}
			
				// bounce off floor
			else if (ball.getBottom() >= this.ClientSize.Height)
			{
				ball.setTop(this.ClientSize.Height - ball.getHeight());
				ball.bounceUp(2);
			}
			
				// bounces off left side
			else if (ball.getLeft() <= 0)
			{
				ball.setLeft(0);
				ball.bounceRight(1);
			}
				// bounces off right side
			else if (ball.getRight() >= this.ClientSize.Width)
			{
				ball.setLeft(this.ClientSize.Width - ball.getWidth());
				ball.bounceLeft(1);
			}
		}


		private void delayTimer_Tick(object sender, System.EventArgs e)
		{
			if (!aboutTimer.Enabled)
			{
				aboutTimer.Enabled = true;
				delayTimer.Enabled = false;
			}
		}

		private void drawInfo (Graphics g)
		{
			Font titleFont = new Font ("Arial Rounded MT Bold", 24, FontStyle.Bold);
			Font sharpFont = new Font ("Arial", 24, FontStyle.Italic);
			Font aboutFont = new Font ("Arial", 10, FontStyle.Regular);
			Font aboutBold = new Font ("Arial", 10, FontStyle.Bold);

			g.DrawString("Pong!", titleFont, Brushes.White , 62, 0);
			g.DrawString("#", sharpFont, Brushes.White, 160, -2);
			g.DrawString("#", sharpFont, Brushes.Blue, 161, -1);
			g.DrawString("By Michael Reeves", aboutFont, Brushes.WhiteSmoke, 68, 38);
			g.DrawString("Version 1.1", aboutFont, Brushes.Gray, this.ClientSize.Width - 93, 54);
			g.DrawLine(Pens.Silver, 5,72, this.ClientSize.Width - 5, 72);
			g.DrawString("A tribute to the \"original video \ngame\" by Alan Alcorn", aboutFont, Brushes.WhiteSmoke, 5, 78);
			g.DrawLine(Pens.Silver, 5, 117, this.ClientSize.Width - 5, 117);
			g.DrawLine(Pens.Silver, 25, 122, this.ClientSize.Width - 25, 122);
			g.DrawLine(Pens.Silver, 5, 127, this.ClientSize.Width - 5, 127);
			g.DrawString("This program is open-source \nand freely distributed at: ", aboutFont, Brushes.WhiteSmoke, 5,132);
			g.DrawString("http://reeves.whitacres.net/", aboutBold, Brushes.DarkGray, 5, 163);
			g.DrawString("http://reeves.whitacres.net/", aboutBold, Brushes.Blue, 6, 162);
			g.DrawString("Copyright 2008", aboutFont, Brushes.Gray, this.ClientSize.Width-93, this.ClientSize.Height-20);
		}

		private void AboutForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
