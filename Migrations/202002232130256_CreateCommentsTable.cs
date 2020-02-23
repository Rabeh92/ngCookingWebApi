namespace ngCookingWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCommentsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recettes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recettes", new[] { "UserId" });
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Mark = c.Int(nullable: false),
                        RecetteId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Recettes", t => t.RecetteId, cascadeDelete: true)
                .Index(t => t.RecetteId)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.Recettes", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Recettes", "UserId");
            AddForeignKey("dbo.Recettes", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recettes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "RecetteId", "dbo.Recettes");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "RecetteId" });
            DropIndex("dbo.Recettes", new[] { "UserId" });
            AlterColumn("dbo.Recettes", "UserId", c => c.String(maxLength: 128));
            DropTable("dbo.Comments");
            CreateIndex("dbo.Recettes", "UserId");
            AddForeignKey("dbo.Recettes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
