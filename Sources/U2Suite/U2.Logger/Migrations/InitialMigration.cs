using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U2.Logger.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Callsign = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    QsoBeginTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QsoEndTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Frequency = table.Column<decimal>(type: "TEXT", nullable: false),
                    RstSent = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Mode = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Band = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    RstReceived = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Operator = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Hash = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingId = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    Value = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
