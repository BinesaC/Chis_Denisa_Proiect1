using Microsoft.EntityFrameworkCore.Migrations;

namespace Chis_Denisa_Proiect1.Migrations
{
    public partial class ProgramareServiciu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeServiciu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramareServiciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramareID = table.Column<int>(type: "int", nullable: false),
                    ServiciuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramareServiciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramareServiciu_Programare_ProgramareID",
                        column: x => x.ProgramareID,
                        principalTable: "Programare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramareServiciu_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_DoctorID",
                table: "Programare",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramareServiciu_ProgramareID",
                table: "ProgramareServiciu",
                column: "ProgramareID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramareServiciu_ServiciuID",
                table: "ProgramareServiciu",
                column: "ServiciuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Doctor_DoctorID",
                table: "Programare",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Doctor_DoctorID",
                table: "Programare");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "ProgramareServiciu");

            migrationBuilder.DropTable(
                name: "Serviciu");

            migrationBuilder.DropIndex(
                name: "IX_Programare_DoctorID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Programare");
        }
    }
}
