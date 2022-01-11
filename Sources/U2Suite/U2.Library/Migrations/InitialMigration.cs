using Microsoft.EntityFrameworkCore.Migrations;

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
                    ManufactureStart = table.Column<int>(nullable: true),
                    ManufactureEnd = table.Column<int>(nullable: true),
                    Width = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Depth = table.Column<int>(nullable: true),
                    WeightGrams = table.Column<int>(nullable: true),
                    PowerWatts = table.Column<int>(nullable: true),
                    DataDirectory = table.Column<string>(maxLength: 150, nullable: false)
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
                values: new object[] { 1, "Alinco" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Icom" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Kenwood" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Motorola" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "TenTec" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Wouxun" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Yaesu" });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "DataDirectory", "Depth", "Height", "ManufactureEnd", "ManufactureStart", "Name", "PowerWatts", "VendorId", "WeightGrams", "Width" },
                values: new object[] { 1, "Alinco/DJX01", 19, 100, null, 2004, "DJ-X1", null, 1, 150, 58 });

            migrationBuilder.InsertData(
                table: "Rigs",
                columns: new[] { "Id", "DataDirectory", "Depth", "Height", "ManufactureEnd", "ManufactureStart", "Name", "PowerWatts", "VendorId", "WeightGrams", "Width" },
                values: new object[] { 2, "Wouxun/KGUV6D", 40, 119, null, null, "KG UV-6D", 5, 6, 253, 65 });

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
