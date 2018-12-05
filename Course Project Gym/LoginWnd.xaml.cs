using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Shapes;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for LoginWnd.xaml
    /// </summary>
    public partial class LoginWnd : Window
    {
        private MainWindow Main;
        public bool IsOpenSingIn { private get; set; } = false;

        public LoginWnd()
        {
            InitializeComponent();

            using (DBContext ctx = new DBContext())
            {
                var cpx = ctx.Complexes.ToList();
                var staff = ctx.Staffs.ToList();
                var shed = ctx.Schedules.ToList();
                var add = ctx.AdditionalServices.ToList();
                ;
            }
        }
        
        private static string GetHash(string data) //MD5 хеширование паролей
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.Default.GetBytes(data));

            StringBuilder builder = new StringBuilder();

            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }

        private void PowerBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        } //закрытие окна

        private void EnterLogBtn_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(244, 67, 54));

            if (emailTb.Text.Equals(string.Empty))
            {
                packIcon1.Foreground = brush;
                packIcon1.Opacity = 1;
                return;
            }
            else if(passBox.Password.Equals(string.Empty))
            {
                packIcon2.Foreground = brush;
                packIcon2.Opacity = 1;
                return;
            }
            else
            {
                AccountRepository accountRepository = AccountRepository.GetInstance();

                var account = accountRepository.Get(emailTb.Text);
                if(account != null)
                {
                    if(account.Password.Equals(GetHash(passBox.Password)))
                    {
                        Main = new MainWindow();
                        Main.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password!\nPlease try again", "Error", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong email!\nPlease try again", "Error", MessageBoxButton.OK);
                }
            }
        } //Вход пользователя

        private void SingInBtn_Click(object sender, RoutedEventArgs e)
        {
            #region Animation
            if (!IsOpenSingIn)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation { From = 400, To = 0, Duration = TimeSpan.FromMilliseconds(450) };
                loginGrid.BeginAnimation(HeightProperty, doubleAnimation);
                
                DoubleAnimation doubleAnimation1 = new DoubleAnimation { From = 0, To = 600, Duration = TimeSpan.FromMilliseconds(450) };
                singInGrid.BeginAnimation(HeightProperty, doubleAnimation1);
                IsOpenSingIn = true;
                SingInBtn.Content = "Login";
            }
            else
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation {To = 400, Duration = TimeSpan.FromMilliseconds(450) };
                loginGrid.BeginAnimation(HeightProperty, doubleAnimation);
                
                DoubleAnimation doubleAnimation1 = new DoubleAnimation { To = 0, Duration = TimeSpan.FromMilliseconds(450) };
                singInGrid.BeginAnimation(HeightProperty, doubleAnimation1);
                IsOpenSingIn = false;
                SingInBtn.Content = "Sing In";
            }
            #endregion


            //регистрация...
        }
    }
}
