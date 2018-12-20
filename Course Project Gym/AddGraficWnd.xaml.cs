using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
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
using System.Windows.Shapes;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for AddGraficWnd.xaml
    /// </summary>
    public partial class AddGraficWnd : Window, INotifyPropertyChanged
    {
        public List<Staff> Coach { get; set; }
        private List<Schedules> schedules = new List<Schedules>();
        public List<Schedules> Schedules
        {
            get
            {
                return schedules;
            }
            set
            {
                schedules = value;
                OnPropertyChanged("Schedules");
            }
        }

        public AddGraficWnd()
        {
            DataContext = this;

            foreach (var item in StaffRepository.GetInstance().GetAll())
            {
                if (item.Position.Name.Equals("Coach"))
                {
                    Coach.Add(item);
                }
            }
            InitializeComponent();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void AddFinallyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewsNameCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in SchedulesRepository.GetInstance().GetAll())
            {
                if (item.Coach.Id == ((sender as ComboBox).SelectedItem as Staff).Id)
                {
                    Schedules.Add(item);
                }
            }
        }
    }
}
