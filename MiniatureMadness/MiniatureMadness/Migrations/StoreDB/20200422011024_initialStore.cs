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
                    { 1, "The merc witht he mouth now in mini form", null, "Deapool", 1099m, "153-785" },
                    { 2, "The big green guy now can fit in your hand", null, "Hulk", 1199m, "597-416" },
                    { 3, "He is really good at shoting arrows, thats about it", null, "Hawk-eye", 499m, "984-354" },
                    { 4, "Get to the bright side and look at all those happy little trees", null, "Bob Ross", 10000m, "358-469" },
                    { 5, "Destroy mini sized cities", null, "Godzilla", 999m, "163-541" },
                    { 6, "Get two and they can point at eachother", null, "Spiderman", 899m, "268-198" },
                    { 7, "He might change into a snake since you like them, but when you pick him up he changes back and stabs you", null, "Loki", 799m, "698-164" },
                    { 8, "maybe you have heard of him", null, "Starlord", 699m, "354-925" },
                    { 9, "to get eyes like his you need a to find a shady doctor in a max security prison... or just buy the mini", null, "Riddick", 799m, "567-298" },
                    { 10, "Comes with everything you need! Laptop, mouse, desk, slippers and coffee.", null, "Work at home mini set", 1100m, "364-975" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
