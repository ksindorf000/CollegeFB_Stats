namespace CollegeFB_Stats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        Age = c.Int(nullable: false),
                        Class = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        CAR = c.Int(nullable: false),
                        YDS_Rush = c.Int(nullable: false),
                        AVG_Rush = c.Double(nullable: false),
                        LONG_Rush = c.Int(nullable: false),
                        TD_Rush = c.Int(nullable: false),
                        CMP = c.Int(nullable: false),
                        ATT = c.Int(nullable: false),
                        YDS_Pass = c.Int(nullable: false),
                        CMP_Percent = c.Double(nullable: false),
                        YDS_A = c.Double(nullable: false),
                        TD_Pass = c.Int(nullable: false),
                        INT = c.Int(nullable: false),
                        RAT = c.Double(nullable: false),
                        REC = c.Int(nullable: false),
                        YDS_Rec = c.Int(nullable: false),
                        AVG_Rec = c.Double(nullable: false),
                        LONG_Rec = c.Int(nullable: false),
                        XPM = c.Int(nullable: false),
                        XPA = c.Int(nullable: false),
                        XP_Percent = c.Double(nullable: false),
                        FGM = c.Int(nullable: false),
                        FGA = c.Int(nullable: false),
                        FG_Percent = c.Double(nullable: false),
                        UnderTwenty = c.Int(nullable: false),
                        TwentyToTwentyNine = c.Double(nullable: false),
                        ThirtyToThirtyNine = c.Int(nullable: false),
                        FourtyToFourtyNine = c.Int(nullable: false),
                        FiftyUp = c.Int(nullable: false),
                        LNG = c.Int(nullable: false),
                        PTS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        YearFormed = c.Int(nullable: false),
                        HeadCoach = c.String(),
                        CityState = c.String(),
                        League = c.String(),
                        Mascot = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stats", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Stats", "PlayerId", "dbo.Players");
            DropIndex("dbo.Stats", new[] { "TeamId" });
            DropIndex("dbo.Stats", new[] { "PlayerId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Stats");
            DropTable("dbo.Players");
        }
    }
}
