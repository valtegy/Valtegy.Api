using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valtegy.Repository.Migrations.ValtegyDb
{
    public partial class AddActivityTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ActivityTypeId);
                });

            migrationBuilder.Sql("insert into [dbo].[ActivityType] (Id, Name, Description) values (NEWID(), 'Pendiente por definir', 'Id ticket o proyecto pendiente');");
            migrationBuilder.Sql("insert into [dbo].[ActivityType] (Id, Name, Description) values (NEWID(), 'Ticket', 'Actividad de ticket');");
            migrationBuilder.Sql("insert into [dbo].[ActivityType] (Id, Name, Description) values (NEWID(), 'Proyecto', 'Actividad de proyecto');");
            migrationBuilder.Sql("insert into [dbo].[ActivityType] (Id, Name, Description) values (NEWID(), 'Actividad interna', 'Actividad de interna Valtegy');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityType");
        }
    }
}
