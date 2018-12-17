namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelateMovieTableToNotifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "MovieId");
            AddForeignKey("dbo.Notifications", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "MovieId", "dbo.Movies");
            DropIndex("dbo.Notifications", new[] { "MovieId" });
            DropColumn("dbo.Notifications", "MovieId");
        }
    }
}
