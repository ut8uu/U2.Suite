﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    RecordId = table.Column<Guid>(maxLength: 36, nullable: false),
                    Callsign = table.Column<string>(maxLength: 50, nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Frequency = table.Column<double>(nullable: false),
                    RstSent = table.Column<string>(maxLength: 8, nullable: false),
                    RstReceived = table.Column<string>(maxLength: 8, nullable: false),
                    Operator = table.Column<string>(maxLength: 64, nullable: false),
                    Comments = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
