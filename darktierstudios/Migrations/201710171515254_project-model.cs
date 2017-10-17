namespace darktierstudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Synopsis = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false),
                        Image = c.Binary(nullable: false),
                        Rulebook = c.Binary(),
                        Charactersheet = c.Binary(),
                        Document = c.Binary(),
                        TheGameCrafterApiID = c.Guid(nullable: false),
                        TheGameCrafterCartID = c.Guid(nullable: false),
                        InDevelopment = c.Boolean(nullable: false),
                        Incompolete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
