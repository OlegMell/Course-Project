using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using Course_Project_Gym.DataBase.Utillities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        enum Months
        {
            Январь = 1,
            Ферваль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        };

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

        public Calendar()
        {
            InitializeComponent();
        }

        //public void SetMonth(int month)
        //{
        //    if (month == 13 || month == 0)
        //        month = 1;

        //    MonthTb.Text = Enum.GetName(typeof(Months), month);
        //    MonthTb.DataContext = month;
        //}

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //...
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var schedule = SchedulesRepository.GetInstance().GetAll();
            List<Schedules> list = new List<Schedules>();
            List<Staff> coachList = new List<Staff>();

            foreach (var item in schedule)
            {
                if (item.Date == Calendar.SelectedDate)
                {
                    coachList.Add(item.Coach);
                    list.Add(item);
                }
            }

            foreach (var l in list)
            {
                Expander exp;
                StackPanel spCoach = null;
                ListView listView = new ListView();
                foreach (var c in coachList)
                {
                    if (l.Coach.Id == c.Id)
                    {
                        if (spCoach is null)
                        {
                            spCoach = new StackPanel();

                            spCoach.Children.Add(new Ellipse
                            {
                                Width = 50,
                                Height = 50,
                                Fill = new ImageBrush
                                {
                                    ImageSource = new BitmapImage(new Uri(Utillity.GetInstance().ByteToImage(c.ProfileImg)))
                                }
                            });

                            spCoach.Children.Add(new TextBlock
                            {
                                Text = c.Name + " " + c.SurName,
                                VerticalAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(15, 0, 0, 0)
                            });
                        }

                        listView.Items.Add(new TextBlock { });//....

                        exp = new Expander
                        {
                            Header = spCoach,
                            Content =
                        };

                        CoachesPanel.Children.Add(exp);
                    }
                }
            }

        }

        //private void Month_Click(object sender, RoutedEventArgs e) => SetMonth(int.Parse(MonthTb.DataContext.ToString()) + int.Parse(((sender as Button).DataContext.ToString())));
    }
}
