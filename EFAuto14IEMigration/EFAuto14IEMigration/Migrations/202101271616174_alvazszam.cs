namespace EFAuto14IEMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alvazszam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.auto", "Alvazszam", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.auto", "Alvazszam");
        }
    }
}
