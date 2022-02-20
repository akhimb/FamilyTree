using FamilyTreeCreation.Classes;
using System.Windows;
using System.Collections.Generic;
using FamilyTreeCreation.Enums;
using System;
using System.Windows.Controls;
using System.Linq;

namespace FamilyTreeCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constants and Fields
        private Graph graph;
        private List<Node> Nodes;
        private List<ModifiedLink> ModifiedLinks;
        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            this.graph = new Graph().Read();

            PopulateNodes();
            PopulateLinks();
        }

        private void PopulateNodes()
        {
            Nodes = new List<Node>();
            for (int i = 0; i < this.graph.nodes.Count; i++)
            {
                var node = graph.nodes[i];
                if (node.icon == null)
                {
                    node.icon = "";
                }
                Nodes.Add(node);
            }
            NodesDataGrid.ItemsSource = null;
            NodesDataGrid.ItemsSource = Nodes;
        }

        private void PopulateLinks()
        {
            ModifiedLinks = new List<ModifiedLink>();
            ModifiedLink modifiedLink;
            for (int i = 0; i < this.graph.links.Count; i++)
            {
                try
                {
                    var link = graph.links[i];
                    modifiedLink = new ModifiedLink();
                    modifiedLink.linkId = link.linkId ?? -1;
                    modifiedLink.source = Nodes[link.source];
                    modifiedLink.target = Nodes[link.target];
                    modifiedLink.type = (Relation)Enum.Parse(typeof(Relation), link.type);
                    ModifiedLinks.Add(modifiedLink);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
            LinksDataGrid.ItemsSource = null;
            LinksDataGrid.ItemsSource = ModifiedLinks;
        }


        #endregion

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPersonView personView = new();
            personView.ShowDialog();
            if (AddPersonView.SelectedNode != null)
            {
                this.graph.UpdateNode(AddPersonView.SelectedNode);
                AddPersonView.SelectedNode = null;
                PopulateNodes();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            AddPersonView personView = new(NodesDataGrid.SelectedItem as Node);
            personView.ShowDialog();
            if (AddPersonView.SelectedNode != null)
            {
                this.graph.UpdateNode(AddPersonView.SelectedNode);
                AddPersonView.SelectedNode = null;
                NodesDataGrid.SelectedItem = null;
                PopulateNodes();
            }
        }

        private void AddLinkButton_Click(object sender, RoutedEventArgs e)
        {
            AddRelation.NodeList = (from Node node in this.Nodes
                                    select node.name).ToList();
            AddRelation relationView = new();
            relationView.ShowDialog();
            if (AddRelation.SelectedLink != null && AddRelation.SelectedLink.type != null)
            {
                this.graph.UpdateLink(AddRelation.SelectedLink);
                AddRelation.SelectedLink = null;
                PopulateLinks();
            }
        }

        private void EditLinkButton_Click(object sender, RoutedEventArgs e)
        {
            AddRelation.NodeList = (from Node node in this.Nodes
                                    select node.name).ToList();
            AddRelation relationView = new(LinksDataGrid.SelectedItem as ModifiedLink);
            relationView.ShowDialog();
            if(AddRelation.SelectedLink != null && AddRelation.SelectedLink.type != null)
            {
                this.graph.UpdateLink(AddRelation.SelectedLink);
                AddRelation.SelectedLink = null;
                LinksDataGrid.SelectedItem = null;
                PopulateLinks();
            }


        }

        private void DeleteLinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (LinksDataGrid.SelectedItem != null)
            {
                this.graph.DeleteLink((LinksDataGrid.SelectedItem as ModifiedLink).linkId);
                LinksDataGrid.SelectedItem = null;
                PopulateLinks();
            }
        }

        private void DeleteNodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (NodesDataGrid.SelectedItem != null)
            {
                this.graph.DeleteNode((NodesDataGrid.SelectedItem as Node).id);
                NodesDataGrid.SelectedItem = null;
                PopulateNodes();
                PopulateLinks();
            }
        }
    }
}
