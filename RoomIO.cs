// TODO: need the using for Dictionary<,>

namespace Roomer
{
    public static class RoomIO
    {
        public static bool IsValidRoomsFile(string RoomsFilePath)
        {
            // TODO
            // 1. Check that the file can be accessed and exists.
            // 2. Validate the file against the Rooms schemas.
            // 2a. The schemas will check that every room/item/exit/etc has a unique ID.
            // 3. Verify that the file doesn't duplicate any unique IDs (rooms, items, exits, etc).
            // 4. Check that the file has a single starting Room.
            // #. [Whatever else?]
        }
        
        public static bool LoadRoomsFromFile(Dictionary<string, Room> outRooms, string RoomsFilePath)
        {
            bool loadWasSuccessful;
            
            loadWasSuccessful = true;
            outRooms = new Dictionary<string, Room>();
            
            // TODO: everything else
            
            return (loadWasSuccessful);
        }
    }
}
