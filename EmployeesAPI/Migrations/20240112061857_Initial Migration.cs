using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    departmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.departmentID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mainTechnologyUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDeadline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeAge = table.Column<int>(type: "int", nullable: false),
                    DepartmentdepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectprojectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentdepartmentID",
                        column: x => x.DepartmentdepartmentID,
                        principalTable: "Departments",
                        principalColumn: "departmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectprojectID",
                        column: x => x.ProjectprojectID,
                        principalTable: "Projects",
                        principalColumn: "projectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentdepartmentID",
                table: "Employees",
                column: "DepartmentdepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectprojectID",
                table: "Employees",
                column: "ProjectprojectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
