using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public int spieler = 2;
        public int clearer = 0;
        public int X_Wins = 0;
        public int O_Wins = 0;
        public int Draw_Wins = 0;
        public bool schonGewonnen = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //Wenn ein Button geclickt wird Umwandlung in X oder O
        public void button_click(object sender, EventArgs e)
        {
            //Umwandlung in programmier Button
            Button button = (Button) sender;

            //Checker ob X oder O eingesetzt wird
            if (button.Text == "" && schonGewonnen == false)
            {
                if (spieler % 2 == 0)
                {
                    button.Text = "X";
                    spieler++;
                    clearer++;
                }
                else
                {
                    button.Text = "O";
                    spieler++;
                    clearer++;
                }
            }
            else
            {
                //Nichts passiert
            }

            //schonGewonnen Checker
            if (schonGewonnen == false)
            {
                //Wer gewonnen hat
                if (Feld11.Text == "X" && Feld12.Text == "X" && Feld13.Text == "X" || Feld21.Text == "X" && Feld22.Text == "X" && Feld23.Text == "X" || Feld31.Text == "X" && Feld32.Text == "X" && Feld33.Text == "X" || Feld11.Text == "X" && Feld21.Text == "X" && Feld31.Text == "X" || Feld12.Text == "X" && Feld22.Text == "X" && Feld32.Text == "X" || Feld13.Text == "X" && Feld23.Text == "X" && Feld33.Text == "X" || Feld11.Text == "X" && Feld22.Text == "X" && Feld33.Text == "X" || Feld13.Text == "X" && Feld22.Text == "X" && Feld31.Text == "X")
                {
                    MessageBox.Show("X hat gewonnen!");
                    X_Wins++;
                    X_Siege.Text = "Spieler X:   " + X_Wins;
                    schonGewonnen = true;
                }
                else
                {
                    //Draw machen
                    if (clearer == 9)
                    {
                        Draw_Wins++;
                        Draw_Siege.Text = "Draw:   " + Draw_Wins;
                        schonGewonnen = true;
                        MessageBox.Show("Draw!");
                    }
                }

                if (Feld11.Text == "O" && Feld12.Text == "O" && Feld13.Text == "O" || Feld21.Text == "O" && Feld22.Text == "O" && Feld23.Text == "O" || Feld31.Text == "O" && Feld32.Text == "O" && Feld33.Text == "O" || Feld11.Text == "O" && Feld21.Text == "O" && Feld31.Text == "O" || Feld12.Text == "O" && Feld22.Text == "O" && Feld32.Text == "O" || Feld13.Text == "O" && Feld23.Text == "O" && Feld33.Text == "O" || Feld11.Text == "O" && Feld22.Text == "O" && Feld33.Text == "O" || Feld13.Text == "O" && Feld22.Text == "O" && Feld31.Text == "O")
                {
                    MessageBox.Show("O hat gewonnen!");
                    O_Wins++;
                    O_Siege.Text = "Spieler O:   " + O_Wins;
                    schonGewonnen = true;
                }
                else
                {
                    //Es passiert nichts
                }
            }
            else
            {
                //Nichts passiert
            }
        }

        public void neuesSpiel(object Sender, EventArgs e)
        {
            Feld11.Text = "";
            Feld12.Text = "";
            Feld13.Text = "";

            Feld21.Text = "";
            Feld22.Text = "";
            Feld23.Text = "";

            Feld31.Text = "";
            Feld32.Text = "";
            Feld33.Text = "";

            spieler = 2;
            clearer = 0;

            schonGewonnen = false;
        }

        public void Zuruecksetzen(object sender, EventArgs e)
        {
            spieler = 2;
            clearer = 0;
            X_Wins = 0;
            O_Wins = 0;
            Draw_Wins = 0;
            schonGewonnen = false;

            Feld11.Text = "";
            Feld12.Text = "";
            Feld13.Text = "";

            Feld21.Text = "";
            Feld22.Text = "";
            Feld23.Text = "";

            Feld31.Text = "";
            Feld32.Text = "";
            Feld33.Text = "";

            O_Siege.Text = "Spieler O:   " + O_Wins;
            Draw_Siege.Text = "Draw:   " + Draw_Wins;
            X_Siege.Text = "Spieler X:   " + X_Wins;
        }

        //Übriggeblieben
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
