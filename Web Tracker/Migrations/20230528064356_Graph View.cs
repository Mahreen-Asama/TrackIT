using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRCheck.Migrations
{
    /// <inheritdoc />
    public partial class GraphView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[FlowCollect]
	AS SELECT F1.[Page] as ""To"", F2.[Page] as ""From"", F1.FlowId as ""FlowID""
	FROM [FlowDatas] F1
	JOIN [FlowDatas] F2 ON F1.[FlowDataId] = F2.[FlowDataId] - 1
	Where F1.FlowId=F2.FlowId
"
);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
