namespace Viidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumInStock", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "NumInStock");
        }
    }
}
