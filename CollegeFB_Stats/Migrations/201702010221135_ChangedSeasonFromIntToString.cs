namespace CollegeFB_Stats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSeasonFromIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stats", "Season", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stats", "Season", c => c.Int(nullable: false));
        }
    }
}
