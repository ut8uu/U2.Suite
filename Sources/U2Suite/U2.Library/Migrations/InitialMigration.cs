﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace U2.Library.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    Dimensions = table.Column<string>(maxLength: 80, nullable: false),
                    WeightGrams = table.Column<string>(maxLength: 50, nullable: false),
                    PowerWatts = table.Column<string>(maxLength: 80, nullable: false),
                    Image = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rigs_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ADI" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 56, "Philips" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 55, "NCG" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 54, "NationalPanasonic" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 53, "National" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 52, "Mizuho" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 51, "Minix" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 50, "Marconi" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 49, "Lowe" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 48, "Lafayette" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 47, "KW" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 46, "Kenwood" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 45, "KDK" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 44, "JRC" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 43, "Icom" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 42, "Hilberling" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 57, "QYT" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 58, "Racal" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 59, "RCA" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 60, "Regency" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 76, "Xiegu" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 75, "WJ" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 74, "Winradio" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 73, "Whistler" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 72, "Tentec" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 71, "Teltow" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 70, "Tecsun" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 41, "Heathkit" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 69, "Swan" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 67, "Star" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 66, "Standard" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 65, "Sony" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 64, "Sommerkamp" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 63, "Siemens" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 62, "Sangean" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 61, "Roberts" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 68, "Svera" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 40, "Handic" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 39, "Hammarlund" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 38, "Hallicrafters" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 17, "Braun" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "Belcom" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "Bearcat" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "Beaconsthlm" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "BC" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Baofeng" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Bando" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "Clegg" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Azden" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "ATV" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Atlas" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Apachelabs" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "AOR" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Anytone" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Alinco" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "AKD" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Atvstockholm" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 77, "Yaesu" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 19, "Collins" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 21, "Dabdrm" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 37, "Grundig" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 36, "GRE" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 35, "Gonset" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 34, "Geloso" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 33, "Galaxy" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 32, "Flexradio" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 31, "FDK" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 20, "Commander" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 30, "Eton" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 28, "Elad" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 27, "Eico" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 26, "Efjohnson" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 25, "Eddystone" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 24, "Drake" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 23, "Dragon" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 22, "DLS" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 29, "Elecraft" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 78, "Yupiteru" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1, "? mm (?in)", "ADI/ar146.jpg", "AR-146", "Hi: 50 W, Lo: ? W", 1, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1727, "333*133*333 mm (13.3*5.3*13.3in)", "Kenwood/ts830m.jpg", "TS-830M", @"AM: ~50 W DC (80 W DC input)
SSB: ~100 W PEP (220 W PEP input)
CW: ~100 W DC (180 W DC input)", 46, "13.5 Kg (29.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1728, "333*133*333 mm (13.3*5.3*13.3in)", "Kenwood/ts830s.jpg", "TS-830S", "Max 100 W", 46, "13.5 Kg (29.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1729, "339*135*375 mm (13.35*5.32*14.76in)", "Kenwood/ts850s.jpg", "TS-850S", @"AM: 10-40 W
FM: 20-100 W
SSB: 20-100 W
CW: 20-100 W
FSK: 20-100 W", 46, "9.4 Kg (20.7 lbs), without AT-850 option" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1730, "330*120*334 mm (13*4.72*13.1in)", "Kenwood/ts870s.jpg", "TS-870S", "Max 100 W (AM 25 W)", 46, "11.5 Kg (25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1731, "396*141*340 mm (15.59*5.56*13.38in)", "Kenwood/ts890s.jpg", "TS-890S", @"HF/6 m5-100 W (AM 5-25 W)


4 m5-50 W (AM 5-12.5 W), Europe only", 46, "15.8 Kg (34.83 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1732, "320*140*320 mm (12.6*5.51*12.6in)", "Kenwood/ts900.jpg", "TS-900", "SSB: 300 W (PEP input)CW: 200 W (input)FSK: 100 W (input)", 46, "12 Kg (26.46 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1733, "374*141*350 mm (14.72*5.55*13.78in)", "Kenwood/ts930s.jpg", "TS-930S", @"AM: ~25 W (80 W input)
SSB/CW: ~125 W (250 W input)
FSK: ~125 W (250 W input)", 46, "16.8 Kg (37 lbs), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1726, "335*155*335 mm (13.2*5.9*13.2in)", "Kenwood/ts820s.jpg", "TS-820S", @"SSB: ~100 W PEP (200 W PEP input) @ mains
CW: ~100 W DC (160 W DC input) @ mains
FSK: ~60 W (100 W input) @ mains", 46, "16.97 Kg (37.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1734, "401*141*350 mm (15.79*5.55*13.78in)", "Kenwood/ts940s.jpg", "TS-940S", @"AM: Max ~70 W (140 W input)
SSB/CW/FSK: Max ~100 W (250 W PEP input)
100% duty cycle", 46, "18.5 Kg (40.79 lbs)20 Kg (44.1 lbs), with AT-940" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1736, "409*154*446 mm (16.1*6.1*17.6in), projections included", "Kenwood/ts950sdx.jpg", "TS-950SDX", "AM: 10-40 WFM/SSB/CW/FSK: 20-150 W (1.9-24 MHz), 20-110 W (28 MHz)", 46, "23 Kg (50.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1737, "460*165*400 mm (18.1*6.5*15.75in)", "Kenwood/ts990s.jpg", "TS-990S", "5-200 W (AM: 2-50 W)", 46, "24.5 Kg (54 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1738, "281*107*344 mm (11.06*4.21*13.54in)", "Kenwood/tsb2000.jpg", "TS-B2000", @"HF5-100 W (AM: 5-25 W)


6 m5-100 W (AM: 5-25 W)


2 m5-100 W (AM: 5-25 W)


70 cm5-50 W (AM: 5-12.5 W)", 46, "7.5 Kg (16.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1739, "161*60*217 mm (6.34*2.36*8.54in)", "Kenwood/tw4000a.jpg", "TW-4000A", @"2 mHi: 25 W, Lo: 5 W


70 cmHi: 25 W, Lo: 5 W", 46, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1740, "150*50*200 mm (5.91*1.97*7.87in)", "Kenwood/tw4100e.jpg", "TW-4100E", "Hi: 45 / 35 W, Lo: 5 / 5 W", 46, "1.6 Kg (3.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1741, "330*180*310 mm (13*7.09*12.2in)", "Kenwood/trio_tx310.jpg", "Trio TX-310", "? W", 46, "11.5 Kg (25.35 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1742, "270*140*310 (10.63*5.51*12.2in)", "Kenwood/tx599customspecial.jpg", "Trio TX-599 Custom Special", @"AM: ~25-50 W (50-80 W input)
SSB/CW: ~50-100 W (100-160 W input)", 46, "12.5 Kg (27.56 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1735, "? mm", "Kenwood/ts950s.jpg", "TS-950S", "Max 150 W", 46, "23 Kg (50.71 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1743, "? mm (?in)", "KW/2000.jpg", "K.W. Electronics - KW 2000", @"SSB: ~50 W PEP (100 W PEP input)
CW: ~50 W (100 W input)", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1725, "335*155*335 mm (13.2*5.9*13.2in)", "Kenwood/ts820.jpg", "TS-820", @"SSB: ~100 W PEP (200 W PEP input) @ mains
CW: ~100 W DC (160 W DC input) @ mains
FSK: ~60 W (100 W input) @ mains", 46, "16.97 Kg (37.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1723, "270*96*260 mm (10.6*3.8*10.2in)", "Kenwood/ts811a.jpg", "TS-811A", "2-25 W (1 min TX / 3 min RX @ 25 W)", 46, "7.2 Kg (15.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1707, "? mm", "Kenwood/ts660.jpg", "TS-660", "Max 10 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1708, "? mm", "Kenwood/ts670.jpg", "TS-670", "Max 10 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1709, "270*96*270 mm (10.6*3.8*10.6in)", "Kenwood/ts680s.jpg", "TS-680S", @"HFAM: 40 W, FM: 50 W, SSB/CW: 100 W


6 mAM: 4 W, FM/SSB/CW: 10 W", 46, "6.1 Kg (13.45 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1710, "270*96*328 mm (10.6*3.8*12.9in)", "Kenwood/ts690s.jpg", "TS-690S", "HF: 100 W (AM: 40 W)6 m: 50 W (AM: 20 W)", 46, "6.9 Kg (15.2 lbs), without ATU" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1711, "278*124*320 mm (10.94*4.88*12.6in)", "Kenwood/ts700.jpg", "Trio/Kenwood TS-700", "FM/SSB/CW: 10 WAM: 3 W", 46, "11 Kg (24.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1712, "278*124*320 mm (10.94*4.88*12.6in)", "Kenwood/ts700a.jpg", "TS-700A", @"AM: 2 W
FM: 10 W
SSB: 10 W (PEP)
CW: 10 W", 46, "11 Kg (24.25 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1713, "278*124*320 mm (10.94*4.88*12.6in)", "Kenwood/ts700g.jpg", "TS-700G", @"AM: 2 to 3 W
FM: 10 W
SSB: 10 W (PEP)
CW: 10 W", 46, "11 Kg (24.25 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1724, "270*96*260 mm (10.6*3.8*10.2in)", "Kenwood/ts811e.jpg", "TS-811E", "2-25 W (1 min TX / 3 min RX @ 25 W)", 46, "7.2 Kg (15.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1714, "278*124*320 mm (10.94*4.88*12.6in)", "Kenwood/ts700gii.jpg", "Trio TS-700GII", "AM: 3 WFM/SSB/CW: 10 W", 46, "11 Kg (24.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1716, "270*96*260 mm (10.6*3.8*10.2in)", "Kenwood/ts711a.jpg", "TS-711A", "2-25 W", 46, "7.1 Kg (15.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1717, "270*96*260 mm (10.6*3.8*10.2in)", "Kenwood/ts711e.jpg", "TS-711E", "2-25 W (25% duty cycle @ 25 W)", 46, "7.1 Kg (15.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1718, "290*124*320 mm (11.42*4.88*12.6in)", "Kenwood/ts770.jpg", "Trio TS-770", @"2 mHi: 10 W, Lo: 1 W


70 cmHi: 10 W, Lo: 1 W", 46, "11 Kg (24.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1719, "290*124*320 mm (11.42*4.88*12.6in)", "Kenwood/ts770e.jpg", "TS-770E", @"2 mHi: 10 W, Lo: 1 W


70 cmHi: 10 W, Lo: 1 W", 46, "11 Kg (24.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1720, "? mm", "Kenwood/ts780.jpg", "TS-780", "10/10 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1721, "330*120*330 mm (13*4.72*13in)", "Kenwood/ts790a.jpg", "TS-790A", "FM/CW: 45/40 WSSB: 35/30 W", 46, "9.2 Kg (20.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1722, "330*120*330 mm (13*4.72*13in)", "Kenwood/ts790e.jpg", "TS-790E", "FM/CW: 45/40 WSSB: 35/30 W", 46, "9.2 Kg (20.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1715, "278*124*320 mm (10.94*4.88*12.6in)", "Kenwood/ts700s.jpg", "TS-700S", "AM: 3 WFM Hi/SSB/CW: 10 WFM Lo: 1 W", 46, "11 Kg (24.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1744, "355*160*336 mm (13.98*6.3*13.23in)", "KW/kw2000a.jpg", "K.W. Electronics - KW 2000A", @"SSB: ~100 W PEP (180 W PEP input)
CW: ~100 W (150 W input)", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1745, "355*160*336 mm (13.98*6.3*13.23in)", "KW/kw2000b.jpg", "K.W. Electronics - KW 2000B", @"SSB: ~100 W PEP (180 W PEP input)
CW: ~100 W (150 W input)", 47, "8.2 Kg (18 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1746, "355*160*336 mm (13.98*6.3*13.23in)", "KW/2000d.jpg", "K.W. Electronics - KW 2000D", @"SSB: ~100 W PEP (180 W PEP input)
CW: ~100 W (150 W input)", 47, "8.2 Kg (18 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1768, "308*130*235 mm (12.12*5.12*9.25in)", "Lafayette/ha460.jpg", "HA-460", "~12 W (20 W input)", 48, "8.62 Kg (19 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1769, "305*127*203 mm (12*5*8in)", "Lafayette/ha520.jpg", "HA-520", "", 48, "6.5 Kg (11.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1770, "? mm", "Lafayette/ha55a.jpg", "HA-55A", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1771, "? mm", "Lafayette/ha63.jpg", "HA-63", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1772, "? mm", "Lafayette/ha63a.jpg", "HA-63A", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1773, "241*57*140 mm (9.5*2.25*5.5in)", "Lafayette/ha650.jpg", "HA-650 (99-2570WX)", "2.5 W (input)", 48, "4.1 Kg (9 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1774, "? mm", "Lafayette/ha700.jpg", "HA-700", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1767, "152*53*200 mm (5.98*2.09*7.87in)", "Lafayette/ha45.jpg", "HA-45", "", 48, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1775, "390*210*240 mm (15.35*8.27*9.45in)", "Lafayette/he10.jpg", "HE-10", "", 48, "11 Kg (24.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1777, "381*178*254 mm (15*7*10in)", "Lafayette/he30.jpg", "HE-30", "", 48, "9.52 Kg (21 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1778, "? mm", "Lafayette/he40.jpg", "HE-40", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1779, "318*140*203 mm (12.5*5.5*8in)", "Lafayette/he45.jpg", "HE-45", "12 W (input)", 48, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1780, "318*140*203 mm (12.5*5.5*8in)", "Lafayette/he45a.jpg", "HE-45A", "", 48, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1781, "318*140*203 mm (12.5*5.5*8in)", "Lafayette/he50.jpg", "HE-50", "12 W", 48, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1782, "? mm", "Lafayette/he80.jpg", "HE-80", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1783, "333*159*305 mm (13.12*6.25*12in)", "Lafayette/kt390starflite.jpg", "KT-390 Starflite", "90 W (input)", 48, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1776, "359*210*235 mm (14.12*8.25*9.5in)", "Lafayette/he25voyager.jpg", "HE-25 Voyager", "AM: 70 W (input)CW: 120 W (input)", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1766, "152*53*200 mm (5.98*2.09*7.87in)", "Lafayette/ha39.jpg", "HA-39", "", 48, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1765, "381*190*254 mm (15*7.5*10in)", "Lafayette/ha350.jpg", "HA-350", "", 48, "11.34 Kg (25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1764, "380*190*260 mm (14.96*7.48*10.24in)", "Lafayette/ha230.jpg", "HA-230", "", 48, "9.5 Kg (20.94 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1747, "355*160*336 mm (13.98*6.3*13.23in)", "KW/kw2000e.jpg", "K.W. Electronics - KW 2000E", @"SSB: ~100 W PEP (180 W PEP input)
CW: ~100 W (150 W input)", 47, "8.2 Kg (18 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1748, "145*170*315 mm (5.7*6.7*12.4in)", "KW/76.jpg", "K.W. Electronics - KW 76", "", 47, "4.5 Kg (9.92 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1749, "? mm (?in)", "KW/77.jpg", "K.W. Electronics - KW 77 Mark I", "", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1750, "? mm (?in)", "KW/77markii.jpg", "K.W. Electronics - KW 77 Mark II", "", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1751, "? mm", "KW/atlanta.jpg", "K.W. Electronics - KW Atlanta", @"SSB: ~250 W PEP (500 W PEP input)
CW: ~175 W (350 W input)
AM: ~60 W (125 W input)", 47, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1752, "? mm (?in)", "KW/kw201.jpg", "K.W. Electronics - KW 201", "", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1753, "? mm (?in)", "KW/kw202.jpg", "K.W. Electronics - KW 202", "", 47, "7.71 Kg (17 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1754, "305*159*241 mm (12*6.25*9.5in)", "KW/valiant.jpg", "K.W. Electronics - KW Valiant", "AM: ~25 W (~8 W on 160 m)", 47, "7.26 Kg (16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1755, "? mm (?in)", "KW/vanguard.jpg", "K.W. Electronics - KW Vanguard", "AM: 50 W", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1756, "? mm (?in)", "KW/vespamarki.jpg", "K.W. Electronics - KW Vespa Mark I", "~50 W", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1757, "? mm (?in)", "KW/vespamarkii.jpg", "K.W. Electronics - KW Vespa Mark II", "SSB: ~100 W PEP (220 W PEP input)", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1758, "? mm (?in)", "KW/viceroymarkiii.jpg", "K.W. Electronics - KW Viceroy Mark III", "AM: Max 50 WSSB: Max 100 WCW: Max 80 W", 47, "20 Kg (44.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1759, "? mm (?in)", "KW/victor.jpg", "K.W. Electronics - KW Victor", "AM: 100 W", 47, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1760, "? mm", "Lafayette/lafayette_bcr101.jpg", "BCR-101", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1761, "? mm", "Lafayette/guardian5000.jpg", "Guardian 5000", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1762, "? mm (?in)", "Lafayette/ha146.jpg", "HA-146", "Hi: 25 W, Lo: 1 W", 48, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1763, "152*53*200 mm (5.98*2.09*7.87in)", "Lafayette/ha155.jpg", "HA-155", "", 48, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1706, "179*60*233 mm (7.05*2.36*9.17in)", "Kenwood/ts60s.jpg", "TS-60S", "90 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1784, "125*45*190 mm (4.92*1.77in)", "Lafayette/microp50.jpg", "Micro P50", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1705, "278*124*320 mm (10.94*4.88*12.6in)", "Kenwood/ts600.jpg", "TS-600", "10 W (AM: 5 W)", 46, "11 Kg (24.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1703, "? mm", "Kenwood/ts590s.jpg", "TS-590S", "Max 100/100 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1646, "Transceiver: 141*40*185 mm (5.55*1.58*7.28in)Head: 111*40*38 mm (4.37*1.58*1.5in)", "Kenwood/tmw706.jpg", "TMW-706S", "Hi: 50 / 50 WMid: 15 / 15 W, Lo: 2 / 2 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1647, "? mm", "Kenwood/tr1100.jpg", "Trio TR-1100", "1 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1648, "185*64*235 mm (7.28*2.52*9.25in)", "Kenwood/tr1200.jpg", "Trio TR-1200", "1 W", 46, "3 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1649, "? mm", "Kenwood/tr2e.jpg", "Trio TR-2E", "10 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1650, "158*52*210 mm (6.22*2.05*8.27in)", "Kenwood/tr50.jpg", "TR-50", "1 W", 46, "1.2 Kg (2.65 lbs), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1651, "180-60*240 mm (7.09*2.36*9.45in)", "Kenwood/tr7010.jpg", "Trio TR-7010", "~8 W (20 W input)", 46, "2.7 Kg (5.95 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1652, "170*60*230 mm (6.69*2.36*9.06in)", "Kenwood/tr7100.jpg", "Trio TR-7100", "10 W", 46, "2.1 Kg (4.63 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1645, "Transceiver: 141*40*185 mm (5.55*1.58*7.28in)Head: 111*40*38 mm (4.37*1.58*1.5in)", "Kenwood/tmw706.jpg", "TMW-706", "Hi: 20 / 20 WMid: 10 / 10 W, Lo: 2 / 2 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1653, "180*60*240 mm (7.1*2.4*9.45in)", "Kenwood/tr7200.jpg", "TR-7200", "Hi: 10 W, Lo: 1 W", 46, "2.5 Kg (5.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1655, "182*74*270 mm (7.16*2.91*10.63in)", "Kenwood/tr7400a.jpg", "TR-7400A", "Hi: 25 W, Lo: 5 W", 46, "2.8 Kg (6.17 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1656, "152*60*234 mm (5.98*2.36*9.21in)", "Kenwood/tr7500.jpg", "TR-7500", "Hi: 10 W, Lo: 1 W", 46, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1657, "180*60*195 mm (7.09*2.36*7.68in)", "Kenwood/tr751a.jpg", "TR-751A", "Hi: 25 W, Lo: 5 W (Adjustable from 2 to 25 W)", 46, "2.2 Kg (4.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1658, "180*60*195 mm (7.09*2.36*7.68in)", "Kenwood/tr751e.jpg", "TR-751E", "Hi: 25 W, Lo: 5 W (Adjustable from 2 to 25 W)", 46, "2.2 Kg (4.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1659, "161*61*230 mm (6.34*2.4*9.05in)", "Kenwood/tr7600.jpg", "TR-7600", "Hi: 10 W, Lo: 1 W", 46, "1.75 Kg (3.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1660, "161*61*230 mm (6.34*2.4*9.05in)", "Kenwood/tr7625.jpg", "TR-7625", "Hi: 25 W, Lo: 5 W", 46, "1.75 Kg (3.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1661, "147*51*198 mm (5.79*2.01*7.8in)", "Kenwood/tr7730.jpg", "TR-7730", "Hi: 25 W, Lo: 5 W", 46, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1654, "180*60*240 mm (7.1*2.4*9.45in)", "Kenwood/tr7200g.jpg", "TR-7200G", "Hi: 10 W, Lo: 1 W", 46, "2.5 Kg (5.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1662, "175*64*206 mm (6.89*2.52*8.11in)", "Kenwood/tr7800.jpg", "TR-7800", "Hi: 25 W, Lo: 5 W", 46, "2.1 Kg (4.63 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1644, "? mm", "Kenwood/tm942.jpg", "TM-942A", "Hi: 50 / 35 / 10 WMid: 10 / 10 / 10 W, Lo: 5 / 5 / 1 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1642, "? mm", "Kenwood/tm842.jpg", "TM-842", "Hi: 10/10 W, Lo: 5/1 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1626, "? mm", "Kenwood/tm642.jpg", "TM-642A", "Hi: 50 / 25 WMid: 10 / 10 W, Lo: 5 / 5 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1627, "140*40*200 mm (5.51*1.58*7.87in)", "Kenwood/tm701e.jpg", "TM-701E", "Hi: 25/25 W, Lo: 5/5 W", 46, "1.4 Kg (3.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1628, "140*40*200 mm (5.51*1.58*7.87in)", "Kenwood/tm702d.jpg", "TM-702D", @"HighMIdLow
2 m:25 W10 W2 W
70 cm:25 W10 W2 W", 46, "1.4 Kg (3.09 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1629, "140*40*200 mm (5.51*1.58*7.87in)", "Kenwood/tm702e.jpg", "TM-702E", @"HighMIdLow
2 m:25 W10 W2 W
70 cm:25 W10 W2 W", 46, "1.4 Kg (3.09 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1630, "150*50*205 mm (5.91*1.97*8.07in)", "Kenwood/tm721a.jpg", "TM-721A", "Hi: 45/35 W, Lo: 5/5 W", 46, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1631, "150*50*205 mm (5.91*1.97*8.07in)", "Kenwood/tm721e.jpg", "TM-721E", "Hi: 45/35 W, Lo: 5/5 W", 46, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1632, "? mm", "Kenwood/tm731a.jpg", "TM-731A", "Hi: 50/35 W, Lo: 5/5 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1643, "? mm", "Kenwood/tm941a.jpg", "TM-941A", "Hi: 50 / 35 / 10 WMid: 10 / 10 / 5 W, Lo: 5 / 5 / 1 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1633, "? mm", "Kenwood/tm731e.jpg", "TM-731E", "Hi: 50/35 W, Lo: 5/5 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1635, "141*42*175 mm (5.55*1.65*6.89in)", "Kenwood/tm732e.jpg", "TM-732E", "Hi: 50/35 WMid: 10/10 W, Lo: 5/5 W", 46, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1636, "? mm", "Kenwood/tm733e.jpg", "TM-733E", "Hi: 50 W/35 W, Lo: ?/? W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1637, "150*50*175 mm (5.91*1.97*6.89in)", "Kenwood/tm741a.jpg", "TM-741A", "Hi: 50/35 WMid: 10/10 W, Lo: 5/5 W", 46, "1.6 Kg (3.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1638, "150*50*175 mm (5.91*1.97*6.89in)", "Kenwood/tm741e.jpg", "TM-741E", "Hi: 50/35 WMid: 10/10 W, Lo: 5/5 W", 46, "1.6 Kg (3.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1639, "150*50*175 mm (5.91*1.97*6.89in)", "Kenwood/tm742a.jpg", "TM-742A", "Hi: 50/35 WMid: 10/10 W, Lo: 5/5 W", 46, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1640, "150*50*175 mm (5.91*1.97*6.89in)", "Kenwood/tm742e.jpg", "TM-742E", "Hi: 50/35 WMid: 10/10 W, Lo: 5/5 W", 46, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1641, "140*40*175 mm (5.5*1.6*6.9in)", "Kenwood/tm833.jpg", "TM-833S", "Hi: 35/10 WMid: 10 / - W, Lo: 5/1 W", 46, "1.3 Kg (2.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1634, "141*42*175 mm (5.55*1.65*6.89in)", "Kenwood/tm732a.jpg", "TM-732A", "Hi: 50/35 WMid: 10/10 W, Lo: 5/5 W", 46, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1663, "175*64*220 mm (6.89*2.52*8.66in)", "Kenwood/tr7850_us.jpg", "TR-7850", "Hi: 40 W, Lo: 5~10 W", 46, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1664, "175*64*206 mm (6.89*2.52*8.11in)", "Kenwood/tr7930.jpg", "TR-7930", "Hi: 25 W, Lo: 5 W", 46, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1665, "175*64*220 mm (6.89*2.52*8.66in)", "Kenwood/tr7950.jpg", "TR-7950", "Hi: 45 W, Lo: 5 W", 46, "1.9 Kg (4.19 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1687, "270*96*305 mm (10.6*3.8*12.1in)", "Kenwood/ts450s.jpg", "TS-450S", "AM: Max 40 WFM/SSB/CW/FSK: Max 100 W", 46, "6.3 Kg (13.9 lbs), without ATU" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1688, "Transceiver: 179*69.5*278 mm (7*2.75*10.9in)Control panel: 183*78*68 mm (7.2*3*2.6in)", "Kenwood/ts480.jpg", "TS-480HX", @"10-160 m5-200 W (AM 5-50 W)


6 m5-100 W (AM 5-25 W)", 46, "Transceiver: 3.2 Kg (7 lbs)Control panel: 500 gr (1.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1689, "Transceiver: 179*69.5*278 mm (7*2.75*10.9in)Control panel: 183*78*68 mm (7.2*3*2.6in)", "Kenwood/ts480.jpg", "TS-480SAT", @"AM: 5-25 W
FM/SSB/CW/FSK: 5-100 W", 46, "Transceiver: 3.2 Kg (7 lbs)Control panel: 500 gr (1.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1690, "179*60*233 mm (7.05*2.36*9.17in)", "Kenwood/ts50s.jpg", "TS-50S", "Hi: 100 W (AM: 25 W)Mid: 50 W (AM: 17 W)Lo: 10 W (AM: 5.5 W)", 46, "2.9 Kg (6.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1691, "330*215*345 mm (12.99*8.46*13.58in)", "Kenwood/ts510.jpg", "Trio TS-510", "15-80 m: 160 W (input)10 m: 120 W (input)", 46, "9.5 Kg (20.94 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1692, "330*185*346 mm (13*7.28*13.62in)", "Kenwood/ts511s.jpg", "TS-511S", @"SSB: ~250 W PEP (500 W PEP input)
CW: ~150 (300 W input)", 46, "10 Kg (22 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1693, "330*195*355 (13*7.67*13.98in)", "Kenwood/ts515s.jpg", "TS-515S", @"SSB: ~250 W PEP (500 W PEP input)
CW: ~150 (300 W input)", 46, "9.5 Kg (20.94 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1686, "270*96*313 mm (10.6*3.78*12.3in)", "Kenwood/ts440s.jpg", "TS-440S", @"AM: Max 50 W
FM/SSB/CW/FSK: 100 W", 46, "6.3 Kg (13.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1694, "335*150*335 mm (13.2*5.9*13.2in)", "Kenwood/ts520.jpg", "TS-520", "Max 100 W", 46, "17 Kg (37.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1696, "333*153*335 mm (13.11*6.02*13.2in)", "Kenwood/ts520se.jpg", "TS-520SE (E=Economy)", @"SSB: ~100 W PEP (200 W PEP input)
CW: ~100 W DC (160 W DC input)", 46, "16 Kg (35.27 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1697, "333*133*333 mm (13.3*5.3*13.3in)", "Kenwood/ts530s.jpg", "TS-530S", @"SSB: ~100 W PEP (220 W PEP input)
CW: ~100 W DC (180 W DC input)", 46, "12.8 Kg (28.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1698, "333*133*333 mm (13.3*5.3*13.3in)", "Kenwood/ts530sp.jpg", "TS-530SP", @"SSB: ~100 W PEP (220 W PEP input)
CW: ~100 W DC (180 W DC input)", 46, "12.8 Kg (28.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1699, "270*96*271 mm (10.63*3.78*10.67in)", "Kenwood/ts570d.jpg", "TS-570D", @"AM: 5-25 W (in 5 W steps)
FM/SSB/CW/FSK: 5-100 W (in 5 W steps)", 46, "6.8 Kg (15 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1700, "270*96*271 mm (10.63*3.78*10.67in)", "Kenwood/ts570dg.jpg", "TS-570D(G)", @"AM: 5-25 W (in 5 W steps)
FM/SSB/CW/FSK: 5-100 W (in 5 W steps)", 46, "6.8 Kg (15 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1701, "270*96*271 mm (10.63*3.78*10.67in)", "Kenwood/ts570s.jpg", "TS-570S", @"AM: 5-25 W (in 5 W steps)
FM/SSB/CW/FSK: 5-100 W (in 5 W steps)", 46, "6.8 Kg (15 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1702, "270*96*271 mm (10.63*3.78*10.67in)", "Kenwood/ts570sg.jpg", "TS-570S(G)", @"AM: 5-25 W (in 5 W steps)
FM/SSB/CW/FSK: 5-100 W (in 5 W steps)", 46, "6.8 Kg (15 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1695, "333*153*335 mm (13.11*6.02*13.2in)", "Kenwood/ts520s.jpg", "TS-520S", @"SSB: ~100 W PEP (200 W PEP input)
CW: ~100 W DC (160 W DC input)", 46, "16 Kg (35.27 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1685, "270*96*275 mm (10.6*3.8*275in)", "Kenwood/ts43x.jpg", "TS-43X", @"AM: ~40 W (60 W input)
FM: ~60 W (120 W input)
SSB: ~120 W PEP (250 W PEP input)
CW: ~100 W DC (200 W DC input)", 46, "6.5 Kg (14.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1684, "270*96*275 mm (10.6*3.8*275in)", "Kenwood/ts430s.jpg", "TS-430S", @"AM: ~40 W (60 W input)
FM: ~60 W (120 W input)
SSB: ~120 W PEP (250 W PEP input)
CW: ~100 W DC (200 W DC input)", 46, "6.5 Kg (14.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1683, "281*107*371 mm (11.06*4.21*14.61in)", "Kenwood/ts2000.jpg", "TS-2000X", @"HF5-100 W (AM: 5-25 W)


6 m5-100 W (AM: 5-25 W)


2 m5-100 W (AM: 5-25 W)


70 cm5-50 W (AM: 5-12.5 W)


23 cm1-10 W (AM: 1-2.5 W)", 46, "8.2 Kg (18.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1666, "180*60*240 mm (7.1*2.4*9.45in)", "Kenwood/tr8300.jpg", "TR-8300", "Hi: 10 W, Lo: 1 W", 46, "2.3 Kg (5.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1667, "147*51*193 mm (5.79*2.01*7.6in)", "Kenwood/tr8400.jpg", "TR-8400", "Hi: 10 W, Lo: 1 W", 46, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1668, "180*60*215 mm (7.09*2.36*8.46in)", "Kenwood/tr851e.jpg", "TR-851E", "Hi: 25 W, Lo: 5 W (Adjustable from 2 to 25 W)", 46, "2.5 Kg (5.51 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1669, "170*68*234 mm (6.69*2.68*9.21in)", "Kenwood/tr9000.jpg", "TR-9000", "Hi: 10 W, Lo: 1 W", 46, "2.5 Kg (5.51 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1670, "170*68*241 mm (6.7*2.68*9.49in)", "Kenwood/tr9130.jpg", "TR-9130", "Hi: 25 W, Lo: 5 W", 46, "2.4 Kg (5.29 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1671, "170*68*260 mm (6.69*2.68*10.24in)", "Kenwood/tr9300.jpg", "Trio TR-9300", "Hi: 10 W, Lo: 1 W", 46, "2.4 Kg (5.29 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1672, "170*68*241 mm (6.69*2.68*9.49in)", "Kenwood/tr9500.jpg", "TR-9500", "Max 10 W", 46, "2.7 Kg (5.94 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1673, "241*94*293 mm (9.49*3.7*11.54in)", "Kenwood/ts120s.jpg", "/Trio TS-120S", @"SSB (10 m): ~80 W PEP (160 W PEP input)
SSB (15-80 m): ~100 W PEP (200 W PEP input)
CW (10 m): ~80 W DC (140 W DC input)
CW (15-80 m): ~100 W DC (160 W DC input)", 46, "5.6 Kg (12.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1674, "241*94*235 mm (9.49*3.7*9.25in)", "Kenwood/ts120v.jpg", "TS-120V", @"SSB: ~10 W PEP (25 W PEP input)
CW: ~10 W DC (20 W DC input)", 46, "4.9 Kg (10.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1675, "241*94*293 mm (9.6*3.8*11.7in)", "Kenwood/ts130s.jpg", "/Trio TS-130S", @"80-15 m: Max 100 W
10 m: Max 80 W", 46, "5.6 Kg (12.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1676, "241*94*293 mm (9.6*3.8*11.7in)", "Kenwood/ts130se.jpg", "TS-130SE (E=Economy)", @"80-15 m: Max 100 W
10 m: Max 80 W", 46, "5.6 Kg (12.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1677, "241*94*235 mm (9.6*3.8*9.4in)", "Kenwood/trio_ts130v.jpg", "/Trio TS-130V", @"SSB: Max 10 W (PEP)
CW: Max 10 W", 46, "4.9 Kg (10.8 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1678, "270*96*270 mm (10.6*3.8*10.6in)", "Kenwood/ts140s.jpg", "TS-140S", @"AM: 40 W
FM: 50 W
SSB/CW: 100 W", 46, "6.1 Kg (13.45 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1679, "325*133*287 mm (12.5*5.4*11.2in)", "Kenwood/ts180s.jpg", "TS-180S", "Max 100 W (slightly less on 10 m)", 46, "11.5 Kg (25.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1680, "325*133*287 mm (12.5*5.4*11.2in)", "Kenwood/ts180v.jpg", "Trio TS-180V", "Max 10 W", 46, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1681, "281*107*371 mm (11.06*4.21*14.61in)", "Kenwood/ts2000.jpg", "TS-2000", @"HF5-100 W (AM: 5-25 W)


6 m5-100 W (AM: 5-25 W)


2 m5-100 W (AM: 5-25 W)


70 cm5-50 W (AM: 5-12.5 W)", 46, "7.8 Kg (17.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1682, "281*107*371 mm (11.06*4.21*14.61in)", "Kenwood/ts2000le.jpg", "TS-2000LE", @"HF5-100 W (AM: 5-25 W)


6 m5-100 W (AM: 5-25 W)


2 m5-100 W (AM: 5-25 W)


70 cm5-50 W (AM: 5-12.5 W)", 46, "7.8 Kg (17.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1704, "270*96*291 mm (10.63*3.78*11.46in)", "Kenwood/ts590sg.jpg", "TS-590SG", "5-100 W (AM 5-25 W)", 46, "7.4 Kg (16.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1625, "? mm", "Kenwood/tm631a.jpg", "TM-631A", "Hi: 50/25 W, Lo: 5/5 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1785, "? mm", "Lafayette/pf30.jpg", "PF-30", "", 48, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1787, "185*80*175 mm (7.28*3.15*6.89in)", "Lowe/lowe_hf150.jpg", "HF-150", "", 49, "1.3 Kg (2.87 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1889, "320*225*100 mm (12.6*8.86*3.94in)", "NationalPanasonic/dr22_rf2200bs.jpg", "National Panasonic DR-22 (RF-2200BS)", "", 54, "3.18 Kg (7.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1890, "381*246*120 mm (15*9.68*4.72in)", "NationalPanasonic/dr28.jpg", "National Panasonic DR-28 (RF-2800LBS)", "", 54, "3.9 Kg (8.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1891, "381*246*120 mm (15*9.68*4.72in)", "NationalPanasonic/dr29.jpg", "Panasonic DR-29 (RF-2900LBS)", "", 54, "3.9 Kg (8.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1892, "371*122*241 mm (14.61*4.8*9.49in)", "NationalPanasonic/dr31.jpg", "National Panasonic DR-31 (RF-3100L)", "", 54, "3.2 Kg (7.06 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1893, "482*200*354 mm (18.98*7.87*13.94in)", "NationalPanasonic/nationalpanasonic_dr48.jpg", "National Panasonic DR-48", "", 54, "8 Kg (17.64 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1894, "482*200*354 mm (18.98*7.87*13.94in)", "NationalPanasonic/nationalpanasonic_dr49.jpg", "National Panasonic DR-49 (RF-4900LBS)", "", 54, "8 Kg (17.64 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1895, "376*122*291 mm (14.8*4.8*11.46in)", "NationalPanasonic/drb600.jpg", "Panasonic DR-B600 (RF-B600LBS)", "", 54, "4.6 Kg (10.14 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1888, "220*200*70 mm (8.66*7.87*2.76in)", "NationalPanasonic/cougarno7.jpg", "National Panasonic Cougar No7 (RF-877)", "", 54, "1.9 Kg (4.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1896, "220*200*70 mm (8.66*7.87*2.76in)", "NationalPanasonic/gx400m_rf966mb.jpg", "National Panasonic GX-400M (RF-966MB)", "", 54, "1.9 Kg (4.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1898, "265*157*80 mm (10.43*6.18*3.15in)", "NationalPanasonic/gx5ii_rf1405l.jpg", "Panasonic GX-5II (RF-1405L)", "", 54, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1899, "? mm", "NationalPanasonic/panasonic_re1800.jpg", "Panasonic RE-1800", "", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1900, "265*157*80 mm (10.43*6.18*3.15in)", "NationalPanasonic/rf1405.jpg", "Panasonic RF-1405", "", 54, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1901, "320*225*100 mm (12.6*8.86*3.94in)", "NationalPanasonic/rf2200.jpg", "Panasonic RF-2200", "", 54, "3.18 Kg (7.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1902, "381*246*120 mm (15*9.68*4.72in)", "NationalPanasonic/rf2800.jpg", "Panasonic RF-2800", "", 54, "3.9 Kg (8.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1903, "381*246*120 mm (15*9.68*4.72in)", "NationalPanasonic/rf2900.jpg", "Panasonic RF-2900", "", 54, "3.9 Kg (8.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1904, "371*122*241 mm (14.61*4.8*9.49in)", "NationalPanasonic/rf3100.jpg", "Panasonic RF-3100", "", 54, "3.2 Kg (7.06 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1897, "220*200*70 mm (8.66*7.87*2.76in)", "NationalPanasonic/gx400_rf966lb.jpg", "National Panasonic GX-400 (RF-966LB)", "", 54, "1.9 Kg (4.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1905, "482*200*354 mm (18.98*7.87*13.94in)", "NationalPanasonic/rf4800.jpg", "Panasonic RF-4800", "", 54, "8 Kg (17.64 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1887, "? mm", "National/sw58c.jpg", "SW-58C", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1885, "? mm", "National/sw5.jpg", "SW-5", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1869, "? mm", "National/nc46.jpg", "NC-46", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1870, "? mm", "National/nc57.jpg", "NC-57", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1871, "? mm", "National/nc60.jpg", "NC-60", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1872, "? mm", "National/nc66.jpg", "NC-66", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1873, "? mm", "National/nc80x.jpg", "NC-80X", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1874, "? mm", "National/nc81x.jpg", "NC-81X", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1875, "? mm", "National/nc88.jpg", "NC-88", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1886, "279*178*178 mm (11*7*7in)", "National/sw54.jpg", "SW-54", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1876, "? mm", "National/nc98.jpg", "NC-98", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1878, "? mm", "National/ncx3.jpg", "NCX-3", "100 W", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1879, "? mm", "National/ncx5.jpg", "NCX-5", "100 W", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1880, "? mm", "National/ncx5mkii.jpg", "NCX-5 MkII", "AM: 100 W (input)SSB: 200 W (PEP input)CW: 200 W (input)", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1881, "? mm", "National/ntx30.jpg", "NTX-30", "30 W", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1882, "? mm", "National/srr.jpg", "SRR", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1883, "? mm (?in)", "National/sw3.jpg", "SW-3", "", 53, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1884, "? mm", "National/sw4.jpg", "SW-4", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1877, "? mm", "National/ncx1000.jpg", "NCX-1000", "AM: 300 WSSB: 570 W (PEP)CW: 570 W", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1906, "482*200*354 mm (18.98*7.87*13.94in)", "NationalPanasonic/rf4900.jpg", "Panasonic RF-4900", "", 54, "8 Kg (17.64 lb), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1907, "? mm", "NationalPanasonic/rjx1011.jpg", "National RJX-1011D", "? W", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1908, "? mm", "NationalPanasonic/rjx202.jpg", "National RJX-202", "? W", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1930, "Transceiver: 98*35*118 mm (3.86*1.38*4.65in)Control mike: ? mm (?in)", "QYT/ktwp12.jpg", "KT-WP12", @"HighLow
2 m:25 W? W
70 cm:20 W? W", 57, "Transceiver: 890 g (1.96 lb)Control mike: ? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1931, "? mm", "Racal/racal_ra117.jpg", "RA-117", "", 58, "28 Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1932, "? mm", "Racal/racal_ra17l.jpg", "RA-17L", "", 58, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1933, "? mm", "Racal/ra217.jpg", "RA-217", "", 58, "28 Kg (61.73 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1934, "483*133*470 mm (19*5.25*18.5in)", "Racal/racal_ra6790gm.jpg", "RA-6790/GM", "", 58, "14.51 Kg (32 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1935, "483*133*500 mm (19.02*5.24*19.69in)", "Racal/racal_ra1218.jpg", "RA-1218", "", 58, "15 Kg (33.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1936, "483*133*458 mm (19*5.29*18in)", "Racal/racal_ra1792.jpg", "RA-1792", "", 58, "14 Kg (31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1929, "62*128*35 mm (2.44*5.04*1.38in)", "QYT/kt8r.jpg", "KT-8R", @"HighLow
2 m:4 W1 W
1.25 m:4 W1 W
350 MHz:4 W1 W
70 cm:4 W1 W", 57, "230 g (8.11 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1937, "489*279*489 mm (19.25*11*19.25in), with cabinet", "RCA/ar88d.jpg", "AR-88D", "", 59, "44.4 Kg (97.9 lbs), with cabinet" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1939, "489*279*489 mm (19.25*11*19.25)", "RCA/cr88a.jpg", "CR-88A", "", 59, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1940, "? mm (?in)", "Regency/actc4h.jpg", "ACT-C4H", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1941, "? mm (?in)", "Regency/actc4hlu.jpg", "ACT-C4 H/L/U", "", 60, "? g (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1942, "? mm (?in)", "Regency/actr10hlu.jpg", "ACT-R10 H/L/U", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1943, "267*76*178 mm (10.5*3*7in)", "Regency/d100.jpg", "D-100", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1944, "267*76*178 mm (10.5*3*7in)", "Regency/d300.jpg", "D-300", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1945, "127*35*165 mm (5*1.38*6.5in)", "Regency/inf1.jpg", "INF-1 \"Informant\"", "", 60, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1938, "489*279*489 mm (19.25*11*19.25)", "RCA/ar88lf.jpg", "AR-88LF", "", 59, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1928, "98*35*118 mm (3.86*1.38*4.65in)", "QYT/kt8900r.jpg", "KT-8900R", @"2 mHi: 25 W, Lo: ? W


1.25 mHi: ? W, Lo: ? W


70 cmHi: 20 W, Lo: ? W", 57, "408 g (14.4 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1927, "98*43*126 mm (3.86*1.69*4.96in)", "QYT/kt8900d.jpg", "KT-8900D", @"2 mHi: 25 W, Lo: 15 W


70 cmHi: 20 W, Lo: 12 W", 57, "448 g (0.99 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1926, "98*35*118 mm (3.86*1.38*4.65in)", "QYT/kt8900.jpg", "KT-8900", @"2 mHi: 25 W, Lo: ? W


70 cmHi: 20 W, Lo: ? W", 57, "408 g (14.4 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1909, "? mm", "NationalPanasonic/rjx230.jpg", "National RJX-230", "? W", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1910, "? mm", "NationalPanasonic/rjx601.jpg", "National RJX-601", "? W", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1911, "? mm", "NationalPanasonic/rjx610.jpg", "National RJX-610", "Max 2.5 W", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1912, "? mm", "NationalPanasonic/rjx661.jpg", "National RJX-661", "? W", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1913, "? mm", "NationalPanasonic/rjx715.jpg", "National RJX-715", "Hi: 10 W, Lo: 2 W", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1914, "? mm", "NationalPanasonic/rjx751.jpg", "National RJX-751", "Max 10 W", 54, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1915, "305*152*406 mm (12*6*16in)", "NationalPanasonic/rjx810d.jpg", "National RJX-810D", "100 W", 54, "10.21 Kg (22.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1916, "305*152*406 mm (12*6*16in)", "NCG/ncg_10160m.jpg", "10/160M", "100 W", 55, "10.21 Kg (22.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1917, "? mm", "NCG/ncg15m.jpg", "15M", "Hi: 10 W, Lo: 2 W", 55, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1918, "? mm", "NCG/ncg_15sb.jpg", "15SB", "Hi: 10 W, Lo: 1 W", 55, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1919, "246*99*269 mm (9.68*3.9*10.59in)", "NCG/72150.jpg", "7/21/50", "Max 10 W", 55, "5 Kg (11.02 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1920, "? mm", "Philips/philips_ae3905.jpg", "AE3905", "", 56, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1921, "? mm", "Philips/philips_d2935.jpg", "D-2935", "", 56, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1922, "? mm", "Philips/philips_d2999pll.jpg", "D-2999PLL", "", 56, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1923, "140*43*172 mm (5.51*1.69*6.77in)", "QYT/kt780plus.jpg", "KT-780 Plus (VHF)", @"HighMidLow
2 m:100 W50 W20 W", 57, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1924, "140*43*172 mm (5.51*1.69*6.77in)", "QYT/kt780plus_uhf.jpg", "KT-780 Plus (UHF)", @"HighMidLow
70 cm:80 W40 W20 W", 57, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1925, "103*47*126 mm (4.06*1.85*4.96in)", "QYT/kt7900d.jpg", "KT-7900D", @"2 mMax 25 W


1.25 mMax 25 W


350 MHzMax 20 W


70 cmMax 20 W", 57, "448 gr (15.8 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1868, "? mm", "National/nc44.jpg", "NC-44", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1786, "255*100*200 mm (10.04*3.94*7.87in)", "Lowe/lowe_hf125.jpg", "HF-125", "", 49, "1.8 Kg (3.97 lbs), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1867, "? mm", "National/nc400.jpg", "NC-400", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1865, "495*286*381 mm (19.5*11.25*15in)", "National/nc303.jpg", "NC-303", "", 53, "27.2 Kg (60 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1808, "? mm", "Mizuho/fx7.jpg", "FX-7", "? W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1809, "165*63*185 mm (6.5*2.48*7.28in)", "Mizuho/mk610.jpg", "MK-610", "1 W", 52, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1810, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx10z_top.jpg", "MX-10Z", "300 mW", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1811, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx14s.jpg", "MX-14S", "2 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1812, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx15_top.jpg", "MX-15", "300 mW", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1813, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx21s.jpg", "MX-18S", "2 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1814, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx2.jpg", "MX-2", "200 mW", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1807, "? mm", "Mizuho/fx6.jpg", "FX-6", "? W", 52, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1815, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx21s.jpg", "MX-21S", "2 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1817, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mizuho_mx28s_top.jpg", "MX-28S", "2 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1818, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx2f.jpg", "MX-2F", "1 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1819, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mizuho_mx.jpg", "MX-3.5S", "2 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1820, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx6_top.jpg", "MX-6", "250 mW", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1821, "? mm", "Mizuho/mx606d.jpg", "MX-606D", "10 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1822, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx6s.jpg", "MX-6S", "1 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1823, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx6z_top.jpg", "MX-6Z", "250 mW", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1816, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx21s.jpg", "MX-24S", "2 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1824, "66*142*39 mm (2.6*5.59*1.54in)", "Mizuho/mx7s_top.jpg", "MX-7S", "Max 2 W", 52, "645 gr (22.75 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1806, "? mm", "Mizuho/fx21.jpg", "FX-21", "? W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1804, "202*65*173 mm (7.95*2.56*6.81in)", "Mizuho/mizuho_dc7d.jpg", "DC-7D", "1 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1788, "? mm", "Lowe/lowe_hf225.jpg", "HF-225", "", 49, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1789, "? mm", "Lowe/lowe_hf235.jpg", "HF-235", "", 49, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1790, "? mm", "Lowe/lowe_hf250.jpg", "HF-250", "", 49, "?" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1791, "210*35*195 mm (8.27*1.38*7.68in)", "Lowe/lowe_hf350.jpg", "HF-350 (Europa version)", "", 49, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1792, "? mm (?in)", "Marconi/marconi_atalanta.jpg", "Atalanta", "", 50, "35 Kg (77.16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1793, "406*311*419 mm (16*12.25*16.5in)", "Marconi/marconi_cr1002.jpg", "CR100/2", "", 50, "37.19 Kg (82 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1794, "406*311*419 mm (16*12.25*16.5in)", "Marconi/marconi_cr1008.jpg", "CR100/8", "", 50, "37.19 Kg (82 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1805, "202*65*173 mm (7.95*2.56*6.81in)", "Mizuho/dc7x.jpg", "DC-7X", "2 W", 52, "1.9 Kg (4.19 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1795, "? mm", "Marconi/marconi_mercury.jpg", "Mercury", "", 50, "35 Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1797, "150*45*155 mm (5.91*1.77*6.1in)", "Minix/minix_mr12s.jpg", "MR-12S", "", 51, "0.8 Kg (1.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1798, "120*40*190 mm (4.72*1.58*7.48in)", "Minix/minix_mr2s.jpg", "MR-2S", "", 51, "750 gr (1.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1799, "360*160*220 mm (14.17*6.3*8.66in)", "Minix/minix_mr73b.jpg", "MR-73B", "", 51, "6 Kg (13.23 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1800, "320*150*220 mm (12.6*5.91*8.66in)", "Minix/minix_mto20a.jpg", "MTO-20A", "Max 10 W", 51, "6 Kg (13.23 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1801, "300*160*340 mm (11.81*6.3*13.39in)", "Minix/minix_mtr25.jpg", "MTR-25", "Max 10 W", 51, "6 Kg (13.23 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1802, "300*160*340 mm (11.81*6.3*13.39in)", "Minix/minix_mtr25s.jpg", "MTR-25S", "Max 8 W", 51, "6 Kg (13.23 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1803, "? mm", "Mizuho/dc701.jpg", "DC-701", "1 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1796, "225*100*165 mm (8.86*3.94*6.5in)", "Minix/minix_mr101.jpg", "MR-101", "", 51, "2.5 Kg (5.51 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1825, "? mm", "Mizuho/p21dx.jpg", "P-21DX", "1 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1826, "? mm", "Mizuho/p7dx.jpg", "P-7DX", "1 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1827, "? mm", "Mizuho/mizuho_qp10.jpg", "QP-10", "1 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1849, "? mm", "National/nc101x.jpg", "NC-101X", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1850, "? mm", "National/nc105.jpg", "NC-105", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1851, "? mm", "National/nc109.jpg", "NC-109", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1852, "? mm", "National/nc121.jpg", "NC-121", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1853, "? mm", "National/nc125.jpg", "NC-125", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1854, "? mm", "National/nc140.jpg", "NC-140", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1855, "? mm", "National/nc155.jpg", "NC-155", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1848, "? mm", "National/nc100xa.jpg", "NC-100XA", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1856, "551*317*257 mm (21.69*12.48*10.12in)", "National/nc173.jpg", "NC-173 (NC-173T)", "", 53, "19 Kg (41.89 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1858, "? mm", "National/nc183.jpg", "NC-183", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1859, "? mm", "National/nc188.jpg", "NC-188", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1860, "? mm", "National/nc190.jpg", "NC-190", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1861, "? mm", "National/nc200.jpg", "NC-200", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1862, "Table version: 489*279*305 mm (19.25*11*12in)Rack version: 483*267*444 mm (19*10.5*17.5in)", "National/nc240d.jpg", "NC-240D", "", 53, "Table version: 27.2 Kg (60 lbs)Rack version: 29.5 Kg (65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1863, "? mm", "National/nc270.jpg", "NC-270", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1864, "? mm", "National/nc300.jpg", "NC-300", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1857, "551*317*257 mm (21.69*12.48*10.12in)", "National/nc173t.jpg", "NC-173T", "", 53, "19 Kg (41.89 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1847, "? mm", "National/nc100.jpg", "NC-100", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1846, "? mm", "National/national200.jpg", "200", "100 W", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1845, "? mm", "National/hrosr.jpg", "HRO-SR", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1828, "? mm", "Mizuho/mizuho_qp21.jpg", "QP-21", "1 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1829, "? mm", "Mizuho/mizuho_qp50.jpg", "QP-50", "1 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1830, "? mm", "Mizuho/mizuho_qp7.jpg", "QP-7", "1 W", 52, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1831, "? mm", "Mizuho/mizuho_sb2m.jpg", "SB-2M", "1 W", 52, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1832, "? mm", "Mizuho/sb2x.jpg", "SB-2X", "1 W", 52, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1833, "150*56*195 mm (5.91*2.2*7.68in)", "Mizuho/mizuho_trx100.jpg", "TRX-100", "1 W", 52, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1834, "? mm", "National/1_10.jpg", "1-10", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1835, "? mm", "National/ags.jpg", "AGS", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1836, "? mm", "National/fb7.jpg", "FB-7", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1837, "? mm (?in)", "National/hfs.jpg", "HFS", "", 53, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1838, "438*228*305 mm (17.24*8.98*12.01in)", "National/hro5.jpg", "HRO-5TA1", "", 53, "25 Kg (55.12 lbs), including 9 coil drawers" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1839, "? mm", "National/hro50.jpg", "HRO-50", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1840, "419*194*324 mm (16.5*7.62*12.75in)", "National/hro500.jpg", "HRO-500", "", 53, "14.51 Kg (32 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1841, "502*257*419 mm (19.76*10.12*16.5in)", "National/hro50t1.jpg", "HRO-50T1", "", 53, "38 Kg (83.78 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1842, "? mm", "National/hro60.jpg", "HRO-60", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1843, "432*133*386 mm (17*5.25*15.5in)", "National/hro600.jpg", "HRO-600", "", 53, "18.1 Kg (40 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1844, "? mm", "National/hro7.jpg", "HRO-7", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1866, "? mm", "National/nc33.jpg", "NC-33", "", 53, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1624, "? mm", "Kenwood/tm541.jpg", "TM-541", "Hi: 10 W, Lo: 1 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1623, "140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm531e.jpg", "TM-531E", "Hi: 10 W, Lo: 1 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1622, "141*42*193 mm (5.55*1.65*7.6in)", "Kenwood/tm521a.jpg", "TM-521A", "Hi: 10 W, Lo: 1 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1402, "58*140*29 mm (2.28*5.51*1.14in), with BP-22", "Icom/icmikro4e.jpg", "IC-�4E (IC-Mikro 4E)", @"HighLow
70 cm:1 W100 mW", 43, "340 g (11.99 oz), with BP-22" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1403, "49*105*39 mm (1.93*4.13*1.54in), with BP-111", "Icom/icp2a.jpg", "IC-P2A", @"HighLow3Low2Low1
2 m:5 W3.5 W1.5 W500 mW


Indicated High and Low3 power is with BP-114 or 13.8 VDC external power", 43, "280 g (9.88 oz), with BP-111" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1404, "49*105*39 mm (1.93*4.13*1.54in), with BP-111", "Icom/icp2at.jpg", "IC-P2AT", @"HighLow3Low2Low1
2 m:5 W3.5 W1.5 W500 mW


Indicated High and Low3 power is with BP-114 or 13.8 VDC external power", 43, "280 g (9.88 oz), with BP-111" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1405, "49*105*39 mm (1.93*4.13*1.54in), with BP-111", "Icom/icp2e.jpg", "IC-P2E", @"HighLow3Low2Low1
2 m:5 W3.5 W1.5 W500 mW


Indicated High and Low3 power is with BP-114 or 13.8 VDC external power", 43, "280 g (9.88 oz), with BP-111" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1406, "49*105*39 mm (1.93*4.13*1.54in), with BP-111", "Icom/icp2et.jpg", "IC-P2ET", @"HighLow3Low2Low1
2 m:5 W3.5 W1.5 W500 mW


Indicated High and Low3 power is with BP-114 or 13.8 VDC external power", 43, "280 g (9.88 oz), with BP-111" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1407, "49*105*39 mm (1.93*4.13*1.54in), with BP-111", "Icom/icp3at.jpg", "IC-P3AT", @"HighLow3Low2Low1
1.25 m:5 W3.5 W1.5 W500 mW


Indicated High and Low3 power is with BP-114 or 13.8 VDC external power", 43, "280 g (9.88 oz), with BP-111" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1408, "49*105*39 mm (1.93*4.13*1.54in), with BP-111", "Icom/icp4at.jpg", "IC-P4AT", @"HighLow3Low2Low1
70 cm:5 W3.5 W1.5 W500 mW


Indicated High and Low3 power is with BP-114 or 13.8 VDC external power", 43, "280 g (9.88 oz), with BP-111" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1401, "58*140*29 mm (2.28*5.51*1.14in), with BP-22", "Icom/icmikro2e.jpg", "IC-�2E (IC-Mikro 2E)", @"HighLow
2 m:1 W100 mW", 43, "340 g (11.99 oz), with BP-22" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1409, "49*105*39 mm (1.93*4.13*1.54in), with BP-111", "Icom/icp4et.jpg", "IC-P4ET", @"HighLow3Low2Low1
70 cm:5 W3.5 W1.5 W500 mW


Indicated High and Low3 power is with BP-114 or 13.8 VDC external power", 43, "280 g (9.88 oz), with BP-111" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1411, "131*34*154 mm (5.16*1.34*6.06in)", "Icom/icpcr100.jpg", "IC-PCR100", "", 43, "500 g (17.64 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1412, "128*30*199 mm (5.04*1.18*7.84in)", "Icom/icpcr1000.jpg", "IC-PCR1000", "", 43, "1 Kg (2.2 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1413, "146*41*206 mm (5.75*1.61*8.11in)", "Icom/icpcr1500.jpg", "IC-PCR1500", "", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1414, "146*41*206 mm (5.75*1.61*8.11in)", "Icom/icpcr2500.jpg", "IC-PCR2500", "", 43, "1.35 Kg (2.98 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1415, "58*86*27 mm (2.28*3.38*1.06in)", "Icom/icq7a.jpg", "IC-Q7A", @"2 m:350 mW
70 cm:300 mW", 43, "170 g (6 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1416, "58*86*27 mm (2.28*3.38*1.06in)", "Icom/icq7e.jpg", "IC-Q7E", @"2 m:350 mW
70 cm:300 mW", 43, "170 g (6 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1417, "49*103*35 mm (1.93*4.06*1.38in)", "Icom/icr1.jpg", "IC-R1", "", 43, "280 g (9.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1410, "47*81*28 mm (1.85*3.19*1.1in)", "Icom/icp7a.jpg", "IC-P7A", @"HighLow
2 m:1.5 W100 mW
70 cm:1 W100 mW", 43, "160 g (5.64 oz), with BP-243 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1418, "58*130*31 mm (2.28*5.12*1.22in)", "Icom/icr10.jpg", "IC-R10", "", 43, "310 g (10.93 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1400, "59*112*34 mm (2.32*4.41*1.34in)", "Icom/ice92d.jpg", "IC-E92D", @"HighMid1Mid2Low
2 m:5 W2.5 W500 mW100 mW
70 cm:5 W2.5 W500 mW100 mW", 43, "325 g (10.58 oz), with BP-256 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1398, "58*87*29 mm (2.28*3.42*1.14in)", "Icom/ice90.jpg", "IC-E90", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "280 g (9.88 oz), with antenna and BP-217" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1382, "425*149*406 mm (16.7*5.9*16in)", "Icom/ic970.jpg", "IC-970", @"PwrBand unit
2 m:1.5-10 WBuilt-in
70 cm:1.5-10 WBuilt-in

      

23 cm:1-10 WUX-97
13 cm:1 WUX-98", 43, "14.5 Kg (32 lb), without PS-3516.8 Kg (37 lb), with PS-35" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1383, "240*94*238 mm (9.45*3.7*9.37in)", "Icom/ic9700.jpg", "IC-9700", @"2 m0.5-100 W (AM: 0.125-25 W)


70 cm0.5-75 W (AM: 0.125-18.75 W)


23 cm0.1-10 W (AM: 0.05-2.5 W)", 43, "4.7 Kg (10.4 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1384, "425*149*406 mm (16.7*5.9*16in)", "Icom/ic970a.jpg", "IC-970A", @"PwrBand unit
2 m:3.5-25 WBuilt-in
70 cm:3.5-25 WBuilt-in

      

23 cm:1-10 WUX-97
13 cm:1 WUX-98", 43, "14.5 Kg (32 lb), without PS-3516.8 Kg (37 lb), with PS-35" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1385, "425*149*406 mm (16.7*5.9*16in)", "Icom/ic970d.jpg", "IC-970D", @"PwrBand unit
2 m FM:6-45 WBuilt-in
2 m SSB/CW:5-35 WBuilt-in
70 cm FM:6-40 WBuilt-in
70 cm SSB/CW:5-30 WBuilt-in

      

23 cm:1-10 WUX-97
13 cm:1 WUX-98", 43, "15 Kg (33.1 lb), without PS-3517.3 Kg (38.1 lb), with PS-35" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1386, "425*149*406 mm (16.7*5.9*16in)", "Icom/ic970e.jpg", "IC-970E", @"PwrBand unit
2 m:3.5-25 WBuilt-in
70 cm:3.5-25 WBuilt-in

      

23 cm:1-10 WUX-97
13 cm:1 WUX-98", 43, "14.5 Kg (32 lb), without PS-3516.8 Kg (37 lb), with PS-35" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1387, "425*149*406 mm (16.7*5.9*16in)", "Icom/ic970h.jpg", "IC-970H", @"PwrBand unit
2 m FM:6-45 WBuilt-in
2 m SSB/CW:5-35 WBuilt-in
70 cm FM:6-40 WBuilt-in
70 cm SSB/CW:5-30 WBuilt-in

      

23 cm:10 WUX-97
13 cm:1 WUX-98", 43, "15 Kg (33 lb), without PS-3517.3 Kg (38.1 lb), with PS-35" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1388, "140*50*175 mm (5.51*1.97*6.89in)", "Icom/icdelta100.jpg", "IC-Delta 100", @"HighLow 2Low 1
2 m:10 W3 W0.5 W
70 cm:10 W3 W0.5 W
23 cm:10 W-1 W", 43, "1.85 Kg (4.08 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1399, "58*103*34 mm (2.28*4.06*1.34in)", "Icom/ice91.jpg", "IC-E91", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "300 gr (10.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1389, "140*50*195 mm (5.5*2*7.7in)", "Icom/icdelta100.jpg", "IC-Delta 100D", @"HighLow 2Low 1
2 m:50 W10 W5 W
70 cm:35 W10 W5 W
23 cm:10 W-1 W", 43, "2.05 Kg (4.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1391, "140*50*195 mm (5.5*2*7.7in)", "Icom/icdelta100.jpg", "IC-Delta 100M", @"HighLow 2Low 1
2 m:25 W10 W3 W
70 cm:25 W10 W3 W
23 cm:10 W-1 W", 43, "2.05 Kg (4.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1392, "58*145*49 mm (2.3*5.7*1.9in), with BP-102", "Icom/icdelta1a.jpg", "IC-Delta 1A", @"HighMidLow
2 m:5 W3.5 W500 mW
70 cm:5 W3.5 W500 mW
23 cm:1 W200 mW200 mW


Indicated high power is @ 13.5 VDC", 43, "635 g (1.4 lb), with BP-102" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1393, "58*145*49 mm (2.3*5.7*1.9in), with BP-102", "Icom/icdelta1e.jpg", "IC-Delta 1E", @"HighMidLow
2 m:5 W3.5 W500 mW
70 cm:5 W3.5 W500 mW
23 cm:1 W200 mW200 mW


Indicated high power is @ 13.5 VDC", 43, "635 g (1.4 lb), with BP-102" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1394, "141*40*185 mm (5.55*1.58*7.28in)", "Icom/ice208.jpg", "IC-E208", @"HighMidLow
2 m:55 W15 W5 W
70 cm:50 W15 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1395, @"Main unit: 150*40*188 mm (5.91*1.58*7.4in)
Controller: 150*58*32 mm (5.91*2.28*1.26in)", "Icom/ice2820.jpg", "IC-E2820", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, @"Main unit: 1.5 Kg (3.31 lbs)
Controller: 210 g (7.41 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1396, "47*81*28 mm (1.85*3.19*1.1in)", "Icom/ice7.jpg", "IC-E7", @"HighLow
2 m:1.5 W100 mW
70 cm:1 W100 mW", 43, "160 g (5.64 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1397, "58*103*34 mm (2.28*4.06*1.34in)", "Icom/ice80d.jpg", "IC-E80D", @"HighMid1Mid2Low
2 m:5 W2.5 W500 mW100 mW
70 cm:5 W2.5 W500 mW100 mW", 43, "290 g (10.23 oz), with antenna and BP-217" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1390, "140*50*195 mm (5.5*2*7.7in)", "Icom/icdelta100h.jpg", "IC-Delta 100H", @"HighLow 2Low 1
2 m:50 W10 W5 W
70 cm:35 W10 W5 W
23 cm:10 W-1 W", 43, "2.05 Kg (4.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1419, "150*50*181 mm (5.9*2*7.1in)", "Icom/icr100.jpg", "IC-R100", "", 43, "1.4 Kg (3.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1420, "Main unit: 146*41*206 mm (5.75*1.61*8.11in)Panel: 111*40*27 mm (4.37*1.58*1.06in)", "Icom/icr1500.jpg", "IC-R1500", "", 43, "Main unit: 1.2 Kg (2.65 lbs)Panel: 200 gr (7.06 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1421, "58*86*27 mm (2.28*3.39*1.06in)", "Icom/icr2.jpg", "IC-R2", "", 43, "170 g (6 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1443, "424*149*340 mm (16.69*5.87*13.39in)", "Icom/icr9500.jpg", "IC-R9500", "", 43, "20 Kg (44 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1444, "57*128*23 mm (2.24*5.04*0.91in)", "Icom/icrx7.jpg", "IC-RX7", "", 43, "200 g (7.06 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1445, "54*111*36 mm (2.1*4.4*1.4in)", "Icom/ics21e.jpg", "IC-S21E", @"High@ 13.5VLow3@ 13.5VLow2Low1E Low
2 m:6 W4 W1.4 W1 W15 mW", 43, "315 g (11.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1446, "? mm (?in)", "Icom/ics22.jpg", "IC-S22", @"HighMidLow
2 m:? W? W? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1447, "? mm (?in)", "Icom/ics32.jpg", "IC-S32", @"HighMidLow
70 cm:? W? W? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1448, "54*111*36 mm (2.1*4.4*1.4in)", "Icom/ics41e.jpg", "IC-S41E", @"High@ 13.5VLow3@ 13.5VLow2Low1E Low
70 cm:6 W4 W3 W2 W15 mW", 43, "315 g (11.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1449, "57*110*27 mm (2.24*4.33*1.06in)", "Icom/ics7d.jpg", "IC-S7D", @"High@ 13.8VHigh@ 6VLow
2 m:6 W2 W500 mW
70 cm:6 W1.5 W500 mW", 43, "285 g (10.05 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1442, "424*150*365 mm (16.69*5.91*14.37in)", "Icom/icr9000l.jpg", "IC-R9000L", "", 43, "20 Kg (44.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1450, "57*110*27 mm (2.24*4.33*1.06in), with BP-171", "Icom/ict22a.jpg", "IC-T22A", @"High@ 9.6VHigh@ 7.2VHigh@ 4.8VLow
2 m:5 W3.5 W1.5 W500 mW", 43, "310 g (10.9 oz), with BP-171 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1452, "58*141*32 mm (2.28*5.55*1.26in)", "Icom/ict2h.jpg", "IC-T2H", @"HighLow
2 m:6 W1 W", 43, "420 g (14.82 oz), without battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1453, "57*110*27 mm (2.24*4.33*1.06in)", "Icom/ict32.jpg", "IC-T32", @"High@ 9.6VHigh@ 6VHigh@ 4.8VLow
70 cm:5 W1.5 W1.3 W500 mW", 43, "280 g (9.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1454, "54*132*35 mm (2.13*5.2*1.38in)", "Icom/ict3h.jpg", "IC-T3H", @"HighLow
2 m:5.5 W500 mW", 43, "350 g (12.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1455, "57*110*27 mm (2.24*4.33*1.06in)", "Icom/ict42a.jpg", "IC-T42A", @"High@ 9.6VHigh@ 7.2VHigh@ 4.8VLow
70 cm:5 W3.5 W1.3 W500 mW", 43, "300 g (10.6 oz), with BP-171 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1456, "58*111*30 mm (2.28*4.37*1.18in)", "Icom/ict70a.jpg", "IC-T70A", @"HighMidLow
2 m:5 W2.5 W500 mW
70 cm:5 W2.5 W500 mW", 43, "380 g (13.4 oz), with antenna and BP-264" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1457, "58*111*30 mm (2.28*4.37*1.18in)", "Icom/ict70e.jpg", "IC-T70E", @"HighMidLow
2 m:5 W2.5 W500 mW
70 cm:5 W2.5 W500 mW", 43, "380 g (13.4 oz), with antenna and BP-264" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1458, "57*122*29 mm (2.24*4.8*1.14in)", "Icom/ict7a.jpg", "IC-T7A", @"High@ 9.6VHigh@ 7.2VLow
2 m:4 W3 W500 mW
70 cm:2.8 W1.6 W500 mW", 43, "320 g (11.3 oz), with BP-180" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1451, "57*110*27 mm (2.24*4.33*1.06in), with BP-171", "Icom/ict22e.jpg", "IC-T22E", @"High@ 9.6VHigh@ 7.2VHigh@ 4.8VLow
2 m:5 W3.5 W1.5 W500 mW", 43, "310 g (10.9 oz), with BP-171 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1441, "424*150*365 mm (16.69*5.91*14.37in)", "Icom/icr9000.jpg", "IC-R9000E", "", 43, "20 Kg (44.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1440, "424*150*365 mm (16.69*5.91*14.37in)", "Icom/icr9000.jpg", "IC-R9000", "", 43, "20 Kg (44.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1439, "220*90*230 mm (8.66*3.54*9.05in)", "Icom/icr8600.jpg", "IC-R8600", "", 43, "4.3 Kg (9.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1422, "60*142*35 mm (2.36*5.59*1.38in)", "Icom/icr20.jpg", "IC-R20", "", 43, "320 g (11.29 oz), with antenna and BP-206" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1423, "146*41*206 mm (5.75*1.61*8.11in)", "Icom/icr2500.jpg", "IC-R2500", "", 43, "1.35 Kg (2.98 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1424, "61*120*33 mm (2.4*4.72*1.3in)", "Icom/icr3_ofv.jpg", "IC-R3", "", 43, "300 g (10.6 oz), with antenna and battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1425, "58*143*30 mm (2.3*5.6*1.2in)", "Icom/icr30.jpg", "IC-R30", "", 43, "310 g (10.9 oz), with BP-287 battery pack and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1426, "58*86*27 mm (2.28*3.39*1.06in)", "Icom/icr5.jpg", "IC-R5", "", 43, "185 g (6.53 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1427, "58*86*30 mm (2.28*3.39*1.18in)", "Icom/icr6.jpg", "IC-R6", "", 43, "200 g (7.06 oz), with antenna and batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1428, "286*111*276 mm (11.25*4.37*10.87in)", "Icom/icr70.jpg", "IC-R70", "", 43, "7.4 Kg (16.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1429, "286*110*276 mm (11.3*4.3*10.9in)", "Icom/icr7000.jpg", "IC-R7000", "", 43, "8 Kg (17.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1430, "286*111*276 mm (11.25*4.37*10.87in)", "Icom/icr71.jpg", "IC-R71", "", 43, "7.5 Kg (16.53 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1431, "241*94*239 mm (9.49*3.7*9.41in)", "Icom/icr7100.jpg", "IC-R7100", "", 43, "6 Kg (13.23 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1432, "286*111*276 mm (11.25*4.37*10.87in)", "Icom/icr71a.jpg", "IC-R71A", "", 43, "7.5 Kg (16.53 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1433, "286*111*276 mm (11.25*4.37*10.87in)", "Icom/icr71d.jpg", "IC-R71D", "", 43, "7.5 Kg (16.53 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1434, "286*111*276 mm (11.25*4.37*10.87in)", "Icom/icr71e.jpg", "IC-R71E", "", 43, "7.5 Kg (16.53 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1435, "241*94*229 mm (9.5*3.7*9in)", "Icom/icr72.jpg", "IC-R72", "", 43, "5.5 Kg (12.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1436, "241*94*229 mm (9.5*3.7*9in)", "Icom/icr72.jpg", "IC-R72DC", "", 43, "4.4 Kg (9.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1437, "241*94*229 mm (9.49*3.7*9.02in)", "Icom/icr75.jpg", "IC-R75", "", 43, "3 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1438, "287*112*309 mm (11.3*4.41*12.17in)", "Icom/icr8500.jpg", "IC-R8500", "", 43, "7 Kg (15.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1381, "59*112*34 mm (2.32*4.41*1.34in)", "Icom/ic92ad.jpg", "IC-92AD", @"HighMidLowS-Low
2 m:5 W2.5 W500 mW100 mW
70 cm:5 W2.5 W500 mW100 mW", 43, "325 g (11.46 oz), with BP-256 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1459, "57*122*29 mm (2.24*4.8*1.14in)", "Icom/ict7d.jpg", "IC-T7D", @"High@ 13.5VHigh@ 6VLow
2 m:6 W2 W500 mW
70 cm:6 W1.5 W500 mW", 43, "320 g (11.29 oz), with BP-180" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1380, "58*103*34 mm (2.28*4.05*1.34in)", "Icom/ic91ad.jpg", "IC-91AD", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "300 g (10.6 oz), with BP-217 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1378, "241*94*239 mm (9.49*3.7*9.41in)", "Icom/ic911d.jpg", "IC-911D", @"2 m2.5-50 W (Can be modified to 100 W)


70 cm2.5-50 W (Can be modified to 75 W)


23 cm1-10 W (with UX-911 option)", 43, "4.5 Kg (9.92 lbs), without UX-911" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1321, "241*111*311 mm (9.49*4.37*12.24in)", "Icom/ic720.jpg", "IC-720", @"AM: Max 40 W
SSB: ~100 W PEP (200 W PEP input)
CW/RTTY: ~100 W (200 W input)", 43, "7.5 Kg (16.53 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1322, "241*84*281 mm (9.5*3.3*11.1in)", "Icom/ic7200.jpg", "IC-7200", "AM: 1-25 W (carrier)SSB/CW/RTTY: 2-100 W", 43, "5.5 Kg (12.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1323, "241*111*311 mm (9.49*4.37*12.24in)", "Icom/ic720a.jpg", "IC-720A", @"AM: Max 40 W
SSB: ~100 W PEP (200 W PEP input)
CW/RTTY: ~100 W (200 W input)", 43, "7.5 Kg (16.53 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1324, "241*94*239 mm (9.5*3.7*9.4in)", "Icom/ic721s.jpg", "IC-721S", @"AM: 1-4 W (With UI-7 option)
SSB/CW: 1-10 W
FM: 1-10 W (With UI-7 option)", 43, "4.5 Kg (9.92 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1325, "241*94*239 mm (9.5*3.7*9.4in)", "Icom/ic725.jpg", "IC-725", @"AM: 10-40 W (With UI-7 option)
FM: 10-100 W (With UI-7 option)
SSB/CW: 10-100 W", 43, "4.6 Kg (10.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1326, "241*94*239 mm (9.5*3.7*9.4in)", "Icom/ic726.jpg", "IC-726", "HF: 10-100 W (AM 10-40 W)6 m: 1-10 W (AM 1-4 W)", 43, "4.8 Kg (11 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1327, "241*94*239 mm (9.5*3.7*9.4in)", "Icom/ic728.jpg", "IC-728", @"AM: 10-40 W (With UI-7 option)
FM: 10-100 W (With UI-7 option)
SSB/CW: 10-100 W", 43, "4.6 Kg (10.14 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1320, "240*95*239 mm (9.45*3.74*9.41in)", "Icom/ic718.jpg", "IC-718", @"AM: 2-40 W
SSB/CW/RTTY: 2-100 W", 43, "3.8 Kg (8.38 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1328, "241*94*239 mm (9.5*3.7*9.4in)", "Icom/ic729.jpg", "IC-729", @"AMFM/SSB/CW
HF:10-40 W10-100 W
6 m:1-4 W1-10 W", 43, "4.9 Kg (10.8 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1330, "240*94*238 mm (9.45*3.7*9.4in)", "Icom/ic7300.jpg", "IC-7300", @"AM (HF/6 m):1-25 W


FM/SSB/CW/RTTY (HF/6 m):2-100 W


AM (4 m):1-12.5 W (European version only)


FM/SSB/CW/RTTY (4 m):2-50 W (European version only)", 43, "4.2 Kg (9.3 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1331, "241*94*272 mm (9.49*3.7*10.71in)", "Icom/ic731.jpg", "IC-731", @"AM: 10-40 W
FM: 10-100 W (10-50 W @ 10 m)
SSB/CW: 10-100 W (10-50 W @ 10 m)", 43, "5 Kg (11.02 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1332, "330*111*285 mm (12.99*4.37*11.22in)", "Icom/ic732.jpg", "IC-732", @"AM: 10-40 W
FM: 10-100 W
SSB: 10-100 W
CW: 10-100 W", 43, "8 Kg (17.64 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1333, "241*94*272 mm (9.49*3.7*10.71in)", "Icom/ic735.jpg", "IC-735", @"AM: 10-40 W
FM: 10-100 W (10-50 W @ 10 m)
SSB/CW: 10-100 W (10-50 W @ 10 m)", 43, "5 Kg (11.02 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1334, "330*111*285 mm (13*4.37*11.22in)", "Icom/ic736.jpg", "IC-736", @"AM: 4-40 W
FM: 5-100 W
SSB: 5-100 W
CW: 5-100 W", 43, "10.48 Kg (23.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1335, "330*111*285 mm (13*4.37*11.22in)", "Icom/ic737.jpg", "IC-737", @"AM: 4-40 W
FM: 10-100 W
SSB: 10-100 W
CW: 10-100 W", 43, "8 Kg (17.64 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1336, "330*111*285 mm (13*4.37*11.22in)", "Icom/ic737a.jpg", "IC-737A", @"AM: 4-40 W
FM: 10-100 W
SSB: 10-100 W
CW: 10-100 W", 43, "8.1 Kg (17.9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1329, "241*94*275 mm (9.49*3.7*10.83in)", "Icom/ic730.jpg", "IC-730", @"AM: 5-25 W
SSB/CW: 5-100 W", 43, "6.4 Kg (14.11 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1337, "330*111*285 mm (13*4.37*11.22in)", "Icom/ic738.jpg", "IC-738", @"AM: 4-40 W
FM: 5-100 W
SSB: 5-100 W
CW: 5-100 W", 43, "8.6 Kg (18.96 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1319, "RF unit: 167*58*225 mm (6.58*2.28*8.86in)Controller: 165*64*78 mm (6.5*2.52*3.07in)", "Icom/ic7100.jpg", "IC-7100", @"HF2-100 W (AM 1-30 W)


6 m2-100 W (AM 1-30 W)


4 m/70 MHz2-50 W (AM 1-15 W), European version only


2 m2-50 W


70 cm3-35 W", 43, "RF unit: 2.3 Kg (5.07 lb)Controller: 500 g (1.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1317, "230*110*260 mm (9.06*4.33*10.24in)", "Icom/ic71.jpg", "IC-71", "Max 10 W", 43, "5.3 Kg (11.68 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1301, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic575d.jpg", "IC-575D", @"AM: 2-20 W
FM/SSB/CW: 2-50 W", 43, "6.1 Kg (13.45 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1302, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic575h.jpg", "IC-575H", @"AM: 5-25 W
FM/SSB/CW: 10-100 W", 43, "6.1 Kg (13.45 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1303, "156*58*216 mm (6.14*2.28*8.5in)", "Icom/ic60.jpg", "IC-60", @"HighLow
6 m:10 W1 W", 43, "2 Kg (4.41 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1304, "? mm (?in)", "Icom/ic61.jpg", "IC-61", @"HighLow
6 m:10 W1 W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1305, "140*40*132 mm (5.51*1.58*5.2in)", "Icom/ic681.jpg", "IC-681", @"HighLow 2Low 1
6 m:10 W3 W500 mW", 43, "800 g (1.76 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1306, "167*58*180 mm (6.57*2.28*7.1in)", "Icom/ic7000.jpg", "IC-7000", @"FM/SSB/CW/RTTY:2-100 W (HF/6 m)
2-50 W (2 m)
2-35 W (70 cm)

AM:1-40 W (HF/6 m)
2-20 W (2 m)
2-14 W (70 cm)", 43, "2.3 Kg (5.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1307, "270*160*235 mm (10.63*6.3*9.25in)", "Icom/ic700r.jpg", "Inoue (Icom) IC-700R", "", 43, "6 Kg (13.23 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1318, "241*111*311 mm (9.5*4.4*12.2in)", "Icom/ic710.jpg", "IC-710", "0-100 W adjustable", 43, "7.3 Kg (16.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1308, "254*160*235 mm (10*6.3*9.25in)", "Icom/ic700t.jpg", "Inoue (Icom) IC-700T", "SSB: ~70 W PEP (150 W PEP input)", 43, "5 Kg (11 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1310, "167*58*200 mm (6.57*2.28*7.87in)", "Icom/ic703.jpg", "IC-703", @"AM: 0.1-2 W in 5 steps @ 9.6 VDC
AM: 0.1-4 W in 5 steps @ 13.8 VDC
FM/SSB/CW/RTTY: 0.1-10 W in 5 steps @ 9.6 VDC
FM/SSB/CW/RTTY: 0.1-10 W in 5 steps @ 13.8 VDC", 43, "2 Kg (4.41 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1311, "167*58*200 mm (6.57*2.28*7.87in)", "Icom/ic703plus.jpg", "IC-703 Plus", @"AM: 0.1-2 W in 5 steps @ 9.6 VDC
AM: 0.1-4 W in 5 steps @ 13.8 VDC
FM/SSB/CW/RTTY: 0.1-10 W in 5 steps @ 9.6 VDC
FM/SSB/CW/RTTY: 0.1-10 W in 5 steps @ 13.8 VDC", 43, "2 Kg (4.41 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1312, "200*84*82 mm (7.9*3.3*3.2in)", "Icom/ic705_2.jpg", "IC-705", @"Up to 5 W with BP-272 or BP-307 battery pack
Up to 10 W @ 13.8 VDC external power", 43, "1.1 Kg (2.4 lb), with BP-272" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1313, "167*58*200 mm (6.58*2.28*7.87in)", "Icom/ic706.jpg", "IC-706", @"HF: 5-100 W (AM 2-40 W)
6 m: 5-100 W (AM 2-40 W)
2 m: 1-10 W (AM 1-4 W)", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1314, "167*58*200 mm (6.58*2.28*7.87in)", "Icom/ic706mkii.jpg", "IC-706MKII", @"HF: 5-100 W (AM 2-40 W)
6 m: 5-100 W (AM 2-40 W)
2 m: 2-20 W (AM 2-8 W)", 43, "2.45 Kg (5.4 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1315, "167*58*200 mm (6.58*2.28*7.87in)", "Icom/ic706mkiig.jpg", "IC-706MKIIG", @"HFAM: 2-40 W, FM/SSB/CW/RTTY: 5-100 W


6 mAM: 2-40 W, FM/SSB/CW/RTTY: 5-100 W


2 mAM: 2-20 W, FM/SSB/CW/RTTY: 5-50 W


70 cmAM: 2-8 W, FM/SSB/CW/RTTY: 2-20 W", 43, "2.45 Kg (5.4 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1316, "240*95*239 mm (9.4*3.7*9.4in)", "Icom/ic707.jpg", "IC-707", @"AM: 5-25 W
FM/SSB/CW: 5-100 W", 43, "4.1 Kg (9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1309, "241*111*311 mm (9.5*4.4*12.2in)", "Icom/ic701.jpg", "IC-701", "0-100 W adjustable", 43, "7.3 Kg (16.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1338, "286*111*374 mm (11.26*4.37*14.72in)", "Icom/ic740.jpg", "IC-740", @"FM: Max 10 W (With optional EX-242)
SSB: Max ~100 W (200 W input)
CW: Max ~100 W (200 W input)
RTTY: Max ~100 W (200 W input)", 43, "8 Kg (17.64 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1339, "287*123*316 mm (11.3*4.84*12.44in)", "Icom/ic7400.jpg", "IC-7400", @"AMFMSSBCW
HF:5-40 W5-100 W5-100 W5-100 W
6 m:5-40 W5-100 W5-100 W5-100 W
2 m:5-40 W5-100 W5-100 W5-100 W", 43, "9 Kg (19.84 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1340, "280*111*355 mm (11*4.37*14in)", "Icom/ic741.jpg", "IC-741", @"FM: ~10-100 W (With EX-242 option)
SSB: ~10-100 W
CW: ~10-100 W", 43, "8 Kg (17.64 lb), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1362, "425*149*411 mm (16.73*5.86*16.18in)", "Icom/ic780.jpg", "IC-780", @"AM: 10-40 W
FM: 10-50 W
SSB: 10-100 W
CW: 10-100 W
RTTY: 10-100 W
All modes max 50 W @ 10 m", 43, "23 Kg (50.71 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1363, "424*149*435 mm (16.69*5.87*17.13in)", "Icom/ic7800.jpg", "IC-7800", @"AM: 5-50 W
FM: 5-200 W
SSB: 5-200 W
CW: 5-200 W
RTTY: 5-200 W
PSK31: 5-200 W
100% duty cycle", 43, "25 Kg (55.12 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1364, "425*149*411 mm (16.8*5.9*16.2in)", "Icom/ic781.jpg", "IC-781", "AM: 8-75 WSSB: 15-150 W PEPCW/RTTY/FM: 15-150 W", 43, "23 Kg (50.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1365, "424*150*420 mm (16.69*5.91*16.54in)", "Icom/ic7850.jpg", "IC-7850 (Limited anniversary model)", @"AM: 5-50 W
FM: 5-200 W
SSB: 5-200 W
CW: 5-200 W
RTTY: 5-200 W
PSK: 5-200 W
100% duty cycle!

137 KHz: More than -20 dBm (European version only)", 43, "23.5 Kg (52 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1366, "424*150*420 mm (16.69*5.91*16.54in)", "Icom/ic7851.jpg", "General market", @"AM: 5-50 W
FM: 5-200 W
SSB: 5-200 W
CW: 5-200 W
RTTY: 5-200 W
PSK: 5-200 W
100% duty cycle!

137 KHz: More than -20 dBm (European market only)", 43, "23.5 Kg (52 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1367, "241*94*239 mm (9.5*3.7*9.4in)", "Icom/ic820h.jpg", "IC-820H", @"HighLow
2 m FM/CW:45 W6 W
2 m SSB:35 W6 W
70 cm FM/CW:40 W6 W
70 cm SSB:30 W6 W", 43, "5 Kg (11 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1368, "241*94*239 mm (9.5*3.7*9.4in)", "Icom/ic821h.jpg", "IC-821H", @"2 mFM/CW: 6-45 W, SSB: 6-35 W (Continuously adjustable)


70 cmFM/CW: 6-40 W, SSB: 6-30 W (Continuously adjustable)", 43, "5 Kg (11 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1361, "424*150*390 mm (16.7*5.9*15.4in)", "Icom/ic775dxii.jpg", "IC-775DX II", @"AM: 5-50 W
FM: 5-100 W
SSB: 5-100 W
CW: 5-100 W
RTTY: 5-100 W", 43, "16.7 Kg (36.8 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1369, @"Controller: 150*50*25 mm (5.91*1.97*0.98in)
Interface A: 177*25*177 mm (6.97*0.98*6.97in)
Interface B: 177*25*192 mm (6.97*0.98*7.56in)
(Check the service manual for band unit details)", "Icom/ic900a.jpg", "IC-900A", @"HighLowBand unit
10 m:10 W1 WUX-19A
6 m:10 W1 WUX-59A
2 m:25 W5 WUX-29A
2 m:45 W5 WUX-29H
70 cm:25 W5 WUX-49A
1.25 m:25 W5 WUX-39A
23 cm:10 W1 WUX-129A", 43, @"Controller: 200 g (7.06 oz)
Interface A: 500 g (1.1 lb)
Interface B: 900 g (1.98 lb)
(Check the service manual for band unit details)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1371, "150*50*191 mm (5.9*2*7.5in), when not separated", "Icom/ic901a.jpg", "IC-901A", @"HighLowBand unit
2 m:50 W5 WBuilt-in
70 cm:35 W5 WBuilt-in

        

10 m:10 W1 WUX-19A
6 m:10 W1 WUX-59A
2 m:25 W5 WUX-S92A
1.25 m:25 W5 WUX-39A
23 cm:10 W1 WUX-129A", 43, "1.6 Kg (3.5 lbs), when not separated" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1372, "150*50*191 mm (5.9*2*7.5in), when not separated", "Icom/ic901e.jpg", "IC-901E", @"HighLowBand unit
2 m:50 W5 WBuilt-in
70 cm:35 W5 WBuilt-in

        

10 m:10 W1 WUX-19E
6 m:10 W1 WUX-59A
2 m:25 W5 WUX-S92E
23 cm:10 W1 WUX-129E", 43, "1.6 Kg (3.5 lbs), when not separated" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1373, "241*94*239 mm (9.49*3.7*9.41in)", "Icom/ic910d.jpg", "IC-910", @"2 m2-20 W


70 cm2-20 W


23 cm1-10 W (with UX-910 option)", 43, "4.5 Kg (9.92 lbs), without UX-910" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1374, "315*116*343 mm (12.4*4.57*13.5in)", "Icom/ic9100.jpg", "IC-9100", @"HF + 6 m2-100 W (AM: 2.30 W)


2 m2-100 W


70 cm2-75 W


23 cm1-10 W (With optional UX-9100)", 43, "11 Kg (24.25 lb), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1375, "241*94*239 mm (9.49*3.7*9.41in)", "Icom/ic910d.jpg", "IC-910D", @"2 m2.5-50 W (Can be modified to 100 W)


70 cm2.5-50 W (Can be modified to 75 W)


23 cm1-10 W (with UX-910 option)", 43, "4.5 Kg (9.92 lbs), without UX-910" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1376, "241*94*239 mm (9.49*3.7*9.41in)", "Icom/ic910h.jpg", "IC-910H", @"2 m5-100 W


70 cm5-75 W


23 cm1-10 W (with UX-910 option)", 43, "4.5 Kg (9.92 lb), without UX-910" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1377, "241*94*239 mm (9.49*3.7*9.41in)", "Icom/ic911d.jpg", "IC-911", @"2 m2-20 W


70 cm2-20 W


23 cm1-10 W (with UX-911 option)", 43, "4.5 Kg (9.92 lb), without UX-911" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1370, @"Controller: 150*50*25 mm (5.91*1.97*0.98in)
Interface A: 177*25*177 mm (6.97*0.98*6.97in)
Interface B: 177*25*192 mm (6.97*0.98*7.56in)
(Check the service manual for band unit details)", "Icom/ic900e.jpg", "IC-900E", @"HighLowBand unit
10 m:10 W1 WUX-19E
6 m:10 W1 WUX-59A
2 m:25 W5 WUX-29E
2 m:45 W5 WUX-29H
70 cm:25 W5 WUX-49E
23 cm:10 W1 WUX-129E", 43, @"Controller: 200 g (7.06 oz)
Interface A: 500 g (1.1 lb)
Interface B: 900 g (1.98 lb)
(Check the service manual for band unit details)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1360, "424*150*390 mm (16.7*5.9*15.4in)", "Icom/ic775dsp.jpg", "IC-775DSP", @"AM: 5-50 W
FM: 5-200 W
SSB: 5-200 W
CW: 5-200 W
RTTY: 5-200 W", 43, "16.7 Kg (36.8 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1359, "424*150*390 mm (16.7*5.9*15.4in)", "Icom/ic775.jpg", "IC-775DSP", @"AM: 5-50 W
FM: 5-200 W
SSB: 5-200 W
CW: 5-200 W
RTTY: 5-200 W", 43, "16.5 Kg (36.4 lb), without DSP option16.7 Kg (36.8 lb), with DSP option" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1358, "425*149*437 mm (16.69*5.91*17.2in)", "Icom/ic7700.jpg", "IC-7700", @"AM: 5-50 W
FM: 5-200 W
SSB: 5-200 W
CW: 5-200 W
RTTY: 5-200 W
PSK31: 5-200 W", 43, "22.5 Kg (50 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1341, "315*116*343 mm (12.4*4.57*13.5in)", "Icom/ic7410.jpg", "IC-7410", @"AM: 2-27 W (Carrier)
FM: 2-100 W
SSB: 2-100 W
CW: 2-100 W
RTTY: 2-100 W", 43, "10.2 Kg (22.49 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1342, "280*111*355 mm (11*4.37*14in)", "Icom/ic745.jpg", "IC-745", @"FM: ~10-100 W (With EX-242 option)
SSB: ~10-100 W
CW: ~10-100 W
Max 50 W @ 10 m", 43, "8 Kg (17.64 lb), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1343, "287*120*316 mm (11.3*4.72*12.44in)", "Icom/ic746.jpg", "IC-746", @"AM: 5-40 W
FM: 5-100 W
SSB: 5-100 W
CW: 5-100 W", 43, "8.9 Kg (19.62 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1344, "287*120*316 mm (11.3*4.72*12.44in)", "Icom/ic746pro.jpg", "IC-746 Pro", @"AM: 5-40 W
FM: 5-100 W
SSB: 5-100 W
CW: 5-100 W", 43, "9 Kg (19.84 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1345, "306*115*355 mm (12.05*4.53*13.98in)", "Icom/ic750.jpg", "IC-750", @"AM: 10-40 W
FM: 10-100 W
SSB: 10-100 W
CW: 10-100 W
RTTY: 10-100 W
(Max 50 W on 10 m)", 43, "8.5 Kg (18.74 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1346, "306*115*355 mm (12.05*4.53*13.98in)", "Icom/ic750a.jpg", "IC-750A", @"AM: 10-40 W
FM: 10-100 W
SSB: 10-100 W
CW: 10-100 W
RTTY: 10-100 W
(Max 50 W on 10 m)", 43, "8.5 Kg (18.74 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1347, "306*115*355 mm (12.05*4.53*13.98in)", "Icom/ic751.jpg", "IC-751", @"AM: 10-40 W
FM: 10-100 W
SSB: 10-100 W
CW: 10-100 W
RTTY: 10-100 W", 43, "8.5 Kg (18.74 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1348, "306*115*355 mm (12.05*4.53*13.98in)", "Icom/ic751a.jpg", "IC-751A", @"AM: 10-50 W
FM: 10-100 W
SSB: 10-100 W
CW: 10-100 W
RTTY: 10-100 W", 43, "8.5 Kg (18.74 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1349, "340*111*285 mm (13.39*4.37*11.22in)", "Icom/ic756.jpg", "IC-756", @"AM: 1-40 W
FM: 2-100 W
SSB: 2-100 W
CW: 2-100 W", 43, "10.5 Kg (23.15 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1350, "340*111*285 mm (13.4*4.37*11.22in)", "Icom/ic756pro.jpg", "IC-756 Pro", @"AM: 5-40 W
FM/SSB/CW/RTTY: 5-100 W
SSB: 5-100 W
CW: 5-100 W
RTTY: 5-100 W", 43, "9.6 Kg (21.2 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1351, "340*111*285 mm (13.4*4.37*11.22in)", "Icom/ic756proii.jpg", "IC-756 Pro II", @"AM: 5-40 W
FM: 5-100 W
SSB: 5-100 W
CW: 5-100 W
RTTY: 5-100 W", 43, "9.6 Kg (21.16 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1352, "340*111*285 mm (13.4*4.37*11.22in)", "Icom/ic756proiii.jpg", "IC-756 Pro III", @"AM: 5-40/5-40 W
FM: 5-100/5-100 W (100% duty cycle)
SSB: 5-100/5-100 W (100% duty cycle)
CW: 5-100/5-100 W (100% duty cycle)
RTTY: 5-100/5-100 W (100% duty cycle)", 43, "9.6 Kg (21.16 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1353, "424*150*390 mm (16.69*5.91*15.35in)", "Icom/ic760.jpg", "IC-760", @"AM: 10-40 W
FM: 10-100 W
SSB: 10-100 W
CW: 10-100 W
RTTY: 10-100 W", 43, "17.5 Kg (38.58 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1354, "340*116*280 mm (13.39*4.57*11.02in)", "Icom/ic7600.jpg", "IC-7600", @"AM: 1-30 W
FM: 2-100 W
SSB: 2-100 W
CW: 2-100 W
RTTY: 2-100 W
PSK: 2-100 W", 43, "10 Kg (22.06 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1355, "424*150*390 mm (16.69*5.91*15.35in)", "Icom/ic761.jpg", "IC-761", @"AM: 10-40 W
FM: 10-100 W
SSB: 10-100 W (PEP)
CW: 10-100 W
RTTY: 10-100 W", 43, "17.5 Kg (38.58 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1356, "340*118*277 mm (13.4*4.6*10.9in)", "Icom/ic7610.jpg", "General version", "1-100 W (AM 1-25 W)", 43, "8.5 Kg (18.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1357, "424*150*390 mm (16.7*5.9*15.4in)", "Icom/ic765.jpg", "IC-765", @"AM: Max 40 W
FM: Max 100 W
SSB: Max 100 W (PEP)
CW: Max 100 W
RTTY: Max 100 W", 43, "17.5 Kg (38.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1379, "58*103*34 mm (2.28*4.05*1.34in)", "Icom/ic91a.jpg", "IC-91A", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "300 g (10.6 oz), with BP-217 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1460, "57*122*29 mm (2.24*4.8*1.14in)", "Icom/ict7e.jpg", "IC-T7E", @"High@ 9.6VHigh@ 7.2VLow
2 m:4 W3 W500 mW
70 cm:2.8 W1.6 W500 mW", 43, "320 g (11.3 oz), with BP-180" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1461, "57*122*29 mm (2.24*4.8*1.14in)", "Icom/ict7h.jpg", "IC-T7H", @"High@ 13.5VHigh@ 6VLow
2 m:6 W2 W500 mW
70 cm:6 W1.5 W500 mW", 43, "320 g (11.29 oz), with BP-180" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1462, "58*106*29 mm (2.28*4.17*1.14in)", "Icom/ict81a.jpg", "IC-T81A", @"High@ 13.5VHigh@ 9.6VHigh@ 6VHigh@ 4.8VLow
6 m:5 W4.5 W2 W1.2 W500 mW
2 m:5 W4.5 W2 W1.2 W500 mW
70 cm:5 W4.5 W2 W1.2 W500 mW
23 cm:1 W1 W1 W1 W100 mW", 43, "280 g (9.9 oz), with BP-199 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1565, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/t599a.jpg", "T-599A", "? W", 46, "12.5 Kg (27 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1566, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/t599d.jpg", "T-599D", "? W", 46, "12.5 Kg (27 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1567, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/t599s.jpg", "T-599S", @"AM: ~25-50 W (60-80 W input)
SSB/CW: ~80-100 W (140-160 W input)", 46, "12.5 Kg (27 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1568, "57*120*28 mm (2.24*4.72*1.1in)", "Kenwood/th21at.jpg", "TH-21AT", @"HighLow
2 m:1 W150 mW", 46, "290 g (10.23 oz), with antenna and PB-21" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1569, "57*120*28 mm (2.24*4.72*1.1in)", "Kenwood/th21bt.jpg", "TH-21BT", @"HighLow
2 m:1 W150 mW", 46, "290 g (10.23 oz), with antenna and PB-21" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1570, "57*120*28 mm (2.24*4.72*1.1in)", "Kenwood/th21e.jpg", "TH-21E", @"HighLow
2 m:1 W150 mW", 46, "260 g (9.17 oz), with standard battery pack" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1571, "56*117*24 mm (2.2*4.6*0.95in), with PB-32", "Kenwood/th22e.jpg", "TH-22E", @"HighLowEl
2 m:3-5 W500 mW30 mW", 46, "290 g (10.2 oz), with PB-32, antenna, handstrap and belt hook" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1564, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/t599.jpg", "T-599", "? W", 46, "12.5 Kg (27 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1572, "58*138*30 mm (2.28*5.43*1.18in), with PB-6", "Kenwood/th25at.jpg", "TH-25AT", "Hi: 5 W, Lo: 0.5 W", 46, "400 gr (14.11 oz), with PB-6" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1574, "58*136*30 mm (2.28*5.35*1.18in)", "Kenwood/th26e.jpg", "TH-26E", "Hi: 2.5-5 W (depending on voltage)Lo: 0.5 WEl: 20 mW", 46, "380 gr (13.4 oz), with PB-10, antenna and handstrap" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1575, "? mm", "Kenwood/th27a.jpg", "TH-27A", "Hi: 2.5-5 W (depending on voltage)Lo: 0.5 W", 46, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1576, "? mm", "Kenwood/th27e.jpg", "TH-27E", "Hi: 2.5-5 W (depending on voltage)Lo: 0.5 W", 46, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1577, "50*116*38 mm (1.97*4.57*1.5in)", "Kenwood/th28e.jpg", "TH-28E", @"HighMidLowEl
2 m:2-5 W2.5 W500 mW20 mW



The high output power level depends on operating voltage", 46, "330 g (11.64 oz), with PB-13, antenna, handstrap and belt hook" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1578, "57*120*28 mm (2.24*4.72*1.1in), with PB-21", "Kenwood/th31a.jpg", "TH-31A", @"HighLow
1.25 m:1 W150 mW", 46, "260 g (9.17 oz), with PB-21" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1579, "57*120*28 mm (2.24*4.72*1.1in), with PB-21", "Kenwood/th31at.jpg", "TH-31AT", @"HighLow
1.25 m:1 W150 mW", 46, "260 g (9.17 oz), with PB-21" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1580, "? mm", "Kenwood/th41e.jpg", "TH-41E", "Hi: 1 W, Lo: ? mW", 46, "260 gr (9.17 oz), with standard battery pack" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1573, "58*138*30 mm (2.28*5.43*1.18in), with PB-6", "Kenwood/th25e.jpg", "TH-25E", "Hi: 5 W, Lo: 0.5 W", 46, "400 gr (14.11 oz), with PB-6" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1581, "58*140*40 mm (2.28*5.51*1.58in), with PB-45L", "Kenwood/thd72a.jpg", "TH-D72A", @"HighLowELow
2 m:2-5 W500 mW50 mW
70 cm:2-5 W500 mW50 mW


High power output depends on battery voltage", 46, "370 g (13.05 oz), with PB-45L antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1563, "180*50*176 mm (7*2*6.9in)", "Kenwood/rz1.jpg", "RZ-1", "", 46, "1.5 Kg (3.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1561, "299*110*200 mm (11.77*4.33*7.87in)", "Kenwood/r600.jpg", "R-600", "", 46, "4.5 Kg (9.9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1545, "381*178*254 mm (15*7*10in)", "Kenwood/9r59ds.jpg", "Trio 9R-59DS", "", 46, "8.53 Kg (18.81 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1546, "330*180*310 mm (13*7.09*12.2in)", "Kenwood/trio_jr310.jpg", "Trio JR-310", "", 46, "9.2 Kg (20.28 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1547, "? mm (?in)", "Kenwood/trio_jr500s.jpg", "Trio JR-500S", "", 46, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1548, "330*178*254 mm (13*7*10in)", "Kenwood/jr500se.jpg", "JR-500SE", "", 46, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1549, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/trio_jr599customdeluxe.jpg", "Trio JR-599 Custom Deluxe", "", 46, "5.7 Kg (12.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1550, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/jr599customspecial.jpg", "Trio JR-599 Custom Special (Type M)", "", 46, "5.7 Kg (12.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1551, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/jr599customspecial.jpg", "Trio JR-599 Custom Special (Type X)", "", 46, "5.7 Kg (12.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1562, "333*153*335 mm (13.11*6.02*13.19in)", "Kenwood/r820.jpg", "R-820", "", 46, "12 Kg (26.4 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1552, "362*163*322 mm (14.25*6.42*12.68in), without options", "Kenwood/qr666.jpg", "QR-666", "", 46, "7.3 Kg (16.1 lb), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1554, "375*115*210 mm (14.76*4.53*8.27in)", "Kenwood/r2000.jpg", "R-2000", "", 46, "5.5 Kg (12.13 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1555, "? mm (?in)", "Kenwood/r300.jpg", "R-300", "", 46, "? g (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1556, "270*96*270 mm (10.63*3.78*10.63in)", "Kenwood/r5000.jpg", "R-5000", "", 46, "5.6 Kg (12.35 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1557, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/r599.jpg", "R-599", "", 46, "5.7 Kg (12.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1558, "? mm (?in)", "Kenwood/r599a.jpg", "R-599A", "", 46, "? g (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1559, "270*140*310 mm (10.63*5.51*12.2in)", "Kenwood/r599d.jpg", "R-599D", "", 46, "5.7 Kg (12.57 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1560, "? mm (?in)", "Kenwood/r599s.jpg", "R-599S", "", 46, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1553, "300*115*218 mm (11.81*4.53*8.58in)", "Kenwood/r1000.jpg", "R-1000", "", 46, "5.5 Kg (12.13 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1582, "58*140*40 mm (2.28*5.51*1.58in), with PB-45L", "Kenwood/thd72e.jpg", "TH-D72E", @"HighLowELow
2 m:2-5 W500 mW50 mW
70 cm:2-5 W500 mW50 mW


High power output depends on battery voltage", 46, "370 g (13.05 oz), with PB-45L antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1583, "56*120*34 mm (2.2*4.72*1.34in), with KNB-75L", "Kenwood/thd74.jpg", "TH-D74A", @"HighMidLowELow
2 m:5 W2 W500 mW50 mW
70 cm:5 W2 W500 mW50 mW", 46, "345 g (12.17 oz), with KNB-75L, antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1584, "56*120*34 mm (2.2*4.72*1.34in), with KNB-75L", "Kenwood/thd74e.jpg", "TH-D74E", @"HighMidLowELow
2 m:5 W2 W500 mW50 mW
70 cm:5 W2 W500 mW50 mW", 46, "345 g (12.17 oz), with KNB-75L, antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1606, "140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm261a.jpg", "TM-261A", "Hi: 50 WMid: 10 W, Lo: 5 W", 46, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1607, "? mm", "Kenwood/tm271a.jpg", "TM-271A", "Hi: 60 WMid: ? W, Lo: ? W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1608, "? mm", "Kenwood/tm281a.jpg", "TM-281A", "Hi: 65 WMid: ? W, Lo: ? W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1609, "? mm", "Kenwood/tm3530a.jpg", "TM-3530A", "Hi: 25 W, Lo: 5 W (adjustable)", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1610, "141*39*183 mm (5.55*1.54*7.2in)", "Kenwood/tm401.jpg", "TM-401A", "Hi: 12 W, Lo: 1 W", 46, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1611, "140*40*197 mm (5.5*1.6*7.8in)", "Kenwood/tm411a.jpg", "TM-411A", "Hi: 25 W, Lo: 5 W", 46, "1.25 Kg (2.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1612, "140*40*197 mm (5.5*1.6*7.8in)", "Kenwood/tm411e.jpg", "Trio TM-411E", "Hi: 25 W, Lo: 5 W", 46, "1.25 Kg (2.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1605, "? mm", "Kenwood/tm2570a.jpg", "TM-2570A", "Hi: 70 W, Lo: 5 W (adjustable)", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1613, "141*42*193 mm (5.55*1.65*7.6in)", "Kenwood/tm421a.jpg", "TM-421A", "Hi: 35 W, Lo: 5 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1615, "141*42*193 mm (5.55*1.65*7.6in)", "Kenwood/tm421es.jpg", "TM-421ES", "Hi: 35 W, Lo: 5 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1616, "140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm431e.jpg", "TM-431E", "Hi: 35 WMid: 10 W, Lo: 5 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1617, "140*40*160 mm140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm441e.jpg", "TM-441E", "Hi: 35 WMid: 10 W, Lo: 5 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1618, "140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm451e.jpg", "TM-451E", "Hi: 35 WMid: 10 W, Lo: 5 W", 46, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1619, "180*60*216 mm (7.09*2.36*8.5in)", "Kenwood/tm455e.jpg", "TM-455E", "Hi: 35 W, Lo: 5 W", 46, "2.8 Kg (6.17 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1620, "140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm461a.jpg", "TM-461A", "Hi: 35 WMid: 10 W, Lo: 5 W", 46, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1621, "141*42*193 mm (5.55*1.65*7.6in)", "Kenwood/tm521.jpg", "TM-521", "Hi: 10 W, Lo: 1 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1614, "141*42*154 mm (5.55*1.65*6.06in)", "Kenwood/tm421e.jpg", "TM-421E", "Hi: 10 W, Lo: 1 W", 46, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1604, "180*60*216 mm (7.09*2.36*8.5in)", "Kenwood/tm255e.jpg", "TM-255E", "Hi: 40 W, Lo: 5 W", 46, "2.7 Kg (5.95 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1603, "? mm", "Kenwood/tm2550e.jpg", "TM-2550E", "Hi: 45 W, Lo: 5 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1602, "140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm251e.jpg", "TM-251E", "Hi: 50 WMid: 10 W, Lo: 5 W", 46, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1585, "54*120*44 mm (2.13*4.72*1.73in), with PB-39", "Kenwood/thd7a.jpg", "TH-D7A", @"HighLowELow
2 m:2.5-6 W500 mW50 mW
70 cm:2.5-6 W500 mW50 mW


High power output depends on battery voltage", 46, "380 g (13.4 oz), with PB-39" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1586, "54*120*44 mm (2.13*4.72*1.73in), with PB-39", "Kenwood/thd7a.jpg", "TH-D7A(G)", @"HighLowELow
2 m:2.5-6 W500 mW50 mW
70 cm:2.5-6 W500 mW50 mW


High power output depends on battery voltage", 46, "380 g (13.4 oz), with PB-39" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1587, "54*120*36 mm (2.13*4.72*1.42in), with PB-38", "Kenwood/thd7e.jpg", "TH-D7E", @"HighLowELow
2 m:2.5-6 W500 mW50 mW
70 cm:2.5-6 W500 mW50 mW


High power output depends on battery voltage", 46, "340 g (11.99 oz), with PB-38" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1588, "54*120*36 mm (2.13*4.72*1.42in), with PB-38", "Kenwood/thd7e.jpg", "TH-D7E(2.0)", @"HighLowELow
2 m:2.5-6 W500 mW50 mW
70 cm:2.5-6 W500 mW50 mW


High power output depends on battery voltage", 46, "340 g (11.99 oz), with PB-38" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1589, "58*87*30 mm (2.28*3.42*1.18in), with PB-42L battery pack", "Kenwood/thf6a.jpg", "TH-F6A", @"HighLowELow
2 m:5 W500 mW50 mW
1.25 m:5 W500 mW50 mW
70 cm:5 W500 mW50 mW


NB! Output power is lower with BT-13 (Misspelled as BT-14 at pg53in the manual!)", 46, "250 g (8.82 oz), with PB-42L battery pack" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1590, "58*87*30 mm (2.28*3.42*1.18in), with PB-42L battery pack", "Kenwood/thf7e.jpg", "TH-F7E", @"HighLowELow
2 m:5 W500 mW50 mW
70 cm:5 W500 mW50 mW


NB! Output power is lower with BT-13 (Misspelled as BT-14 at pg53in the manual!)", 46, "250 g (8.82 oz), with PB-42L battery pack" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1591, "54*112*34 mm (2.13*4.41*1.32in)", "Kenwood/thg71a.jpg", "TH-G71A", @"HighLowELow
2 m:2.5-6 W500 mW50 mW
70 cm:2.2-5.5 W500 mW50 mW


High power output depends on battery pack/voltage", 46, "330 g (11.6 oz), with PB-38, antenna and belt hook" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1592, "54*112*34 mm (2.13*4.41*1.32in)", "Kenwood/thg71e.jpg", "TH-G71E", @"HighLowELow
2 m:2.5-6 W500 mW50 mW
70 cm:2.2-5.5 W500 mW50 mW


High power output depends on battery pack/voltage", 46, "330 g (11.6 oz), with PB-38, antenna and belt hook" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1593, "? mm (?in)", "Kenwood/thk20at.jpg", "TH-K20AT", @"HighMidLow
2 m:5.5 W? W? W", 46, "? g (? lb), with KNB-63L" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1594, "58*110*29 mm (2.28*4.33*1.14in)", "Kenwood/thk2at.jpg", "TH-K2AT", @"HighMidLow
2 m:5 W1.5 W500 mW", 46, "355 g (12.52 oz), with PB-43N and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1595, "58*110*36 mm (2.28*4.33*1.42in)", "Kenwood/thk2.jpg", "TH-K2E", @"HighMidLow
2 m:5 W1.5 W500 mW


Indicated output power is with PB-43N or 13.8 VDC external.
Output power is slightly lower with BT-14 dry cell case.", 46, "320 g (11.3 oz), with PB-43N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1596, "58*110*29 mm (2.28*4.33*1.14in)", "Kenwood/thk2et.jpg", "TH-K2ET", @"HighMidLow
2 m:5 W1.5 W500 mW



The high output level depends on voltage", 46, "355 g (12.52 oz), with PB-43N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1597, "58*128*36 mm (2.28*5.04*1.42in)", "Kenwood/thk4.jpg", "TH-K4E", @"HighMidLow
70 cm:5 W? W? W



The high output level depends on voltage", 46, "355 g (12.52 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1598, "58*102*27 mm (2.28*4.02*1.06in)", "Kenwood/thk7.jpg", "TH-K7", @"2 m: 300 mW
70 cm: 300 mW", 46, "160 g (5.64 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1599, "140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm231e.jpg", "TM-231E", "Hi: 50 WMid: 10 W, Lo: 2 W", 46, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1600, "150*50*160 mm (5.91*1.97*6.3in)", "Kenwood/tm2400.jpg", "TM-2400", "Hi: 1 W, Lo: 0.1 W", 46, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1601, "140*40*160 mm (5.51*1.58*6.3in)", "Kenwood/tm241e.jpg", "TM-241E", "Hi: 50 WMid: 10 W, Lo: 5 W", 46, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1544, "381*178*254 mm (15*7*10in)", "Kenwood/9r59.jpg", "Trio 9R-59", "", 46, "9.3 Kg (20.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1543, "390*210*240 mm (15.35*8.27*9.45in)", "Kenwood/9r4j.jpg", "Trio 9R-4J", "", 46, "11 Kg (24.25 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1542, "? mm", "KDK/fm740.jpg", "FM-740 (Kyokuto Denshi K.K.)", "Hi: 10 W, Lo: 1 W", 45, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1541, "? mm", "KDK/fm5010l.jpg", "FM-50 10L (Kyokuto Denshi K.K.)", "Hi: ? WMid: ? W, Lo: ? mW", 45, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1484, "57*137*33 mm (2.24*5.39*1.3in)", "Icom/icw32a.jpg", "IC-W32A", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "450 g (15.87 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1485, "57*137*33 mm (2.24*5.39*1.3in)", "Icom/icw32e.jpg", "IC-W32E", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "450 g (15.87 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1486, "57*125*35 mm (2.24*4.92*1.38in)", "Icom/icx21t.jpg", "IC-X21T", @"High@ 13.5VLow3Low2Low1ELow
70 cm:5 W3.5 W1.5 W500 mW15 mW
23 cm:1 W600 mW350 mW150 mW150 mW", 43, "380 g (13.4)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1487, "54*135*38 mm (2.13*5.32*1.5in)", "Icom/icx2e.jpg", "IC-X2E", @"HighLow
70 cm:5 W? mW
23 cm:1 W? mW", 43, "405 g (14.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1488, "57*125*36 mm (2.24*4.92*1.42in)", "Icom/icz1e.jpg", "IC-Z1A", @"HighMidLow
2 m:5 W500 mW15 mW
70 cm:5 W500 mW15 mW", 43, "380 g (13.4 oz), with BP-171" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1489, "57*125*36 mm (2.24*4.92*1.42in)", "Icom/icz1e.jpg", "IC-Z1E", @"HighMidLow
2 m:5 W500 mW15 mW
70 cm:5 W500 mW15 mW", 43, "380 g (13.4 oz), with BP-171" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1490, "Controller: 154*50*51 mm (6.06*1.97*2in)Transceiver: 141*40*166 mm (5.55*1.58*6.54in)", "Icom/id1.jpg", "ID-1", "Hi: 10 W, Lo: 1 W", 43, "Controller: 220 g (7.76 oz)Transceiver: 1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1483, "57*125*31 mm (2.24*4.92*1.22in)", "Icom/icw31e.jpg", "IC-W31E", @"HighMidLow
2 m:5 W500 mW15 mW
70 cm:5 W500 mW15 mW", 43, "320 g (11.29 oz), with BP-170)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1491, "58*95*25 mm (2.28*3.74*0.98in)", "Icom/id31e.jpg", "ID-31E", @"HighLow 3Low 2Low 1
70 cm:5 W? W? W? mW", 43, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1493, "150*40*172 mm (5.91*1.57*6.77in)", "Icom/id4100.jpg", "ID-4100E", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "1.2 Kg (2.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1494, "Main unit: ? mm (?in)Controller: ? mm (?in)", "Icom/id5100.jpg", "ID-5100", "Hi: 50/50 WMid: ?/? W, Lo: ?/? W", 43, "Main unit: ? Kg (? lbs)Controller: ? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1495, "Main unit: 150*40*173 mm (5.9*1.6*6.8in)Controller: 182*25*82 mm (7.2*1*3.2in)", "Icom/id5100.jpg", "ID-5100A", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "Main unit: 1.3 Kg (2.9 lb)Controller: 260 g (9.2 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1496, "Main unit: 150*40*173 mm (5.9*1.6*6.8in)Controller: 182*25*82 mm (7.2*1*3.2in)", "Icom/id5100.jpg", "ID-5100E", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "Main unit: 1.3 Kg (2.9 lb)Controller: 260 g (9.2 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1497, "58*105*26 mm (2.28*4.13*1.02in)", "Icom/id51.jpg", "ID-51A", @"HighMidLow 2Low 1S-Low
2 m:5 W2.5 W1 W500 mW100 mW
70 cm:5 W2.5 W1 W500 mW100 mW", 43, "255 g (9 oz), with BP-271 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1498, "58*105*26 mm (2.28*4.13*1.02in)", "Icom/id51plus2.jpg", "ID-51A Plus2", @"HighMidLow 2Low 1S-Low
2 m:5 W2.5 W1 W500 mW100 mW
70 cm:5 W2.5 W1 W500 mW100 mW", 43, "255 g (8.99 oz), with BP-271 and antenna)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1499, "58*105*26 mm (2.28*4.13*1.02in)", "Icom/id51.jpg", "ID-51E", @"HighMidLow 2Low 1S-Low
2 m:5 W2.5 W1 W500 mW100 mW
70 cm:5 W2.5 W1 W500 mW100 mW", 43, "255 g (9 oz), with BP-271 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1492, "150*40*172 mm (5.91*1.57*6.77in)", "Icom/id4100.jpg", "ID-4100A", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "1.2 Kg (2.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1482, "57*125*31 mm (2.24*4.92*1.22in)", "Icom/icw31a.jpg", "IC-W31A", @"HighMidLow
2 m:5 W500 mW15 mW
70 cm:5 W500 mW15 mW", 43, "340 g (11.99 oz), with BP-171" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1481, "54*154*36 mm (2.12*6.06*1.42in)", "Icom/icw2e.jpg", "IC-W2E", @"HighLow 3Low 2Low 1
2 m:5 W3.5 W1.5 W500 mW
70 cm:5 W3.5 W1.5 W500 mW", 43, "450 g (15.87 oz), with BP-83" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1480, "54*154*36 mm (2.12*6.06*1.42in)", "Icom/icw2a.jpg", "IC-W2A", @"HighLow 3Low 2Low 1
2 m:5 W3.5 W1.5 W500 mW
70 cm:5 W3.5 W1.5 W500 mW", 43, "450 g (15.87 oz), with BP-83" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1463, "58*106*29 mm (2.28*4.17*1.14in)", "Icom/ict81e.jpg", "IC-T81E", @"High@ 13.5VHigh@ 9.6VHigh@ 6VHigh@ 4.8VLow
6 m:5 W4.5 W2 W1.2 W500 mW
2 m:5 W4.5 W2 W1.2 W500 mW
70 cm:5 W4.5 W2 W1.2 W500 mW
23 cm:1 W1 W1 W1 W100 mW", 43, "280 g (9.9 oz), with BP-199 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1464, "58*87*29 mm (2.28*3.42*1.14in)", "Icom/ict82r.jpg", "IC-T82R (Withdrawn from the market)", "Hi: 5/5/5 W, Lo: 0.5/0.5/0.5 W", 43, "240 gr (8.47 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1465, "58*107*29 mm (2.28*4.21*1.14in)", "Icom/ict8a.jpg", "IC-T8A", @"High@ 13.5VHigh@ 9.6VHigh@ 6VHigh@ 4.8VLow
6 m:5 W4.5 W2 W1.2 W500 mW
2 m:5 W4.5 W2 W1.2 W500 mW
70 cm:5 W4.5 W2 W1.2 W500 mW", 43, "270 g (9.52 oz), with BP-198" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1466, "58*107*29 mm (2.28*4.21*1.14in)", "Icom/ict8e.jpg", "IC-T8E", @"High@ 13.5VHigh@ 9.6VHigh@ 6VHigh@ 4.8VLow
6 m:5 W4.5 W2 W1.2 W500 mW
2 m:5 W4.5 W2 W1.2 W500 mW
70 cm:5 W4.5 W2 W1.2 W500 mW", 43, "270 g (9.52 oz), with BP-198" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1467, "58*87*29 mm (2.28*3.42*1.14in)", "Icom/ict90.jpg", "IC-T90", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "280 g (9.88 oz), with antenna and BP-217" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1468, "58*87*29 mm (2.28*3.42*1.14in)", "Icom/ict90a.jpg", "IC-T90A", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "280 g (9.88 oz), with antenna and BP-217" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1469, "54*140*37 mm (2.13*5.51*1.46in)", "Icom/icu1.jpg", "IC-U1", @"HighMidLow
70 cm:5 W2 W500 mW", 43, "390 g (13.76 oz), with ABP-222N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1470, "54*140*37 mm (2.13*5.51*1.46in)", "Icom/icu82.jpg", "IC-U82", @"HighMidLow

70 cm:5 W2 W500 mW", 43, "390 g (13.76 oz), with ABP-222N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1471, "54*140*37 mm (2.13*5.51*1.46in)", "Icom/icv1.jpg", "IC-V1", @"HighMidLow
2 m:7 W4 W500 mW", 43, "390 g (13.76 oz), with ABP-222N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1472, "? mm (?in)", "Icom/icv21at.jpg", "IC-V21AT", @"HighLow
2 m:5 W? mW
1.25 m:5 W? mW", 43, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1473, "54*132*35 mm (2.12*5.2*1.38in)", "Icom/icv8.jpg", "IC-V8", @"HighLow
2 m:5.5 W500 mW", 43, "350 g (12.35 oz), with antenna and battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1474, "150*50*150 mm (5.91*1.97*5.91in)", "Icom/icv8000.jpg", "IC-V8000", @"HighMid-HiMid-LoLow
2 m:75 W25 W10 W5 W", 43, "1.1 Kg (2.42 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1475, "54*140*37 mm (2.12*5.51*1.46in)", "Icom/icv82.jpg", "IC-V82", @"HighMidLow
2 m:7 W4 W500 mW", 43, "390 g (13.76 oz), with ABP-222N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1476, "56*110*35 mm (2.2*4.33*1.38in)", "Icom/icv85.jpg", "IC-V85", @"HighMidLow
2 m:7 W4 W500 mW", 43, "310 g (10.93 oz), with BP-227" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1477, "57*169*32 mm (2.24*6.65*1.26in)", "Icom/icw21at.jpg", "IC-W21AT", @"High@ 12VLow3Low2Low1EL
2 m:5 W3.5 W1.5 W500 mW15 mW
70 cm:5 W3.5 W1.5 W500 mW15 mW", 43, "~440 g (~15.52 oz), depending on battery type" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1478, "57*125*35 mm 2.24*4.92*1.38in)", "Icom/icw21e.jpg", "IC-W21E", @"High@ 12VLow3Low2Low1EL
2 m:5 W3.5 W1.5 W500 mW15 mW
70 cm:5 W3.5 W1.5 W500 mW15 mW", 43, "390 g (13.76 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1479, "57*125*35 mm 2.24*4.92*1.38in)", "Icom/icw21et.jpg", "IC-W21ET", @"High@ 12VLow3Low2Low1EL
2 m:5 W3.5 W1.5 W500 mW15 mW
70 cm:5 W3.5 W1.5 W500 mW15 mW", 43, "390 g (13.76 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1500, "58*105*26 mm (2.28*4.13*1.02in)", "Icom/id51plus2.jpg", "ID-51E Plus2", @"HighMidLow 2Low 1S-Low
2 m:5 W2.5 W1 W500 mW100 mW
70 cm:5 W2.5 W1 W500 mW100 mW", 43, "255 g (8.99 oz), with BP-271 and antenna)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1946, "127*35*165 mm (5*1.38*6.5in)", "Regency/inf2.jpg", "INF-2 \"Informant\"", "", 60, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1501, "61*122*35 mm (2.4*4.8*1.4in)", "Icom/id52.jpg", "ID-52A", @"HighMidLow 2Low 1S-Low
2 m:5 W2.5 W1 W500 mW100 mW
70 cm:5 W2.5 W1 W500 mW100 mW", 43, "330 g (11.6 oz), with BP-272 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1503, "? mm (?in)", "Icom/id80.jpg", "ID-80", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1525, "330*130*285 mm (13*5.12*11.22in)", "JRC/jrc_nrd545.jpg", "NRD-545", "", 44, "7.5 Kg (16.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1526, "? mm", "JRC/jrc_nrd71.jpg", "NRD-71", "", 44, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1527, "480*149*290 mm (18.9*5.87*11.42in)", "JRC/jrc_nrd72.jpg", "NRD-72", "", 44, "11 Kg (24.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1528, "489*190*305 mm (19.25*7.48*12.01in)", "JRC/jrc_nrd91.jpg", "NRD-91", "", 44, "15 Kg (33.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1529, "489*190*305 mm (19.25*7.48*12.01in)", "JRC/jrc_nrd92m.jpg", "NRD-92M", "", 44, "15 Kg (33.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1530, "480*149*294 mm (18.9*5.87*11.57in)", "JRC/nrd630.jpg", "NRD-630", "", 44, "6 Kg (13.23 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1531, "? mm", "KDK/fm14410la.jpg", "FM-144 10LA (Kyokuto Denshi K.K.)", "Hi: 10 WMid: 1 W, Lo: 0.1 W", 45, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1524, "330*130*280 mm (13*5.12*11.02in)", "JRC/jrc_nrd535.jpg", "NRD-535", "", 44, "8.5 Kg (18.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1532, "165*54*195 mm (6.5*2.13*7.5in)", "KDK/fm14410sxrii.jpg", "FM-144 10SX RII (Kyokuto Denshi K.K.)", "Hi: 10 W, Lo: 1 W", 45, "2.1 Kg (4.63 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1534, "180*60*215 mm (7.09*2.36*8.46in)", "KDK/fm2016e.jpg", "FM-2016E (Kyokuto Denshi K.K.)", "Hi: 15 W, Lo: 2 W", 45, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1535, "180*60*195 mm (7.09*2.36*7.68in)", "KDK/fm2025.jpg", "FM-2025 (Kyokuto Denshi K.K.)", "Hi: 25 W, Lo: 3 W", 45, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1536, "180*60*195 mm (7.09*2.36*7.68in)", "KDK/fm2025e.jpg", "(Kyokuto Denshi K.K.) FM-2025E", @"HighLow
2 m:25 W3 W", 45, "2.2 Kg (4.85 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1537, "162*55*182 mm (6.38*2.16*7.16in)", "KDK/fm2030.jpg", "FM-2030 (Kyokuto Denshi K.K.)", "Hi: 25 W, Lo: 5 W", 45, "1.7 Kg 3.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1538, "162*55*182 mm (6.38*2.16*7.16in)", "KDK/fm2033.jpg", "FM-2033 (Kyokuto Denshi K.K.)", "Hi: 25 W, Lo: 5 W", 45, "1.7 Kg (3.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1539, "? mm", "KDK/fm240.jpg", "FM-240 (Kyokuto Denshi K.K.)", "Hi: 25 W, Lo: 5 W", 45, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1540, "162*55*182 mm (6.38*2.16*7.16in)", "KDK/fm4033.jpg", "FM-4033 (Kyokuto Denshi K.K.)", "Hi: 25 W, Lo: 5 W", 45, "1.7 Kg (3.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1533, "180*60*195 mm (7.09*2.36*7.68in)", "KDK/fm2015r.jpg", "FM-2015R (Kyokuto Denshi K.K.)", "Hi: 15 W, Lo: 1 W", 45, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1523, "343*132*287 mm (13.5*5.2*11.3in)", "JRC/jrc_nrd525.jpg", "NRD-525", "", 44, "8.62 Kg (19 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1522, "340*140*300 mm (13.4*5.5*11.8in)", "JRC/jrc_nrd515.jpg", "NRD-515", "", 44, "7.71 Kg (17 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1521, "340*140*300 mm (13.39*5.51*11.81in)", "JRC/jrc_nrd505.jpg", "NRD-505", "", 44, "10 Kg (22.05 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1504, "Transceiver: 141*40*186 mm (5.55*1.58*7.32in)Control head: 111*40*39 mm (4.37*1.58*1.54in)", "Icom/id800.jpg", "ID-800D", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "Transceiver: 1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1505, "Transceiver: 141*40*186 mm (5.55*1.58*7.32in)Control head: 111*40*39 mm (4.37*1.58*1.54in)", "Icom/id800h.jpg", "ID-800H", @"HighMidLow
2 m:55 W15 W5 W
70 cm:50 W15 W5 W", 43, "Transceiver: 1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1506, "150*40*199 mm (5.9*1.57*7.83in)", "Icom/id880d.jpg", "ID-880D", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "1.3 Kg (2.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1507, "58*103*24 mm (2.28*4.06*0.94in)", "Icom/id91.jpg", "ID-91", @"HighLow
2 m:5 W500 mW
70 cm:5 W500 mW", 43, "300 g (10.58 oz), without batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1508, "59*112*34 mm (2.32*4.41*1.34in)", "Icom/id92.jpg", "ID-92", @"HighMid 1Mid 2Low
2 m:5 W2.5 W500 mW100 mW
70 cm:5 W2.5 W500 mW100 mW", 43, "315 g (11.11 oz), with BP-270" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1509, "150*40*199 mm (5.91*1.58*7.84in)", "Icom/ide880.jpg", "ID-E880", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "1.3 Kg (2.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1510, "? mm (?in)", "Icom/tra60.jpg", "IEW Inoue Electric Works (Icom) TRA-60", "? W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1511, "? mm", "Icom/x3.jpg", "X3", "? / ? W", 43, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1512, "? mm", "JRC/jrc_jst100.jpg", "JST-100D", "Max 100 W", 44, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1513, "? mm", "JRC/jrc_jst100.jpg", "JST-100S", "Max 10 W", 44, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1514, "? mm", "JRC/jrc_jst110.jpg", "JST-110D", "100 W", 44, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1515, "? mm", "JRC/jrc_jst125.jpg", "JST-125", "5-100 W", 44, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1516, "? mm", "JRC/jrc_jst135.jpg", "JST-135", "150 W", 44, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1517, "350*130*305 mm (13.78*5.12*305in)", "JRC/jrc_jstx45.jpg", "JST-145", "7-150 W (AM: 3-50 W)", 44, "12 Kg (26.46 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1518, "350*130*305 mm (13.78*5.12*305in)", "JRC/jrc_jstx45.jpg", "JST-245", "7-150 W (AM: 3-50 W)", 44, "12 Kg (26.46 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1519, "480*150*290 mm (18.9*5.91*11.42in)", "JRC/jrc_nrd301a.jpg", "NRD-301A", "", 44, "7.5 Kg (16.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1520, "250*100*240 mm (9.84*3.94*9.45in)", "JRC/jrc_nrd345.jpg", "NRD-345", "", 44, "3.5 Kg (7.72 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1502, "61*122*35 mm (2.4*4.8*1.4in)", "Icom/id52.jpg", "ID-52E", @"HighMidLow 2Low 1S-Low
2 m:5 W2.5 W1 W500 mW100 mW
70 cm:5 W2.5 W1 W500 mW100 mW", 43, "330 g (11.6 oz), with BP-272 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1300, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic575a.jpg", "IC-575A", @"AM: 1-4 W
FM/SSB/CW: 1-10 W", 43, "6.1 Kg (13.45 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1947, "? mm (?in)", "Regency/inf3.jpg", "INF-3 \"Informant\"", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1949, "? mm (?in)", "Regency/inf7.jpg", "INF-7 \"Informant\"", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2376, "160*50*180 mm (6.3*1.97*7.09in)", "Yaesu/ft2500m.jpg", "FT-2500M", "Hi: 50 WMid: 20 W, Lo: 5 W", 77, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2377, "? mm", "Yaesu/ft250r.jpg", "FT-250R", "Hi: 5 W, Lo: ? mW", 77, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2378, "62*121*39 mm (2.44*4.76*1.53in)", "Yaesu/ft252.jpg", "FT-252", "Hi: 5 WMid: 2 W, Lo: 0.5 W", 77, "280 gr (9.88 oz), with antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2379, "62*121*39 mm (2.44*4.76*1.53in)", "Yaesu/ft257.jpg", "FT-257", "Hi: 5 WMid: 2 W, Lo: 0.5 W", 77, "280 gr (9.88 oz), with antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2380, "52*104*31 mm (2.1*4.1*1.2in)", "Yaesu/ft25.jpg", "FT-25E", @"Hi: 5 W
Mid: 2 W, Lo: 500 mW", 77, "260 gr (9.17 oz), with SBR-25Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2381, "52*104*31 mm (2.1*4.1*1.2in)", "Yaesu/ft25.jpg", "FT-25R", @"Hi: 5 W
Mid: 2 W, Lo: 500 mW", 77, "260 gr (9.17 oz), with SBR-25Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2382, "55*146*33 mm (2.16*5.75*1.3in), with FNB-27", "Yaesu/ft26.jpg", "FT-26", @"Hi: 2-5 W (depending on voltage)
L3: 2-3 W (depending on voltage)
L2: 1.5 W
L1: 500 mW", 77, "430 g (15.17 oz), with FNB-27" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2375, "160*50*180 mm (6.3*1.97*7.09in)", "Yaesu/ft2400.jpg", "FT-2400", "Hi: 50 WMid: 25 W, Lo: 5 W", 77, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2383, "160*40*160 mm (6.3*1.58*6.3in)", "Yaesu/ft2600m.jpg", "FT-2600M", "Hi: 60 WMid1: 25 WMid2: 10 W, Lo: 5 W", 77, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2385, "150*50*168 mm (5.91*1.97*6.61in)", "Yaesu/ft2700r.jpg", "FT-2700R", "Hi: ?/? W, Lo: ?/? W", 77, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2386, "150*50*168 mm (5.91*1.97*6.61in)", "Yaesu/ft2700rh.jpg", "FT-2700RH", "Hi: 25/25 W, Lo: 3/3 W", 77, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2387, "140*40*162 mm (5.51*1.58*6.38in)", "Yaesu/ft270r.jpg", "FT-270R", "Hi: 25 W, Lo: 3 W", 77, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2388, "140*40*162 mm (5.51*1.58*6.38in)", "Yaesu/ft270r.jpg", "FT-270RH", "Hi: 45 W, Lo: 5 W", 77, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2389, "160*50*185 mm (6.3*1.97*7.28in)", "Yaesu/ft2800m.jpg", "FT-2800M", "Hi: 65 WMid: 25 W, Lo2: 10 W, Lo1: 5 W", 77, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2390, "160*50*185 mm (6.3*2*7.3in)", "Yaesu/ft2900r.jpg", "FT-2900R", @"Hi: 75 W
Mid: 30 W, Lo1: 10 W, Lo2: 5 W", 77, "1.9 Kg (4.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2391, "150*58*195 mm (5.9*2.28*7.68in)", "Yaesu/ft290r.jpg", "FT-290R", "Hi: 2.5 W @ 12 VDCLo: 0.5 W", 77, "1.3 Kg (2.87 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2384, "? mm", "Yaesu/ft270.jpg", "FT-270", "Hi: 5 W, Lo: ? mW", 77, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2392, "150*57*194 mm (5.91*2.24*7.64in)", "Yaesu/ft290rii.jpg", "FT-290R II", "Max 2.5 W (25 W with optional FL-2025)", 77, "1.2 Kg (2.65 lbs), without battery case2.1 Kg (4.63 lbs), with optional FL-2025" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2374, "55*139*32 mm (2.16*5.47*1.26in), with FNB-10", "Yaesu/ft23r.jpg", "FT-23R", @"Hi: 2-5 W (depending on voltage)
Lo: 200-500 mW (depending on voltage)", 77, "430 g (15.17 oz), with FNB-10" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2372, "160*50*175 mm (6.3*1.97*6.89in)", "Yaesu/ft2311r.jpg", "FT-2311R", "Hi: 10 W, Lo: 1 W (version B), 5 W (version A)", 77, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2356, "65*168*34 mm (2.56*6.61*1.34in)", "Yaesu/ft209r.jpg", "FT-209R", "Hi: 3.5 W (Depending on battery pack/voltage)Lo: 350 mW", 77, "557 g (19.65 oz), with FNB-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2357, "65*168*34 mm (2.56*6.61*1.34in)", "Yaesu/ft209rh.jpg", "FT-209RH", "Hi: 2.3-5 W (Depending on battery pack/voltage)Lo: 500 mW", 77, "557 g (19.65 oz), with FNB-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2358, "160*50*175 mm (6.3*1.97*6.89in)", "Yaesu/ft211rh.jpg", "FT-211RH", @"HighLow
2 m:45 W5 W", 77, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2359, "140*40*160 mm (5.51*1.58*6.3in)", "Yaesu/ft212rh.jpg", "FT-212RH", "Hi: 45 W, Lo: 5 W", 77, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2360, "140*40*160 mm (5.51*1.58*6.3in)", "Yaesu/ft215.jpg", "FT-215", "Hi: 50 WMid: 25 W, Lo: 5 W", 77, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2361, "280*125*295 mm (11*4.92*11.6in)", "Yaesu/ft220.jpg", "FT-220", @"FM/CW: 10 W
SSB: Max 10 W (PEP)", 77, "8.5 Kg (18.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2362, "140*40*160 mm (5.51*1.58*6.3in)", "Yaesu/ft2200.jpg", "FT-2200", "Hi: 50 WMid: 25 W, Lo: 5 W", 77, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2373, "? mm", "Yaesu/ft2312r.jpg", "FT-2312R", "Hi: 10 W, Lo: 1 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2363, "280*125*295 mm (11*4.9*11.6in)", "Yaesu/ft221.jpg", "FT-221", @"FM/CW: 10 W
SSB: Max 10 W (PEP)", 77, "8.5 Kg (18.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2365, "180*70*220 mm (7.09*2.76*8.66in)", "Yaesu/ft224.jpg", "FT-224", "Hi: 10 W, Lo: 1 W", 77, "2.5 Kg (5.51 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2366, "280*125*315 mm (11*4.92*12.4in)", "Yaesu/ft225rd.jpg", "FT-225RD", @"AM: 8 W (DC)
FM/CW: 25 W (DC)
SSB: 24 W (PEP)", 77, "9 Kg (19.84 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2367, "180*60*220 mm (7.09*2.36*8.66in)", "Yaesu/ft227r.jpg", "FT-227R \"Memorizer\"", "Hi: 10 W, Lo: 1 W", 77, "2.7 Kg (5.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2368, "180*60*220 mm (7.09*2.36*8.66in)", "Yaesu/ft227ra.jpg", "FT-227RA \"Memorizer\"", "Hi: 10 W, Lo: 1 W", 77, "2.7 Kg (5.95 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2369, "180*60*220 mm (7.09*2.36*8.66in)", "Yaesu/ft227rb.jpg", "FT-227RB \"Memorizer\"", "Hi: 10 W, Lo: 1 W", 77, "2.7 Kg (5.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2370, "68*168*38 mm (2.68*6.61*2.4in), with FNB-3", "Yaesu/ft2303.jpg", "FT-2303", "Hi: 1 W, Lo: 100 mW", 77, "655 gr (1.44 lbs), with FNB-3 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2371, "150*50*174 mm (5.91*1.97*6.85in)", "Yaesu/ft230r.jpg", "FT-230R", "Hi: 25 W, Lo: 3 W", 77, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2364, "280*125*295 mm (11*4.9*11.6in)", "Yaesu/ft221r.jpg", "FT-221R", @"AM: 2.5 W
FM/CW: 14 W
SSB: 12 W (PEP)", 77, "8.5 Kg (18.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2393, "160*50*185 mm (6.3*2*7.3in)", "Yaesu/ft2980e.jpg", "FT-2980E", @"Hi: 80 W
Mid1: 30 W
Mid2: 10 W, Lo: 5 W", 77, "1.9 Kg (4.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2394, "160*50*185 mm (6.3*2*7.3in)", "Yaesu/ft2980r.jpg", "FT-2980R", @"Hi: 80 W
Mid1: 30 W
Mid2: 10 W, Lo: 5 W", 77, "1.9 Kg (4.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2395, "210*95*270 mm (8.27*3.74*10.63in)", "Yaesu/ft2auto.jpg", "FT-2 AUTO", "Hi: 10 W, Lo: 1 W", 77, "4.2 Kg (9.26 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2417, "55*146*33 mm (2.16*5.75*1.3in), with FNB-27", "Yaesu/ft416.jpg", "FT-416", "Hi: 5 W, Lo3: 3 W, Lo2: 1.5Lo1: 0.5 W", 77, "430 g (15.17 oz), with FNB-27" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2418, "57*102*26 mm (2.24*4.02*1.02in), with FNB-31", "Yaesu/ft41r.jpg", "FT-41R", "Hi: 4.5 W, Lo3: 2 W, Lo2: 1 W, Lo1: 200 mW", 77, "280 gr (9.88 oz), with FNB-31" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2419, "229*84*217 mm (9.02*3.31*8.54in)", "Yaesu/ft450.jpg", "FT-450", "100 / 100 W", 77, "3.6 Kg (7.94 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2420, "229*84*217 mm (9.02*3.31*8.54in)", "Yaesu/ft450d.jpg", "FT-450D", "100 / 100 W", 77, "3.6 Kg (7.94 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2421, "? mm", "Yaesu/ft4600h.jpg", "FT-4600H", "Hi: ? W, Lo: ? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2422, "? mm", "Yaesu/ft470.jpg", "FT-470", "Hi: 5/5 W, Lo: ?/? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2423, "150*50*180 mm (5.91*1.97*7.09in)", "Yaesu/ft4700rh.jpg", "FT-4700RH", "Hi: 50/40 W, Lo: 5/5 W", 77, "2.0 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2416, "55*146*33 mm (2.16*5.75*1.3in), with FNB-27", "Yaesu/ft415.jpg", "FT-415", "Hi: 5 W, Lo3: 3 W, Lo2: 1.5 W, Lo1: 0.5 W", 77, "430 g (15.17 oz), with FNB-27" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2424, "140*40*155 mm (5.5*1.6*6.1in)", "Yaesu/ft4800h.jpg", "FT-4800H", "Hi: 50 / 35 W, Lo: 5 / 5 W", 77, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2426, "180*60*240 mm (7.09*2.36*9.45in)", "Yaesu/ft480r.jpg", "FT-480R", @"FM/CW, Hi: 10 W, Lo: 1 W
SSB: 30 W (PEP input)", 77, "2.9 Kg (6.39 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2427, "52*90*30 mm (2.05*3.54*1.18in)", "Yaesu/ft4ve.jpg", "FT-4VE", @"Hi: 5 W
Mid: 2.5 W, Lo: 0.5 W", 77, "250 g (8.82 oz), with SBR-28LI and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2428, "52*90*30 mm (2.05*3.54*1.18in)", "Yaesu/ft4vr.jpg", "FT-4VR", @"Hi: 5 W
Mid: 2.5 W, Lo: 0.5 W", 77, "250 g (8.82 oz), with SBR-28LI and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2429, "52*90*30 mm (2.05*3.54*1.18in)", "Yaesu/ft4xe.jpg", "FT-4XE", @"Hi: 5 W
Mid: 2.5 W, Lo: 0.5 W", 77, "250 g (8.82 oz), with SBR-28LI and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2430, "52*90*30 mm (2.05*3.54*1.18in)", "Yaesu/ft4xr.jpg", "FT-4XR", @"Hi: 5 W
Mid: 2.5 W, Lo: 0.5 W", 77, "250 g (8.82 oz), with SBR-28LI and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2431, "? mm", "Yaesu/ft50.jpg", "FT-50", "100 W (input)", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2432, "350*160*292 mm (13.8*6.3*11.5in)", "Yaesu/ft501.jpg", "FT-501", @"SSB: ~350 W PEP (560 W PEP input)
CW: ~250 W (380 W input)", 77, "10 Kg (22.05 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2425, "140*40*155 mm (5.5*1.6*6.1in)", "Yaesu/ft4800m.jpg", "FT-4800M", "Hi: 25 / 25 W, Lo: 3 / 3 W", 77, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2415, "55*188*32 mm (2.16*7.4*1.26in), with FNB-11H", "Yaesu/ft411mkii.jpg", "FT-411MKII", "Hi: 2.5-5 W (depending on voltage)Lo: ? W", 77, "550 gr (19.4 oz), with FNB-11H" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2414, "55*139*32 mm (2.16*5.47*1.26in)", "Yaesu/ft411e.jpg", "FT-411E", @"Hi: 2-5 W (Depending on voltage)
Lo: ? W", 77, "430 g (15.17 oz), with FNB-10" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2413, "55*139*32 mm (2.16*5.47*1.26in), with FNB-10", "Yaesu/ft411.jpg", "FT-411", @"Hi: 2-5 W (Depending on voltage)
Lo: ? W", 77, "430 g (15.17 oz), with FNB-10" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2396, "62*110*32 mm (2.44*4.33*1.26in), with SBR-14LI and no antenna", "Yaesu/ft2de.jpg", "FT-2DE", @"2 mHi: 5 W @ 7.2 VDCL3: 2.5 WL2: 0.8-1 WL1: 50 mW


70 cmHi: 5 W @ 7.2 VDCL3: 2.5 WL2: 0.8-1 WL1: 100 mW", 77, "310 gr (10.9 oz), with SBR-14LI and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2397, "62*110*32 mm (2.44*4.33*1.26in), with SBR-14LI and no antenna", "Yaesu/ft2d.jpg", "FT-2DR", @"2 mHi: 5 W @ 7.2 VDCL3: 2.5 WL2: 0.8-1 WL1: 100 mW


70 cmHi: 5 W @ 7.2 VDCL3: 2.5 WL2: 0.8-1 WL1: 100 mW", 77, "310 gr (10.9 oz), with SBR-14LI and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2398, "168*64*254 mm (6.62*2.5*10in)", "Yaesu/ft2f.jpg", "FT-2F", "Hi: 10 W, Lo: 1 W", 77, "1.81 Kg (4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2399, "140*40*180 mm (5.51*1.58*7.09in)", "Yaesu/ft3000.jpg", "FT-3000M", "Hi: 70 WMid1: 50 WMid2: 25 W, Lo: 10 W", 77, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2400, "280*125*370 mm (11.02*4.92*14.57in)", "Yaesu/ft301.jpg", "FT-301", "SSB: 200 W (PEP input)CW: 200 W (input)AM/FSK: 50 W (input)", 77, "9 Kg (19.84 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2401, "280*125*370 mm (11.02*4.92*14.57in)", "Yaesu/ft301d.jpg", "FT-301D", "SSB/CW: 100 WAM: 25 W", 77, "9 Kg (19.84 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2402, "280*125*370 mm (11.02*4.92*14.57in)", "Yaesu/ft301s.jpg", "FT-301S", "10 W", 77, "9 Kg (19.84 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2403, "280*125*370 mm (11.02*4.92*14.57in)", "Yaesu/ft301sd.jpg", "FT-301SD", "10 W", 77, "9 Kg (19.84 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2404, "160*50*145 mm (6.3*2*5.71in)", "Yaesu/ft311rm.jpg", "FT-311RM", "Hi: 25 W, Lo: 3 W", 77, "1.3 Kg (2.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2405, "? mm", "Yaesu/ft33r.jpg", "FT-33R", "Hi: 5 W, Lo: ? mW", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2406, "? mm", "Yaesu/ft3700.jpg", "FT-3700", "Hi: ?/? W, Lo: ?/? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2407, "? mm", "Yaesu/ft3800.jpg", "FT-3800", "Hi: ? W, Lo: ? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2408, "? mm (?in)", "Yaesu/ft3900.jpg", "FT-3900", "Hi: 25 W, Lo: 5 W", 77, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2409, "62*100*33 mm (2.44*3.94*1.28in), with SBR-14Li", "Yaesu/ft3de.jpg", "FT-3DE", @"HighLow 3Low 2Low 1
2 m:5 W2.5 W1 W300 mW
70 cm:5 W2.5 W1 W300 mW


NB! Output power above is with Li-Ion battery or external DC.
With FBA-39 dry cell battery tray, the output power is below 1 W.", 77, "282 g (9.95 oz), with SBR-14Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2410, "62*100*33 mm (2.44*3.94*1.28in), with SBR-14Li", "Yaesu/ft3d.jpg", "FT-3DR", @"HighLow 3Low 2Low 1
2 m:5 W2.5 W1 W300 mW
70 cm:5 W2.5 W1 W300 mW


NB! Output power above is with Li-Ion battery or external DC.
With FBA-39 dry cell battery tray, the output power is below 1 W.", 77, "282 g (9.95 oz), with SBR-14Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2411, "57*99*30 mm (2.24*3.9*1.18in), with FNB-40", "Yaesu/ft40r.jpg", "FT-40R", @"Hi: 2-5 W (depending on voltage)
L3: 2-2.5 W (depending on voltage)
L2: 1 W
L1: 100 mW", 77, "325 g (11.46 oz), with FNB-40" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2412, "229*84*217 mm (9*3.3*8.5in)", "Yaesu/ft410.jpg", "FT-410", @"AM: Max 25 W (carrier)
SSB/CW: Max 100 W", 77, "4 Kg (8.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2355, "61*168*49 mm (2.4*6.61*1.93in)", "Yaesu/ft208r.jpg", "FT-208R", "Hi: 2.5 W, Lo: 300 mW", 77, "720 g (1.59 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2433, "57*99*30 mm (2.24*3.9*1.18in).with FNB-40", "Yaesu/ft50r.jpg", "FT-50R", @"2 mHi: 5 W / Mid1: 2.8 W / Mid2: 1 W / Lo: 0.1 W (@ 9.6 VDC)


70 cmHi: 5 W / Mid1: 2.8 W / Mid2: 1 W / Lo: 0.1 W (@ 9.6 VDC)", 77, "355 gr (12.52 oz), with FNB-40" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2354, "68*181*54 mm (2.68*7.13*2.13in)", "Yaesu/ft207r.jpg", "FT-207R", "Hi: 2.5 W, Lo: 200 mW", 77, "680 g (23.99 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2352, "69*171*49 mm (2.72*6.73*1.93in)", "Yaesu/ft202r.jpg", "FT-202R", "1 W", 77, "400 gr (14.11 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2295, "370*150*290 mm (14.57*5.91*11.42in)", "Yaesu/fl101.jpg", "FL-101", @"AM: Max 40 W (input)
SSB: Max 130 W (PEP input)
CW: Max 90 W (input)", 77, "16 Kg (35.27 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2296, "334*153*262 mm (13.15*6.02*10.31in)", "Yaesu/fl50.jpg", "FL-50", "Max 25 W (input)", 77, "10 Kg (22.05 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2297, "? mm", "Yaesu/fl50b.jpg", "FL-50B", "Max 75 W (input)", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2298, "? mm", "Yaesu/fldx400.jpg", "FLdx-400", "Max 100 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2299, "? mm (?in)", "Yaesu/fr100b.jpg", "FR-100B", "", 77, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2300, "340*153*285 mm (13.4*6*11.2in)", "Yaesu/fr101.jpg", "FR-101", "", 77, "9 Kg (19.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2301, "340*153*285 mm (13.4*6*11.2in)", "Yaesu/fr101d.jpg", "FR-101D", "", 77, "9 Kg (19.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2294, "381*178*298 mm (15*7*11.75in)", "Yaesu/fl100b.jpg", "FL-100B", "120 W (PEP input)", 77, "15.9 Kg (35 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2302, "? mm", "Yaesu/fr101s.jpg", "FR-101S", "", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2304, "? mm", "Yaesu/fr50b.jpg", "FR-50B", "", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2305, "368*165*292 mm (14.5*6.5*11.5in)", "Yaesu/frdx400.jpg", "FRdx-400", "", 77, "11.34 Kg (25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2306, "? mm", "Yaesu/frdx500.jpg", "FRdx-500", "", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2307, "238*93*243 mm (9.37*3.66*9.57in)", "Yaesu/frg100.jpg", "FRG-100", "", 77, "3 Kg (6.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2308, "340*153*285 mm (13.4*6.02*11.22in)", "Yaesu/frg7.jpg", "FRG-7", "", 77, "7 Kg (15.43 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2309, "360*125*295 mm (14.2*4.92*11.6in)", "Yaesu/frg7000.jpg", "FRG-7000", "", 77, "7 Kg (15.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2310, "334*129*225 mm (13.15*5.08*8.86in)", "Yaesu/frg7700.jpg", "FRG-7700", "", 77, "6 Kg (13.23 lbs), without optional memory unit" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2303, "334*153*262 mm (13.15*6.02*10.31in)", "Yaesu/fr50.jpg", "FR-50", "", 77, "8 Kg (17.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2311, "334*118*225 mm (13.15*4.65*8.86in)", "Yaesu/frg8800.jpg", "FRG-8800", "", 77, "6.1 Kg (13.45 lbs), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2293, "180*72*270 mm (7.09*2.84*10.63in)", "Yaesu/cpu2500r.jpg", "CPU-2500R", "Hi: 25 W, Lo: 3 W", 77, "3.2 Kg (7.06 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2291, "97*40*155 mm (3.82*1.58*6.1in)", "Xiegu/xiegu_x1mpro.jpg", "X1M Pro (Platinum)", "Max 5 W", 76, "650 g (1.43 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2275, "? mm", "Winradio/winradio_wr1500i.jpg", "WR-1500i", "", 74, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2276, "? mm", "Winradio/winradio_wr3000i.jpg", "WR-3100i", "", 74, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2277, "290*115*? mm (11.42*4.53*?in)", "Winradio/winradio_wr3500idsp.jpg", "WR-3500i-DSP", "", 74, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2278, "96*41*164 mm (3.78*1.61*6.46in)", "Winradio/wrg313e.jpg", "WR-G313e", "", 74, "480 gr (16.93 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2279, "? mm", "WJ/wj_521a1.jpg", "Watkins-Johnson 521A-1", "", 75, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2280, "? mm", "WJ/8888.jpg", "Watkins-Johnson WJ-8888", "", 75, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2281, "483*133*495 mm (19.02*5.24*19.49in)", "WJ/wj8888a.jpg", "Watkins-Johnson WJ-8888A", "", 75, "18.1 Kg (39.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2292, "160*99*46 mm (6.3*3.9*1.8in)", "Xiegu/xiegu_x5105.jpg", "X5105", @"HF0.5-5 W (AM 1.5 W)


6 m0.5-5 W (AM 1.5 W)", 76, "940 g (2.07 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2282, "483*133*495 mm (19.02*5.24*19.49in)", "WJ/8888b.jpg", "Watkins-Johnson WJ-8888B", "", 75, "18.1 Kg (39.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2284, "483*133*508 mm (19*5.25*20in)", "WJ/wj_hf1000a.jpg", "Watkins-Johnson HF-1000A", "", 75, "6.8 Kg (15 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2285, "209*89*500 mm (8.25*3.5*20in)", "WJ/wj8615.jpg", "Watkins-Johnson WJ-8615", "", 75, "11.3 Kg (25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2286, "97*40*155 mm (3.82*1.58*6.1in)", "Xiegu/xiegu_g1m.jpg", "G1M \"G-Core\"", "Max 5 W", 76, "? g (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2287, "120*45*210 mm (4.72*1.77*8.27in), without handles", "Xiegu/xiegu_g90.jpg", "G90 \"G-Core\"", @"AM: 5 W (Carrier)
FM: 20 W (With optional GSOC controller)
SSB/CW: 20 W", 76, "1.63 Kg (3.59 lb), without handles" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2288, "120*45*180 mm (4.75*1.75*7.06in)", "Xiegu/xiegu_x108.jpg", "X108", "1-20 W", 76, "885 gr (1.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2289, "120*45*180 mm (4.75*1.75*7.06in)", "Xiegu/xiegu_x108g.jpg", "X108G", "1-20 W @ 13.8 VDC", 76, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2290, "97*40*155 mm (3.82*1.58*6.1in)", "Xiegu/xiegu_x1m.jpg", "X1M", "Max 5 W", 76, "650 gr (1.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2283, "? mm", "WJ/wj_906a6.jpg", "Watkins-Johnson 906A-6", "", 75, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2312, "180*80*220 mm (7.09*3.15*8.66in)", "Yaesu/frg9600.jpg", "FRG-9600", "", 77, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2313, "180*80*220 mm (7.09*3.15*8.66in)", "Yaesu/frg965.jpg", "FRG-965", "", 77, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2314, "160*54*205 mm (6.3*2.2*8in)", "Yaesu/ft100.jpg", "FT-100", @"HFMax 100 W (25 W AM)


6 mMax 100 W (25 W AM)


2 mMax 50 W (12.5 W AM)


70 cmMax 20 W (5 W AM)", 77, "3.0 Kg (6.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2336, "65*168*34 mm (2.56*6.61*1.34in)", "Yaesu/ft109rh.jpg", "FT-109RH", "Hi: 2-5 W (depending on voltage)Lo: 500 mW", 77, "616 gr (21.73 oz), with FNB-4" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2337, "57*99*30 mm (2.24*3.9*1.18in), with FNB-40", "Yaesu/ft10r.jpg", "FT-10R", @"Hi: 2-5 W (depending on voltage)
L3: 2-2.8 W (depending on voltage)
L2: 1 W
L1: 100 mW", 77, "325 g (11.46 oz), with FNB-40" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2338, "57*102*26 mm (2.24*4.02*1.02in), with FNB-31", "Yaesu/ft11r.jpg", "FT-11R", "Hi: 5 W, Lo: 0.3 W", 77, "280 gr (9.88 oz), with FNB-31" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2339, "? mm (?in)", "Yaesu/ft127.jpg", "FT-127", "10 W", 77, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2340, "180*60*220 mm (7.09*2.36*8.66in)", "Yaesu/ft127ra.jpg", "FT-127RA \"Memorizer\"", "Hi: 10 W, Lo: 1 W", 77, "2.7 Kg (5.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2341, "? mm", "Yaesu/ft1500m.jpg", "FT-1500M", "Hi: 50 WMid: 25 W, Lo2: 10 W, Lo: 5 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2342, "140*40*146 mm (5.51*1.58*5.75in)", "Yaesu/ft1802.jpg", "FT-1802E", "Hi: 50 WMid: 25 W, Lo2: 10 W, Lo: 5 W", 77, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2335, "334*129*? mm (13.2*15.1*?in)", "Yaesu/ft107sm.jpg", "FT-107SM", @"AM/FSK: Max 4 W
SSB/CW: Max 10 W", 77, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2343, "? mm", "Yaesu/ft1900.jpg", "FT-1900R", "Hi: 55 WMid: ? W, Lo2: ? W, Lo: ? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2345, "60*95*32.5 mm (2.4*3.7*1.28in)", "Yaesu/ft1d.jpg", "FT-1DR", @"2 mHi: 5 W (13.8 V)L3: 2.5 W (13.8 V)L2: 1 WL1: 100 mW


70 cmHi: 5 W (13.8 V)L3: 2.5 W (13.8 V)L2: 1 WL1: 100 mW", 77, "290 gr (10.23 oz), with FNB-102Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2346, "60*95*32.5 mm (2.4*3.7*1.28in)", "Yaesu/ft1xd.jpg", "FT-1XDE", @"2 mHi: 5 W (13.8 V)L3: 2.5 W (13.8 V)L2: 1 WL1: 100 mW


70 cmHi: 5 W (13.8 V)L3: 2.5 W (13.8 V)L2: 1 WL1: 100 mW", 77, "290 gr (10.23 oz), with SBR-14Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2347, "330*140*279 mm (13*5.5*11in)", "Yaesu/ft200.jpg", "FT-200", "SSB: Max 100 W", 77, "7.26 Kg (16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2348, "? mm", "Yaesu/ft2000.jpg", "FT-2000", "Max 100 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2349, "? mm", "Yaesu/ft2000.jpg", "FT-2000D", "Max 200 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2350, "? mm", "Yaesu/ft201.jpg", "FT-201", "? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2351, "? mm", "Yaesu/ft201s.jpg", "FT-201S", "100 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2344, "60*95*32.5 mm (2.4*3.7*1.28in)", "Yaesu/ft1d.jpg", "FT-1DE", @"2 mHi: 5 W (13.8 V)L3: 2.5 W (13.8 V)L2: 1 WL1: 100 mW


70 cmHi: 5 W (13.8 V)L3: 2.5 W (13.8 V)L2: 1 WL1: 100 mW", 77, "290 gr (10.23 oz), with FNB-102Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2334, "334*129*400 mm (13.2*15.1*15.8in)", "Yaesu/ft107m_warc_darkgray.jpg", "FT-107M", @"AM/FSK: Max 40 W
SSB/CW: Max 100 W", 77, "12.5 Kg (27.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2333, "? mm", "Yaesu/ft104.jpg", "FT-104", "Max 1 W", 77, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2332, "368*129*310 mm (14.5*5.08*12.2in)", "Yaesu/ft102.jpg", "FT-102", @"AM: Max ~40 W (max 80 W DC input), with optional AM/FM unit
FM: Max ~50 W (max 120 W DC input), with optional AM/FM unit
SSB/CW (1.8-25 MHz): Max ~100 W (max 240 W DC input)
SSB/CW (28-29.9 MHz): Max ~75 W (max 160 W DC input)
NB! The PA is very conservatively driven, and can produce significantlyhigher output power if properly peaked and tuned.", 77, "15 Kg (33.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2315, "? mm", "Yaesu/ft1000d.jpg", "FT-1000D", "FM/SSB/CW: 200 WAM: 50 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2316, "410*135*347 mm (16.14*5.32*13.66in)", "Yaesu/ft1000mp.jpg", "FT-1000MP", "AM: Max 25 W carrierFM/SSB/CW: Max: 100 W", 77, "15 Kg (33.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2317, "410*135*347 mm (16*5.3*13.7in)", "Yaesu/ft1000mpmarkv.jpg", "FT-1000MP Mark V", "FM/SSB/CW: 200 WAM: 50 W", 77, "14 Kg (31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2318, "410*135*347 mm (16.14*5.32*13.66in)", "Yaesu/ft1000mpmarkvfield.jpg", "FT-1000MP Mark V Field", "100 W", 77, "15 Kg (33.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2319, "160*54*205 mm (6.3*2.2*8in)", "Yaesu/ft100d.jpg", "FT-100D", @"HFMax 100 W (25 W AM)


6 mMax 100 W (25 W AM)


2 mMax 50 W (12.5 W AM)


70 cmMax 20 W (5 W AM)", 77, "3.0 Kg (6.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2320, "267*152*330 mm (10.5*6*13in)", "Yaesu/ft100older.jpg", "FT-100 (older)", "SSB: 120 W (PEP input)", 77, "13.61 Kg (30 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2321, "343*152*292 mm (13.5*6*11.5in)", "Yaesu/ft101.jpg", "FT-101", "SSB: 260 W (PEP input)CW: 180 W (input)AM: 80 W (input)", 77, "13.61 Kg (30 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2322, "? mm", "Yaesu/ft101b.jpg", "FT-101B", "SSB: 260 W (PEP input)CW: 180 W (input)AM: 80 W (input)", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2323, "334*148*284 mm (13.15*5.83*11.18in)", "Yaesu/ft101e.jpg", "FT-101E", @"AM: 80 W (input)
SSB: 260 W(PEP input)
CW: 180 W (input)", 77, "13.6 Kg (29.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2324, "? mm", "Yaesu/ft101ee.jpg", "FT-101EE", "100 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2325, "334*148*284 mm (13.15*5.83*11.18in)", "Yaesu/ft101fe.jpg", "FT-101FE", "AM: 80 W (input)SSB: 260 W(PEP input)CW: 180 W (input)", 77, "13.6 Kg (29.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2326, "334*148*284 mm (13.15*5.83*11.18in)", "Yaesu/ft101fx.jpg", "FT-101FX", "AM: 80 W (input)SSB: 260 W(PEP input)CW: 180 W (input)", 77, "13.6 Kg (29.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2327, "345*157*326 mm (13.58*6.18*12.83in)", "Yaesu/ft101z.jpg", "FT-101 (Mk0)", "SSB/CW: ~100 W (180 W DC input)", 77, "15 Kg (33.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2328, "345*157*326 mm (13.58*6.18*12.83in)", "Yaesu/ft101zd.jpg", "FT-101ZD (Mk0)", @"AM: ~25 W (50 W DC input)
SSB/CW: ~100 W (180 W DC input)", 77, "15 Kg (33.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2329, "345*157*326 mm (13.58*6.18*12.83in)", "Yaesu/ft101zdmk1.jpg", "FT-101ZD (Mk1)", @"AM: ~25 W (50 W DC input)
SSB/CW: ~100 W (180 W DC input)", 77, "15 Kg (33.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2330, "345*157*326 mm (13.58*6.18*12.83in)", "Yaesu/ft101zdmk2.jpg", "FT-101ZD (Mk2)", @"AM: ~25 W (50 W DC input)
SSB/CW: ~100 W (180 W DC input)", 77, "15 Kg (33.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2331, "345*157*326 mm (13.58*6.18*12.83in)", "Yaesu/ft101zdmk3.jpg", "FT-101ZD (Mk3)", @"AM: ~25 W (50 W DC input)
SSB/CW: ~100 W (180 W DC input)", 77, "15 Kg (33.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2353, "65*153*34 mm (2.56*6.02*1.34in)", "Yaesu/ft203r.jpg", "FT-203R", "2.5 W", 77, "450 gr (15.87 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2274, "? mm", "Winradio/winradio_wr1500e.jpg", "WR-1500e", "", 74, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2434, "140*40*155 mm", "Yaesu/ft5100.jpg", "FT-5100", "VHF Hi: 50 W, Lo: 5 WUHF Hi: 35 W, Lo: 5 W", 77, "1.0 Kg (2.2 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2436, "140*40*155 mm (5.51*1.58*6.1in)", "Yaesu/ft5200.jpg", "FT-5200", "Hi: 50/35 W, Lo: 5/5 W", 77, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2538, "365*115*312 mm (14.4*4.5*12.3in)", "Yaesu/ftdx1200.jpg", "FTdx-1200", "AM: 2-25 W / 2-25 W carrierFM/NFM/SSB/CW: 5-100 W / 5-100 W", 77, "9.5 Kg (20.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2539, "365*115*312 mm (14.37*4.53*12.28in)", "Yaesu/ftdx3000.jpg", "FTdx-3000", "5-100 / 5-100 W", 77, "10 Kg (22.05 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2540, "400*159*349 mm (15.75*6.26*13.74in)", "Yaesu/ftdx400.jpg", "FTdx-400", "SSB: 560 W (PEP input)CW: 500 W (input)AM: 125 W (input)", 77, "18.1 Kg (39.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2541, "400*159*349 mm (15.75*6.26*13.74in)", "Yaesu/ftdx401.jpg", "FTdx-401", "SSB: 560 W (PEP input)CW: 430 W (Input) W", 77, "18.1 Kg (39.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2542, "462*135*389 mm (18.19*5.32*15.31in)", "Yaesu/ftdx5000.jpg", "FTdx-5000", "10-200/10-200 W (AM: 5-50/5-50 W)", 77, "21 Kg (46.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2543, "462*135*389 mm (18.19*5.32*15.31in)", "Yaesu/ftdx5000d-mp.jpg", "FTdx-5000D", "10-200/10-200 W (AM: 5-50/5-50 W)", 77, "21 Kg (46.3 lbs), +2.5 Kg (5.51 lbs) for the SM-5000" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2544, "462*135*389 mm (18.19*5.32*15.31in)", "Yaesu/ftdx5000d-mp.jpg", "FTdx-5000MP", "10-200/10-200 W (AM: 5-50/5-50 W)", 77, "21 Kg (46.3 lbs), +2.5 Kg (5.51 lbs) for the SM-5000" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2537, "420*130*355 mm (16.6*5.1*12.7in)", "Yaesu/ftdx101mp.jpg", "FTdx-101MP", @"HFMax 200 W (AM 50 W)


6 mMax 200 W (AM 50 W)


4 mMax 200 W  (AM 50 W), Europe only", 77, "13.5 Kg (29.8 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2545, "? mm", "Yaesu/ftdx9000contest.jpg", "FTdx-9000 Contest", "Max 200 W (AM: 75 W)", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2547, "? mm", "Yaesu/ftdx9000mp.jpg", "FTdx-9000MP", "Max 400 W (AM: 100 W)", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2548, "Panel: 140*45*29 mm (5.5*1.77*1.14in)Main unit: 140*45*164 mm (5.5*1.77*6.46in)", "Yaesu/ftm100de.jpg", "FTM-100DE", @"2 mHi: 50 W, Mid: 20 W, Lo: 5 W


70 cmHi: 50 W, Mid: 20 W, Lo: 5 W", 77, "Total: 1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2549, "Panel: 140*45*29 mm (5.5*1.77*1.14in)Main unit: 140*45*164 mm (5.5*1.77*6.46in)", "Yaesu/ftm100dr.jpg", "FTM-100DR", @"2 mHi: 50 W, Mid: 20 W, Lo: 5 W


70 cmHi: 50 W, Mid: 20 W, Lo: 5 W", 77, "Total: 1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2550, "112*38*178 mm (4.41*1.5*7.01in)", "Yaesu/ftm10r.jpg", "FTM-10R", "Hi: 50/40 WMid: 20/20 W, Lo: 5/5 W", 77, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2551, "Transceiver: 139*42*132 mm (5.47*1.66*5.2in)Control head: 139*53*18 mm (5.47*2.09*0.7in)", "Yaesu/ftm300de.jpg", "FTM-300DE", @"2 mHi: 50 WMid: 25 W, Lo: 5 W


70 cmHi: 50 WMid: 25 W, Lo: 5 W", 77, "Total: 1.1 Kg (2.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2552, "Transceiver: 139*42*132 mm (5.47*1.66*5.2in)Control head: 139*53*18 mm (5.47*2.09*0.7in)", "Yaesu/ftm300dr.jpg", "FTM-300DR", @"2 mHi: 50 WMid: 25 W, Lo: 5 W


70 cmHi: 50 WMid: 25 W, Lo: 5 W", 77, "Total: 1.1 Kg (2.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2553, "154*43*155 mm (6.06*1.69*6.1in)", "Yaesu/ftm3200de.jpg", "FTM-3200DE", "Hi: 65 WMid: 30 W, Lo: 5 W", 77, "Total: 1.3 Kg (2.86 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2546, "? mm", "Yaesu/ftdx9000d.jpg", "FTdx-9000D", "Max 200 W (AM: 75 W), internal PSU versionMax 400 W (AM: 100 W), external PSU version", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2554, "154*43*155 mm (6.06*1.69*6.1in)", "Yaesu/ftm3200dr.jpg", "FTM-3200DR", "Hi: 65 WMid: 30 W, Lo: 5 W", 77, "Total: 1.3 Kg (2.86 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2536, "420*130*355 mm (16.6*5.1*12.7in)", "Yaesu/ftdx101d.jpg", "FTdx-101D", @"HFMax 100 W (AM 25 W)


6 mMax 100 W (AM 25 W)


4 mMax 100 W  (AM 25 W), Europe only", 77, "12 Kg (26.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2534, "266*91*263 mm (10.47*3.58*10.35in)", "Yaesu/ftdx10.jpg", "FTdx-10", @"HF5-100 W (AM: 5-25 W)


6 m5-100 W (AM: 5-25 W)", 77, "5.9 Kg (13 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2518, "342*154*324 mm (13.46*6.06*12.76in)", "Yaesu/ft901d.jpg", "FT-901D", @"AM/FM/FSK: Max ~40 W (max 80 W DC input)
SSB/CW: Max ~100 W (max 180 W DC input)", 77, "18 Kg (39.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2519, "342*154*324 mm (13.46*6.06*12.76in)", "Yaesu/ft901de.jpg", "FT-901DE", @"AM/FM/FSK: Max ~40 W (max 80 W DC input)
SSB/CW: Max ~100 W (max 180 W DC input)", 77, "18 Kg (39.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2520, "342*154*324 mm (13.46*6.06*12.76in)", "Yaesu/ft901dm.jpg", "FT-901DM", @"AM/FM/FSK: Max ~40 W (max 80 W DC input)
SSB/CW: Max ~100 W (max 180 W DC input)", 77, "18 Kg (39.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2521, "342*154*324 mm (13.46*6.06*12.76in)", "Yaesu/ft901sd.jpg", "FT-901SD", @"AM: Max ~3 W (max 5 W DC input)
FM/SSB/CW/FSK: Max ~10 W (max 20 W DC input)", 77, "18 Kg (39.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2522, "342*154*324 mm (13.46*6.06*12.76in)", "Yaesu/ft902d.jpg", "FT-902D", @"AM/FM/FSK: ~40 W (80 W DC input)
SSB/CW: ~100 W (180 W input)", 77, "18 Kg (39.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2523, "342*154*324 mm (13.46*6.06*12.76in)", "Yaesu/ft902dm.jpg", "FT-902DM", @"AM/FM/FSK: ~40 W (80 W DC input)
SSB/CW: ~100 W (180 W input)", 77, "18 Kg (39.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2524, "100*30*138 mm (3.94*1.18*5.43in)", "Yaesu/ft90r.jpg", "FT-90R", "Hi: 50/35 WMid1: 20/20 WMid2: 10/10 W, Lo: 5/5 W", 77, "640 gr (1.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2535, "? mm", "Yaesu/ftdx100.jpg", "FTdx-100", "75 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2525, "55*139*32 mm (2.16*5.47*1.26in), with FNB-10", "Yaesu/ft911.jpg", "FT-911", "Hi: 1 W, Lo: 100 mW", 77, "430 gr (15.17 oz), with FNB-10" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2527, "410*135*316 mm (16.14*5.32*12.44in)", "Yaesu/ft920.jpg", "FT-920", @"AM: Max 25 W carrier
SSB/CW: Max 100 W", 77, "11.5 Kg (25.35 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2528, "410*135*316 mm", "Yaesu/ft920af.jpg", "FT-920AF", "SSB/CW: Max 100 WAM: 25 W", 77, "11.5 Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2529, "365*115*315 mm (14.37*4.53*12.4in)", "Yaesu/ft950.jpg", "FT-950", @"10-160 m: 5-100 W (AM: 2-25 W)
50-54 MHz: 5-100 W (AM: 2-25 W)", 77, "9.8 Kg (21.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2530, "370*157*350 mm (14.57*6.18*13.78in)", "Yaesu/ft980.jpg", "FT-980", "SSB/CW: Max 100 WAM: Max 25 WFM: Max 50 W", 77, "17 Kg (37.48 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2531, "368*129*335 mm (14.49*5.08*13.19in)", "Yaesu/ft990.jpg", "FT-990", "AM: Max 25 WFM/SSB/CW: Max 100 W", 77, "13 Kg (28.66 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2532, "229*80*253 mm (9*3.2*10in)", "Yaesu/ft991.jpg", "FT-991", "HF + 6 m: 5-100 W (2-25 W AM)VHF/UHF: 2-50 W (1-12 W AM)", 77, "4.3 Kg (9.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2533, "229*80*253 mm (9*3.2*10in)", "Yaesu/ft991a.jpg", "FT-991A", @"HF + 6 m: 5-100 W (2-25 W AM)
VHF/UHF: 2-50 W (1-12 W AM)", 77, "4.3 Kg (9.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2526, "140*40*160 mm (5.51*1.58*6.3in)", "Yaesu/ft912r.jpg", "FT-912R", @"HighLow
23 cm:10 W1 W", 77, "1.25 Kg (2.76 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2555, "? mm", "Yaesu/ftm350.jpg", "FTM-350", "Hi: 50 / 50 W (20 / 20 W in Japan)Mid: 20 / 20 W, Lo: 5 / 5 W", 77, "2.1 Kg (4.63 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2556, "Transceiver: 140*40*125 mm (5.5*1.6*4.9in)Controller: 140*72*20 mm (5.5*2.8*0.8in)", "Yaesu/ftm400de.jpg", "FTM-400DE", "Hi: 50 WMid: 20 W, Lo: 5 W", 77, "Total: 1.2 Kg (2.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2557, "Transceiver: 140*40*125 mm (5.5*1.6*4.9in)Controller: 140*72*20 mm (5.5*2.8*0.8in)", "Yaesu/ftm400de.jpg", "FTM-400DR", "Hi: 50 WMid: 20 W, Lo: 5 W", 77, "Total: 1.2 Kg (2.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2579, "60*95*28 mm (2.36*3.74*1.1in)", "Yaesu/vx8g.jpg", "VX-8GE", "Hi: 5 / 5 W, Low3: 2.5 / 2.5 W, Low2: 1 / 1 W, Low1: 20 / 20 mW", 77, "250 gr (8.82 oz), with standard battery pack and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2580, "60*95*23 mm (2.36*3.74*0.9in)", "Yaesu/vx8r.jpg", "VX-8R", "Hi: 5 / 5 / 1.5 / 5 W, Low3: ? / ? / ? / ? W, Low2: ? / ? / ? / ? W, Low1: ? / ? / ? / ? mW", 77, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2581, "67*175*40 mm (2.64*6.89*1.58in)", "Yupiteru/mvt3000.jpg", "MVT-3000", "", 78, "? g (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2582, "59*152*32 mm (2.32*5.98*1.26in)", "Yupiteru/mvt3300.jpg", "MVT-3300", "", 78, "310 gr (10.93 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2583, "? mm (?in)", "Yupiteru/mvt4000.jpg", "MVT-4000", "", 78, "? g (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2584, "? mm", "Yupiteru/mvt5000.jpg", "MVT-5000", "", 78, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2585, "160*45*155 mm (6.3*1.77*6.1in)", "Yupiteru/mvt6000.jpg", "MVT-6000", "", 78, "650 g (1.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2578, "60*95*23 mm (2.36*3.74*0.9in)", "Yaesu/vx8.jpg", "VX-8E", "Hi: 5 / 5 / 5 W, Low3: 2.5 / 2.5 / 2.5 W, Low2: 1 / 1 / 1 / 1 W, Low1: 50 / 50 / 50 mW", 77, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2586, "70*180*40 mm (2.76*7.09*1.58in)", "Yupiteru/mvt7000.jpg", "MVT-7000", "", 78, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2588, "64*155*38 mm (2.52*6.1*1.5in)", "Yupiteru/mvt7100.jpg", "MVT-7100", "", 78, "320 g (11.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2589, "64*155*38 mm (2.52*6.1*1.5in)", "Yupiteru/mvt7200.jpg", "MVT-7200", "", 78, "320 g (11.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2590, "60*120*32 mm (2.36*4.72*1.26in)", "Yupiteru/mvt7300eu.jpg", "MVT-7300EU", "", 78, "310 g (10.93 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2591, "160*45*155 mm (6.3*1.77*6.1in)", "Yupiteru/mvt8000.jpg", "MVT-8000", "", 78, "650 g (1.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2592, "66*155*40 mm (2.6*6.1*1.58in)", "Yupiteru/mvt9000.jpg", "MVT-9000", "", 78, "410 g (14.46 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2593, "66*155*40 mm (2.6*6.1*1.58in)", "Yupiteru/mvt9000mkii.jpg", "MVT-9000MKII", "", 78, "410 g (14.46 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2594, "72*127*36 mm (2.84*5*1.42in)", "Yupiteru/vt125.jpg", "VT-125", "", 78, "207 g (7.3 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2587, "70*180*40 mm (2.76*7.09*1.58in)", "Yupiteru/mvt7000ex.jpg", "MVT-7000EX (Extended coverage)", "", 78, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2577, "60*95*24 mm (2.36*3.74*0.94in)", "Yaesu/vx8d.jpg", "VX-8DE", "Hi: 5 / 5 / 5 W, Low3: 2.5 / 2.5 / 2.5 W, Low2: 1 / 1 / 1 / 1 W, Low1: 50 / 50 / 50 mW", 77, "240 gr (8.47 oz), with standard battery pack and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2576, "60*90*28 mm (2.36*3.54*1.1in)", "Yaesu/vx7rs.jpg", "VX-7R", @"6 m1 W


2 m/70 cmHi: 5 W, Low3: 2.5 W, Low2: 1 W, Low1: 500 mW


220 MHz300 mW (USA only)", 77, "250 gr (8.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2575, "58*89*29 mm (2.28*3.5*1.14in)", "Yaesu/vx6r.jpg", "VX-6R", @"2 mHi: 5 W, Low3: 2.5 W, Low2: 1 W, Low1: 300 mW


70 cmHi: 5 W, Low3: 2.5 W, Low2: 1 W, Low1: 300 mW


220 MHzHi: 1.5 W, Low3: 1 W, Low2: 500 mW, Low1: 200 mW", 77, "270 gr (9.5 oz), with FNB-80LI" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2558, "Transceiver: 140*40*125 mm (5.5*1.6*4.9in)Controller: 140*72*20 mm (5.5*2.8*0.8in)", "Yaesu/ftm400de.jpg", "FTM-400XDE", "Hi: 50 WMid: 20 W, Lo: 5 W", 77, "Total: 1.2 Kg (2.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2559, "Transceiver: 140*40*125 mm (5.5*1.6*4.9in)Controller: 140*72*20 mm (5.5*2.8*0.8in)", "Yaesu/ftm400de.jpg", "FTM-400XDR", "Hi: 50 WMid: 20 W, Lo: 5 W", 77, "Total: 1.2 Kg (2.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2560, "370*157*350 mm (14.57*6.18*13.78in)", "Yaesu/ftone.jpg", "FT-One", "AM: 25 WFM/FSK: 50 WSSB/CW: 90-100 W (PEP)", 77, "17 Kg (37.48 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2561, "220*80*230 mm (8.66*3.15*9.06in)", "Yaesu/sigmasizer200r.jpg", "Sigmasizer 200R", "Hi: 10 W, Lo: 1 W", 77, "3.0 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2562, "59*85*26 mm (2.32*3.35*1.02in)", "Yaesu/vr120.jpg", "VR-120", "", 77, "195 gr (6.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2563, "59*85*26 mm (2.32*3.35*1.02in)", "Yaesu/vr120d.jpg", "VR-120D", "", 77, "195 gr (6.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2564, "58*95*24 mm (2.28*3.74*0.94in)", "Yaesu/vr500.jpg", "VR-500", "", 77, "220 gr (7.76 oz), with antenna and battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2565, "180*70*203 mm (7.1*2.8*8in)", "Yaesu/vr5000.jpg", "VR-5000", "", 77, "1.9 Kg (4.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2566, "58*108*26 mm (2.28*4.25*1.02in)", "Yaesu/vx110.jpg", "VX-110", @"Hi: 5 W
Mid: 2 W, Lo: 0.5 W", 77, "325 g (11.46 oz), with FNB-64 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2567, "60*120*32 mm (2.36*4.72*1.26in)", "Yaesu/vx120.jpg", "VX-120", @"Hi: 5 W
Mid: 2 W, Lo: 0.5 W", 77, "390 g (13.8 oz), with FNB-83, antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2568, "58*108*26 mm (2.28*4.25*1.02in)", "Yaesu/vx150.jpg", "VX-150", @"Hi: 5 W
Mid: 2 W, Lo: 0.5 W", 77, "325 g (11.46 oz), with FNB-64 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2569, "60*120*32 mm (2.36*4.72*1.26in)", "Yaesu/vx170.jpg", "VX-170", @"Hi: 5 W
Mid: 2 W, Lo: 0.5 W", 77, "390 g (13.8 oz), with FNB-83, antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2570, "47*81*25 mm (1.85*3.19*0.98in)", "Yaesu/vx1r.jpg", "VX-1R", @"2 mHi: 500 mW @ 3.6 VDC (1 W @ 6 VDC external power)Lo: 50 mW @ 3.6 VDC (200 mW @ 6 VDC external power)


70 cmHi: 500 mW @ 3.6 VDC (1 W @ 6 VDC external power)Lo: 50 mW @ 3.6 VDC (200 mW @ 6 VDC external power)", 77, "133 gr (4.7 oz), with antenna and battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2571, "47*81*23 mm (1.85*3.19*0.9in)", "Yaesu/vx2.jpg", "VX-2R", "1.5-3 / 1-2 W", 77, "182 gr (6.42 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2572, "? mm", "Yaesu/vx3.jpg", "VX-3R", "Hi: 1.5 / 1 W, Lo: ? / ? mW", 77, "? gr (with battery and antenna)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2573, "58*88*27 mm (2.28*3.46*1.06in)", "Yaesu/vx5r.jpg", "VX-5R", "Hi: 5/5/4.5 W, Low3: 2.5/2.5/2.5 W, Low2: 1/1/1 W, Low1: 0.3/0.3/0.3 W", 77, "255 gr (9 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2574, "58*89*29 mm (2.28*3.5*1.14in)", "Yaesu/vx6r.jpg", "VX-6E", @"2 mHi: 5 W, Low3: 2.5 W, Low2: 1 W, Low1: 300 mW


70 cmHi: 5 W, Low3: 2.5 W, Low2: 1 W, Low1: 300 mW", 77, "270 gr (9.5 oz), with FNB-80LI" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2517, "238*93*253 mm (9.37*3.66*9.96in)", "Yaesu/ft900.jpg", "FT-900", @"AM: Max 25 W
SSB/CW: Max 100 W", 77, "5.3 Kg (11.68 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2435, "57*123*27 mm (2.24*4.84*1.06in), with FNB-31", "Yaesu/ft51r.jpg", "FT-51R", "20 mW-5 W", 77, "330 gr (11.64 oz), with FNB-31 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2516, "200*80*262 mm (7.87*3.15*10.31in)", "Yaesu/ft897d.jpg", "FT-897D", "FM/SSB/CW: 100/100/50/20 WAM: 25/25/12.5/5 W", 77, "3.9 Kg (8.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2514, "155*52*218 mm (6.1*2*8.6in)", "Yaesu/ft891.jpg", "FT-891", @"AM: 40 W carrier
FM/SSB/CW: Max 100 W", 77, "1.9 Kg (4.18 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2457, "150*57*194 mm (5.91*2.24*7.64in), with battery case or FL-6020", "Yaesu/ft690rii.jpg", "FT-690R II", "Max 2.5 W (10 W with optional FL-6020)", 77, "1.2 Kg (2.65 lb), without battery case2.1 Kg (4.63 lb), with optional FL-6020)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2458, "230*80*290 mm (9.06*3.15*11.42in)", "Yaesu/ft7.jpg", "FT-7", "10 W", 77, "5 Kg (11.02 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2459, "? mm", "Yaesu/ft703r.jpg", "FT-703R", "? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2460, "240*93*295 mm (9.45*3.66*11.61in)", "Yaesu/ft707.jpg", "FT-707 \"Wayfarer\"", "Max 100 W (50 W on AM)", 77, "6.5 Kg (14.33 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2461, "240*93*270 mm (9.45*3.66*10.63in)", "Yaesu/ft707s.jpg", "FT-707S", "Max 10 W (5 W on AM)", 77, "5.8 Kg (12.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2462, "61*168*49 mm (2.4*6.61*1.93in)", "Yaesu/ft708r.jpg", "FT-708R", "Hi: 1 W, Lo: 200 mW", 77, "720 g (1.59 lbs), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2463, "? mm", "Yaesu/ft709r.jpg", "FT-709R", "Hi: ? W, Lo: ? mW", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2456, "150*58*195 mm (5.91*2.28*7.68in)", "Yaesu/ft690r.jpg", "FT-690R", "2.5 W", 77, "1.3 Kg (2.87 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2464, "60*98*33 mm (2.36*3.86*1.3in)", "Yaesu/ft70d.jpg", "FT-70DE", @"2 mHi: 5 W, Mid: 2 W, Lo: 200 mW


70 cmHi: 5 W, Mid: 2 W, Lo: 200 mW", 77, "255 gr (8.99 oz), with SBR-24LI battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2466, "140*38*166 mm (5.51*1.5*6.54in)", "Yaesu/ft7100m.jpg", "FT-7100M", "Hi: 50/35 WMid1: 20/20 WMid2: 10/10 W, Lo: 5/5 W", 77, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2467, "160*50*175 mm (6.3*1.97*6.89in)", "Yaesu/ft711rh.jpg", "FT-711RH", "Hi: 35 W, Lo: 4 W", 77, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2468, "? mm", "Yaesu/ft712rh.jpg", "FT-712RH", "Hi: 35 W, Lo: ? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2469, "140*40*160 mm (5.51*1.58*6.3in)", "Yaesu/ft715.jpg", "FT-715H", "Hi: 35 WMid: 20 W, Lo: 5 W", 77, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2470, "140*40*160 mm (5.51*1.58*6.3in)", "Yaesu/ft7200.jpg", "FT-7200", "Hi: 35 WMid: 20 W, Lo: 5 W", 77, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2471, "Control head: ? mm (?in)", "Yaesu/ft720r.jpg", "FT-720R", @"2 m10 W (720RV deck)25 W (720RVH deck)


70 cm10 W (720RU deck)", 77, "Control head: ? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2472, "334*129*315 mm (13.15*5.08*12.4in)", "Yaesu/ft726r.jpg", "FT-726R", "Max 10 W", 77, "11 Kg (24.25 lbs), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2465, "60*98*33 mm (2.36*3.86*1.3in)", "Yaesu/ft70d.jpg", "FT-70DR", @"2 mHi: 5 W, Mid: 2 W, Lo: 200 mW


70 cmHi: 5 W, Mid: 2 W, Lo: 200 mW", 77, "255 gr (8.99 oz), with SBR-24LI battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2473, "71*200*38 mm (2.8*7.87*1.5in), with FNB-4A", "Yaesu/ft727r.jpg", "FT-727R", @"2 mHi: 2-5 W (Depending on voltage)Lo: 500 mW


70 cmHi: 2-5 W (Depending on voltage)Lo: 500 mW", 77, "616 g (21.73 oz), with FNB-4A" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2455, "180*60*240 mm (7.09*2.36*9.45in)", "Yaesu/ft680r.jpg", "FT-680R", "10 W (AM: 5 W)", 77, "2.9 Kg (6.39 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2453, "52*104*31 mm (2.1*4.1*1.2in)", "Yaesu/ft65.jpg", "FT-65E", @"2 mHi: 5 W, Mid: 2.5 W, Lo: 500 mW


70 cmHi: 5 W, Mid: 2.5 W, Lo: 500 mW", 77, "260 gr (9.17 oz), with SBR-25Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2437, "55*134*33 mm (2.16*5.28*1.3in), with FBA-12", "Yaesu/ft530.jpg", "FT-530", "Hi: 5/5 W, Lo: ?/? mW", 77, "530 gr (18.7 oz), with FNB-27 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2438, "140*40*155 mm (5.5*1.6*6.1in)", "Yaesu/ft5800.jpg", "FT-5800H", "Hi: 35 / 10 W, Lo: 5 / 1 W", 77, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2439, "140*40*155 mm (5.5*1.6*6.1in)", "Yaesu/ft5800.jpg", "FT-5800M", "Hi: 25 / 10 W, Lo: 3 / 1 W", 77, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2440, "65*100*34 mm (2.44*3.94*1.34in), with SBR-14Li", "Yaesu/ft5de.jpg", "FT-5DE", @"HighLow 3Low 2Low 1
2 m:5 W2.5 W1 W300 mW
70 cm:5 W2.5 W1 W300 mW


NB! Output power above is with Li-Ion battery or external DC.
With FBA-39 dry cell battery tray, the output power is below 1 W.", 77, "282 g (9.95 oz), with SBR-14Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2441, "65*100*34 mm (2.44*3.94*1.34in), with SBR-14Li", "Yaesu/ft5dr.jpg", "FT-5DR", @"HighLow 3Low 2Low 1
2 m:5 W2.5 W1 W300 mW
70 cm:5 W2.5 W1 W300 mW


NB! Output power above is with Li-Ion battery or external DC.
With FBA-39 dry cell battery tray, the output power is below 1 W.", 77, "282 g (9.95 oz), with SBR-14Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2442, "? mm", "Yaesu/ft600.jpg", "FT-600", "100 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2443, "58*109*30 mm (2.28*4.29*1.18in)", "Yaesu/ft60r.jpg", "FT-60R", @"2 mHi: 5 W, Mid: 2 W, Lo: 0.5 W


70 cmHi: 5 W, Mid: 2 W, Lo: 0.5 W", 77, "370 g (13.05 oz), with FNB-83 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2454, "52*104*31 mm (2.1*4.1*1.2in)", "Yaesu/ft65.jpg", "FT-65R", @"2 mHi: 5 W, Mid: 2.5 W, Lo: 500 mW


70 cmHi: 5 W, Mid: 2.5 W, Lo: 500 mW", 77, "260 gr (9.17 oz), with SBR-25Li and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2444, "? mm (?in)", "Yaesu/ft620.jpg", "FT-620", @"AM: ? W
SSB: ? W PEP
CW: ? W", 77, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2446, "280*125*295 mm (11*4.92*11.61in)", "Yaesu/ft620b.jpg", "FT-620B", @"AM: ~4 W (8 W input)
SSB: ~10 W (20 W input)
CW: ~10 W (20 W input)", 77, "8 Kg (17.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2447, "280*125*300 mm (11.02*4.92*11.81in)", "Yaesu/ft625r.jpg", "FT-625R", @"AM: Max 8 W
FM: Max 25 W
SSB: Max 25 W
CW: Max 25 W", 77, "9 Kg (19.84 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2448, "280*125*300 mm (11.02*4.92*11.81in)", "Yaesu/ft625rd.jpg", "FT-625RD", @"AM: Max 8 W
FM: Max 25 W
SSB: Max 25 W
CW: Max 25 W", 77, "9 Kg (19.84 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2449, "180*60*220 mm (7.09*2.36*8.66in)", "Yaesu/ft627ra.jpg", "FT-627RA \"Memorizer\"", "Hi: 10 W, Lo: 1 W", 77, "2.7 Kg (5.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2450, "? mm", "Yaesu/ft650.jpg", "FT-650", "100 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2451, "? mm", "Yaesu/ft655.jpg", "FT-655", "100 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2452, "? mm", "Yaesu/ft655s.jpg", "FT-655S", "? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2445, "140*40*155 mm (5.51*1.58*6.1in)", "Yaesu/ft6200.jpg", "FT-6200", "Hi: 35/10 W, Lo: 5/1 W", 77, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2474, "150*50*174 mm (5.91*1.97*6.85in)", "Yaesu/ft730r.jpg", "FT-730R", "Hi: 10 W, Lo: 1 W", 77, "1.5 Kg (3.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2475, "368*129*286 mm (14.5*5.08*11.26in)", "Yaesu/ft736mx.jpg", "FT-736MX", @"2 mMax 25 W


70 cmMax 25 W", 77, "9 Kg (19.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2476, "368*129*286 mm (14.5*5.08*11.26in)", "Yaesu/ft736r.jpg", "FT-736R", @"MaxBand unit
2 m:25 WBuilt-in
70 cm:25 WBuilt-in

      

6 m:10 WFEX-736-50
1.25 m:25 WFEX-736-220
23 cm:10 WFEX-736-1.2", 77, "9 Kg (19.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2498, "? mm", "Yaesu/ft8100.jpg", "FT-8100", "Hi: 20/20 WMid: 10/10 W, Lo: 1/1 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2499, "140*40*165 mm (5.51*1.58*6.5in)", "Yaesu/ft8100r.jpg", "FT-8100R", "Hi: 50/35 WMid: 20/20 W, Lo: 5/5 W", 77, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2500, "55*139*32 mm (2.16*5.47*1.26in), with FNB-10", "Yaesu/ft811.jpg", "FT-811", "Hi: 1-5 W (Depending on voltage)Lo: 0.5 W", 77, "430 g (15.17 oz), with FNB-10" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2501, "55*146*33 mm (2.16*5.75*1.3in), with FNB-27", "Yaesu/ft815.jpg", "FT-815", "Hi: 5 W, Lo3: 3 W, Lo2: 1.5 W, Lo1: 0.5 W", 77, "430 g (15.17 oz), with FNB-27" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2502, "55*146*33 mm (2.16*5.75*1.3in), with FNB-27", "Yaesu/ft816.jpg", "FT-816", "Hi: 5 W, Lo3: 3 W, Lo2: 1.5Lo1: 0.5 W", 77, "430 g (15.17 oz), with FNB-27" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2503, "135*38*165 mm (5.32*1.5*6.5in)", "Yaesu/ft817.jpg", "FT-817", @"Hi: 5 W (SSB/CW/FM) and 1.5 W (AM) @ 13.8 V external DC
Hi: 2.5 W (SSB/CW/FM) and 0.7 W (AM) @ 9.6 V internal DC
Low3: 2.5 W (SSB/CW/FM)
Low2: 1 W (SSB/CW/FM)
Low1: 500 mW (SSB/CW/FM)", 77, "1.17 Kg (2.58 lbs), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2504, "135*38*165 mm (5.32*1.5*6.5in)", "Yaesu/ft817nd.jpg", "FT-817ND (New Deluxe)", @"Hi: 5 W (SSB/CW/FM) and 1.5 W (AM) @ 13.8 V external DC
Hi: 2.5 W (SSB/CW/FM) and 0.7 W (AM) @ 9.6 V internal DC
Low3: 2.5 W (SSB/CW/FM)
Low2: 1 W (SSB/CW/FM)
Low1: 500 mW (SSB/CW/FM)", 77, "1.17 Kg (2.58 lbs), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2497, "140*40*153 mm (5.51*1.58*6.02in)", "Yaesu/ft8000r.jpg", "FT-8000R", @"2 mHi: 50 W, Mid: 10 W, Lo: 5 W


70 cmHi: 35 W, Mid: 10 W, Lo: 5 W", 77, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2505, "135*38*165 mm (5.32*1.5*6.5in)", "Yaesu/ft818.jpg", "FT-818ND", "Max 6 W (SSB/CW/FM) and 2 W (AM) @ 13.8 V DCMax ? W (SSB/CW/FM) and ? W (AM) @ 9.6 V DC", 77, "1.17 Kg (2.58 lbs), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2507, "260*86*270 mm (10.24*3.39*10.63in)", "Yaesu/ft847.jpg", "FT-847", @"HFFM/SSB/CW: Max 100 W. AM: Max 25 W (Carrier)


6 mFM/SSB/CW: Max 100 W. AM: Max 25 W (Carrier)


2 mFM/SSB/CW: Max 50 W. AM: Max 12.5 W (Carrier)


70 cmFM/SSB/CW: Max 50 W. AM: Max 12.5 W (Carrier)", 77, "7 Kg (15.43 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2508, "140*40*160 mm (5.51*1.57*6.3in)", "Yaesu/ft8500.jpg", "FT-8500", @"2 mHi: 50 W, Mid: 10 W, Lo: 5 W


70 cmHi: 35 W, Mid: 10 W, Lo: 5 W", 77, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2509, "155*52*233 mm (6.1*2.05*9.17in)", "Yaesu/ft857.jpg", "FT-857", "6-160 m: 100 W2 m: 50 W70 cm: 20 W", 77, "2.1 Kg (4.63 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2510, "155*52*233 mm (6.1*2.05*9.17in)", "Yaesu/ft857d.jpg", "FT-857D", "6-160 m: 100 W2 m: 50 W70 cm: 20 W", 77, "2.1 Kg (4.63 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2511, "140*42*168 mm (5.51*1.65*6.61in)", "Yaesu/ft8800r.jpg", "FT-8800R", @"2 mHi: 50 W, Mid: 20 W, Lo2: 10 W, Lo1:5 W


70 cmHi: 35 W, Mid: 20 W, Lo2: 10 W, Lo1:5 W", 77, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2512, "334*93*243 mm (13.15*3.66*9.57in)", "Yaesu/ft890.jpg", "FT-890", "? W", 77, "5.6 Kg (12.35 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2513, "140*42*168 mm (5.51*1.65*6.61in)", "Yaesu/ft8900r.jpg", "FT-8900R", @"HighMid 1Mid 2Low
10 m:50 W20 W10 W5 W
6 m:50 W20 W10 W5 W
2 m:50 W20 W10 W5 W
70 cm:35 W20 W10 W5 W", 77, "1 Kg (2.2 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2506, "238*93*243 mm (9.37*3.66*9.57in)", "Yaesu/ft840.jpg", "FT-840", @"AM: Max 25 W
FM: Max 100 W (with optional FM-747)
SSB/CW: Max 100 W", 77, "4.5 Kg (9.92 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2496, "230*80*320 mm (9.06*3.15*12.6in)", "Yaesu/ft7b.jpg", "FT-7B", "AM: 12 WSSB/CW: 50 W", 77, "5.5 Kg (12.13 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2495, "? mm", "Yaesu/ft790rii.jpg", "FT-790R II", "2.5 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2494, "150*58*195 mm (5.91*2.28*7.68in)", "Yaesu/ft790r.jpg", "FT-790R", "Hi: 1 W, Lo: 200 mW", 77, "1.3 Kg (2.87 lb), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2477, "? mm", "Yaesu/ft73r.jpg", "FT-73R", "Hi: Max 5 W, Lo: ? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2478, "? mm", "Yaesu/ft7400h.jpg", "FT-7400H", "Hi: 35 WMid: 15 W, Lo: 5 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2479, "238*93*238 mm (9.37*3.66*9.37in)", "Yaesu/ft747gx.jpg", "FT-747GX", "Max 100 W (AM 25 W)", 77, "3.3 Kg (7.28 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2480, "238*93*238 mm (9.37*3.66*9.37in)", "Yaesu/ft747sx.jpg", "FT-747SX", "Max 10 W (AM 2.5 W)", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2481, "210*80*300 mm (8.27*3.15*11.81in)", "Yaesu/ft75.jpg", "FT-75", @"SSB: 20 W PEP
CW: 20 W DC", 77, "3.8 Kg (8.38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2482, "238*93*238 mm (9.4*3.7*9.4in)", "Yaesu/ft757gx.jpg", "- FT-757GX", "FM/SSB/CW: 100 W (slightly less on 10 m)AM: 25 W", 77, "5.2 Kg (11.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2483, "238*93*238 mm (9.4*3.7*9.4in)", "Yaesu/ft757gxii.jpg", "FT-757GX II", @"AM: Max 25 W (carrier)
FM/SSB/CW: Max 100 W (slightly less on 10 m)", 77, "5.2 Kg (11.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2484, "210*80*300 mm (8.27*3.15*11.81in)", "Yaesu/ft75b.jpg", "FT-75B", @"SSB: Max >60 W PEP (100 W PEP input)
CW: Max >50 W DC (100 W DC input)", 77, "3.8 Kg (8.38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2485, "? mm", "Yaesu/ft76.jpg", "FT-76", "Hi: Max 5 W, Lo: ? W", 77, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2486, "368*129*295 mm (14.5*5.08*11.61in)", "Yaesu/ft767gx.jpg", "FT-767GX", @"AM: Max 25 W carrier
FM/SSB/CW/AFSK: Max 100 W", 77, "13.5 Kg (30 lbs), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2487, "240*95*300 mm (9.45*3.74*11.81in)", "Yaesu/ft77.jpg", "FT-77", @"SSB/CW: 100 W (85 W on 10 m)
FM: 50 W (woth FM option)", 77, "6 Kg (13.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2488, "?*?*162 mm (?*?*6.38in)", "Yaesu/ft770rh.jpg", "FT-770RH", "Hi: 25 W, Lo: ? W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2489, "140*42*168 mm (5.51*1.65*6.61in)", "Yaesu/ft7800h.jpg", "FT-7800R(E)", "Hi: 50/40 WMid1: 20/20 WMid2: 10/10 W, Lo: 5/5 W", 77, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2490, "? mm", "Yaesu/ft7800_older.jpg", "FT-7800 (Older)", "Hi: ?/?/10 W, Lo: ?/?/1 W", 77, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2491, "180*60*250 mm (7.09*2.36*9.84in)", "Yaesu/ft780r.jpg", "FT-780R", @"FM/CW, Hi: 10 W, Lo: 1 W
SSB: 30 W (PEP input)", 77, "3.0 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2492, "140*42*168 mm (5.51*1.65*6.61in)", "Yaesu/ft7900e.jpg", "FT-7900E", @"2 mHi: 50 W, Mid: 20 W, Mid2: 10 W / Lo: 5 W


70 cmHi: 45 W, Mid: 20 W, MId2: 10 W / Lo: 5 W", 77, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2493, "140*42*168 mm (5.51*1.65*6.61in)", "Yaesu/ft7900.jpg", "FT-7900R", "Hi: 50/45 WMid1: 20/20 WMid2: 10/10 W, Lo: 5/5 W", 77, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2515, "200*80*262 mm (7.87*3.15*10.31in)", "Yaesu/ft897.jpg", "FT-897", "FM/SSB/CW: 100/100/50/20 WAM: 25/25/12.5/5 W", 77, "3.9 Kg (8.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2273, "? mm", "Winradio/winradio_wr1000i.jpg", "WR-1000i", "", 74, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2272, "? mm", "Winradio/winradio_wr1000e_a.jpg", "WR-1000e", "", 74, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2271, "180*45*135 mm (7.12*1.75*5.31in)", "Whistler/ws1098.jpg", "WS1098", "", 73, "950 gr (2.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2051, "452*310*208 mm (17.8*12.2*8.2in)", "Sony/sony_crf330k.jpg", "CRF-330K", "", 65, "13.15 Kg (29 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2052, "? mm", "Sony/sony_crf5100.jpg", "CRF-5100 \"Earth orbiter\"", "", 65, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2053, "412*285*169 mm (16.22*11.22*6.65in)", "Sony/sony_crfv21.jpg", "CRF-V21", "", 65, "9.5 Kg (20.94 lbs), with batterie)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2054, "325*173*56 mm (12.8*6.8*2.2in)", "Sony/sony_icf2001.jpg", "ICF-2001", "", 65, "1.81 Kg (4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2055, "290*160*50 mm (11.42*6.3*1.97in)", "Sony/sony_icf2001d.jpg", "ICF-2001D", "", 65, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2056, "291*171*111 mm (11.46*6.73*4.37in)", "Sony/sony_icf6500w.jpg", "ICF-6500W", "", 65, "1.9 Kg (4.19 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2057, "453*184*227 mm (17.83*7.24*8.94in)", "Sony/icf6700w.jpg", "ICF-6700W", "", 65, "5.4 Kg (11.9 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2050, "452*310*208 mm (17.8*12.2*8.2in)", "Sony/sony_crf320.jpg", "CRF-320", "", 65, "13.15 Kg (29 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2058, "457*190*235 mm (18*7.5*9.25in)", "Sony/icf6800w.jpg", "ICF-6800W", "", 65, "5.44 Kg (12 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2060, "180*120*35 mm (7.09*4.72*1.38in)", "Sony/sony_icf7600a.jpg", "ICF-7600A", "", 65, "640 gr (1.41 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2061, "180*120*35 mm (7.09*4.72*1.38in)", "Sony/sony_icf7600a.jpg", "ICF-7600AW", "", 65, "640 gr (1.41 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2062, "185*119*32 mm (7.28*4.68*1.26in)", "Sony/sony_icf7600d.jpg", "ICF-7600D", "", 65, "640 gr (1.41 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2063, "192*117*32 mm (7.56*4.61*1.26in)", "Sony/sony_icf7600da.jpg", "ICF-7600DA", "", 65, "610 gr (1.34 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2064, "180*120*35 mm (7.09*4.72*1.38in)", "Sony/sony_icf7600ds.jpg", "ICF-7600DS", "", 65, "650 gr (1.43 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2065, "180*120*35 mm (7.09*4.72*1.38in)", "Sony/sony_icf7600w.jpg", "ICF-7600W", "", 65, "640 gr (1.41 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2066, "185*118*33 mm (7.28*4.65*1.3in)", "Sony/sony_icf7601.jpg", "ICF-7601", "", 65, "600 gr (1.32 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2059, "180*120*35 mm (7.09*4.72*1.38in)", "Sony/sony_icf7600.jpg", "ICF-7600", "", 65, "640 gr (1.41 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2067, "136*95*70 + 257*95*41 mm (5.35*3.74*2.76in + 10.12*3.74*1.61in)", "Sony/sony_icf7800w.jpg", "ICF-7800W", "", 65, "780 gr (1.72 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2049, "? mm", "Sony/sony_crf160.jpg", "CRF-160", "", 65, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2047, "254*102*335 mm (10*4*13.2in)", "Sony/sony_crf1_b.jpg", "CRF-1", "", 65, "7.71 Kg (17 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2031, "? mm", "Sommerkamp/sk269r.jpg", "SK-269R", "Hi: 25 W, Lo: 5 W", 64, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2032, "? mm", "Sommerkamp/sk269rh.jpg", "SK-269RH", "Hi: 45 W, Lo: 5 W", 64, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2033, "180*80*220 mm (7.09*3.15*8.66in)", "Sommerkamp/srg8600dx.jpg", "SRG-8600DX", "", 64, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2034, "140*40*166 mm (5.51*1.58*6.54in)", "Sommerkamp/ts146dx.jpg", "TS-146DX", @"HighMidLow
2 m:50 W10 W5 W", 64, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2035, "140*40*166 mm (5.51*1.58*6.54in)", "Sommerkamp/ts147dx.jpg", "TS-147DX", "Hi: 50 WMid: 25 W, Lo: 7 W", 64, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2036, "? mm", "Sommerkamp/ts206at.jpg", "TS-206AT", "2 W", 64, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2037, "55*84*31 mm (2.16*3.31*1.22in)", "Sommerkamp/ts277dx.jpg", "TS-277DX", "Hi: 5 WMid: 2.5 W, Lo: 350 mW", 64, "185 gr (6.53 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2048, "? mm", "Sony/sony_crf150.jpg", "CRF-150", "", 65, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2038, "? mm", "Sommerkamp/ts280dx.jpg", "TS-280DX", "? W", 64, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2040, "156*58*290 mm (6.14*2.28*11.42in)", "Sommerkamp/ts280fmus.jpg", "TS-280FM (US version)", "Hi: 50 W (100% duty cycle!)Lo: 5 W", 64, "2.3 Kg (5.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2041, "340*153*285 mm (13.39*6.02*11.22in)", "Sommerkamp/ts288a24ch.jpg", "TS-288A/24CH", "AM: 80 W (input), 50% duty cycle (slightly lower on 10m)SSB: 260 W (PEP input)CW: 180 W (input)", 64, "15 Kg (33.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2042, "156*61*290 mm (6.14*2.4*11.42in)", "Sommerkamp/ts800.jpg", "TS-800", "Hi: 50 W, Lo: 5 W", 64, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2043, "457*190*235 mm (18*7.5*9.25in)", "Sony/icf6800.jpg", "ICF-6800", "", 65, "5.44 Kg (12 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2044, "264*149*63 mm (10.39*5.87*2.48in)", "Sony/icfex5.jpg", "ICF-EX5", "", 65, "1.05 Kg (2.32 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2045, "264*149*63 mm (10.39*5.87*2.48in)", "Sony/icfex5mk2.jpg", "ICF-EX5 MK2", "", 65, "1.05 Kg (2.32 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2046, "90*179*50 mm (3.54*7.05*1.97in)", "Sony/sony_air7.jpg", "Air-7", "", 65, "600 gr (1.32 lbs), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2039, "156*58*290 mm (6.14*2.28*11.42in)", "Sommerkamp/ts280fm.jpg", "TS-280FM", "Hi: 45 W (100% duty cycle!)Lo: 2 W", 64, "2.3 Kg (5.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2068, "90*182*50 mm (3.54*7.16*1.97in)", "Sony/sony_icfpro70.jpg", "ICF-Pro 70 (Hi Scan)", "", 65, "650 gr (1.43 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2069, "90*182*50 mm (3.54*7.16*1.97in)", "Sony/sony_icfpro80.jpg", "ICF-Pro 80", "", 65, "650 g (1.43 lbs), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2070, "? mm", "Sony/sony_icfsc1.jpg", "ICF-SC1 PC", "", 65, "255 gr (8.99 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2092, "55*?*31 mm (?in)", "Standard/c150e.jpg", "C-150E", @"Hi: 2-5 W (depending on voltage)
Lo: 300 mW", 66, "300 g (10.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2093, "? mm", "Standard/c156.jpg", "C-156", "? mW", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2094, "? mm", "Standard/c158a.jpg", "C-158A", "? mW", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2095, "? mm", "Standard/c168.jpg", "C-168", "? mW", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2096, "47*120*34 mm (1.85*4.72*1.34in)", "Standard/c170.jpg", "C-170", "? mW", 66, "320 gr (11.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2097, "? mm", "Standard/c178a.jpg", "C-178A", "Hi: ? W, Lo: ? W", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2098, "? mm", "Standard/c188.jpg", "C-188", "Hi: 5 WMid: ? W, Lo: ? mW", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2091, "? mm", "Standard/c1208.jpg", "C-1208", "Hi: ? WMid: ? W, Lo: ? W", 66, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2099, "58*122*27 mm (2.28*4.8*1.06in)", "Standard/c188s.jpg", "C-188S", @"Hi: 5 W
Mid: ? W, Lo: ? mW", 66, "300 g (10.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2101, "? mm", "Standard/c288a.jpg", "C-288A", "?/? W", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2102, "? mm (?in)", "Standard/c311.jpg", "C-311", "Hi: ? W, Lo: ? mW", 66, "? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2103, "58*80*25 mm (2.28*3.15*0.98in)", "Standard/c401.jpg", "C-401", "230 mW", 66, "130 gr (4.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2104, "53*110*33 mm (2.09*4.33*1.3in)", "Standard/c412.jpg", "C-412", "1 W", 66, "350 gr (12.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2105, "50*90*38 mm (1.97*3.54*1.5in)", "Standard/c415.jpg", "C-415", "? mW", 66, "260 gr (9.17 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2106, "? mm", "Standard/c468s.jpg", "C-468S", "? W", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2107, "47*120*34 mm (1.85*4.72*1.34in)", "Standard/c470.jpg", "C-470", "? mW", 66, "320 gr (11.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2100, "? mm", "Standard/c228a.jpg", "C-228A", "?/? W", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2090, "50*90*38 mm (1.97*3.54*1.5in)", "Standard/c116.jpg", "C-116", "? mW", 66, "260 gr (9.17 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2089, "50*90*38 mm (1.97*3.54*1.5in)", "Standard/c115.jpg", "C-115", "? mW", 66, "260 gr (9.17 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2088, "53*110*33 mm (2.09*4.33*1.3in)", "Standard/c112.jpg", "C-112", "? mW", 66, "350 gr (12.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2071, "135*33*91 mm (5.32*1.3*3.58in)", "Sony/sony_icfsw07.jpg", "ICF-SW07", "", 65, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2072, "168*106*35 mm (6.61*4.17*1.38in)", "Sony/icfsw35.jpg", "ICF-SW35", "", 65, "405 gr (14.3 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2073, "170*105*35 mm (6.69*4.13*1.38in)", "Sony/sony_icfsw40.jpg", "ICF-SW40", "", 65, "415 gr (14.64 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2074, "191*118*32 mm (7.52*4.65*1.26in)", "Sony/sony_icfsw7600.jpg", "ICF-SW7600", "", 65, "615 gr (1.36 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2075, "191*118*32 mm (7.52*4.64*1.26in)", "Sony/sony_icfsw7600g.jpg", "ICF-SW7600G", "", 65, "615 gr (21.69 oz), including batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2076, "190*119*35 mm (7.48*4.68*1.38in)", "Sony/sony_icfsw7600gr.jpg", "ICF-SW7600GR", "", 65, "608 g (1.34 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2077, "121*71*26 mm (4.75*2.8*1in)", "Sony/sony_icfsw1.jpg", "ICF-SW1", "", 65, "227 gr (8 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2078, "176*105*40 mm (6.93*4.13*1.58in)", "Sony/sony_sw1000.jpg", "ICF-SW1000T", "", 65, "240 gr (8.47 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2079, "111*24*73 mm (4.37*0.95*2.87in)", "Sony/sony_icfsw100.jpg", "ICF-SW100E / ICF-SW100S", "", 65, "220 gr (7.76 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2080, "194*127*39 mm (7.64*5*1.54in)", "Sony/sony_sw55e.jpg", "ICF-SW55E", "", 65, "850 gr (1.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2081, "290*160*50 mm (11.42*6.3*1.97in)", "Sony/sony_sw77.jpg", "ICF-SW77", "", 65, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2082, "? mm", "Sony/sony_tfm1600w.jpg", "TFM-1600W", "", 65, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2083, "58*97*24 mm (2.28*3.82*0.94in)", "Standard/ax400.jpg", "AX-400", "", 66, "200 gr (7.06 oz), with antenna and batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2084, "180*75*180 mm (7.09*2.95*7.09in)", "Standard/ax700b.jpg", "AX-700", "", 66, "2.1 Kg (4.63 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2085, "58*80*25 mm (2.28*3.15*0.98in)", "Standard/c101.jpg", "C-101", "? mW", 66, "130 gr (4.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2086, "58*80*25 mm (2.28*3.15*0.98in)", "Standard/c108.jpg", "C-108", "230 mW", 66, "130 g (4.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2087, "? mm", "Standard/c111.jpg", "C-111", "? mW", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2030, "156*58*216 mm (6.14*2.28*8.5in)", "Sommerkamp/ic2f.jpg", "IC-2F", ">10 W (20 W input)", 64, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2108, "? mm", "Standard/c4800.jpg", "C-4800", "Hi: 10 W, Lo: ? W", 66, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2029, "400*159*349 mm (15.75*6.25*13.75in)", "Sommerkamp/ftdx505.jpg", "FTdx-505", "SSB: Max 560 W (PEP input)CW: Max 500 W (input)", 64, "18.1 Kg (40 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2027, "? mm", "Sommerkamp/ft77.jpg", "FT-77", "? W", 64, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1970, "? mm", "Regency/regency_inf10.jpg", "INF-10 \"Informant\"", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1971, "? mm", "Regency/regency_inf50.jpg", "INF-50 \"Informant\"", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1972, "146*60*235 mm (5.75*2.42*9.25in)", "Regency/regency_m100.jpg", "Touch M100", "", 60, "1.6 Kg (3.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1973, "146*60*235 mm (5.75*2.42*9.25in)", "Regency/regency_m100.jpg", "Touch M100E", "", 60, "1.6 Kg (3.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1974, "146*60*235 mm (5.75*2.38*9.25in)", "Regency/regency_m400.jpg", "Touch M400", "", 60, "1.59 Kg (3.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1975, "146*60*235 mm (5.75*2.38*9.25in)", "Regency/regency_m400.jpg", "Touch M400E", "", 60, "1.59 Kg (3.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1976, "120*38*168 mm (4.72*1.5*6.61in)", "Regency/mx1600_top.jpg", "MX-1600", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1969, "? mm", "Regency/regency_hx650.jpg", "HX-650", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1977, "? mm", "Regency/regency_mx3000.jpg", "MX-3000", "", 60, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1979, "138*80*200 mm (5.4*3.1*7.9in)", "Regency/mx5000.jpg", "MX-5000", "", 60, "1.1 Kg (2.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1980, "? mm", "Regency/regency_mx7000.jpg", "MX-7000", "", 60, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1981, "196*125*36 mm (7.72*4.92*1.42in)", "Roberts/roberts_r809.jpg", "R-809", "", 61, "720 gr (1.59 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1982, "296*192*68 mm (11.65*7.56*2.68in)", "Roberts/roberts_r827.jpg", "R-827", "", 61, "1.72 Kg (3.79 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1983, "223*135*38 mm (8.78*5.32*1.5in)", "Roberts/roberts_r861.jpg", "R-861", "", 61, "770 gr (1.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1984, "135*78*28 mm (5.32*3.07*1.1in)", "Roberts/roberts_r862.jpg", "R-862", "", 61, "250 gr (8.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1985, "185*115*42 mm (7.28*4.53*1.65in)", "Roberts/roberts_r871.jpg", "R-871", "", 61, "475 gr (16.76 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1978, "? mm", "Regency/regency_mx4000.jpg", "MX-4000", "", 60, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1986, "148*89*30 mm (5.83*3.5*1.18in)", "Roberts/roberts_r876.jpg", "R-876", "", 61, "330 gr (11.64 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1968, "77*174*39 mm (3.03*6.85*1.54in)", "Regency/regency_hx2000e.jpg", "HX-2000E", "", 60, "425 gr (15 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1966, "? mm", "Regency/regency_hx1000.jpg", "HX-1000", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1950, "? mm", "Regency/r1070.jpg", "R-1070", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1951, "? mm (?in)", "Regency/r1600.jpg", "R-1600", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1952, "? mm", "Regency/r2060.jpg", "R-2060", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1953, "? mm", "Regency/regency_actc4u.jpg", "ACT-C4U", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1954, "? mm", "Regency/regency_acte10.jpg", "ACT-E10 H/L/U", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1955, "? mm", "Regency/regency_acte106.jpg", "ACT-E106", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1956, "? mm", "Regency/regency_actr106.jpg", "ACT-R106", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1967, "? mm", "Regency/regency_hx200.jpg", "HX-200", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1957, "? mm", "Regency/regency_actr1.jpg", "ACT-R1 High", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1959, "? mm", "Regency/regency_actr1.jpg", "ACT-R1 UHF", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1960, "165*65*218 mm (6.5*2.6*8.58in)", "Regency/regency_actr92ap.jpg", "ACT-R92AP \"Flight scan\"", "", 60, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1961, "? mm", "Regency/regency_actt16k.jpg", "ACT-T16K", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1962, "? mm", "Regency/regency_actt720a.jpg", "ACT-T720A", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1963, "? mm", "Regency/regency_c403.jpg", "C-403", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1964, "? mm", "Regency/regency_d310.jpg", "D-310", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1965, "? mm", "Regency/regency_d810.jpg", "D-810", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1958, "? mm", "Regency/regency_actr1.jpg", "ACT-R1 Low", "", 60, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1987, "161*105*36 mm (6.34*4.13*1.42in)", "Roberts/roberts_r881.jpg", "R-881", "", 61, "370 gr (13.05 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1988, "215*125*35 mm (8.46*4.92*1.38in)", "Roberts/roberts_r9914.jpg", "R-9914", "", 61, "575 gr (20.28 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1989, "165*105*36 mm (6.5*4.13*1.42in)", "Roberts/roberts_r9921.jpg", "R-9921", "", 61, "380 gr (13.4 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2011, "448*153*470 mm (17.64*6.02*18.5in)", "Siemens/chr531.jpg", "CHR531", "", 63, "23 Kg (50.71 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2012, "445*177*440 mm (17.52*6.97*17.32in)", "Siemens/e410.jpg", "E410", "", 63, "18 Kg (39.68 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2013, "380*180*330 mm (14.96*7.09*12.99in)", "Sommerkamp/fl100b.jpg", "FL-100B", "120 W (PEP input)", 64, "16 Kg (35.27 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2014, "370*160*290 mm (14.57*6.3*11.42in)", "Sommerkamp/fl500b.jpg", "FL-500B", "100 W", 64, "19 Kg (41.89 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2015, "? mm", "Sommerkamp/fldx500.jpg", "FLDX-500", "? W", 64, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2016, "380*180*330 mm (14.96*7.09*12.99in)", "Sommerkamp/fr100b.jpg", "FR-100B", "", 64, "12 Kg (26.46 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2017, "340*153*285 mm (13.4*6*11.2in)", "Sommerkamp/fr101d.jpg", "FR-101D", "", 64, "9 Kg (19.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2010, "475*295*390 mm (18.7*11.61*15.35in)", "Siemens/745_e311a.jpg", "745 E311a", "", 63, "26 Kg (57.32 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2018, "330*152*260 mm (13*6*10.25in)", "Sommerkamp/fr50b.jpg", "FR-50B", "", 64, "7.94 Kg (17.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2020, "280*125*295 mm (11*4.92*11.6in)", "Sommerkamp/ft220.jpg", "FT-220", @"FM/CW: 10 W
SSB: Max 10 W (PEP)", 64, "8.5 Kg (18.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2021, "mm (in)", "Sommerkamp/ft221.jpg", "FT-221", @"FM/CW: 10 W
SSB: Max 10 W (PEP)", 64, "Kg ( lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2022, "280*125*295 mm (11*4.9*11.6in)", "Sommerkamp/ft221r.jpg", "FT-221R", "AM: 2.5 WFM/CW: 14 WSSB: 12 W PEP", 64, "8.5 Kg (18.7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2023, "330*140*279 mm (13*5.5*11in)", "Sommerkamp/ft250.jpg", "FT-250", "240 W (PEP input)", 64, "7.26 Kg (16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2024, "? mm", "Sommerkamp/ft277.jpg", "FT-277", "? W", 64, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2025, "? mm", "Sommerkamp/ft307.jpg", "FT-307", "? W", 64, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2026, "240*93*295 mm (9.45*3.66*11.61in)", "Sommerkamp/ft767dx.jpg", "FT-767DX", "100 W", 64, "6.5 Kg (14.33 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2019, "? mm", "Sommerkamp/frdx500.jpg", "FRDX-500", "", 64, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2009, "550*350*380 mm (21.65*13.78*14.96in)", "Siemens/745_e310.jpg", "745 E310", "", 63, "35 Kg (77.16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2008, "550*355*407 mm (21.65*13.98*16.02in)", "Siemens/745_e309b.jpg", "745 E309b", "", 63, "38 Kg (83.78 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2007, "552*356*340 mm (21.73*14.02*13.39in)", "Siemens/745_e303.jpg", "745 E303", "", 63, "44 Kg (97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1990, "296*192*68 mm (11.65*7.56*2.68in)", "Roberts/roberts_rc828.jpg", "RC-828", "", 61, "1.72 Kg (3.79 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1991, "208*135*41 mm (8.19*5.32*1.61in)", "Sangean/ats909x_blk.jpg", "ATS-909X", "", 62, "735 gr (1.62 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1992, "? mm", "Sangean/ats202.jpg", "ATS-202", "", 62, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1993, "? mm", "Sangean/ats303.jpg", "ATS-303", "", 62, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1994, "? mm", "Sangean/ats404.jpg", "ATS-404", "", 62, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1995, "214*128*38 mm (8.42*5.04*1.5in)", "Sangean/ats505.jpg", "ATS-505", "", 62, "840 gr (1.85 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1996, "133*89*32 mm (5.25*3.5*1.25in)", "Sangean/ats606a.jpg", "ATS-606A", "", 62, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1997, "? mm", "Sangean/ats800.jpg", "ATS-800", "", 62, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1998, "? mm", "Sangean/ats800a.jpg", "ATS-800A", "", 62, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1999, "? mm", "Sangean/ats801.jpg", "ATS-801", "", 62, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2000, "? mm", "Sangean/ats802.jpg", "ATS-802", "", 62, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2001, "293*160*60 mm (11.54*6.3*2.36in)", "Sangean/ats803.jpg", "ATS-803", "", 62, "1.75 Kg (3.86 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2002, "293*160*60 mm (11.54*6.3*2.36in)", "Sangean/ats803a.jpg", "ATS-803A", "", 62, "1.75 Kg (3.86 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2003, "190*152*38 mm (7.5*6*1.5in)", "Sangean/ats808a.jpg", "ATS-808A", "", 62, "680 gr (1.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2004, "296*192*68 mm (11.65*7.56*2.68in)", "Sangean/ats818.jpg", "ATS-818", "", 62, "1.9 Kg (4.19 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2005, "215*133*38 mm (10.04*5.24*1.5in)", "Sangean/ats909.jpg", "ATS-909", "", 62, "850 gr (1.87 lb), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2006, "162*87*28 mm (6.38*3.42*1.1in)", "Sangean/sg789.jpg", "SG-789", "", 62, "300 g (10.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2028, "? mm", "Sommerkamp/ftdx150.jpg", "FTdx-150", "75 W", 64, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2109, "58*122*27 mm (2.28*4.8*1.06in)", "Standard/c488s.jpg", "C-488S", @"Hi: 5 W
Mid: ? W, Lo: ? mW", 66, "300 g (10.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2110, "362*109*330 mm (14.25*4.29*12.99in)", "Standard/c50.jpg", "C-50", "Hi: 10/10 WMid: 5/5 W, Lo: 1/1 W", 66, "11 Kg (24.25)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2111, "60*173*34 mm (2.36*6.81*1.34in)", "Standard/c500e.jpg", "C-500E", @"2 mHi: 2.5-5 W (Depending on voltage), Lo: 400 mW


70 cmHi: 2.5-5 W (Depending on voltage), Lo: 400 mW", 66, "490 g (17.28 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2214, "? mm", "Teltow/215.jpg", "215", "100 W", 71, "30 Kg (66.14 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2215, "542*222*348 mm (21.34*8.74*13.7in)", "Teltow/215b.jpg", "215B", "20-60 W", 71, "27 Kg (59.52 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2216, "? mm", "Teltow/215c.jpg", "215C", "100 W", 71, "30 Kg (66.14 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2217, "? mm", "Tentec/1220.jpg", "Ten-Tec 1220", "5 W (30 W option: 1222)", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2218, "? mm", "Tentec/1253.jpg", "Ten-Tec 1253", "", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2219, "? mm", "Tentec/1254.jpg", "Ten-Tec 1254", "", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2220, "? mm", "Tentec/2510modeb.jpg", "Ten-Tec 2510 Mode B", "? W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2213, "? mm", "Teltow/210.jpg", "210", "100 W", 71, "30 Kg (66.14 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2221, "? mm", "Tentec/2591.jpg", "Ten-Tec 2591", "Hi: 2.5 W, Lo: 0.3 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2223, "330*115*180 mm (12.99*4.53*7.09in)", "Tentec/argonaut509.jpg", "Ten-Tec Argonaut 509", "Max 3 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2224, "? mm", "Tentec/argonaut515.jpg", "Ten-Tec Argonaut 515", "3 W", 72, "?" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2225, "248*95*318 mm (9.76*3.74*12.52in)", "Tentec/argonautii535.jpg", "Ten-Tec Argonaut II (535)", "0-5 W", 72, "3.9 Kg (8.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2226, "216*70*246 mm (8.5*2.76*9.68in)", "Tentec/argonautv516.jpg", "Ten-Tec Argonaut V (516)", "1-20 W", 72, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2227, "241*101*305 mm (9.49*3.98*12.01in)", "Tentec/argosy525.jpg", "Ten-Tec Argosy (525)", "10-100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2228, "? mm", "Tentec/argosyii.jpg", "Ten-Tec Argosy II (525D)", "10-100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2229, "? mm", "Tentec/century21.jpg", "Ten-Tec Century 21 (570)", "30 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2222, "216*70*222 mm (8.5*2.76*8.74in)", "Tentec/526.jpg", "Ten-Tec 526 (6N2)", "1-20/1-20 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2230, "? mm", "Tentec/tentec_century21digi574.jpg", "Ten-Tec Century 21/Digital (574)", "30 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2212, "272*173*88 mm (10.71*6.81*3.46in)", "Tecsun/s8800e.jpg", "S-8800e \"Wellenjagd edition\"", "", 70, "1.5 Kg (3.31 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2210, "372*183*153 mm (14.65*7.2*6.02in)", "Tecsun/s2000.jpg", "S-2000", "", 70, "2.7 Kg (5.95 lb), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2194, "? mm", "Swan/750.jpg", "750", "300 W SSB, 200 W CW", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2195, "362*162*337 mm (14.25*6.38*13.27in)", "Swan/astro103.jpg", "Cubic Astro 103", "100 W", 69, "10.6 Kg (23.37 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2196, "247*95*301 mm (9.72*3.74*11.85in)", "Swan/astro150.jpg", "Astro 150", "100 W", 69, "5.9 Kg (13.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2197, "247*95*301 mm (9.72*3.74*11.85in)", "Swan/cubic_astro150a.jpg", "Cubic Astro 150A", "100 W", 69, "5.9 Kg (13.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2198, "? mm", "Swan/fm1210a.jpg", "FM-1210A", "10 W", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2199, "? mm", "Swan/fm2xa.jpg", "FM-2XA", "10 W", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2200, "? mm", "Swan/swan_ss200a.jpg", "SS-200A", "? W", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2211, "272*173*88 mm (10.71*6.81*3.46in)", "Tecsun/s8800.jpg", "S-8800", "", 70, "1.5 Kg (3.31 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2201, "? mm", "Swan/sw120.jpg", "SW-120", "150 W (PEP input)", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2203, "? mm", "Swan/sw160x.jpg", "SW-160X", "? W", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2204, "? mm", "Swan/sw240.jpg", "SW-240", "100 W", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2205, "53*159*26 mm (2.09*6.26*1.02in)", "Tecsun/pl365.jpg", "PL-365", "", 70, "128 g (4.52 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2206, "188*116*31 mm (7.4*4.6*1.25in)", "Tecsun/pl600.jpg", "PL-600", "", 70, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2207, "187*114*33 mm (7.4*4.5*1.3in)", "Tecsun/pl660.jpg", "PL-660", "", 70, "470 gr (1.04 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2208, "188*116*31 mm (7.4*4.57*1.22in)", "Tecsun/pl680.jpg", "PL-680", "", 70, "475 g (1.05 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2209, "192*113*33 mm (7.56*4.45*1.3in)", "Tecsun/pl880.jpg", "PL-880", "", 70, "520 g (1.15 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2202, "? mm", "Swan/sw140.jpg", "SW-140", "150 W (PEP input)", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2231, "250*101*290 mm (9.84*3.98*11.42in)", "Tentec/century22.jpg", "Ten-Tec Century 22 (579)", "25 W", 72, "2.7 Kg (5.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2232, "? mm (?in)", "Tentec/corsair.jpg", "Ten-Tec Corsair (560)", "Max 100 W (100% duty cycle)", 72, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2233, "? mm", "Tentec/corsairii.jpg", "Ten-Tec Corsair II (561)", "100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2255, "308*127*330 mm (12.13*5*12.99in)", "Tentec/rx350.jpg", "Ten-Tec RX-350", "", 72, "5.45 Kg (12.02 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2256, "? mm", "Tentec/scout555.jpg", "Ten-Tec Scout 555", "5-50 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2257, "? mm", "Tentec/540.jpg", "Ten-Tec Triton IV (540)", "100 W (100% duty cycle)", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2258, "? mm", "Tentec/544-tritoniv.jpg", "Ten-Tec Triton IV Digital (544)", "100 W (100% duty cycle)", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2259, "343*114*330 mm (13.5*4.5*13in)", "Tentec/tritoni.jpg", "Ten-Tec Triton I", "50 W", 72, "5.44 Kg (12 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2260, "67*135*28 mm (2.12*5.31*1.06in)", "Whistler/trx1.jpg", "TRX-1", "", 73, "210 g (7.4 oz), without batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2261, "67*135*28 mm (2.12*5.31*1.06in)", "Whistler/trx1e.jpg", "TRX-1E", "", 73, "210 g (7.4 oz), without batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2254, "482*133*317 mm (19*5.25*12.5in)", "Tentec/rx340.jpg", "Ten-Tec RX-340", "", 72, "5.7 Kg (12.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2262, "180*45*135 mm (7.12*1.75*5.31in)", "Whistler/trx2.jpg", "TRX-2", "", 73, "950 g (2.09 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2264, "63*145*40 mm (2.37*5.68*1.56in)", "Whistler/ws1010.jpg", "WS1010", "", 73, "220 gr (7.8 oz), without antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2265, "175*60*210 mm (6.87*2.37*8.25in)", "Whistler/ws1025.jpg", "WS1025", "", 73, "700 gr (24.7 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2266, "65*145*42 mm (2.56*5.71*1.65in)", "Whistler/ws1040.jpg", "WS1040", "", 73, "240 gr (8.5 oz), without antenna and batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2267, "185*55*135 mm (7.3*2.2*5.3in)", "Whistler/ws1065.jpg", "WS1065", "", 73, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2268, "67*135*28 mm (2.12*5.31*1.06in)", "Whistler/ws1080.jpg", "WS1080", "", 73, "210 gr (7.4 oz), without antenna and batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2269, "67*135*28 mm (2.12*5.31*1.06in)", "Whistler/ws1088.jpg", "WS1088", "", 73, "210 gr (7.4 oz), without antenna and batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2270, "180*45*135 mm (7.12*1.75*5.31in)", "Whistler/ws1095.jpg", "WS1095", "", 73, "950 gr (2.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2263, "180*45*135 mm (7.12*1.75*5.31in)", "Whistler/trx2e.jpg", "TRX-2E", "", 73, "950 g (2.09 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2253, "? mm", "Tentec/rx325.jpg", "Ten-Tec RX-325", "", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2252, "? mm", "Tentec/pm3.jpg", "Ten-Tec PM-3", "? W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2251, "260*110*160 mm (10.24*4.33*6.3in)", "Tentec/pm2.jpg", "Ten-Tec PM-2", "2 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2234, "? mm", "Tentec/delta580.jpg", "Ten-Tec Delta (580)", "100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2235, "? mm", "Tentec/deltaii.jpg", "Ten-Tec Delta II (536)", "100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2236, "? mm", "Tentec/eagle.jpg", "Ten-Tec Eagle (599)", "5-100 W (100% duty cycle)", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2237, "308*127*330 mm (12.13*5*12.99in)", "Tentec/jupiter.jpg", "Ten-Tec Jupiter (538)", "5-100 W (100% duty cycle)", 72, "5.3 Kg (11.68 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2238, "165*57*193 mm (6.5*2.25*7.6in)", "Tentec/argonautvi.jpg", "Ten-Tec Argonaut VI (539)", "1-10 W", 72, "1.63 Kg (3.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2239, "362*140*356 mm (14.25*5.5*14in)", "Tentec/omnia.jpg", "Ten-Tec Omni-A (545)", "85-100 W @ 14 VDC, 100% duty cycle", 72, "6.6 Kg (14.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2240, "362*140*356 mm (14.25*5.5*14in)", "Tentec/omnic.jpg", "Ten-Tec Omni-C (546C)", "85-100 W  typical", 72, "6.58 Kg (14.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2241, "362*140*356 mm (14.25*5.5*14in)", "Tentec/omnid.jpg", "Ten-Tec Omni-D (546)", "85-100 W @ 14 VDC, 100% duty cycle", 72, "6.6 Kg (14.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2242, "273*146*432 mm (10.75*5.75*17.01in)", "Tentec/omniv.jpg", "Ten-Tec Omni V (562)", "20-100 W", 72, "7.25 Kg (15.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2243, "? mm", "Tentec/omnivi.jpg", "Ten-Tec Omni VI (563)", "5-100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2244, "? mm", "Tentec/omnivii588.jpg", "Ten-Tec Omni VII (588)", "100/100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2245, "375*146*432 mm (14.76*5.75*17.01in)", "Tentec/omniviplus.jpg", "Ten-Tec Omni VI Plus (564)", "5-100 W", 72, "7.25 Kg (15.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2246, "? mm", "Tentec/orion.jpg", "Ten-Tec Orion (565)", "100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2247, "432*133*476 mm (17.01*5.24*18.74in)", "Tentec/orionii566.jpg", "Ten-Tec Orion II (566)", "100 W", 72, "9.2 Kg (20.28 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2248, "? mm", "Tentec/paragon.jpg", "Ten-Tec Paragon (585)", "Max 100 W", 72, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2249, "375*146*432 mm (14.75*5.75*17in)", "Tentec/paragonii.jpg", "Ten-Tec Paragon II (586)", "0-100 W (100% duty cycle up to 20 minutes)", 72, "7.25 Kg (16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2250, "130*273*292 mm (5.12*10.75*11.5in)", "Tentec/pegasus550.jpg", "Ten-Tec Pegasus (550)", "100 W", 72, "4.1 Kg (9.04 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2193, "? mm", "Swan/700.jpg", "700", "? W", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2192, "330*130*260 mm (12.99*5.12*10.24in)", "Swan/500cx.jpg", "500CX", "SSB: 550 W (PEP input)CW: 360 W (input)AM: 125 W (input)", 69, "7.3 Kg (16.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2191, "330*140*279 mm (13*5.5*11in)", "Swan/500c.jpg", "500C", @"AM: 125 W (Input)
SSB: 520 W (PEP input)
CW: 360 W (Input)", 69, "7.82 Kg (17.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2190, "? mm", "Swan/400.jpg", "400", "200 W (70 W AM)", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2133, "58*80*25 mm (2.28*3.15*0.98in)", "Standard/c601.jpg", "C-601", "280/100 mW", 66, "160 gr (5.64 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2134, "? mm", "Standard/c628.jpg", "C-628", "Hi: 5/1 WMid: 2/? W, Lo: 350/100 mW", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2135, "340*156*290 mm (13.39*6.14*11.42in)", "Standard/standard_c6500.jpg", "C-6500", "", 66, "6.4 Kg (14.11 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2136, "63*95*29 mm (2.48*3.74*1.14in)", "Standard/c701.jpg", "C-701", @"2 m280 mW


70 cm280 mW


23 cm100 mW", 66, "160 g (5.64 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2137, "58*104*27 mm (2.28*4.09*1.06in)", "Standard/c710.jpg", "C-710", @"2 mHi: 1 W, Lo: 300 mW


70 cmHi: 1 W, Lo: 300 mW


23 cmHi: 280 mW, Lo: 170 mW", 66, "210 g (7.41 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2138, "129*52*191 mm (5.08*2.05*7.52in)", "Standard/c78.jpg", "C-78", "1 W", 66, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2139, "? mm", "Standard/c7800.jpg", "C-7800", "Hi: ?/? W, Lo: ?/? W", 66, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2132, "155*55*207 mm (6.1*2.16*8.15in)", "Standard/c6000series.jpg", "C-6000S", "Hi: 25/10 W, Lo: 5/1 W", 66, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2140, "138*31*178 mm (5.43*1.22*7.01in)", "Standard/c7900.jpg", "C-7900", "Hi: 10 W, Lo: ? W", 66, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2142, "84*58*235 mm (3.31*2.28*9.25in)", "Standard/c828m.jpg", "C-828M", "Hi: 10 W, Lo: 1 W", 66, "0.96 Kg (2.12 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2143, "129*52*191 mm (5.08*2.05*7.52in)", "Standard/c88.jpg", "C-88", "1 W", 66, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2144, "168*58*240 mm (6.61*2.28*9.45in)", "Standard/c8800.jpg", "C-8800", "Hi: 10 W, Lo: 1 W", 66, "3 Kg (6.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2145, "138*31*178 mm (5.43*1.22*7.01in)", "Standard/c8900.jpg", "C-8900", "Hi: 10 W, Lo: ? W", 66, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2146, "112*38*178 mm (4.41*1.5*7.01in)", "Standard/standard_ftm10.jpg", "FTM-10", "Hi: 20/20 W, Lo: 5/5 W", 66, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2147, "112*38*178 mm (4.41*1.5*7.01in)", "Standard/standard_ftm10.jpg", "FTM-10H", "Hi: 50/40 WMid: 20/20 W, Lo: 5/5 W", 66, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2148, "112*38*178 mm (4.41*1.5*7.01in)", "Standard/standard_ftm10.jpg", "FTM-10S", "10/7 W", 66, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2141, "70*120*37 mm (2.75*4.72*1.46in)", "Standard/c800.jpg", "C-800", "50 mW", 66, "290 gr (10.23 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2131, "155*55*207 mm (6.1*2.16*8.15in)", "Standard/c6000series.jpg", "C-6000", "Hi: 10/10 W, Lo: 1/1 W", 66, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2130, "140*40*173 mm (5.51*1.58*6.81in)", "Standard/c5900.jpg", "C-5900D", "Hi: 45 / 50 / 35 WMid: 10 / 10 / 10 W, Lo: 3 / 3 / 3 W", 66, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2129, "140*40*173 mm (5.51*1.58*6.81in)", "Standard/c5900.jpg", "C-5900B", "Hi: 20 / 20 / 20 WMid: 10 / 10 / 10 W, Lo: 3 / 3 / 3 W", 66, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2112, "58*80*25 mm (2.28*3.15*0.98in)", "Standard/c501.jpg", "C-501", "280/280 mW", 66, "160 gr (5.64 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2113, "64*95*29 mm (2.52*3.74*1.14in)", "Standard/c508.jpg", "C-508", "280 mW", 66, "180 gr (6.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2114, "362*109*365 mm (14.25*4.29*14.37in)", "Standard/c50.jpg", "C-50D", "Hi: 50/40 WMid: 5/5 W, Lo: 1/1 W", 66, "11.5 Kg (25.35 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2115, "58*104*27 mm (2.28*4.09*1.06in)", "Standard/c510.jpg", "C-510", "Hi: 1/1 W, Lo: 300/300 mW", 66, "210 gr (7.41 oz), with batteries & antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2116, "150*50*205 mm (5.91*1.97*8.07in)", "Standard/c5200d.jpg", "C-5200D", @"2 mHi: 50 W, Lo: 5 W


70 cmHi: 40 W, Lo: 5 W", 66, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2117, "150*50*180 mm (5.91*1.97*7.09in)", "Standard/c5200.jpg", "C-5200E", @"2 mHi: 10 W, Lo: 1 W


70 cmHi: 10 W, Lo: 1 W", 66, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2118, "150*50*205 mm (5.91*1.97*8.07in)", "Standard/c5200.jpg", "C-5200ED", @"2 mHi: 50 W, Lo: 5 W


70 cmHi: 40 W, Lo: 5 W", 66, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2119, "55*157*31 mm (2.16*6.18*1.22in)", "Standard/c528.jpg", "C-528", @"2 mHi: 2.4-5 W (Depending on voltage), Mid: 2 W, Lo: 350 mW


70 cmHi: 2-5 W (Depending on voltage), Mid: 2 W, Lo: 350 mW", 66, "450 g (15.87 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2120, "? mm", "Standard/c5400.jpg", "C-5400", "? W", 66, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2121, "? mm", "Standard/c5500.jpg", "C-5500", "? W", 66, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2122, "55*130*31 mm (2.16*5.12*1.22in)", "Standard/c558s.jpg", "C-558S", "Hi: 5/5 W, Lo: ?/? W", 66, "355 gr (12.52 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2123, "47*135*34 mm (1.85*5.32*1.34in)", "Standard/c560.jpg", "C-560", "Hi: 2.5/2.5 W/35 mWMid: ?/? W/35 mW, Lo: ?/? W/35 mW", 66, "360 gr (12.7 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2124, "150*50*210 mm (5.91*1.97*8.27in)in)", "Standard/c5608d.jpg", "C-5608D", "Hi: 50/40 WMid: 10/10 W, Lo: 3/3 W", 66, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2125, "47*135*34 mm (1.85*5.32*1.34in)", "Standard/c568.jpg", "C-568", "Hi: 2.5/2.5 W/35 mWMid: ?/? W/35 mW, Lo: ?/? W/35 mW", 66, "360 gr (12.7 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2126, "140*55*40 mm (5.51*2.16*1.58in)", "Standard/c5750.jpg", "C-5750", "Hi: 7 / 6 WMid: 3 / 3 W, Lo: ? / ? W", 66, "360 gr (12.7 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2127, "149*54*208 mm (5.87*2.13*8.19in)", "Standard/c5800.jpg", "C-5800E", "Hi: 25 W, Lo: 1 W", 66, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2128, "129*52*191 mm (5.08*2.05*7.52in)", "Standard/c58.jpg", "C-58", "1 W", 66, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2149, "? mm", "Standard/horizon2.jpg", "Horizon/2", "Hi: 25 W, Lo: ? W", 66, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1948, "? mm (?in)", "Regency/inf5.jpg", "INF-5 \"Informant\"", "", 60, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2150, "? mm (?in)", "Standard/src145b.jpg", "SR-C145B", "2 W", 66, "? gr (? lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2152, "76*229*41 mm (3*9*1.62in)", "Standard/src146a.jpg", "SR-C146A", "2 W", 66, "907 gr (2 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2174, "192*67*216 mm (7.56*2.64*8.5in)", "Svera/sr_masterscanner1414a.jpg", "/ Svensk Radio SR Masterscanner 1414A", "", 68, "1.76 Kg (3.88 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2175, "192*67*216 mm (7.56*2.64*8.5in)", "Svera/sr_masterscanner1414b.jpg", "/ Svensk Radio SR Masterscanner 1414B", "", 68, "1.76 Kg (3.88 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2176, "? mm (?in)", "Svera/sr_pro16.jpg", "/ Svensk Radio SR Pro-16", "", 68, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2177, "166*54*193 mm (6.54*2.13*7.6in)", "Svera/sr_superprovls.jpg", "/ Svensk Radio SR Super-Pro VLS", "", 68, "1.52 Kg (3.35 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2178, "166*55*189 mm (6.54*2.16*7.44in)", "Svera/sr_vlusuperscanner.jpg", "/ Svensk Radio SR VLU Superscanner", "", 68, "1.78 Kg (3.92 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2179, "164*56*194 mm (6.46*2.2*7.64in)", "Svera/vlhfm.jpg", "/ Svensk Radio VLH/FM", "", 68, "1.4 Kg (3.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2180, "247*95*301 mm (9.72*3.74*11.85in)", "Swan/100mx.jpg", "100 MX", "100 W", 69, "5.9 Kg (13.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2173, "? mm (?in)", "Svera/sr_hilowsuperscanner.jpg", "/ Svensk Radio SR Hi-Low Superscanner", "", 68, "1.7 Kg (3.75 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2181, "362*162*337 mm (14.25*6.38*13.27in)", "Swan/102bx.jpg", "102 BX", "100 W", 69, "10.6 Kg (23.37 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2183, "? mm", "Swan/250c.jpg", "250C", "100 W (75 W AM)", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2184, "? mm", "Swan/260cygnet.jpg", "260 Cygnet", "SSB: 260 W (PEP input)CW: 180 W (input)", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2185, "330*140*280 mm (12.99*5.51*11.02in)", "Swan/270cygnet.jpg", "270 Cygnet", @"SSB: 260 W (PEP input)
CW: 180 W (input)", 69, "11 Kg (24.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2186, "330*140*279 mm (13*5.5*11in)", "Swan/350.jpg", "350", @"AM: Max 125 W (input)
SSB: Max 400 W (PEP input)
CW: Max 320 W (DC input)", 69, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2187, "? mm", "Swan/350c.jpg", "350C", "200 W", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2188, "? mm", "Swan/350d.jpg", "350D", "200 W", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2189, "330*140*279 mm (13*5.5*11in)", "Swan/350mkii.jpg", "350 MkII", @"AM: Max 140 W (input)
SSB: Max 400 W (PEP input)
CW: Max 320 W (DC input)", 69, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2182, "? mm", "Swan/250.jpg", "250", "100 W (75 W AM)", 69, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2172, "265*105*241 mm (10.43*4.13*9.49in)", "Svera/sr_4bander.jpg", "/ Svensk Radio SR 4-Bander", "", 68, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2171, "200*70*243 mm (7.87*2.76*9.57in)", "Svera/sr_312.jpg", "/ Svensk Radio SR-312", "", 68, "2.23 Kg (4.92 lb), without mounting bracket" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2170, "192*62*203 mm (7.56*2.44*7.99in)", "Svera/sr_16.jpg", "/ Svensk Radio SR-16", "", 68, "1.54 Kg (3.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2153, "? mm (?in)", "Standard/src806g.jpg", "SR-C806G", "Hi: 10 W, Lo: 1 W", 66, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2154, "? mm (?in)", "Standard/src828m.jpg", "SR-C828M", "Hi: 10 W, Lo: 1 W", 66, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2155, "? mm", "Standard/vr160.jpg", "VR-160", "", 66, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2156, "? mm", "Star/sr100.jpg", "SR-100 \"Friend\"", "", 67, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2157, "? mm", "Star/sr200.jpg", "SR-200", "", 67, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2158, "385*185*255 mm (15.2*7.3*10in)", "Star/sr550.jpg", "SR-550", "", 67, "6.5 Kg (14.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2159, "? mm", "Star/sr600.jpg", "SR-600", "", 67, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2160, "? mm", "Star/sr700a.jpg", "SR-700A", "", 67, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2161, "? mm", "Star/st200.jpg", "ST-200", "? W", 67, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2162, "? mm", "Star/st333.jpg", "ST-333", "10 W", 67, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2163, "? mm", "Star/st700.jpg", "ST-700", "? W", 67, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2164, "160*54*207 mm (6.3*2.13*8.15in)", "Svera/ds2200vlh.jpg", "/ Svensk Radio DS-2200VLH", "", 68, "1.25 Kg (2.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2165, "236*73*250 mm (9.3*2.9*9.8in)", "Svera/ds3300.jpg", "/ Svensk Radio DS-3300", "", 68, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2166, "? mm", "Svera/sr208.jpg", "/ Svensk Radio SR-208", "", 68, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2167, "66*120*33 mm (2.6*4.72*1.3in)", "Svera/sr_13905a.jpg", "/ Svensk Radio SR 13-905A", "", 68, "260 g (9.17 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2168, "66*120*33 mm (2.6*4.72*1.3in)", "Svera/sr_13905.jpg", "/ Svensk Radio SR 13-905B", "", 68, "260 gr (9.17 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2169, "80*136*37 mm (3.15*5.35*1.46in)", "Svera/sr_13906a.jpg", "/ Svensk Radio SR 13-906A \"Miniscanner\"", "", 68, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2151, "75*210*40 mm (2.95*8.27*1.58in)", "Standard/src146.jpg", "SR-C146", "1 W", 66, "1 Kg (2.2 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1299, "185*64*223 mm (7.28*2.52*8.78in)", "Icom/ic560.jpg", "IC-560", @"HighLow
6 m:10 W1 W", 43, "2.7 Kg (5.95 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1298, "241*111*311 mm (9.49*4.37*12.24in)", "Icom/ic551d.jpg", "IC-551D", @"AM: 0-40 W
FM: 1-50 W (With optional FM unit)
SSB: 1-50 W (PEP)
CW: 1-50 W", 43, "6.6 kg (14.55 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1297, "241*111*264 mm (9.49*4.37*10.39in)", "Icom/ic551.jpg", "IC-551", @"AM: 1-4 W
FM: 1-10 W (Optional)
SSB: 1-10 W (PEP)
CW: 1-10 W", 43, "6.1 kg (13.44 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 428, "? mm", "Bearcat/bc800xlt.jpg", "Uniden Bearcat BC-800XLT", "", 15, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 429, "64*178*38 mm (2.5*7*1.5in)", "Bearcat/bc80xlt.jpg", "Uniden Bearcat BC-80XLT", "", 15, "340 g (12 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 430, "229*60*190 mm (9*2.38*7.5in)", "Bearcat/bearcat_bc860xlt.jpg", "Uniden Bearcat BC-860XLT", "", 15, "626 gr (1.38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 431, "? mm", "Bearcat/bearcat_bc890xlt.jpg", "Uniden Bearcat BC-890XLT", "", 15, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 432, "276*86*190 mm (10.87*3.38*7.48in)", "Bearcat/bearcat_bc895xlt.jpg", "Uniden Bearcat BC-895XLT (Trunktracker)", "", 15, "1.59 Kg (3.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 433, "276*86*190 mm (10.87*3.38*7.48in)", "Bearcat/bc898t.jpg", "Uniden Bearcat BC-898T (Trunktracker III)", "", 15, "1.6 Kg (3.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 434, "267*85*190 mm (10.51*3.34*7.48in)", "Bearcat/bearcat_bc9000xlt.jpg", "Uniden Bearcat BC-9000XLT", "", 15, "1.82 Kg (4.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 427, "177*61*167 mm (6.97*2.84*6.58in)", "Bearcat/bc796d.jpg", "Uniden Bearcat BC-796D (Trunktracker IV)", "", 15, "1.44 Kg (3.18 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 435, "160*41*189 mm (6.3*1.6*7.4in)", "Bearcat/bc950xlt.jpg", "BC-950XLT", "", 15, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 437, "71*161*37 mm (2.8*6.3*1.5in)", "Bearcat/bcd436hp.jpg", "BCD-436HP (Trunktracker V)", "", 15, "349 g (12.3 oz). with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 438, "184*56*151 mm (7.2*2.2*5.9in)", "Bearcat/bcd536hp.jpg", "Uniden Bearcat BCD-536HP", "", 15, "1.54 Kg (3.39 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 439, "184*56*154 mm (7.24*2.2*6.06in)", "Bearcat/bcd996t.jpg", "Uniden Bearcat BCD-996T (Trunktracker IV)", "", 15, "1.6 Kg (3.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 440, "183*56*150 mm (7.2*2.2*5.9in)", "Bearcat/bcd996xt.jpg", "Uniden Bearcat BCD-996XT (Trunktracker IV)", "", 15, "1.56 Kg (3.44 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 441, "102*25*152 mm (4*1*6in)", "Bearcat/bce.jpg", "BC-E / 8-track (By Electra Company)", "", 15, "170 g (6 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 442, "76*33*136 mm (2.99*1.3*5.36in)", "Bearcat/bct10.jpg", "Uniden Bearcat BCT-10", "", 15, "180 gr (6.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 443, "76*33*136 mm (2.99*1.3*5.36in)", "Bearcat/bct12.jpg", "Uniden Bearcat BCT-12 (Beartracker)", "", 15, "180 gr (6.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 436, "65*153*45 mm (2.56*6.02*1.77in)", "Bearcat/bcd396t.jpg", "Uniden Bearcat BCD-396T (Trunktracker IV)", "", 15, "218 g (7.68 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 444, "184*56*154 mm (7.24*2.2*6.06in)", "Bearcat/bct15.jpg", "Uniden Bearcat BCT-15 (Bear/Trunktracker III)", "", 15, "1.6 Kg (3.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 426, "177*72*167 mm (6.97*2.84*6.58in)", "Bearcat/bc785d.jpg", "Uniden Bearcat BC-785D (Trunktracker III)", "", 15, "1.33 Kg (2.93 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 424, "165*45*200 mm (6.49*1.77*7.87in)", "Bearcat/bearcat_bc760xlt.jpg", "Uniden Bearcat BC-760XLT", "", 15, "950 g (2.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 408, "148*81*209 mm (5.8*3.2*8.2in)", "Bearcat/bc345crs.jpg", "Uniden Bearcat BC-345CRS", "", 15, "560 g (1.24 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 409, "305*102*229 mm (12*4*9in)", "Bearcat/bc350.jpg", "350 (By Electra Company)", "", 15, "3.63 Kg (8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 410, "132*41*174 mm (5.2*1.61*6.85in)", "Bearcat/bc350a.jpg", "Uniden Bearcat BC-350A", "", 15, "766 g (1.69 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 411, "132*41*146 mm (5.19*1.62*5.75in)", "Bearcat/bc355c.jpg", "Uniden Bearcat BC-355C", "", 15, "638 g (1.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 412, "132*41*146 mm (5.19*1.62*5.75in)", "Bearcat/bc355n.jpg", "Uniden Bearcat BC-355N", "", 15, "638 g (1.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 413, "147*81*208 mm (5.8*3.2*8.2in)", "Bearcat/bc365crs.jpg", "Uniden Bearcat BC-365CRS", "", 15, "601 g (1.32 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 414, "209*81*148 mm (8.23*3.19*5.83in)", "Bearcat/bc370crs.jpg", "Uniden Bearcat BC-370CRS", "", 15, "599 g (1.32 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 425, "176*61*167 mm (6.93*2.4*6.58in)", "Bearcat/bc780xlt.jpg", "Uniden Bearcat BC-780XLT (Trunktracker III)", "", 15, "1.33 Kg (2.93 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 415, "? mm (?in)", "Bearcat/bc400xlt.jpg", "Uniden Bearcat BC-400XLT", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 417, "? mm (?in)", "Bearcat/bc550a.jpg", "Uniden Bearcat BC-550A", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 418, "140*44*178 mm (5.5*1.75*7in)", "Bearcat/bc560xlt.jpg", "Uniden Bearcat BC-560XLT", "", 15, "794 g (1.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 419, "64*324*44 mm (2.52*12.76*1.73in), with standard antenna", "Bearcat/bc60xlt.jpg", "Uniden Bearcat BC-60XLT", "", 15, "357 gr (12.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 420, "64*178*38 mm (2.52*7.01*1.5in)", "Bearcat/bearcat_bc60xlt1.jpg", "Uniden Bearcat BC-60XLT1", "", 15, "340 g (12 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 421, "132*41*176 mm (5.2*1.62*6.94in)", "Bearcat/bc700a.jpg", "Uniden Bearcat BC-700A", "", 15, "482 g (1.06 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 422, "70*155*25 mm (2.76*6.1*0.98in)", "Bearcat/bc70xlt.jpg", "Uniden Bearcat BC-70XLT", "", 15, "305 gr (10.76 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 423, "67*115*33 mm (2.64*4.53*1.3in)", "Bearcat/bc75xlt.jpg", "Uniden Bearcat BC-75XLT", "", 15, "175 g (6.17 oz), without antenna and batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 416, "70*170*35 mm (2.76*6.69*1.38in)", "Bearcat/bearcat_bc50xl.jpg", "Uniden Bearcat BC-50XL", "", 15, "298 gr (10.5 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 445, "184*56*154 mm (7.24*2.2*6.06in)", "Bearcat/bct15x.jpg", "Uniden Bearcat BCT-15X (Bear/Trunktracker III)", "", 15, "1.6 Kg (3.53 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 446, "? mm (?in)", "Bearcat/bct7.jpg", "Uniden Bearcat BCT-7 (Beartracker)", "", 15, "? g (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 447, "177*51*153 mm (6.97*2.01*6.02in)", "Bearcat/bct8.jpg", "Uniden Bearcat BCT-8 (Beartracker/Trunktracker III)", "", 15, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 469, "150*75*? mm (5.9*2.95*?in)", "Bearcat/sds200.jpg", "Uniden Bearcat SDS-200E", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 470, "73*178*35 mm (2.87*7.01*1.38in)", "Bearcat/ubc100xl.jpg", "Uniden Bearcat UBC-100XL", "", 15, "375 g (13.23 oz), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 471, "70*190*32 mm (2.75*7.5*1.25in)", "Bearcat/ubc100xlt.jpg", "Uniden Bearcat UBC-100XLT", "", 15, "390 g (13.76 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 472, "65*147*43 mm (2.56*5.79*1.69in)", "Bearcat/ubc105xlt.jpg", "Uniden Bearcat UBC-105XLT", "", 15, "216 g (7.62 oz), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 473, "64*310*45 mm (2.52*12.2*1.77in)", "Bearcat/ubc120xlt.jpg", "Uniden Bearcat UBC-120XLT", "", 15, "357 g (12.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 474, "67*115*33 mm (2.64*4.53*1.3in)", "Bearcat/ubc125xlt.jpg", "Uniden Bearcat UBC-125XLT", "", 15, "175 gr (6.17 oz), without batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 475, "245*60*200 mm (9.6*2.4*7.9in)", "Bearcat/ubc144xlt.jpg", "Uniden Bearcat UBC-144XLT", "", 15, "585 gr (1.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 468, "150*75*? mm (5.9*2.95*?in)", "Bearcat/sds200.jpg", "Uniden Bearcat SDS-200", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 476, "238*60*180 mm (9.37*2.36*7.09in)", "Bearcat/ubc145xl.jpg", "Uniden Bearcat UBC-145XL", "", 15, "730 g (1.61 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 478, "65*297*40 mm (2.56*11.69*1.58in)", "Bearcat/ubc180xlt.jpg", "Uniden Bearcat UBC-180XLT", "", 15, "320 g (11.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 479, "70*190*32 mm (2.75*7.5*1.25in)", "Bearcat/ubc200xlt.jpg", "Uniden Bearcat UBC-200XLT", "", 15, "567 g (1.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 480, "63*311*45 mm (2.48*12.24*1.77in)", "Bearcat/ubc220xlt.jpg", "Uniden Bearcat UBC-220XLT", "", 15, "357 g (12.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 481, "205*68*139 mm (8.07*2.68*5.47in)", "Bearcat/ubc244clt.jpg", "Uniden Bearcat UBC-244CLT", "", 15, "560 gr (1.24 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 482, "70*190*38 mm (2.76*7.48*1.5in)", "Bearcat/ubc2500xlt.jpg", "Uniden Bearcat UBC-2500XLT", "", 15, "390 g (13.76 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 483, "205*139*73 mm (8.07*5.47*2.87in)", "Bearcat/ubc278clt.jpg", "Uniden Bearcat UBC-278CLT", "", 15, "655 gr (1.44 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 484, "? mm (?in)", "Bearcat/ubc280xlt.jpg", "Uniden Bearcat UBC-280XLT \"Sportcat\"", "", 15, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 477, "? mm", "Bearcat/ubc175xl.jpg", "Uniden Bearcat UBC-175XL", "", 15, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 467, "? mm (?in)", "Bearcat/sds100.jpg", "Uniden Bearcat SDS-100", "", 15, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 466, "74*117*36 mm (2.9*4.6*1.4in)", "Bearcat/sc230.jpg", "Uniden Bearcat SC-230 (NASCAR scanner)", "", 15, "222 g (7.84 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 465, "65*296*40 mm (2.5*11.75*1.75in), with antenna", "Bearcat/sc200.jpg", "Uniden Bearcat SC-200 (Sportcat)", "", 15, "320 g (11.3 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 448, "229*102*165 mm (9*4*6.5in)", "Bearcat/bearcat.jpg", "/  I (By Electra Company)", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 449, "229*93*184 mm (9*3.68*7.25in)", "Bearcat/bearcat_101.jpg", "101 (By Electra Company)", "", 15, "2.84 Kg (6.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 450, "? mm", "Bearcat/bearcat_12.jpg", "12 (By Electra Company)", "", 15, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 451, "235*73*222 mm (9.25*2.88*8.75in)", "Bearcat/bearcat_5.jpg", "5 (By Electra Company)", "", 15, "1.36 Kg (3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 452, "229*102*203 mm (9*4*8in)", "Bearcat/bearcat_6.jpg", "6 (By Electra Company)", "", 15, "1.81 Kg (4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 453, "241*93*181 mm (9.5*3.68*7.12in)", "Bearcat/bearcat_8.jpg", "8 (By Electra Company)", "", 15, "2.38 Kg (5.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 454, "229*102*173 mm (9*4*6.81in)", "Bearcat/bearcat_ii.jpg", "series 2 /  II (By Electra Company)", "", 15, "1.81 Kg (4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 455, "229*93*155 mm (9*3.68*6.12in)", "Bearcat/bearcat_iii.jpg", "III (By Electra Company)", "", 15, "2.27 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 456, "229*92*155 mm (9*3.62*6.12in)", "Bearcat/bearcat_iv.jpg", "IV (By Electra Company)", "", 15, "2.27 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 457, "185*56*205 mm (7.28*2.2*8.1in)", "Bearcat/beartracker885.jpg", "Uniden Beartracker 885", "", 15, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 458, "? mm (?in)", "Bearcat/br330t.jpg", "Uniden NASCAR BR-330T (Trunktracker III)", "", 15, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 459, "? mm", "Bearcat/compuscancp2100.jpg", "CompuScan CP-2100", "", 15, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 460, "370*130*240 mm (14.57*5.12*9.45in)", "Bearcat/dx1000.jpg", "DX-1000 (By Electra Company)", "", 15, "8 Kg (17.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 461, "149*84*38 mm (5.87*3.31*1.5in)", "Bearcat/homepatrol1.jpg", "Uniden HomePatrol-1 (Trunktracker)", "", 15, "300 g (10.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 462, "201*147*48 mm (7.9*5.8*1.9in)", "Bearcat/mr8100.jpg", "Uniden MR-8100", "", 15, "952 gr (2.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 463, "64*311*44 mm (2.5*12.25*1.75in), with antenna", "Bearcat/sc150.jpg", "Uniden Bearcat SC-150 (Sportcat)", "", 15, "349 g (12.32 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 464, "65*296*40 mm (2.5*11.75*1.75in), with antenna", "Bearcat/sc180.jpg", "Uniden Bearcat SC-180 (Sportcat)", "", 15, "320 g (11.3 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 407, "209*81*148 mm(8.23*3.19*5.83in)", "Bearcat/bc340crs.jpg", "Uniden Bearcat BC-340CRS", "", 15, "626 g (1.38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 485, "69*187*38 mm (2.72*7.36*1.5in)", "Bearcat/ubc3000xlt.jpg", "Uniden Bearcat UBC-3000XLT", "", 15, "370 g (13 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 406, "69*187*38 mm (2.72*7.36*1.5in)", "Bearcat/bearcat_bc3000xlt.jpg", "Uniden Bearcat BC-3000XLT", "", 15, "370 g (13 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 404, "65*153*45 mm (2.56*6.02*1.77in)", "Bearcat/bc296d.jpg", "Uniden Bearcat BC-296D (Trunktracker IV)", "", 15, "350 g (12.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 347, "Radio unit: 140*46*150 mm (5.5*1.8*6in)Control head: 157*66*34 mm (6.3*2.6*1.34in)", "Baofeng/uv50x3.jpg", "/Btech UV-50X3", @"2 mHi: 50 W, Mid: 20 W, Lo: 5 W


1.25 mHi: 5 W, Mid: 5 W, Lo: 5 W


70 cmHi: 50 W, Mid: 20 W, Lo: 5 W", 12, "Radio unit: 2.1 Kg (4.6 lbs)Control head: ? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 348, "58*110*32 mm (2.28*4.33*1.26in)", "Baofeng/uv5r.jpg", "UV-5R", @"2 mHi: 4 W, Lo: 1 W


70 cmHi: 4 W, Lo: 1 W", 12, "130 g (4.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 349, "60*120*30 mm (2.36*4.71*1.18in)", "Baofeng/uv5rex.jpg", "UV-5R EX", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "210 g (7.41 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 350, "60*112*35 mm (2.36*4.41*1.38in)", "Baofeng/uv5rpro.jpg", "UV-5R Pro", "Hi: 8 W, Lo: ? W", 12, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 351, "52*100*32 mm (2.05*3.94*1.26in)", "Baofeng/uv5rtp.jpg", "UV-5RTP", @"2 mHi: 8 W, Mid: 4 W, Lo: 1 W


70 cmHi: 8 W, Mid: 4 W, Lo: 1 W", 12, "250 g (8.82 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 352, "58*110*32 mm (2.28*4.33*1.26in)", "Baofeng/uv5rx3.jpg", "UV-5RX3", @"2 mHi: 5 W, Lo: 1 W


1.25 mHi: 4 W, Lo: 1 W


70 cmHi: 4 W, Lo: 1 W", 12, "214 g (7.55 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 353, "58*110*32 mm (2.28*4.33*1.26in)", "Baofeng/uv5x3.jpg", "/Btech UV-5X3", @"2 mHi: 5 W, Lo: 1 W


1.25 mHi: 4 W, Lo: 1 W


70 cmHi: 4 W, Lo: 1 W", 12, "214 gr (7.55 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 346, "47*81*23 mm (1.85*3.19*0.9in)", "Baofeng/uv3rmk2_colors.jpg", "UV-3R MkII", @"2 mHi: 2 W, Lo: 1 W


70 cmHi: 2 W, Lo: 1 W", 12, "130 gr (4.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 354, "? mm (?in)", "Baofeng/uv6r.jpg", "UV-6R", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 356, "", "BC/pcselectronics_ammaxiidsp.jpg", "PCS Electronics AM Max II DSP", "4-15 W carrier (16-60 W peak)", 13, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 357, "? mm", "BC/ramsey_am1.jpg", "Ramsey AM-1", "100 mW", 13, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 358, "126*38*133 mm", "BC/ramsey_am25.jpg", "Ramsey AM-25", "Hi: 1-4 W (depending on voltage)Lo: 50-150 mW (depending on voltage)", 13, "240 gr (with case)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 359, "? mm", "BC/ramsey_fm100b.jpg", "Ramsey FM-100B", "? mW", 13, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 360, "? mm", "BC/ramsey_fm100b.jpg", "Ramsey FM-100B Export", "1 W", 13, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 361, "? mm", "BC/ramsey_fm10a.jpg", "Ramsey FM-10A", "10 mW", 13, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 362, "? mm", "BC/ramsey_fm25b.jpg", "Ramsey FM-25B", "? mW", 13, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 355, "60*130*35 mm (2.36*5.12*1.38in)", "Baofeng/uv82l.jpg", "UV-82L", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "238 g (8.4 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 363, "? mm (?in)", "BC/ramsey_px1.jpg", "Ramsey PX-1", "Max 35 W", 13, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 345, "47*81*23 mm (1.85*3.19*0.9in)", "Baofeng/uv3r.jpg", "UV-3R", @"2 mHi: 2 W, Lo: 1 W


70 cmHi: 2 W, Lo: 1 W", 12, "130 gr (4.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 343, "60*132*35 mm (2.36*5.2*1.38in)", "Baofeng/gt5tp.jpg", "GT-5TP", @"2 mHi: 8 W, Mid: 4 W, Lo: 1 W


70 cmHi: 8 W, Mid: 4 W, Lo: 1 W", 12, "238 g (8.4 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 327, "335*138*350 mm (13.19*5.43*13.78in)", "Bando/technic5d.jpg", "Technic-5D", "50 W", 11, "13.5 Kg (29.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 328, "335*138*350 mm (13.19*5.43*13.78in)", "Bando/technic5s.jpg", "Technic-5S", "50 W", 11, "13.5 Kg (29.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 329, "145*47*190 mm (5.71*1.85*7.48in)", "Baofeng/bf9500.jpg", "/Pofung BF-9500", @"Hi: 50 W
Mid: 20 W
Mid-Lo: 10 W, Lo: 5 W", 12, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 330, "55*108*21 mm (2.16*4.25*0.83in), including antenna", "Baofeng/bft1.jpg", "BF-T1", "Hi: 1 W, Lo: 500 mW", 12, "120 g (4.23 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 331, "52*110*32 mm (2.05*4.33*1.26in)", "Baofeng/dm5r.jpg", "DM-5R", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 332, "52*110*32 mm (2.05*4.33*1.26in)", "Baofeng/dm5rplus.jpg", "DM-5R Plus", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 333, "58*140*32 mm (2.28*5.51*1.26in)", "Baofeng/dm8hx.jpg", "DM-8HX", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 344, "52*110*32 mm (2.05*4.33*1.26in)", "Baofeng/rd5r.jpg", "RD-5R", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "213 g (7.51 oz), with 1800 mAh battery pack and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 334, "58*140*32 mm (2.28*5.51*1.26in)", "Baofeng/dm9hx.jpg", "DM-9HX", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 336, "51*125*25 mm (2*4.92*0.98in)", "Baofeng/gt3.jpg", "GT-3", @"2 mHi: 4 W, Lo: 1 W


70 cmHi: 3 W, Lo: 1 W", 12, "120 g (4.23 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 337, "51*125*25 mm (2*4.92*0.98in)", "Baofeng/gt3mk2.jpg", "GT-3 MkII", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 5 W, Lo: 1 W", 12, "120 g (4.23 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 338, "58*109*36 mm (2.28*4.29*1.42in)", "Baofeng/gt3tp.jpg", "GT-3TP", @"2 mHi: 8 W, Mid: 4 W, Lo: 1 W


70 cmHi: 8 W, Mid: 4 W, Lo: 1 W", 12, "454 g (16 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 339, "58*109*36 mm (2.28*4.29*1.42in)", "Baofeng/gt3tpmkii.jpg", "GT-3TP MkII", @"2 mHi: 8 W, Mid: 4 W, Lo: 1 W


70 cmHi: 8 W, Mid: 4 W, Lo: 1 W", 12, "454 g (16 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 340, "58*109*36 mm (2.28*4.29*1.42in)", "Baofeng/gt3tpmkiii.jpg", "GT-3TP MkIII", @"2 mHi: 8 W, Mid: 4 W, Lo: 1 W


70 cmHi: 8 W, Mid: 4 W, Lo: 1 W", 12, "454 g (16 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 341, "58*110*32 mm (2.28*4.33*1.26in)", "Baofeng/gt3wp.jpg", "GT-3WP", @"2 mHi: 5 W, Mid: 3 W, Lo: 1 W


70 cmHi: 5 W, Mid: 3 W, Lo: 1 W", 12, "510 g (18 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 342, "60*132*35 mm (2.36*5.2*1.38in)", "Baofeng/gt5.jpg", "/Pofung GT-5", @"2 mHi: 5 W, Lo: 1 W


70 cmHi: 4 W, Lo: 1 W", 12, "238 g (8.4 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 335, "? mm (?in)", "Baofeng/gt1.jpg", "GT-1", @"Hi: 2-5 W (depending on voltage)
Lo: ? W", 12, "? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 364, "155*38.1*107 mm (6.1*1.5*4.2in)", "BC/sstran_amt3000.jpg", "SSTRAN AMT-3000", "Max 100 mW (input)", 13, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 365, "155*38.1*107 mm (6.1*1.5*4.2in)", "BC/sstran_amt3000.jpg", "SSTRAN AMT-3000-9K", "Max 100 mW (input)", 13, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 366, "206*38.1*107 mm (8.1*1.5*4.2in)", "BC/sstran_amt5000.jpg", "SSTRAN AMT-5000", "Max 100 mW (input)", 13, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 388, "235*114*178 mm (9.25*4.5*7)", "Bearcat/bc210xw.jpg", "Uniden Bearcat 210XW", "", 15, "3.13 Kg (6.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 389, "270*89*203 mm (10.62*3.5*8in)", "Bearcat/bc211.jpg", "211 (By Electra Company)", "", 15, "2.27 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 390, "265*75*195 mm (10.43*2.95*7.68in)", "Bearcat/bearcat_bc220.jpg", "220 (By Electra Company)", "", 15, "2.4 Kg (5.29 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 391, "265*75*195 mm (10.4*2.95*7.7in)", "Bearcat/bearcat_bc220fb.jpg", "220FB (By Electra Company)", "", 15, "2.4 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 392, "64*152*43 mm (2.5*6*1.7in)", "Bearcat/bearcat_bc220xlt.jpg", "Uniden Bearcat BC-220XLT", "", 15, "368 g (13 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 393, "? mm (?in)", "Bearcat/bc230xlt.jpg", "Uniden Bearcat BC-230XLT", "", 15, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 394, "64*165*44 mm (2.5*6.5*1.75in)", "Bearcat/bearcat_bc235xlt.jpg", "Uniden Bearcat BC-235XLT (Trunktracker)", "", 15, "357 g (12.6 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 387, "269*89*203 mm (10.6*3.5*8in)", "Bearcat/bc210xlt.jpg", "Uniden Bearcat 210XLT", "", 15, "2.27 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 395, "205*68*139 mm (8.07*2.68*5.47in)", "Bearcat/bc244clt.jpg", "Uniden Bearcat BC-244CLT", "", 15, "560 gr (1.24 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 397, "69*117*32 mm (2.72*4.6*1.26in)", "Bearcat/bc246t.jpg", "Uniden Bearcat BC-246T (Trunktracker III)", "", 15, "218 g (7.68 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 398, "205*73*139 mm (8.07*2.87*5.47in)", "Bearcat/bc248clt.jpg", "Uniden Bearcat BC-248CLT", "", 15, "625 gr (1.38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 399, "273*89*203 mm (10.75*3.5*7.99in)", "Bearcat/bc250.jpg", "BC-250 (By Electra Company)", "", 15, "2.3 Kg (5.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 400, "65*153*45 mm (2.56*6.02*1.77in)", "Bearcat/bc250d.jpg", "Uniden Bearcat BC-250D", "", 15, "350 g (12.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 401, "273*89*203 mm (10.75*3.5*7.99in)", "Bearcat/bc250.jpg", "BC-250FB (By Electra Company)", "", 15, "2.3 Kg (5.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 402, "165*127*190 mm (6.5*5*7.5in)", "Bearcat/bc260.jpg", "/ Uniden  BC-260", "", 15, "1.81 Kg (4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 403, "205*139*73 mm (8.07*5.47*2.87in)", "Bearcat/bc278clt.jpg", "Uniden Bearcat BC-278CLT", "", 15, "655 gr (1.44 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 396, "64*152*44 mm (2.52*5.98*1.73in)", "Bearcat/bc245xlt.jpg", "Uniden Bearcat BC-245XLT (Trunktracker II)", "", 15, "312 g (11.01 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 386, "267*89*203 mm (10.5*3.5*8in)", "Bearcat/bc210xl.jpg", "210XL (By Electra Company)", "", 15, "2.27 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 385, "229*89*178 mm (9*3.5*7in)", "Bearcat/bc210.jpg", "210 (By Electra Company)", "", 15, "2.04 Kg (4.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 384, "70*190*32 mm (2.75*7.5*1.25in)", "Bearcat/bc205xlt.jpg", "Uniden Bearcat BC-205XLT", "", 15, "567 g (1.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 367, "206*38.1*107 mm (8.1*1.5*4.2in)", "BC/sstran_amt5000.jpg", "SSTRAN AMT-5000-9K", "Max 100 mW (input)", 13, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 368, "76*178*38 mm (2.99*7.01*1.5in)", "Bearcat/bc100.jpg", "BC-100 (By Electra Company)", "", 15, "453 g (15.98 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 369, "76*178*38 mm (2.99*7.01*1.5in)", "Bearcat/bc100.jpg", "BC-100FB (By Electra Company)", "", 15, "453 g (15.98 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 370, "74*178*37 mm (2.9*7*1.44in)", "Bearcat/bc100xl.jpg", "Uniden Bearcat BC-100XL", "", 15, "567 g (1.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 371, "70*190*32 mm (2.75*7.5*1.25in)", "Bearcat/bc100xlt.jpg", "Uniden Bearcat BC-100XLT", "", 15, "567 g (1.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 372, "64*311*44 mm (2.52*12.24*1.73in), with standard antenna", "Bearcat/bearcat_bc120xlt.jpg", "Uniden Bearcat BC-120XLT", "", 15, "354 g (12.49 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 373, "248*66*203 mm (9.75*2.6*8in)", "Bearcat/bc142xl.jpg", "Uniden Bearcat BC-142XL", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 374, "241*64*181 mm (9.5*2.5*7.12in)", "Bearcat/bc145xl.jpg", "Uniden Bearcat BC-145XL", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 375, "229*70*165 mm (9*2.75*6.5in)", "Bearcat/bc147xlt_led.jpg", "Uniden Bearcat BC-147XLT", "", 15, "544 g (1.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 376, "? mm", "Bearcat/bc150.jpg", "150 (By Electra Company)", "", 15, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 377, "? mm (?in)", "Bearcat/bc160.jpg", "160 (By Electra Company)", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 378, "? mm", "Bearcat/bc170.jpg", "Uniden Bearcat BC-170", "", 15, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 379, "? mm (?in)", "Bearcat/bc180.jpg", "180 (By Electra Company)", "", 15, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 380, "229*76*241 mm (9*3*9.5in)", "Bearcat/bc200.jpg", "200 (By Electra Company)", "", 15, "1.59 Kg (3.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 381, "70*190*32 mm (2.75*7.5*1.25in)", "Bearcat/bc200xlt.jpg", "Uniden Bearcat BC-200XLT", "", 15, "567 g (1.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 382, "270*89*203 mm (10.62*3.5*8in)", "Bearcat/bc2020.jpg", "BC-20/20 (By Electra Company)", "", 15, "2.27 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 383, "270*89*203 mm (10.62*3.5*8in)", "Bearcat/bc2020fb.jpg", "BC-20/20FB (By Electra Company)", "", 15, "2.27 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 405, "311*93*178 mm (12.25*3.68*7", "Bearcat/bc300.jpg", "300 (By Electra Company)", "", 15, "2.95 Kg (6.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 326, "330*150*330 mm (12.99*5.91*12.99in)", "Bando/technic4s.jpg", "Technic-4S", "50 W", 11, "14 Kg (30.86 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 486, "53*104*28 mm (2.09*4.09*1.1in)", "Bearcat/ubc30xlt.jpg", "Uniden UBC-30XLT", "", 15, "100 gr (3.53 oz), without antennna & battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 488, "61*130*31 mm (2.4*5.12*1.22in)", "Bearcat/ubc3500xlt.jpg", "Uniden UBC-3500XLT", "", 15, "183 g (6.45 oz), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 590, "120*40*190 mm (4.72*1.58*7.48in)", "Commander/190.jpg", "190 (CMD-190)", "", 20, "850 g (1.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 591, "140*50*190 mm (5.51*1.97*7.48in)", "Commander/193.jpg", "193", "", 20, "940 g (2.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 592, "120*40*190 mm (4.72*1.58*7.48in)", "Commander/2320.jpg", "2320", "", 20, "810 gr (1.78 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 593, "130*35*150 mm (5.12*1.38*5.91in)", "Commander/316.jpg", "316", "", 20, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 594, "130*35*150 mm (5.12*1.38*5.91in)", "Commander/317.jpg", "317", "", 20, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 595, "193*64*205 mm (7.6*2.52*8.07in)", "Commander/318.jpg", "318", "", 20, "2.03 Kg (4.48 lb), with mobile bracket" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 596, "132*27*169 mm (5.2*1.06*6.65in)", "Commander/320.jpg", "320", "", 20, "420 g (14.8 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 589, "94*66*208 mm (3.7*2.6*8.19in)", "Commander/168.jpg", "168", "", 20, "2 Kg (4.41 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 597, "265*70*265 mm (10.43*2.76*10.43in)", "Commander/328.jpg", "328", "", 20, "3.3 Kg (7.27 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 599, "225*60*260 mm (8.86*2.36*10.24in)", "Commander/334.jpg", "334 \"Police monitor\"", "", 20, "3 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 600, "154*60*211 mm (6.06*2.36*8.31in)", "Commander/450.jpg", "450", "", 20, "1.12 Kg (2.47 lb), with mounting bracket" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 601, "140*50*190 mm (5.51*1.97*7.48in)", "Commander/500.jpg", "500", "", 20, "920 g (2.03 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 602, "132*37*169 mm (5.2*1.46*6.65in)", "Commander/530.jpg", "530", "", 20, "450 gr (15.87 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 603, "? mm (?in)", "Commander/cd3000ar.jpg", "CD-3000 AR", "", 20, "1.1 Kg (2.42 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 604, "? mm (?in)", "Commander/commander_134o.jpg", "134-O", "", 20, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 605, "90*50*140 mm (3.54*1.97*5.51in)", "Commander/commander_137.jpg", "137", "", 20, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 598, "132*32*146 mm (5.2*1.26*5.75in)", "Commander/330.jpg", "330", "", 20, "765 g (1.69 lb), with mounting bracket" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 606, "? mm", "Commander/commander_155.jpg", "155", "", 20, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 588, "90*50*140 mm (3.54*1.97*5.51in)", "Commander/155.jpg", "155", "", 20, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 586, "155*57*210 mm (6.1*2.24*8.27in)", "Commander/134o.jpg", "134-O", "", 20, "1.65 Kg (3.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 570, "483*44*500 mm (19.02*1.73*19.69in)", "Collins/collins_95s1a.jpg", "95S-1A", "", 19, "6 Kg (13.23 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 571, "483*133*500 mm (19.02*5.24*19.69in)", "Collins/collins_hf2050.jpg", "HF-2050", "", 19, "18 Kg (39.68 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 572, "483*222*520 mm (19.02*8.74*20.47in)", "Collins/collins_hf8054a.jpg", "HF-8054A", "", 19, "20 Kg (44.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 573, "? mm", "Collins/hf380.jpg", "HF-380", "? W", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 574, "711*1689*457 mm (28*66.5*18in)", "Collins/kw1.jpg", "KW-1", "1 KW (input)", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 575, "? mm", "Collins/kwm1.jpg", "KWM-1", "100 W", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 576, "375*197*356 mm (14.75*7.75*14in)", "Collins/kwm2.jpg", "KWM-2", @"SSB: ~100 W PEP (175 W PEP input)
CW: ~100 W DC (160 W DC input)", 19, "8.35 Kg (18.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 587, "90*50*140 mm (3.54*1.97*5.51in)", "Commander/137.jpg", "137", "", 20, "1.15 Kg (2.54 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 577, "375*197*356 mm (14.75*7.75*14in)", "Collins/kwm2a.jpg", "KWM-2A", @"SSB: ~100 W PEP (175 W PEP input)
CW: ~100 W DC (160 W DC input)", 19, "8.35 Kg (18.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 579, "? mm", "Collins/r388.jpg", "R-388/URR", "", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 580, "483*267*438 mm (19.02*10.51*17.24in)", "Collins/r390.jpg", "R-390/URR", "", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 581, "483*267*438 mm (19.02*10.51*17.24in)", "Collins/r390a.jpg", "R-390A/URR", "", 19, "29.5 Kg (65.04 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 582, "483*267*438 mm (19.02*10.51*17.24in)", "Collins/r391.jpg", "R-391", "", 19, "29.5 Kg (65.04 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 583, "283*293*352 mm (11.14*11.54*13.86in)", "Collins/r392urr.jpg", "R-392/URR", "", 19, "23.7 Kg (52.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 584, "320*260*120 mm (12.6*10.24*4.72in)", "Commander/170.jpg", "170 (122-170)", "", 20, "3 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 585, "155*57*210 mm (6.1*2.24*8.27in)", "Commander/134b.jpg", "134-B", "", 20, "1.65 Kg (3.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 578, "394*190*457 mm (15.51*7.48*17.99in)", "Collins/kwm380.jpg", "Rockwell/Collins KWM-380", "Max 100 W", 19, "27.2 Kg (59.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 607, "94*66*208 mm (3.7*2.6*8.19in)", "Commander/commander_168.jpg", "168", "", 20, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 608, "120*40*190 mm (4.72*1.58*7.48in)", "Commander/commander_190.jpg", "190", "", 20, "850 gr (1.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 609, "140*50*190 mm (5.51*1.97*7.48in)", "Commander/commander_193.jpg", "193", "", 20, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 631, "38*49*? mm", "Dabdrm/rokemanorresearch_pocketdab.jpg", "Roke Manor Research Pocket DAB", "", 21, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 632, "190*260*130 mm", "Dabdrm/roberts_rd1.jpg", "Roberts RD-1 (Gemini 1)", "", 21, "1.74 Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 633, "200*200*125 mm", "Dabdrm/roberts_rd2.jpg", "Roberts RD-2 (Gemini 2)", "", 21, "1.68 Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 634, "? mm", "Dabdrm/roberts_rd3.jpg", "Roberts RD-3 (Gemini 3)", "", 21, "1.32 Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 635, "65*110*20 mm", "Dabdrm/roberts_rd4.jpg", "Roberts RD-4 (Gemini 4 Sports)", "", 21, "160 gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 636, "? mm", "Dabdrm/sangean_classic2000.jpg", "Sangean Classic 2000", "", 21, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 637, "? mm", "Dabdrm/sangean_ddr3.jpg", "Sangean DDR3", "", 21, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 630, "65*120*20 mm", "Dabdrm/puredigital_pocketdab.jpg", "Pure Pocket DAB", "", 21, "180 gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 638, "? mm", "Dabdrm/sangean_dpr1.jpg", "Sangean DPR1", "", 21, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 640, "180*260*90 mm", "Dabdrm/sangean_drm40.jpg", "Sangean DRM-40", "", 21, "1.7 Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 641, "? mm", "Dabdrm/zoopad_anima.jpg", "Zoopad Anima", "", 21, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 642, "120*40*180 mm (4.72*1.58*7.09in)", "DLS/dls_160.jpg", "-160", "", 22, "650 g (1.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 643, "120*40*180 mm (4.72*1.58*7.09in)", "DLS/dls_200c.jpg", "200C", "", 22, "500 g (1.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 644, "74*175*37 mm (2.91*6.89*1.46in)", "DLS/dls_40.jpg", "-40", "", 22, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 645, "152*55*180 mm (5.98*2.16*7.09in)", "DLS/dls_400.jpg", "-400", "", 22, "700 g (1.54 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 646, "270*95*230 mm (10.63*3.74*9.06in)", "DLS/dls_70.jpg", "-70", "", 22, "3.1 Kg (6.84 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 639, "? mm", "Dabdrm/sangean_dpr2.jpg", "Sangean DPR2", "", 21, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 629, "210*175*110 mm", "Dabdrm/puredigital_evoke1elgar.jpg", "Pure Evoke-1 Elgar", "", 21, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 628, "88*69*24 mm", "Dabdrm/perstel_dr201.jpg", "Personal Telecom DR-201", "", 21, "40 gr (without batteries)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 627, "69*88*22 mm", "Dabdrm/perstel_dr101.jpg", "Personal Telecom DR-101", "", 21, "40 gr (without batteries)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 610, "120*40*190 mm (4.72*1.58*7.48in)", "Commander/commander_2320.jpg", "2320", "", 20, "810 gr (1.78 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 611, "130*35*150 mm (5.12*1.38*5.91in)", "Commander/commander_316.jpg", "316", "", 20, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 612, "130*35*150 mm (5.12*1.38*5.91in)", "Commander/commander_317.jpg", "317", "", 20, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 613, "? mm (?in)", "Commander/318.jpg", "318", "", 20, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 614, "132*27*169 mm (5.2*1.06*6.65in)", "Commander/commander_320.jpg", "320", "", 20, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 615, "265*70*265 mm (10.43*2.76*10.43in)", "Commander/commander_328.jpg", "328", "", 20, "3.3 Kg (7.27 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 616, "132*32*146 mm (5.2*1.26*5.75in)", "Commander/commander_330.jpg", "330", "", 20, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 617, "225*60*260 mm (8.86*2.36*10.24in)", "Commander/commander_334.jpg", "334 \"Police monitor\"", "", 20, "3 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 618, "150*63*200 mm (5.91*2.48*7.87in)", "Commander/commander_450.jpg", "450", "", 20, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 619, "140*50*190 mm (5.51*1.97*7.48in)", "Commander/commander_500.jpg", "500", "", 20, "920 gr (2.03 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 620, "132*37*169 mm (5.2*1.46*6.65in)", "Commander/commander_530.jpg", "530", "", 20, "450 gr (15.87 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 621, "142*54*192 mm (5.59*2.13*7.56in)", "Commander/commander_microcompu170.jpg", "Micro Compu 170", "", 20, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 622, "142*54*192 mm (5.59*2.13*7.56in)", "Commander/microcompu170.jpg", "Micro Compu 170", "", 20, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 623, "110*60*30 mm", "Dabdrm/codingtechnologies_digitalworldtraveller.jpg", "Coding Technologies Digital World Traveller", "", 21, "110 gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 624, "220*147*28 mm", "Dabdrm/grundig_digiboy.jpg", "Grundig Digiboy", "", 21, "550 gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 625, "210*70*130 mm", "Dabdrm/mayah_drm2010.jpg", "Mayah DRM-2010", "", 21, "650 gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 626, "? mm", "Dabdrm/ministryofsound_dr011.jpg", "Ministry of Sound DR-011", "", 21, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 569, "? mm", "Collins/851s1.jpg", "/Rockwell 851S-1", "", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 487, "65*153*45 mm (2.56*6.02*1.77in)", "Bearcat/ubc3300xlt.jpg", "Uniden Bearcat UBC-3300XLT", "", 15, "350 g (12.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 568, "? mm", "Collins/451s1.jpg", "/Rockwell 451S-1", "", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 566, "375*197*317 mm (14.76*7.76*12.48in)", "Collins/75s3b.jpg", "75S-3B", "", 19, "9.1 Kg (20.06 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 509, "71*161*37 mm (2.8*6.34*1.46in)", "Bearcat/ubcd3600xlt.jpg", "Uniden UBCD-3600XLT (Trunktracker V)", "", 15, "349 g (12.3 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 510, "61*136*31 mm (2.4*5.35*1.22in)", "Bearcat/ubcd396t.jpg", "Uniden UBCD-396T (Trunktracker IV)", "", 15, "260 gr (9.17 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 511, "177*51*154 mm (6.97*2.01*6.06in)", "Bearcat/ubct8.jpg", "Uniden Bearcat UBCT-8 (Trunktracker III)", "", 15, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 512, "72*138*34 mm (2.84*5.43*1.34in)", "Bearcat/usc230.jpg", "Uniden USC-230", "", 15, "179 g (6.31 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 513, "? mm", "Belcom/kappa15.jpg", "Kappa-15", "10 W", 16, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 514, "220*70*250 mm (8.66*2.76*9.84in)", "Belcom/liner10.jpg", "Liner 10", "Max 10 W (PEP)", 16, "3 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 515, "220*70*250 mm (8.66*2.76*9.84in)", "Belcom/liner2.jpg", "Liner 2", "Max 10 W (PEP)", 16, "3 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 508, "68*115*32 mm (2.68*4.53*1.26in)", "Bearcat/ubc93xlt.jpg", "Uniden UBC-93XLT", "", 15, "165 g (5.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 516, "? mm (?in)", "Belcom/liner2dx.jpg", "Liner 2 DX", "Max ? W (PEP)", 16, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 518, "? mm", "Belcom/ls102.jpg", "LS-102", "Hi: ? W, Lo: ? W", 16, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 519, "62*165*40 mm (2.44*6.5*1.58in)", "Belcom/ls202e.jpg", "LS-202E", @"Hi: 3.5 W @ 10.8 VDC
Hi: 2.5 W @ 9 VDC
Hi: 1.5 W @ 7.2 VDC
Lo: 0.5 W @ 9 VDC", 16, "500 g (1.1 lb), with batteries and rubber antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 520, "? mm", "Belcom/ls20f.jpg", "LS-20F", "Hi: 10 W, Lo: 1 W", 16, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 521, "69*140*26 mm (2.72*5.51*1.02in)", "Belcom/ls20xe.jpg", "LS-20XE", "Hi: 1 WMid: 500 mW, Lo: 100 mW", 16, "260 gr (9.17 oz), including batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 522, "? mm", "Belcom/ls602.jpg", "LS-602", "? W", 16, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 523, "? mm (?in)", "Braun/rx420.jpg", "RX-420 dig", "", 17, "? g (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 524, "210*68*220 mm (8.27*2.68*8.66in)", "Braun/se280.jpg", "SE-280", "10 W", 17, "2.2 Kg (4.85 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 517, "280*110*355 mm (11.02*4.33*13.98in)", "Belcom/liner70a.jpg", "Liner 70A", @"AM: Max 4 W
FM/SSB/CW: Max 10 W", 16, "11.5 Kg (25.35 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 525, "220*70*235 mm (8.67*2.76*9.25in)", "Braun/se285.jpg", "SE-285", "10 W", 17, "2.3 Kg (5.07 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 507, "68*115*32 mm (2.68*4.53*1.26in)", "Bearcat/ubc92xlt.jpg", "Uniden UBC-92XLT", "", 15, "165 g (5.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 505, "229*60*190 mm (9*2.38*7.5in)", "Bearcat/ubc860xlt.jpg", "Uniden Bearcat UBC-860XLT", "", 15, "626 gr (1.38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 489, "132*42*142 mm (5.2*1.65*5.59in)", "Bearcat/ubc355clt.jpg", "Uniden Bearcat UBC-355CLT", "", 15, "640 g (1.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 490, "209*81*148 mm (8.23*3.19*5.83in)", "Bearcat/ubc360clt.jpg", "Uniden Bearcat UBC-360CLT", "", 15, "600 g (1.32 lbs), without batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 491, "209*81*148 mm (8.23*3.19*5.83in)", "Bearcat/ubc370clt.jpg", "Uniden Bearcat UBC-370CLT", "", 15, "600 g (1.32 lbs), without batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 492, "64*165*40 mm (2.52*6.5*1.58in)", "Bearcat/ubc57xlt.jpg", "Uniden Bearcat UBC-57XLT", "", 15, "275 g (9.7 oz), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 493, "64*180*40 mm (2.52*7.09*1.58in)", "Bearcat/ubc60xlt1.jpg", "Uniden Bearcat UBC-60XLT1", "", 15, "340 g (12 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 494, "? mm (?in)", "Bearcat/ubc61xlt.jpg", "Uniden Bearcat UBC-61XLT", "", 15, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 495, "66*178*35 mm (2.6*7*1.37in)", "Bearcat/ubc65xlt.jpg", "Uniden Bearcat UBC-65XLT", "", 15, "390 g (13.76 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 506, "267*85*190 mm (10.51*3.35*7.48in)", "Bearcat/ubc9000xlt.jpg", "Uniden Bearcat UBC-9000XLT", "", 15, "1.82 Kg (4.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 496, "64*178*38 mm (2.52*7.01*1.5in)", "Bearcat/ubc68xlt.jpg", "Uniden Bearcat UBC-68XLT", "", 15, "340 gr (11.99 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 498, "68*115*32 mm (2.68*4.53*1.26in)", "Bearcat/ubc69xlt2.jpg", "Uniden Bearcat UBC-69XLT2", "", 15, "165 g (5.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 499, "68*115*32 mm (2.68*4.53*1.26in)", "Bearcat/ubc72xlt.jpg", "Uniden UBC-72XLT", "", 15, "165 g (5.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 500, "165*45*200 mm (6.49*1.77*7.87in)", "Bearcat/ubc760xlt.jpg", "Uniden Bearcat UBC-760XLT", "", 15, "950 gr (2.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 501, "177*72*195 mm (6.97*2.84*7.68in)", "Bearcat/ubc780xlt.jpg", "Uniden Bearcat UBC-780XLT (Trunktracker III)", "", 15, "1.33 Kg (2.93 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 502, "177*69*168 mm (6.97*2.72*6.61in)", "Bearcat/ubc785xlt.jpg", "Uniden Bearcat UBC-785XLT", "", 15, "1.33 Kg (2.93 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 503, "184*56*151 mm (7.24*2.2*5.94in)", "Bearcat/ubc800xlt.jpg", "Uniden Bearcat UBC-800XLT (Trunktracker III)", "", 15, "1.57 Kg (3.46 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 504, "64*178*38 mm (2.5*7*1.5in)", "Bearcat/ubc80xlt.jpg", "Uniden Bearcat UBC-80XLT", "", 15, "340 g (12 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 497, "68*115*32 mm (2.68*4.53*1.26in)", "Bearcat/ubc69xlt.jpg", "Uniden Bearcat UBC-69XLT", "", 15, "165 g (5.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 526, "215*68*230 mm (8.46*2.68*9.06in)", "Braun/se300.jpg", "SE-300", "10 W (PEP)", 17, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 527, "307*117*260 mm (12.1*4.6*10.2in)", "Braun/se400.jpg", "SE-400 dig", "Max 10 W", 17, "7.3 Kg (16.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 528, "305*120*270 mm (12*4.72*10.63in)", "Braun/se401.jpg", "SE-401 dig", @"FM/CW: 10 W
SSB: Max 10 W (PEP)", 17, "7.3 Kg (16 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 550, "? mm", "Collins/32v1.jpg", "32V-1", "CW: 150 W (input)AM: 120 W (input)", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 551, "? mm", "Collins/32v2.jpg", "32V-2", "CW: 150 W (input)AM: 120 W (input)", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 552, "? mm", "Collins/32v3.jpg", "32V-3", "CW: 150 W (input)AM: 120 W (input)", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 553, "536*318*352 mm (21.1*12.52*13.86in)", "Collins/51j.jpg", "51J-1", "", 19, "25 Kg (55.12 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 554, "536*317*333 mm (21.1*12.48*13.11in)", "Collins/51j3.jpg", "51J-3", "", 19, "19.5 Kg (42.99 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 555, "536*317*333 mm (21.1*12.48*13.11in)", "Collins/51j4.jpg", "51J-4", "", 19, "24.9 Kg (54.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 556, "343*254*254 mm (13.5*10*10in)", "Collins/51q.jpg", "51-Q", "", 19, "13.61 Kg (30 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 549, "375*197*318 mm (14.75*7.75*12.5in)", "Collins/32s3.jpg", "32S-3", "100 W", 19, "7.26 Kg (16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 557, "375*167*332 mm (14.8*6.6*13.1in)", "Collins/51s1.jpg", "51S-1", "", 19, "11.8 Kg (26 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 559, "536*311*352 mm (21.1*12.24*13.86in)", "Collins/75a1.jpg", "75A-1", "", 19, "25.8 Kg (56.88 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 560, "559*318*338 mm (22*12.5*13.3in)", "Collins/75a2.jpg", "75A-2", "", 19, "31.75 Kg (70 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 561, "536*317*333 mm (21.1*12.48*13.11in)", "Collins/75a3.jpg", "75A-3", "", 19, "22.7 Kg (50.04 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 562, "432*266*381 mm (17.01*10.47*15in)", "Collins/75a4.jpg", "75A-4", "", 19, "16 Kg (35.27 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 563, "374*169*292 mm (14.75*6.6*11.5in)", "Collins/75s1.jpg", "75S-1", "", 19, "9.1 Kg (20 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 564, "374*169*292 mm (14.72*6.65*11.5in)", "Collins/75s2.jpg", "75S-2", "", 19, "9 Kg (19.84 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 565, "374*169*292 mm (14.72*6.65*11.5in)", "Collins/75s3.jpg", "75S-3", "", 19, "9 Kg (19.84 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 558, "? mm", "Collins/651s1.jpg", "651S-1", "", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 548, "? mm", "Collins/32s1.jpg", "32S-1", "? W", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 547, "? mm", "Collins/310b1.jpg", "310B-1", "15 W", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 546, "? mm", "Collins/30k1.jpg", "310A-3 / 30K-1", "CW: 500 W (input)AM: 375 W (input)", 19, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 529, "305*120*270 mm (12*4.72*10.63in)", "Braun/se402.jpg", "SE-402 dig", "Max 10 W", 17, "7.3 Kg (16 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 530, "420*160*260 mm (16.54*6.3*10.24in)", "Braun/se600dig.jpg", "SE-600 dig", @"AM/FM/CW: 12 W
SSB: 40 W (PEP)", 17, "15.2 Kg (34 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 531, "420*160*260 mm (16.54*6.3*10.24in)", "Braun/se600ana.jpg", "SE-600", @"AM/FM/CW: 12 W
SSB: 40 W (PEP)", 17, "12 Kg (26.46 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 532, "? mm", "Clegg/22er.jpg", "22'er", "20 W (input)", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 533, "? mm", "Clegg/22erfm.jpg", "22'er FM", "60 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 534, "? mm", "Clegg/66er.jpg", "66'er", "10 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 535, "? mm", "Clegg/99er.jpg", "99'er", "~5 W (8 W input)", 18, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 536, "? mm", "Clegg/climaster62t10.jpg", "Climaster 62 T10", "AM: 100 WCW: 140 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 537, "? mm", "Clegg/climasterzeus.jpg", "Climaster Zeus", "AM: 90 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 538, "? mm", "Clegg/fm27b.jpg", "FM-27B", "25 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 539, "? mm", "Clegg/fm76.jpg", "FM-76", "Hi: 10 W, Lo: 1 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 540, "? mm", "Clegg/fm88.jpg", "FM-88", "1-25 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 541, "? mm", "Clegg/fmdx.jpg", "FM-DX", "0.5-35 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 542, "? mm", "Clegg/interceptorb.jpg", "Interceptor B", "", 18, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 543, "250*60*225 mm (9.84*2.36*8.86in)", "Clegg/mark3.jpg", "Mark 3", "Hi: 15 W, Lo: 1 W", 18, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 544, "? mm", "Clegg/thor6.jpg", "Thor 6", "40 W", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 545, "? mm", "Clegg/venus.jpg", "Venus", "AM: 40 WSSB: 120 W PEP (input)", 18, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 567, "375*197*317 mm (14.76*7.76*12.48in)", "Collins/75s3c.jpg", "75S-3C", "", 19, "9.1 Kg (20.06 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 325, "330*145*340 mm (12.99*5.71*13.39in)", "Bando/technic3.jpg", "Technic-3", "100 W", 11, "15 Kg (33.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 324, "? mm", "Bando/technic1a.jpg", "Technic-1A", "50 W", 11, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 323, "210*100*240 mm (8.27*3.94*9.45in)", "Bando/technic12v.jpg", "Technic-12V", "10 W (PEP)", 11, "12.3 Kg (27.12 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 103, "58*99*32 mm (2.28*3.9*1.26in)", "Alinco/djx30.jpg", "DJ-X30T", "", 3, "220 gr (7.76 oz), with EBP57" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 104, "56*102*23 mm (2.2*4.02*0.9in)", "Alinco/djx3s.jpg", "DJ-X3S", "", 3, "? gr (? oz), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 105, "60*110*25 mm (2.36*4.33*0.98in)", "Alinco/djx5.jpg", "DJ-X5", "", 3, "160 gr (5.64 oz), Without batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 106, "58*96*15 mm (2.28*3.78*0.59in)", "Alinco/djx7.jpg", "DJ-X7", "", 3, "103 gr (3.63 oz), with EBP58N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 107, "58*99*32 mm (2.28*3.9*1.26in)", "Alinco/djx8.jpg", "DJ-X8", "", 3, "220 gr (7.76 oz), with EBP57" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 108, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr03t.jpg", "DR-03T", "Hi: 10 WMid: 5 W, Lo: 1 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 109, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr06.jpg", "DR-06T", "Hi: 50 WMid: 20 W, Lo: 5 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 102, "58*99*32 mm (2.28*3.9*1.26in)", "Alinco/djx30.jpg", "DJ-X30E", "", 3, "220 gr (7.76 oz), with EBP57" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 110, "? mm", "Alinco/dr110t.jpg", "DR-110T", "Hi: 45 W, Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 112, "? mm", "Alinco/dr1200.jpg", "DR-1200", "Hi: 25 WMid: ? W, Lo: ? W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 113, "140*40*174 mm (5.51*1.58*6.85in)", "Alinco/dr120.jpg", "DR-120H", "Hi: 50 WMid: 10 W, Lo: 5 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 114, "140*40*155 mm (5.51*1.58*6.1in)", "Alinco/dr130.jpg", "DR-130", "Hi: 50 W, Lo: 5 W", 3, "860 gr (1.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 115, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr135mk2.jpg", "DR-135E MKII", "Hi: 50 WMid: 10 W, Lo: 5 W", 3, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 116, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr135mk2.jpg", "DR-135T MKII", "Hi: 50 WMid: 10 W, Lo: 5 W", 3, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 117, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr135tp.jpg", "DR-135TP", "Hi: 50 WMid: 10 W, Lo: 5 W", 3, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 118, "141*41*154 mm (5.55*1.61*6.06in)", "Alinco/dr140.jpg", "DR-140", "Hi: 50 W, Lo: 5 W", 3, "860 gr (1.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 111, "? mm", "Alinco/dr112.jpg", "DR-112T", "Hi: 45 W, Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 119, "140*40*129 mm (5.51*1.58*5.08in)", "Alinco/dr150.jpg", "DR-150", "Hi: 50 WMid: 25 W, Lo: 10 W", 3, "800 gr (1.76 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 101, "56*102*23 mm (2.2*4.02*0.9in)", "Alinco/djx3.jpg", "DJ-X3", "", 3, "145 gr (with batteries and antenna)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 99, "57*150*28 mm (2.24*5.9*1.1in)", "Alinco/djx20.jpg", "DJ-X20", "", 3, "320 gr (11.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 83, "57*98*28 mm (2.24*3.86*1.1in)", "Alinco/djs45.jpg", "DJ-S45E", "Hi: 2 W (6 VDC), 400 mW (2.4 VDC)Lo: 500 mW (6 VDC), 150 mW (2.4 VDC)", 3, "162 gr (5.71 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 84, "57*98*28 mm (2.24*3.86*1.1in)", "Alinco/djs45.jpg", "DJ-S45T", "Hi: 2 W (6 VDC), 400 mW (2.4 VDC)Lo: 500 mW (6 VDC), 150 mW (2.4 VDC)", 3, "162 gr (5.71 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 85, "58*110*36 mm (2.28*4.33*1.42in)", "Alinco/djs47e.jpg", "DJ-S47E", "Hi: 5 W (@ 13.8 VDC)Lo: 0.8 W", 3, "280 gr (9.88 oz), with antenna and EBP-65" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 86, "53*109*38 mm (2.1*4.3*1.5in)", "Alinco/djs4t.jpg", "DJ-S4T", "Hi: 2-5 W (depending on voltage)Mid: 1 W, Lo: 100 mW", 3, "368 gr (13 oz), with dry battery case" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 87, "58*110*36 mm (2.28*4.33*1.42in)", "Alinco/djv17.jpg", "DJ-V17E", "Hi: 5 W (@ 13.8 VDC)Lo: 0.8 W", 3, "280 gr (9.88 oz), with antenna and EBP-65" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 88, "58*110*36 mm (2.28*4.33*1.42in)", "Alinco/djv17.jpg", "DJ-V17T", "Hi: 5 W (@ 13.8 VDC)Lo: 0.8 W", 3, "280 gr (9.88 oz), with antenna and EBP-65" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 89, "58*110*36 mm (2.28*4.33*1.42in)", "Alinco/djv27.jpg", "DJ-V27", "Hi: 5 W (@ 13.8 VDC)Lo: 0.8 W", 3, "280 gr (9.88 oz), with antenna and EBP-65" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 100, "57*150*28 mm (2.24*5.91*1.1in)", "Alinco/djx2000.jpg", "DJ-X2000", "", 3, "200 gr (7.06 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 90, "58*110*36 mm (2.28*4.33*1.42in)", "Alinco/djv47.jpg", "DJ-V47E", "Hi: 5 W (@ 13.8 VDC)Lo: 0.8 W", 3, "280 gr (9.88 oz), with antenna and EBP-65" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 92, "58*97*40 mm (2.28*3.82*1.58in)", "Alinco/djv5e.jpg", "DJ-V5", "Hi: 1-5/1-5 W (depending on voltage)Lo: 0.5/0.5 W", 3, "335 gr (11.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 93, "58*100*19 mm (2.28*3.94*0.75in)", "Alinco/djx01.jpg", "DJ-X01 \"Wave catcher\"", "", 3, "150 gr (5.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 94, "53*110*37 mm (2.09*4.33*1.46in)", "Alinco/djx1.jpg", "DJ-X1", "", 3, "320 gr (11.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 95, "57*150*28 mm (2.24*5.9*1.1in)", "Alinco/djx10e.jpg", "DJ-X10E", "", 3, "320 gr (11.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 96, "61*106*38 mm (2.4*4.17*1.5in)", "Alinco/djx11.jpg", "DJ-X11E", "", 3, "235 gr (8.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 97, "61*106*38 mm (2.4*4.17*1.5in)", "Alinco/djx11.jpg", "DJ-X11T", "", 3, "235 gr (8.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 98, "58*90*15 mm (2.28*3.54*0.59in)", "Alinco/djx2.jpg", "DJ-X2", "", 3, "85 gr (3 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 91, "58*110*36 mm (2.28*4.33*1.42in)", "Alinco/djv47.jpg", "DJ-V47T", "Hi: 5 W (@ 13.8 VDC)Lo: 0.8 W", 3, "280 gr (9.88 oz), with antenna and EBP-65" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 120, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr235t.jpg", "DR-235T", "Hi: 25 WMid: 10 W, Lo: 5 W", 3, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 121, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr235mk2.jpg", "DR-235T MKII", "Hi: 25 WMid: 10 W, Lo: 5 W", 3, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 122, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr235mk3.jpg", "DR-235T MKIII", "Hi: 25 WMid: 10 W, Lo: 5 W", 3, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 144, "164*44*184 mm (6.44*1.73*7.21in)", "Alinco/drb185he.jpg", "DR-B185HE", "Hi: 85 W, Lo: 5 W", 3, "1.5 Kg (3.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 145, "164*44*184 mm (6.44*1.73*7.21in)", "Alinco/drb185ht.jpg", "DR-B185HT", "Hi: 85 W, Lo: 5 W", 3, "1.5 Kg (3.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 146, "? mm", "Alinco/drm03sx.jpg", "DR-M03SX", "Hi: 10 W, Lo: 1 W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 147, "140*40*115 mm (5.51*1.58*4.53in)", "Alinco/drm06th.jpg", "DR-M06TH", "Hi: 10 W, Lo: 1 W", 3, "760 gr (1.68 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 148, "140*40*154 mm (5.51*1.58*6.06in)", "Alinco/drm10h.jpg", "DR-M10H", "Hi: 50 W, Lo: 5 W", 3, "860 gr (1.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 149, "140*40*154 mm (5.51*1.58*6.06in)", "Alinco/drm40h.jpg", "DR-M40H", "Hi: 35 W, Lo: 5 W", 3, "860 gr (1.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 150, "140*40*176 mm (5.51*1.58*6.93in)", "Alinco/drm50h.jpg", "DR-M50H", "Hi: 50/35 W, Lo: 5/5 W", 3, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 143, "140*60*188 mm (5.5*2.4*7.4in)", "Alinco/dr735t.jpg", "DR-735T", @"2 mHi: 50 W, Mid: 20 W, Lo: 5 W


70 cmHi: 50 W, Mid: 20 W, Lo: 5 W", 3, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 151, "178*58*230 mm (7.01*2.28*9.06in)", "Alinco/dx70.jpg", "DX-70EH", "Hi: 100 W/100 W (AM: 40/40 W)Lo: 10 W/10 W (AM: 4/4 W)", 3, "2.7 Kg (5.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 153, "246*94*228 mm (9.68*3.7*8.98in)", "Alinco/dx77t.jpg", "DX-77T", "Max 100 W", 3, "3.8 Kg (8.38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 154, "240*94*255 mm (9.45*3.7*10in)", "Alinco/dxr8.jpg", "DX-R8E", "", 3, "4.1 Kg (9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 155, "240*94*255 mm (9.45*3.7*10in)", "Alinco/dxr8.jpg", "DX-R8T", "", 3, "4.1 Kg (9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 156, "240*94*255 mm (9.45*3.7*10in)", "Alinco/dxsr8.jpg", "DX-SR8E", @"Hi: 100 W (AM 40 W)
Lo: 10 W (AM 4 W)
S-Lo: 1 W (AM 0.4 W). Internally adjustable between 0.1-2 W.", 3, "4.1 Kg (9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 157, "240*94*255 mm (9.45*3.7*10in)", "Alinco/dxsr8.jpg", "DX-SR8T", @"Hi: 100 W (AM 40 W)
Lo: 10 W (AM 4 W)
S-Lo: 1 W (AM 0.4 W). Internally adjustable between 0.1-2 W.", 3, "4.1 Kg (9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 158, "240*94*255 mm (9.45*3.7*10in)", "Alinco/dxsr9.jpg", "DX-SR9E", @"Hi: 100 W (AM 40 W)
Lo: 10 W (AM 4 W)
S-Lo: 1 W (AM 0.4 W). Internally adjustable between 0.1-2 W.", 3, "4.1 Kg (9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 159, "240*94*255 mm (9.45*3.7*10in)", "Alinco/dxsr9.jpg", "DX-SR9T", @"Hi: 100 W (AM 40 W)
Lo: 10 W (AM 4 W)
S-Lo: 1 W (AM 0.4 W). Internally adjustable between 0.1-2 W.", 3, "4.1 Kg (9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 152, "178*58*230 mm (7.01*2.28*9.06in)", "Alinco/dx70.jpg", "DX-70TH", "Hi: 100 W/100 W (AM: 40/40 W)Lo: 10 W/10 W (AM: 4/4 W)", 3, "2.7 Kg (5.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 142, "140*60*188 mm (5.5*2.4*7.4in)", "Alinco/dr735h.jpg", "DR-735H", @"2 mHi: 50 W, Mid: 20 W, Lo: 5 W


70 cmHi: 50 W, Mid: 20 W, Lo: 5 W", 3, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 141, "140*60*188 mm (5.5*2.4*7.4in)", "Alinco/dr735e.jpg", "DR-735E", @"2 mHi: 50 W, Mid: 20 W, Lo: 5 W


70 cmHi: 50 W, Mid: 20 W, Lo: 5 W", 3, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 140, "140*60*188 mm (5.5*2.4*7.4in)", "Alinco/dr735h.jpg", "DR-735D", @"2 mHi: 20 W, Mid: 10 W, Lo: 5 W


70 cmHi: 20 W, Mid: 10 W, Lo: 5 W", 3, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 123, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr420.jpg", "DR-420H", "Hi: 35 WMid: 10 W, Lo: 5 W", 3, "1.0 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 124, "140*40*154 mm (5.59*1.58*6.06in)", "Alinco/dr430.jpg", "DR-430", "Hi: 50 W, Lo: 5 W", 3, "0.86 Kg (1.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 125, "142*40*174 mm (5.59*1.58*6.85in)", "Alinco/dr435t.jpg", "DR-435T", "Hi: 35 WMid: 10 W, Lo: 5 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 126, "mm", "Alinco/dr510t.jpg", "DR-510T", "Hi: 45/35 W, Lo: ?/? W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 127, "? mm", "Alinco/dr570.jpg", "DR-570T", "Hi: 40/35 W, Lo: ?/? W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 128, "? mm", "Alinco/dr590t.jpg", "DR-590T", "Hi: 45/35 W, Lo: ?/? W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 129, "? mm", "Alinco/dr592.jpg", "DR-592HX", "Hi: ?/? W, Lo: ?/? W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 130, "? mm", "Alinco/dr599.jpg", "DR-599", "Hi: ?/? W, Lo: ?/? W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 131, "140*47*176 mm (5.51*1.85*6.93in)", "Alinco/dr605.jpg", "DR-605E", "Hi: 50/35 W, Lo: 5/5 W", 3, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 132, "140*47*176 mm (5.51*1.85*6.93in)", "Alinco/dr605.jpg", "DR-605T", "Hi: 50/35 W, Lo: 5/5 W", 3, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 133, "? mm", "Alinco/dr610.jpg", "DR-610", "Hi: 50/35 WMid: 10/10 W, Lo: 5/5 W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 134, "140*40*185 mm (5.51*1.58*7.28in)", "Alinco/dr620.jpg", "DR-620D", "Hi: 20/20 WMid: 10/10 W, Lo: 2/2 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 135, "140*40*185 mm (5.51*1.58*7.28in)", "Alinco/dr620.jpg", "DR-620E", @"2 mHi: 50 WMid: 10 W, Lo: 5 W


70 cmHi: 35 WMid: 10 W, Lo: 5 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 136, "140*40*185 mm (5.51*1.58*7.28in)", "Alinco/dr620.jpg", "DR-620T", @"2 mHi: 50 WMid: 10 W, Lo: 5 W


70 cmHi: 35 WMid: 10 W, Lo: 5 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 137, "140*40*185 mm (5.51*1.57*7.28in)", "Alinco/dr635e.jpg", "DR-635E", @"2 mHi: 50 W, Mid: 20 W, Lo: 5 W


70 cmHi: 35 W, Mid: 20 W, Lo: 5 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 138, "140*40*185 mm (5.51*1.57*7.28in)", "Alinco/dr635.jpg", "DR-635T", "Hi: 50/35 WMid: 20/20 W, Lo: 5/5 W", 3, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 139, "139*40*212 mm (5.5*1.6*8.34in)", "Alinco/dr638h.jpg", "DR-638H", @"2 mHi: 50 W, Mid: 25 W, Mid2: 10 W, Lo: 5 W


70 cmHi: 40 W, Mid: 25 W, Mid2: 10 W, Lo: 5 W", 3, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 82, "57*98*28 mm (2.24*3.86*1.1in)", "Alinco/djs42.jpg", "DJ-S42", "Hi: 1 W, Lo: 0.5 W", 3, "162 gr (5.71 oz), with antenna and EBP-60" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 160, "? mm (?in)", "Anytone/at5189.jpg", "AT-5189", "Hi: 25 W, Lo: ? W", 4, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 81, "55*102*28 mm (2.16*4.02*1.1in)", "Alinco/djs41t.jpg", "DJ-S41T", "Hi: 350 mW, Lo: 50 mW", 3, "185 gr (6.53 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 79, "58*110*36 mm (2.28*4.33*1.42in)", "Alinco/djs17e.jpg", "DJ-S17E", "Hi: 5 W (@ 13.8 VDC)Lo: 0.8 W", 3, "280 gr (9.88 oz), with antenna and EBP-65" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 22, "? mm", "Alinco/dj120e.jpg", "DJ-120E", "Hi: 2.5-6 W (depending on voltage)Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 23, "? mm", "Alinco/dj120t.jpg", "DJ-120T", "Hi: 2.5-6 W (depending on voltage)Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 24, "? mm", "Alinco/dj160t.jpg", "DJ-160T", "Hi: 5 W, Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 25, "? mm", "Alinco/dj162.jpg", "DJ-162", "Hi: ? W, Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 26, "58*108*36 mm (2.28*4.25*1.42in)", "Alinco/dj175.jpg", "DJ-175E", "Hi: 5 WMid: 2 W, Lo: 0.5 W", 3, "245 gr (8.64 oz), with battery (EBP-72) and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 27, "58*108*36 mm (2.28*4.25*1.42in)", "Alinco/dj175.jpg", "DJ-175T", "Hi: 5 WMid: 2 W, Lo: 0.5 W", 3, "245 gr (8.64 oz), with battery (EBP-72) and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 28, "58*132*33 mm (2.28*5.2*1.3in)", "Alinco/dj180.jpg", "DJ-180E", "Hi: 2-5 W (Depending on voltage)Lo: ? mW", 3, "350 gr (12.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 21, "? mm", "Alinco/dj100.jpg", "DJ-100", "Hi: 3-6.5 W (Depending on voltage)Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 29, "58*132*33 mm (2.28*5.2*1.3in)", "Alinco/dj180.jpg", "DJ-180T", "Hi: 2-5 W (Depending on voltage)Lo: ? mW", 3, "350 gr (12.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 31, "57*151*27 mm (2.24*5.94*1.06in)", "Alinco/dj191.jpg", "DJ-191T", "1.5-5 W", 3, "300 gr (10.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 32, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj193j.jpg", "DJ-193J", "Hi: 5 W, Lo: ? mW", 3, "320 gr (11.29 oz), with EBP-50N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 33, "? mm", "Alinco/dj195.jpg", "DJ-195", "Hi: ? W, Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 34, "? mm", "Alinco/dj196t.jpg", "DJ-196T", "Hi: 5 W, Lo: ? mW", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 35, "? mm", "Alinco/dj200t.jpg", "DJ-200T", "Hi: 2.5-5 W (Depending on voltage)Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 36, "56*132*33 mm (2.2*5.2*1.3in)", "Alinco/dj280.jpg", "DJ-280T", "Hi: 4 W, Lo: 1 W", 3, "350 gr (12.35 Oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 37, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj296t.jpg", "DJ-296T", "Hi: Up to 5 W (depending on voltage)Lo: 0.8 W", 3, "310 gr (10.93 oz), with EBP50N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 30, "57*151*27 mm (2.24*5.94*1.06in)", "Alinco/dj190.jpg", "DJ-190T", "1.5-5 W", 3, "300 gr (10.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 38, "? mm", "Alinco/dj460t.jpg", "DJ-460T", "Hi: ? W, Lo: ? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 20, "? mm", "Alinco/alx2t.jpg", "ALX-2T", "3 W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 18, "? mm", "Alinco/alr22e.jpg", "ALR-22E", "Hi: 25 W, Lo: ? W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2, "140*40*166 mm (5.51*1.58*6.54in)", "ADI/ar147.jpg", "AR-147", "Hi: 60 WMid: 25 W, Lo: 7 W", 1, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 3, "140*40*166 mm (5.51*1.58*6.54in)", "ADI/ar147e.jpg", "AR-147E", "Hi: 60 WMid: 25 W, Lo: 7 W", 1, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 4, "140*40*166 mm (5.51*1.58*6.54in)", "ADI/ar447.jpg", "AR-447", "Hi: 35 WMid: 15 W, Lo: 7 W", 1, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 5, "? mm", "ADI/at201hp.jpg", "AT-201HP", "Hi: 5 W, Lo: ? W", 1, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 6, "? mm", "ADI/at401hp.jpg", "AT-401HP", "Hi: 5 W, Lo: ? W", 1, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 7, "? mm", "ADI/at600hp.jpg", "AT-600HP", "Hi: 5 W, Lo: ? W", 1, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 8, "140*40*166 mm (5.51*1.58*6.54in)", "ADI/tm281a.jpg", "TM-281A", "Hi: 60 WMid: 25 W, Lo: 7 W", 1, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 19, "? mm", "Alinco/alr22t.jpg", "ALR-22T", "Hi: ? W, Lo: ? W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 9, "185*60*200 mm (7.28*2.36*7.87in)", "AKD/2001.jpg", "2001", "Hi: 25 W, Lo: 5 W", 2, "825 g (1.82 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 11, "185*60*200 mm (7.28*2.36*7.87in)", "AKD/6001.jpg", "6001", "Hi: 25 W, Lo: 5 W", 2, "825 g (1.82 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 12, "185*60*200 mm (7.28*2.36*7.87in)", "AKD/7003.jpg", "7003", "3 W", 2, "825 g (1.82 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 13, "? mm", "Alinco/ald24e.jpg", "ALD-24E", "Hi: 25/25 W, Lo: 5/5 W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 14, "? mm", "Alinco/ald24t.jpg", "ALD-24T", "Hi: 25/25 W, Lo: 5/5 W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 15, "? mm", "Alinco/alm203e.jpg", "ALM-203E", "Hi: 5 W, Lo: 100 mW", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 16, "? mm", "Alinco/alr206t.jpg", "ALR-206T", "Hi: 25 W, Lo: 5 W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 17, "? mm", "Alinco/alr21x.jpg", "ALR-21X", "Hi: 25 W, Lo: 5 W", 3, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 10, "185*60*200 mm (7.28*2.36*7.87in)", "AKD/4001.jpg", "4001", "Hi: 25 W, Lo: 5 W", 2, "825 g (1.82 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 39, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj493j.jpg", "DJ-493J", "Hi: 4 W, Lo: ? mW", 3, "300 gr (10.58 oz), with EBP-50N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 40, "? mm", "Alinco/dj496t.jpg", "DJ-496T", "Hi: 4 W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 41, "? mm", "Alinco/dj500e.jpg", "DJ-500E", "Hi: 2.5-6/2-5 W (Depending on voltage)Lo: ?/? mW", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 63, "58*96*15 mm (2.28*3.78*0.59in)", "Alinco/djc6.jpg", "DJ-C6E", "300/300 mW (500 mW with 6 VDC external)", 3, "98 gr (3.46 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 64, "58*96*15 mm (2.28*3.78*0.59in)", "Alinco/djc7.jpg", "DJ-C7", "Hi: 300-500 mW (depending on voltage)Lo: ? mW", 3, "102 gr (3.6 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 65, "53*109*38 mm (2.1*4.3*1.5in)", "Alinco/djf1t.jpg", "DJ-F1T", "Hi: 2-5 W (depending on voltage)Mid: 1 W, Lo: 100 mW", 3, "374 gr (13.2 oz), with standard battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 66, "53*109*38 mm (2.1*4.3*1.5in)", "Alinco/djf4t.jpg", "DJ-F4T", "Hi: 2-5 W (depending on voltage)Mid: 1 W, Lo: 100 mW", 3, "374 gr (13.2 oz), with standard battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 67, "? mm", "Alinco/djg1.jpg", "DJ-G1E", "Hi: 2.5-5 W (depending on voltage)Mid: 1 W, Lo: 200 mW", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 68, "? mm", "Alinco/djg1.jpg", "DJ-G1T", "Hi: 2.5-5 W (depending on voltage)Mid: 1 W, Lo: 200 mW", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 69, "? mm", "Alinco/djg29t.jpg", "DJ-G29T", "Hi: 5 / 2 W, Lo: ? / ? mW", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 62, "56*94*11 mm (2.2*3.7*0.43in)", "Alinco/djc5e.jpg", "DJ-C5E", @"PWR
2 m:300 mW
70 cm:300 mW", 3, "85 g (3 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 70, "57*139*28 mm (2.24*5.47*1.1in)", "Alinco/djg5.jpg", "DJ-G5E", "2-5 W/2-5 W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 72, "61*106*38 mm (2.4*4.17*1.5in)", "Alinco/djg7.jpg", "DJ-G7", "Hi: 5/4.5/1 W (@ 9 VDC)Mid1: 2/2/0.2 WMid2: 0.8/0.8/0.2 W, Lo: 0.2/0.2/0.2 W", 3, "296 gr (10.44 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 73, "59*118*40 mm (2.32*4.65*1.57in)", "Alinco/djmd5.jpg", "DJ-MD5E", @"2 mTurbo: 5 WHi: 2.5 WMid: 1 W, Lo: 200 mW


70 cmTurbo: 5 WHi: 2.5 WMid: 1 W, Lo: 200 mW", 3, "256 g (9.03 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 74, "59*118*40 mm (2.32*4.65*1.57in)", "Alinco/djmd5.jpg", "DJ-MD5EGP", @"2 mTurbo: 5 WHi: 2.5 WMid: 1 W, Lo: 200 mW


70 cmTurbo: 5 WHi: 2.5 WMid: 1 W, Lo: 200 mW", 3, "256 g (9.03 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 75, "59*118*40 mm (2.32*4.65*1.57in)", "Alinco/djmd5.jpg", "DJ-MD5T", @"2 mTurbo: 5 WHi: 2.5 WMid: 1 W, Lo: 200 mW


70 cmTurbo: 5 WHi: 2.5 WMid: 1 W, Lo: 200 mW", 3, "256 g (9.03 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 76, "59*118*40 mm (2.32*4.65*1.57in)", "Alinco/djmd5.jpg", "DJ-MD5TGP", @"2 mTurbo: 5 WHi: 2.5 WMid: 1 W, Lo: 200 mW


70 cmTurbo: 5 WHi: 2.5 WMid: 1 W, Lo: 200 mW", 3, "256 g (9.03 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 77, "55*102*28 mm (2.16*4.02*1.1in)", "Alinco/djs11t.jpg", "DJ-S11T", "Hi: 350 mW, Lo: 50 mW", 3, "185 gr (6.53 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 78, "57*98*28 mm (2.24*3.86*1.1in)", "Alinco/djs12.jpg", "DJ-S12", "Hi: 1 W, Lo: 0.5 W", 3, "162 gr (5.71 oz), with antenna and EBP-60" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 71, "57*139*28 mm (2.24*5.47*1.1in)", "Alinco/djg5.jpg", "DJ-G5T", "2-5 W/2-5 W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 61, "56*94*11 mm (2.2*3.7*0.43in)", "Alinco/djc5.jpg", "DJ-C5T", @"PWR
2 m:300 mW
70 cm:300 mW", 3, "85 g (3 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 60, "56*94*11 mm (2.2*3.7*0.43in)", "Alinco/djc4.jpg", "DJ-C4T", "300 mW", 3, "75 g (2.65 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 59, "56*94*11 mm (2.2*3.7*0.43in)", "Alinco/djc4.jpg", "DJ-C4E", "300 mW", 3, "75 g (2.65 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 42, "59*98*35 mm (2.32*3.86*1.38in)", "Alinco/dj500e_new.jpg", "DJ-500E (newer)", @"2 mHi: 5 W, Mid: 2.5 W, Lo: 1 W


70 cmHi: 5 W, Mid: 2.5 W, Lo: 1 W", 3, "227 gr (8.01 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 43, "? mm", "Alinco/dj500t.jpg", "DJ-500T", "Hi: 2.5-6/2-5 W (Depending on voltage)Lo: ?/? mW", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 44, "59*98*35 mm (2.32*3.86*1.38in)", "Alinco/dj500t_new.jpg", "DJ-500T (newer)", @"2 mHi: 5 W, Mid: 2.5 W, Lo: 1 W


70 cmHi: 5 W, Mid: 2.5 W, Lo: 1 W", 3, "227 gr (8.01 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 45, "56*124*37 mm (2.2*4.88*1.46in), with standard battery", "Alinco/dj520j.jpg", "DJ-520J", "Hi: 5/5 W, Lo: ?/? mW", 3, "280 gr (9.88 oz), with standard battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 46, "58*97*37 mm (2.28*3.82*1.46in)", "Alinco/dj530j.jpg", "DJ-530J", "Hi: 5/5 W, Lo: 800/800 mW", 3, "310 gr (10.93 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 47, "57*169*32 mm (2.24*6.65*1.26in)", "Alinco/dj560.jpg", "DJ-560E", "Hi: 5/5 W (depending on voltage)Lo: ?/? W", 3, "440 gr (15.52 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 48, "57*169*32 mm (2.24*6.65*1.26in)", "Alinco/dj560.jpg", "DJ-560T", "Hi: 5/5 W (depending on voltage)Lo: ?/? W", 3, "440 gr (15.52 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 49, "? mm", "Alinco/dj562.jpg", "DJ-562SX", "Hi: 5/5 W (depending on voltage)Lo: ?/? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 50, "? mm", "Alinco/dj580.jpg", "DJ-580", "Hi: ?/? W, Lo: ?/? W", 3, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 51, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj593mkii.jpg", "DJ-593E MKII", "Hi: 2.5-5 / 2.5-4.5 W (depending on voltage)Lo: 0.8/0.8 W", 3, "310 gr (10.93 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 52, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj593j.jpg", "DJ-593J", "Hi: 5/5 W, Lo: 0.8/0.8 W", 3, "310 gr (10.93 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 53, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj596e.jpg", "DJ-596E", @"High@ 13.8 VHigh@9.6 VLow 1
2 m:5 W4.5 W800 mW
70 cm:5 W4.5 W800 mW", 3, "280 g (9.88 oz), with EBP-50N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 54, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj596mkii.jpg", "DJ-596E MKII", "Hi: 2.5-5 / 2.5-4.5 W (depending on voltage)Lo: 0.8/0.8 W", 3, "310 gr (10.93 oz), with battery and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 55, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj596j.jpg", "DJ-596J", "Hi: 5/5 W, Lo: 0.8/0.8 W", 3, "280 gr (9.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 56, "56*124*37 mm (2.2*4.88*1.46in)", "Alinco/dj596j.jpg", "DJ-596T", @"High@ 13.8 VHigh@9.6 VLow 1
2 m:5 W4.5 W800 mW
70 cm:5 W4.5 W800 mW", 3, "280 g (9.88 oz), with EBP-50N" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 57, "56*94*11 mm (2.2*3.7*0.43in)", "Alinco/djc1.jpg", "DJ-C1E", "300 mW", 3, "75 g (2.65 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 58, "56*94*11 mm (2.2*3.7*0.43in)", "Alinco/djc1.jpg", "DJ-C1T", "300 mW", 3, "75 g (2.65 oz), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 80, "56*102*28 mm (2.2*4.02*1.1in)", "Alinco/djs40.jpg", "DJ-S40", "Hi: 1 W, Lo: 200 mW", 3, "160 gr (5.64 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 161, "140*40*195 mm (5.51*1.58*7.68in)", "Anytone/at5888uv.jpg", "AT-5888UV", @"HighMid 1Mid 2Low
2 m:50 W25 W10 W5 W
70 cm:40 W25 W10 W5 W", 4, "1.12 Kg (2.47 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 162, "? mm (?in)", "Anytone/at5888uviii.jpg", "AT-5888UV III", @"HighMidLow
2 m:55 W10 W5 W
1.25 m:55 W10 W5 W
70 cm:40 W10 W5 W", 4, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 163, "145*47*190 mm (5.71*1.85*7.48in)", "Anytone/at588vhf.jpg", "AT-588 VHF", "Hi: 60 WMid: 25 W, Lo: 10 W", 4, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 266, "34*60*13 mm (1.34*2.36*0.51in)", "ATV/lh_rc832s.jpg", "LH RC832S", "", 8, "36 g (1.27 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 267, "? mm", "ATV/luda_gp707.jpg", "Luda GP-707", "", 8, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 268, "68*16*78 mm (2.7*0.63*3.1in)", "ATV/luda_gp708.jpg", "Luda GP-708", "", 8, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 269, "? mm", "ATV/mfj_8704.jpg", "MFJ-8704 \"Video Lynx\"", "50 mW (100 mW unmodulated)", 8, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 270, "89*38*19 mm (3.5*1.5*0.75in)", "ATV/mfj_8708.jpg", "MFJ-8708", "50 mW (100 mW unmodulated)", 8, "96 gr (3.4 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 271, "60*19*71 mm (2.35*0.75*2.8in)", "ATV/mfj_8709.jpg", "MFJ-8709", "Max 4.5 W", 8, "96 gr (3.4 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 272, "75*28*40 mm (2.95*1.1*1.58in)", "ATV/minitiouner_express.jpg", "MiniTiouner Express", "", 8, "80 g (2.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 265, "74*120*35 mm (2.91*4.72*1.38in)", "ATV/lawmate_sc0825.jpg", "Lawmate SC-0825", "", 8, "240 gr (8.47 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 273, "24*9*29 mm (0.94*0.35*1.14in)", "ATV/misumi_mstab003m.jpg", "Misumi MST-AB003M", "30 mW", 8, "25 gr (0.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 275, "24*9*29 mm (0.94*0.35*1.14in)", "ATV/misumi_mstab020m.jpg", "Misumi MST-AB020M", "200 mW", 8, "25 gr (0.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 276, "? mm", "ATV/misumi_mstab050m.jpg", "Misumi MST-AB050M", "500 mW", 8, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 277, "48*35*61 mm (1.89*1.38*2.4in)", "ATV/misumi_mstab100m.jpg", "Misumi MST-AB100M", "1 W", 8, "129 gr (4.55 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 278, "61*35*64 mm (2.4*1.38*2.52in)", "ATV/misumi_mstab200m.jpg", "Misumi MST-AB200M", "2 W", 8, "170 gr (6 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 279, "61*35*118 mm (2.4*1.38*4.65in)", "ATV/misumi_mstab400m.jpg", "Misumi MST-AB400M", "4 W", 8, "316 gr (11.15 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 280, "74*120*35 mm (2.91*4.72*1.38in)", "ATV/misumi_wcs99x.jpg", "Misumi WCS-99X", "", 8, "240 gr (8.47 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 281, "74*123*35 mm (2.91*4.84*1.38in)", "ATV/misumi_wcs99xiim.jpg", "Misumi WCS-99XII-M", "", 8, "280 gr (9.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 274, "39*6*27 mm (1.54*0.24*1.06in)", "ATV/misumi_mstab010m.jpg", "Misumi MST-AB010M", "100 mW", 8, "26 gr (0.92 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 282, "74*123*35 mm (2.91*4.84*1.38in)", "ATV/misumi_wcs99xiis.jpg", "Misumi WCS-99XII-S", "", 8, "280 gr (9.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 264, "74*20*90 mm (2.9*0.79*3.54in)", "ATV/konigelectronic_vidtrans12kn_rx.jpg", "K�nig Electronic - Vid-Trans12KN (RX)", "", 8, "? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 262, "125*20*72 mm (4.92*0.79*2.84in)", "ATV/iftrontech_yellowjacketpro.jpg", "Iftrontech Yellow Jacket pro", "", 8, "190 gr (6.7 oz), with antennas" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 246, "147*15*59 mm (5.79*0.59*2.32in)", "ATV/comtech_fm2400rtim8.jpg", "Comtech FM2400RTIM8", "", 8, "85 g (3 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 247, "? mm", "ATV/comtech_fm2400tsim.jpg", "Comtech FM2400TSIM", "~8 mW", 8, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 248, "124*16*59 mm (4.88*0.63*2.32in)", "ATV/comtech_fm2400tsimg.jpg", "Comtech FM2400TSIMG", ">9 mW", 8, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 249, "176*119*23 mm (6.93*4.68*0.9in), excluding the sunshield", "ATV/eachine_lcd5802d.jpg", "Eachine LCD5802D", "", 8, "425 g (15 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 250, "14*13*17 mm (0.55*0.51*0.67in), excluding the antenna", "ATV/eachine_tx06.jpg", "Eachine TX-06", "25 mW", 8, "3.9 g (0.14 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 251, "20*28*8 mm (0.79*1.1*0.32in)", "ATV/eachine_tx526.jpg", "Eachine TX-526", @"Hi: 600 mW
Mid: 200 mW, Lo: 25 mW", 8, "7 g (0.25 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 252, "91*143*30 mm (3.58*5.63*1.18in)", "ATV/fongyao_pvrw24c.jpg", "Fongyao PVRW-24C", "", 8, "264 gr (9.31 oz), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 263, "88*164*56 mm (3.5*6.5*2.2in)", "ATV/inventtech_bc001.jpg", "Invent-Tech BC-001", "", 8, "310 gr (10.9 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 253, "190*55*120 mm (7.48*2.16*4.72in)", "ATV/fortop_tvt432.jpg", "Fortop TVT-432", "15-20 W", 8, "900 gr (1.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 255, "68*15*78 mm (2.68*0.59*3.07in)", "ATV/fr632.jpg", "FR632 (OEM)", "", 8, "92 gr (3.24 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 256, "20*8*30 mm (0.79*0.32*1.18in)", "ATV/ft951.jpg", "FT-951 (OEM)", "25 mW (14 dBm �0.5 dB)", 8, "7 gr (0.25 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 257, "? mm (?in)", "ATV/hawksweep_hs5000a.jpg", "Hawksweep HS-5000A", "", 8, "? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 258, "? mm", "ATV/hspubs_d100.jpg", "HS Publications D100", "", 8, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 259, "? mm", "ATV/hspubs_d100deluxe.jpg", "HS Publications D100 De-Luxe", "", 8, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 260, "225*55*175 mm (8.86*2.16*6.89in)", "ATV/idelektronik_13cmtx.jpg", "ID Elektronik 13 cm ATV TX", "1.5 W", 8, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 261, "28*10*22 mm (1.1*0.39*0.87in)", "ATV/iftrontech_nanostingerpro.jpg", "Iftrontech Nano Stinger Pro", "25 mW", 8, "9 gr (0.32 oz), without antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 254, "? mm", "ATV/fortop_tvt435.jpg", "Fortop TVT-435", "15-20 W", 8, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 283, "? mm", "ATV/mm_mmc435600.jpg", "Microwave Modules MMC 435/600", "", 8, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 284, "187*53*120 mm (7.36*2.09*4.72in)", "ATV/mm_mtv435.jpg", "Microwave Modules MTV 435", "20 W Peak Sync Power", 8, "900 g (1.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 285, "74*120*35 mm (2.91*4.72*1.38in)", "ATV/optoelectronics_videosweeper.jpg", "Optoelectronics Video Sweeper", "", 8, "240 gr (8.47 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 307, "60*174*33 mm (2.36*6.85*1.3in)", "Azden/az61.jpg", "AZ-61", "Hi: 5 W, Lo: 0.5 W", 10, "550 gr (19.4 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 308, "? mm", "Azden/pcs2000.jpg", "PCS-2000", "Hi: ? W, Lo: ? W", 10, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 309, "? mm", "Azden/pcs2200.jpg", "PCS-2200", "Hi: ? W, Lo: ? W", 10, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 310, "? mm", "Azden/pcs2800z.jpg", "PCS-2800Z", "Hi: 10 W, Lo: ? W", 10, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 311, "65*184*44 mm (2.56*7.24*1.73in)", "Azden/azden_pcs300.jpg", "PCS-300", "Hi: 3 W, Lo: 1 W", 10, "640 gr (22.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 312, "158*66*246 mm (6.22*2.6*9.68in)", "Azden/azden_pcs3000.jpg", "PCS-3000", "Hi: 25 W, Lo: 5 W", 10, "2.5 Kg (5.51 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 313, "140*50*172 mm (5.51*1.97*6.77in)", "Azden/azden_pcs4000.jpg", "PCS-4000", "Hi: 25 W, Lo: 5 W", 10, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 306, "60*174*33 mm (2.36*6.85*1.3in)", "Azden/az11.jpg", "AZ-11", "Hi: 5 W, Lo: 0.5 W", 10, "550 gr (19.4 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 314, "? mm", "Azden/pcs4300.jpg", "PCS-4300", "Hi: 25 W, Lo: 5 W", 10, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 316, "140*51*184 mm (5.5*2*7.25in)", "Azden/pcs6000.jpg", "PCS-6000", "Hi: 25 W, Lo: 5 W", 10, "1.4 Kg (3.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 317, "140*51*184 mm (5.5*2*7.25in)", "Azden/pcs6000.jpg", "PCS-6000H", "Hi: 50 W, Lo: 10 W", 10, "1.4 Kg (3.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 318, "140*51*140 mm (5.5*2*5.5in)", "Azden/pcs7000h.jpg", "PCS-7000H", "Hi: 50 W, Lo: 10 W", 10, "1.36 Kg (3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 319, "? mm", "Azden/pcs7500.jpg", "PCS-7500", "Hi: 10 W, Lo: ? W", 10, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 320, "140*51*140 mm (5.51*2.01*5.51in)", "Azden/pcs7500h.jpg", "PCS-7500H", "Hi: 50 W, Lo: 5 W", 10, "1.3 Kg (2.87 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 321, "140*50*205 mm (5.51*1.97*8.07in)", "Azden/pcs7801hn.jpg", "PCS-7801HN", "Hi: 50 W, Lo: 5 W", 10, "1.4 Kg (3.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 322, "210*100*240 mm (8.27*3.94*9.45in)", "Bando/technic12k.jpg", "Technic-12K", "10 W (PEP)", 11, "12.3 Kg (27.12 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 315, "140*50*182 mm (5.51*1.97*7.16in)", "Azden/pcs5000.jpg", "PCS-5000", "Hi: 25 W, Lo: 5 W", 10, "1.4 Kg (3.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 305, "? mm", "ATV/videoscanner.jpg", "Videoscanner", "", 8, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 304, "23*40*8 mm (0.9*1.58*0.32in)", "ATV/ts5828s.jpg", "TS-5828S (OEM)", "500-600 mW (27-28 dBm)", 8, "10 g (0.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 303, "26*17*55 mm (1.02*0.67*2.16in)", "ATV/ts582000.jpg", "TS-582000 (OEM)", "2 W (33 dBm �1 dB)", 8, "59 gr (2.08 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 286, "157*35*64 mm (6.18*1.38*2.52in)", "ATV/parabolic_atvrx1.jpg", "Parabolic ATV-RX (RF out version)", "", 8, "? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 287, "157*35*64 mm (6.18*1.38*2.52in)", "ATV/parabolic_atvrx2.jpg", "Parabolic ATV-RX (Video/LF out version)", "", 8, "? gr (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 288, "157*35*64 mm (6.18*1.38*2.52in)", "ATV/parabolic_atvtx_1.jpg", "Parabolic ATV-TX", "200 mW", 8, "225 gr (7.94 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 289, "? mm", "ATV/pcelectronics_atvr4.jpg", "PC Electronics ATVR-4", "", 8, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 290, "? mm (?in)", "ATV/pcelectronics_tc1.jpg", "PC Electronics TC-1", ">10 W (PEP/Sync tip)", 8, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 291, "? mm (?in)", "ATV/pcelectronics_tc701.jpg", "PC Electronics TC70-1", "1 W (PEP/Sync tip)", 8, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 292, "190*74*188 mm (7.5*2.9*7.4in)", "ATV/pcelectronics_tc7010.jpg", "PC Electronics TC70-10", ">10 W (PEP/Sync tip)", 8, "1.32 Kg (2.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 293, "? mm (?in)", "ATV/pcelectronics_tc701d.jpg", "PC Electronics TC70-1D", "1 W (PEP/Sync tip)", 8, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 294, "190*69*190 mm (7.5*2.7*7.5in)", "ATV/pcelectronics_tc7020.jpg", "PC Electronics TC70-20", ">20 W (PEP/Sync tip)", 8, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 295, "190*69*190 mm (7.5*2.7*7.5in)", "ATV/pcelectronics_tc7020s.jpg", "PC Electronics TC70-20S", ">20 W (PEP/Sync tip)", 8, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 296, "? mm", "ATV/pcelectronics_tvc4g.jpg", "PC Electronics TVC-4G", "", 8, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 297, "? mm (?in)", "ATV/pcelectronics_tx705s.jpg", "PC Electronics TX70-5S", ">4 W (PEP/Sync tip) @ 75% duty cycle (15 min on/5 min off)Longer transmissions require forced cooling!", 8, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 298, "52*13*61 mm (2.05*0.51*2.4in)", "ATV/rc305.jpg", "RC-305 (OEM)", "", 8, "43 gr (1.52 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 299, "52*14*69 mm (2.05*0.55*2.72in)", "ATV/rc5808.jpg", "RC-5808 (OEM)", "", 8, "44 gr (1.55 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 300, "54*80*15 mm (2.12*3.15*0.59in)", "ATV/rc832s.jpg", "RC-832S (OEM)", "", 8, "80 g (2.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 301, "176*119*23 mm (6.93*4.68*0.9in), excluding the 28 mm (1.1in) deep sunshield", "ATV/rxlcd5802.jpg", "RX-LCD5802 (OEM)", "", 8, "425 g (15 oz), without antennas" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 302, "190*140*40 mm (7.48*5.51*1.58in)", "ATV/spytecinc_vs125.jpg", "SpyTec Inc. VS-125", "", 8, "860 gr (1.9 lbs), with battery" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 245, "98*15*59 mm (3.86*0.59*2.32in)", "ATV/comtech_fm2350tsimp.jpg", "Comtech FM2350TSIMP", "~200 mW", 8, "70 gr (2.47 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 244, "124*18*59 mm (4.88*0.71*2.32in)", "ATV/comtech_fm1394tsim.jpg", "Comtech FM1394TSIM", "~50 mW", 8, "70 gr (2.47 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 243, "148*15*59 mm (5.83*0.59*2.32in)", "ATV/comtech_fm1394rtim.jpg", "Comtech FM1394RTIM \"Platinum\"", "", 8, "90 g (3.18 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 242, "124*18*59 mm (4.88*0.71*2.32in)", "ATV/comtech_fm1200tsimg.jpg", "Comtech FM1200TSIMG", "~50 mW", 8, "70 gr (2.47 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 185, "217*100*260 mm (8.54*3.94*10.24in)", "AOR/aor_ar5000.jpg", "AR-5000", "", 5, "3.5 Kg (7.72 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 186, "217*100*260 mm (8.5*3.5*10in)", "AOR/aor_ar5000a.jpg", "AR-5000A", "", 5, "3.5 Kg (7.8 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 187, "217*100*260 mm (8.54*3.94*10.24in)", "AOR/aor_ar5000.jpg", "AR-5000+3", "", 5, "3.5 Kg (7.72 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 188, "220*97*304 mm (8.5*3.75*12in)", "AOR/ar5001d.jpg", "AR-5001D", "", 5, "5 Kg (11.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 189, "220*97*304 mm (8.67*3.82*12in)", "AOR/aor_ar6000.jpg", "AR-6000", "", 5, "5 Kg (12 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 190, "220*90*240 mm (8.66*3.54*9.45in)", "AOR/ar7000_and remote.jpg", "AR-7000", "", 5, "3.5 Kg (7.72 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 191, "238*77*191 mm (9.37*3.03*7.52in)", "AOR/aor_ar7030.jpg", "AR-7030", "", 5, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 184, "138*80*200 mm (5.43*3.15*7.87in)", "AOR/aor_ar3000a.jpg", "AR-3000A", "", 5, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 192, "238*77*191 mm (9.37*3.03*7.52in)", "AOR/aor_ar7030plus.jpg", "AR-7030 Plus", "", 5, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 194, "69*153*40 mm (2.72*6.02*1.58in)", "AOR/aor_ar8000.jpg", "AR-8000", "", 5, "350 gr (12.35 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 195, "61*143*39 mm (2.4*5.63*1.53in)", "AOR/aor_ar8200.jpg", "AR-8200", "", 5, "196 gr (6.8 oz), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 196, "61*143*39 mm (2.4*5.63*1.53in)", "AOR/ar8200d.jpg", "AR-8200D", "", 5, "370 gr (13.05 oz), including batteries, antenna and belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 197, "61*143*39 mm (2.4*5.63*1.53in)", "AOR/ar8200mk2.jpg", "AR-8200 MK2", "", 5, "217 gr (7.65 oz), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 198, "61*143*39 mm (2.4*5.63*1.53in)", "AOR/ar8200mk3.jpg", "AR-8200 MK3", "", 5, "340 gr (11.99 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 199, "155*57*195 mm (6.1*2.24*7.68in)", "AOR/aor_ar8600.jpg", "AR-8600", "", 5, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 200, "155*57*195 mm (6.1*2.2*7.7in)", "AOR/aor_ar8600mkii.jpg", "AR-8600 Mk2", "", 5, "2 Kg (4.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 193, "62*167*40 mm (2.44*6.58*1.58in)", "AOR/aor_ar740a.jpg", "AR-740A", "Hi: 3 W, Lo: 0.3 W", 5, "450 gr (15.87 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 183, "138*80*200 mm (5.43*3.15*7.87in)", "AOR/ar3000.jpg", "AR-3000", "", 5, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 182, "68*38*162 mm (2.68*1.5*6.38in)", "AOR/aor_ar280.jpg", "AR-280", "5 W", 5, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 181, "63*153*40 mm (2.48*6.02*1.58in)", "AOR/ar2700.jpg", "AR-2700", "", 5, "315 gr (11.11 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 164, "124*39*163 mm (4.88*1.54*6.42in)", "Anytone/at778uv.jpg", "AT-778UV", @"2 mHi: 25 W, Mid: 15 W, Lo: 5 W


70 cmHi: 25 W, Mid: 15 W, Lo: 5 W", 4, "640 g (1.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 165, "188*40*141 mm (7.4*1.58*5.55in)", "Anytone/atd578uv.jpg", "AT-D578UV", @"TurboHighMidLow
2 m:55 W25 W10 W5 W
70 cm:40 W25 W10 W5 W", 4, "1.04 Kg (2.29 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 166, "188*40*141 mm (7.4*1.58*5.55in)", "Anytone/atd578uvplusv2.jpg", "AT-D578UV Plus v2", @"TurboHighMidLow
2 m:55 W25 W10 W5 W
70 cm:40 W25 W10 W5 W", 4, "1.04 Kg (2.29 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 167, "61*129*39 mm (2.4*5.08*1.54in)", "Anytone/atd868uv.jpg", "AT-D868UV", @"HighMidLow 1Low 2
2 m:7 W5 W2.5 W1 W
70 cm:6 W5 W2.5 W1 W", 4, "282 g (9.95 oz), with 2100 mAh battery pack and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 168, "61*129*39 mm (2.4*5.08*1.54in)", "Anytone/atd878uv.jpg", "AT-D878UV", @"HighMidLow 1Low 2
2 m:7 W5 W2.5 W1 W
70 cm:6 W5 W2.5 W1 W", 4, "282 g (9.95 oz), with 2100 mAh battery pack and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 169, "61*129*39 mm (2.4*5.08*1.54in)", "Anytone/atd878uviiplus.jpg", "AT-D878UVII Plus", @"HighMidLow 1Low 2
2 m:7 W5 W2.5 W200 mW
70 cm:6 W5 W2.5 W200 mW", 4, "282 g (9.95 oz), with 2100 mAh battery pack and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 170, "? mm", "AOR/ar1000.jpg", "AR-1000", "", 5, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 171, "? mm", "AOR/ar1000xlt.jpg", "AR-1000XLT", "", 5, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 172, "55*152*40 mm (2.16*5.98*1.58in)", "AOR/ar1500.jpg", "AR-1500", "", 5, "360 g (12.7 oz), including battery pack" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 173, "61*107*30 mm (2.4*4.2*1.2in)", "AOR/aor_ar16.jpg", "AR-16", "", 5, "153 g (5.4 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 174, "65*170*35 mm (2.56*6.69*1.38in)", "AOR/ar2000.jpg", "AR-2000", "", 5, "300 g (10.58 oz), without batteries415 g (14.64 oz), with batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 175, "138*80*200 mm (5.43*3.15*7.87in)", "AOR/aor_ar2001.jpg", "AR-2001", "", 5, "1.1 Kg (2.42 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 176, "138*80*200 mm (5.43*3.15*7.87in)", "AOR/ar2002.jpg", "AR-2002", "", 5, "1.2 Kg (2.64 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 177, "63*130*25 mm (2.48*5.12*0.98in)", "AOR/aor_ar22_1.jpg", "AR-22", "", 5, "200 gr (7.06 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 178, "216*70*286 mm (8.5*2.75*11.25in)", "AOR/ar2300.jpg", "AR-2300", "", 5, "2.99 (6.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 179, "60*165*40 mm (2.36*6.5*1.58in)", "AOR/aor_ar240.jpg", "AR-240", "1.5 W", 5, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 180, "138*80*200 mm (5.43*3.15*7.87in)", "AOR/ar2515.jpg", "AR-2515", "", 5, "1.2 Kg (2.65 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 201, "55*145*40 mm (2.16*5.71*1.58in)", "AOR/ar900.jpg", "AR-900", "", 5, "620 gr (21.87 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 647, "120*40*180 mm (4.72*1.58*7.09in)", "DLS/dls_80new.jpg", "-80", "", 22, "620 g (1.37 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 202, "145*52*180 mm (5.71*2.05*7.09in)", "AOR/aor_ar950.jpg", "AR-950", "", 5, "0.6 Kg (1.32 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 204, "419*130*308 mm (16.5*5.12*12.12in)", "AOR/aor_aralpha.jpg", "AR-Alpha B", "", 5, "7.71 Kg (17 Lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 226, "240*90*250 mm (9.45*3.54*9.84in)", "Atlas/215x.jpg", "215X", @"SSB: >80 W PEP (200 W PEP input)
CW: >80 W", 7, "3.1 Kg (6.83 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 227, "? mm (?in)", "Atlas/300.jpg", "300", "? W", 7, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 228, "? mm (?in)", "Atlas/310.jpg", "310", "? W", 7, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 229, "320*140*410 mm (12.5*5.25*16in)", "Atlas/350xl.jpg", "350-XL", @"1.8-23 MHz: >160 W (350 W PEP input)
28-30 MHz: >100 W (250 W PEP input)", 7, "8.2 Kg (18 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 230, "229*86*229 mm (9*3.4*9in)", "Atlas/400x.jpg", "400X \"The little giant\"", @"SSB: >75 W PEP (150 W PEP input)
CW: >60 W (120 W input)", 7, "3.18 Kg (7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 231, "216*95*248 mm (8.5*3.75*9.75in)", "Atlas/rx110.jpg", "RX-110", "", 7, "3.18 Kg (7 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 232, "? mm (?in)", "Atlas/tx110.jpg", "TX-110-H", @"10 m: >50 W (100 W input)
15 m: >75 W (150 W input)
20-80 m: >90 W (200 W input)", 7, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 225, "240*90*250 mm (9.45*3.54*9.84in)", "Atlas/210xle.jpg", "210X Limited Edition", @"SSB: >110 W PEP (250 W PEP input)
CW: >110 W", 7, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 233, "? mm (?in)", "Atlas/tx110.jpg", "TX-110-L", @"10-15 m: >5 W (10 W input)
20-80 m: >8 W (15 W input)", 7, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 235, "60*48*35 mm (2.36*1.89*1.38in)", "ATV/ajoka_aj801t.jpg", "Ajoka AJ-801T", "1 W", 8, "130 gr (4.59 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 236, "65*60*35 mm (2.56*2.36*1.38in)", "ATV/ajoka_aj803t.jpg", "Ajoka AJ-803T", "3 W", 8, "156 gr (5.5 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 237, "67*132*33 mm (2.64*5.2*1.3in)", "ATV/aor_arstv.jpg", "AOR AR-STV", "", 8, "430 gr (15.17 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 238, "? mm (?in)", "ATV/aptron_am1a.jpg", "Aptron AM-1A (By Aptron Laboratories. Bloomington, Indiana)", "", 8, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 239, "? mm (?in)", "ATV/aptron_ax10.jpg", "Aptron AX-10 (By Aptron Laboratories. Bloomington, Indiana)", "? W", 8, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 240, "26*55*17 mm (1.02*2.16*0.67in)", "ATV/boscam_ts351.jpg", "Boscam TS-351", "Max 200 mW", 8, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 241, "147*15*58 mm (5.79*0.59*2.28in)", "ATV/comtech_fm1200rtim.jpg", "Comtech FM1200RTIM", "", 8, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 234, "211*66*188 mm (8.3*2.6*7.4in)", "ATV/aea_vsb70.jpg", "AEA VSB-70 (By Advanced Electronic Applications Inc.)", "1 W (PEP/Sync tip)", 8, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 224, "240*90*250 mm (9.45*3.54*9.84in)", "Atlas/210x.jpg", "210X", @"10 m
SSB: >50 W PEP (120 W PEP input)
CW: >50 W
15-80 m
SSB: >80 W PEP (200 W PEP input)
CW: >80 W", 7, "3.1 Kg (6.83 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 223, "240*90*250 mm (9.45*3.54*9.84in)", "Atlas/210.jpg", "210", @"10 m
SSB: >50 W PEP (120 W PEP input)
CW: >50 W
15-80 m
SSB: >80 W PEP (200 W PEP input)
CW: >80 W", 7, "3.1 Kg (6.83 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 222, "241*89*241 mm (9.49*3.5*9.49in)", "Atlas/180m.jpg", "180M", @"SSB: >90 W PEP (180 W PEP input)
CW: >90 W (180 W input)", 7, "3.4 Kg (7.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 205, "178*50*214 mm (7*1.97*8.42in)", "AOR/ardv1.jpg", "AR-DV1", "", 5, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 206, "60*95*24 mm (2.36*3.74*0.94in)", "AOR/armini.jpg", "AR-Mini", "", 5, "210 gr (7.41 oz), with antenna and batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 207, "157*58*270 mm (6.18*2.28*10.63in)", "AOR/aor_arone.jpg", "AR-One", "", 5, "2.2 Kg (4.85 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 208, "? mm", "AOR/aor_sr1030.jpg", "SR-1030", "", 5, "3.5 Kg (7.72 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 209, "220*120*195 mm (8.66*4.72*7.68in)", "AOR/aor_sr2000.jpg", "SR-2000", "", 5, "3.3 Kg (7.28 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 210, "250*88*240 mm (9.84*3.46*9.45in)", "AOR/ar3030.jpg", "AR-3030", "", 5, "2.2 Kg (4.85 lb), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 211, "63*130*26 mm (2.48*5.12*1.02in)", "AOR/ar33.jpg", "AR-33", "", 5, "200 g (7.06 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 212, "220*97*304 mm (8.66*3.82*11.97in)", "AOR/ar5700d.jpg", "AR-5700D", "", 5, "5 Kg (11.02 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 213, "178*50*214 mm (7*1.97*8.42in)", "AOR/ar7400.jpg", "AR-7400", "", 5, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 214, "? mm (?in)", "AOR/aralphaii.jpg", "AR-Alpha II", "", 5, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 215, "65*137*41 mm (2.56*5.39*1.61in)", "AOR/ardv10.jpg", "AR-DV10", "", 5, "420 g (14.82 oz), with battery pack, antenna & belt clip" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 216, "200*31*230 mm (7.87*1.22*9.06in)", "AOR/sr2200.jpg", "SR-2200", "", 5, "1.23 Kg (2.71 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 217, "? mm (?in)", "Apachelabs/anan10.jpg", "Apache Labs Anan-10", "15 W", 6, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 218, "265*80*220 mm (10.4*3.15*8.66in)", "Apachelabs/anan100.jpg", "Apache Labs Anan-100", "Max 100 W", 6, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 219, "265*80*220 mm (10.4*3.15*8.66in)", "Apachelabs/anan100d.jpg", "Apache Labs Anan-100D", "1-100 W", 6, "4.5 Kg (9.92 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 220, "265*80*220 mm (10.4*3.15*8.66in)", "Apachelabs/anan200d.jpg", "Apache Labs Anan-200D", "1-100 W", 6, "4.5 Kg (9.92 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 221, "241*89*241 mm (9.49*3.5*9.49in)", "Atlas/180.jpg", "180", @"SSB: >90 W PEP (180 W PEP input)
CW: >90 W (180 W input)", 7, "3.4 Kg (7.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 203, "419*130*308 mm (16.5*5.12*12.12in)", "AOR/aor_aralpha.jpg", "AR-Alpha", "", 5, "7.71 Kg (17 Lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 648, "Receiver: ? mm (?in)Remote head: ? mm (?in)", "DLS/dls_direct.jpg", "Direct", "", 22, "Receiver: ? Kg (? lb)Remote head: ? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 649, "Receiver: 135*32*125 mm (5.32*1.26*4.92in)Remote head: 95*43*24 mm (3.74*1.69*0.94in)", "DLS/dls_directii.jpg", "Direct II", "", 22, "Receiver: ? Kg (? lb)Remote head: ? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 650, "300*85*240 mm (11.81*3.35*9.45in)", "Dragon/dragon_ss797.jpg", "SS-797", "FM/SSB: 50 WAM: 20 W", 23, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1077, "? mm", "Hilberling/mt8010.jpg", "MT80-10", "100 W", 42, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1078, "? mm", "Hilberling/mt8020.jpg", "MT80/20", "100 W", 42, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1079, "425*175*465 mm (16.7*6.9*18.3in)", "Hilberling/pt8000a.jpg", "PT-8000A", "HF/6 m: 100 W (AM: 50 W)2 m: 10 W (AM: 2.5 W)", 42, "28 Kg (62 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1080, "425*175*465 mm (16.7*6.9*18.3in)", "Hilberling/pt8000av2_and_psu.jpg", "PT-8000A Version 2", "HF: 200 W (AM: 50 W)6/4/2 m: 100 W (AM: 25 W)", 42, "28 Kg (62 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1081, "? mm", "Hilberling/rx14.jpg", "RX14", "", 42, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1082, "? mm", "Hilberling/rx16.jpg", "RX16", "", 42, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1083, "? mm (?in)", "Icom/am3d.jpg", "AM-3D", "1 W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1076, "184*70*260 mm (7.24*2.76*10.24in)", "Heathkit/vf7401.jpg", "VF-7401", "15 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1084, "? mm (?in)", "Icom/fdam1.jpg", "Inoue (Icom) FDAM-1", "1 W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1086, "65*117*35 mm (2.56*4.6*1.38in), without battery pack", "Icom/ic02a.jpg", "IC-02A", @"High@ 13.2VHigh@ 8.4VLow
2 m:5 W3 W500 mW", 43, "515 g (1.13 lb), with BP-3 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1087, "65*117*35 mm (2.56*4.6*1.38in), without battery pack", "Icom/ic02at.jpg", "IC-02AT", @"High@ 13.2VHigh@ 8.4VLow
2 m:5 W3 W500 mW", 43, "515 g (1.13 lb), with BP-3 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1088, "65*117*35 mm (2.56*4.6*1.38in), without battery pack", "Icom/ic02e.jpg", "IC-02E", @"High@ 13.2VHigh@ 8.4VLow
2 m:5 W3 W500 mW", 43, "515 g (1.13 lb), with BP-3 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1089, "65*117*35 mm (2.56*4.6*1.38in), without battery pack", "Icom/ic03at.jpg", "IC-03AT", @"HighLow
1.25 m:2.5-5 W500 mW", 43, "515 g (1.13 lb), with BP-3 and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1090, "65*117*35 mm (2.56*4.6*1.38in), without battery pack", "Icom/ic04a.jpg", "IC-04A", @"Hi: 2.5-5 W (Depending on battery pack/voltage)
Lo: 0.5 W", 43, "495 g (1.09 lbs), with BP-3 and supplied antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1091, "65*117*35 mm (2.56*4.6*1.38in), without battery pack", "Icom/ic04at.jpg", "IC-04AT", @"Hi: 2.5-5 W (Depending on battery pack/voltage)
Lo: 0.5 W", 43, "515 g (1.13 lbs), with BP-3 and supplied antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1092, "65*117*35 mm (2.56*4.6*1.38in), without battery pack", "Icom/ic04e.jpg", "IC-04E", @"Hi: 2.5-5 W (Depending on battery pack/voltage)
Lo: 0.5 W", 43, "515 g (1.13 lbs), with BP-3 and supplied antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1085, "? mm (?in)", "Icom/fdam3.jpg", "Inoue (Icom) FDAM-3", "1 W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1093, "140*50*207 mm (5.51*1.97*8.15in)", "Icom/ic120.jpg", "IC-120", "1 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1075, "84*232*48 mm (3.31*9.13*1.89in)", "Heathkit/vf2031.jpg", "VF-2031", "2 W", 41, "900 gr (1.98 lbs), With batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1073, "292*117*267 mm (11.5*4.6*10.5in)", "Heathkit/sw7800.jpg", "SW-7800", "", 41, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1057, "324*171*305 mm (12.76*6.73*12.01in)", "Heathkit/hx1681.jpg", "HX-1681", "100 W (75 W on 10 m)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1058, "308*155*254 mm (12.13*6.1*10in)", "Heathkit/mr1.jpg", "MR-1 \"Comanche\"", "", 41, "7 Kg (15.43 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1059, "495*296*406 mm (19.49*11.65*15.98in)", "Heathkit/rx1.jpg", "RX-1 \"Mohawk\"", "", 41, "23 Kg (50.71 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1060, "? mm", "Heathkit/sb100.jpg", "SB-100", "100 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1061, "378*168*340 mm (14.88*6.62*13.38in)", "Heathkit/sb101.jpg", "SB-101", @"SSB: ~100 W PEP (180 W PEP input)
CW: ~100 W (DC 170 W DC input)
Slightly less on 10 m", 41, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1062, "? mm", "Heathkit/sb102.jpg", "SB-102", "100 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1063, "368*146*352 mm (14.49*5.75*13.86in)", "Heathkit/sb104.jpg", "SB-104", "Hi: 100 W (PEP)Lo: 1 W (PEP)", 41, "9.1 Kg (20 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1074, "495*295*406 mm (19.5*11.6*16in)", "Heathkit/tx1.jpg", "TX-1 \"Apache\"", @"AM/SSB: ~80 W (150 W input
CW: ~100 W (180 W input)", 41, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1064, "368*146*352 mm (14.49*5.75*13.86in)", "Heathkit/sb104a.jpg", "SB-104A", "Hi: 100 W (PEP)Lo: 1 W (PEP)", 41, "9.1 Kg (20 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1066, "? mm", "Heathkit/sb1400.jpg", "Heath SB-1400", "100 W (AM: 25 W)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1067, "377*169*340 mm (14.84*6.65*13.39in)", "Heathkit/sb301.jpg", "SB-301", "", 41, "7.7 Kg (16.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1068, "? mm", "Heathkit/sb303.jpg", "SB-303", "", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1069, "380*170*350 mm (14.9*6.7*13.8in)", "Heathkit/sb310.jpg", "SB-310", "", 41, "7.7 Kg (17 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1070, "? mm", "Heathkit/sb401.jpg", "SB-401", "100 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1071, "356*156*349 mm (14*6.14*13.74in)", "Heathkit/ss9000.jpg", "Heath SS-9000", @"SSB: Max 100 W PEP
CW/RTTY: Max 100 W", 41, "15.9 Kg (35 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1072, "368*135*203 mm (14.49*5.32*7.99in)", "Heathkit/sw717.jpg", "SW-717", "", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1065, "? mm", "Heathkit/sb110.jpg", "SB-110", "100 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1094, "140*40*196 mm (5.51*1.58*7.72in)", "Icom/ic1200.jpg", "IC-1200A", @"HighLow
23 cm:10 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1095, "140*40*196 mm (5.51*1.58*7.72in)", "Icom/ic1200.jpg", "IC-1200E", @"HighLow
23 cm:10 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1096, "140*40*200 mm (5.51*1.58*7.87in)", "Icom/ic1201a.jpg", "IC-1201A", @"HighLow
23 cm:10 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1118, @"Transceiver: 141*40*185 mm (5.55*1.58*7.28in)
Control head: 111*40*39 mm (4.37*1.58*1.54in)", "Icom/ic208d.jpg", "IC-208D", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1119, "141*40*185 mm (5.55*1.6*7.3in)", "Icom/ic208h.jpg", "IC-208H", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W


High: 25 W for Taiwan version", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1120, "230*111*260 mm (9.06*4.37*10.24in)", "Icom/ic21.jpg", "IC-21", @"HighLow
2 m:10 W1 W", 43, "6 Kg (13.23 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1121, "230*111*260 mm (9.06*4.37*10.24in)", "Icom/ic210.jpg", "IC-210", "0.5-10 W", 43, "7.2 Kg (15.87 lb), with optional internal PSU" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1122, "140*40*180 mm (5.51*1.58*7.09in)", "Icom/ic2100h.jpg", "IC-2100H", @"HighMidLow
2 m:55 W10 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1123, "241*111*264 (9.5*4.4*10.4in)", "Icom/ic211.jpg", "IC-211", @"FM: 1-10 W
SSB: 10 W (PEP)
CW: 10 W", 43, "6.1 Kg (13.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1124, "241*111*264 (9.5*4.4*10.4in)", "Icom/ic211e.jpg", "IC-211E", "1-10 W", 43, "6.1 Kg (13.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1117, "140*40*185 mm (5.51*1.58*7.28in)", "Icom/ic207h.jpg", "IC-207H", @"HighMid hiMid loLow
2 m:50 W20 W10 W5 W
70 cm:35 W20 W10 W5 W", 43, "1.17 Kg (2.58 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1125, "61*183*162 mm (2.4*7.2*6.38in)", "Icom/ic212.jpg", "IC-212", @"HighLow
2 m:3 W500 mW", 43, "2 Kg (4.41 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1127, "61*183*162 mm (2.4*7.2*6.38in)", "Icom/ic215e.jpg", "IC-215E", @"HighLow
2 m:3 W500 mW", 43, "1.9 Kg (4.19 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1128, "230*111*260 mm (9.06*4.37*10.24in)", "Icom/ic21a.jpg", "IC-21A", "0.5 to 10 W", 43, "7.2 Kg (15.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1129, "155*55*230 mm (6.1*2.16*9.06in)", "Icom/ic22.jpg", "IC-22", @"HighLow
2 m:10 W1 W", 43, "1.81 Kg (4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1130, "140*40*146 mm (5.51*1.58*5.75in)", "Icom/ic2200h.jpg", "IC-2200H", @"HighMid 1Mid 2Low 1
2 m:65 W25 W10 W5 W", 43, "1.25 Kg (2.76 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1131, "241*111*264 (9.5*4.4*10.4in)", "Icom/ic221.jpg", "IC-221", "1-10 W", 43, "6.1 (13.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1132, "156*58*247 mm (6.14*2.28*9.72in)", "Icom/ic225.jpg", "IC-225", "10 W", 43, "2.4 Kg (5.29 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1133, "140*50*137 mm (5.5*2*5.4in)", "Icom/ic228a.jpg", "IC-228A", "Hi: 25 W, Lo: 5 W", 43, "850 g (1.9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1126, "61*183*162 mm (2.4*7.2*6.38in)", "Icom/ic215.jpg", "IC-215", @"HighLow
2 m:3 W500 mW", 43, "1.9 Kg (4.19 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1116, "61*183*162 mm (2.4*7.2*6.38in)", "Icom/ic202s.jpg", "IC-202S", @"SSB: 3 W (PEP)
CW: 3 W", 43, "2 Kg (4.41 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1115, "61*183*162 mm (2.4*7.2*6.38in)", "Icom/ic202e.jpg", "IC-202E", "Max 3 W", 43, "2 Kg (4.41 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1114, "61*183*162 mm (2.4*7.2*6.38in)", "Icom/ic202a.jpg", "IC-202A", @"SSB: 3 W (PEP)
CW: 3 W", 43, "2 Kg (4.41 lbs), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1097, "140*40*200 mm (5.51*1.58*7.87in)", "Icom/ic1201.jpg", "IC-1201E", @"HighLow
23 cm:10 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1098, "286*111*276 mm (11.26*4.37*10.87in)", "Icom/ic1271.jpg", "IC-1271", @"FM/CW: 1-10 W
SSB: 1-10 W (PEP)", 43, "7.1 Kg (15.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1099, "286*111*276 mm (11.26*4.37*10.87in)", "Icom/ic1271a.jpg", "IC-1271A", @"FM/CW: 1-10 W
SSB: 1-10 W (PEP)", 43, "7.1 Kg (15.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1100, "286*111*276 mm (11.26*4.37*10.87in)", "Icom/ic1271e.jpg", "IC-1271E", @"FM/CW: 1-10 W
SSB: 1-10 W (PEP)", 43, "7.1 Kg (15.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1101, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic1275.jpg", "IC-1275", @"FM/CW: 1-10 W
SSB: 1-10 W (PEP)", 43, "6.2 Kg (13.67 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1102, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic1275a.jpg", "IC-1275A", @"FM/CW: 1-10 W
SSB: 1-10 W (PEP)", 43, "6.2 Kg (13.67 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1103, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic1275e.jpg", "IC-1275E", @"FM/CW: 1-10 W
SSB: 1-10 W (PEP)", 43, "6.2 Kg (13.67 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1104, "65*171*36 mm (2.56*6.73*1.42in), with BP-3", "Icom/ic12at.jpg", "IC-12AT", @"HighLow
23 cm:1 W100 mW", 43, "610 g (1.34 lbs), with BP-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1105, "65*171*36 mm (2.56*6.73*1.42in), with BP-3", "Icom/ic12e.jpg", "IC-12E", @"HighLow
23 cm:1 W100 mW", 43, "610 g (1.34 lbs), with BP-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1106, "65*130*35 mm (2.56*5.12*1.38in)", "Icom/ic12gat.jpg", "IC-12GAT", "Hi: 1 W @ 8.4 VDCLo: 100 mW", 43, "470 g (16.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1107, "65*130*35 mm (2.56*5.12*1.38in)", "Icom/ic12ge.jpg", "IC-12GE", "Hi: 1 W @ 8.4 VDCLo: 100 mW", 43, "470 g (16.58 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1108, "155*58*216 mm (6.12*2.28*8.5in)", "Icom/ic20.jpg", "IC-20", @"HighLow
2 m:10 W1 W", 43, "2.04 Kg (4.5 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1109, "156*58*247 mm (6.14*2.28*9.72in)", "Icom/ic200.jpg", "IC-200", @"HighLow
2 m:10 W1 W", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1110, "150*50*151 mm (5.91*1.97*5.94in)", "Icom/ic2000.jpg", "IC-2000", @"HighLow
2 m:10 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1111, "150*50*151 mm (5.91*1.97*5.94in)", "Icom/ic2000h.jpg", "IC-2000H", @"HighMidLow
2 m:50 W10 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1112, "230*110*260 mm (9.06*4.33*10.24in)", "Icom/ic201.jpg", "IC-201", @"FM/CW: Max 10 W
SSB: Max 10 W (PEP)", 43, "5.4 Kg (11.9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1113, "61*183*162 mm (2.4*7.2*6.38in)", "Icom/ic202.jpg", "IC-202", "CW: 3 WUSB: 3 W (PEP)", 43, "2 Kg (4.41 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1056, "? mm", "Heathkit/hx1675.jpg", "HX-1675", "35 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1134, "140*50*137 mm (5.5*2*5.4in)", "Icom/ic228e.jpg", "IC-228E", "Hi: 25 W, Lo: 5 W", 43, "850 g (1.9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1055, "? mm", "Heathkit/hws4xl.jpg", "Heath HWS-4-XL", "Hi: 5 W, Lo: 400 mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1053, "? mm", "Heathkit/hws2xl.jpg", "Heath HWS-2-XL", "Hi: 5 W, Lo: 400 mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 996, "260*80*270 mm (10.24*3.15*10.63in)", "Handic/handic_0016.jpg", "0016", "", 40, "3.7 Kg (8.16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 997, "? mm", "Handic/handic_0020.jpg", "0020", "", 40, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 998, "72*166*36 mm (2.84*6.54*1.42in)", "Handic/handic_004.jpg", "004", "", 40, "275 g (9.7 oz), without batteries and antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 999, "? mm (?in)", "Handic/handic_0050.jpg", "0050", "", 40, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1000, "115*45*165 mm (4.52*1.77*6.5in)", "Handic/handic_006.jpg", "006 (Newer)", "", 40, "540 g (19.05 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1001, "260*80*200 mm (10.24*3.15*7.87in)", "Handic/handic_0060.jpg", "0060", "", 40, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1002, "115*40*200 mm (4.53*1.58*7.87in)", "Handic/handic_006uhf.jpg", "006 UHF", "", 40, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 995, "260*80*270 mm (10.2*3.2*10.6in)", "Handic/0012.jpg", "0012", "", 40, "2.4 Kg (5.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1003, "115*45*165 mm (4.52*1.77*6.5in)", "Handic/handic_006_old.jpg", "006 (Older)", "", 40, "540 g (19.05 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1005, "132*38*183 mm (5.2*1.5*7.2in)", "Handic/handic_008.jpg", "008", "", 40, "675 gr (1.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1006, "220*76*205 mm (8.7*3*8.3in)", "Handic/handic_0080.jpg", "0080", "", 40, "2.2 Kg (4.85 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1007, "132*38*183 mm (5.2*1.5*7.2in)", "Handic/handic_0082.jpg", "0082", "", 40, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1008, "240*100*160 mm (9.45*3.94*6.3in)", "Handic/handic_009.jpg", "009", "", 40, "2.05 Kg (4.52 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1009, "130*50*180 mm (5.12*1.97*7.09in)", "Handic/handic_1600.jpg", "1600", "", 40, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1010, "130*60*180 mm (5.12*2.36*7.09in)", "Handic/handic_1600mkii.jpg", "1600 MKII", "", 40, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1011, "130*60*180 mm (5.12*2.36*7.09in)", "Handic/handic_1600mkiii.jpg", "1600 MKIII", "", 40, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1004, "210*65*200 mm (8.27*2.56*7.87in)", "Handic/007.jpg", "007", "", 40, "1.98 Kg (4.36 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1012, "167*43*190 mm (6.58*1.69*7.48in)", "Handic/handic_2310s.jpg", "2310S", "", 40, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 994, "?*266*? mm (?*10.47*?in)", "Hammarlund/spr200series.jpg", "SPR-220-X", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 992, "?*266*? mm (?*10.47*?in)", "Hammarlund/spr200series.jpg", "SPR-220-LX", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 976, "?*266*? mm (?*10.47*?in)", "Hammarlund/sp200series.jpg", "Super-Pro SP-210-LX", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 977, "?*266*? mm (?*10.47*?in)", "Hammarlund/sp200series.jpg", "Super-Pro SP-210-SX", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 978, "?*266*? mm (?*10.47*?in)", "Hammarlund/sp200series.jpg", "Super-Pro SP-210-X", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 979, "?*266*? mm (?*10.47*?in)", "Hammarlund/sp200series.jpg", "Super-Pro SP-220-LX", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 980, "?*266*? mm (?*10.47*?in)", "Hammarlund/sp200series.jpg", "Super-Pro SP-220-SX", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 981, "?*266*? mm (?*10.47*?in)", "Hammarlund/sp200series.jpg", "Super-Pro SP-220-X", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 982, "546*311*387 mm (21.5*12.25*15.25in)", "Hammarlund/sp400x.jpg", "Super-Pro SP-400-X", "", 39, "30.4 Kg (67 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 993, "?*266*? mm (?*10.47*?in)", "Hammarlund/spr200series.jpg", "SPR-220-SX", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 983, "? mm", "Hammarlund/sp600jx.jpg", "SP-600-JX-1 (R-274A/FRR)", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 985, "483*267*419 mm (19*10.5*16.5in)", "Hammarlund/sp600jx21a.jpg", "SP-600-JX-21A", "", 39, "33 Kg (72.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 986, "? mm", "Hammarlund/sp600jx6.jpg", "SP-600-JX-6 (US Navy model R-274B/FRR)", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 987, "545*315*432 mm (21.46*12.4*17in), with cabinet", "Hammarlund/sp600j_northern159.jpg", "SP-600-J \"Northern Radio 159\"", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 988, "? mm", "Hammarlund/sp600vlf31.jpg", "SP-600-VLF-31", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 989, "?*266*? mm (?*10.47*?in)", "Hammarlund/spr200series.jpg", "SPR-210-LX", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 990, "?*266*? mm (?*10.47*?in)", "Hammarlund/spr200series.jpg", "SPR-210-SX", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 991, "?*266*? mm (?*10.47*?in)", "Hammarlund/spr200series.jpg", "SPR-210-X", "", 39, "33 Kg (72.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 984, "? mm", "Hammarlund/sp600jx17.jpg", "SP-600-JX-17", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1013, "190*220*90 mm (7.48*8.66*3.54in)", "Handic/handic_ml.jpg", "ML", "", 40, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1014, "? mm", "Heathkit/cr1.jpg", "CR-1", "", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1015, "526*349*406 mm (20.7*13.75*16in)", "Heathkit/dx100.jpg", "DX-100", "AM: Max 125 WCW: Max 140 W", 41, "45.36 Kg (100 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1037, "?", "Heathkit/hw202.jpg", "HW-202", "10 W", 41, "?" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1038, "210*70*249 mm (8.27*2.76*9.8in)", "Heathkit/hw2036.jpg", "HW-2036", "10 W", 41, "3.2 Kg (7.06 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1039, "150*50*180 mm (5.91*1.97*7.09in)", "Heathkit/hw24.jpg", "Heath HW-24", "Hi: 10/10 W, Lo: 1/1 W", 41, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1040, "150*50*205 mm (5.91*1.97*8.07in)", "Heathkit/hw24h.jpg", "Heath HW-24-H", @"2 mHi: 50 W, Lo: 5 W


70 cmHi: 40 W, Lo: 5 W", 41, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1041, "245*169*131 mm (9.65*6.65*5.16in)", "Heathkit/hw29a.jpg", "HW-29A (The \"Sixer\")", "5 W (Input)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1042, "? mm", "Heathkit/hw2m-4m.jpg", "Heath HW-2M", "Hi: 5 WMid: 2.5 W, Lo: 350 mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1043, "? mm", "Heathkit/hw2p-4p.jpg", "Heath HW-2P", "Hi: 5 WMid: 2.5 W, Lo: 300 mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1036, "? mm", "Heathkit/hw20.jpg", "HW-20", "10 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1044, "245*169*131 mm (9.65*6.65*5.16in)", "Heathkit/hw30.jpg", "HW-30 (The \"Twoer\", a.k.a. \"The Benton Harbor Lunchbox\")", "5 W (Input)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1046, "? mm", "Heathkit/hw2p-4p.jpg", "Heath HW-4P", "Hi: 5 WMid: 2.5 W, Lo: 300 mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1047, "? mm", "Heathkit/hw5400.jpg", "HW-5400", "100 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1048, "231*99*187 mm (9.09*3.9*7.36in)", "Heathkit/hw7.jpg", "HW-7", "2-3 W (DC input)", 41, "1.9 Kg (4.19 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1049, "235*108*216 mm (9.25*4.25*8.5in)", "Heathkit/hw8.jpg", "HW-8", "Max 3.5 W", 41, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1050, "235*108*216 mm (9.25*4.25*8.5in)", "Heathkit/hw9.jpg", "HW-9", "Max 4 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1051, "? mm", "Heathkit/hws2.jpg", "Heath HWS-2", "Hi: 3 W, Lo: 400 mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1052, "? mm", "Heathkit/hws24ht.jpg", "Heath HWS-24-HT", "Hi: 5/5 W, Lo: ?/? mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1045, "? mm", "Heathkit/hw2m-4m.jpg", "Heath HW-4M", "Hi: 5 WMid: 2.5 W, Lo: 350 mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1035, "245*169*131 mm (9.65*6.65*5.16in)", "Heathkit/hw19.jpg", "HW-19 (The \"Tener\")", "5 W (Input)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1034, "? mm", "Heathkit/hw16.jpg", "HW-16", "90 W (input)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1033, "? mm", "Heathkit/hw12a.jpg", "HW-12A", "Approx. 100 W (200 W PEP input)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1016, "? mm", "Heathkit/dx40.jpg", "DX-40", "AM: 60 W (input)CW: 75 W (input)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1017, "? mm", "Heathkit/dx60.jpg", "DX-60", "50 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1018, "175*250*300 mm (6.89*9.84*11.81in)", "Heathkit/gc1mohican.jpg", "GC-1 \"Mohican\"", "", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1019, "305*175*254 mm (12*6.88*10in)", "Heathkit/gc1amohican.jpg", "GC-1A \"Mohican\"", "", 41, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1020, "305*175*254 mm (12*6.88*10in)", "Heathkit/gc1umohican.jpg", "GC-1U \"Mohican\"", "", 41, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1021, "370*160*280 mm (14.57*6.3*11.02in)", "Heathkit/gr54.jpg", "GR-54", "", 41, "8.5 Kg (18.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1022, "? mm", "Heathkit/gr64.jpg", "GR-64", "", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1023, "292*159*229 mm (11.5*6.25*9in)", "Heathkit/gr78.jpg", "GR-78", "", 41, "4.54 Kg (10 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1024, "? mm", "Heathkit/gr81.jpg", "GR-81", "", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1025, "? mm", "Heathkit/gr88.jpg", "GR-88", "", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1026, "311*133*209 mm (12.24*5.24*8.23in)", "Heathkit/gr91.jpg", "GR-91", "", 41, "4 Kg (8.82 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1027, "? mm", "Heathkit/hr10.jpg", "HR-10", "", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1028, "324*171*305 mm (12.76*6.73*12.01in)", "Heathkit/hr1680.jpg", "HR-1680", "", 41, "6.3 Kg (13.89 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1029, "? mm", "Heathkit/hw10.jpg", "HW-10 \"Shawnee\"", "10 W", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1030, "370*160*340 mm (14.57*6.3*13.39in)", "Heathkit/hw101.jpg", "HW-101", "100 W (80 W on 10 m)", 41, "8.5 Kg (18.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1031, "367*146*352 mm (14.45*5.75*13.86in)", "Heathkit/hw104.jpg", "HW-104", "Hi: 100 W, Lo: 1 W", 41, "7 Kg (15.43 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1032, "305*152*254 mm (12*6*10in)", "Heathkit/hw12.jpg", "HW-12", "Approx. 100 W (200 W PEP input)", 41, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1054, "? mm", "Heathkit/hws4.jpg", "Heath HWS-4", "Hi: 3 W, Lo: 400 mW", 41, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1135, "140*50*159 mm (5.5*2*6.3in)", "Icom/ic228h.jpg", "IC-228H", "Hi: 45 W, Lo: 5 W", 43, "1.1 Kg (2.4 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1136, "140*40*105 mm (5.5*1.6*4.1in)", "Icom/ic229a.jpg", "IC-229A", "Hi: 25 W, Lo3: 10 W, Lo2: 5 W, Lo1: 1 W", 43, "750 g (1.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1137, "140*40*105 mm (5.5*1.6*4.1in)", "Icom/ic229e.jpg", "IC-229E", "Hi: 25 W, Lo3: 10 W, Lo2: 5 W, Lo1: 1 W", 43, "750 g (1.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1240, "65*180*35 mm (2.56*7.09*1.38in), with BP-70", "Icom/ic32at.jpg", "IC-32AT", @"High@ 13.2VLow
2 m:5.5 W1 W
70 cm:5 W1 W", 43, "590 g (1.3 lbs), with BP-70" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1241, "65*159*35 mm (2.56*6.26*1.38in), with BP-3", "Icom/ic32e.jpg", "IC-32E", @"High@ 13.2VLow
2 m:5.5 W1 W
70 cm:5 W1 W", 43, "510 g (1.12 lbs), with BP-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1242, "65*159*35 mm (2.56*6.26*1.38in), with BP-3", "Icom/ic32et.jpg", "IC-32ET", @"High@ 13.2VLow
2 m:5.5 W1 W
70 cm:5 W1 W", 43, "510 g (1.12 lb), with BP-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1243, "? mm (?in)", "Icom/ic339.jpg", "IC-339", "Hi: ? W, Lo: ? W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1244, "140*50*177 mm (5.51*1.97*9.97in)", "Icom/ic35.jpg", "IC-35", @"HighLow
70 cm:10 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1245, "241*141*264 mm (9.49*5.55*10.39in)", "Icom/ic351.jpg", "IC-351", "1-10 W adjustable", 43, "7.2 Kg (15.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1246, "? mm (?in)", "Icom/ic37.jpg", "IC-37", @"HighLow
70 cm:10 W1 W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1239, "140*40*165 mm (5.51*1.58*6.5in)", "Icom/ic3230h.jpg", "IC-3230H", @"HighLow 2Low 1
2 m:45 W10 W1 W
70 cm:35 W10 W1 W", 43, "1.25 Kg (2.76 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1247, "156*58*228 mm (6.14*2.28*8.98in)", "Icom/ic370.jpg", "IC-370", @"HighLow
70 cm:10 W1 W", 43, "2.2 Kg (4.85 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1249, "140*40*177 mm (5.51*1.58*6.97in)", "Icom/ic3700.jpg", "IC-3700D", @"HighLow 2Low 1
70 cm:35 W10 W5 W
23 cm:10 W- W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1250, "140*40*177 mm (5.51*1.58*6.97in)", "Icom/ic3700.jpg", "IC-3700M", @"HighLow 2Low 1
70 cm:25 W10 W3 W
23 cm:10 W- W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1251, "156*58*228 mm (6.14*2.28*8.98in)", "Icom/ic370a.jpg", "IC-370A", @"HighLow
70 cm:10 W1 W", 43, "2.2 Kg (4.85 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1252, "285*110*275 mm (11.22*4.33*10.83in)", "Icom/ic371.jpg", "IC-371", "1-10 W", 43, "6 Kg (13.23 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1253, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic375a.jpg", "IC-375A", "2.5-25 W adjustable", 43, "6.2 Kg (13.67 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1254, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic375d.jpg", "IC-375D", "5-50 W adjustable", 43, "6 Kg (13.23 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1255, "140*38*177 mm (5.51*1.5*6.97in)", "Icom/ic37a.jpg", "IC-37A", @"HighLow
1.25 m:25 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1248, "140*40*159 mm (5.51*1.58*6.26in)", "Icom/ic3700.jpg", "IC-3700", @"HighLow 2Low 1
70 cm:10 W3 W500 mW
23 cm:10 W- W1 W", 43, "1.36 Kg (3 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1256, "140*50*171 mm (5.51*1.97*6.73in)", "Icom/ic38a.jpg", "IC-38A", @"HighLow
1.25 m:25 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1238, "140*40*195 mm (5.51*1.58*7.68in)", "Icom/ic3220h.jpg", "IC-3220H", @"HighLow 2Low 1
2 m:45 W10 W5 W
70 cm:35 W10 W5 W", 43, "1.4 Kg (3.09 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1236, "140*50*180 mm (5.5*2*7.1in)", "Icom/ic3210e.jpg", "IC-3210E", @"HighLow
2 m:25 W5 W
70 cm:25 W5 W", 43, "1.2 Kg (2.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1220, "? mm (?in)", "Icom/ic2gxat.jpg", "IC-2GXET", @"HighMid1Mid2Low
2 m:7 W? W? mW? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1221, "58*91*30 mm (2.28*3.58*1.18in), with BP-121", "Icom/ic2ie.jpg", "IC-2iE", @"HighLow3Low2Low1
2 m:5 W2.5 W500 mW20 mW", 43, "260 g (9.17 oz), with BP-121" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1222, "65*165*35 mm (2.56*6.5*1.38in), with BP-4", "Icom/ic2n.jpg", "IC-2N", "Hi: 1.5 W, Lo: 150 mW", 43, "490 g (1.08 lbs), with BP-4 loaded with six LR6/AA batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1223, "49*103*35 mm (1.93*4.06*1.38in)", "Icom/ic2sat.jpg", "IC-2SAT", @"HighLow3Low2Low1
2 m:5 W3.5 W1.5 W500 mW", 43, "280 g (9.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1224, "49*104*33 mm (1.93*4.09*1.3in), with BP-82", "Icom/ic2se.jpg", "IC-2SE", @"HighLow3Low2Low1
2 m:5 W3.5 W1.5 W500 mW", 43, "270 g (9.52 oz), with BP-82" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1225, "49*103*35 mm (1.93*4.06*1.38in)", "Icom/ic2set.jpg", "IC-2SET", @"HighLow3Low2Low1
2 m:5 W3.5 W1.5 W500 mW", 43, "280 g (9.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1226, "54*135*36 mm (2.13*5.32*1.42in), with BP-82", "Icom/ic2sra.jpg", "IC-2SRA", @"Hi: 1.5-5 W (depending on voltage)
Lo3: 1.5-3.5 W (depending on voltage)
Lo2: 1.5 W, Lo1: 500 mW", 43, "395 g (13.93 oz), with BP-82" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1237, "140*40*195 mm (5.51*1.58*7.68in)", "Icom/ic3220e.jpg", "IC-3220E", @"HighLow 2Low 1
2 m:25 W10 W1 W
70 cm:25 W10 W1 W", 43, "1.4 Kg (3.09 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1227, "54*135*36 mm (2.13*5.32*1.42in), with BP-82", "Icom/ic2sre.jpg", "IC-2SRE", @"Hi: 1.5-5 W (depending on voltage)
Lo3: 1.5-3.5 W (depending on voltage)
Lo2: 1.5 W, Lo1: 500 mW", 43, "395 g (13.93 oz), with BP-82" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1229, "61*183*162 mm (2.4*7.2*6.38in)", "Icom/ic302.jpg", "IC-302", "Max 3 W", 43, "2 Kg (4.41 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1230, "156*58*244 mm (6.14*2.28*9.61in)", "Icom/ic30a.jpg", "IC-30A", @"HighLow
70 cm:10 W1 W", 43, "2.4 Kg (5.29 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1231, "230*111*260 mm (9.06*4.37*10.02in)", "Icom/ic31.jpg", "IC-31", "0.5 to 10 W", 43, "7.2 Kg (15.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1232, "156*58*245 mm (6.14*2.28*9.65in)", "Icom/ic320.jpg", "IC-320", @"HighLow
70 cm:10 W1 W", 43, "1.8 Kg (3.97 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1233, "140*50*207 mm (5.51*1.97*8.15in)", "Icom/ic3200a.jpg", "IC-3200A", @"HighLow
2 m:25 W5 W
70 cm:25 W5 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1234, "140*50*207 mm (5.51*1.97*8.15in)", "Icom/ic3200e.jpg", "IC-3200E", @"HighLow
2 m:25 W5 W
70 cm:25 W5 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1235, "140*50*180 mm (5.5*2*7.1in)", "Icom/ic3210a.jpg", "IC-3210A", @"HighLow
2 m:25 W5 W
70 cm:25 W5 W", 43, "1.2 Kg (2.6 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1228, "? mm (?in)", "Icom/ic30.jpg", "IC-30", @"HighLow
70 cm:10 W? W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1257, "170*64*218 mm (6.69*2.52*8.58in)", "Icom/ic390.jpg", "IC-390", @"HighLow
70 cm:10 W1 W", 43, "2.6 Kg (5.73 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1258, "65*117*35 mm (2.56*4.61*1.38in), without battery", "Icom/ic3at.jpg", "IC-3AT", @"HighLow
1.25 m:1.5 W150 mW", 43, "? g (? oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1259, "? mm (?in)", "Icom/ic3j.jpg", "IC-3J", @"HighMid1Mid2Low
70 cm:? W? W? mW? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1281, "170*64*218 mm (6.69*2.52*8.58in)", "Icom/ic490a.jpg", "IC-490A", "Hi: 10 W, Lo: 1 W", 43, "2.6 Kg (5.73 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1282, "170*64*218 mm (6.69*2.52*8.58in)", "Icom/ic490e.jpg", "IC-490E", "Hi: 10 W, Lo: 1 W", 43, "2.6 Kg (5.73 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1283, "65*165*35 mm (2.56*6.5*1.38in), with BP-3", "Icom/ic4at.jpg", "IC-4AT", @"Hi: 1.5-2.3 W (Depending on voltage/battery pack)
Lo: 150 mW", 43, "470 g (1.04 lbs), with BP-3 and supplied antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1284, "65*165*35 mm (2.56*6.5*1.38in), with BP-3", "Icom/ic4e.jpg", "IC-4E", @"Hi: 1.5-2.3 W (Depending on voltage/battery pack)
Lo: 150 mW", 43, "470 g (1.04 lbs), with BP-3 and supplied antenna" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1285, "? mm (?in)", "Icom/ic4ge.jpg", "IC-4GE", @"HighLow
70 cm:? W? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1286, "? mm (?in)", "Icom/ic4gxe.jpg", "IC-4GXE", @"HighLow
70 cm:6 W? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1287, "? mm (?in)", "Icom/ic4gxet.jpg", "IC-4GXET", @"HighLow
70 cm:6 W? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1280, "140*50*155 mm (5.51*1.97*6.1in)", "Icom/ic48e.jpg", "IC-48E", @"HighLow
70 cm:25 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1288, "58*91*30 mm (2.28*3.58*1.18in), with BP-121", "Icom/ic4ie.jpg", "IC-4iE", @"HighLow 3Low 2Low 1
70 cm:5 W2.5 W500 mW20 mW", 43, "260 g (9.17 oz), with BP-121" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1290, "49*103*33 mm (1.93*4.06*1.3in), with BP-82", "Icom/ic4set.jpg", "IC-4SET", @"HighLow 3Low 2Low 1
70 cm:5 W3.5 W1.5 W500 mW", 43, "280 g (9.88 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1291, "54*135*36 mm (2.13*5.32*1.42in), with BP-82", "Icom/ic4sra.jpg", "IC-4SRA", @"Hi: 1.5-5 W (depending on voltage)
Lo3: 1.5-3.5 W (depending on voltage)
Lo2: 1.5 W, Lo1: 500 mW", 43, "385 g (13.6 oz), with BP-82" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1292, "54*135*36 mm (2.13*5.32*1.42in), with BP-82", "Icom/ic4sre.jpg", "IC-4SRE", @"Hi: 1.5-5 W (depending on voltage)
Lo3: 1.5-3.5 W (depending on voltage)
Lo2: 1.5 W, Lo1: 500 mW", 43, "385 g (13.6 oz), with BP-82" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1293, "230*110*260 mm (9.06*4.33*10.24in)", "Icom/ic501.jpg", "IC-501", @"AM: Max 2.5 W
SSB: Max 10 W (PEP)
CW: 10 W", 43, "5.1 Kg (11.24 lb), without PSU option" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1294, "61*183*162 mm (2.4*7.2*6.4in)", "Icom/ic502.jpg", "IC-502", @"SSB: 3 W (PEP)
CW: 3 W", 43, "2 Kg (4.4 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1295, "61*183*162 mm (2.4*7.2*6.4in)", "Icom/ic502a.jpg", "IC-502A", @"SSB: 3 W (PEP)
CW: 3 W", 43, "2 Kg (4.4 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1296, "230*76*189 mm (9.1*3*7.4in)", "Icom/ic505.jpg", "IC-505", @"High@ 13.8VLow
2 m:10 W3 W", 43, "3.2 Kg (7.05 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1289, "49*103*33 mm (1.93*4.06*1.3in), with BP-82", "Icom/ic4se.jpg", "IC-4SE", @"HighLow 3Low 2Low 1
70 cm:5 W3.5 W1.5 W500 mW", 43, "270 g (9.52 oz), with BP-82" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1279, "140*50*155 mm (5.51*1.97*6.1in)", "Icom/ic48a.jpg", "IC-48A", @"HighLow
70 cm:25 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1278, "140*40*171 mm (5.5*1.6*6.7in)", "Icom/ic481h.jpg", "IC-481H", @"HighMidLow
70 cm:35 W10 W2 W", 43, "960 g (2.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1277, "140*41*238 mm (5.51*1.61*9.37in)", "Icom/ic47e.jpg", "IC-47E", @"HighLow
70 cm:25 W5 W", 43, "1.4 Kg (3.09 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1260, "? mm (?in)", "Icom/ic3n.jpg", "IC-3N", @"HighLow
70 cm:1.5 W? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1261, "? mm (?in)", "Icom/ic3sat.jpg", "IC-3SAT", @"HighLow
1.25 m:? W? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1262, "61*183*162 mm (2.4*7.2*6.4in)", "Icom/ic402_front_back.jpg", "IC-402", @"SSB: 3 W (PEP)
CW: 3 W", 43, "2 Kg (4.4 lb), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1263, "140*50*159 mm (5.51*1.97*6.26in)", "Icom/ic448e.jpg", "IC-448E", @"HighLow
70 cm:35 W5 W", 43, "850 g (1.9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1264, "140*40*155 mm (5.5*1.6*6.1in)", "Icom/ic449a.jpg", "IC-449A", @"HighLow 3Low 2Low 1
70 cm:35 W20 W10 W5 W", 43, "1 Kg (2.2 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1265, "140*40*155 mm (5.5*1.6*6.1in)", "Icom/ic449e.jpg", "IC-449E", @"HighLow 3Low 2Low 1
70 cm:35 W20 W10 W5 W", 43, "1 Kg (2.2 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1266, "241*111*264 mm (9.5*4.37*10.4in)", "Icom/ic451a.jpg", "IC-451A", "1-10 W adjustable", 43, "7.2 Kg (15.9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1267, "241*111*264 mm (9.5*4.37*10.4in)", "Icom/ic451e.jpg", "IC-451E", "1-10 W adjustable", 43, "7.2 Kg (15.9 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1268, "140*50*177 mm (5.51*1.97*6.97in)", "Icom/ic45a.jpg", "IC-45A", @"HighLow
70 cm:10 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1269, "140*50*177 mm (5.51*1.97*6.97in)", "Icom/ic45e.jpg", "IC-45E", @"HighLow
70 cm:10 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1270, "285*110*275 mm (11.22*4.33*10.83in)", "Icom/ic471a.jpg", "IC-471A", "Max 25 W", 43, "6 Kg (13.23 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1271, "285*110*275 mm (11.22*4.33*10.83in)", "Icom/ic471e.jpg", "IC-471E", "Max 25 W", 43, "6 Kg (13.23 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1272, "285*110*275 mm (11.22*4.33*10.83in)", "Icom/ic471h.jpg", "IC-471H", "10-75 W adjustable", 43, "7.1 Kg (15.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1273, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic475a.jpg", "IC-475A", "2.5-25 W adjustable", 43, "6.3 Kg (13.89 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1274, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic475e.jpg", "IC-475E", "2.5-25 W adjustable", 43, "6.3 Kg (13.89 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1275, "241*95*239 mm (9.49*3.74*9.41in)", "Icom/ic475h.jpg", "IC-475H", "10-75 W adjustable", 43, "6 Kg (13.23 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1276, "140*41*238 mm (5.51*1.61*9.37in)", "Icom/ic47a.jpg", "IC-47A", @"HighLow
70 cm:25 W5 W", 43, "1.4 Kg (3.09 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1219, "? mm (?in)", "Icom/ic2gxa.jpg", "IC-2GXE", @"HighMid1Mid2Low
2 m:7 W? W? mW? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1218, "? mm (?in)", "Icom/ic2gxat.jpg", "IC-2GXAT", @"HighMid1Mid2Low
2 m:7 W? W? mW? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1217, "? mm (?in)", "Icom/ic2gxa.jpg", "IC-2GXA", @"HighMid1Mid2Low
2 m:7 W? W? mW? mW", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1216, "65*130*35 mm (2.56*5.12*1.38in), with BP-3", "Icom/ic2ge.jpg", "IC-2GE", @"Hi: 3.5-7 W (Depending on battery pack/voltage)
Lo: 1 W", 43, "430 g (15.17 oz), with BP-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1159, "140*40*175 mm (5.51*1.58*6.89in)", "Icom/ic2410e.jpg", "IC-2410E", @"HighMidLow
2 m:25 W10 W1 W
70 cm:25 W10 W1 W", 43, "1.35 Kg (2.98 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1160, "140*40*175 mm (5.51*1.58*6.89in)", "Icom/ic2410h.jpg", "IC-2410H", @"HighMidLow
2 m:45 W10 W5 W
70 cm:35 W10 W5 W", 43, "1.35 Kg (2.98 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1161, "155*57*235 mm (6.1*2.24*9.25in), without optional SSB adapter", "Icom/ic245.jpg", "IC-245", @"FM/CW: 10 W
SSB: Max 10 W (PEP), with optional SSB adapter", 43, "2.7 Kg (5.95 lbs), without optional SSB adapter" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1162, "155*90*235 mm (6.1*3.54*9.25in)", "Icom/ic245e.jpg", "IC-245E", @"FM/CW: 10 W
SSB: Max 10 W (PEP)", 43, "2.7 Kg (5.95 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1163, "52*136*34 mm (2*5.4*1.4in), with BP-82", "Icom/ic24at.jpg", "IC-24AT", @"High@ 13.8VHigh@ 7.2VLow 3@ 13.8VLow 3@ 7.2VLow 2Low 1
2 m:5 W1.5 W3.5 W1.5 W1.5 W500 mW
70 cm:5 W1.5 W3.5 W1.5 W1.5 W500 mW", 43, "340 g (12 oz), with antenna and BP-82" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1164, "156*58*218 mm (6.14*2.28*8.58in)", "Icom/ic24e.jpg", "IC-24E", @"HighLow
2 m:10 W1 W", 43, "1.7 Kg (3.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1165, "52*136*34 mm (2*5.4*1.4in), with BP-82", "Icom/ic24et.jpg", "IC-24ET", @"High@ 13.8VHigh@ 7.2VLow 3@ 13.8VLow 3@ 7.2VLow 2Low 1
2 m:5 W1.5 W3.5 W1.5 W1.5 W500 mW
70 cm:5 W1.5 W3.5 W1.5 W1.5 W500 mW", 43, "340 g (12 oz), with antenna and BP-82" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1158, "150*50*195 mm (5.9*2*7.7in)", "Icom/ic2400e.jpg", "IC-2400E", @"HighLow
2 m:45 W5 W
70 cm:35 W5 W", 43, "1.7 Kg (3.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1166, "156*58*218 mm (6.14*2.28*8.58in)", "Icom/ic250.jpg", "IC-250", @"HighLow
2 m:10 W1 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1168, "150*50*195 mm (5.91*1.97*7.68in)", "Icom/ic2500e.jpg", "IC-2500E", @"HighLow
70 cm:35 W5 W
23 cm:10 W1 W", 43, "1.8 Kg (3.97 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1169, "241*111*264 mm (9.5*4.4*10.4in)", "Icom/ic251a.jpg", "IC-251A", @"FM: 1-10 W
SSB: 10 W (PEP)
CW: 10 W", 43, "5 Kg (11 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1170, "241*111*264 mm (9.5*4.4*10.4in)", "Icom/ic251e.jpg", "IC-251E", @"FM: 1-10 W
SSB: 10 W (PEP)
CW: 10 W", 43, "5 Kg (11 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1171, "185*64*223 mm (7.28*2.52*8.78in)", "Icom/ic255a.jpg", "IC-255A", @"HighLow
2 m:25 W1 W", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1172, "185*64*223 mm (7.28*2.52*8.78in)", "Icom/ic255e.jpg", "IC-255E", @"HighLow
2 m:25 W1 W", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1173, "140*50*177 mm (5.51*1.97*6.97in)", "Icom/ic25a.jpg", "IC-25A", @"HighLow
2 m:25 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1174, "140*50*177 mm (5.51*1.97*6.97in)", "Icom/ic25e.jpg", "IC-25E", @"HighLow
2 m:25 W1 W", 43, "1.5 Kg (3.31 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1167, "150*50*195 mm (5.91*1.97*7.68in)", "Icom/ic2500a.jpg", "IC-2500A", @"HighLow
70 cm:35 W5 W
23 cm:10 W1 W", 43, "1.8 Kg (3.97 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1157, "150*50*195 mm (5.9*2*7.7in)", "Icom/ic2400a.jpg", "IC-2400A", @"HighLow
2 m:45 W5 W
70 cm:35 W5 W", 43, "1.7 Kg (3.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1156, "156*58*218 mm (6.14*2.28*8.58in)", "Icom/ic240.jpg", "IC-240", "10 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1155, "140*40*204 mm (5.51*1.58*8.03in)", "Icom/ic2350h.jpg", "IC-2350H", @"HighMidLow
2 m:50 W10 W5 W
70 cm:35 W10 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1138, "140*40*155 mm (5.5*1.6*6.1in)", "Icom/ic229h.jpg", "IC-229H", "Hi: 50 W, Lo3: 25 W, Lo2: 10 W, Lo1: 5 W", 43, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1139, "156*58*205 mm (6.14*2.28*8.07in)", "Icom/ic22a.jpg", "IC-22A", @"HighLow
2 m:10 W1 W", 43, "1.7 Kg (3.75 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1140, "156*58*218 mm (6.14*2.3*8.6in)", "Icom/ic22s.jpg", "IC-22S", @"HighLow
2 m:10 W1 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1141, "65*159*35 mm (2.56*6.26*1.38in), with BP-3", "Icom/ic23.jpg", "IC-23", @"HighLow
2 m:5.5 W1 W
70 cm:5 W1 W", 43, "510 g (1.12 lbs), with BP-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1142, "156*58*247 mm (6.14*2.28*9.72in)", "Icom/ic230.jpg", "IC-230", "10 W", 43, "2.4 Kg (5.29 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1143, "140*50*207 mm (5.51*1.97*8.15in)", "Icom/ic2300.jpg", "IC-2300", @"HighLow
2 m:10 W1 W
70 cm:10 W1 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1144, "140*50*218 mm (5.51*1.97*8.58in)", "Icom/ic2300d.jpg", "IC-2300D", @"HighLow
2 m:25 W5 W
70 cm:25 W5 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1145, "140*40*118 mm (5.51*1.58*4.6in)", "Icom/ic2300h.jpg", "IC-2300H", @"HighMidMid-LoLow 1
2 m:65 W25 W10 W5 W", 43, "1.1 Kg (2.42 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1146, "140*40*162 mm (5.51*1.58*6.38in)", "Icom/ic2300t.jpg", "IC-2300-T", @"HighMidMid-LoLow
2 m:65 W25 W10 W5 W", 43, "1.1 Kg (2.42 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1147, "140*50*180 mm (5.51*1.97*7.09in)", "Icom/ic2310.jpg", "IC-2310", @"HighLow
2 m:10 W1 W
70 cm:10 W1 W", 43, "1.7 Kg (3.75 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1148, "140*50*180 mm (5.51*1.97*7.09in)", "Icom/ic2310d.jpg", "IC-2310D", @"HighLow
2 m:25 W5 W
70 cm:25 W5 W", 43, "1.7 Kg (3.75 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1149, "155*90*235 mm (6.1*3.54*9.25in)", "Icom/ic232.jpg", "IC-232", @"FM/CW Hi: 10 W, Lo: 1 W
SSB: Max 10 W (PEP)", 43, "2.7 Kg (5.95 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1150, "140*40*165 mm (5.51*1.58*6.5in)", "Icom/ic2330a.jpg", "IC-2330A", @"HighLow 2Low 1
2 m:45 W10 W5 W
1.25 m:25 W10 W5 W", 43, "1.25 Kg (2.76 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1151, "140*40*165 mm (5.51*1.58*6.5in)", "Icom/ic2340.jpg", "IC-2340", @"2 mHi: 10 WMid: 5 W, Lo: 1 W


70 cmHi: 10 WMid: 5 W, Lo: 1 W", 43, "1.3 Kg (2.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1152, "140*40*165 mm (5.51*1.58*6.5in)", "Icom/ic2340a.jpg", "IC-2340A", @"2 mHi: 25 WMid: 10 W, Lo: 1 W


70 cmHi: 25 WMid: 10 W, Lo: 1 W", 43, "1.3 Kg (2.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1153, "140*40*165 mm (5.51*1.58*6.5in)", "Icom/ic2340a.jpg", "IC-2340E", @"2 mHi: 25 WMid: 10 W, Lo: 1 W


70 cmHi: 25 WMid: 10 W, Lo: 1 W", 43, "1.3 Kg (2.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1154, "140*40*165 mm (5.51*1.58*6.5in)", "Icom/ic2340h.jpg", "IC-2340H", @"2 mHi: 45 WMid: 10 W, Lo: 5 W


70 cmHi: 35 WMid: 10 W, Lo: 5 W", 43, "1.3 Kg (2.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1175, "140*50*222 mm (5.51*1.97*8.74in)", "Icom/ic25h.jpg", "IC-25H", @"HighLow
2 m:45 W2 W", 43, "1.9 Kg (4.19 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 975, "? mm", "Hammarlund/sp100mrm5.jpg", "Super-Pro SP-100 \"MRM-5\"", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1176, "? mm (?in)", "Icom/ic26.jpg", "IC-26", @"HighLow
2 m:10 W1 W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1178, "140*50*207 mm (5.51*1.97*8.15in)", "Icom/ic2600d.jpg", "IC-2600D", @"HighLow
2 m:25 W5 W
70 cm:25 W5 W", 43, "2 Kg (4.41 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1200, "156*58*228 mm (6.14*2.28*8.98in)", "Icom/ic280e.jpg", "IC-280E", @"HighLow
2 m:10 W1 W", 43, "2.2 Kg (4.85 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1201, "140*40*171 mm (5.5*1.6*6.7in)", "Icom/ic281h.jpg", "IC-281H", @"HighMidLow
2 m:50 W10 W5 W
70 cm:50 W10 W5 W", 43, "930 g (2.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1202, "Main unit: 150*40*188 mm (5.91*1.58*7.4in)Controller: 150*58*32 mm (5.91*2.28*1.26in)", "Icom/ic2820h.jpg", "IC-2820H", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W


High power = 25 W for Taiwan version", 43, "Main unit: 1.5 Kg (3.31 lb)Controller: 210 g (7.41 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1203, "140*50*133 mm (5.5*2*5.2in)", "Icom/ic28a.jpg", "IC-28A", @"HighLow
2 m:25 W5 W", 43, "950 g (2.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1204, "140*50*133 mm (5.5*2*5.2in)", "Icom/ic28e.jpg", "IC-28E", @"HighLow
2 m:25 W5 W", 43, "950 g (2.1 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1205, "140*50*155 mm (5.5*2*6.1in)", "Icom/ic28h.jpg", "IC-28H", @"HighLow
2 m:45 W5 W", 43, "1.2 Kg (2.64 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1206, "170*64*218 mm (6.7*2.52*8.6in)", "Icom/ic290.jpg", "IC-290", "Hi: 10 W, Lo: 1 W", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1199, "Main unit: 140*40*166 mm (5.5*1.6*6.5in)Controller: 140*70*34 mm (5.5*2.8*1.34in)", "Icom/ic2800h.jpg", "IC-2800H", @"HighMid-HiMid-LoLow
2 m:50 W20 W10 W5 W
70 cm:35 W20 W10 W5 W", 43, "Main unit: 1.15 Kg (2.54 lb)Controller: 290 g (10.23 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1207, "170*64*218 mm (6.7*2.52*8.6in)", "Icom/ic290a.jpg", "IC-290A", "Hi: 10 W, Lo: 1 W", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1209, "170*64*218 mm (6.7*2.52*8.6in)", "Icom/ic290e.jpg", "IC-290E", "Hi: 10 W, Lo: 1 W", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1210, "170*64*218 mm (6.69*2.52*8.58in)", "Icom/ic290h.jpg", "IC-290H", "Hi: 25 W, Lo: 1 W", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1211, "65*117*35 mm (2.56*4.61*1.38in), without battery pack", "Icom/ic2at.jpg", "IC-2AT", @"HighLow
2 m:1.5 W150 mW", 43, "490 g (17.28 oz), with BP3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1212, "65*117*35 mm (2.56*4.61*1.38in), without battery pack", "Icom/ic2e_1.jpg", "IC-2E", @"High@ 8.4VLow
2 m:1.5 W150 mW", 43, "490 g (17.28 oz), with BP3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1213, "156*58*216 mm (6.14*2.28*8.5in)", "Icom/ic2f.jpg", "Inoue (Icom) IC-2F", ">10 W (20 W input)", 43, "2 Kg (4.41 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1214, "65*130*35 mm (2.56*5.12*1.38in), with BP-3", "Icom/ic2ga.jpg", "IC-2GA", @"Hi: 3.5-7 W (Depending on battery pack/voltage)
Lo: 1 W", 43, "430 g (15.17 oz), with BP-3" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1215, "65*151*35 mm (2.56*5.94*1.38in), with BP-70", "Icom/ic2gat.jpg", "IC-2GAT", @"Hi: 3.5-7 W (Depending on battery pack/voltage)
Lo: 1 W", 43, "500 g (17.64 oz), with BP-70" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1208, "170*64*218 mm (6.69*2.52*8.58in)", "Icom/ic290d.jpg", "IC-290D", "Hi: 25 W, Lo: 1 W", 43, "2.5 Kg (5.51 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1198, "140**40*133 mm (5.51*1.58*5.24in)", "Icom/ic28.jpg", "IC-28", @"HighLow
2 m:10 W1 W", 43, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1197, "140**38*177 mm (5.51*1.5*6.97in)", "Icom/ic27.jpg", "IC-27H", @"HighLow
2 m:45 W5 W", 43, "1.3 Kg (2.87 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1196, "140**38*177 mm (5.51*1.5*6.97in)", "Icom/ic27.jpg", "IC-27E", @"HighLow
2 m:25 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1179, "185*64*223 mm (7.28*2.52*8.78in)", "Icom/ic260a.jpg", "IC-260A", @"HighLow
2 m:10 W1 W", 43, "2.7 Kg (5.95 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1180, "185*64*223 mm (7.28*2.52*8.78in)", "Icom/ic260e.jpg", "IC-260E", @"HighLow
2 m:10 W1 W", 43, "2.7 Kg (5.95 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1181, "156*58*228 mm (6.14*2.28*8.98in)", "Icom/ic270.jpg", "IC-270", @"HighLow
2 m:10 W1 W", 43, "2.2 Kg (4.85 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1182, "140*40*177 mm (5.51*1.58*6.97in)", "Icom/ic2700h.jpg", "IC-2700H", @"HighMidLow
2 m:50 W10 W5 W
70 cm:35 W10 W5 W", 43, "1.45 Kg (3.2 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1183, "140*40*212 mm (5.51*1.58*8.35in)", "Icom/ic2710h.jpg", "IC-2710H", @"HighMidLow
2 m:50 W10 W5 W
70 cm:35 W10 W5 W", 43, "1.4 Kg (3.08 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1184, "285*110*275 mm (11.22*4.33*10.83in)", "Icom/ic271a.jpg", "IC-271A", "1-25 W adjustable", 43, "5.2 Kg (11.46 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1185, "285*110*275 mm (11.22*4.33*10.83in)", "Icom/ic271.jpg", "IC-271E", "1-25 W adjustable", 43, "5.2 Kg (11.46 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1186, "285*110*275 mm (11.22*4.33*10.83in)", "Icom/ic271h.jpg", "IC-271H", "10-100 W adjustable", 43, "5.2 Kg (11.46 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1187, "Main unit: 140*40*187 mm (5.51*1.58*7.36in)Panel: 140*50*25 mm (5.51*1.97*0.98in)", "Icom/ic2720h.jpg", "IC-2720H", @"HighMidLow
2 m:50 W15 W5 W
70 cm:35 W15 W5 W


High power = 25 W for Taiwan version", 43, "Main unit: 1.25 Kg (2.76 lb)Panel: 150 g (5.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1188, "Main unit: 140*40*187 mm (5.51*1.58*7.36in)Panel: 140*50*25 mm (5.51*1.97*0.98in)", "Icom/ic2725e.jpg", "IC-2725E", @"HighMidLow
2 m:50 W15 W5 W
70 cm:35 W15 W5 W", 43, "Main unit: 1.25 Kg (2.76 lb)Panel: 150 g (5.29 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1189, "Body: 150*40*151 mm (5.91*1.57*5.94in)Controller: 150*50*27 mm (5.91*1.97*1.07in)", "Icom/ic2730.jpg", "IC-2730A", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "Body: 1.2 Kg (2.65 lb)Controller: 140 g (4.94 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1190, "Body: 150*40*151 mm (5.91*1.57*5.94in)Controller: 150*50*27 mm (5.91*1.97*1.07in)", "Icom/ic2730.jpg", "IC-2730D", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "Body: 1.2 Kg (2.65 lb)Controller: 140 g (4.94 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1191, "Body: 150*40*151 mm (5.91*1.57*5.94in)Controller: 150*50*27 mm (5.91*1.97*1.07in)", "Icom/ic2730.jpg", "IC-2730E", @"HighMidLow
2 m:50 W15 W5 W
70 cm:50 W15 W5 W", 43, "Body: 1.2 Kg (2.65 lb)Controller: 140 g (4.94 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1192, "241*95*239 mm (9.5*3.7*9.4in)", "Icom/ic275a.jpg", "IC-275A", "2.5-25 W adjustable", 43, "6.2 Kg (13.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1193, "241*95*239 mm (9.5*3.7*9.4in)", "Icom/ic275a.jpg", "IC-275E", "2.5-25 W adjustable", 43, "6.2 Kg (13.7 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1194, "241*95*239 mm (9.5*3.7*9.4in)", "Icom/ic275h.jpg", "IC-275H", "10-100 W adjustable", 43, "6 Kg (13.2 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1195, "140**38*177 mm (5.51*1.5*6.97in)", "Icom/ic27.jpg", "IC-27A", @"HighLow
2 m:25 W5 W", 43, "1.2 Kg (2.65 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 1177, "140*50*207 mm (5.51*1.97*8.15in)", "Icom/ic2600.jpg", "IC-2600", @"HighLow
2 m:10 W1 W
70 cm:10 W1 W", 43, "2 Kg (4.41 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2595, "57*127*35 mm (2.24*5*1.38in)", "Yupiteru/vt150.jpg", "VT-150", "", 78, "? g (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 974, "457*454*394 mm (18*17.9*15.5in)", "Hammarlund/pro310.jpg", "Pro-310", "", 39, "29.4 Kg (64.82 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 972, "? mm", "Hammarlund/hx50.jpg", "HX-50", "60 W", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 752, "343*114*254 mm (13.5*4.5*10in)", "Elecraft/k4.jpg", "K4HD", "100 W", 29, "4.54 Kg (10 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 753, "147*50*40 mm (5.8*2.8*1.5in)", "Elecraft/kx2.jpg", "KX2", @"10 and 12 mMax 8 W


15-80 mMax 10 W


Recommended TX duty cycle: 50 % all modes", 29, "370 gr (13 oz), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 754, "333*180*58 mm (13.11*7.09*2.28in)", "Eton/e1.jpg", "Et�n E1", "", 30, "1.9 Kg (4.19 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 755, "333*180*58 mm (13.11*7.09*2.28in)", "Eton/e1xm.jpg", "Et�n E1 XM", "", 30, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 756, "167*105*27 mm (6.58*4.13*1.06in)", "Eton/e5.jpg", "Et�n E5", "", 30, "346 gr (12.2 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 757, "168*105*28 mm (6.61*4.13*1.1in)", "Eton/g3globetraveler.jpg", "Et�n G3 Globe Traveler", "", 30, "345 gr (12.17 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 758, "125*76*29 mm (4.92*2.99*1.14in)", "Eton/g6aviator_buzzaldrin.jpg", "Et�n G6 Aviator Buzz Aldrin Edition", "", 30, "207 gr (7.3 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 751, "343*114*254 mm (13.5*4.5*10in)", "Elecraft/k4.jpg", "K4D", "100 W", 29, "4.54 Kg (10 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 759, "136*87*26 mm (5.35*3.42*1.02in)", "Eton/g8travelerii.jpg", "Et�n G8 Traveler II", "", 30, "201 gr (7.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 761, "340*85*295 mm (13.39*3.35*11.61in)", "FDK/fdk_multi2000.jpg", "Multi-2000 (Fukuyama Denki Kogyo)", @"FM: Hi 10 W, Lo: 1 W
SSB: 10 W (PEP)", 31, "7 Kg (15.43 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 762, "378*128*305 mm (14.9*5*12in)", "FDK/fdk_multi2700.jpg", "Multi-2700 (Fukuyama Denki Kogyo)", "Hi: 10 W (AM: 3 W)Lo: 1 W", 31, "14 Kg (30.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 763, "? mm", "FDK/fdk_multi3000.jpg", "Multi-3000 (Fukuyama Denki Kogyo)", "Hi: 10 W, Lo: 1 W", 31, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 764, "? mm", "FDK/multi400s.jpg", "Multi-400S (Fukuyama Denki Kogyo)", "? W", 31, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 765, "? mm", "FDK/fdk_multi700e.jpg", "Multi-700E (Fukuyama Denki Kogyo)", "? W", 31, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 766, "? mm", "FDK/fdk_multi700ex.jpg", "Multi-700EX (Fukuyama Denki Kogyo)", "1-25 W", 31, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 767, "? mm", "FDK/fdk_multi725x.jpg", "Multi-725X (Fukuyama Denki Kogyo)", "Hi: 25 W, Lo: 1 W", 31, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 760, "? mm", "FDK/multi11.jpg", "Multi-11 (Fukuyama Denki Kogyo)", "Hi: 10 W, Lo: ? W", 31, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 768, "163*73*260 mm (6.42*2.87*10.24in)", "FDK/multi750.jpg", "Multi-750 (Fukuyama Denki Kogyo)", "Hi: 10 W, Lo: 1 W", 31, "2.6 Kg (5.73 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 750, "343*114*254 mm (13.5*4.5*10in)", "Elecraft/k4.jpg", "K4", "100 W", 29, "4.54 Kg (10 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 748, "? mm", "Elecraft/k3.jpg", "K3/10", "0.1-10 / 0.1-10 W", 29, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 732, "? mm", "Efjohnson/ranger.jpg", "E.F.Johnson Ranger", "40 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 733, "? mm", "Efjohnson/viking_valiant.jpg", "E.F.Johnson Viking Valiant", "AM: 200 WSSB: 150 WCW: 150 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 734, "? mm", "Efjohnson/viking1.jpg", "E.F.Johnson Viking I", "100 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 735, "? mm", "Efjohnson/viking500.jpg", "E.F.Johnson Viking 500", "AM: 250 WSSB: 300 WCW: 300 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 736, "? mm", "Efjohnson/vikingii.jpg", "E.F.Johnson Viking II", "AM: 100 WCW: 130 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 737, "? mm", "Efjohnson/vikingmobile.jpg", "E.F.Johnson Viking Mobile", "30-60 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 738, "? mm", "Eico/720.jpg", "720", "60 W", 27, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 749, "? mm", "Elecraft/k3.jpg", "K3/100", "Max 100 / 100 W", 29, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 739, "216*152*229 mm (8.5*6*9in)", "Eico/723.jpg", "723", "~40 W (60 W input)", 27, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 741, "? mm", "Elad/fdmduo.jpg", "FDM-Duo", "Max 5 W", 28, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 742, "108*27*90 mm (4.25*1.06*3.54in)", "Elad/fdms1.jpg", "FDM-S1", "", 28, "180 gr (6.35 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 743, "? mm", "Elecraft/elecraft_k1.jpg", "K1", "QRP", 29, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 744, "198*74*208 mm (7.8*2.9*8.2in)", "Elecraft/elecraft_k2.jpg", "K2", "0.1-15 W", 29, "1.5 Kg (3.3 lb), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 745, "135*30*80 mm (5.32*1.18*3.15in)", "Elecraft/elecraft_kx1.jpg", "KX1", "1-4 W", 29, "250 gr (8.82 oz), without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 746, "188*88*41 mm (7.4*3.5*1.6in)", "Elecraft/elecraft_kx3.jpg", "KX3", "0-12 W (depending on voltage, band and setting)", 29, "680 gr (1.5 lbs) without options" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 747, "? mm", "Elecraft/elecraft_k2.jpg", "K2/100", "0.1-100 W", 29, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 740, "200*60*190 mm (7.87*2.36*7.48in)", "Elad/fdm77.jpg", "FDM-77", "", 28, "1 Kg (2.2 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 769, "? mm", "FDK/fdk_multi750e.jpg", "Multi-750E (Fukuyama Denki Kogyo)", "Hi: 10 W, Lo: 1 W", 31, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 770, "162*62*260 mm (6.38*2.44*10.24in)", "FDK/fdk_multi750xx.jpg", "Multi-750XX (Fukuyama Denki Kogyo)", "Hi: 20 W, Lo: 1 W", 31, "2.6 Kg (5.73 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 771, "179*75*247 mm (7.05*2.95*9.72in)", "FDK/multi8.jpg", "Multi-8 (Fukuyama Denki Kogyo)", @"HighMidLow
2 m:10 W3 W1 W", 31, "4 Kg (8.82 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 793, "? mm", "Geloso/g4225.jpg", "G4/225", "80 W", 34, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 794, "? mm", "Geloso/g4228.jpg", "G4/228", "150 W", 34, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 795, "? mm", "Gonset/2meter.jpg", "2-meter", "12 W", 35, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 796, "? mm", "Gonset/commander.jpg", "Commander", "AM: 35 WCW: 50 W (input)", 35, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 797, "? mm", "Gonset/communicator2meter.jpg", "Communicator 2 meter", "15 W (input)", 35, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 798, "? mm", "Gonset/communicatoriv220.jpg", "Communicator IV (220)", "10 W", 35, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 799, "? mm", "Gonset/g43.jpg", "G-43", "", 35, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 792, "? mm", "Geloso/g4223.jpg", "G4/223", "40 W", 34, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 800, "? mm", "Gonset/g66.jpg", "G-66", "", 35, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 802, "? mm", "Gonset/g77.jpg", "G-77", "60 W (input)", 35, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 803, "? mm", "Gonset/gsb100.jpg", "GSB-100", "AM: 50 W (input)FM: 75 W (input)SSB: 100 W (PEP input)CW: 100 W (input)", 35, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 804, "241*140*183 mm (9.5*5.5*7.2in)", "Gonset/sidewinder900a.jpg", "Sidewinder 900A", "SSB: 20 W (PEP input)AM: 6 W (input)", 35, "4.58 Kg (10.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 805, "? mm", "Gonset/sidewinder910a.jpg", "Sidewinder 910A", "SSB/CW: 20 WAM: 6 W", 35, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 806, "63*145*40 mm (2.48*5.71*1.58in)", "GRE/psr100.jpg", "/COM PSR-100", "", 36, "220 gr (7.76 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 807, "210*60*175 mm (8.27*2.36*6.89in)", "GRE/psr200.jpg", "PSR-200", "", 36, "690 gr (1.52 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 808, "210*52*175 mm (8.27*2.05*6.89in)", "GRE/psr214.jpg", "PSR-214", "", 36, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 801, "? mm", "Gonset/g76.jpg", "G-76", "~60 W (100 W input)", 35, "11 Kg (24.25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 791, "? mm", "Geloso/g4218.jpg", "G4/218", "", 34, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 790, "? mm", "Geloso/g4216.jpg", "G4/216", "", 34, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 789, "? mm", "Geloso/g4214.jpg", "G4/214", "", 34, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 772, "162*71*260 mm (6.38*2.8*10.24in)", "FDK/fdk_multi800d.jpg", "Multi-800D (Fukuyama Denki Kogyo)", "1-25 W", 31, "3 Kg (6.61 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 773, "? mm", "FDK/multi8dx.jpg", "Multi-8 DX (Fukuyama Denki Kogyo)", "Hi: 10 WMid: ? W, Lo: ? W", 31, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 774, "? mm", "FDK/fdk_multipalmiv_2.jpg", "Multi-Palm IV (Fukuyama Denki Kogyo)", "1 W", 31, "470 gr (16.58 oz), with batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 775, "330*71*300 mm (13*2.8*11.75in)", "Flexradio/flex6300.jpg", "Systems Flex-6300", "1-100 W (AM 1-25 W)", 32, "4.5 Kg (10 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 776, "350*171*337 mm (14*6.74*13.25in)", "Flexradio/flex6400.jpg", "Systems Flex-6400", "1-100 W (AM: 1-25 W)", 32, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 777, "350*171*337 mm (14*6.74*13.25in)", "Flexradio/flex6400m.jpg", "Systems Flex-6400M", "1-100 W (AM: 1-25 W)", 32, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 778, "330*102*305 mm (13*4*12in)", "Flexradio/flex6500.jpg", "Systems Flex-6500", "1-100 W (AM 1-25 W)", 32, "5.9 Kg (13 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 779, "350*171*337 mm (14*6.74*13.25in)", "Flexradio/flex6600.jpg", "Systems Flex-6600", "1-100 W (AM: 1-25 W)", 32, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 780, "350*171*337 mm (14*6.74*13.25in)", "Flexradio/flex6600m.jpg", "Systems Flex-6600M", "1-100 W (AM: 1-25 W)", 32, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 781, "330*102*305 mm (13*4*12in)", "Flexradio/flex6700.jpg", "Systems Flex-6700", "Max 100 W (AM max ? W)", 32, "5.9 Kg (13 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 782, "330*102*305 mm (13*4*12in)", "Flexradio/flex6700r.jpg", "Systems Flex-6700R", "", 32, "4.5 Kg (10 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 783, "286*152*318 mm (11.25*6*12.5in)", "Galaxy/gt550.jpg", "GT-550", @"SSB: ~250 W (550 W input)
CW: ~160 W (360 W input)", 33, "7.71 Kg (17 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 784, "432*152*356 mm (17*6*14in)", "Galaxy/r530.jpg", "R-530", "", 33, "11.3 Kg (25 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 785, "? mm", "Galaxy/vmarkii.jpg", "V Mark II", "SSB: ~150 W PEP (300 W PEP input)CW: ~150 W (300 W input)", 33, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 786, "514*254*260 mm (20.24*10*10.24in)", "Geloso/g207.jpg", "G-207", "", 34, "13 Kg (28.66 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 787, "? mm", "Geloso/g208.jpg", "G-208", "", 34, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 788, "? mm", "Geloso/g210tr.jpg", "G210TR", "40 W", 34, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 731, "? mm", "Efjohnson/navigator.jpg", "E.F.Johnson Navigator", "25 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 809, "63*150*45 mm (2.48*5.91*1.77in)", "GRE/psr216.jpg", "PSR-216", "", 36, "250 gr (8.82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 730, "? mm", "Efjohnson/messenger.jpg", "E.F.Johnson Messenger", "5 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 728, "? mm", "Efjohnson/invader.jpg", "E.F.Johnson Invader", "AM: 50 WCW: 100 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 671, "334*134*330 mm (13.15*5.28*12.99in)", "Drake/r8a.jpg", "R-8A", "", 24, "5.9 Kg (13.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 672, "334*134*330 mm (13.15*5.28*12.99in)", "Drake/r8b.jpg", "R-8B", "", 24, "5.9 Kg (13.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 673, "334*134*330 mm (13.15*5.28*12.99in)", "Drake/r8e.jpg", "R-8E", "", 24, "5.9 Kg (13.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 674, "482*178*279 mm (18.98*7.01*10.98in)", "Drake/rr1.jpg", "RR-1", "", 24, "6.4 Kg (14.11 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 675, "482*178*279 mm (18.98*7.01*10.98in)", "Drake/rr1b.jpg", "RR-1B", "", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 676, "482*178*279 mm (18.98*7.01*10.98in)", "Drake/rr2.jpg", "RR-2", "", 24, "6.35 Kg (14 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 677, "480*133*356 mm (19.9*5.24*14.02in)", "Drake/rr3.jpg", "RR-3", "", 24, "8.6 Kg (18.96 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 670, "? mm (?in)", "Drake/r8000.jpg", "R-8000", "", 24, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 678, "274*140*324 mm (10.79*5.51*12.76in)", "Drake/spr4.jpg", "SPR-4", "", 24, "8.2 Kg (18.08 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 680, "276*111*194 mm (10.87*4.37*7.64in)", "Drake/sw1.jpg", "SW-1", "", 24, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 681, "? mm", "Drake/sw2.jpg", "SW-2", "", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 682, "273*140*295 mm (10.75*5.5*11.62in)", "Drake/sw4.jpg", "SW-4", "", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 683, "292*133*330 mm (11.5*5.24*12.99in)", "Drake/sw8.jpg", "SW-8", "", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 684, "? mm", "Drake/t4.jpg", "T-4", "100 W", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 685, "273*140*295 mm (10.75*5.5*11.62in)", "Drake/t4b.jpg", "T-4B", @"AM: ~120 W (200 W PEP input)
SSB: ~120 W PEP (200 W PEP input)
CW: ~120 W (200 W DC input)", 24, "5.64 Kg (12.44 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 686, "? mm", "Drake/t4x.jpg", "T-4X", "100 W", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 679, "330*140*280 mm (13*5.5*11in)", "Drake/ssr1.jpg", "SSR-1", "", 24, "6.4 Kg (14 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 687, "273*140*295 mm (10.75*5.5*11.6in)", "Drake/t4xb.jpg", "T-4XB", "AM/SSB: 200 W (PEP input)CW: 200 W (input)", 24, "6.4 Kg (14.06 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 669, "334*134*330 mm (13.15*5.28*12.99in)", "Drake/r8.jpg", "R-8", "", 24, "5.9 Kg (13.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 667, "346*117*318 mm (13.62*4.61*12.52in)", "Drake/r77.jpg", "R-77", "", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 651, "140*40*154 mm (5.51*1.58*6.06in)", "Dragon/dragon_sy130.jpg", "SY-130E", "Hi: 50 W, Lo: 10 W", 23, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 652, "282*74*209 mm (11.1*2.91*8.23in)", "Dragon/dragon_sy495v.jpg", "SY-495V", "Hi: ? W, Lo: ? W", 23, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 653, "? mm", "Dragon/dragon_sy501.jpg", "SY-501", "Hi: 5 W, Lo: 350 mW", 23, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 654, "140*40*125 mm (5.51*1.58*4.92in)", "Dragon/dragon_sy550.jpg", "SY-550", "Hi: 25 W, Lo: ? W", 23, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 655, "171*279*381 mm (6.73*11*15in)", "Drake/1a.jpg", "1-A", "", 24, "8.2 Kg (18.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 656, "304*177*228 mm (11.97*6.97*8.98in)", "Drake/2a.jpg", "2-A", "", 24, "6.6 Kg (14.55 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 657, "? mm", "Drake/2b.jpg", "2-B", "", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 668, "346*115*330 mm (13.6*4.6*13in)", "Drake/r7a.jpg", "R7A", "", 24, "8.34 Kg (18.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 658, "289*162*239 mm (11.38*6.38*9.41in)", "Drake/2c.jpg", "2-C", "", 24, "6.1 Kg (13.45 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 660, "340*140*380 mm (13.39*5.51*14.96in)", "Drake/msr1.jpg", "MSR-1", "", 24, "7.7 Kg (16.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 661, "495*170*380 mm (19.49*6.69*14.96in)", "Drake/msr2.jpg", "MSR-2", "", 24, "15.4 Kg (33.95 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 662, "273*140*297 mm (10.75*5.51*11.69in)", "Drake/r4.jpg", "R-4", "", 24, "7.3 Kg (16.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 663, "? mm", "Drake/r4a.jpg", "R-4A", "", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 664, "273*140*297 mm (10.75*5.5*11.7in)", "Drake/r4b.jpg", "R-4B", "", 24, "7.26 Kg (16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 665, "273*140*311 mm (10.75*5.5*12.25in)", "Drake/r4c.jpg", "R-4C", "", 24, "7.71 Kg (17 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 666, "346*115*330 mm (13.6*4.6*13in)", "Drake/r7.jpg", "R7", "", 24, "8.34 Kg (18.4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 659, "? mm", "Drake/2nt.jpg", "2-NT", "40-60 W", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 688, "260*140*295 mm (10.25*5.5*11.6in)", "Drake/t4xc.jpg", "T-4XC", "110-140 W (200 W PEP input)", 24, "6.62 Kg (14.6 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 689, "135*58*181 mm (5.32*2.28*7.13in)", "Drake/tr22.jpg", "TR-22", "1 W", 24, "1.7 Kg (3.75 lbs), with batteries and mic" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 690, "? mm", "Drake/tr270.jpg", "TR-270", "Lo: 1 WMid: 10 WHi: 25 W", 24, "5.9 Kg (13.01 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 712, "? mm (?in)", "Eddystone/840a.jpg", "840A", "", 25, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 713, "? mm (?in)", "Eddystone/840c.jpg", "840C", "", 25, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 714, "? mm", "Eddystone/850-2.jpg", "850/2", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 715, "483*222*400 mm (19.02*8.74*15.75in)", "Eddystone/880-2.jpg", "880/2", "", 25, "40 Kg (88.18 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 716, "430*220*250 mm (15.93*8.66*9.84in)", "Eddystone/909a.jpg", "909A", "", 25, "14 Kg (30.86 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 717, "? mm", "Eddystone/940.jpg", "940", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 718, "426*154*298 mm (16.77*6.06*11.73in), bench version483*154*342 mm (19.02*6.06*13.46in), rack version", "Eddystone/990r.jpg", "990R", "", 25, "8.8 Kg (19.4 lbs), bench version9 Kg (19.84 lbs), rack version" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 711, "? mm (?in)", "Eddystone/840.jpg", "840", "", 25, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 719, "? mm", "Eddystone/990s.jpg", "990S", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 721, "318*159*180 mm (12.52*6.26*7.09in)", "Eddystone/ec10a2.jpg", "EC10A/2", "", 25, "6.7 Kg (14.77 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 722, "? mm", "Eddystone/ec10mkii.jpg", "EC10 MkII", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 723, "? mm", "Eddystone/ec958.jpg", "EC958", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 724, "? mm", "Efjohnson/500.jpg", "E.F.Johnson 500 \"Five hundred\"", "AM: 250 WSSB: 250 WCW: 300 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 725, "? mm", "Efjohnson/6n2.jpg", "E.F.Johnson 6N2", "AM: 50 WCW: 80 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 726, "? mm", "Efjohnson/adventurer.jpg", "E.F.Johnson Adventurer", "30 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 727, "? mm", "Efjohnson/challenger.jpg", "E.F.Johnson Challenger", "AM: 40 WCW: 70 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 720, "? mm", "Eddystone/ec10.jpg", "EC10", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 710, "425*222*381 mm (16.75*8.75*15in)", "Eddystone/830-7.jpg", "830/7", "", 25, "22.2 Kg (49 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 709, "425*222*381 mm (16.75*8.75*15in)", "Eddystone/830-5.jpg", "830/5", "", 25, "22.2 Kg (49 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 708, "425*222*381 mm (16.75*8.75*15in)", "Eddystone/830-2.jpg", "830/2", "", 25, "22.2 Kg (49 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 691, "273*140*366 mm (10.75*5.5*14.4in)", "Drake/tr3.jpg", "TR-3", @"AM: 50 W
SSB: ~150 W PEP (300 W PEP input)
CW: ~130 W DC (260 W DC input)", 24, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 692, "138*58*216 mm (5.43*2.28*8.5in)", "Drake/tr33c.jpg", "TR-33C", "1.5 W", 24, "2 Kg (4.41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 693, "? mm", "Drake/tr44.jpg", "TR-44", "100 W", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 694, "273*292*311 mm (10.75*11.5*12.25in)", "Drake/tr44b.jpg", "TR-44B", @"AM: ~120 W (200 W PEP input)
SSB: ~120 W PEP (200 W PEP input)
CW: ~120 W (200 W DC input)", 24, "13.61 Kg (30 lbs), without PSU" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 695, "272*140*360 mm (10.71*5.51*14.17in)", "Drake/tr4c.jpg", "TR-4C", "Max 100 W", 24, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 696, "273*140*365 mm (10.75*5.51*14.37in)", "Drake/tr4cw.jpg", "TR-4CW", "150 W", 24, "7.3 Kg (16.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 697, "? mm", "Drake/tr5.jpg", "TR-5", "80 W", 24, "6.5 Kg (14.33 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 698, "? mm", "Drake/tr6.jpg", "TR-6", "100 W", 24, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 699, "346*116*317 mm (13.62*4.57*12.48in)", "Drake/tr7.jpg", "TR-7", "120 W", 24, "7.7 Kg (16.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 700, "180*60*240 mm (7.09*2.36*9.45in)", "Drake/tr72.jpg", "TR-72", "Hi: 10 W, Lo: 1 W", 24, "2.5 Kg (5.51 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 701, "346*117*318 mm (13.62*4.61*12.52in)", "Drake/tr77.jpg", "TR-77", "150 W (PEP)", 24, "6.35 Kg (14 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 702, "203*102*381 mm (7.99*4.02*15in)", "Drake/uv3.jpg", "UV-3", "Hi: 35/15/10 W, Lo: 3.5/2/1 W", 24, "5 Kg (11.02 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 703, "210*90*300 mm (8.27*3.54*11.82in)", "Drake/uv3e.jpg", "UV-3E", "Hi: 35/10 W, Lo: 3.5/1 W", 24, "5 Kg (11.02 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 704, "? mm", "Eddystone/1830-1.jpg", "1830/1", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 705, "? mm", "Eddystone/670a.jpg", "670A", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 706, "426*222*381 mm (16.77*8.74*15in)", "Eddystone/680x.jpg", "680X", "", 25, "21.3 Kg (46.96 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 707, "? mm", "Eddystone/730-4.jpg", "730/4", "", 25, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 729, "? mm", "Efjohnson/invader2000.jpg", "E.F.Johnson Invader 2000", "AM: 500 WSSB: 1 KWCW: 600 W", 26, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 810, "210*52*175 mm (8.27*2.05*6.89in)", "GRE/psr220.jpg", "PSR-220", "", 36, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 811, "232*90*210 mm (9.13*3.54*8.27in)", "GRE/psr225.jpg", "PSR-225", "", 36, "2 Kg (4.41 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 812, "58*145*42 mm (2.28*5.71*1.65in)", "GRE/psr244.jpg", "PSR-244", "", 36, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 915, "? mm", "Hallicrafters/sr400acycloneiii.jpg", "SR-400A \"Cyclone III\"", "SSB: 550 W (PEP input)CW: 175 W (input)", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 916, "? mm", "Hallicrafters/sr400cyclone.jpg", "SR-400 \"Cyclone\"", "SSB: 400 W (PEP input)CW: 125 W (input)", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 917, "? mm", "Hallicrafters/sr500tornado.jpg", "SR-500 \"Tornado\"", "SSB: 500 W (PEP input)CW: 300 W (input)", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 918, "? mm", "Hallicrafters/sr540.jpg", "SR-540", "SSB: ? W (PEP input), CW: ? W (input)", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 919, "324*178*197 mm (12.75*7*7.75in)", "Hallicrafters/sr75.jpg", "SR-75", "10 W", 38, "7.26 Kg (16 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 920, "470*226*279 mm (18.5*8.9*11in)", "Hallicrafters/sx100.jpg", "SX-100", "", 38, "15.6 Kg (34.39 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 921, "? mm (?in)", "Hallicrafters/sx101.jpg", "SX-101", "", 38, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 914, "? mm", "Hallicrafters/sr34ac.jpg", "SR-34AC", "8 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 922, "508*267*406 mm (20*10.5*16in)", "Hallicrafters/sx101a.jpg", "SX-101A", "", 38, "31.8 Kg (70 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 924, "? mm (?in)", "Hallicrafters/sx11.jpg", "SX-11 \"Super Skyrider\"", "", 38, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 925, "476*216*259 mm (18.74*8.5*10.2in)", "Hallicrafters/sx110.jpg", "SX-110", "", 38, "13 Kg (28.66 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 926, "478*226*259 mm (18.8*8.9*10.2in)", "Hallicrafters/sx111.jpg", "SX-111", "", 38, "16.22 Kg (35.75 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 927, "? mm", "Hallicrafters/sx112.jpg", "SX-112", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 928, "406*267*406 mm (15.98*10.51in)", "Hallicrafters/sx115.jpg", "SX-115", "", 38, "20 Kg (44.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 929, "281*197*375 mm (11.06*7.76*14.76in)", "Hallicrafters/sx117.jpg", "SX-117", "", 38, "8.4 Kg (18.52 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 930, "476*203*248 mm (18.74*7.99*9.76in)", "Hallicrafters/sx122.jpg", "SX-122", "", 38, "13.2 Kg (29.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 923, "? mm (?in)", "Hallicrafters/sx101mkii.jpg", "SX-101 Mk II", "", 38, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 931, "476*203*248 mm (18.74*7.99*9.76in)", "Hallicrafters/sx122a.jpg", "SX-122A", "", 38, "13.2 Kg (29.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 913, "? mm", "Hallicrafters/sr34.jpg", "SR-34", "8 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 911, "? mm", "Hallicrafters/sr160.jpg", "SR-160", "SSB: 150 W (PEP input)CW: 125 W (input)", 38, "7.94 Kg (17.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 895, "470*241*216 mm (18.5*9.5*8.5in)", "Hallicrafters/s52.jpg", "S-52", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 896, "? mm", "Hallicrafters/s53.jpg", "S-53", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 897, "325*178*197 mm (12.8*7*7.76in)", "Hallicrafters/s53a.jpg", "S-53A", "", 38, "8.2 Kg (18.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 898, "? mm", "Hallicrafters/s7.jpg", "S-7 \"Super Skyrider\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 899, "? mm", "Hallicrafters/s72.jpg", "S-72", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 900, "? mm", "Hallicrafters/s72.jpg", "S-72L", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 901, "470*229*241 mm (18.5*9.02*9.49in)", "Hallicrafters/s76.jpg", "S-76", "", 38, "18.6 Kg (41 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 912, "? mm", "Hallicrafters/sr2000hurricane.jpg", "SR-2000 \"Hurricane\"", "SSB: 2 KW (PEP input)CW: 900 W (input)", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 902, "470*231*249 mm (18.5*9.1*9.8in)", "Hallicrafters/s77.jpg", "S-77", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 904, "330*178*184 mm (13*7*7.25in)", "Hallicrafters/s81.jpg", "S-81", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 905, "330*178*184 mm (13*7*7.25in)", "Hallicrafters/s82.jpg", "S-82", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 906, "470*230*270 mm (18.5*9.06*10.63in)", "Hallicrafters/s85.jpg", "S-85", "", 38, "12 Kg (26.46 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 907, "470*230*270 mm (18.5*9.06*10.63in)", "Hallicrafters/s85.jpg", "S-85U", "", 38, "12 Kg (26.46 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 908, "? mm", "Hallicrafters/s9.jpg", "S-9 \"Super Skyrider\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 909, "? mm", "Hallicrafters/s95.jpg", "S-95 \"Civic patrol\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 910, "381*165*330 mm (15*6.5*13in)", "Hallicrafters/sr150.jpg", "SR-150", "SSB: 150 W (PEP input)CW: 125 W (input)", 38, "7.94 Kg (17.5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 903, "470*231*249 mm (18.5*9.1*9.8in)", "Hallicrafters/s77a.jpg", "S-77A", "", 38, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 932, "479*203*248 mm (18.86*7.99*9.76in)", "Hallicrafters/sx130.jpg", "SX-130", "", 38, "11.3 Kg (24.91 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 933, "464*203*248 mm (18.27*7.99*9.76in)", "Hallicrafters/sx133.jpg", "SX-133", "", 38, "14.1 Kg (31.09 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 934, "? mm", "Hallicrafters/sx140.jpg", "SX-140", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 956, "? mm", "Hammarlund/hq110c.jpg", "HQ-110C", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 957, "511*279*343 mm (20.12*11*13.5in)", "Hammarlund/hq120x.jpg", "HQ-120X", "", 39, "21.3 Kg (47 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 958, "511*279*343 mm (20.1*11*13.5in)", "Hammarlund/hq129x.jpg", "HQ-129X", "", 39, "21.3 Kg (47 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 959, "511*279*343 mm (20.12*10.98*13.5in)", "Hammarlund/hq140x.jpg", "HQ-140X", "", 39, "21.3 Kg (46.96 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 960, "482*266*330 mm (19.98*10.47*13in)", "Hammarlund/hq145.jpg", "HQ-145", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 961, "511*279*343 mm (20.12*10.98*13.5in)", "Hammarlund/hq150.jpg", "HQ-150", "", 39, "31.7 Kg (69.9 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 962, "482*266*330 mm (18.98*10.47*13in)", "Hammarlund/hq160.jpg", "HQ-160", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 955, "? mm", "Hammarlund/hq105tre.jpg", "HQ-105TRE", "5 W", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 963, "483*267*330 mm (19*10.5*13in)", "Hammarlund/hq170.jpg", "HQ-170", "", 39, "17.2 Kg (38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 965, "483*267*330 mm (19*10.5*13in)", "Hammarlund/hq170c.jpg", "HQ-170C", "", 39, "17.2 Kg (38 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 966, "? mm", "Hammarlund/hq180a.jpg", "HQ-180A", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 967, "? mm", "Hammarlund/hq180c.jpg", "HQ-180C", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 968, "? mm", "Hammarlund/hq180x.jpg", "HQ-180X", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 969, "? mm", "Hammarlund/hq200.jpg", "HQ-200", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 970, "? mm", "Hammarlund/hq205.jpg", "HQ-205", "5 W", 39, "12.7 Kg (28 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 971, "406*178*356 mm (16*7*14in)", "Hammarlund/hq215.jpg", "HQ-215", "", 39, "9.52 Kg (21 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 964, "? mm", "Hammarlund/hq170ac.jpg", "HQ-170AC", "", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 954, "413*241*233 mm (16.26*9.49*9.17in)", "Hammarlund/hq100c.jpg", "HQ-100C", "", 39, "13.6 Kg (29.98 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 953, "? mm", "Hammarlund/four20.jpg", "Four-20", "20 W", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 952, "527*241*349 mm (20.75*9.5*13.75in)", "Hammarlund/cometpro.jpg", "Comet Pro", "", 39, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 935, "333*149*279 mm (13.11*5.87*10.98in)", "Hallicrafters/sx146.jpg", "SX-146", "", 38, "8.2 Kg (18.08 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 936, "432*305*305 mm (17*12*12in)", "Hallicrafters/sx17.jpg", "SX-17 \"Super Skyrider\"", "", 38, "18.14 Kg (40 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 937, "? mm", "Hallicrafters/sx24.jpg", "SX-24 \"Skyrider Defiant\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 938, "495*241*283 mm (19.49*9.49*11.14in)", "Hallicrafters/sx25.jpg", "SX-25 \"Super Defiant\"", "", 38, "21 Kg (46.3 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 939, "521*254*375 mm (20.51*10*14.76in)", "Hallicrafters/sx28.jpg", "SX-28 \"Super Skyrider\"", "", 38, "34 Kg (74.96 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 940, "521*254*375 mm (20.51*10*14.76in)", "Hallicrafters/sx28a.jpg", "SX-28A \"Super Skyrider\"", "", 38, "34 Kg (74.96 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 941, "508*260*203 mm (20*10.2*8in)", "Hallicrafters/sx42.jpg", "SX-42", "", 38, "23.6 Kg (52 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 942, "? mm", "Hallicrafters/sx43.jpg", "SX-43", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 943, "? mm", "Hallicrafters/sx62.jpg", "SX-62", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 944, "330*130*280 mm (13*5.12*11in)", "Hallicrafters/sx71.jpg", "SX-71", "", 38, "15 Kg (33.07 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 945, "? mm", "Hallicrafters/sx73.jpg", "SX-73", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 946, "? mm", "Hallicrafters/sx85.jpg", "SX-85", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 947, "508*235*444 mm (20*9.25*17.48in)", "Hallicrafters/sx88.jpg", "SX-88", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 948, "? mm", "Hallicrafters/sx96.jpg", "SX-96", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 949, "476*229*273 mm (18.74*9.02*10.75in)", "Hallicrafters/sx99.jpg", "SX-99", "", 38, "13 Kg (28.66 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 950, "? mm", "Hallicrafters/wr4000.jpg", "WR-4000", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 951, "? mm (?in)", "Hammarlund/comet.jpg", "- Comet", "", 39, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 894, "? mm", "Hallicrafters/s51.jpg", "- S-51", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 893, "? mm", "Hallicrafters/s47.jpg", "- S-47", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 892, "? mm", "Hallicrafters/s41w.jpg", "S-41W \"Skyrider Jr.\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 891, "? mm (?in)", "Hallicrafters/s40b.jpg", "S-40B", "", 38, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 834, "530*290*120 mm (20.87*11.42*4.72in)", "Grundig/satellit2400sl.jpg", "Satellit 2400SL", "", 37, "7.4 Kg (16.31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 835, "304*180*70 mm (11.97*7.09*2.76in)", "Grundig/satellit300.jpg", "Satellit 300", "", 37, "2.15 Kg (4.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 836, "500*290*120 mm (19.69*11.42*4.72in)", "Grundig/satellit3000.jpg", "Satellit 3000", "", 37, "8.9 Kg (19.62 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 837, "520*320*140 mm (20.47*12.6*5.51in)", "Grundig/satellit3400.jpg", "Satellit 3400", "", 37, "8.9 Kg (19.62 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 838, "300*178*51 mm (11.8*7*2in)", "Grundig/satellit400.jpg", "Satellit 400", "", 37, "2.27 Kg (5 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 839, "568*268*120 mm (22.36*10.55*4.72in)", "Grundig/satellit4000recorder.jpg", "Satellit 4000 Recorder", "", 37, "7 Kg (15.43 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 840, "503*241*203 mm (19.8*9.5*8in)", "Grundig/satellit500.jpg", "Satellit 500", "", 37, "8.62 Kg (19 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 833, "440*260*130 mm (17.32*10.24*5.12in)", "Grundig/satellit210.jpg", "Satellit 210 Amateur", "", 37, "6.1 Kg (13.45 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 841, "500*240*200 mm (19.69*9.45*7.87in)", "Grundig/satellit600.jpg", "Satellit 600", "", 37, "8.5 Kg (18.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 843, "305*175*65 mm (12.25*7.25*3in)", "Grundig/satellit700.jpg", "Satellit 700", "", 37, "1.8 Kg (4 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 844, "372*184*146 mm (14.65*7.24*5.75in)", "Grundig/satellit750.jpg", "Satellit 750", "", 37, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 845, "540*240*220 mm (21.26*9.45*8.66in)", "Grundig/satellit800_side.jpg", "Satellit 800", "", 37, "6.6 Kg (14.55 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 846, "? mm", "Grundig/satellit900prototype.jpg", "Satellit 900", "", 37, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 847, "150*85*34 mm (5.91*3.35*1.34in)", "Grundig/yachtboy10.jpg", "Yacht Boy 10 (WR5401)", "", 37, "250 gr (8,82 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 848, "142*92*35 mm (5.59*3.62*1.38in)", "Grundig/yachtboy2000.jpg", "Yacht Boy 2000", "", 37, "330 gr (11.64 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 849, "128*87*33 mm (5.04*3.42*1.3in)", "Grundig/yachtboy50.jpg", "Yacht Boy 50 (WR5405)", "", 37, "270 gr (9.52 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 842, "500*240*200 mm (19.69*9.45*7.87in)", "Grundig/satellit650.jpg", "Satellit 650", "", 37, "8.5 Kg (18.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 832, "460*270*120 mm (18.11*10.63*4.72in)", "Grundig/satellit2100.jpg", "Satellit 2100", "", 37, "6.3 Kg (13.89 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 831, "440*260*130 mm (17.32*10.24*5.12in)", "Grundig/satellit210.jpg", "Satellit 210", "", 37, "6.1 Kg (13.45 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 830, "440*260*120 mm (17.32*10.24*4.72in)", "Grundig/satellit208.jpg", "Satellit 208", "", 37, "6.1 Kg (13.45 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 813, "60*160*40 mm (2.36*6.3*1.58in)", "GRE/psr255.jpg", "PSR-255", "", 36, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 814, "59*171*40 mm (2.32*6.73*1.58in)", "GRE/psr275.jpg", "PSR-275", "", 36, "240 gr (8.46 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 815, "63*145*40 mm (2.48*5.71*1.58in)", "GRE/psr282.jpg", "PSR-282", "", 36, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 816, "? mm", "GRE/psr295.jpg", "PSR-295", "", 36, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 817, "? mm", "GRE/psr300.jpg", "PSR-300", "", 36, "? gr" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 818, "185*55*135 mm (7.28*2.16*5.32in)", "GRE/psr400.jpg", "PSR-400", "", 36, "790 gr (1.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 819, "? mm", "GRE/psr500.jpg", "PSR-500", "", 36, "240 gr (8.46 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 820, "185*55*135 mm (7.28*2.16*5.32in)", "GRE/psr600.jpg", "PSR-600", "", 36, "790 gr (1.74 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 821, "290*180*80 mm (11.42*7.09*3.15in)", "Grundig/musicboy1100.jpg", "Music Boy 1100", "", 37, "1.8 Kg (3.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 822, "460*260*130 mm (18.11*10.24*5.12in)", "Grundig/satellit1000.jpg", "Satellit 1000", "", 37, "6.45 Kg (14.22 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 823, "412*267*120 mm (16.22*10.51*4.72in)", "Grundig/1400.jpg", "Satellit 1400 Professional", "", 37, "5.5 Kg (12.13 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 824, "412*267*120 mm (16.22*10.51*4.72in)", "Grundig/1400sl.jpg", "Satellit 1400 SL Professional", "", 37, "5.5 Kg (12.13 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 825, "460*270*120 mm (18.11*10.63*4.72in)", "Grundig/satellit2000.jpg", "Satellit 2000", "", 37, "6.3 Kg (13.89 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 826, "410*250*120 mm (16.14*9.84*4.72in)", "Grundig/satellit205.jpg", "Satellit 205", "", 37, "7 Kg (15.43 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 827, "410*250*120 mm (16.14*9.84*4.72in)", "Grundig/satellit205.jpg", "Satellit 205A", "", 37, "7 Kg (15.43 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 828, "410*250*120 mm (16.14*9.84*4.72in)", "Grundig/satellit205.jpg", "Satellit 205A Amateur", "", 37, "7 Kg (15.43 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 829, "410*250*120 mm (16.14*9.84*4.72in)", "Grundig/satellit205.jpg", "Satellit 205 Amateur", "", 37, "7 Kg (15.43 lbs), without batteries" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 850, "184*120*40 mm (7.24*4.72*1.58in)", "Grundig/yachtboy80.jpg", "Yacht Boy 80 (WR5408 PLL)", "", 37, "510 gr (18 oz)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 973, "? mm", "Hammarlund/hx500.jpg", "HX-500", "SSB: ~60 W (100 W input)", 39, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 851, "? mm", "Hallicrafters/fpm200.jpg", "FPM-200", "100 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 853, "? mm", "Hallicrafters/h2m1000.jpg", "H2M-1000", "Hi: 12 W, Lo: 1 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 875, "470*216*235 mm (18.5*8.5*9.25in)", "Hallicrafters/s22.jpg", "S-22 \"Skyrider Marine\"", "", 38, "14.06 Kg (31 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 876, "470*216*238 mm (18.5*8.5*9.37in)", "Hallicrafters/s22r.jpg", "S-22R \"Skyrider Marine\"", "", 38, "14.1 Kg (31.1 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 877, "483*230*256 mm (19.02*9.06*10.08in)", "Hallicrafters/s27.jpg", "S-27", "", 38, "20 Kg (44.1 lbs), except cabinet" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 878, "? mm (?in)", "Hallicrafters/s29.jpg", "S-29 \"Sky Traveler\"", "", 38, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 879, "? mm", "Hallicrafters/s36a.jpg", "S-36A", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 880, "489*241*375 mm (19.25*9.5*14.75in)", "Hallicrafters/s37.jpg", "S-37", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 881, "327*178*184 mm (12.87*7.09*7.24in)", "Hallicrafters/s38.jpg", "S-38", "", 38, "5 Kg (11.02 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 874, "470*235*216 mm (18.5*9.25*8.5in)", "Hallicrafters/s21.jpg", "S-21 \"Skyrider 5-10\"", "", 38, "15.42 Kg (34 lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 882, "327*178*184 mm (12.87*7.09*7.24in)", "Hallicrafters/s38a.jpg", "S-38A", "", 38, "5 Kg (11.02 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 884, "? mm", "Hallicrafters/s38c.jpg", "S-38C", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 885, "? mm", "Hallicrafters/s38d.jpg", "S-38D", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 886, "? mm", "Hallicrafters/s38e.jpg", "S-38E", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 887, "? mm", "Hallicrafters/s39.jpg", "S-39 \"Sky Ranger\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 888, "? mm", "Hallicrafters/s4.jpg", "S-4 \"Super Skyrider\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 889, "470*229*280 mm (18.5*9.02*11.02in)", "Hallicrafters/s40.jpg", "S-40", "", 38, "12.7 Kg (28 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 890, "470*229*280 mm (18.5*9.02*11.02in)", "Hallicrafters/s40a.jpg", "S-40A", "", 38, "12.7 Kg (28 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 883, "330*190*184 mm (13*7.5*7.25in", "Hallicrafters/s38b.jpg", "S-38B", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 873, "470*216*238 mm (18.5*8.5*9.37in)", "Hallicrafters/s20r.jpg", "S-20R \"Sky Champion\"", "", 38, "14.5 Kg (31.97 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 872, "? mm (?in)", "Hallicrafters/s20.jpg", "S-20 \"Sky Champion\"", "", 38, "? Kg (? lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 871, "? mm", "Hallicrafters/s19r.jpg", "S-19R \"Sky Buddy\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 854, "? mm", "Hallicrafters/ht17.jpg", "HT-17", "10-20 m: 10 W, 40-80 m: 15 W,", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 855, "? mm", "Hallicrafters/ht18.jpg", "HT-18", "? W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 856, "508*457*260 mm (20*18*10.25in)", "Hallicrafters/ht19.jpg", "HT-19", "125 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 857, "508*311*438 mm (20*12.25*17.25in)", "Hallicrafters/ht20.jpg", "HT-20", "AM: 100 W, CW: 115 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 858, "508*260*432 mm (20*10.25*17in)", "Hallicrafters/ht32a.jpg", "HT-32A", "AM: ? WSSB: 150 W (PEP)CW: ? W", 38, "39 Kg (86 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 859, "? mm", "Hallicrafters/ht37.jpg", "HT-37", "? W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 860, "? mm", "Hallicrafters/ht40.jpg", "HT-40", "AM 30 W, CW 35 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 861, "? mm", "Hallicrafters/ht44.jpg", "HT-44", "100 W (AM 35 W)", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 862, "? mm", "Hallicrafters/ht4g.jpg", "HT-4G", "AM: 300, CW: 450 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 863, "? mm", "Hallicrafters/ht9.jpg", "HT-9", "100 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 864, "432*190*190 mm (17*7.5*7.5in)", "Hallicrafters/s1.jpg", "S-1 \"Skyrider\"", "", 38, "? Kg (? lb)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 865, "? mm", "Hallicrafters/s10.jpg", "S-10 \"Ultra Skyrider\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 866, "476*216*259 mm (18.74*8.5*10.2in)", "Hallicrafters/s108.jpg", "S-108", "", 38, "12.8 Kg (28.22 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 867, "267*127*191 mm (10.51*5*7.52in)", "Hallicrafters/s119.jpg", "S-119 \"Sky Buddy II\"", "", 38, "3.6 Kg (7.94 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 868, "343*149*222 mm (13.5*5.87*8.74in)", "Hallicrafters/s120.jpg", "S-120", "", 38, "4.6 Kg (10.14 lbs)" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 869, "? mm", "Hallicrafters/s14.jpg", "S-14 \"Skychief\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 870, "? mm", "Hallicrafters/s16.jpg", "S-16 \"Super Skyrider\"", "", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 852, "? mm", "Hallicrafters/fpm300.jpg", "FPM-300", "100 W", 38, "? Kg" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "Dimensions", "Image", "Name", "PowerWatts", "VendorId", "WeightGrams" },
                values: new object[] { 2596, "59*147*38 mm (2.32*5.79*1.5in)", "Yupiteru/vt225.jpg", "VT-225", "", 78, "280 g (9.88 oz)" });

            migrationBuilder.CreateIndex(
                name: "IX_Rigs_VendorId",
                table: "Rigs",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rigs");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
