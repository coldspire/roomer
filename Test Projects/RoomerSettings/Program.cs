using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roomer;

namespace RoomerSettingsTest
{
    class Program
    {
        private Roomer.RoomerSettings roomerSettings;

        private void Go()
        {
            bool loadWasSuccessful;

            loadWasSuccessful = RoomIO.LoadRoomerSettings(out roomerSettings);
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Go();
        }
    }
}
