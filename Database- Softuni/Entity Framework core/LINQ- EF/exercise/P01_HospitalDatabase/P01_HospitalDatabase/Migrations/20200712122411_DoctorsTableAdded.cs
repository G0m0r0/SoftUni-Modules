using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_HospitalDatabase.Migrations
{
    public partial class DoctorsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patientMedicaments_Medicaments_MedicamentId",
                table: "patientMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_patientMedicaments_Patients_PatientId",
                table: "patientMedicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patientMedicaments",
                table: "patientMedicaments");

            migrationBuilder.RenameTable(
                name: "patientMedicaments",
                newName: "PatientMedicaments");

            migrationBuilder.RenameIndex(
                name: "IX_patientMedicaments_PatientId",
                table: "PatientMedicaments",
                newName: "IX_PatientMedicaments_PatientId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Visitations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                unicode: false,
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldUnicode: false,
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMedicaments",
                table: "PatientMedicaments",
                columns: new[] { "MedicamentId", "PatientId" });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Specialty = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitations_DoctorId",
                table: "Visitations",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicaments_Medicaments_MedicamentId",
                table: "PatientMedicaments",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "MedicamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicaments_Patients_PatientId",
                table: "PatientMedicaments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitations_Doctor_DoctorId",
                table: "Visitations",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicaments_Medicaments_MedicamentId",
                table: "PatientMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicaments_Patients_PatientId",
                table: "PatientMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitations_Doctor_DoctorId",
                table: "Visitations");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Visitations_DoctorId",
                table: "Visitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMedicaments",
                table: "PatientMedicaments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Visitations");

            migrationBuilder.RenameTable(
                name: "PatientMedicaments",
                newName: "patientMedicaments");

            migrationBuilder.RenameIndex(
                name: "IX_PatientMedicaments_PatientId",
                table: "patientMedicaments",
                newName: "IX_patientMedicaments_PatientId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 80);

            migrationBuilder.AddPrimaryKey(
                name: "PK_patientMedicaments",
                table: "patientMedicaments",
                columns: new[] { "MedicamentId", "PatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_patientMedicaments_Medicaments_MedicamentId",
                table: "patientMedicaments",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "MedicamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patientMedicaments_Patients_PatientId",
                table: "patientMedicaments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
