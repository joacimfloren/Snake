using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSnake
{
    public partial class MenuOne : Form
    {
        public MenuOne()
        {
            InitializeComponent();
            //Visuella inställningar för knapparna (Start, Highscore, Options och Exit)
            btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnStart.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnHighScore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnHighScore.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnHighScore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnOptions.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnExit.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

            this.Width = 900;
            this.Height = 900;
        }
        //Globala variabler.
        public static int speed = 10;
        public static bool acc = false;
        public static bool wall = false;
        public static int points = 1;
        //Knapp som startar ett nytt spelform.
        private void btnStart_Click(object sender, EventArgs e)
        {
            Game g = new Game();
            g.Width = 900;
            g.Height = 900;
            g.Show();
        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }
        //Knapp som tar dig till Highscoreformen
        private void btnHighScore_Click(object sender, EventArgs e)
        {
            Highscore h = new Highscore();
            h.Width = 900;
            h.Height = 900;
            h.ShowDialog(this);
        }
        //Knapp som tar dig till Spelinställningar. 
        private void btnOptions_Click(object sender, EventArgs e)
        {
            Options o = new Options();
            o.Width = 900;
            o.Height = 900;
            o.ShowDialog(this);
        }
        //Knapp som avslutar spelet.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Avslutar applikationen med tangenten Esc.
        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Application.Exit();
        }
        
        
    }
}
