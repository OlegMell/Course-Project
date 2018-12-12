using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using Course_Project_Gym.DataBase.Utillities;
using HamburgerMenu;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public News LastNews { get; set; }

        private News PreviousNews { get; set; } = new News();

        public MainWindow()
        {
            DataContext = this;

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += (s, r) =>
            {
                var news = NewsRepository.GetInstance().GetLast();
                if (news.Id != PreviousNews.Id)
                {
                    if (news.Image != null)
                    {
                        BitmapImage image = new BitmapImage(new Uri(System.IO.Path.GetFullPath(Utillity.GetInstance().ByteToImage(news.Image))));
                        newsImg.ImageSource = image;
                        textNewsTbock.Text = news.Name;
                    }
                    else
                    {
                        if (news.About.Length > 50)
                            textNewsTbock.Text = news.About.Substring(0, 50);
                        else
                            textNewsTbock.Text = news.About;
                    }
                    PreviousNews = news;
                }
            };
            timer.Start();

            InitializeComponent();
            humbrgMenu.ButtonMenu.Click += ButtonMenu_Click;
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            if(humbrgMenu.StateClosed)
                humbrgMenu.menuPanel.Visibility = Visibility.Collapsed;
            else
                humbrgMenu.menuPanel.Visibility = Visibility.Visible;
        }
    }
}
