namespace WebAcademia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        Matricula = c.Int(nullable: false, identity: true),
                        CPF = c.Int(nullable: false),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        EnderecoAluno_Rua = c.String(),
                        EnderecoAluno_Bairro = c.String(),
                        EnderecoAluno_Cidade = c.String(),
                        EnderecoAluno_Estado = c.String(),
                        EnderecoAluno_CEP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Matricula);
            
            CreateTable(
                "dbo.Mensalidades",
                c => new
                    {
                        CodigoMensalidade = c.Int(nullable: false),
                        MesReferencia = c.Int(nullable: false),
                        DataVencimento = c.DateTime(nullable: false),
                        DataPagamento = c.DateTime(nullable: false),
                        PagamentoConcluido = c.Boolean(nullable: false),
                        PlanoMensalidade_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.CodigoMensalidade)
                .ForeignKey("dbo.Alunoes", t => t.CodigoMensalidade)
                .ForeignKey("dbo.Planoes", t => t.PlanoMensalidade_Codigo)
                .Index(t => t.CodigoMensalidade)
                .Index(t => t.PlanoMensalidade_Codigo);
            
            CreateTable(
                "dbo.Planoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        ValorMensal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Mensalidades", "PlanoMensalidade_Codigo", "dbo.Planoes");
            DropForeignKey("dbo.Mensalidades", "CodigoMensalidade", "dbo.Alunoes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Mensalidades", new[] { "PlanoMensalidade_Codigo" });
            DropIndex("dbo.Mensalidades", new[] { "CodigoMensalidade" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Planoes");
            DropTable("dbo.Mensalidades");
            DropTable("dbo.Alunoes");
        }
    }
}
