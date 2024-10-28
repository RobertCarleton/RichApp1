using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W5L2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserA", x => x.ID);
                    table.CheckConstraint("CK_UserA_Age", "[Age] >= 0 AND [Age] <= 200");
                });

            migrationBuilder.CreateTable(
                name: "UserB",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<int>(type: "int", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserB", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_UserB_UserA_UserID",
                        column: x => x.UserID,
                        principalTable: "UserA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserB");

            migrationBuilder.DropTable(
                name: "UserA");
        }
    }
}
