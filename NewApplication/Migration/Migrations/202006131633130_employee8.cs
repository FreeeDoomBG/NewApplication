namespace NewApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Address1", c => c.String(maxLength: 255));
            DropColumn("dbo.Employees", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Address", c => c.String(maxLength: 255));
            DropColumn("dbo.Employees", "Address1");
        }
    }
}
