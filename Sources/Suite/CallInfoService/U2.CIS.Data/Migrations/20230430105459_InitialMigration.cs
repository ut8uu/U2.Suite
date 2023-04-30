using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U2.CIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Call = table.Column<string>(type: "TEXT", nullable: true),
                    Aliases = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    YearOfBirth = table.Column<int>(type: "INTEGER", nullable: true),
                    EMail = table.Column<string>(type: "TEXT", nullable: true),
                    AddressLine1 = table.Column<string>(type: "TEXT", nullable: true),
                    AddressLine2 = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    DxccCountry = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    ZIP = table.Column<string>(type: "TEXT", nullable: true),
                    GridLocator = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<decimal>(type: "TEXT", nullable: true),
                    Longitude = table.Column<decimal>(type: "TEXT", nullable: true),
                    CqZone = table.Column<int>(type: "INTEGER", nullable: true),
                    ItuZone = table.Column<int>(type: "INTEGER", nullable: true),
                    QslManager = table.Column<string>(type: "TEXT", nullable: true),
                    AcceptsEqsl = table.Column<bool>(type: "INTEGER", nullable: true),
                    AcceptsLotw = table.Column<bool>(type: "INTEGER", nullable: true),
                    UsesPaperQsl = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
