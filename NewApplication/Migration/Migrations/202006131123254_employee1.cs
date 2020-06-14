namespace NewApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ImageUrl", c => c.String(maxLength: 255));
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Employees", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Employees", "Dob", c => c.String(maxLength: 255));
            AlterColumn("dbo.Employees", "Address", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "Dob", c => c.String());
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "ImageUrl");
        }
    }
}
