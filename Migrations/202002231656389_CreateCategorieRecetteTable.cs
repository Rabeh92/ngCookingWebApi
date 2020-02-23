namespace ngCookingWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategorieRecetteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategorieRecettes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameToDisplay = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategorieRecettes");
        }
    }
}
