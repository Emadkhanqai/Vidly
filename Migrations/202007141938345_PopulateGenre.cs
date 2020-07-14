namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres  (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres  (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres  (Name) VALUES ('Family')");
            Sql("INSERT INTO Genres  (Name) VALUES ('Romance')");

            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
    }
}
