namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateReadPropertyInNotificationsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "DateRead", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "DateRead", c => c.DateTime(nullable: false));
        }
    }
}
