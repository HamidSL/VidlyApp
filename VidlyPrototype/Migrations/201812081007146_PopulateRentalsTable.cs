namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRentalsTable : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Rentals(CustomerId, MovieId, DateRented,DateReturned) VALUES(1, 1, '"+DateTime.Now+"','10 dec 2018')");
            //Sql("INSERT INTO Rentals(CustomerId, MovieId, DateRented,DateReturned) VALUES(2, 2, '"+DateTime.Now+"','12 dec 2018')");
            //Sql("INSERT INTO Rentals(CustomerId, MovieId, DateRented,DateReturned) VALUES(2, 6, '"+DateTime.Now+"','15 dec 2018')");
            //Sql("INSERT INTO Rentals(CustomerId, MovieId, DateRented,DateReturned) VALUES(3, 9, '"+DateTime.Now+"','16 dec 2018')");


        }

        public override void Down()
        {
        }
    }
}
