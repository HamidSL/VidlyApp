namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieGenresMovieRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieGenresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenresId");
            AddForeignKey("dbo.Movies", "MovieGenresId", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenresId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenresId" });
            DropColumn("dbo.Movies", "MovieGenresId");
        }
    }
}
