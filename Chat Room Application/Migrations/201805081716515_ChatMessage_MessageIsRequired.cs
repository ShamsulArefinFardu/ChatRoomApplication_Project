namespace Chat_Room_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatMessage_MessageIsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChatMessages", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChatMessages", "Message", c => c.String());
        }
    }
}
