namespace Cardinal.Model.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedCardColToTransaction : DbMigration {
        public override void Up() {
            AddColumn("dbo.Transactions", "AssignedCard", c => c.String());
        }

        public override void Down() {
            DropColumn("dbo.Transactions", "AssignedCard");
        }
    }
}
