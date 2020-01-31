namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingsxservices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.BookingsXServices",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   GroomServiceID = c.Int(),
                   GroomBookingID = c.Int()
               })
               .PrimaryKey(t => t.ID);

            AddForeignKey("dbo.BookingsXServices", "GroomServiceID", "dbo.GroomServices", "GroomServiceID", cascadeDelete: true);
            AddForeignKey("dbo.BookingsXServices", "GroomBookingID", "dbo.GroomBookings", "GroomBookingID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropTable("dbo.BookingsXServices");
        }
    }
}
