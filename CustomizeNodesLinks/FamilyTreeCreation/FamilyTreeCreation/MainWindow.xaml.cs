using FamilyTreeCreation.Classes;
using System.Windows;
using System.IO;
using Newtonsoft.Json;

namespace FamilyTreeCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constants and Fields
        private Graph graph;
        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            this.graph = new Graph();
            var json = File.ReadAllText("FamilyGraph.json");
            this.graph = JsonConvert.DeserializeObject<Graph>(json);
            System.Console.WriteLine(this.graph);
            NodesDataGrid.ItemsSource = this.graph.nodes;

        }

        #endregion


    }
}
