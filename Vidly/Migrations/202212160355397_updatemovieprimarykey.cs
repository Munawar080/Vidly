namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemovieprimarykey : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies DROP CONSTRAINT [PK_dbo.Movies]");
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Id", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
