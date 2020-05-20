namespace ABC_Invoicing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CustomerAddress = c.String(),
                        CustomerPhone = c.String(),
                        CustomerRegNum = c.String(),
                        CustomerVatNumber = c.Int(nullable: false),
                        CustomerContact = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
