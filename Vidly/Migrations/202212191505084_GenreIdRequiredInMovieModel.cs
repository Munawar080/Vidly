namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreIdRequiredInMovieModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte());
        }
    }
}
