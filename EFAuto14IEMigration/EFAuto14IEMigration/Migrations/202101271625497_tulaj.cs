namespace EFAuto14IEMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tulaj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tulaj",
                c => new
                    {
                        TulajId = c.Int(nullable: false, identity: true),
                        Nev = c.String(nullable: false),
                        Telefon = c.String(),
                    })
                .PrimaryKey(t => t.TulajId);
            
            AddColumn("dbo.auto", "TulajId", c => c.Int(nullable: false));
            CreateIndex("dbo.auto", "TulajId");
            AddForeignKey("dbo.auto", "TulajId", "dbo.tulaj", "TulajId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.auto", "TulajId", "dbo.tulaj");
            DropIndex("dbo.auto", new[] { "TulajId" });
            DropColumn("dbo.auto", "TulajId");
            DropTable("dbo.tulaj");
        }
    }
}
