using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel.DataAnnotations;

namespace Lab1_MLS.Models
{
    public class PlayerModel 
    {        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public string Club { get; set; }

        
    }
}
