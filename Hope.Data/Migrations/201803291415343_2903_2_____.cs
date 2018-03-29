namespace Hope.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2903_2_____ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Published = c.DateTime(nullable: false),
                        ComposerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Composers", t => t.ComposerId, cascadeDelete: true)
                .Index(t => t.ComposerId);
            
            CreateTable(
                "dbo.Composers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ArticleId = c.Int(nullable: false),
                        ReaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.ReaderId);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stars = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        ReaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.ReaderId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccessToken = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Expriy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rates", "ReaderId", "dbo.Readers");
            DropForeignKey("dbo.Rates", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Comments", "ReaderId", "dbo.Readers");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "ComposerId", "dbo.Composers");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropIndex("dbo.Rates", new[] { "ReaderId" });
            DropIndex("dbo.Rates", new[] { "ArticleId" });
            DropIndex("dbo.Comments", new[] { "ReaderId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "ComposerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tokens");
            DropTable("dbo.Rates");
            DropTable("dbo.Readers");
            DropTable("dbo.Comments");
            DropTable("dbo.Composers");
            DropTable("dbo.Articles");
        }
    }
}
