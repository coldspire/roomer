// TODO: need the using for Dictionary<,>

namespace Roomer
{
    public class Rooms
    {
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
        
        Rooms(string RoomsFilePath)
        {            
            // TODO: The whole procedure for opening a Rooms file and filling the rooms Dict            
            // if (RoomIO.IsValidRoomsFile(RoomsFilePath))
            // then Builder.LoadRoomsFromFile(rooms, RoomsFilePath)
        }
    }
}
