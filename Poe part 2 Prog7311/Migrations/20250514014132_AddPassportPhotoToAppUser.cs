using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poe_part_2_Prog7311.Migrations
{
    /// <inheritdoc />
    public partial class AddPassportPhotoToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassportPhotoPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportPhotoPath",
                table: "AspNetUsers");
        }
    }
}
