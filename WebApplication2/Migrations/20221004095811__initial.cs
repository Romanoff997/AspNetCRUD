using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "ID", "Company", "Department", "Gender", "Name" },
                values: new object[] { new Guid("9bbc96b5-3dda-4297-8d08-b5348646098b"), "Company 2", "Dep 1", "Man", "name 2" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "ID", "Company", "Department", "Gender", "Name" },
                values: new object[] { new Guid("9e468402-2999-422b-8056-3a5002357a80"), "Company 1", "Dep 1", "Man", "name 1" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "ID", "Company", "Department", "Gender", "Name" },
                values: new object[] { new Guid("bd58569e-3659-49e8-bc42-711f51c077d2"), "Company 2", "Dep 1", "Woman", "name 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
