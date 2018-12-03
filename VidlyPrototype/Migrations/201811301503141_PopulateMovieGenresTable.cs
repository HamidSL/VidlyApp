namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres(Name) VALUES('horror')");
            Sql("INSERT INTO MovieGenres(Name) VALUES('comedy')");
            Sql("INSERT INTO MovieGenres(Name) VALUES('action')");
            Sql("INSERT INTO MovieGenres(Name) VALUES('adventure')");
            Sql("INSERT INTO MovieGenres(Name) VALUES('family')");
            Sql("INSERT INTO MovieGenres(Name) VALUES('sci-fi')");
            Sql("INSERT INTO MovieGenres(Name) VALUES('romance')");
            Sql("INSERT INTO MovieGenres(Name) VALUES('musical')");

        }

        public override void Down()
        {
        }
    }
}
