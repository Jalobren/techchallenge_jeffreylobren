namespace RaceDay.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RaceDayMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        HorseId = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                        Stake = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.HorseId, t.RaceId })
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Horses", t => t.HorseId)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .Index(t => t.CustomerId)
                .Index(t => t.HorseId)
                .Index(t => t.RaceId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Horses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Odds = c.Decimal(precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RaceHorses",
                c => new
                    {
                        HorseID = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HorseID, t.RaceId })
                .ForeignKey("dbo.Horses", t => t.HorseID, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.HorseID)
                .Index(t => t.RaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RaceHorses", "RaceId", "dbo.Races");
            DropForeignKey("dbo.RaceHorses", "HorseID", "dbo.Horses");
            DropForeignKey("dbo.Bets", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Bets", "HorseId", "dbo.Horses");
            DropForeignKey("dbo.Bets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.RaceHorses", new[] { "RaceId" });
            DropIndex("dbo.RaceHorses", new[] { "HorseID" });
            DropIndex("dbo.Bets", new[] { "RaceId" });
            DropIndex("dbo.Bets", new[] { "HorseId" });
            DropIndex("dbo.Bets", new[] { "CustomerId" });
            DropTable("dbo.RaceHorses");
            DropTable("dbo.Races");
            DropTable("dbo.Horses");
            DropTable("dbo.Customers");
            DropTable("dbo.Bets");
        }
    }
}
