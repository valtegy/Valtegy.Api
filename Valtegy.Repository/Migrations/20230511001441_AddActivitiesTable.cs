using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Valtegy.Repository.Migrations
{
    public partial class AddActivitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: true),
                    UserIdCreated = table.Column<Guid>(nullable: false),
                    UserIdUpdated = table.Column<Guid>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ActivityDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ActivityTypeId = table.Column<int>(nullable: false),
                    ActivityNumber = table.Column<int>(nullable: false),
                    StatusActivityId = table.Column<int>(nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
