using Microsoft.EntityFrameworkCore.Migrations;

namespace CupApplication.Migrations
{
    public partial class Cup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "DB_Beneficiaries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "DB_Beneficiaries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
