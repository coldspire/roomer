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

        public RoomerManager(string RoomFilePath)
        {
            roomerSettings = new RoomerSettings();

            RoomIO.IOErrCode errorCode = RoomIO.IsValidRoomsFile(RoomFilePath, roomerSettings);
            if (errorCode == RoomIO.IOErrCode.NoError)
            {
                // TODO: Load rooms from file
                // TODO: Put the player in the starting room and start playing!
            }
            else
            {
                // TODO: Output error debug information.
            }
        }
    }
}