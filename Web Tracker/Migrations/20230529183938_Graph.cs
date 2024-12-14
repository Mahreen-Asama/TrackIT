using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRCheck.Migrations
{
    /// <inheritdoc />
    public partial class Graph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               @"CREATE VIEW [dbo].[FlowCollection]
	AS SELECT F1.[Page] as ""To"", F2.[Page] as ""From"", F1.FlowId as ""FlowID"", US.WebsiteId as ""WebsiteId""
	FROM [FlowDatas] F1
	JOIN [FlowDatas] F2 ON F1.[FlowDataId] = F2.[FlowDataId] - 1
	JOIN [Flows] FW ON F1.FlowId = FW.FlowId
	JOIN [Users] US ON FW.UserId = US.UserId
	Where F1.FlowId=F2.FlowId
"
);
            migrationBuilder.Sql(
               @"CREATE VIEW [dbo].[FlowCollectionSum]
	AS SELECT [To] as ""To"", [From] as ""From"", Count(*) as ""Count"", [WebsiteId] as ""WebsiteId""
	FROM [FlowCollection]
	Group by [To], [From], [WebsiteId]
"
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
