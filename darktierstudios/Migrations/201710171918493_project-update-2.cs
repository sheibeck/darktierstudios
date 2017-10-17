namespace darktierstudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectupdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Incomplete", c => c.Boolean(nullable: false));
            DropColumn("dbo.Projects", "Incompolete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Incompolete", c => c.Boolean(nullable: false));
            DropColumn("dbo.Projects", "Incomplete");
        }
    }
}
