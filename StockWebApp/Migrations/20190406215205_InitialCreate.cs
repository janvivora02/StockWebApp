using Microsoft.EntityFrameworkCore.Migrations;

namespace StockWebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    isEnabled = table.Column<bool>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    iexId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "Gainers",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    primaryExchange = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    calculationPrice = table.Column<string>(nullable: true),
                    open = table.Column<float>(nullable: false),
                    openTime = table.Column<long>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    closeTime = table.Column<long>(nullable: false),
                    high = table.Column<float>(nullable: false),
                    low = table.Column<float>(nullable: false),
                    latestPrice = table.Column<float>(nullable: false),
                    latestSource = table.Column<string>(nullable: true),
                    latestTime = table.Column<string>(nullable: true),
                    latestUpdate = table.Column<long>(nullable: false),
                    latestVolume = table.Column<int>(nullable: false),
                    iexRealtimePrice = table.Column<float>(nullable: false),
                    iexRealtimeSize = table.Column<int>(nullable: false),
                    iexLastUpdated = table.Column<int>(nullable: false),
                    delayedPrice = table.Column<float>(nullable: false),
                    delayedPriceTime = table.Column<long>(nullable: false),
                    extendedPrice = table.Column<float>(nullable: false),
                    extendedChange = table.Column<float>(nullable: false),
                    extendedChangePercent = table.Column<float>(nullable: false),
                    extendedPriceTime = table.Column<long>(nullable: false),
                    previousClose = table.Column<float>(nullable: false),
                    change = table.Column<float>(nullable: false),
                    changePercent = table.Column<float>(nullable: false),
                    iexMarketPercent = table.Column<float>(nullable: false),
                    iexVolume = table.Column<int>(nullable: false),
                    avgTotalVolume = table.Column<int>(nullable: false),
                    iexBidPrice = table.Column<float>(nullable: false),
                    iexBidSize = table.Column<int>(nullable: false),
                    iexAskPrice = table.Column<float>(nullable: false),
                    iexAskSize = table.Column<int>(nullable: false),
                    marketCap = table.Column<long>(nullable: false),
                    peRatio = table.Column<float>(nullable: false),
                    week52High = table.Column<float>(nullable: false),
                    week52Low = table.Column<float>(nullable: false),
                    ytdChange = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gainers", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    headline = table.Column<string>(nullable: false),
                    datetime = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    summary = table.Column<string>(nullable: true),
                    related = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.headline);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Gainers");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
