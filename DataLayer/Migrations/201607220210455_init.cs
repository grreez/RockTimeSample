namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ParentArticleId = c.Int(),
                        ArticleLevel = c.Int(nullable: false),
                        ArticleTitle = c.String(nullable: false, maxLength: 50),
                        ArticleHeader = c.String(maxLength: 50),
                        ArticleContent = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Articles", t => t.ParentArticleId)
                .Index(t => t.ParentArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "ParentArticleId", "dbo.Articles");
            DropIndex("dbo.Articles", new[] { "ParentArticleId" });
            DropTable("dbo.Articles");
        }
    }
}
