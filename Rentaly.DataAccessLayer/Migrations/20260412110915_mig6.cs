using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentaly.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desxription1",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "Desxription2",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "Desxription3",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "Icon1",
                table: "Awards");

            migrationBuilder.RenameColumn(
                name: "Icon3",
                table: "Awards",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "Icon2",
                table: "Awards",
                newName: "Desxription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Awards",
                newName: "Icon3");

            migrationBuilder.RenameColumn(
                name: "Desxription",
                table: "Awards",
                newName: "Icon2");

            migrationBuilder.AddColumn<string>(
                name: "Desxription1",
                table: "Awards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desxription2",
                table: "Awards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desxription3",
                table: "Awards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Icon1",
                table: "Awards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
