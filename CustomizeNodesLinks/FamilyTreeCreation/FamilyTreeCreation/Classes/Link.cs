using FamilyTreeCreation.Enums;

namespace FamilyTreeCreation.Classes
{
    public class Link
    {
        public string? linkId { get; set; }
        public int source;
        public int target;
        public string type; 
    }
}
