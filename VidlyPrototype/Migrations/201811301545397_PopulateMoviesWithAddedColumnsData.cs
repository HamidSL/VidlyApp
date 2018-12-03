namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesWithAddedColumnsData : DbMigration
    {
        public override void Up()
        {
            //asib oct 4 2018
            //bp feb 16 2018
            //aviw apr 27 2018
            //rir2 nov 21 2018
            //getout feb 24 2017
            //madmax may 15 2015
            //toystory apr 19 1996
            //titanic nov 18 1997
            //hsm jan 20 2006
            Sql("UPDATE Movies SET ReleaseDate = '4 oct 2018', DateAdded = '"+ DateTime.Now +"', NoInStock = '10' WHERE Id = 1");
            Sql("UPDATE Movies SET ReleaseDate = '16 feb 2018', DateAdded = '" + DateTime.Now + "', NoInStock = '20' WHERE Id = 2");
            Sql("UPDATE Movies SET ReleaseDate = '27 apr 2018', DateAdded = '" + DateTime.Now + "', NoInStock = '15' WHERE Id = 3");
            Sql("UPDATE Movies SET ReleaseDate = '21 nov 2018', DateAdded = '" + DateTime.Now + "', NoInStock = '12' WHERE Id = 4");
            Sql("UPDATE Movies SET ReleaseDate = '24 feb 2017', DateAdded = '" + DateTime.Now + "', NoInStock = '13' WHERE Id = 6");
            Sql("UPDATE Movies SET ReleaseDate = '15 may 2015', DateAdded = '" + DateTime.Now + "', NoInStock = '5' WHERE Id = 5");
            Sql("UPDATE Movies SET ReleaseDate = '19 apr 1996', DateAdded = '" + DateTime.Now + "', NoInStock = '8' WHERE Id = 8");
            Sql("UPDATE Movies SET ReleaseDate = '18 nov 1997', DateAdded = '" + DateTime.Now + "', NoInStock = '6' WHERE Id = 7");
            Sql("UPDATE Movies SET ReleaseDate = '20 jan 2006', DateAdded = '" + DateTime.Now + "', NoInStock = '6' WHERE Id = 9");

        }

        public override void Down()
        {
        }
    }
}
