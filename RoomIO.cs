using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Roomer
{
    /// <summary>
    /// Methods and enums for roomer IO. 
    /// No fields/properties or saved state.
    /// </summary>
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

        public static string MakePath(params string[] pathParts)
        {
            string fullPath = "";
            foreach (string part in pathParts)
            {
                fullPath = Path.Combine(fullPath, part);
            }

            if (File.Exists(fullPath) || Directory.Exists(fullPath))
            {
                return (fullPath);
            }

            return null;
        }

        // TODO: Move this to a RoomerValidator class
        public static IOErrCode IsValidRoomsFile(string RoomsFilePath, RoomerSettings roomerSettings)
        {
            // TODO: Would be good to pass more information back to the caller regarding any errors.
            // E.g. if the schema is invalid, what does XDocument.Validate say was wrong?

            XmlSchemaSet roomsSchemas;
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
            
            //// 2. Validate the file against the Rooms schemas.
            bool foundValidErrs = false;

            // TODO: Is this a good way to check if a schema is invalid? By using an exception? Nope.
            // Probably should be in a method. And not use an exception
            try
            {
                XDocument temp = XDocument.Load(RoomsFilePath);
            }
            catch (System.Xml.XmlException)
            {
                foundValidErrs = true;            
            }

            if (foundValidErrs)
            {
                return (IOErrCode.RoomFileNotXMLValid);
            }

            //// Now that our XML file is valid, store it off.
            roomsDoc = XDocument.Load(RoomsFilePath);

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
        
        public static Dictionary<string, Room> LoadRoomsFromFile(string RoomsFilePath)
        {
            XElement roomsFile;
            roomsFile = XElement.Load(RoomsFilePath);

            if (roomsFile == null)
            {
                return (null);
            }

            Dictionary<string, Room> outRooms = new Dictionary<string, Room>();
            bool loadWasSuccessful = true; // Will change to false as soon as an error is found

            foreach (XElement roomElem in roomsFile.Descendants("Room"))
            {
                string id;
                id = roomElem.Element("id").Value;

                // TODO: Can this be condensed? There's a lot of checking for null elements.
                // Maybe an extension method that either returns a blank string or the value of the needed descendent would work?
                string descriptionSimple = "";
                string descriptionDetail = "";
                if (roomElem.Element("description") != null)
                {
                    if (roomElem.Element("description").Element("simple") != null)
                    {
                        descriptionSimple = roomElem.Element("description").Element("simple").Value;
                    }

                    if (roomElem.Element("description").Element("detailed") != null)
                    {
                        descriptionDetail = roomElem.Element("description").Element("detailed").Value;
                    }
                }

                bool visited;
                visited = (roomElem.Element("visited") != null);

                List<Exit> exitsForRoom = new List<Exit>();

                // TODO: This has the same problem that the description does. There's a lot of checking for null elements.
                if (roomElem.Element("exits") != null)
                {
                    foreach (XElement exitElem in roomElem.Element("exits").Elements("exit"))
                    {
                        string sourceId = exitElem.Element("roomIDSource").Value;
                        string destId = exitElem.Element("roomIDDest").Value;

                        // TODO: And here's that same description issue again with the elements...
                        string descriptionExitSimple = "";
                        string descriptionExitDetail = "";
                        if (exitElem.Element("description") != null)
                        {
                            if (exitElem.Element("description").Element("simple") != null)
                            {
                                descriptionExitSimple = exitElem.Element("description").Element("simple").Value;
                            }

                            if (exitElem.Element("description").Element("detailed") != null)
                            {
                                descriptionExitDetail = exitElem.Element("description").Element("detailed").Value;
                            }
                        }

                        exitsForRoom.Add(new Exit(sourceId, destId, new Description(descriptionExitSimple, descriptionExitDetail)));
                    }
                }

                // TODO: FindRoomErrors
                // if (FindRoomErrors() == errors)
                // {
                //   loadWasSuccessful = false;
                //   log_errors();
                // }

                outRooms.Add(id, new Room(id, new Description(descriptionSimple, descriptionDetail), exitsForRoom, visited));

                if (!loadWasSuccessful)
                {
                    break;
                }
            }
            
            return (outRooms);
        }

    }
}

