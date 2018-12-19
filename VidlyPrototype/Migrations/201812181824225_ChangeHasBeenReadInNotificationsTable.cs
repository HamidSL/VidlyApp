namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeHasBeenReadInNotificationsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "HasBeenRead", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "HasBeenRead", c => c.Boolean(nullable: false));
        }
    }
}
