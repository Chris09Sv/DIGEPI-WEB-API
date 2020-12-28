using Microsoft.EntityFrameworkCore.Migrations;

namespace DGP.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TLaboratorios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Institucion = table.Column<int>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Id_Sinave = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TLaboratorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TManejo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Atencion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TManejo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TProvincias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provincia = table.Column<string>(nullable: true),
                    Codigo_One = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProvincias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TMuestras",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaboratorioId = table.Column<int>(nullable: true),
                    codigo_muestra = table.Column<string>(nullable: true),
                    nombre_paciente = table.Column<string>(nullable: true),
                    apellido_paciente = table.Column<string>(nullable: true),
                    sexo = table.Column<string>(nullable: true),
                    fecha_nacimiento = table.Column<string>(nullable: true),
                    tipo_documento = table.Column<string>(nullable: true),
                    numero_documento = table.Column<string>(nullable: true),
                    codigo_nacionalidad = table.Column<string>(nullable: true),
                    manejoId = table.Column<int>(nullable: true),
                    codigo_tipo_atencion = table.Column<string>(nullable: true),
                    Provinciaid = table.Column<int>(nullable: true),
                    codigo_municipio = table.Column<string>(nullable: true),
                    codigo_sector = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    celular = table.Column<string>(nullable: true),
                    tiene_sintomas = table.Column<string>(nullable: true),
                    embarazada = table.Column<string>(nullable: true),
                    fecha_toma_muestra = table.Column<string>(nullable: true),
                    fecha_reporte = table.Column<string>(nullable: true),
                    resultado = table.Column<string>(nullable: true),
                    tipo_muestra = table.Column<string>(nullable: true),
                    primera_muestra = table.Column<string>(nullable: true),
                    comentarios = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMuestras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TMuestras_TLaboratorios_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "TLaboratorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TMuestras_TProvincias_Provinciaid",
                        column: x => x.Provinciaid,
                        principalTable: "TProvincias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TMuestras_TManejo_manejoId",
                        column: x => x.manejoId,
                        principalTable: "TManejo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TMuestras_LaboratorioId",
                table: "TMuestras",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_TMuestras_Provinciaid",
                table: "TMuestras",
                column: "Provinciaid");

            migrationBuilder.CreateIndex(
                name: "IX_TMuestras_manejoId",
                table: "TMuestras",
                column: "manejoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMuestras");

            migrationBuilder.DropTable(
                name: "TLaboratorios");

            migrationBuilder.DropTable(
                name: "TProvincias");

            migrationBuilder.DropTable(
                name: "TManejo");
        }
    }
}
