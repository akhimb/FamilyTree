using FamilyTreeCreation.Classes;
using FamilyTreeCreation.Enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;

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
            ImageBrowseButton.IsEnabled = false;
            SelectedNode = node;
            NameTxtBox.Text = node.name;
            DesignationTxtBox.Text = node.designation;
            IconPathTextBox.Text = node.icon;
            GenderComboBox.SelectedIndex = node.isMale? 0 : 1;
            if(node.name!="")
            {
                ImageBrowseButton.IsEnabled = true;
            }
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
                    //right candidate
                    if(NameTxtBox.Text!="")
                    {
                        SaveImage(ResizeImage(new Bitmap(openFileDlg.FileName), 150, 150), NameTxtBox.Text.ToLower());
                        IconPathTextBox.Text = $"./images/{NameTxtBox.Text.ToLower() + ".jpg"}";
                    }
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public void SaveImage(Bitmap bitmap,string fileName)
        {
            // Get a bitmap. The using statement ensures objects  
            // are automatically disposed from memory after use.  
            using (Bitmap bmp1 = bitmap)
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID  
                // for the Quality parameter category.  
                System.Drawing.Imaging.Encoder myEncoder =
                    System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.  
                // An EncoderParameters object has an array of EncoderParameter  
                // objects. In this case, there is only one  
                // EncoderParameter object in the array.  
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(@$"E:\Git-Projects\FamilyTree\Images\{fileName}.jpg", jpgEncoder, myEncoderParameters);
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedNode == null)
                SelectedNode = new Node();
            SelectedNode.isMale = GenderComboBox.SelectedIndex == 0;
            SelectedNode.name = NameTxtBox.Text.ToString();
            SelectedNode.icon = IconPathTextBox.Text.ToString();
            SelectedNode.designation = DesignationTxtBox.Text.ToString();
            this.Close();
        }
    }
}
