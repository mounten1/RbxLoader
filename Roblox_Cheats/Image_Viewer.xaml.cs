using System.Windows;
using System.Windows.Media;

namespace Roblox_Cheats
{
    /// <summary>
    /// Логика взаимодействия для Image_Viewer.xaml
    /// </summary>
    public partial class Image_Viewer : Window
    {
        public Image_Viewer(ImageSource image)
        {
            InitializeComponent();
            pictureBox.Source = image;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
