

namespace Roomer
{
    public class RoomerManager
    {
        private static RoomerSettings roomerSettings;
        private Rooms rooms;

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