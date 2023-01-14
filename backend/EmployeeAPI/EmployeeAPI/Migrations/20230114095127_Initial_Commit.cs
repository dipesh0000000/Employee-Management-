using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAPI.Migrations
{
    public partial class Initial_Commit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Alias", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "SLC", 0, new DateTime(2023, 1, 14, 9, 51, 26, 812, DateTimeKind.Utc).AddTicks(7863), false, "School Leaving Certificate", 0, null },
                    { 2, "10 +2", 0, new DateTime(2023, 1, 14, 9, 51, 26, 812, DateTimeKind.Utc).AddTicks(8515), false, "Higher Secondary School", 0, null },
                    { 3, "Bachelor", 0, new DateTime(2023, 1, 14, 9, 51, 26, 812, DateTimeKind.Utc).AddTicks(8535), false, "Bachelor", 0, null },
                    { 4, "Master", 0, new DateTime(2023, 1, 14, 9, 51, 26, 812, DateTimeKind.Utc).AddTicks(8537), false, "Master", 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qualifications");
        }
    }
}
