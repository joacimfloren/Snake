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
    //Skapar ett eget objekt Spelare som innehåller string nickname och int score
    public struct Spelare
    {
        public string nickname;
        public int score;
    }

    public partial class GameOver : Form
    {
        //Skapar två listor som innehåller Spelare
        public static List<Spelare> highscoreList = new List<Spelare>();
        public static List<Spelare> tempHighscorelist = new List<Spelare>();

        public GameOver()
        {
            InitializeComponent();
            //Sätter storleken på formen till 900x900 och opacitet 80%
            this.Height = 900;
            this.Width = 900;
            this.Opacity = 0.8;

            //Visuella inställningar för Submitknappen
            btnSubmit.BackColor = System.Drawing.Color.Transparent;
            btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnSubmit.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

            lbScore.BackColor = System.Drawing.Color.Transparent;//Sätter bakgrunden på Scorelabeln till transparennt
            lbScore.Text = Game.score.ToString(); //Skriver ut score
            txtName.BackColor = System.Drawing.Color.LightCyan; //Bakgrundsfärg på Textboxen txtName

        }

        //Stänger denna form om Exitknappen trycks
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Stänger denna form om Escape trycks
        private void GameOver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }

        //Om Submitknappen trycks
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Spelare enSpelare = AddToList(txtName); //Metoden skapar enSpelare med inläst namn och score
            highscoreList = ReadFile("highscore.txt"); //Läser in Spelare från textfil & lägger de i highscoreList
            highscoreList.Add(enSpelare); //Lägger till enSpelare längst ner i highscoreList
            highscoreList = SortFile(highscoreList); //Sorterar highscoreList med hjälp av metoden SortFile
            SaveToFile(highscoreList); //Metoden SaveToFile sparar listan till textfil

            this.Close();
        }

        //AddToList metod (olämpligt namn då den inte lägger till i listan, den tar namn & score och lägger i en spelare
        public static Spelare AddToList(TextBox txtName)
        {
            Spelare nySpelare = new Spelare();
            string tempNn = "";
            tempNn = txtName.Text;
            while (string.IsNullOrEmpty(tempNn))
            {
                tempNn = txtName.Text;
            }
            nySpelare.nickname = tempNn;

            nySpelare.score = Game.score;

            return nySpelare;
        }

        //SaveToFile metod, sparar highscorelist till textfil
        public static void SaveToFile(List<Spelare> sList)
        {
            StreamWriter writeFile;

            try
            {
                if (File.Exists("highscore.txt"))
                    File.Delete("highscore.txt");
                writeFile = File.CreateText("highscore.txt");

                foreach (Spelare s in sList)
                {
                    writeFile.WriteLine(s.nickname + ";" + s.score.ToString());
                }

                writeFile.Close();
            }

            catch (FileNotFoundException exObj)
            {
            }

            catch (IOException exObj)
            {
            }
        }

        //Läser  från textfil och lägger in filens innehåll i lista
        public static List<Spelare> ReadFile(string filename)
        {
            List<Spelare> localPlayerlist = new List<Spelare>();
            Spelare onePlayer;
            string[] temp;

            StreamReader lasFil;

            try
            {
                lasFil = File.OpenText(filename);

                string line = lasFil.ReadLine();
                while (line != null)
                {
                    temp = line.Split(';');
                    onePlayer.nickname = temp[0];
                    onePlayer.score = Convert.ToInt32(temp[1]);
                    localPlayerlist.Add(onePlayer);
                    line = lasFil.ReadLine();
                }

                lasFil.Close();
            }

            catch (FileNotFoundException exObj)
            {
            }

            catch (IOException exObj)
            {
            }

            return localPlayerlist;
        }

        //Metod SortFile, sorterar highscorelistan och skickar ut en ny sorterad lista
        public static List<Spelare> SortFile(List<Spelare> sortThisList)
        {
            List<Spelare> SortedList = new List<Spelare>(sortThisList.OrderByDescending(s => s.score).ToList());

            return SortedList;
        }
    }
}