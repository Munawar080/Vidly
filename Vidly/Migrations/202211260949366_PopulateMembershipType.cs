namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, DurationInMonth, DiscountRate, SignUpFree)  VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id, DurationInMonth, DiscountRate, SignUpFree)  VALUES (2,1,10,30)");
            Sql("INSERT INTO MembershipTypes (Id, DurationInMonth, DiscountRate, SignUpFree)  VALUES (3,3,15,90)");
            Sql("INSERT INTO MembershipTypes (Id, DurationInMonth, DiscountRate, SignUpFree)  VALUES (4,12,20,300)");
        }
        
        public override void Down()
        {
        }
    }
}
