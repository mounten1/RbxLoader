using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Roblox_Cheats
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient webClient = new WebClient();
        string mainPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RbxLoader";
        string[] Cheats_Name = new string[10];

        public MainWindow()
        {
            InitializeComponent();

            string serverVersion = webClient.DownloadString("https://rbxloader.000webhostapp.com/version");
            string clientVersion = "1.0";
            if(clientVersion != serverVersion == true)
            {
                MessageBox.Show("This version outdated");
                Application.Current.Shutdown();
            }

            Cheats_Name[0] = "KRNL";
            Cheats_Name[1] = "Robloxware";
            Cheat1Name_text.Text = Cheats_Name[0];
            Cheat2Name_text.Text = Cheats_Name[1];

            if (Directory.Exists(mainPath) == true)
            {

            }
            else
            {
                Directory.CreateDirectory(mainPath);
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Cheat_View(Cheats_Name[0]));
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Cheat_View(Cheats_Name[1]));
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, ((40 * index)), 0, 0);
        }
    }
}
