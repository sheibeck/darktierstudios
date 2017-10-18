namespace darktierstudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ProjectDate");
        }
    }
}
