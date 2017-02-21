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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            //Visuella inställningar för Apply-knappen
            btnAddOptions.BackColor = System.Drawing.Color.Transparent;
            btnAddOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnAddOptions.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnAddOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

            //Sätter storleken på formen till 900x900
            this.Width = 900;
            this.Height = 900;
        }

        //Om Applyknappen trycks (kontrollerar radioknapparna)
        private void btnAddOptions_Click(object sender, EventArgs e)
        {
            //Beroende på vilka radiobuttons som är checkade får variablerna olika värden
            //Dessa variabler ligger i MenuOne och skickas sen in till spelet.
            if (rBtnEasy.Checked)
            {
                MenuOne.speed = 10;
                MenuOne.points = 1;
            }
            else if (rBtnMedium.Checked)
            {
                MenuOne.speed = 20;
                MenuOne.points = 2;
            }
            else if (rBtnHard.Checked)
            {
                MenuOne.speed = 30;
                MenuOne.points = 3;
            }
            else if (rBtnMaster.Checked)
            {
                MenuOne.speed = 10;
                MenuOne.acc = true;
                MenuOne.points = 1;
            }

            if (rBtnWallsOff.Checked)
                MenuOne.wall = false;
            else if (rBtnWallsOn.Checked)
                MenuOne.wall = true;

            this.Close();
        }

        private void Options_KeyDown(object sender, KeyEventArgs f)
        {
            //Om Escape trycks stängs options formen
            if (f.KeyData == Keys.Escape)
                this.Close();
        }
    }
}
