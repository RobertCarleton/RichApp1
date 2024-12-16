using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp34.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuthorizationDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Contact",
                newName: "OwnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Contact",
                newName: "OwnerId");
        }
    }
}
