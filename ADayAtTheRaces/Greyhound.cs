using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public class Greyhound
    {
        public int StartingPosition; 
        public int RacetrackLength;
        public PictureBox GreyhoundPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            Location = Randomizer.Next(30, 60);
            //Location = 100;
            GreyhoundPictureBox.Left += Location;
            if (GreyhoundPictureBox.Left >= RacetrackLength - GreyhoundPictureBox.Width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            GreyhoundPictureBox.Left = StartingPosition;
        }
    }
}
