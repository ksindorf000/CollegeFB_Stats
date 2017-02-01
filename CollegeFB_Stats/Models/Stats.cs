using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFB_Stats.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public string Season { get; set; }
        
        //Virtual Accessers
        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
        
        //Rushing Stats
        public int CAR { get; set; } = 0;
        public int YDS_Rush { get; set; } = 0;
        public double AVG_Rush { get; set; } = 0;
        public int LONG_Rush { get; set; } = 0;
        public int TD_Rush { get; set; } = 0;

        //Passing Stats
        public int CMP { get; set; } = 0;
        public int ATT { get; set; } = 0;
        public int YDS_Pass { get; set; } = 0;
        public double CMP_Percent { get; set; } = 0;
        public double YDS_A { get; set; } = 0;
        public int TD_Pass { get; set; } = 0;
        public int INT { get; set; } = 0;
        public double RAT { get; set; } = 0;

        //Receiving Stats
        public int REC { get; set; } = 0;
        public int YDS_Rec { get; set; } = 0;
        public double AVG_Rec { get; set; } = 0;
        public int LONG_Rec { get; set; } = 0;

        //Kicking Stats
        public int XPM { get; set; } = 0;
        public int XPA { get; set; } = 0;
        public double XP_Percent { get; set; } = 0;
        public int FGM { get; set; } = 0;
        public int FGA { get; set; } = 0;
        public double FG_Percent { get; set; } = 0;
        public int UnderTwenty { get; set; } = 0;
        public int TwentyToTwentyNine { get; set; } = 0;
        public int ThirtyToThirtyNine { get; set; } = 0;
        public int FourtyToFourtyNine { get; set; } = 0;
        public int FiftyUp { get; set; } = 0;
        public int LNG { get; set; } = 0;
        public int PTS { get; set; } = 0;
    }
}
