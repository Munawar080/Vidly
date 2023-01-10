namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRolesTables : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'7553553b-2ab5-42a9-a078-feb83ee66ac2', N'Adminrole', N'AEKSSUhQ3G0mB5WmDPDamnCUKqKxyFckwbwWFwZJk+23F8idXr0eiijLk7+NMu/UGQ==', N'b6173705-5851-4c41-9993-6043d4d6fc7e', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'e883e262-903e-40bd-81c1-04632dde2b0c', N'GuestRole', N'AB7O4aKdgM1FDD7PXzht5GZv9dgfvd0TntX+25ZoCPGL2sAor3MUEHxdMyqZGtjfLg==', N'6a839d60-dfde-4ed0-bfc5-ff23ee69eaaf', N'ApplicationUser')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'10f0e8cb-0d54-4aa9-8abd-9e57ee9045d2', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7553553b-2ab5-42a9-a078-feb83ee66ac2', N'10f0e8cb-0d54-4aa9-8abd-9e57ee9045d2')

");
        }
        
        public override void Down()
        {
        }
    }
}
