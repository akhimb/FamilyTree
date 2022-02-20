using FamilyTreeCreation.Classes;
using FamilyTreeCreation.Enums;
using System;
using System.Windows;

namespace FamilyTreeCreation
{
    /// <summary>
    /// Interaction logic for AddPersonView.xaml
    /// </summary>
    public partial class AddPersonView : Window
    {
        public static Node SelectedNode { get; set; }
        public AddPersonView()
        {
            InitializeComponent();

        }

        public AddPersonView(Node node)
        {
            InitializeComponent();
            SelectedNode = node;
            NameTxtBox.Text = node.name;
            DesignationTxtBox.Text = node.designation;
            IconPathTextBox.Text = node.icon;
            GenderComboBox.SelectedIndex = node.isMale? 0 : 1;
        }

        private void ImageBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.RestoreDirectory = true;
            openFileDlg.Title = "Browse Image Files";
            openFileDlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
               if(openFileDlg.FileName.Contains("png") || openFileDlg.FileName.Contains("jpeg"))
                {
                    //right candidate
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedNode = new Node();
            SelectedNode.isMale = GenderComboBox.SelectedIndex == 0;
            SelectedNode.name = NameTxtBox.Text.ToString();
            SelectedNode.icon = IconPathTextBox.Text.ToString();
            SelectedNode.designation = DesignationTxtBox.Text.ToString();
            this.Close();
        }
    }
}
