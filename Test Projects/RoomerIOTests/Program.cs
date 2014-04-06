using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roomer;

namespace RoomerIOTests
{
    class Program
    {
        public RoomKeeper roomKeeper;

        public void Go()
        {
            Console.Write("Path to rooms file: ");
            string filePath = Console.ReadLine();
            roomKeeper = new RoomKeeper(RoomIO.MakePath(filePath.Split('\\', '/')));
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Go();
        }
    }
}
