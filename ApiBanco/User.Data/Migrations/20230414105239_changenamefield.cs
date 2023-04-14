using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Data.Migrations
{
    /// <inheritdoc />
    public partial class changenamefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "Incomes",
                table: "Account",
                newName: "Income");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Income",
                table: "Account",
                newName: "Incomes");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Account",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
