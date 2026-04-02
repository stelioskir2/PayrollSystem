using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CITIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "POSITIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITLE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSITIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BRANCHES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AREA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CITY_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCHES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BRANCHES_CITIES_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    REGISTRATION_NUMBER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FIRST_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LAST_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    POSITION_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SALARY = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ADDRESS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PHONE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.REGISTRATION_NUMBER);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_POSITIONS_POSITION_ID",
                        column: x => x.POSITION_ID,
                        principalTable: "POSITIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BRANCHES_CITY_ID",
                table: "BRANCHES",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_BRANCH_ID",
                table: "EMPLOYEES",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_POSITION_ID",
                table: "EMPLOYEES",
                column: "POSITION_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "BRANCHES");

            migrationBuilder.DropTable(
                name: "POSITIONS");

            migrationBuilder.DropTable(
                name: "CITIES");
        }
    }
}
