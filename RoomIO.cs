using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Roomer
{
    public static class RoomIO
    {
        public static bool IsValidRoomsFile(string RoomsFilePath, RoomerSettings roomerSettings)
        {
            // TODO
            // 2a. The schemas will check that every room/item/exit/etc has a unique ID.
            // 3. Verify that the file doesn't duplicate any unique IDs (rooms, items, exits, etc).
            // 4. Check that the file has a single starting Room.
            // #. [Whatever else?]
            
            // 1. Check that the file can be accessed and exists.
            if (!File.Exists(RoomsFilePath))
            {
                return (false);
            }
            
            // 2. Validate the file against the Rooms schemas.
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", Path.Combine(roomerSettings.GetSett("PathSchemas"), roomerSettings.GetSett("RoomsXsdFilename")));

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemas;

            XmlReader xmlReader = XmlReader.Create(RoomsFilePath);
            if (!xmlReader.Read())
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

    }
}

