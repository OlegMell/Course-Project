﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class Address
    {
        public int Id { get; set; }

        virtual public City City { get; set; }
        virtual public Streets Street { get; set; }
        public string House { get; set; }
    }
}
