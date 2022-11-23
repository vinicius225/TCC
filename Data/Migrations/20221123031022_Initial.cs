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
                name: "especialidade",
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
                    table.PrimaryKey("PK_especialidade", x => x.id);
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
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidade_saude", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "busca_especialidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_especialidade = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busca_especialidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_busca_especialidade_especialidade_id_especialidade",
                        column: x => x.id_especialidade,
                        principalTable: "especialidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_medico_unidade_saude_id_medico",
                        column: x => x.id_medico,
                        principalTable: "unidade_saude",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadeMedico",
                columns: table => new
                {
                    id_especialidade = table.Column<int>(type: "integer", nullable: false),
                    id_medico = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeMedico", x => new { x.id_especialidade, x.id_medico });
                    table.ForeignKey(
                        name: "FK_EspecialidadeMedico_especialidade_id_especialidade",
                        column: x => x.id_especialidade,
                        principalTable: "especialidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadeMedico_medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "medico",
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
                    id_plantao = table.Column<int>(type: "integer", nullable: true),
                    criado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    editado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantao", x => x.id);
                    table.ForeignKey(
                        name: "FK_plantao_especialidade_id_especialidade",
                        column: x => x.id_especialidade,
                        principalTable: "especialidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plantao_medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plantao_unidade_saude_id_plantao",
                        column: x => x.id_plantao,
                        principalTable: "unidade_saude",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_plantao_unidade_saude_id_unidade",
                        column: x => x.id_unidade,
                        principalTable: "unidade_saude",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_busca_especialidade_id_especialidade",
                table: "busca_especialidade",
                column: "id_especialidade");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadeMedico_id_medico",
                table: "EspecialidadeMedico",
                column: "id_medico");

            migrationBuilder.CreateIndex(
                name: "IX_medico_id_medico",
                table: "medico",
                column: "id_medico");

            migrationBuilder.CreateIndex(
                name: "IX_plantao_id_especialidade",
                table: "plantao",
                column: "id_especialidade");

            migrationBuilder.CreateIndex(
                name: "IX_plantao_id_medico",
                table: "plantao",
                column: "id_medico");

            migrationBuilder.CreateIndex(
                name: "IX_plantao_id_plantao",
                table: "plantao",
                column: "id_plantao");

            migrationBuilder.CreateIndex(
                name: "IX_plantao_id_unidade",
                table: "plantao",
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
                name: "EspecialidadeMedico");

            migrationBuilder.DropTable(
                name: "plantao");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "especialidade");

            migrationBuilder.DropTable(
                name: "medico");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "unidade_saude");
        }
    }
}
