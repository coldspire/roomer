using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Roomer
{
    public static class RoomIO
    {
        public enum IOErrCode
        {
            NoError,

            // Rooms file testing errors
            RoomFileNotFound,
            RoomFileNotXMLValid,
            RoomIdsNotUnique,
            StartRoomMissingOrMulti,

            // Rooms loading errors

        }

        public static string MakePath(string Dir, string Fname)
        {
            string path = Path.Combine(Dir, Fname);
            if (Directory.Exists(path))
            {
                return (path);
            }

            return null;
        }

        public static IOErrCode IsValidRoomsFile(string RoomsFilePath, RoomerSettings roomerSettings)
        {
            XmlSchemaSet roomsSchemas;
            XmlReader roomsReader;
            XDocument roomsDoc;

            //// 1. Check that the file can be accessed and exists.
            if (!File.Exists(RoomsFilePath))
            {
                return (IOErrCode.RoomFileNotFound);
            }

            //// Some setup for checking the XML doc against schemas

            string schemaPath = Path.Combine(roomerSettings.GetSett("PathSchemas"), roomerSettings.GetSett("RoomsXsdFilename"));
            
            roomsSchemas = new XmlSchemaSet();
            roomsSchemas.Add("", schemaPath);

            roomsReader = XmlReader.Create(RoomsFilePath);
            
            //// 2. Validate the file against the Rooms schemas.
            if (!roomsReader.Read())
            {
                return (IOErrCode.RoomFileNotXMLValid);
            }

            //// Now that our XML file is valid, store it off.
            roomsDoc = XDocument.Load(roomsReader);

            //// 3. Check that all rooms use a unique ID
            IEnumerable<string> roomIds = roomsDoc.Root.Descendants("id").Select(e => e.Value);
            if (roomIds.Distinct().Count() != roomIds.Count())
            {
                return (IOErrCode.RoomIdsNotUnique);
            }

            //// 4. Check that exactly one starting room exists
            if (roomsDoc.Root.Descendants("isStartingRoom").Count() != 1)
            {
                return (IOErrCode.StartRoomMissingOrMulti);
            }

            //// Looks good!
            return (IOErrCode.NoError);
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

