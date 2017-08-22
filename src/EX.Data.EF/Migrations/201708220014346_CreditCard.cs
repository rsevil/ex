namespace EX.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCard",
                c => new
                    {
                        Number = c.String(nullable: false, maxLength: 19, fixedLength: true, unicode: false),
                        Pin = c.String(nullable: false, maxLength: 3, fixedLength: true, unicode: false),
                        ValidFrom = c.DateTimeOffset(nullable: false, precision: 7),
                        DueOn = c.DateTimeOffset(nullable: false, precision: 7),
                        InvalidLoginAttempts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Number);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CreditCard");
        }
    }
}
