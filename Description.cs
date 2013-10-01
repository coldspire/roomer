
namespace Roomer
{
    // A common container to store descriptions for objects.
    public class Description
    {
        private const string noDesc = "No description.";
    
        private string detailed = noDesc;
        public string Detailed
        {
            private set { detailed = value; }
            get { return detailed; }
        }
        
        private string simple = noDesc;
        public string Simple
        {
            private set { simple = value; }
            get { return simple; }
        }
        
        public Description(string setDetailed, string setSimple)
        {
            Detailed = setDetailed;
            Simple = setSimple;
        }
    }
}
