namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMovieDateValueToCurrentDateTime : DbMigration
    {
        public override void Up()
        {
            //Sql("ALTER TABLE Movies ALTER COLUMN DateAdded DEFAULT NOW()");
        }
        
        public override void Down()
        {
        }
    }
}
