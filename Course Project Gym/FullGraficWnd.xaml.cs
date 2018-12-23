using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using Course_Project_Gym.DataBase.Utillities;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for FullGraficWnd.xaml
    /// </summary>
    public partial class FullGraficWnd : Window
    {
        List<Schedules> list;
        List<Staff> coachList;
        ListView listView;
        List<string> Time = new List<string>
            {
                "9:00",
                "10:00",
                "11:00",
                "12:00",
                "14:00",
                "15:00",
                "16:00",
                "17:00",
                "18:00",
                "19:00",
                "20:00",
                "21:00"
        };

        public FullGraficWnd() => InitializeComponent();

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) => SetCoach();

        private void SetCoach()
        {
            CoachesPanel.Children.Clear();
            var schedule = SchedulesRepository.GetInstance().GetAll();
            list = new List<Schedules>();
            coachList = new List<Staff>();

            foreach (var item in schedule)
            {
                if (item.Date == CalendarSmall.SelectedDate)
                {
                    coachList.Add(item.Coach);
                    list.Add(item);
                }
            }

            foreach (var l in list)
            {
                Expander exp;
                StackPanel spCoach = null;
                List<Schedules> listOne;
                foreach (var c in coachList)
                {
                    listOne = list.Where(item => item.Coach.Id == c.Id).ToList();

                    if (l.Coach.Id == c.Id)
                    {
                        if (spCoach is null)
                        {
                            spCoach = new StackPanel { Orientation = Orientation.Horizontal };

                            BitmapImage bitmap;
                            if (File.Exists(c.ProfileImg.Name + c.ProfileImg.Extension))
                            {
                                bitmap = new BitmapImage(new Uri(System.IO.Path.GetFullPath(c.ProfileImg.Name + c.ProfileImg.Extension)));
                            }
                            else
                            {

                                bitmap = new BitmapImage(new Uri(System.IO.Path.GetFullPath(Utillity.GetInstance().ByteToImage(c.ProfileImg))));
                            }

                            spCoach.Children.Add(new Ellipse
                            {
                                Width = 60,
                                Height = 60,
                                Fill = new ImageBrush(bitmap)
                            });

                            spCoach.Children.Add(new TextBlock
                            {
                                Text = c.Name + " " + c.SurName,
                                VerticalAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(15, 0, 0, 0),
                                FontSize = 18,
                            });
                        }

                        exp = new Expander
                        {
                            Header = spCoach,
                            Content = SetGraficOfOne(listOne),
                            DataContext = c.Id
                        };
                        CoachesPanel.Children.Add(exp);
                    }
                }
            }
        }

        private ListView SetGraficOfOne(List<Schedules> listOne)
        {
            listView = new ListView();
            listView.MouseDoubleClick += ListView_MouseDoubleClick;

            foreach (var item in Time)
            {
                foreach (var li in listOne)
                {
                    if (li.TimeStart.ToShortTimeString().Contains(item))
                    {
                        listView.Items.Add(new TextBlock
                        {
                            Text = item,
                            Foreground = new SolidColorBrush(Colors.Red)
                        });
                    }
                    else
                    {
                        listView.Items.Add(new TextBlock
                        {
                            Text = item,
                            Foreground = new SolidColorBrush(Colors.Green)
                        });
                    }
                }
            }
            return listView;
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listView = (sender as ListView);
            var exp = (listView.Parent as Expander);
            var h = int.Parse((listView.SelectedItem as TextBlock).Text.Substring(0, (listView.SelectedItem as TextBlock).Text.IndexOf(':')));

            Schedules scheduleNew = new Schedules
            {
                TimeStart = new DateTime(CalendarSmall.SelectedDate.Value.Year, CalendarSmall.SelectedDate.Value.Month, CalendarSmall.SelectedDate.Value.Day, h, 0, 0),
                Date = CalendarSmall.SelectedDate.Value,
                Duration = 1,
                Coach = StaffRepository.GetInstance().Get(int.Parse(exp.DataContext.ToString())),
                Services = new AdditionalServices()
            };
            
            SchedulesRepository.GetInstance().Add(scheduleNew);
            var schedule = SchedulesRepository.GetInstance().GetAll();
            list = new List<Schedules>();
            coachList = new List<Staff>();

            foreach (var item in schedule)
            {
                if (item.Date == CalendarSmall.SelectedDate)
                {
                    coachList.Add(item.Coach);
                    list.Add(item);
                }
            }
            var listSchedule = list.Where(item => item.Coach.Id == int.Parse(exp.DataContext.ToString())).ToList();
            exp.Content = null;
            exp.Content = SetGraficOfOne(listSchedule);
        }
    }
}
