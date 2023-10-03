using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyAPI.Migrations
{
    /// <inheritdoc />
    public partial class Finalresult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodPrice",
                table: "ecomPortfolios");

            migrationBuilder.RenameColumn(
                name: "subtitle",
                table: "ecomPortfolios",
                newName: "professorTitle");

            migrationBuilder.RenameColumn(
                name: "subdescription3",
                table: "ecomPortfolios",
                newName: "professorName");

            migrationBuilder.RenameColumn(
                name: "subField",
                table: "ecomPortfolios",
                newName: "eventtitle");

            migrationBuilder.RenameColumn(
                name: "Subtitle2",
                table: "ecomPortfolios",
                newName: "eventDescription");

            migrationBuilder.RenameColumn(
                name: "Subheading3",
                table: "ecomPortfolios",
                newName: "eventDescrip");

            migrationBuilder.RenameColumn(
                name: "SubVideo",
                table: "ecomPortfolios",
                newName: "contactEmail");

            migrationBuilder.RenameColumn(
                name: "SubTitle3",
                table: "ecomPortfolios",
                newName: "contactAddress");

            migrationBuilder.RenameColumn(
                name: "SubImage",
                table: "ecomPortfolios",
                newName: "chefTitle");

            migrationBuilder.RenameColumn(
                name: "SubHeading2",
                table: "ecomPortfolios",
                newName: "chefName");

            migrationBuilder.RenameColumn(
                name: "SubHeading",
                table: "ecomPortfolios",
                newName: "ProfessorRating");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ecomPortfolios",
                newName: "ProfessorPosition");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ecomPortfolios",
                newName: "ProfessorDescription");

            migrationBuilder.RenameColumn(
                name: "FrontTitle",
                table: "ecomPortfolios",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "FrontImage",
                table: "ecomPortfolios",
                newName: "OpeningHour");

            migrationBuilder.RenameColumn(
                name: "FrontDescription",
                table: "ecomPortfolios",
                newName: "Menuvalue");

            migrationBuilder.RenameColumn(
                name: "FoodName",
                table: "ecomPortfolios",
                newName: "MenuTitle");

            migrationBuilder.RenameColumn(
                name: "FoodItems",
                table: "ecomPortfolios",
                newName: "HeroTitle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ecomPortfolios",
                newName: "HeroDescription");

            migrationBuilder.AddColumn<string>(
                name: "AboutDescription",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutImage",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutNumber",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutTitle",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutVideos",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardButtonText",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardDescription",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardTitle",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChefDescription",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChefImage",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChefPosition",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactDescription",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactTitle",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventImage",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "EventPrice",
                table: "ecomPortfolios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FooterAddress",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterEmail",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterOpeningHour",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterPhone",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GalleryImage",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GalleryTitle",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeroButton",
                table: "ecomPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropColumn(
                name: "AboutDescription",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "AboutImage",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "AboutNumber",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "AboutTitle",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "AboutVideos",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "CardButtonText",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "CardDescription",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "CardTitle",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "ChefDescription",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "ChefImage",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "ChefPosition",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "ContactDescription",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "ContactTitle",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "EventImage",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "EventPrice",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "FooterAddress",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "FooterEmail",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "FooterOpeningHour",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "FooterPhone",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "GalleryImage",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "GalleryTitle",
                table: "ecomPortfolios");

            migrationBuilder.DropColumn(
                name: "HeroButton",
                table: "ecomPortfolios");

            migrationBuilder.RenameColumn(
                name: "professorTitle",
                table: "ecomPortfolios",
                newName: "subtitle");

            migrationBuilder.RenameColumn(
                name: "professorName",
                table: "ecomPortfolios",
                newName: "subdescription3");

            migrationBuilder.RenameColumn(
                name: "eventtitle",
                table: "ecomPortfolios",
                newName: "subField");

            migrationBuilder.RenameColumn(
                name: "eventDescription",
                table: "ecomPortfolios",
                newName: "Subtitle2");

            migrationBuilder.RenameColumn(
                name: "eventDescrip",
                table: "ecomPortfolios",
                newName: "Subheading3");

            migrationBuilder.RenameColumn(
                name: "contactEmail",
                table: "ecomPortfolios",
                newName: "SubVideo");

            migrationBuilder.RenameColumn(
                name: "contactAddress",
                table: "ecomPortfolios",
                newName: "SubTitle3");

            migrationBuilder.RenameColumn(
                name: "chefTitle",
                table: "ecomPortfolios",
                newName: "SubImage");

            migrationBuilder.RenameColumn(
                name: "chefName",
                table: "ecomPortfolios",
                newName: "SubHeading2");

            migrationBuilder.RenameColumn(
                name: "ProfessorRating",
                table: "ecomPortfolios",
                newName: "SubHeading");

            migrationBuilder.RenameColumn(
                name: "ProfessorPosition",
                table: "ecomPortfolios",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ProfessorDescription",
                table: "ecomPortfolios",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "ecomPortfolios",
                newName: "FrontTitle");

            migrationBuilder.RenameColumn(
                name: "OpeningHour",
                table: "ecomPortfolios",
                newName: "FrontImage");

            migrationBuilder.RenameColumn(
                name: "Menuvalue",
                table: "ecomPortfolios",
                newName: "FrontDescription");

            migrationBuilder.RenameColumn(
                name: "MenuTitle",
                table: "ecomPortfolios",
                newName: "FoodName");

            migrationBuilder.RenameColumn(
                name: "HeroTitle",
                table: "ecomPortfolios",
                newName: "FoodItems");

            migrationBuilder.RenameColumn(
                name: "HeroDescription",
                table: "ecomPortfolios",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "FoodPrice",
                table: "ecomPortfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
