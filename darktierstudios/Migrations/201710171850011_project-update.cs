namespace darktierstudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Author", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Projects", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Rulebook", c => c.String());
            AlterColumn("dbo.Projects", "Charactersheet", c => c.String());
            AlterColumn("dbo.Projects", "Document", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Document", c => c.Binary());
            AlterColumn("dbo.Projects", "Charactersheet", c => c.Binary());
            AlterColumn("dbo.Projects", "Rulebook", c => c.Binary());
            AlterColumn("dbo.Projects", "Image", c => c.Binary(nullable: false));
            DropColumn("dbo.Projects", "Author");
        }
    }
}
