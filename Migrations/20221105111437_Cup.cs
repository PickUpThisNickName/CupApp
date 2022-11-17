using Microsoft.EntityFrameworkCore.Migrations;

namespace CupApplication.Migrations
{
    public partial class Cup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DB_Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Beneficiaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DB_BenefitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koefficient = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_BenefitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DB_Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Cup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DB_Drinks_leftovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Drinks_leftovers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DB_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeInStock = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PortionVolume = table.Column<float>(type: "real", nullable: false),
                    PortionPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DB_Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingTimeId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    BeneficiariID = table.Column<int>(type: "int", nullable: false),
                    Cup1_ID = table.Column<int>(type: "int", nullable: false),
                    Cup1_Amount = table.Column<int>(type: "int", nullable: false),
                    Cup2_ID = table.Column<int>(type: "int", nullable: false),
                    Cup2_Amount = table.Column<int>(type: "int", nullable: false),
                    Cup3_ID = table.Column<int>(type: "int", nullable: false),
                    Cup3_Amount = table.Column<int>(type: "int", nullable: false),
                    Cup4_ID = table.Column<int>(type: "int", nullable: false),
                    Cup4_Amount = table.Column<int>(type: "int", nullable: false),
                    Cup5_ID = table.Column<int>(type: "int", nullable: false),
                    Cup5_Amount = table.Column<int>(type: "int", nullable: false),
                    Product1_ID = table.Column<int>(type: "int", nullable: false),
                    Product1_Amount = table.Column<int>(type: "int", nullable: false),
                    Product2_ID = table.Column<int>(type: "int", nullable: false),
                    Product2_Amount = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DB_WorkingSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkerID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_WorkingSession", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DB_Beneficiaries");

            migrationBuilder.DropTable(
                name: "DB_BenefitType");

            migrationBuilder.DropTable(
                name: "DB_Drinks");

            migrationBuilder.DropTable(
                name: "DB_Drinks_leftovers");

            migrationBuilder.DropTable(
                name: "DB_Products");

            migrationBuilder.DropTable(
                name: "DB_Sales");

            migrationBuilder.DropTable(
                name: "DB_WorkingSession");
        }
    }
}
