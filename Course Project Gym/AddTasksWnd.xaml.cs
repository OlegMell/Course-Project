﻿using Course_Project_Gym.DataBase;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for AddTasksWnd.xaml
    /// </summary>
    public partial class AddTasksWnd : Window
    {
        public TasksRepository TaskRep { get; set; } = TasksRepository.GetInstance();
        private Complex CurrenComplex;
        public Tasks NewTasks { get; set; }
        private System.Windows.Controls.Button colorBtn;
        public bool IsAdded { get; set; }


        public AddTasksWnd(Complex complex)
        {
            InitializeComponent();
            CurrenComplex = complex;
        }

        private void AddFinallyBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(TasksNameTb.Text)&& !string.IsNullOrEmpty(TasksAboutTb.Text))
            {
                NewTasks = new Tasks
                {
                    Name = TasksNameTb.Text,
                    About = TasksAboutTb.Text
                };
                
                if(colorBtn != null)
                {
                    NewTasks.ColorName = colorBtn.DataContext.ToString();
                }
            }
            else
            {
                return;
            }
            TaskRep.Add(NewTasks);
            IsAdded = true;
            Close();
        }

        private void ColorBtn_Click(object sender, RoutedEventArgs e)
        {
            colorBtn = new System.Windows.Controls.Button();
            colorBtn = (sender as System.Windows.Controls.Button);
        }
    }
}
