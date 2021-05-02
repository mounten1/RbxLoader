using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Roblox_Cheats
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class Cheat_View : UserControl
    {
        string CheatPath;
        string cheatName;
        WebClient webClient = new WebClient();
        WebClient webClient1 = new WebClient();

        public Cheat_View(string CheatName)
        {
            InitializeComponent();

            cheatName = CheatName;
            CheatPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RbxLoader\\" + CheatName;

            Console.WriteLine(CheatPath);
            if (Directory.Exists(CheatPath) == true)
            {
                DownloadNeedFiles(cheatName);
            }
            else
            {
                Directory.CreateDirectory(CheatPath);
                DownloadNeedFiles(cheatName);
            }

            this.Visibility = Visibility.Hidden;

            webClient1.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient1.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

            DownloadText.Visibility = Visibility.Visible;
            progressBar.Visibility = Visibility.Hidden;

            if (File.Exists(CheatPath + "\\" + cheatName + ".exe") == false)
            {
                DownloadText.Text = "Скачать";
            }
            else
            {
                DownloadText.Text = "Запустить";

            }
        }

        private void Picture2_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void Picture2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image_Viewer viewer = new Image_Viewer(Picture2Image.ImageSource);
            viewer.Show();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Image_Viewer viewer = new Image_Viewer(Picture1Image.ImageSource);
            viewer.Show();
        }

        private void Border_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            Image_Viewer viewer = new Image_Viewer(Picture3Image.ImageSource);
            viewer.Show();
        }

        private void Border_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            Image_Viewer viewer = new Image_Viewer(Picture4Image.ImageSource);
            viewer.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Visible;
            TrainsitionigContentSlide.OnApplyTemplate();
        }

        void DownloadNeedFiles(string CheatName)
        {
            webClient.Encoding = Encoding.UTF8;
            string textDescription = webClient.DownloadString("https://rbxloader.000webhostapp.com/" + CheatName + "/description");
            string textCreator = webClient.DownloadString("https://rbxloader.000webhostapp.com/" + CheatName + "/creator");
            string textVersion = webClient.DownloadString("https://rbxloader.000webhostapp.com/" + CheatName + "/version");


            DescriptionTxt.Text = textDescription;
            CreatorTxt.Text = textCreator;
            VersionTxt.Text = textVersion;


            if (File.Exists(CheatPath + "\\1.png") == false)
            {
                webClient.DownloadFile("https://rbxloader.000webhostapp.com/" + CheatName + "/1.png", CheatPath + "\\1.png");
            }

            Picture1Image.ImageSource = new BitmapImage(new Uri(CheatPath + "\\1.png"));

            if (File.Exists(CheatPath + "\\2.png") == false)
            {
                webClient.DownloadFile("https://rbxloader.000webhostapp.com/" + CheatName + "/2.png", CheatPath + "\\2.png");
            }

            Picture2Image.ImageSource = new BitmapImage(new Uri(CheatPath + "\\2.png"));

            if (File.Exists(CheatPath + "\\3.png") == false)
            {
                webClient.DownloadFile("https://rbxloader.000webhostapp.com/" + CheatName + "/3.png", CheatPath + "\\3.png");
            }

            Picture3Image.ImageSource = new BitmapImage(new Uri(CheatPath + "\\3.png"));

            if (File.Exists(CheatPath + "\\4.png") == false)
            {
                webClient.DownloadFile("https://rbxloader.000webhostapp.com/" + CheatName + "/4.png", CheatPath + "\\4.png");
            }

            Picture4Image.ImageSource = new BitmapImage(new Uri(CheatPath + "\\4.png"));


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(CheatPath + "\\" + cheatName + ".exe") == false)
            {
                DownloadText.Visibility = Visibility.Hidden;
                progressBar.Visibility = Visibility.Visible;
                webClient1.DownloadFileAsync(new Uri("https://rbxloader.000webhostapp.com/" + cheatName + "/" + cheatName + ".zip"), CheatPath + "\\" + cheatName + ".zip");
            }
            else
            {
                string folder = CheatPath;
                string app = cheatName;


                ProcessStartInfo _processStartInfo = new ProcessStartInfo();
                _processStartInfo.WorkingDirectory = folder;
                _processStartInfo.FileName = app;
                Process myProcess = Process.Start(_processStartInfo);
            }
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadText.Visibility = Visibility.Visible;
            progressBar.Visibility = Visibility.Hidden;


            string zipPath = CheatPath + "\\" + cheatName + ".zip";
            string extractPath = CheatPath;

            ZipFile.ExtractToDirectory(zipPath, extractPath);
            DownloadText.Text = "Запустить";
        }
    }
}
