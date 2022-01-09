using Microsoft.EntityFrameworkCore.Migrations;

namespace U2.Library.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rigs_Vendors_VendorId",
                table: "Rigs");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Rigs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Depth",
                table: "Rigs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Rigs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufactureEnd",
                table: "Rigs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufactureStart",
                table: "Rigs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Rigs",
                nullable: false,
                defaultValue: 0);

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
                values: new object[] { 4, "Yaesu" });

            migrationBuilder.AddForeignKey(
                name: "FK_Rigs_Vendors_VendorId",
                table: "Rigs",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rigs_Vendors_VendorId",
                table: "Rigs");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Depth",
                table: "Rigs");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Rigs");

            migrationBuilder.DropColumn(
                name: "ManufactureEnd",
                table: "Rigs");

            migrationBuilder.DropColumn(
                name: "ManufactureStart",
                table: "Rigs");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Rigs");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Rigs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rigs_Vendors_VendorId",
                table: "Rigs",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
