using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApparelShoppingAppAPI.Migrations
{
    public partial class AddedPaymentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PaymentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PaymentDetails");
        }
    }
}
