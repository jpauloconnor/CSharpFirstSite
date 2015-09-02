namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedATable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OkToDelete",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Sophie = c.String(),
                        SomeColumn = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OkToDelete");
        }
    }
}
