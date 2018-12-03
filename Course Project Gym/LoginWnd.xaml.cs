using Course_Project_Gym.DataBase;
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
    /// Interaction logic for LoginWnd.xaml
    /// </summary>
    public partial class LoginWnd : Window
    {
        public LoginWnd()
        {
            InitializeComponent();

            using (DBContext ctx = new DBContext())
            {
                var cpx = ctx.Complexes.ToList();
                var staff = ctx.Staffs.ToList();
            }
        }

        private void PowerBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
