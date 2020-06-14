namespace NewApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Genera", c => c.String(maxLength: 255));
            AddColumn("dbo.Employees", "ImageUrl2", c => c.String());
            AddColumn("dbo.Employees", "ImageUrl3", c => c.String());
            AddColumn("dbo.Employees", "ImageUrl4", c => c.String());
            DropColumn("dbo.Employees", "Address1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Address1", c => c.String(maxLength: 255));
            DropColumn("dbo.Employees", "ImageUrl4");
            DropColumn("dbo.Employees", "ImageUrl3");
            DropColumn("dbo.Employees", "ImageUrl2");
            DropColumn("dbo.Employees", "Genera");
        }
    }
}
