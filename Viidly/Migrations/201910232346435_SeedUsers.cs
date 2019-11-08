namespace Viidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4779e36c-efd3-4997-a13e-cce64a155aa8', N'admin@vidly.com', 0, N'AHrAjja+IGygSABIaojmREkdzXvAU9YGhusMytBGj0llcX0PSUb01B7sQ0rNwhtdCQ==', N'f1cb61db-14f3-4cea-bc99-6073589e639d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ca61cae8-fac8-4d33-b582-a1797e0a60ed', N'guest@vidly.com', 0, N'AGmWkkP8YQmiyLyxTA/iEChdM9cDdQbKhSW9zELKbl3CMRhUX4mO7Oo48o0m1XDiXg==', N'51dbbf1c-7988-4f77-ba91-4e36fd4fafe0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f604cdf1-f6d0-40fc-93a6-40c26c46f501', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4779e36c-efd3-4997-a13e-cce64a155aa8', N'f604cdf1-f6d0-40fc-93a6-40c26c46f501')

");
        }
        
        public override void Down()
        {
        }
    }
}
