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
                name: "Test",
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
                    table.PrimaryKey("PK_Test", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "ID", "Company", "Department", "Gender", "Name" },
                values: new object[] { new Guid("113def3b-08d8-48c2-86b5-90180cb95949"), "Company 2", "Dep 1", "Woman", "name 3" });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "ID", "Company", "Department", "Gender", "Name" },
                values: new object[] { new Guid("a37e2f12-3d37-4102-a791-ca2b55f09193"), "Company 1", "Dep 1", "Man", "name 1" });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "ID", "Company", "Department", "Gender", "Name" },
                values: new object[] { new Guid("e330c4db-03cd-49cb-8552-fe2598afdadb"), "Company 2", "Dep 1", "Man", "name 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
