using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using System.ComponentModel;
using System.Windows;


namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for ClientsWnd.xaml
    /// </summary>
    public partial class ClientsWnd : Window
    {
        public BindingList<Clients> Clients { get; set; }
        public ClientsWnd()
        {
            InitializeComponent();
            Clients = new BindingList<Clients>();
            DataContext = this;
            SetList();
        }
        
        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClientWnd addClientWnd = new AddClientWnd();
            addClientWnd.ShowDialog();
            if(addClientWnd.IsAdded)
            {
                SetList();
            }
        }

        private void SetList()
        {
            Clients.Clear();
            foreach (var item in ClientsRepository.GetInstance().GetAll())
            {
                Clients.Add(item as Clients);
            }
        }

        private void CheckClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewSubscription_Click(object sender, RoutedEventArgs e)
        {
            //...
        }
    }
}
