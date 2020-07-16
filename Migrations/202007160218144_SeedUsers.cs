namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3435489c-2723-46a4-8bd1-e318c2450888', N'admin@vidly.com', 0, N'AD+nEz5ULKYJSvVVbVcSpYzIEpfndZEjwl+mXkaNLyJ9YUHRtp5J7vekc4QHseC8XQ==', N'4283ec69-b99b-471e-98d8-bb8bae92babe', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'97fd8364-ffae-432c-978b-94cea782d4ca', N'guest@vidly.com', 0, N'ADMQfaCTUgb7BAGTwR5G/rrn46zvEggsqqIDlctsifm1iSGdjbJPwWuaf2fD1ZZoBw==', N'6da45e27-af22-4742-a7bb-9a93a5b9787d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'550cd7a2-2f21-4286-8369-419be1818419', N'CanManageMovies')               
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3435489c-2723-46a4-8bd1-e318c2450888', N'550cd7a2-2f21-4286-8369-419be1818419')       
                ");
        }
        
        public override void Down()
        {
        }
    }
}
