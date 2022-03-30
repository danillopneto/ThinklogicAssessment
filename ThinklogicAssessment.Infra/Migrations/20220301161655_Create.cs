using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThinklogicAssessment.Infra.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of the event."),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End date of the event."),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Title of the event."),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Location of the event."),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true, comment: "Description of the event."),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_StartDate",
                table: "Event",
                column: "StartDate")
                .Annotation("SqlServer:Clustered", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
