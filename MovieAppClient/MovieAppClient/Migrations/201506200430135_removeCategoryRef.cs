namespace MovieAppClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCategoryRef : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Movies", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Movies", "Category_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Category_Id");
            AddForeignKey("dbo.Movies", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "Category_Id" });
            AlterColumn("dbo.Movies", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Movies", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Movies", "CategoryId");
            AddForeignKey("dbo.Movies", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
