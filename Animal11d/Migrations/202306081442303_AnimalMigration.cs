namespace Animal11d.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "RegisterOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "RegisterOn");
        }
    }
}
