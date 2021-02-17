using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel.DataAnnotations;

namespace Lab1_MLS.Models
{
    public class PlayerModel : IComparable
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

        [Required]
        public double Compensation { get; set; }

        public int CompareTo(object obj)
        {
            var comparer = ((PlayerModel)obj).Id;
            return comparer < Id ? -1 : comparer == Id ? 0 : 1;
        }

        public static Comparison<PlayerModel> SortByID = delegate (PlayerModel p1, PlayerModel p2)
        {
            return p1.CompareTo(p2);
        };

        public static Comparison<PlayerModel> SortByName = delegate (PlayerModel p1, PlayerModel p2)
        {
            return p1.Name.CompareTo(p2.Name);
        };
        
        public static Comparison<PlayerModel> SortByLastName = delegate (PlayerModel p1, PlayerModel p2)
        {
            return p1.LastName.CompareTo(p2.LastName);
        };

        public static Comparison<PlayerModel> SortByPosition = delegate (PlayerModel p1, PlayerModel p2)
        {
            return p1.Position.CompareTo(p2.Position);
        };

        public static Comparison<PlayerModel> SortBySalary = delegate (PlayerModel p1, PlayerModel p2)
        {
            return p1.Salary.CompareTo(p2.Salary);
        };

        public static Comparison<PlayerModel> SortByClub = delegate (PlayerModel p1, PlayerModel p2)
        {
            return p1.Club.CompareTo(p2.Club);
        };

    }
}
