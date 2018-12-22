namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPosterAndTMDBIdToMoviesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "TMdbId", c => c.Int());
            AddColumn("dbo.Movies", "PosterImage", c => c.String());
            AddColumn("dbo.Movies", "Summary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Summary");
            DropColumn("dbo.Movies", "PosterImage");
            DropColumn("dbo.Movies", "TMdbId");
        }
    }
}
