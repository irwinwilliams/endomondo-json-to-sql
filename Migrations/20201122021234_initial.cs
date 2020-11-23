using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndomondoJsonToSQL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    StartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DurationS = table.Column<double>(type: "float", nullable: true),
                    DistanceKm = table.Column<double>(type: "float", nullable: true),
                    CaloriesKcal = table.Column<double>(type: "float", nullable: true),
                    AltitudeMinM = table.Column<double>(type: "float", nullable: true),
                    AltitudeMaxM = table.Column<double>(type: "float", nullable: true),
                    SpeedAvgKmh = table.Column<double>(type: "float", nullable: true),
                    SpeedMaxKmh = table.Column<double>(type: "float", nullable: true),
                    AscendM = table.Column<double>(type: "float", nullable: true),
                    DescendM = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
