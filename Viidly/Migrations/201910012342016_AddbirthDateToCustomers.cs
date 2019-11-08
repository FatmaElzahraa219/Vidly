namespace Viidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddbirthDateToCustomers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
