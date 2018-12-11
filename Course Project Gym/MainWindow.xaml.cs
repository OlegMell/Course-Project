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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Course_Project_Gym.DataBase.Repositories;
using HamburgerMenu;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += (s, r) =>
            {
                textNewsTbock.Text = NewsRepository.GetInstance().GetLast().About;
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
