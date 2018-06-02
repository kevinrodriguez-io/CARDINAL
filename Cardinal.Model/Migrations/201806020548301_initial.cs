namespace Cardinal.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountCuttings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        AccountDescription = c.String(),
                        NationalIdentifier = c.String(),
                        TotalDeposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalWithdrawal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IntrestRate = c.Int(nullable: false),
                        CashPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RealPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastMinimumCashPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MoratoryIntrest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WithdrawalCommission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdministrativeCommission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashPaymentCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AutomaticCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceCutting = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        UserId = c.Int(nullable: false),
                        CuttingDate = c.DateTime(nullable: false),
                        CashPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        Deposit = c.Decimal(precision: 18, scale: 2),
                        Withdrawal = c.Decimal(precision: 18, scale: 2),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Direction = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDirectionHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LastDirection = c.String(),
                        NewDirection = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Identifier = c.String(),
                        AccountId = c.Int(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.UserDirectionHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.AccountCuttings", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Cards", new[] { "AccountId" });
            DropIndex("dbo.UserDirectionHistories", new[] { "UserId" });
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropIndex("dbo.AccountCuttings", new[] { "AccountId" });
            DropTable("dbo.Cards");
            DropTable("dbo.UserDirectionHistories");
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountCuttings");
        }
    }
}
