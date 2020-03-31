namespace WebAcademia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ao_2003262133 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aulas",
                c => new
                    {
                        CodigoAula = c.Int(nullable: false, identity: true),
                        NomeAula = c.String(),
                        FrequenciaSemanal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoAula);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aulas");
        }
    }
}
