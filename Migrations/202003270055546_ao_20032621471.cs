namespace WebAcademia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ao_20032621471 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AgendaAulas", "AulaAgenda_CodigoAula", "dbo.Aulas");
            DropForeignKey("dbo.AgendaAulas", "InstrutorAula_Matricula", "dbo.Instrutors");
            DropIndex("dbo.AgendaAulas", new[] { "AulaAgenda_CodigoAula" });
            DropIndex("dbo.AgendaAulas", new[] { "InstrutorAula_Matricula" });
            AlterColumn("dbo.AgendaAulas", "AulaAgenda_CodigoAula", c => c.Int(nullable: false));
            AlterColumn("dbo.AgendaAulas", "InstrutorAula_Matricula", c => c.Int(nullable: false));
            CreateIndex("dbo.AgendaAulas", "AulaAgenda_CodigoAula");
            CreateIndex("dbo.AgendaAulas", "InstrutorAula_Matricula");
            AddForeignKey("dbo.AgendaAulas", "AulaAgenda_CodigoAula", "dbo.Aulas", "CodigoAula", cascadeDelete: true);
            AddForeignKey("dbo.AgendaAulas", "InstrutorAula_Matricula", "dbo.Instrutors", "Matricula", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgendaAulas", "InstrutorAula_Matricula", "dbo.Instrutors");
            DropForeignKey("dbo.AgendaAulas", "AulaAgenda_CodigoAula", "dbo.Aulas");
            DropIndex("dbo.AgendaAulas", new[] { "InstrutorAula_Matricula" });
            DropIndex("dbo.AgendaAulas", new[] { "AulaAgenda_CodigoAula" });
            AlterColumn("dbo.AgendaAulas", "InstrutorAula_Matricula", c => c.Int());
            AlterColumn("dbo.AgendaAulas", "AulaAgenda_CodigoAula", c => c.Int());
            CreateIndex("dbo.AgendaAulas", "InstrutorAula_Matricula");
            CreateIndex("dbo.AgendaAulas", "AulaAgenda_CodigoAula");
            AddForeignKey("dbo.AgendaAulas", "InstrutorAula_Matricula", "dbo.Instrutors", "Matricula");
            AddForeignKey("dbo.AgendaAulas", "AulaAgenda_CodigoAula", "dbo.Aulas", "CodigoAula");
        }
    }
}
