using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U2.LoggerSvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniqueId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Call = table.Column<string>(type: "TEXT", nullable: true),
                    DateTimeOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeOff = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Band = table.Column<string>(type: "TEXT", nullable: true),
                    BandRx = table.Column<string>(type: "TEXT", nullable: true),
                    Continent = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Cqz = table.Column<int>(type: "INTEGER", nullable: false),
                    Dirty = table.Column<bool>(type: "INTEGER", nullable: false),
                    Dxcc = table.Column<int>(type: "INTEGER", nullable: false),
                    Frequency = table.Column<decimal>(type: "TEXT", nullable: false),
                    FrequencyRx = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gridsquare = table.Column<string>(type: "TEXT", nullable: true),
                    Iota = table.Column<string>(type: "TEXT", nullable: true),
                    IotaIslandId = table.Column<string>(type: "TEXT", nullable: true),
                    IsRunQso = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ituz = table.Column<int>(type: "INTEGER", nullable: false),
                    Lat = table.Column<decimal>(type: "TEXT", nullable: false),
                    Lon = table.Column<decimal>(type: "TEXT", nullable: false),
                    Mode = table.Column<string>(type: "TEXT", nullable: true),
                    MyCity = table.Column<string>(type: "TEXT", nullable: true),
                    MyCountry = table.Column<string>(type: "TEXT", nullable: true),
                    MyCqZone = table.Column<int>(type: "INTEGER", nullable: false),
                    MyGridsquare = table.Column<string>(type: "TEXT", nullable: true),
                    MyItuZone = table.Column<int>(type: "INTEGER", nullable: false),
                    MyLat = table.Column<decimal>(type: "TEXT", nullable: false),
                    MyLon = table.Column<decimal>(type: "TEXT", nullable: false),
                    MyName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Operator = table.Column<string>(type: "TEXT", nullable: true),
                    Propagation = table.Column<string>(type: "TEXT", nullable: true),
                    RstSent = table.Column<string>(type: "TEXT", nullable: true),
                    RstRcvd = table.Column<string>(type: "TEXT", nullable: true),
                    SatName = table.Column<string>(type: "TEXT", nullable: true),
                    SatMode = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<string>(type: "TEXT", nullable: true),
                    QrzId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEntries");
        }
    }
}
