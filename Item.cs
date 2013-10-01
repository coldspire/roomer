
namespace Roomer
{   
    public class Item
    {
        public Description Description;
        
        // Whether this item is accessible to the PC. 
        // If not, it can be seen but something else must be done first to get/use it.
        private bool isAccessible;
        
        // Whether this item is visible to the PC.
        // So an item can exist somewhere but be hidden.
        private bool isVisible;
    }
}
