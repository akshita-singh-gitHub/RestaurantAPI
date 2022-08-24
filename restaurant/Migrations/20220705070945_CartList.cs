using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restaurant.Migrations
{
    public partial class CartList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "CartList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                    UserId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),

                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartItems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Restaurant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartList");

           
        }
    }
}
