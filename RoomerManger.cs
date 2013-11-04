

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
            get { return Rooms ? Rooms.Count : 0; }
        }
        
        public Room StartingRoom
        {
            get { return !roomIdStart.IsNullOrEmpty && Rooms ? Rooms[roomIdStart] : null; }
        }
        
        private string roomIdStart;

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