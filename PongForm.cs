using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace Pong
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PongForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		
		Random rand;

		Player P1;
		Player P2;
		Ball theBall;

		int difficulty;
		int maxScore;
		int redLevel;

        bool gameOver;
		bool newGame;
		bool roundStarted;
		

		String winner;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Timer ballTimer;
		private System.Windows.Forms.MenuItem mExit;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mNewGame;
		private System.Windows.Forms.MenuItem mOptions;
		private System.Windows.Forms.MenuItem mEasy;
		private System.Windows.Forms.MenuItem mMedium;
		private System.Windows.Forms.MenuItem mHard;
		private System.Windows.Forms.MenuItem mHelp;
		private System.Windows.Forms.MenuItem mImpossible;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem mClassicNet;
		private System.Windows.Forms.MenuItem mCheckeredNet;
		private System.Windows.Forms.MenuItem mDifficulty;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mNoNet;
		private System.Windows.Forms.MenuItem mMaxScore;
		private System.Windows.Forms.MenuItem m3;
		private System.Windows.Forms.MenuItem m5;
		private System.Windows.Forms.MenuItem m7;
		private System.Windows.Forms.MenuItem mMeshNet;
		private System.Windows.Forms.MenuItem mImpactFlash;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mPlaySound;
		private System.Windows.Forms.MenuItem mGraphics;
		private System.Windows.Forms.MenuItem mUpdatedGraphics;
		private System.Windows.Forms.MenuItem mShadedGraphics;
		private System.Windows.Forms.MenuItem mClassicGraphics;
		private System.Windows.Forms.MenuItem mPaddleSize;
		private System.Windows.Forms.MenuItem mNormalPaddle;
		private System.Windows.Forms.MenuItem mClassicPaddle;
		private System.Windows.Forms.MenuItem mAutoPause;
		private System.Windows.Forms.MenuItem mAbout;

		// Incorperate external functions to play sounds (relies on winmm.dll)
		
	
		[DllImport("winmm.dll")]
		private static extern bool PlaySound(string szSound, int hModule, long dwFlags);
		
		public PongForm()
		{
			// use custom cursor
			try
			{
				this.Cursor = new Cursor("images\\Blank.cur");
			}
			catch (DirectoryNotFoundException e22)
			{
				MessageBox.Show("\"Images\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			catch (FileNotFoundException e22)
			{
				MessageBox.Show("Cursor file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			catch (Exception e22)
			{
				MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}

			

			//force window size
			this.Size = new Size(600, 600);
			this.MaximizeBox = false;
			this.MaximumSize = new Size(600, 600);
			this.MinimumSize = new Size(600, 600);

			InitializeComponent();
			
			// initialize variables
			rand = new Random();
			gameOver = false;
			newGame = true;
			winner = "";
			redLevel = 0;
			// Create objects
			try
			{
				P1 = new Player(25, 267, 24, 48, 10, 0, Image.FromFile("images\\Paddle.gif"));
				P2 = new Player(this.ClientSize.Width - (24 + 25), 248, 24, 48, 566, 0, Image.FromFile("images\\Paddle.gif"));
				theBall = new Ball (283, 260, 24, 24, Image.FromFile("images\\Ball.gif"));
			}
			catch (DirectoryNotFoundException e1)
			{
				MessageBox.Show("\"Images\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			catch (FileNotFoundException e1)
			{
				MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			catch (Exception e1)
			{
				MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}

			
			//Enable double buffering
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer,true);			

			// play blank sound to prevent delay on initial sound file
			PlaySound(null,0,0x0001);

			// Initialize all variables to default settings for new game

			startAgain();
			
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary> 
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/* <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/   </summary> */
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PongForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mNewGame = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mExit = new System.Windows.Forms.MenuItem();
			this.mOptions = new System.Windows.Forms.MenuItem();
			this.mGraphics = new System.Windows.Forms.MenuItem();
			this.mUpdatedGraphics = new System.Windows.Forms.MenuItem();
			this.mShadedGraphics = new System.Windows.Forms.MenuItem();
			this.mClassicGraphics = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mNoNet = new System.Windows.Forms.MenuItem();
			this.mMeshNet = new System.Windows.Forms.MenuItem();
			this.mCheckeredNet = new System.Windows.Forms.MenuItem();
			this.mClassicNet = new System.Windows.Forms.MenuItem();
			this.mPaddleSize = new System.Windows.Forms.MenuItem();
			this.mNormalPaddle = new System.Windows.Forms.MenuItem();
			this.mClassicPaddle = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.mImpactFlash = new System.Windows.Forms.MenuItem();
			this.mPlaySound = new System.Windows.Forms.MenuItem();
			this.mAutoPause = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mDifficulty = new System.Windows.Forms.MenuItem();
			this.mEasy = new System.Windows.Forms.MenuItem();
			this.mMedium = new System.Windows.Forms.MenuItem();
			this.mHard = new System.Windows.Forms.MenuItem();
			this.mImpossible = new System.Windows.Forms.MenuItem();
			this.mMaxScore = new System.Windows.Forms.MenuItem();
			this.m3 = new System.Windows.Forms.MenuItem();
			this.m5 = new System.Windows.Forms.MenuItem();
			this.m7 = new System.Windows.Forms.MenuItem();
			this.mHelp = new System.Windows.Forms.MenuItem();
			this.mAbout = new System.Windows.Forms.MenuItem();
			this.ballTimer = new System.Windows.Forms.Timer(this.components);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.mOptions,
																					  this.mHelp});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mNewGame,
																					  this.menuItem3,
																					  this.mExit});
			this.menuItem1.Text = "File";
			// 
			// mNewGame
			// 
			this.mNewGame.Index = 0;
			this.mNewGame.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.mNewGame.Text = "New Game";
			this.mNewGame.Click += new System.EventHandler(this.mNewGame_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// mExit
			// 
			this.mExit.Index = 2;
			this.mExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.mExit.Text = "Exit";
			this.mExit.Click += new System.EventHandler(this.mExit_Click);
			// 
			// mOptions
			// 
			this.mOptions.Index = 1;
			this.mOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mGraphics,
																					 this.menuItem4,
																					 this.mPaddleSize,
																					 this.menuItem5,
																					 this.mImpactFlash,
																					 this.mPlaySound,
																					 this.mAutoPause,
																					 this.menuItem2,
																					 this.mDifficulty,
																					 this.mMaxScore});
			this.mOptions.Text = "Options";
			// 
			// mGraphics
			// 
			this.mGraphics.Index = 0;
			this.mGraphics.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mUpdatedGraphics,
																					  this.mShadedGraphics,
																					  this.mClassicGraphics});
			this.mGraphics.Text = "Graphics Style";
			// 
			// mUpdatedGraphics
			// 
			this.mUpdatedGraphics.Checked = true;
			this.mUpdatedGraphics.Index = 0;
			this.mUpdatedGraphics.Text = "Updated Graphics";
			this.mUpdatedGraphics.Click += new System.EventHandler(this.mUpdatedGraphics_Click);
			// 
			// mShadedGraphics
			// 
			this.mShadedGraphics.Index = 1;
			this.mShadedGraphics.Text = "Shaded Graphics";
			this.mShadedGraphics.Click += new System.EventHandler(this.mShadedGraphics_Click);
			// 
			// mClassicGraphics
			// 
			this.mClassicGraphics.Index = 2;
			this.mClassicGraphics.Text = "Classic Graphics";
			this.mClassicGraphics.Click += new System.EventHandler(this.mClassicGraphics_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mNoNet,
																					  this.mMeshNet,
																					  this.mCheckeredNet,
																					  this.mClassicNet});
			this.menuItem4.Text = "Net Type";
			// 
			// mNoNet
			// 
			this.mNoNet.Checked = true;
			this.mNoNet.Index = 0;
			this.mNoNet.Text = "No Net";
			this.mNoNet.Click += new System.EventHandler(this.mNoNet_Click);
			// 
			// mMeshNet
			// 
			this.mMeshNet.Index = 1;
			this.mMeshNet.Text = "Mesh Net";
			this.mMeshNet.Click += new System.EventHandler(this.mMeshNet_Click);
			// 
			// mCheckeredNet
			// 
			this.mCheckeredNet.Index = 2;
			this.mCheckeredNet.Text = "Checkered Net";
			this.mCheckeredNet.Click += new System.EventHandler(this.mCheckeredNet_Click);
			// 
			// mClassicNet
			// 
			this.mClassicNet.Index = 3;
			this.mClassicNet.Text = "Use Classic Net";
			this.mClassicNet.Click += new System.EventHandler(this.mClassicNet_Click);
			// 
			// mPaddleSize
			// 
			this.mPaddleSize.Index = 2;
			this.mPaddleSize.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mNormalPaddle,
																						this.mClassicPaddle});
			this.mPaddleSize.Text = "Paddle Size";
			// 
			// mNormalPaddle
			// 
			this.mNormalPaddle.Checked = true;
			this.mNormalPaddle.Index = 0;
			this.mNormalPaddle.Text = "Pong Sharp";
			this.mNormalPaddle.Click += new System.EventHandler(this.mNormalPaddle_Click);
			// 
			// mClassicPaddle
			// 
			this.mClassicPaddle.Index = 1;
			this.mClassicPaddle.Text = "Classic";
			this.mClassicPaddle.Click += new System.EventHandler(this.mClassicPaddle_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// mImpactFlash
			// 
			this.mImpactFlash.Checked = true;
			this.mImpactFlash.Index = 4;
			this.mImpactFlash.Text = "Impact Flash";
			this.mImpactFlash.Click += new System.EventHandler(this.mImpactFlash_Click);
			// 
			// mPlaySound
			// 
			this.mPlaySound.Checked = true;
			this.mPlaySound.Index = 5;
			this.mPlaySound.Text = "Play Sound";
			this.mPlaySound.Click += new System.EventHandler(this.mPlaySound_Click);
			// 
			// mAutoPause
			// 
			this.mAutoPause.Checked = true;
			this.mAutoPause.Index = 6;
			this.mAutoPause.Text = "Offscreen AutoPause";
			this.mAutoPause.Click += new System.EventHandler(this.mAutoPause_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 7;
			this.menuItem2.Text = "-";
			// 
			// mDifficulty
			// 
			this.mDifficulty.Index = 8;
			this.mDifficulty.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mEasy,
																						this.mMedium,
																						this.mHard,
																						this.mImpossible});
			this.mDifficulty.Text = "Difficulty";
			// 
			// mEasy
			// 
			this.mEasy.Index = 0;
			this.mEasy.Text = "Easy";
			this.mEasy.Click += new System.EventHandler(this.mEasy_Click);
			// 
			// mMedium
			// 
			this.mMedium.Checked = true;
			this.mMedium.Index = 1;
			this.mMedium.Text = "Medium";
			this.mMedium.Click += new System.EventHandler(this.mMedium_Click);
			// 
			// mHard
			// 
			this.mHard.Index = 2;
			this.mHard.Text = "Hard";
			this.mHard.Click += new System.EventHandler(this.mHard_Click);
			// 
			// mImpossible
			// 
			this.mImpossible.Index = 3;
			this.mImpossible.Text = "Impossible";
			this.mImpossible.Click += new System.EventHandler(this.mImpossible_Click);
			// 
			// mMaxScore
			// 
			this.mMaxScore.Index = 9;
			this.mMaxScore.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m3,
																					  this.m5,
																					  this.m7});
			this.mMaxScore.Text = "Winning Score";
			// 
			// m3
			// 
			this.m3.Checked = true;
			this.m3.Index = 0;
			this.m3.Text = "3";
			this.m3.Click += new System.EventHandler(this.m3_Click);
			// 
			// m5
			// 
			this.m5.Index = 1;
			this.m5.Text = "5";
			this.m5.Click += new System.EventHandler(this.m5_Click);
			// 
			// m7
			// 
			this.m7.Index = 2;
			this.m7.Text = "7";
			this.m7.Click += new System.EventHandler(this.m7_Click);
			// 
			// mHelp
			// 
			this.mHelp.Index = 2;
			this.mHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.mAbout});
			this.mHelp.Text = "Help";
			// 
			// mAbout
			// 
			this.mAbout.Index = 0;
			this.mAbout.Text = "About";
			this.mAbout.Click += new System.EventHandler(this.mAbout_Click);
			// 
			// ballTimer
			// 
			this.ballTimer.Interval = 2;
			this.ballTimer.Tick += new System.EventHandler(this.ballTimer_Tick);
			// 
			// PongForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(592, 524);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "PongForm";
			this.Text = "Pong!#";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PongForm_MouseDown);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PongForm_MouseMove);
			this.MouseEnter += new System.EventHandler(this.PongForm_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.PongForm_MouseLeave);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PongForm());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			loadSettings();
		}
		
		protected override void OnPaint (PaintEventArgs e)
		{

			Graphics g = e.Graphics;
			Font scoringFont = new Font ("Courier New", 14, FontStyle.Bold);
			Font winnerFont = new Font ("Courier New", 28, FontStyle.Bold);
					
			base.OnPaint (e); // call normal paint method

			// Draw scoring
			g.DrawString(" " + P1.getScore(), scoringFont, Brushes.Red,-2,0);
			g.DrawString(" " + P2.getScore(), scoringFont, Brushes.Red, this.ClientSize.Width - (scoringFont.SizeInPoints * 3) +4 ,0);
			// Draw net
			drawNet(g);

			// draw Paddles & Ball
			if (mUpdatedGraphics.Checked)
			{
				g.DrawImage(P1.getImage(), P1.getLeft(), P1.getTop());
				g.DrawImage(P2.getImage(), P2.getLeft(), P2.getTop());
				g.DrawImage(theBall.getImage(), theBall.getLeft(), theBall.getTop(), theBall.getWidth(), theBall.getHeight());
			}

			else if (mShadedGraphics.Checked)
			{
				int shade = 95;

				for (int count = 0; count <= P1.getWidth(); count ++)
				{
					if (count > 0)
						shade +=5 + (12/count);
					else
						shade += 5;
					g.DrawRectangle(new Pen(Color.FromArgb(shade, shade, shade), 2), P1.getLeft() + count, P1.getTop() + count, P1.getWidth() - count * 2, P1.getHeight() - count * 2);
				}

				shade = 95;
				for (int count = 0; count <= P2.getWidth() ; count ++)
				{
					if (count > 0)
						shade += 5 + (12/count);
					else
						shade += 5;
					g.DrawRectangle(new Pen(Color.FromArgb(shade, shade, shade), 2), P2.getLeft() + count, P2.getTop() + count, P2.getWidth() - count * 2, P2.getHeight() - count * 2);
				}

				shade = 255;
				for (int count = 0; count <= theBall.getWidth(); count++ )
				{

					if (count > 0)
						shade -= (count/2);

					g.DrawEllipse(new Pen(Color.FromArgb(shade,shade,shade), 2), theBall.getLeft() + count, theBall.getTop() + count, theBall.getWidth() - count * 2, theBall.getHeight() - count * 2);
				}
					//g.DrawString(Convert.ToString(shade),new Font("Arial", 36), Brushes.White, this.ClientSize.Width / 2, this.ClientSize.Height /2);

			}
			else if (mClassicGraphics.Checked)
			{
				g.FillRectangle(Brushes.LightGray, P1.getLeft(), P1.getTop(), P1.getWidth(), P1.getHeight());
				g.FillRectangle(Brushes.LightGray, P2.getLeft(), P2.getTop(), P2.getWidth(), P2.getHeight());
				g.FillEllipse(Brushes.LightGray, theBall.getLeft(), theBall.getTop(), theBall.getWidth(), theBall.getHeight());
				g.DrawEllipse(new Pen(Color.DarkGray, 1), theBall.getLeft(), theBall.getTop(), theBall.getWidth(), theBall.getHeight());
			}
			if (roundStarted && !gameOver && !ballTimer.Enabled && mAutoPause.Checked)
				g.DrawString ("Pause", winnerFont, Brushes.White, this.ClientSize.Width/2 - (4 *winnerFont.SizeInPoints/2) , 250);
			if (newGame && !ballTimer.Enabled && mNoNet.Checked)
				g.DrawString("Click Mouse To Serve", winnerFont, Brushes.White, this.ClientSize.Width/2 - 235,400);
			//if (gameOver)
				g.DrawString(winner, winnerFont, Brushes.White, this.ClientSize.Width/2 - ((winner.Length -1) * (winnerFont.SizeInPoints)/2), this.ClientSize.Height/2);


		}

		private void Checkbounce()
		{
			// bounce off ceiling
			if (theBall.getTop() <= 0)
			{
				theBall.setTop(0);
				if (mPlaySound.Checked)
				{
					PlaySound(null,0,0x0040);
					try
					{
						PlaySound("sounds\\wall.wav", 0, 0x0001);
					}
					catch (DirectoryNotFoundException e2)
					{
						MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
						Application.Exit();
					}
					catch (FileNotFoundException e2)
					{
						MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
						Application.Exit();
					}
					catch (Exception e2)
					{
						MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
						Application.Exit();
					}
					
				}
				theBall.bounceDown(difficulty);
				theBall.setBounceCount(theBall.getBounceCount() -1);
			}
			
				// bounce off floor
			else if (theBall.getBottom() >=this.ClientSize.Height)
			{
				theBall.setTop(this.ClientSize.Height - theBall.getHeight());
				if (mPlaySound.Checked)
				{
					PlaySound(null,0,0x0040);
					try
					{
						PlaySound("sounds\\wall.wav", 0, 0x0001);
					}
					catch (DirectoryNotFoundException e3)
					{
						MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
						Application.Exit();
					}
					catch (FileNotFoundException e3)
					{
						MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
						Application.Exit();
					}
					catch (Exception e3)
					{
						MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
						Application.Exit();
					}
				}
				theBall.bounceUp(difficulty);
				theBall.setBounceCount(theBall.getBounceCount() -1);
			}
			
				// bounce off P1
			else if (theBall.getLeft() <= P1.getRight() && theBall.getRight() >= P1.getLeft() && !P1.inZone)
			{ 
				P1.inZone = true;

				//bounce off side
				if (P1.getTop() < theBall.getMiddle() && P1.getBottom() > theBall.getMiddle())
				{
					P1.inZone = false;
					theBall.setLeft(P1.getRight());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\ping.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e4)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e4)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e4)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceRight(difficulty);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
					
				}

					// bounce off top
				else if (P1.getTop() < theBall.getBottom() && P1.getTop() >= theBall.getMiddle())
				{
					P1.inZone = false;
					theBall.setLeft(P1.getRight());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\ping.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e5)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e5)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e5)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceRight(difficulty);
					theBall.bounceUp(difficulty, 2);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

					//bounce off bottom
				else if ( P1.getBottom() > theBall.getTop()  && P1.getBottom() <= theBall.getMiddle())
				{ 
					
					P1.inZone = false;
					theBall.setLeft(P1.getRight());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\ping.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e6)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e6)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e6)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceRight(difficulty);
					theBall.bounceDown(difficulty, 2);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

			}

			else if (theBall.getLeft() <= P1.getRight() && theBall.getRight() >= P1.getLeft() && P1.inZone)
			{
				// bounce off top
				if (P1.getTop() < theBall.getBottom() && P1.getTop() >= theBall.getMiddle())
				{
					 
					theBall.setTop(P1.getTop() - theBall.getHeight());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\ping.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e7)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e7)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception err7)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceRight(difficulty);
					theBall.bounceUp(difficulty);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

					//bounce off top corner
				else if (P1.getTop() == theBall.getBottom() && P1.getTop() >= theBall.getMiddle())
				{
					 
					theBall.setTop(P1.getTop() - theBall.getHeight());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\ping.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e8)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e8)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e8)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceRight(difficulty);
					theBall.bounceUp(difficulty, 2);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}


					//bounce off bottom
				else if ( P1.getBottom() > theBall.getTop()  && P1.getBottom() <= theBall.getMiddle())
				{ 
					
					 
					theBall.setTop(P1.getBottom());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\ping.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e9)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e9)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e9)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					
					}
					theBall.bounceRight(difficulty);
					theBall.bounceDown(difficulty);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}
				
					//bounce off bottom corner
				else if ( P1.getBottom() == theBall.getTop()  && P1.getBottom() <= theBall.getMiddle())
				{ 
					
					 
					theBall.setTop(P1.getBottom());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\ping.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e10)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e10)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e10)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceRight(difficulty);
					theBall.bounceDown(difficulty, 2);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

			}
				// clear "inZone" flag when out of in Zone
			else if (P1.inZone)
					 P1.inZone = false;


			// bounce off P2
			else if (theBall.getRight() <= P2.getRight() && theBall.getRight() >= P2.getLeft() && !P2.inZone)
			{ 
				P2.inZone = true;

				//bounce off side
				if (P2.getTop() < theBall.getMiddle() && P2.getBottom() > theBall.getMiddle())
				{
					P2.inZone = false;
					theBall.setLeft(P2.getLeft() - theBall.getWidth());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try 
						{
							PlaySound("sounds\\pong.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e11)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e11)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e11)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceLeft(difficulty);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}					
				}

					// bounce off top
				else if (P2.getTop() < theBall.getBottom() && P2.getTop() >= theBall.getMiddle())
				{
					P2.inZone = false;
					theBall.setLeft(P2.getLeft() - theBall.getWidth());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\pong.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e12)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e12)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e12)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceLeft(difficulty);
					theBall.bounceUp(difficulty, 2);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

					//bounce off bottom
				else if ( P2.getBottom() > theBall.getTop()  && P2.getBottom() <= theBall.getMiddle())
				{ 
					
					P2.inZone = false;
					theBall.setLeft(P2.getLeft() - theBall.getWidth());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\pong.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e13)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e13)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e13)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceLeft(difficulty);
					theBall.bounceDown(difficulty, 2);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

			}

			else if (theBall.getLeft() <= P2.getRight() && theBall.getRight() >= P2.getLeft() && P2.inZone)
			{
				// bounce off top
				if (P2.getTop() < theBall.getBottom() && P2.getTop() >= theBall.getMiddle())
				{
					 
					theBall.setTop(P2.getTop() - theBall.getHeight());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try 
						{
							PlaySound("sounds\\pong.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e14)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e14)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e14)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceLeft(difficulty);
					theBall.bounceUp(difficulty);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

				//bounce off top corner
				else if (P2.getTop() == theBall.getBottom() && P2.getTop() >= theBall.getMiddle())
				{
					 
					theBall.setTop(P2.getTop() - theBall.getHeight());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\pong.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e15)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e15)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e15)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceLeft(difficulty);
					theBall.bounceUp(difficulty, 2);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}
					//bounce off bottom
				else if ( P2.getBottom() > theBall.getTop()  && P2.getBottom() <= theBall.getMiddle())
				{ 
					theBall.setTop(P2.getBottom());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try 
						{
							PlaySound("sounds\\pong.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e16)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e16)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e16)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceLeft(difficulty);
					theBall.bounceDown(difficulty);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

					// bounce off bottom corner
				else if ( P2.getBottom() == theBall.getTop()  && P2.getBottom() <= theBall.getMiddle())
				{ 
					theBall.setTop(P2.getBottom());
					if (mPlaySound.Checked)
					{
						PlaySound(null,0,0x0040);
						try
						{
							PlaySound("sounds\\pong.wav", 0, 0x0001);
						}
						catch (DirectoryNotFoundException e17)
						{
							MessageBox.Show("\"Sounds\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (FileNotFoundException e17)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
						catch (Exception e17)
						{
							MessageBox.Show("Sound file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
							Application.Exit();
						}
					}
					theBall.bounceLeft(difficulty);
					theBall.bounceDown(difficulty, 2);
					if (mImpactFlash.Checked)
					{
						redLevel = 255;
					}
				}

			}
				// clear "inZone" flag when out of in Zone
			else if (P2.inZone)
				P2.inZone = false;

				// Ball enters CPU defended goal; P1 scores
			else if (theBall.getRight() >= this.ClientSize.Width)
			{
				P2.inZone = false;
				P1.setScore(P1.getScore() +1);
				checkWinner();
			}
		
				// Ball enters P1 defended goal; CPU scores
			else if (theBall.getLeft()<=0)
			{
				P1.inZone = false;
				P2.setScore(P2.getScore() +1);
				checkWinner();
			}


		}


		private void mNewGame_Click(object sender, System.EventArgs e)
		{
			startAgain();
		}

		private void startAgain()
		{
			this.BackColor = Color.Black;
			try
			{
				this.Cursor = new Cursor("images\\Blank.cur");
			}
			catch (DirectoryNotFoundException e23)
			{
				MessageBox.Show("\"Images\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			catch (FileNotFoundException e23)
			{
				MessageBox.Show("Cursor file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			catch (Exception e23)
			{
				MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}

			gameOver = false;
			newGame = true;
			setDifficulty();
			setMaxScore();
			winner = "";
			P1.setScore(0);
			P2.setScore(0);
			startRound();
			Invalidate();
			
		}

		private void startRound()
		{
			theBall.setBounceCount(0);
			P2.setTop(this.ClientSize.Height/2 - P2.getHeight()/2);
			theBall.setLeft(this.ClientSize.Width/2 - theBall.getWidth()/2);
			theBall.setTop(this.ClientSize.Height/2 - theBall.getHeight()/2);
			theBall.setChangeX((rand.Next(difficulty,3)+1) * -1);
			theBall.setChangeY(rand.Next(3,5) * - 1);
			ballTimer.Enabled = false;
			roundStarted = false;
		
		}

		private void mExit_Click(object sender, System.EventArgs e)
		{
			saveSettings();
			Application.Exit();
		}


		private void useAI ()
		{
			int AI_Step = (difficulty * 3) + 1;
		
			if (mImpossible.Checked)
			{
				
				if(theBall.getTop() > this.ClientSize.Height - P2.getHeight())
					P2.setTop(this.ClientSize.Height - P2.getHeight());
				else if(P2.getTop() < 0)
                    P2.setTop(0);
				else
					P2.setTop(theBall.getMiddle());
			}

			else
			{
				if(theBall.getTop() < P2.getTop())
				{
					if (P2.getTop() - AI_Step <= 0)
						P2.setTop(0);
					else if (P2.getTop() - theBall.getTop() < AI_Step)
						P2.setTop(theBall.getTop());
					else
						P2.setTop(P2.getTop() - AI_Step);
				}

				else if (theBall.getTop() > P2.getBottom())
				{
					if (P2.getBottom() + AI_Step >= this.ClientSize.Height)
						P2.setTop(this.ClientSize.Height - P2.getHeight());
					else if (theBall.getTop() - P2.getBottom() < AI_Step)
						P2.setTop(theBall.getTop() - P2.getHeight());
					else
						P2.setTop(P2.getTop() + AI_Step);
				}
			}
				
			
		}


		public void checkWinner()
		{
			if (P1.getScore() < maxScore && P2.getScore() < maxScore)
			{
				startRound();
			}
			else
			{
				this.BackColor = Color.Gray;
				if (P1.getScore() == maxScore)
					winner = " Player Wins!";
				else 
					winner = " Computer Wins!";
				ballTimer.Enabled = false;
				gameOver = true;
				this.Cursor = Cursors.Default;
			}
		}


		private void PongForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			if (e.Y - P1.getHeight()/2 < 0)
			{
				P1.setTop(0);
			}
			else if (e.Y + P1.getHeight()/2 > this.ClientSize.Height)
			{
				P1.setTop(this.ClientSize.Height - P1.getHeight());
			}
			else
				P1.setTop(e.Y - P1.getHeight()/2);

			/*
			else if (e.Y - P1.getHeight()/2 < this.ClientSize.Height - P1.getHeight()/2)
			{
				P1.setTop(e.Y);
			}
			else
				P1.setTop(this.ClientSize.Height - P1.getHeight());
			*/
			// allow paddle to move before round starts
			if (!gameOver && !ballTimer.Enabled)
			{
				Invalidate ();
			}

		
		}

		private void PongForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!gameOver)
			{
				ballTimer.Enabled = true;
				newGame = false;
				roundStarted = true;
			}
		
		}


		private void mEasy_Click(object sender, System.EventArgs e)
		{
			if (!mEasy.Checked)
			{
				mEasy.Checked = true;
				mMedium.Checked = false;
				mHard.Checked = false;
				mImpossible.Checked = false;
				startAgain();
			}

		}

		private void mMedium_Click(object sender, System.EventArgs e)
		{
			if (!mMedium.Checked)
			{
				mEasy.Checked = false;
				mMedium.Checked = true;
				mHard.Checked = false;
				mImpossible.Checked = false;
				startAgain();
			}
		}

		private void mHard_Click(object sender, System.EventArgs e)
		{
			if (!mHard.Checked)
			{
				mEasy.Checked = false;
				mMedium.Checked = false;
				mHard.Checked = true;
				mImpossible.Checked = false;
				startAgain();
			}
		
		}

		private void mImpossible_Click(object sender, System.EventArgs e)
		{
			if (!mImpossible.Checked)
			{
				mEasy.Checked = false;
				mMedium.Checked = false;
				mHard.Checked = false;
				mImpossible.Checked = true;
				startAgain();
			}
		}
		
		private void setDifficulty()
		{
			if (mEasy.Checked)
			{
				difficulty = 1;
			}

			if (mMedium.Checked)
			{
				difficulty = 2;
			}
			
			if (mHard.Checked)
			{
				difficulty = 3;
			}

			if (mImpossible.Checked)
			{
				difficulty = 3;
			}
		}

		
		private void ballTimer_Tick(object sender, System.EventArgs e)
		{
			if (mImpactFlash.Checked)
			{
				if (redLevel != 0)
				{
					this.BackColor = Color.FromArgb(redLevel, 0 ,0);
					if (redLevel >= 25)
						redLevel -= 25;
					else
						redLevel = 0;
				}				
			}
			else if (this.BackColor != Color.Black)
				this.BackColor = Color.Black;

			theBall.setLeft(theBall.getLeft() + theBall.getChangeX());
			theBall.setTop(theBall.getTop() + theBall.getChangeY());
			// have CPU move
			useAI();
			// see if the ball is hitting something and if so, bounce off it
			Checkbounce();

			Invalidate ();
		}


		private void drawNet (Graphics g)
		{
			if (mCheckeredNet.Checked)
			{
				
				int n = 0;
				g.DrawLine(Pens.LightGray, this.ClientSize.Width/2 - 14, 0, this.ClientSize.Width/2 - 14, this.ClientSize.Height);
				for (int X = this.ClientSize.Width/2 -12 ; X < this.ClientSize.Width/2 +12 ; X += 5)
				{ 
					for (int Y = n; Y<=this.ClientSize.Height; Y += 10)
					{
						g.FillRectangle(Brushes.LightGray, X , Y, 4, 4);
						
					} n -= 5;
				} 
				g.DrawLine(Pens.LightGray, this.ClientSize.Width/2 + 13, 0, this.ClientSize.Width/2 + 13, this.ClientSize.Height);
			}

			if (mClassicNet.Checked)
			{
				for (int Y=0; Y<=this.ClientSize.Height; Y+=50)
				{
					g.FillRectangle(Brushes.LightGray, this.ClientSize.Width/2 -9, Y, 20, 20);
				}

			}

			if (mMeshNet.Checked)
			{
				g.DrawLine(Pens.LightGray, this.ClientSize.Width/2 - 14, 0, this.ClientSize.Width/2 - 14, this.ClientSize.Height);

				for(int X = this.ClientSize.Width/2 - 12; X <= this.ClientSize.Width/2 +12; X +=4)
				{
					g.DrawLine(Pens.LightGray, X, 0, X, this.ClientSize.Height);


					for (int Y = 4; Y < this.ClientSize.Height; Y +=4)
					{
						g.DrawLine(Pens.LightGray,X,Y,this.ClientSize.Width/2 +12,Y);
					}	
				}
				g.DrawLine(Pens.LightGray, this.ClientSize.Width/2 + 14, 0, this.ClientSize.Width/2 + 14, this.ClientSize.Height);


			}
		}

		private void mClassicNet_Click(object sender, System.EventArgs e)
		{
			if (!mClassicNet.Checked)
			{
				mMeshNet.Checked = false;
				mClassicNet.Checked = true;
				mCheckeredNet.Checked = false;
				mNoNet.Checked = false;

				saveSettings();
			}
		
		}

		private void mNoNet_Click(object sender, System.EventArgs e)
		{
			if (!mNoNet.Checked)
			{
				mMeshNet.Checked = false;
				mCheckeredNet.Checked = false;
				mClassicNet.Checked = false;
				mNoNet.Checked = true;

				saveSettings();
			}

		}

		private void mCheckeredNet_Click(object sender, System.EventArgs e)
		{
			if (!mCheckeredNet.Checked)
			{
				mMeshNet.Checked = false;
				mCheckeredNet.Checked = true;
				mClassicNet.Checked = false;
				mNoNet.Checked = false;

				saveSettings();
			}
		}

		private void mMeshNet_Click(object sender, System.EventArgs e)
		{
			if (!mMeshNet.Checked)
			{
				mMeshNet.Checked = true;
				mCheckeredNet.Checked = false;
				mClassicNet.Checked = false;
				mNoNet.Checked = false;

				saveSettings();
			}
		}

		
		private void setMaxScore()
		{
						
			if (m3.Checked)
				maxScore = 3;
			else if (m5.Checked)
				maxScore = 5;
			else if (m7.Checked)
				maxScore = 7;
			else
				maxScore = -1; // error checking			
		}

		private void m3_Click(object sender, System.EventArgs e)
		{
			if (!m3.Checked)
			{
				m3.Checked = true;
				m5.Checked = false;
				m7.Checked = false;

				saveSettings();

				startAgain();
			}
			
		}

		private void m5_Click(object sender, System.EventArgs e)
		{
			if (!m5.Checked)
			{
				m3.Checked = false;
				m5.Checked = true;
				m7.Checked = false;

				saveSettings();

				startAgain();
			}

			saveSettings();
		}

		private void m7_Click(object sender, System.EventArgs e)
		{
			if(!m7.Checked)
			{
				m3.Checked = false;
				m5.Checked = false;
				m7.Checked = true;

				saveSettings();
				
				startAgain();
			}

		}

		private void mImpactFlash_Click(object sender, System.EventArgs e)
		{
			if (mImpactFlash.Checked)
				mImpactFlash.Checked = false;
			else
				mImpactFlash.Checked = true;

			saveSettings();
		}

		private void mPlaySound_Click(object sender, System.EventArgs e)
		{
			if (mPlaySound.Checked)
				mPlaySound.Checked = false;
			else
				mPlaySound.Checked = true;

			saveSettings();
		}
		
		private void mAbout_Click(object sender, System.EventArgs e)
		{
			Point startPoint = this.Location;
			startPoint.X += this.ClientSize.Width/2;
			startPoint.Y += this.ClientSize.Height/2;

			ballTimer.Enabled = false;

			AboutForm newAboutForm = new AboutForm(startPoint);
			newAboutForm.ShowDialog();
			
		}

		private void mUpdatedGraphics_Click(object sender, System.EventArgs e)
		{
			if (!mUpdatedGraphics.Checked)
			{
				mShadedGraphics.Checked = false;
				mClassicGraphics.Checked = false;
				mUpdatedGraphics.Checked = true;
			
				saveSettings();
			}
		}

		private void mShadedGraphics_Click(object sender, System.EventArgs e)
		{
			if (!mShadedGraphics.Checked)
			{
				mShadedGraphics.Checked = true;
				mClassicGraphics.Checked = false;
				mUpdatedGraphics.Checked = false;

				saveSettings();
			}
		}

		private void mClassicGraphics_Click(object sender, System.EventArgs e)
		{
			if (!mClassicGraphics.Checked)
			{
				mShadedGraphics.Checked = false;
				mClassicGraphics.Checked = true;
				mUpdatedGraphics.Checked = false;

				saveSettings();
			}
		}

		private void mClassicPaddle_Click(object sender, System.EventArgs e)
		{
			if (mNormalPaddle.Checked)
			{
				mNormalPaddle.Checked = false;
				mClassicPaddle.Checked = true;

				saveSettings();

				try
				{
					P1.setImage(Image.FromFile("images\\paddle_big.gif"));
					P2.setImage(Image.FromFile("images\\paddle_big.gif"));
				}
				catch (DirectoryNotFoundException e18)
				{
					MessageBox.Show("\"Images\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				catch (FileNotFoundException e18)
				{
					MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				catch (Exception e18)
				{
					MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				P1.setHeight(96);
				P2.setHeight(96);
				startAgain();
			}
		}

		private void mNormalPaddle_Click(object sender, System.EventArgs e)
		{
			if (mClassicPaddle.Checked)
			{
				mClassicPaddle.Checked = false;
				mNormalPaddle.Checked = true;

				saveSettings();

				try 
				{
					P1.setImage(Image.FromFile("images\\paddle.gif"));
					P2.setImage(Image.FromFile("images\\paddle.gif"));
				}
				catch (DirectoryNotFoundException e19)
				{
					MessageBox.Show("\"Images\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				catch (FileNotFoundException e19)
				{
					MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				catch (Exception e19)
				{
					MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				P1.setHeight(48);
				P2.setHeight(48);
				startAgain();
			}
		
		}

		private void saveSettings()
		{
			
			System.IO.StreamWriter saveFile = new System.IO.StreamWriter("settings.dat", false);

			for (int loopCount = 1; loopCount < 8; loopCount++)
			{	
				switch (loopCount)
				{
					case 1:
					{
						if (mClassicGraphics.Checked)
							saveFile.WriteLine('3');
						else if (mShadedGraphics.Checked)
							saveFile.WriteLine('2');
						else
							saveFile.WriteLine('1');
						break;
					}
					case 2:
					{
						if (mMeshNet.Checked)
							saveFile.WriteLine('2');
						else if (mCheckeredNet.Checked)
							saveFile.WriteLine('3');
						else if (mClassicNet.Checked)
							saveFile.WriteLine('4');
						else
							saveFile.WriteLine('1');
						break;
					}
					case 3:
					{
						if (mClassicPaddle.Checked)
							saveFile.WriteLine('2');
						else
							saveFile.WriteLine('1');
						break;
					}
					case 4:
					{
						if (mImpactFlash.Checked)
							saveFile.WriteLine('1');
						else
							saveFile.WriteLine('0');
						break;
					}
					case 5:
					{
						if (mPlaySound.Checked)
							saveFile.WriteLine('1');
						else
							saveFile.WriteLine('0');
						break;
					}
					case 6:
					{
						if (mAutoPause.Checked)
							saveFile.WriteLine('1');
						else
							saveFile.WriteLine('0');
						break;
					}
					case 7:
					{
						if (mMedium.Checked)
							saveFile.WriteLine('2');
						else if (mHard.Checked)
							saveFile.WriteLine('3');
						else if (mImpossible.Checked)
							saveFile.WriteLine('4');
						else
							saveFile.WriteLine('1');
						break;
					}
					case 8:
					{
						if (m5.Checked)
							saveFile.WriteLine('2');
						else if (m7.Checked)
							saveFile.WriteLine('3');
						else
							saveFile.WriteLine('1');
						break;
					}

				} // end switch
			} // end for loop
	
			//Cleanup 
			saveFile.Close();

		
		}

		private void loadSettings ()
		{
			int loopCount = 1;
			string loadVal = "True";
			int loadInt;
			System.IO.StreamReader listLoad = null;
			//work with file
			try 
			{
				listLoad = new System.IO.StreamReader("settings.dat");
			}
			catch (FileNotFoundException e21)
			{
				saveSettings();
				listLoad = new System.IO.StreamReader("settings.dat");
			}
			catch (Exception e21)
			{
				saveSettings();
				listLoad = new System.IO.StreamReader("settings.dat");
			}
			while ( (loadVal = listLoad.ReadLine()) != null)
			{
				try
				{
					loadInt = Convert.ToInt16(loadVal);
				}
				catch (Exception e22)
				{
					loadInt = -1;
				}
				
				switch (loopCount)
				{
					case 1:
					{
						if (loadInt != 1)
						{
							mUpdatedGraphics.Checked = false;

							if (loadInt == 2)
								mShadedGraphics.Checked = true;
							else if (loadInt == 3)
								mClassicGraphics.Checked = true;
							else
								mUpdatedGraphics.Checked = true;
						}
						break;
					}
					case 2:
					{
						if (loadInt != 1)
						{
							mNoNet.Checked = false;

							if (loadInt == 2)
								mMeshNet.Checked = true;
							else if (loadInt == 3)
								mCheckeredNet.Checked = true;
							else if (loadInt == 4)
								mClassicNet.Checked = true;
							else
								mNoNet.Checked = true;
						}
						break;
					}
					case 3:
					{
						if (loadInt == 2)
						{
							mClassicPaddle.Checked = true;
							mNormalPaddle.Checked = false;
							P1.setHeight(96);
							P2.setHeight(96);
							if (mUpdatedGraphics.Checked)
							{
								try
								{
									P1.setImage(Image.FromFile("images\\paddle_big.gif"));
									P2.setImage(Image.FromFile("images\\paddle_big.gif"));
								}
								catch (DirectoryNotFoundException e20)
								{
									MessageBox.Show("\"Images\" directory missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
									Application.Exit();
								}
								catch (FileNotFoundException e20)
								{
									MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
									Application.Exit();
								}
								catch (Exception e20)
								{
									MessageBox.Show("Image file missing. Pong# now terminating", "Critical Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
									Application.Exit();
								}
							}
								
						}
						else
							mNormalPaddle.Checked = true;
						break;
					}
					case 4:
					{
						if (loadInt == 0)
							mImpactFlash.Checked = false;
						else
							mImpactFlash.Checked =true;
						break;
					}
					case 5:
					{
						if (loadInt == 0)
							mPlaySound.Checked = false;
						else
							mPlaySound.Checked = true;
						break;
					}
					case 6:
					{
						if (loadInt == 0)
							mAutoPause.Checked = false;
						else
							mAutoPause.Checked = true;
						break;
					}
					case 7: 
					{
						if (loadInt != 2)
						{
							mMedium.Checked = false;

							if (loadInt == 1)
								mEasy.Checked = true;
							else if (loadInt == 3)
								mHard.Checked = true;
							else if (loadInt == 4)
								mImpossible.Checked = true;
							else 
								mMedium.Checked = true;
						}
						break;
					}
					case 8:
					{
						if (loadInt != 1)
						{
							m3.Checked = false;

							if (loadInt == 2)
								m5.Checked = true;
							else if (loadInt == 3)
								m7.Checked = true;
							else 
								m3.Checked = true;
						}
						break;
					}
					default:
						break;
				}// end switch
					loopCount++;
			}//end while loop

			listLoad.Close();
		}

		private void PongForm_MouseLeave(object sender, System.EventArgs e)
		{
			if (mAutoPause.Checked && ballTimer.Enabled)
			{
				ballTimer.Enabled = false;
				Invalidate();
			}
		}

		private void PongForm_MouseEnter(object sender, System.EventArgs e)
		{

		}

		private void mAutoPause_Click(object sender, System.EventArgs e)
		{
			if (mAutoPause.Checked)
				mAutoPause.Checked = false;
			else
				mAutoPause.Checked = true;

			saveSettings();
		}


	}
}
