using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roomer;

namespace RoomerIOTests
{
    class Program
    {
        public RoomerManager roomerManger;

        public void Go()
        {
            roomerManger = new RoomerManager();
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Go();
        }
    }
}
