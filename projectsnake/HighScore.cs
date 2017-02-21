using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjectSnake
{
    public partial class Highscore : Form
    {
        //Skapar ett objekt som heter Stringplayer, innehåller nick & hscore
        public struct Stringplayer
        {
            public string nick, hscore;   
        }

        public Highscore()
        {
            InitializeComponent();

            //Visuella inställningar för knappen buttonExit
            buttonExit.BackColor = System.Drawing.Color.Transparent;
            buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            buttonExit.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

            //Skriver ut stringen som metoden omg generar, highscore.txt skickas in i metoden
            label1.Text = omg(GameOver.ReadFile("highscore.txt"));
        }

        //Metoden omg skapar en string från highscoreList som skickas in
        public static string omg(List<Spelare> highscoreList)
        {
            List<string> sList = new List<string>();

            Stringplayer splayer = new Stringplayer();

            foreach (Spelare s in highscoreList.Take(5))
            {
                splayer.nick = s.nickname.ToString();
                splayer.hscore = s.score.ToString();
                sList.Add(splayer.nick + " - " + splayer.hscore + " poäng \n\n");
            }

            String.Join(String.Empty, sList.ToArray());

            StringBuilder builder = new StringBuilder();
            sList.ForEach(k => builder.Append(k));

            string disp = sList.Aggregate<string>((a, b) => a + b);

            return disp;
        }

        //vad som händer när Exit-knappen trycks (öppnar menu-formen igen)
        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            MenuOne m = new MenuOne();
            m.Width = 900;
            m.Height = 900;
            m.ShowDialog(this);
        }

        //om escape trycks stäng highscore formen ner
        private void Highscore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}