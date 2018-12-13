
using Course_Project_Gym.DataBase;
using Course_Project_Gym.DataBase.Repositories;
using Course_Project_Gym.DataBase.Utillities;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for AddNewsPanelUc.xaml
    /// </summary>

    public delegate void ClickHelper();
    public partial class AddNewsPanelUc : System.Windows.Controls.UserControl
    {
        public event ClickHelper ClickAddBtnD;
        public News AddedNews { get; set; }
        OpenFileDialog openFile;
        public AddNewsPanelUc()
        {
            InitializeComponent();
        }

        private void AddImageInNews_Click(object sender, RoutedEventArgs e)
        {
            openFile = new OpenFileDialog
            {
                Filter = "Image(*.jpg)|*.jpg",
                DefaultExt = "*.jpg",
                CheckFileExists = true,
                CheckPathExists = true
            };
        }

        private void AddFinallyBtn_Click(object sender, RoutedEventArgs e)
        {
            AddedNews = new News
            {
                Name = NewsNameTb.Text,
                About = NewsAboutTb.Text,
                DateNews = DateTime.Now
            };

            if (openFile != null)
            {
                if (!openFile.FileName.Equals(string.Empty))
                {
                    AddedNews.Image = Utillity.GetInstance().ImageToByte(openFile.SafeFileName);
                }
            }
            NewsRepository.GetInstance().Add(AddedNews);
        }
    }
}
