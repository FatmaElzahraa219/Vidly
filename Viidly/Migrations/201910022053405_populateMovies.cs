namespace Viidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name,ReleaseDate,DateAdded,GenreId,NumInstock) VALUES (1, 'HangOver',10/6/2009,5/4/2016,5,5)");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name,ReleaseDate,DateAdded,GenreId,NumInstock) VALUES (2, 'Die Hard',10/7/2009,5/6/2017,1,3)");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name,ReleaseDate,DateAdded,GenreId,NumInstock) VALUES (3, 'The Terminator',10/1/2000,10/7/2005,1,2)");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name,ReleaseDate,DateAdded,GenreId,NumInstock) VALUES (4, 'ToyStory',10/1/2000,10/7/2005,3,10)");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name,ReleaseDate,DateAdded,GenreId,NumInstock) VALUES (5, 'Titanic',8/3/1999,10/9/2001,4,20)");

        }

        public override void Down()
        {
        }
    }
}
