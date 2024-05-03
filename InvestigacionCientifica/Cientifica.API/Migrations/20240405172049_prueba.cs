using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cientifica.API.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investigadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    especialidad = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    afiliacion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoDeInvestigaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaDeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoDeInvestigaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecursosEs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cantidad = table.Column<int>(type: "int", maxLength: 35, nullable: false),
                    proveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    entrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursosEs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigadorId = table.Column<int>(type: "int", nullable: false),
                    ProyectoDeInvestigacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participaciones_Investigadores_InvestigadorId",
                        column: x => x.InvestigadorId,
                        principalTable: "Investigadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participaciones_ProyectoDeInvestigaciones_ProyectoDeInvestigacionId",
                        column: x => x.ProyectoDeInvestigacionId,
                        principalTable: "ProyectoDeInvestigaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    autores = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    fechapu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProyectoDeInvestigacionesId = table.Column<int>(type: "int", nullable: true),
                    ProyectoDeinvestigacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicaciones_ProyectoDeInvestigaciones_ProyectoDeInvestigacionesId",
                        column: x => x.ProyectoDeInvestigacionesId,
                        principalTable: "ProyectoDeInvestigaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoDeInvestigacionId = table.Column<int>(type: "int", nullable: false),
                    RecursosEId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignaciones_ProyectoDeInvestigaciones_ProyectoDeInvestigacionId",
                        column: x => x.ProyectoDeInvestigacionId,
                        principalTable: "ProyectoDeInvestigaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignaciones_RecursosEs_RecursosEId",
                        column: x => x.RecursosEId,
                        principalTable: "RecursosEs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesDeInvestigaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaDeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AsignacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesDeInvestigaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActividadesDeInvestigaciones_Asignaciones_AsignacionId",
                        column: x => x.AsignacionId,
                        principalTable: "Asignaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesDeInvestigaciones_AsignacionId",
                table: "ActividadesDeInvestigaciones",
                column: "AsignacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_ProyectoDeInvestigacionId",
                table: "Asignaciones",
                column: "ProyectoDeInvestigacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_RecursosEId",
                table: "Asignaciones",
                column: "RecursosEId");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_InvestigadorId",
                table: "Participaciones",
                column: "InvestigadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_ProyectoDeInvestigacionId",
                table: "Participaciones",
                column: "ProyectoDeInvestigacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_ProyectoDeInvestigacionesId",
                table: "Publicaciones",
                column: "ProyectoDeInvestigacionesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesDeInvestigaciones");

            migrationBuilder.DropTable(
                name: "Participaciones");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.DropTable(
                name: "Investigadores");

            migrationBuilder.DropTable(
                name: "ProyectoDeInvestigaciones");

            migrationBuilder.DropTable(
                name: "RecursosEs");
        }
    }
}
