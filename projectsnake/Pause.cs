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
    public partial class Pause : Form
    {
        public Pause()
        {
            InitializeComponent();
            this.Height = 900;
            this.Width = 900;
            this.Opacity = 0.8; // 80% Transparens
            //Visuella inställningar för End Game knappen.
            btnExit.BackColor = System.Drawing.Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnExit.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            
            //Återställer ljudknappen.
            if (Game.s == 1)
                btnSound.BackgroundImage = Bitmap.FromFile("sound-off.png");
            else
                btnSound.BackgroundImage = Bitmap.FromFile("sound-on.png");
            //Visuella inställningar för ljudknappen.
            btnSound.BackColor = System.Drawing.Color.Transparent;
            btnSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnSound.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            //Visuella inställningar för Score.
            btnScore.BackColor = System.Drawing.Color.Transparent;
            btnScore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnScore.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnScore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            lbScore.Text = Game.score.ToString(); //Din nuvarande poäng visas.
        }
        //Nuvarande spel avslutas när End Game knappen trycks.
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Game.stopGame = true; 
        }
        //Spelet återupptas om antingen (Space eller Escape knappen används)
        private void Pause_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
                this.Close();


            else if (e.KeyData == Keys.Escape)
                this.Close();
        }
        //En knapp som trycks så ljudet spelar eller inte.
        private void btnSound_Click(object sender, EventArgs e)
        {
            Game.simpleSound.Stop();
            //Om ljudet är avstängt.
            if (Game.s == 1)
            {
                Game.simpleSound.Play();
                Game.s = 0;
                btnSound.BackgroundImage = Bitmap.FromFile("sound-on.png");
            }
            //Om ljudet är på.
            else
            {
                Game.s = 1;
                btnSound.BackgroundImage = Bitmap.FromFile("sound-off.png");
            }
        } 
    }
}
