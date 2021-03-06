﻿using System;
using Course_Project_Gym.DataBase;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using Course_Project_Gym.DataBase.Utillities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Course_Project_Gym
{
    /// <summary>
    /// Interaction logic for ScheduleOfOneUc.xaml
    /// </summary>
    public partial class ScheduleOfOneUc : UserControl
    {
        public Schedules Schedule { get; set; }

        public ScheduleOfOneUc(Schedules schedule)
        {
            DataContext = this;
            InitializeComponent();
            
            Schedule = schedule;
            BitmapImage bit = new BitmapImage(new Uri(Path.GetFullPath(Utillity.GetInstance().ByteToImage(Schedule.Coach.ProfileImg))));
            ProfileImg.ImageSource = bit;
            ProfileNameTb.Text = $"{Schedule.Coach.Name} {Schedule.Coach.SurName}";
            TimeStart.Text = Schedule.TimeStart.ToShortTimeString();
            Duration.Text = Schedule.Duration.ToString() + ".h";
        }
    }
}
