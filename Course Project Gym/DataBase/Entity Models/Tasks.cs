using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Course_Project_Gym.DataBase
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string ColorName { get; set; } = "White";
        [NotMapped]
        public SolidColorBrush BrushColor { get => new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorName)); } //ошибка
    }
}
