namespace Animal11d.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Animals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Age = c.Int(nullable: false),
                        BreedsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedsId, cascadeDelete: true)
                .Index(t => t.BreedsId);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "BreedsId", "dbo.Breeds");
            DropIndex("dbo.Animals", new[] { "BreedsId" });
            DropTable("dbo.Breeds");
            DropTable("dbo.Animals");
        }
    }
}
