using FamilyTreeCreation.Enums;

namespace FamilyTreeCreation.Classes
{
    public class ModifiedLink
    {
        public int? linkId { get; set; }
        public Node source { get; set; }
        public Node target { get; set; }
        public Relation type { get; set; } = Relation.NONE; 
    }
}
