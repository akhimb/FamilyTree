using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FamilyTreeCreation.Classes
{
    [Serializable]
    class Graph
    {
        public List<Link> links { get; set; }
        public List<Node> nodes { get; set; }
        private string jsonFile = "FamilyGraph.json";

        public void Add()
        {
            throw new NotImplementedException();
        }

        public Graph Read()
        {
            var json = File.ReadAllText(jsonFile);
            
            return JsonConvert.DeserializeObject<Graph>(json);
        }

        public void DeleteNode(string nodeId)
        {
            var NodeToDelete = this.nodes.Where(x => x.id == nodeId).FirstOrDefault();
            this.nodes.Remove(NodeToDelete);
            int deletedNodeIndex = Convert.ToInt32(NodeToDelete.id) - 1;
            var LinksToDelete = this.links.Where(x => x.source == deletedNodeIndex || x.target == deletedNodeIndex).Select(y=>y.linkId).ToArray();
            for (int i = 0; i < LinksToDelete.Length; i++)
            {
                this.DeleteLink(LinksToDelete[i]);
            }
            UpdateJSONFile();
        }

        public void DeleteLink(int? linkId)
        {
            var LinkToDelete = this.links.Where(x => x.linkId == linkId).FirstOrDefault();
            this.links.Remove(LinkToDelete);
        }

        public void UpdateLink(Link link)
        {
            var ExistingLink = this.links.Where(x => x.linkId == link.linkId).FirstOrDefault();
            if (ExistingLink != null)
            {
                ExistingLink.linkId = link.linkId;
                ExistingLink.source = link.source;
                ExistingLink.target = link.target;
                ExistingLink.type = link.type;

            }
            else
            {
                link.linkId = this.links.Count+1;
                this.links.Add(link);
            }
            UpdateJSONFile();
        }

        public void UpdateNode(Node node)
        {
            var ExistingNode = this.nodes.Where(x => x.id == node.id).FirstOrDefault();
            if(ExistingNode != null)
            {
                ExistingNode.id = node.id;
                ExistingNode.isMale = node.isMale;
                ExistingNode.icon = node.icon;
                ExistingNode.name = node.name;
                ExistingNode.designation = node.designation;
            }
            else
            {
                node.id = (this.nodes.Count + 1).ToString();
                this.nodes.Add(node);
            }
            UpdateJSONFile();

        }

        private void UpdateJSONFile()
        {
            using (StreamWriter sw = new(jsonFile))
            {
                string json = JsonConvert.SerializeObject(this);
                sw.Write(json);
                sw.Flush();
            }
        }
    }
}
