using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using Course_Project_Gym.DataBase.Utillities;
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
            TestConnection();
            DataContext = this;
            InitializeComponent();
        }

        private void TestConnection() => AccountRepository.GetInstance().Get(1);

        private void CloseSignInPanel()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation { To = 400, Duration = TimeSpan.FromMilliseconds(450) };
            loginGrid.BeginAnimation(HeightProperty, doubleAnimation);

            DoubleAnimation doubleAnimation1 = new DoubleAnimation { To = 0, Duration = TimeSpan.FromMilliseconds(450) };
            singInGrid.BeginAnimation(HeightProperty, doubleAnimation1);
            IsOpenSingIn = false;
            SignInBtn.Content = "Sing In";
        } //анимация закрытия окна регистрации

        private void PowerBtn_Click(object sender, RoutedEventArgs e) => Close(); //закрытие окна

        private void EnterLogBtn_Click(object sender, RoutedEventArgs e) => OpenDashboard(); //Вход пользователя

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
                SignInBtn.Content = "Login";
            }
            else
            {
                CloseSignInPanel();
            }
            #endregion

            var complexes = ComplexRepository.GetInstance().GetAll();
            var positions = PositionRepository.GetInstance().GetAll();

            if (complexes.Count() != 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in complexes)
                {
                    builder.Append(item.Id + " " + item.Name + " " + item.Address.City.Name + " " + item.Address.Street.Name + " " + item.Address.House);
                    workPlaceRegCb.Items.Add(builder.ToString());
                }
            }

            if (positions.Count() != 0)
            {
                positionRegCb.ItemsSource = positions;
                positionRegCb.DisplayMemberPath = "Name";
            }

        } //открытие панели регистрации

        private void OkRegBtn_Click(object sender, RoutedEventArgs e)
        {
            Staff nStaff = new Staff
            {
                Name = nameRegTb.Text,
                SurName = surnameRegtb.Text,
                PhoneNumber = phoneRegTb.Text,
                WorkExperience = float.Parse(workRegTb.Text),
                Account = new Accounts
                {
                    Password = passRegTb.Password,
                    Login = emailRegTb.Text
                },
                Position = PositionRepository.GetInstance().Get((positionRegCb.SelectedItem as Position).Id),
                Complex = ComplexRepository.GetInstance().Get(int.Parse(workPlaceRegCb.SelectedItem.ToString().ToArray().First().ToString()))
            };
            StaffRepository.GetInstance().Add(nStaff);

            CloseSignInPanel();
        } //регистрация пользователя

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                OpenDashboard();
            }
        }

        private void OpenDashboard()
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(244, 67, 54));

            if (emailTb.Text.Equals(string.Empty))
            {
                packIcon1.Foreground = brush;
                packIcon1.Opacity = 1;
                return;
            }
            else if (passBox.Password.Equals(string.Empty))
            {
                packIcon2.Foreground = brush;
                packIcon2.Opacity = 1;
                return;
            }
            else
            {
                AccountRepository accountRepository = AccountRepository.GetInstance();
                var account = accountRepository.Get(emailTb.Text);
                if (account != null)
                {
                    if (account.Password.Equals(Utillity.GetInstance().GetHash(passBox.Password)))
                    {
                        Complex cmpl = new Complex();

                        var cmplx = ComplexRepository.GetInstance().GetAll();
                        foreach (var item in cmplx)
                        {
                            var staff = item.Staffs.ToList();
                            foreach (var s in staff)
                            {
                                if (s.Account.Login.Equals(account.Login))
                                {
                                    cmpl = item;
                                    break;
                                }
                            }
                        }

                        Main = new MainWindow { CurrentComplex = cmpl };
                        Main.StatusBar.Items.Add(new TextBlock
                        {
                            Text = $"{cmpl.Name + " " + cmpl.Address.City.Name + " " + cmpl.Address.Street.Name + " " + cmpl.Address.House}",
                            HorizontalAlignment = HorizontalAlignment.Right,
                            Margin = new Thickness(500, 0, 0, 0)
                        });
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
        } //открытие главного окна 
    }
}
