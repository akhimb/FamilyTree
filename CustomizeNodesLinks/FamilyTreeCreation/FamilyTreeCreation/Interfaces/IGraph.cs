using FamilyTreeCreation.Classes;

namespace FamilyTreeCreation.Interfaces
{
    public interface IGraph
    {
        Link[] links { get; set; }
        Node[] nodes { get; set; }

        public void Add();
        public void Update();
        public void Delete();
        public Node GetNode(string id);
        public Link GetLink(string id);

    }
}
