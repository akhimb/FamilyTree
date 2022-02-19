using FamilyTreeCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeCreation.Classes
{
    class Graph : IGraph
    {
        public Link[] links { get; set; }
        public Node[] nodes { get; set; }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Link GetLink(string id)
        {
            throw new NotImplementedException();
        }

        public Node GetNode(string id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
