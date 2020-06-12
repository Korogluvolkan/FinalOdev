namespace haliSahaRezervasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePayCheckColumnInRezervasyonsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rezervasyons", "PayCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rezervasyons", "PayCheck");
        }
    }
}
