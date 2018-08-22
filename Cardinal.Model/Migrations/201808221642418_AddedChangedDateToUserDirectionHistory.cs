namespace Cardinal.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChangedDateToUserDirectionHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDirectionHistories", "ChangedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDirectionHistories", "ChangedDate");
        }
    }
}
