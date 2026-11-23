using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practiceproject.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "RegisterUsers",
                newName: "PasswordHash");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Departid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Departid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "RegisterUsers",
                newName: "passwordHash");
        }
    }
}
