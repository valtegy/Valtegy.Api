using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valtegy.Repository.Migrations.ValtegyDb
{
    public partial class AddStatusActivityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusActivity",
                columns: table => new
                {
                    StatusActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusActivity", x => x.StatusActivityId);
                });

            migrationBuilder.Sql("insert into [dbo].[StatusActivity] (Id, Name, Description, Active) values (NEWID(), 'Abierta', 'Abierta', 1);");
            migrationBuilder.Sql("insert into [dbo].[StatusActivity] (Id, Name, Description, Active) values (NEWID(), 'Pendiente', 'Pendiente', 1);");
            migrationBuilder.Sql("insert into [dbo].[StatusActivity] (Id, Name, Description, Active) values (NEWID(), 'Cerrada', 'Cerrada', 1);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusActivity");
        }
    }
}
