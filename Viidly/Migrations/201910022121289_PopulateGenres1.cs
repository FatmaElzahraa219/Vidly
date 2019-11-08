namespace Viidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres1 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");

        }

        public override void Down()
        {
        }
    }
}
