namespace Cardinal.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class needed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AccountCuttings", "AccountDescription");
            DropColumn("dbo.AccountCuttings", "NationalIdentifier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountCuttings", "NationalIdentifier", c => c.String());
            AddColumn("dbo.AccountCuttings", "AccountDescription", c => c.String());
        }
    }
}
