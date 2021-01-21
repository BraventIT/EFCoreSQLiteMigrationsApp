using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSQLiteXamFormsApp.Migrations
{
    public partial class UpdatePatientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Patients",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Patients");
        }
    }
}
