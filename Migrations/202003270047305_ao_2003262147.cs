namespace WebAcademia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ao_2003262147 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgendaAulas",
                c => new
                    {
                        CodigoAgendamento = c.Int(nullable: false, identity: true),
                        HoraInicio = c.DateTime(nullable: false),
                        DuracaoMinutos = c.Int(nullable: false),
                        AulaAgenda_CodigoAula = c.Int(),
                        InstrutorAula_Matricula = c.Int(),
                    })
                .PrimaryKey(t => t.CodigoAgendamento)
                .ForeignKey("dbo.Aulas", t => t.AulaAgenda_CodigoAula)
                .ForeignKey("dbo.Instrutors", t => t.InstrutorAula_Matricula)
                .Index(t => t.AulaAgenda_CodigoAula)
                .Index(t => t.InstrutorAula_Matricula);
            
            CreateTable(
                "dbo.Instrutors",
                c => new
                    {
                        Matricula = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Matricula);
            
            AddColumn("dbo.Alunoes", "AgendaAulas_CodigoAgendamento", c => c.Int());
            CreateIndex("dbo.Alunoes", "AgendaAulas_CodigoAgendamento");
            AddForeignKey("dbo.Alunoes", "AgendaAulas_CodigoAgendamento", "dbo.AgendaAulas", "CodigoAgendamento");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgendaAulas", "InstrutorAula_Matricula", "dbo.Instrutors");
            DropForeignKey("dbo.AgendaAulas", "AulaAgenda_CodigoAula", "dbo.Aulas");
            DropForeignKey("dbo.Alunoes", "AgendaAulas_CodigoAgendamento", "dbo.AgendaAulas");
            DropIndex("dbo.Alunoes", new[] { "AgendaAulas_CodigoAgendamento" });
            DropIndex("dbo.AgendaAulas", new[] { "InstrutorAula_Matricula" });
            DropIndex("dbo.AgendaAulas", new[] { "AulaAgenda_CodigoAula" });
            DropColumn("dbo.Alunoes", "AgendaAulas_CodigoAgendamento");
            DropTable("dbo.Instrutors");
            DropTable("dbo.AgendaAulas");
        }
    }
}
