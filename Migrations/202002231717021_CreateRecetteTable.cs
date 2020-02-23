namespace ngCookingWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRecetteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsAvailable = c.Boolean(nullable: false),
                        Picture = c.String(),
                        CategorieId = c.Int(nullable: false),
                        Calorie = c.Int(nullable: false),
                        Description = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategorieIngredients", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IngredientNameIndex")
                .Index(t => t.CategorieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "CategorieId", "dbo.CategorieIngredients");
            DropIndex("dbo.Ingredients", new[] { "CategorieId" });
            DropIndex("dbo.Ingredients", "IngredientNameIndex");
            DropTable("dbo.Ingredients");
        }
    }
}
