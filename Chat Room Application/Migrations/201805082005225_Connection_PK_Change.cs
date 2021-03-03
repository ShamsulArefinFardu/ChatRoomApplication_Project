namespace Chat_Room_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Connection_PK_Change : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Connections");
            AddColumn("dbo.Connections", "ContextConnectionId", c => c.String());
            AlterColumn("dbo.Connections", "ConnectionID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Connections", "ConnectionID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Connections");
            AlterColumn("dbo.Connections", "ConnectionID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Connections", "ContextConnectionId");
            AddPrimaryKey("dbo.Connections", "ConnectionID");
        }
    }
}
