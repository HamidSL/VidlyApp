namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToMoviesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NoInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NoInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
