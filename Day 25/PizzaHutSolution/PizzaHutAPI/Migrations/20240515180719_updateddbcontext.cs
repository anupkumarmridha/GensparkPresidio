using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHutAPI.Migrations
{
    public partial class updateddbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Stocks_StockPizzaId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_StockPizzaId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "StockPizzaId",
                table: "Pizzas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockPizzaId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_StockPizzaId",
                table: "Pizzas",
                column: "StockPizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Stocks_StockPizzaId",
                table: "Pizzas",
                column: "StockPizzaId",
                principalTable: "Stocks",
                principalColumn: "PizzaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
