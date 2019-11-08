namespace Viidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            Sql("SET IDENTITY_INSERT Genres ON INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            Sql("SET IDENTITY_INSERT Genres ON INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            Sql("SET IDENTITY_INSERT Genres ON INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");
            
        }
        
        public override void Down()
        {
        }
    }
}
