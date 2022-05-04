/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

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
