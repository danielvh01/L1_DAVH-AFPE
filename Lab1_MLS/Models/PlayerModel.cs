using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Lab1_MLS.Models
{
    public class PlayerModel 
    {        

        public string Name { get; set; }

        public string LastName { get; set; }
        
        public string Position { get; set; }

        public double Salary { get; set; }

        public string Club { get; set; }

        
    }
}
