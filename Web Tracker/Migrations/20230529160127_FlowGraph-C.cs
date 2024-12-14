using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRCheck.Migrations
{
    /// <inheritdoc />
    public partial class FlowGraphC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[FlowCollectSum]
	AS SELECT [To] as ""To"", [From] as ""From"", Count(*) as ""FlowID""
	FROM [FlowCollect]
	Group by [To], [From] 
"
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
