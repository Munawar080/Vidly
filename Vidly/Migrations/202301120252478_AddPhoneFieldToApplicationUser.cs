using System;
using System.Data.Entity.Migrations;

namespace Vidly.Migrations
{
    
    public partial class AddPhoneFieldToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
