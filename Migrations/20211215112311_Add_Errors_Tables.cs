using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Email_Scheduler_WebApi.Migrations
{
    public partial class Add_Errors_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFault",
                table: "EmailSchedules",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleErrors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ErrorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleErrors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleErrors_EmailSchedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "EmailSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleErrors_Errors_ErrorId",
                        column: x => x.ErrorId,
                        principalTable: "Errors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleErrors_ErrorId",
                table: "ScheduleErrors",
                column: "ErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleErrors_ScheduleId",
                table: "ScheduleErrors",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleErrors");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropColumn(
                name: "IsFault",
                table: "EmailSchedules");
        }
    }
}
