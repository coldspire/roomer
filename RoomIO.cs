using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Roomer
{
    public static class RoomIO
    {
        public static bool IsValidRoomsFile(string RoomsFilePath, RoomerSettings roomerSettings)
        {
            // TODO
            // 1. Check that the file can be accessed and exists.
            // 2. Validate the file against the Rooms schemas.
            // 2a. The schemas will check that every room/item/exit/etc has a unique ID.
            // 3. Verify that the file doesn't duplicate any unique IDs (rooms, items, exits, etc).
            // 4. Check that the file has a single starting Room.
            // #. [Whatever else?]

            if (!File.Exists(RoomsFilePath))
            {
                return (false);
            }    



            // Looks good!
            return (true);
        }
        
        public static bool LoadRoomsFromFile(Dictionary<string, Room> outRooms, string RoomsFilePath)
        {
            bool loadWasSuccessful;
            
            loadWasSuccessful = true;
            outRooms = new Dictionary<string, Room>();
            
            // TODO: everything else
            
            return (loadWasSuccessful);
        }

        public static bool LoadRoomerSettings(out RoomerSettings roomerSettings)
        {
            roomerSettings = new RoomerSettings();

            if (!File.Exists(RoomerSettings.SettingsPath))
            {
                return (false);
            }

            using (FileStream fs = new FileStream(RoomerSettings.SettingsPath, FileMode.Open))
            {
                XmlReader xmlReader = XmlReader.Create(fs);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(RoomerSettings));

                roomerSettings = (RoomerSettings)xmlSerializer.Deserialize(xmlReader);
            }

            return (true);
        }

    }
}
