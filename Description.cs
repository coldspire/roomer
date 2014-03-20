
namespace Roomer
{
    // A common container to store descriptions for objects.
    public class Description
    {
        const string noDesc = "No description.";

        public string Simple { get; private set; }
        public string Detailed { get; private set; }

        public Description() 
        {
            Detailed = noDesc;
            Simple = noDesc;
        }

        public Description(string setSimple, string setDetailed)
        {
            Detailed = setDetailed;
            Simple = setSimple;
        }

        public Description(Description newDescription)
        {
            Detailed = newDescription.Detailed;
            Simple = newDescription.Simple;
        }        
    }
}
