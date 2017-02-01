using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearFormed { get; set; }
        public string HeadCoach { get; set; }
        public string CityState { get; set; }
        public string League { get; set; }
        public string Mascot { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} NAME: {Name} {Mascot}";
        }

    }
}
