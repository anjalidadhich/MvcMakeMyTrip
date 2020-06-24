namespace RoleBasedAuthanticationInMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingDetails", "CatId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookingDetails", "CatId");
            AddForeignKey("dbo.BookingDetails", "CatId", "dbo.Categories", "CatId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingDetails", "CatId", "dbo.Categories");
            DropIndex("dbo.BookingDetails", new[] { "CatId" });
            DropColumn("dbo.BookingDetails", "CatId");
        }
    }
}
