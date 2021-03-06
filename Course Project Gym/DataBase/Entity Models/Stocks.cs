﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class Stocks
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public float AmountOfDiscount { get; set; }
        public string About { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        virtual public AdditionalServices AdditionalService { get; set; }

    }
}
