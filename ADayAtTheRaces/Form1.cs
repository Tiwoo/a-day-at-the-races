using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Random MyRandomizer = new Random();

        public Form1()
        {
            InitializeComponent();

            GreyhoundArray[0] = new Greyhound() { GreyhoundPictureBox = pictureBox1, StartingPosition = pictureBox1.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width, Randomizer = MyRandomizer};
            GreyhoundArray[1] = new Greyhound() { GreyhoundPictureBox = pictureBox2, StartingPosition = pictureBox2.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width, Randomizer = MyRandomizer };
            GreyhoundArray[2] = new Greyhound() { GreyhoundPictureBox = pictureBox3, StartingPosition = pictureBox3.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width, Randomizer = MyRandomizer };
            GreyhoundArray[3] = new Greyhound() { GreyhoundPictureBox = pictureBox4, StartingPosition = pictureBox4.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width, Randomizer = MyRandomizer };

            GuyArray[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeBetLabel};
            GuyArray[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobBetLabel };
            GuyArray[2] = new Guy() { Name = "Al", Cash = 45, MyRadioButton = alRadioButton, MyLabel = alBetLabel };

            for (int i = 0; i < 3; i++)
            {
                GuyArray[i].ClearBet();
                GuyArray[i].UpdateLabels();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int winnerDog = 0;

            for (int i = 0; i < 4; i++)
            {
                if (GreyhoundArray[i].Run() == true)
                {
                    timer1.Stop();
                    MessageBox.Show("Dog# " + (i + 1) + " won the race!", "We have a winner");
                    winnerDog = (i+1);

                    for (int j = 0; j < 3; j++)
                    {
                        GuyArray[j].Collect(winnerDog);

                    } break;
                }
            }
                    
        
                
            
   
            
        }

        private void bettingButton_Click(object sender, EventArgs e)
        {
            // placebet for the guy which radioButton is checked.
            int guyIndex;
            if (joeRadioButton.Checked == true)
            {
                guyIndex = 0;
                bettorNameLabel.Text = "Joe";
            }
            else if (bobRadioButton.Checked == true)
            {
                guyIndex = 1;
                bettorNameLabel.Text = "Bob";
            }
            else
            {
                guyIndex = 2;
                bettorNameLabel.Text = "Al";
            }

            GuyArray[guyIndex].PlaceBet((int)betAmountNumericUpDown.Value, (int)dogNumberNumericUpDown.Value);
            GuyArray[guyIndex].UpdateLabels();
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {

            }
            else
            {
                timer1.Start();
            }
            
        }
    }
}
