namespace EX.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditCards : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditCard", "InvalidPinAttempts", c => c.Int(nullable: false));
            DropColumn("dbo.CreditCard", "InvalidLoginAttempts");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditCard", "InvalidLoginAttempts", c => c.Int(nullable: false));
            DropColumn("dbo.CreditCard", "InvalidPinAttempts");
        }
    }
}
