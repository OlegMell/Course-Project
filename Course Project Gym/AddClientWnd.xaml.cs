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
    /// Interaction logic for AddClientWnd.xaml
    /// </summary>
    public partial class AddClientWnd : Window
    {
        public ClientsRepository ClientRep { get; set; }
        public Clients NewClients { get; set; }
        public bool IsAdded { get; set; }
        public AddClientWnd()
        {
            InitializeComponent();

        }

        private void AddFinallyBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(ClientsNameTb.Text)&& !string.IsNullOrEmpty(ClientsSurNameTb.Text)&& !string.IsNullOrEmpty(ClientsPhoneTb.Text))
            {
                NewClients = new Clients
                {
                    Name = ClientsNameTb.Text,
                    SurName = ClientsSurNameTb.Text,
                    PhoneNumber = ClientsPhoneTb.Text
                };
            }
            else
            {
                return;
            }
            ClientRep.Add(NewClients);
            IsAdded = true;
            Close();
        }
    }
}
