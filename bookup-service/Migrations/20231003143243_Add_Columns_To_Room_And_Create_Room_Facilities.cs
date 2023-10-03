using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookup_service.Migrations
{
    /// <inheritdoc />
    public partial class Add_Columns_To_Room_And_Create_Room_Facilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "floor",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isBooked",
                table: "Rooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "floor",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "isBooked",
                table: "Rooms");
        }
    }
}
