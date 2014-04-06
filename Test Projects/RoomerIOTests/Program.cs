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
            filePath = filePath.Replace('/', System.IO.Path.DirectorySeparatorChar);
            filePath = filePath.Replace('\\', System.IO.Path.DirectorySeparatorChar);

            roomKeeper = new RoomKeeper(filePath);            
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Go();
        }
    }
}
