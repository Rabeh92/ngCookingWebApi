namespace ngCookingWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRecetteTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recettes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreationDate = c.Long(nullable: false),
                        UserId = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        CategorieId = c.Int(nullable: false),
                        Picture = c.String(),
                        Calorie = c.Int(nullable: false),
                        Preparation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategorieRecettes", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "NameIndex")
                .Index(t => t.CategorieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recettes", "CategorieId", "dbo.CategorieRecettes");
            DropIndex("dbo.Recettes", new[] { "CategorieId" });
            DropIndex("dbo.Recettes", "NameIndex");
            DropTable("dbo.Recettes");
        }
    }
}
