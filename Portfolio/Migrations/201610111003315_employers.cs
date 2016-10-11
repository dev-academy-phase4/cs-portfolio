namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Jobs", "Employer_Id", c => c.Int());
            CreateIndex("dbo.Jobs", "Employer_Id");
            AddForeignKey("dbo.Jobs", "Employer_Id", "dbo.Employers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "Employer_Id", "dbo.Employers");
            DropIndex("dbo.Jobs", new[] { "Employer_Id" });
            DropColumn("dbo.Jobs", "Employer_Id");
            DropTable("dbo.Employers");
        }
    }
}
