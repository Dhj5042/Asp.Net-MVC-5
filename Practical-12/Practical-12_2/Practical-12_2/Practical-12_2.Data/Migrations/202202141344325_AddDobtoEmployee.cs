namespace Practical_12_2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDobtoEmployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "DOB", c => c.Int(nullable: false));
        }
    }
}
