using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCRUD.Migrations
{
    public partial class DbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "HR",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "HR",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ImgUser = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HR",
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                schema: "HR",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "HR");
        }
    }
}
