using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practiceproject.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewEmployees",
                columns: table => new
                {
                    empId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    empName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    empPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    empJoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewEmployees", x => x.empId);
                    table.ForeignKey(
                        name: "FK_NewEmployees_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "Departid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewEmployees_departmentId",
                table: "NewEmployees",
                column: "departmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewEmployees");
        }
    }
}
