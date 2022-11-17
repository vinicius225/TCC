using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidade_Medico",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_medico = table.Column<int>(type: "integer", nullable: false),
                    id_especialidade = table.Column<int>(type: "integer", nullable: false),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade_Medico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeSaudeMedico",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_medidco = table.Column<int>(type: "integer", nullable: false),
                    id_unidade = table.Column<int>(type: "integer", nullable: false),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeSaudeMedico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "especialidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    id_especialidade = table.Column<int>(type: "integer", nullable: true),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especialidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_especialidade_Especialidade_Medico_id_especialidade",
                        column: x => x.id_especialidade,
                        principalTable: "Especialidade_Medico",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    sexo = table.Column<char>(type: "character(1)", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    id_perfil = table.Column<int>(type: "integer", nullable: false),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_perfil_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medico",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    crm = table.Column<string>(type: "text", nullable: false),
                    estado_crm = table.Column<string>(type: "text", nullable: false),
                    id_medico = table.Column<int>(type: "integer", nullable: true),
                    id_medidco = table.Column<int>(type: "integer", nullable: true),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_medico_Especialidade_Medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "Especialidade_Medico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_medico_UnidadeSaudeMedico_id_medidco",
                        column: x => x.id_medidco,
                        principalTable: "UnidadeSaudeMedico",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "unidade_saude",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    cnpj = table.Column<string>(type: "text", nullable: false),
                    endereco = table.Column<string>(type: "text", nullable: false),
                    numero = table.Column<string>(type: "text", nullable: false),
                    telefone = table.Column<string>(type: "text", nullable: false),
                    id_unidade = table.Column<int>(type: "integer", nullable: true),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidade_saude", x => x.id);
                    table.ForeignKey(
                        name: "FK_unidade_saude_UnidadeSaudeMedico_id_unidade",
                        column: x => x.id_unidade,
                        principalTable: "UnidadeSaudeMedico",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "busca_especialidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_especialidade = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    Especialidadeid = table.Column<int>(type: "integer", nullable: false),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busca_especialidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_busca_especialidade_especialidade_Especialidadeid",
                        column: x => x.Especialidadeid,
                        principalTable: "especialidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "plantao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_unidade = table.Column<int>(type: "integer", nullable: false),
                    id_medico = table.Column<int>(type: "integer", nullable: false),
                    id_especialidade = table.Column<int>(type: "integer", nullable: false),
                    horarioinicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    horariofim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dia_semana = table.Column<int>(type: "integer", nullable: false),
                    UnidadeSaudesid = table.Column<int>(type: "integer", nullable: false),
                    Medicosid = table.Column<int>(type: "integer", nullable: false),
                    Especialidadesid = table.Column<int>(type: "integer", nullable: false),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantao", x => x.id);
                    table.ForeignKey(
                        name: "FK_plantao_especialidade_Especialidadesid",
                        column: x => x.Especialidadesid,
                        principalTable: "especialidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plantao_medico_Medicosid",
                        column: x => x.Medicosid,
                        principalTable: "medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plantao_unidade_saude_UnidadeSaudesid",
                        column: x => x.UnidadeSaudesid,
                        principalTable: "unidade_saude",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_busca_especialidade_Especialidadeid",
                table: "busca_especialidade",
                column: "Especialidadeid");

            migrationBuilder.CreateIndex(
                name: "IX_especialidade_id_especialidade",
                table: "especialidade",
                column: "id_especialidade");

            migrationBuilder.CreateIndex(
                name: "IX_medico_id_medico",
                table: "medico",
                column: "id_medico");

            migrationBuilder.CreateIndex(
                name: "IX_medico_id_medidco",
                table: "medico",
                column: "id_medidco");

            migrationBuilder.CreateIndex(
                name: "IX_plantao_Especialidadesid",
                table: "plantao",
                column: "Especialidadesid");

            migrationBuilder.CreateIndex(
                name: "IX_plantao_Medicosid",
                table: "plantao",
                column: "Medicosid");

            migrationBuilder.CreateIndex(
                name: "IX_plantao_UnidadeSaudesid",
                table: "plantao",
                column: "UnidadeSaudesid");

            migrationBuilder.CreateIndex(
                name: "IX_unidade_saude_id_unidade",
                table: "unidade_saude",
                column: "id_unidade");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_perfil",
                table: "usuario",
                column: "id_perfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "busca_especialidade");

            migrationBuilder.DropTable(
                name: "plantao");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "especialidade");

            migrationBuilder.DropTable(
                name: "medico");

            migrationBuilder.DropTable(
                name: "unidade_saude");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "Especialidade_Medico");

            migrationBuilder.DropTable(
                name: "UnidadeSaudeMedico");
        }
    }
}
