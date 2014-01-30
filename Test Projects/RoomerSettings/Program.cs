using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roomer;

namespace RoomerSettingsTest
{
    class Program
    {
        private RoomerSettings roomerSettings;

        private void Go()
        {
            roomerSettings = new RoomerSettings();

            if (roomerSettings.InitSuccessful)
            {
                
            }
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Go();
        }
    }
}
