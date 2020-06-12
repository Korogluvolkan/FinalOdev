namespace haliSahaRezervasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNotesColumnInRezervasyonsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rezervasyons", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rezervasyons", "Notes");
        }
    }
}
