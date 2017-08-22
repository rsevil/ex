namespace EX.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Operations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTimeOffset(nullable: false, precision: 7),
                        CreditCardNumber = c.String(maxLength: 19, fixedLength: true, unicode: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCard", t => t.CreditCardNumber)
                .Index(t => t.CreditCardNumber);
            
            AddColumn("dbo.CreditCard", "Balance", c => c.Decimal(nullable: true, precision: 18, scale: 2));
            Sql("UPDATE dbo.CreditCard SET Balance = 1000");
            AlterColumn("dbo.CreditCard", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operation", "CreditCardNumber", "dbo.CreditCard");
            DropIndex("dbo.Operation", new[] { "CreditCardNumber" });
            DropColumn("dbo.CreditCard", "Balance");
            DropTable("dbo.Operation");
        }
    }
}
