using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClyvoDayApiDocker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    ClinicaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TradeName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.ClinicaId);
                });

            migrationBuilder.CreateTable(
                name: "Tutores",
                columns: table => new
                {
                    TutoresId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FullName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ScoreEngagement = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutores", x => x.TutoresId);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    VeterinarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FullName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Crmv = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Specialty = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ClinicaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.VeterinarioId);
                    table.ForeignKey(
                        name: "FK_Veterinarios_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "ClinicaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimaisEstimacao",
                columns: table => new
                {
                    AnimalEstimacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Species = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Breed = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Weight = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TutoresId1 = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    TutoresId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimaisEstimacao", x => x.AnimalEstimacaoId);
                    table.ForeignKey(
                        name: "FK_AnimaisEstimacao_Tutores_TutoresId",
                        column: x => x.TutoresId,
                        principalTable: "Tutores",
                        principalColumn: "TutoresId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimaisEstimacao_Tutores_TutoresId1",
                        column: x => x.TutoresId1,
                        principalTable: "Tutores",
                        principalColumn: "TutoresId");
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoCuidadoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AnimalEstimacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TypeEvent = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventCompleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Observations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoCuidadoId);
                    table.ForeignKey(
                        name: "FK_Eventos_AnimaisEstimacao_AnimalEstimacaoId",
                        column: x => x.AnimalEstimacaoId,
                        principalTable: "AnimaisEstimacao",
                        principalColumn: "AnimalEstimacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitoramentos",
                columns: table => new
                {
                    MonitoramentoAnimalId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AnimalEstimacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Mood = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnergyLevel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Food = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SleepQuality = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RecentActivities = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Medication = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Observations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MonitoringDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoramentos", x => x.MonitoramentoAnimalId);
                    table.ForeignKey(
                        name: "FK_Monitoramentos_AnimaisEstimacao_AnimalEstimacaoId",
                        column: x => x.AnimalEstimacaoId,
                        principalTable: "AnimaisEstimacao",
                        principalColumn: "AnimalEstimacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimaisEstimacao_TutoresId",
                table: "AnimaisEstimacao",
                column: "TutoresId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimaisEstimacao_TutoresId1",
                table: "AnimaisEstimacao",
                column: "TutoresId1");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_AnimalEstimacaoId",
                table: "Eventos",
                column: "AnimalEstimacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitoramentos_AnimalEstimacaoId",
                table: "Monitoramentos",
                column: "AnimalEstimacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarios_ClinicaId",
                table: "Veterinarios",
                column: "ClinicaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Monitoramentos");

            migrationBuilder.DropTable(
                name: "Veterinarios");

            migrationBuilder.DropTable(
                name: "AnimaisEstimacao");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "Tutores");
        }
    }
}
