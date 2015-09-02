namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppedTempTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OkToDelete");
        }
        
        public override void Down()
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
    }
}
