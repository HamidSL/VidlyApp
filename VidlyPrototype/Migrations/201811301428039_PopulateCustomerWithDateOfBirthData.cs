namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerWithDateOfBirthData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET DateOfBirth = '1 Jan 1996' WHERE Id = 1");
            Sql("UPDATE Customers SET DateOfBirth = '1 Apr 1998' WHERE Id = 3");

        }

        public override void Down()
        {
        }
    }
}
