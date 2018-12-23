using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddServicesWnd.xaml
    /// </summary>
    public partial class AddServicesWnd : Window
    {
        public AdditionalServicesRepository ServicesRep { get; set; }
        public AdditionalServices NewServices { get; set; }
        public AddServicesWnd()
        {
            InitializeComponent();
        }

        private void AddFinallyBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(ServicesNameTb.Text)&& !string.IsNullOrEmpty(ServicesPriceTb.Text))
            {
                NewServices = new AdditionalServices
                {
                    Name = ServicesNameTb.Text,
                    Price = float.Parse(ServicesPriceTb.Text)
                };
            }
            else
            {
                return;
            }
            ServicesRep.Add(NewServices);
            Close();
        }
    }
}
