namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoCreated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Created", c => c.DateTime(nullable: false, defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Created", c => c.DateTime(nullable: false));
        }
    }
}
