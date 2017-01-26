namespace CollegeFB_Stats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAKickingStatFromDoubleToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stats", "TwentyToTwentyNine", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stats", "TwentyToTwentyNine", c => c.Double(nullable: false));
        }
    }
}
