namespace VidlyPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cdbdf35e-8172-4183-a90d-f17d7f248b4d', N'guest@vidly.com', 0, N'AIc5a+YJ2U3jCCIDtZ9IZZ4tZDi5DI49kN8SKQF8mfhGbsmAxHYyz+bBVPfSMR0LJQ==', N'4033c3eb-1ed4-4854-9b88-a54414ceed7d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd066ed14-bf88-434b-a00c-a1e7d229f87c', N'admin@vidly.com', 0, N'AGdAEoNyVpie3s4EQ0iN2kQyMXmTTqsJzEUUF0zGh/QdjNnidWaXIIxtUKMtFVPvBQ==', N'36a047c8-0e28-459f-a3ea-bb62862acf1e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b0f41d29-7d66-449a-9200-de22e4ddc029', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cdbdf35e-8172-4183-a90d-f17d7f248b4d', N'b0f41d29-7d66-449a-9200-de22e4ddc029')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd066ed14-bf88-434b-a00c-a1e7d229f87c', N'b0f41d29-7d66-449a-9200-de22e4ddc029')

");
        }
        
        public override void Down()
        {
        }
    }
}
