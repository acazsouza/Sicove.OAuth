namespace OAuth.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Codes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Value = c.Guid(nullable: false),
                        RedirectUrl = c.String(),
                        ExpireAt = c.DateTime(nullable: false),
                        WasUsed = c.Boolean(nullable: false),
                        LoggedUser_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.LoggedUser_Id)
                .Index(t => t.LoggedUser_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RedirectUrl = c.String(),
                        LoggedUser_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.LoggedUser_Id)
                .Index(t => t.LoggedUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "LoggedUser_Id", "dbo.Users");
            DropForeignKey("dbo.Codes", "LoggedUser_Id", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "LoggedUser_Id" });
            DropIndex("dbo.Codes", new[] { "LoggedUser_Id" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Users");
            DropTable("dbo.Codes");
        }
    }
}
