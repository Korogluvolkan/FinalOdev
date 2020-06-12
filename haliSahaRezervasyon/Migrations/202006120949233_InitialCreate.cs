namespace haliSahaRezervasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rezervasyons",
                c => new
                    {
                        RezervasyonId = c.Int(nullable: false, identity: true),
                        SahaId = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        RezervasyonSaat = c.String(),
                    })
                .PrimaryKey(t => t.RezervasyonId);
            
            CreateTable(
                "dbo.Saatlers",
                c => new
                    {
                        SaatId = c.Int(nullable: false, identity: true),
                        Saat = c.String(),
                        SaatDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SaatId);
            
            CreateTable(
                "dbo.Sahalars",
                c => new
                    {
                        SahaId = c.Int(nullable: false, identity: true),
                        SahaIsim = c.String(),
                        Fiyat = c.Int(nullable: false),
                        Adres = c.String(),
                        SahaDurum = c.Boolean(nullable: false),
                        SahaKisi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SahaId);
            
            CreateTable(
                "dbo.Tarihlers",
                c => new
                    {
                        TarihId = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Saat_SaatId = c.Int(),
                    })
                .PrimaryKey(t => t.TarihId)
                .ForeignKey("dbo.Saatlers", t => t.Saat_SaatId)
                .Index(t => t.Saat_SaatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarihlers", "Saat_SaatId", "dbo.Saatlers");
            DropIndex("dbo.Tarihlers", new[] { "Saat_SaatId" });
            DropTable("dbo.Tarihlers");
            DropTable("dbo.Sahalars");
            DropTable("dbo.Saatlers");
            DropTable("dbo.Rezervasyons");
        }
    }
}
