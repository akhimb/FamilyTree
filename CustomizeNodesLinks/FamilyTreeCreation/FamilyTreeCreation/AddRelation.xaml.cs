using FamilyTreeCreation.Classes;
using FamilyTreeCreation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FamilyTreeCreation
{
    /// <summary>
    /// Interaction logic for AddRelation.xaml
    /// </summary>
    public partial class AddRelation : Window
    {
        public static Link SelectedLink { get; set; }
        public static List<string> NodeList;
        public static List<string> RelationList = new()
        {
            "NONE",
            "MOTHER",
            "FATHER",
            "BROTHER",
            "SISTER",
            "DAUGHTER",
            "SON",
            "SPOUSE"

        };
        public AddRelation()
        {
            InitializeComponent();
            SelectedLink = new Link();
            SourceComboBox.ItemsSource = NodeList;
            TargetComboBox.ItemsSource = NodeList;
            RelationComboBox.ItemsSource = RelationList;
            SourceComboBox.Focus();
        }

        public AddRelation(ModifiedLink modifiedLink)
        {
            InitializeComponent();
            SelectedLink = new Link();
            SelectedLink.linkId = modifiedLink.linkId;
            SourceComboBox.ItemsSource = NodeList;
            TargetComboBox.ItemsSource = NodeList;
            RelationComboBox.ItemsSource = RelationList;
            SourceComboBox.SelectedItem = modifiedLink.source.name;
            TargetComboBox.SelectedItem = modifiedLink.target.name;
            RelationComboBox.SelectedItem = modifiedLink.type.ToString();
            SourceComboBox.Focus();
        }

        private void ImageBrowseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedLink.source = SourceComboBox.SelectedIndex;
            SelectedLink.target = TargetComboBox.SelectedIndex;
            SelectedLink.type = RelationComboBox.SelectedValue.ToString();
            this.Close();
        }
    }
}
