using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRCheck.Migrations
{
    /// <inheritdoc />
    public partial class ErrortableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorDatas",
                columns: table => new
                {
                    ErrorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorScript = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorLine = table.Column<int>(type: "int", nullable: false),
                    ErrorColumn = table.Column<int>(type: "int", nullable: false),
                    ErrorStack = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorDatas", x => x.ErrorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorDatas");
        }
    }
}
