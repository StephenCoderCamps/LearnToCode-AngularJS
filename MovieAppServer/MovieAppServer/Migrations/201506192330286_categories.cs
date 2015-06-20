namespace MovieAppServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "Category_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Category_Id");
            AddForeignKey("dbo.Movies", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "Category_Id" });
            DropColumn("dbo.Movies", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
