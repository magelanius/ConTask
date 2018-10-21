namespace ConTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableElements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardColumns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoardId = c.Int(nullable: false),
                        Name = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                    
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.BoardId, cascadeDelete: true);
            
            CreateTable(
                "dbo.BoardRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                    
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BoardColumns", t => t.ColumnId, cascadeDelete: true)
                    .ForeignKey("dbo.ProjectTasks", t => t.TaskId, cascadeDelete: false);
            
            
        }
        
        public override void Down()
        {
            
            DropTable("dbo.BoardRows");
            DropTable("dbo.BoardColumns");
        }
    }
}
