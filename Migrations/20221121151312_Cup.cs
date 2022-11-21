using Microsoft.EntityFrameworkCore.Migrations;

namespace CupApplication.Migrations
{
    public partial class Cup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DB_WorkingSession",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DB_WorkingSession",
                table: "DB_WorkingSession",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DB_WorkingSession",
                table: "DB_WorkingSession");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DB_WorkingSession",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
