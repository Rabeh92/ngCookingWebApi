namespace ngCookingWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationRelationBetweenRecetteAndIngredientTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recette_Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false),
                        RecetteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IngredientId, t.RecetteId })
                .ForeignKey("dbo.Recettes", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.RecetteId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.RecetteId);
            
            AlterColumn("dbo.Recettes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Recettes", "UserId");
            AddForeignKey("dbo.Recettes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recettes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recette_Ingredients", "RecetteId", "dbo.Ingredients");
            DropForeignKey("dbo.Recette_Ingredients", "IngredientId", "dbo.Recettes");
            DropIndex("dbo.Recette_Ingredients", new[] { "RecetteId" });
            DropIndex("dbo.Recette_Ingredients", new[] { "IngredientId" });
            DropIndex("dbo.Recettes", new[] { "UserId" });
            AlterColumn("dbo.Recettes", "UserId", c => c.String());
            DropTable("dbo.Recette_Ingredients");
        }
    }
}
