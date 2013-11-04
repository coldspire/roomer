using System.Collections.Generic;

namespace Roomer
{
    public class RoomerManager
    {
        private static RoomerSettings roomerSettings;


        private Dictionary<string, Room> rooms;
        public Dictionary<string, Room> Rooms
        {
            get { return rooms; }
            private set { rooms = value; }
        }        
        
        public int NumberOfRooms
        {
            get { return Rooms != null ? Rooms.Count : 0; }
        }

        private string roomIdStart; 
        
        public Room StartingRoom
        {
            get { return roomIdStart != "" && Rooms != null ? Rooms[roomIdStart] : null; }
        }

        public RoomerManager()
        {
            roomerSettings = new RoomerSettings();            
            RoomIO.LoadRoomerSettings(out roomerSettings);

            if (RoomIO.IsValidRoomsFile(@"RoomFiles\TwoRooms.xml", roomerSettings))
            {

            }
        }
    }
}