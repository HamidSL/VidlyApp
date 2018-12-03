namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('a star is born', '2')");
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('black panther', '3')");
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('avengers:Infinity War', '3')");
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('wrek-It ralph', '2')");
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('mad max:Fury road', '3')");
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('get out', '1')");
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('titanic', '7')");
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('toy story', '2')");
            Sql("INSERT INTO Movies(Name, MovieGenresId) VALUES('high school musical', '8')");
        }

        public override void Down()
        {
        }
    }
}
