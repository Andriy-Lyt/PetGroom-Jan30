namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ownersxpets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.OwnersXPets",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   OwnerID = c.Int(),
                   PetID = c.Int()
               })
               .PrimaryKey(t => t.ID);

            AddForeignKey("dbo.OwnersXPets", "OwnerID", "dbo.Owners", "OwnerID", cascadeDelete: true);
            AddForeignKey("dbo.OwnersXPets", "PetID", "dbo.Pets", "PetID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropTable("dbo.OwnersXPets");
        }
    }
}
