using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp34.Data.Migrations
{
    /// <inheritdoc />
    public partial class WILLTHISWORK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomTag",
                schema: "notdbo",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "notdbo",
                table: "MyRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomTag",
                schema: "notdbo",
                table: "MyUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "notdbo",
                table: "MyRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
