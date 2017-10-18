namespace darktierstudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectslug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Slug", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Slug");
        }
    }
}
