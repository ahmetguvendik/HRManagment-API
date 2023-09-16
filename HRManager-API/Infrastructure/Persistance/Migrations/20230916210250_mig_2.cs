using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeJob",
                table: "EmployeeJob");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "EmployeeJob",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeJob",
                table: "EmployeeJob",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJob_EmployeeId",
                table: "EmployeeJob",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeJob",
                table: "EmployeeJob");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJob_EmployeeId",
                table: "EmployeeJob");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeJob");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeJob",
                table: "EmployeeJob",
                columns: new[] { "EmployeeId", "JobId" });
        }
    }
}
