using System.Collections.Generic;

namespace Roomer
{
    //// A location in which the player can interact with objects and events, and Exit to other Rooms.
    public class Room
    {
        public string Id { get; private set; }        
        public Description Description { get; set; }
        public bool Visited { get; set; }
                
        private List<Exit> exits = new List<Exit>();
        public List<Exit> Exits
        {
            get { return exits; }
            set { exits = value; }
        }

        public Room(string newId, Description newDesc, List<Exit> newExits, bool newVisitPrev = false)
        {
            Id = newId;
            Visited = newVisitPrev;
            Description = new Description(newDesc);
            exits.AddRange(newExits);
        }
    }
}
