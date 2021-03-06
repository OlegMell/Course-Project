﻿using Course_Project_Gym;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HamburgerMenu
{
    /// <summary>
    /// Interaction logic for HumburgerMenu.xaml
    /// </summary>
    public partial class HumburgerMenu : UserControl, INotifyPropertyChanged
    {
        private Visibility stateClosed = Visibility.Collapsed;
        public Visibility StateClosed
        {
            get
            {
                return stateClosed;
            }
            set
            {
                stateClosed = value;
                OnPropertyChanged("StateClosed");
            }
        }

        public HumburgerMenu()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            if (StateClosed == Visibility.Collapsed)
            {
                StateClosed = Visibility.Visible;
                Storyboard sb = FindResource("OpenMenu") as Storyboard;
                sb.Begin();
                GridMenu.Opacity = 1;
            }
            else
            {
                StateClosed = Visibility.Collapsed;
                Storyboard sb = FindResource("CloseMenu") as Storyboard;
                sb.Begin();
                GridMenu.Opacity = 0.4;
            }
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsWnd clientsWnd = new ClientsWnd();
            clientsWnd.ShowDialog();
        }
    }
}
