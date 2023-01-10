namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockNumberAvailablePropInMovieModel : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies ADD Stock int, NumberAvailable tinyint;");
        }
        
        public override void Down()
        {
        }
    }
}
