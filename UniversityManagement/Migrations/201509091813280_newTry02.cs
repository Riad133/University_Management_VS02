namespace UniversityManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTry02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("dbo.Departments", "DepartmentCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Departments", new[] { "DepartmentCode" });
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.String(nullable: false));
        }
    }
}
