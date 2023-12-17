using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Repositories.Migrations
{
    public partial class TimingToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MornigShiftStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MornigShiftEndtTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AfternoonShiftStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AfternoonShiftEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timing", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timing");
        }
    }
}
