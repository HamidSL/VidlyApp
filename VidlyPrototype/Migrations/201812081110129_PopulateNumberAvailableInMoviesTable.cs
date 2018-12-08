namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNumberAvailableInMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberAvailable = NoInStock");
        }
        
        public override void Down()
        {
        }
    }
}
