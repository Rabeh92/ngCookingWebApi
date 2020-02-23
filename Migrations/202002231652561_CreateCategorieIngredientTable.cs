namespace ngCookingWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategorieIngredientTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategorieIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameToDisplay = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategorieIngredients");
        }
    }
}
