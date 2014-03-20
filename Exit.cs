
namespace Roomer
{
    //// A path from one Room to a different Room.
    public class Exit
    {
        //// ID of the starting/source Room
        public string SourceId { get; private set; }

        //// ID of the destination Room, i.e. where this Exit will take the PC
        public string DestId { get; private set; }

        public Description Description { get; set; }

        private void setupExit(string sourceId, string destId, Description descript)
        {
            SourceId = sourceId;
            DestId = destId;
            Description = new Description(descript);
            return;
        }

        public Exit(string sourceID, string destId, Description descript)
        {
            setupExit(sourceID, destId, descript);
        }

        public Exit(string sourceID, string destID)
        {
            setupExit(sourceID, destID, new Description());
        }
    }
}
