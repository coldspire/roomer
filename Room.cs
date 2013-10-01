using System.Collections.Generic;

namespace Roomer
{
    //// A location in which the player can interact with objects and events, and Exit to other Rooms.
    public class Room
    {
        // A unique ID for this Room.
        private string id;
        
        public Description Description;
        
        // Indicates whether the PC has previously visited this Room.
        private bool visitedPreviously;
                
        // Exits in this Room that can transition the PC to a different Room
        private List<Exit> exits = new List<Exit>();
    }
}
