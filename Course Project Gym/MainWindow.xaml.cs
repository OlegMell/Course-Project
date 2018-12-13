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
using System.Windows.Media.Animation;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Uri PreviousImg { get; set; }
        private string PreName = "";
        private int NewsCount = 0;

        public MainWindow()
        {
            DataContext = this;

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += (s, r) =>
            {
                var news = NewsRepository.GetInstance().GetAll();
                if (NewsCount < news.Count())
                {
                    NewsPanel.Children.Clear();
                    foreach (var item in news)
                    {
                        BitmapImage image = new BitmapImage();
                        if (item.Image != null)
                        {
                            if (!PreName.Equals(item.Image.Name))
                            {
                                image = new BitmapImage();
                                Uri uri = new Uri(System.IO.Path.GetFullPath(Utillity.GetInstance().ByteToImage(item.Image)));
                                image = new BitmapImage(uri);
                                PreviousImg = uri;
                            }
                            else
                            {
                                image = new BitmapImage(PreviousImg);
                            }
                            NewsUc newsUc = new NewsUc();
                            newsUc.ImgNews.ImageSource = image;
                            newsUc.NewsName.Text = item.Name;
                            NewsPanel.Children.Add(newsUc);
                        }
                        PreName = item.Image.Name;
                    }
                    NewsCount = news.Count();
                }
            };
            timer.Start();

            
            InitializeComponent();
            humbrgMenu.ButtonMenu.Click += ButtonMenu_Click;
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            //...
        }
        
        private void ScrollNews_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if ((sender as ScrollViewer).VerticalOffset > 0)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation {To = 0, Duration = TimeSpan.FromMilliseconds(200) };
                BottomArrowBtn.BeginAnimation(OpacityProperty, doubleAnimation);
            }
            if ((sender as ScrollViewer).VerticalOffset > 20)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation { To = 1, Duration = TimeSpan.FromMilliseconds(200) };
                TopArrowBtn.BeginAnimation(OpacityProperty, doubleAnimation);
            }
            if((sender as ScrollViewer).VerticalOffset == 0)
            {
                DoubleAnimation doubleAnimation1 = new DoubleAnimation { To = 0, Duration = TimeSpan.FromMilliseconds(200) };
                TopArrowBtn.BeginAnimation(OpacityProperty, doubleAnimation1);

                DoubleAnimation doubleAnimation = new DoubleAnimation { To = 1, Duration = TimeSpan.FromMilliseconds(200) };
                BottomArrowBtn.BeginAnimation(OpacityProperty, doubleAnimation);
            }
        }

        private void BottomArrowBtn_Click(object sender, RoutedEventArgs e)
        {
           ScrollNews.ScrollToEnd();
        }

        private void TopArrowBtn_Click(object sender, RoutedEventArgs e)
        {
            ScrollNews.ScrollToHome();
        }

        private void NewsForm_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void NewsForm_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void ScrollNews_MouseEnter(object sender, MouseEventArgs e)
        {
            //BottomArrowBtn.Visibility = Visibility.Visible;
        }

        private void ScrollNews_MouseLeave(object sender, MouseEventArgs e)
        {
            //BottomArrowBtn.Visibility = Visibility.Hidden;
        }

        private void AddNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation thickness = new ThicknessAnimation { To = new Thickness(10) };
        }

        private void AddImageInNews_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
