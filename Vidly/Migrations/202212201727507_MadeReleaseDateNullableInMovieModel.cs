namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeReleaseDateNullableInMovieModel : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies ADD ReleaseDate DateTime");
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
