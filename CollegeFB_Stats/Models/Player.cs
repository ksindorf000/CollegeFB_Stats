using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public string Class { get; set; } //True Fr, RedShirt Fr, Sr etc.

        public override string ToString()
        {
            return $"ID: {Id} NAME:{Name}";
        }

    }
}
