using Microsoft.EntityFrameworkCore.Migrations;

namespace CW11.Migrations
{
    public partial class prescriptionMediament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_Fkey", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "Medicament_Prescription",
                        column: x => x.IdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Prescription_Medicaments",
                        column: x => x.IdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "Details", "Dose", "IdMedicament" },
                values: new object[] { 2, "aaaaaa", 2, 1 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "Details", "Dose", "IdMedicament" },
                values: new object[] { 1, "bbbbbbbbbbbb", 3, 2 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "Details", "Dose", "IdMedicament" },
                values: new object[] { 3, "cccccc", 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");
        }
    }
}
