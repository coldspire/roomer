
namespace Roomer
{
    //// A path from one Room to a different Room.
    public class Exit
    {
        //// ID of the starting/source Room
        private string roomIDSource;
        
        //// ID of the destination Room, i.e. where this Exit will take the PC
        private string roomIDDest;
        
        //// Describes this exit/transition to the PC
        private string description;
    }
}