namespace NewApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ImageUrl", c => c.String(maxLength: 3999));
        }
    }
}
