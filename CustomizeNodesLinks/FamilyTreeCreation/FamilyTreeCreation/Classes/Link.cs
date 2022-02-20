using FamilyTreeCreation.Enums;

namespace FamilyTreeCreation.Classes
{
    public class Link
    {
        public int? linkId { get; set; }
        public int source;
        public int target;
        public string type; 
    }
}
