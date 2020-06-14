namespace NewApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ImageUrl1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ImageUrl1");
        }
    }
}
