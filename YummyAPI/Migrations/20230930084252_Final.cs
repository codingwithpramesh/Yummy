using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyAPI.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPeople = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ecomPortfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrontTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubHeading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubHeading2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subdescription3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalClient = table.Column<int>(type: "int", nullable: false),
                    totalProject = table.Column<int>(type: "int", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    TotalWorkers = table.Column<int>(type: "int", nullable: false),
                    Subheading3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCategory = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ecomPortfolios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ecomPortfolios");
        }
    }
}
