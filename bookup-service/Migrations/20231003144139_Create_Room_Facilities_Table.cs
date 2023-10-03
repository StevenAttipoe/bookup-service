using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookup_service.Migrations
{
    /// <inheritdoc />
    public partial class Create_Room_Facilities_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasBathroom",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "hasFan",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "hasFridge",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "hasKitchen",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "hasTv",
                table: "Rooms");

            migrationBuilder.CreateTable(
                name: "RoomFacilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HasTv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasFridge = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasFan = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasKitchen = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasBathroom = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFacilities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomFacilities");

            migrationBuilder.AddColumn<bool>(
                name: "hasBathroom",
                table: "Rooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasFan",
                table: "Rooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasFridge",
                table: "Rooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasKitchen",
                table: "Rooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasTv",
                table: "Rooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
