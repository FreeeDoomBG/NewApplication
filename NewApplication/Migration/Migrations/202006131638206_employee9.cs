namespace NewApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Text");
        }
    }
}
