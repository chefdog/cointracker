using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoTracker.Common.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ct");

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    ArticleType = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    CoinId = table.Column<long>(nullable: false),
                    PortfolioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coin",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    ListPrice = table.Column<decimal>(nullable: false),
                    BuyPrice = table.Column<decimal>(nullable: false),
                    SellPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryLog",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    ParamKey = table.Column<string>(nullable: true),
                    ParamValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiningItem",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiningItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiningRig",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiningRig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paragraph",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Paragraph = table.Column<string>(nullable: true),
                    ArticleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraph", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    IsShared = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItem",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    CoinModelId = table.Column<long>(nullable: false),
                    MiningModelId = table.Column<long>(nullable: false),
                    PortfolioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                schema: "ct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RowGuid = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article",
                schema: "ct");

            migrationBuilder.DropTable(
                name: "Coin",
                schema: "ct");

            migrationBuilder.DropTable(
                name: "HistoryLog",
                schema: "ct");

            migrationBuilder.DropTable(
                name: "MiningItem",
                schema: "ct");

            migrationBuilder.DropTable(
                name: "MiningRig",
                schema: "ct");

            migrationBuilder.DropTable(
                name: "Paragraph",
                schema: "ct");

            migrationBuilder.DropTable(
                name: "Portfolio",
                schema: "ct");

            migrationBuilder.DropTable(
                name: "PortfolioItem",
                schema: "ct");

            migrationBuilder.DropTable(
                name: "UserAccount",
                schema: "ct");
        }
    }
}
