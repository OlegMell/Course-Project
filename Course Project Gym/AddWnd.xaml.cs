using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using Course_Project_Gym.DataBase.Utillities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for AddWnd.xaml
    /// </summary>
    public partial class AddWnd : Window
    {
        private bool IsSetImage { get; set; }
        public NewsRepository NewRep { get; set; } = NewsRepository.GetInstance();
        private OpenFileDialog openFile;
        private Complex CurrentComplex;
        public News NewsNew { get; set; }

        public AddWnd(Complex complex)
        {
            InitializeComponent();
            CurrentComplex = complex;
        }
        
        private void ImgSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IsSetImage = true;
            }
        }

        private void AddFinallyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NewsNameTb.Text) && !string.IsNullOrEmpty(NewsAboutTb.Text))
            {
                NewsNew = new News
                {
                    Name = NewsNameTb.Text,
                    About = NewsAboutTb.Text,
                    DateNews = DateTime.Now,
                    Complex = CurrentComplex
                };

                if (IsSetImage)
                {
                    NewsNew.Image = Utillity.GetInstance().ImageToByte(openFile.FileName);
                }
            }
            else
            {
                return;
            }

            NewRep.Add(NewsNew);
            Close();
        }
    }
}
