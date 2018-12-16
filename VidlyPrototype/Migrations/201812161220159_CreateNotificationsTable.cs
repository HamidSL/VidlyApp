namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNotificationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Message = c.String(nullable: false),
                        DateReceived = c.DateTime(nullable: false),
                        DateRead = c.DateTime(nullable: false),
                        HasBeenRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropTable("dbo.Notifications");
        }
    }
}
