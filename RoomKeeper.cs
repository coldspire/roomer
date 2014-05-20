using System.Collections.Generic;
using System.Linq;

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

        private string startingRoomId;

        public Room StartingRoom
        {
            get { return (startingRoomId != "" && Rooms != null) ? Rooms[startingRoomId] : null; }
        }

        private void SetStartingRoomId()
        {
            var startingRoom = Rooms.Where(room => room.Value.IsStartingRoom).Single();
            startingRoomId = startingRoom.Value.Id;
        }

        public RoomKeeper(string RoomFilePath)
        {
            roomerSettings = new RoomerSettings();

            RoomIO.IOErrCode errorCode = RoomIO.IsValidRoomsFile(RoomFilePath, roomerSettings);
            if (errorCode == RoomIO.IOErrCode.NoError)
            {
                Rooms = RoomIO.LoadRoomsFromFile(RoomFilePath);
                SetStartingRoomId();
            }
            else
            {
                // TODO: Output error debug information.
            }
        }
    }
}