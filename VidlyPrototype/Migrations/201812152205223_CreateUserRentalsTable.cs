namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserRentalsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Movie_Id = c.Int(nullable: false),
                        Users_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRentals", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.UserRentals", new[] { "Users_Id" });
            DropIndex("dbo.UserRentals", new[] { "Movie_Id" });
            DropTable("dbo.UserRentals");
        }
    }
}
