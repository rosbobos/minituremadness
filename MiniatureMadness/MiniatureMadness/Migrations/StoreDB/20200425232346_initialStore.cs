using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniatureMadness.Migrations.StoreDB
{
    public partial class initialStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "This coffee cake inspired cupcake is light and testes of sweet almonds and oats", "/Assets/CanvaAlmond.jpg", "Oats & Almond", 3m, "153-785" },
                    { 2, "Sharp clean raspberry mixes with a deep dark chocolate in this mini cupcake", "/Assets/CanvaChocoCupcake.jpg", "Chocolate Raspberry", 2m, "597-416" },
                    { 3, "Wheather doing a gender reveal or a simple baby shower these vanilla cupcakes are topped with sweet marzipan decorations", "/Assets/CanvaBabyShower.png", "Baby Shower Special", 4m, "984-354" },
                    { 4, "A simple and sweet milk chocolate cupcake topped with chocolate frosting and a sprinkle of sea salt", "/Assets/CanvaChocolate.jpg", "Classic Chocolate", 2m, "358-469" },
                    { 5, "A new take on red velvet, this is a soft chocolate flavored cupcake colored with current and current jam is added in the frosting for a truely blissful experiance", "/Assets/CanvaCurrent.jpg", "Current", 3m, "163-541" },
                    { 6, "These soft vanilla cupcakes are flavored with slightly tart blueberries which make them so refreshing", "/Assets/CanvaFourCupcakes.jpg", "Blueberry bliss", 3m, "268-198" },
                    { 7, "These are a mixture of sweet vanilla and strawberry. Topped with candy hearts", "/Assets/CanvaHearts.jpg", "Sweet heart", 2m, "698-164" },
                    { 8, "Sweet soft mint paired with deep dark chocolate", "/Assets/CanvaMintchoco.jpg", "Mint and chocolate", 2m, "354-925" },
                    { 9, "This is made with purple sweet potatoe to add a delicate flavor that is soft and slightly sweet", "/Assets/CanvaPurpleCupcake.jpg", "Purple princess", 3m, "567-298" },
                    { 10, "These multi colored cupcakes come in vanilla with a touch of magic", "/Assets/CanvaUnicornCupcakes.jpg", "Unicorn", 3m, "364-975" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
