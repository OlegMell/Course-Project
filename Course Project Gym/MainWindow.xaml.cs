using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using Course_Project_Gym.DataBase.Utillities;
using System.Windows.Media.Animation;
using System.Collections.Generic;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AddWnd addWnd;
        private Uri PreviousImg { get; set; }
        private string PreName = "";
        private int NewsCount = 0;
        public Complex CurrentComplex { get; set; }
        private DispatcherTimer timer;
        private bool IsSearchBarOpen {get;set;}

        public MainWindow()
        {
            DataContext = this;

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (s, r) =>
            {
                var news = NewsRepository.GetInstance().GetAll();
                if (NewsCount < news.Count())
                {
                    NewsPanel.Children.Clear();
                    SetNews(news.ToList());
                    NewsCount = news.Count();
                }
            };
            timer.Start();
            
            InitializeComponent();

            var schedule = SchedulesRepository.GetInstance().GetAll();
            foreach (var item in schedule)
            {
                if (item.Date.Date.Equals(DateTime.Today))
                {
                    ScheduleOfOneUc scheduleOfOne = new ScheduleOfOneUc(item);
                    WorksPanel.Children.Add(scheduleOfOne);
                }
            }
            
            humbrgMenu.ButtonMenu.Click += ButtonMenu_Click;
        }

        private void SetNews(List<News> news)
        {
            foreach (var item in news)
            {
                NewsUc newsUc = new NewsUc();
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
                    newsUc.FillialTb.Text = CurrentComplex.Name + " " + CurrentComplex.Address.City.Name + " " + CurrentComplex.Address.Street.Name + " " + CurrentComplex.Address.House;
                    newsUc.ImgNews.ImageSource = image;
                    newsUc.NewsName.Text = item.Name;
                    PreName = item.Image.Name;
                }
                else
                {
                    newsUc.NewsName.Text = item.Name;
                    newsUc.FormForImg.Visibility = Visibility.Collapsed;
                }
                NewsPanel.Children.Add(newsUc);
            }
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
        
        private void AddNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            addWnd = new AddWnd(CurrentComplex);
            addWnd.ShowDialog();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            IsSearchBarOpen = !IsSearchBarOpen;
            DoubleAnimation animation1 = new DoubleAnimation { To = 0, Duration = TimeSpan.FromMilliseconds(150) };
            animation1.Completed += (s, ar) =>
            {
                DoubleAnimation animation2 = new DoubleAnimation { To = 60, Duration = TimeSpan.FromMilliseconds(100) };
                SearchTb.BeginAnimation(HeightProperty, animation2);
                SearchTb.Focus();
            };
            TitleNewsTb.BeginAnimation(HeightProperty, animation1);
        }

        private void SearchTb_LostFocus(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation1 = new DoubleAnimation { To = 0, Duration = TimeSpan.FromMilliseconds(150) };
            animation1.Completed += (s, ar) =>
            {
                DoubleAnimation animation2 = new DoubleAnimation { To = 50, Duration = TimeSpan.FromMilliseconds(100) };
                TitleNewsTb.BeginAnimation(HeightProperty, animation2);
            };
            SearchTb.BeginAnimation(HeightProperty, animation1);
            SearchTb.Text = string.Empty;
            timer.Start();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(timer.IsEnabled)
                timer.Stop();

            var list = NewsRepository.GetInstance().GetAll();
            List<News> foundNews = new List<News>(); 
            foreach (var item in list)
            {
                if (item.Name.Contains(SearchTb.Text))
                {
                    foundNews.Add(item);
                }
            }

            if(foundNews.Count != 0)
                NewsPanel.Children.Clear();

            SetNews(foundNews);
        }
    }
}
