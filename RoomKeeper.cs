using System.Collections.Generic;

namespace Roomer
{
    public class RoomKeeper
    {
        private static RoomerSettings roomerSettings;

        private Dictionary<string, Room> rooms = new Dictionary<string, Room>();
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
            get { return (roomIdStart != "" && Rooms != null) ? Rooms[roomIdStart] : null; }
        }

        public RoomKeeper(string RoomFilePath)
        {
            roomerSettings = new RoomerSettings();

            RoomIO.IOErrCode errorCode = RoomIO.IsValidRoomsFile(RoomFilePath, roomerSettings);
            if (errorCode == RoomIO.IOErrCode.NoError)
            {
                Rooms = RoomIO.LoadRoomsFromFile(RoomFilePath);
            }
            else
            {
                // TODO: Output error debug information.
            }
        }
    }
}