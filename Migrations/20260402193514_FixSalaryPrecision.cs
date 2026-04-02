using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixSalaryPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SALARY",
                table: "EMPLOYEES",
                type: "NUMBER(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SALARY",
                table: "EMPLOYEES",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(10,2)");
        }
    }
}
