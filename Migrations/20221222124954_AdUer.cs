using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb_4_EgnaProjekt.Migrations
{
    public partial class AdUer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personalInformations",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "('0001-01-01T00:00:00.0000000')"),
                    type = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalInformations", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FK_ClassId = table.Column<int>(type: "int", nullable: false),
                    FK_PersonIdEmployee = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_personalInformations",
                        column: x => x.FK_PersonIdEmployee,
                        principalTable: "personalInformations",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FK_EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FK_GradingTable = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Employees",
                        column: x => x.FK_EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ClassId = table.Column<int>(type: "int", nullable: false),
                    FK_PersonIdStudent = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Classes",
                        column: x => x.FK_ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Students_personalInformations1",
                        column: x => x.FK_PersonIdStudent,
                        principalTable: "personalInformations",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "gradingTables",
                columns: table => new
                {
                    GradingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    GradeSet = table.Column<DateTime>(type: "date", nullable: false),
                    FK_StudentId = table.Column<int>(type: "int", nullable: false),
                    FK_ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradingTables", x => x.GradingId);
                    table.ForeignKey(
                        name: "FK_gradingTables_Classes",
                        column: x => x.FK_ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_gradingTables_Students",
                        column: x => x.FK_StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ClassId = table.Column<int>(type: "int", nullable: false),
                    FK_StudentId = table.Column<int>(type: "int", nullable: false),
                    FK_ClassName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.SchoolId);
                    table.ForeignKey(
                        name: "FK_schools_Classes",
                        column: x => x.FK_ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_schools_Students",
                        column: x => x.FK_StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FK_EmployeeId",
                table: "Classes",
                column: "FK_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FK_GradingTable",
                table: "Classes",
                column: "FK_GradingTable");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FK_PersonIdEmployee",
                table: "Employees",
                column: "FK_PersonIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_gradingTables_FK_ClassId",
                table: "gradingTables",
                column: "FK_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_gradingTables_FK_StudentId",
                table: "gradingTables",
                column: "FK_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_schools_FK_ClassId",
                table: "schools",
                column: "FK_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_schools_FK_StudentId",
                table: "schools",
                column: "FK_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FK_ClassId",
                table: "Students",
                column: "FK_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FK_PersonIdStudent",
                table: "Students",
                column: "FK_PersonIdStudent");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_gradingTables",
                table: "Classes",
                column: "FK_GradingTable",
                principalTable: "gradingTables",
                principalColumn: "GradingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Employees",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_gradingTables",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "schools");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "gradingTables");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "personalInformations");
        }
    }
}
