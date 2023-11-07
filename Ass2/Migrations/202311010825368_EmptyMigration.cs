namespace Ass2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Score", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Score", c => c.String());
        }
    }
}
