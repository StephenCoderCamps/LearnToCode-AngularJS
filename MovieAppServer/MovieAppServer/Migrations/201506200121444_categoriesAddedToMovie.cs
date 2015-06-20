namespace MovieAppServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoriesAddedToMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Movies", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Movies", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "CategoryId");
            AddForeignKey("dbo.Movies", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            AlterColumn("dbo.Movies", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Movies", "Category_Id");
            AddForeignKey("dbo.Movies", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
