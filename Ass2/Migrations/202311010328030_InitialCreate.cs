namespace Ass2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Score = c.String(),
                        URL = c.String(),
                        MovieCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MovieCategories", t => t.MovieCategoryID)
                .Index(t => t.MovieCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieCategoryID", "dbo.MovieCategories");
            DropIndex("dbo.Movies", new[] { "MovieCategoryID" });
            DropTable("dbo.Movies");
            DropTable("dbo.MovieCategories");
        }
    }
}
