namespace BGMS_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinPlayersNum = c.Int(nullable: false),
                        MaxPlayersNum = c.Int(nullable: false),
                        MinimalPlayerAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameDisplayinformationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayTime = c.DateTime(nullable: false),
                        DisplaySource = c.String(),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameModels", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameDisplayinformationModels", "GameId", "dbo.GameModels");
            DropIndex("dbo.GameDisplayinformationModels", new[] { "GameId" });
            DropTable("dbo.GameDisplayinformationModels");
            DropTable("dbo.GameModels");
        }
    }
}
