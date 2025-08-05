using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKeyFromGivenNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GivenName",
                table: "GivenName");

            migrationBuilder.AlterColumn<string>(
                name: "GivenName",
                table: "GivenName",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GivenName",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GivenName",
                table: "GivenName",
                columns: new[] { "PatientId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GivenName",
                table: "GivenName");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GivenName");

            migrationBuilder.AlterColumn<string>(
                name: "GivenName",
                table: "GivenName",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GivenName",
                table: "GivenName",
                columns: new[] { "PatientId", "GivenName" });
        }
    }
}
