namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMembershipTypesRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTypesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypesId");
            AddForeignKey("dbo.Customers", "MembershipTypesId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypesId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypesId" });
            DropColumn("dbo.Customers", "MembershipTypesId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
