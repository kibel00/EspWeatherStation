using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EspWeatherStation.Server.Migrations
{
    /// <inheritdoc />
    public partial class WeatherStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherStation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sensor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Value1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Value2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Value3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ReadingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherStation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherStation");
        }
    }
}
