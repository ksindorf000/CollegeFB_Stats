namespace CollegeFB_Stats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeasonToStats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stats", "Season", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stats", "Season");
        }
    }
}
