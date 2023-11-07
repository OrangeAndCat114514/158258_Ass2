namespace Ass2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyPendingChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Score", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Score", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
