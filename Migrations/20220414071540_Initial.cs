using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheapCars.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    EngineCapacity = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    DriveType = table.Column<int>(nullable: false),
                    Gearbox = table.Column<string>(maxLength: 50, nullable: false),
                    Cut = table.Column<bool>(nullable: false),
                    FullDuty = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(maxLength: 20, nullable: true),
                    NumberOfShipments = table.Column<int>(nullable: false),
                    SteeringWheelPosition = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EngineType = table.Column<string>(nullable: true),
                    BodyType = table.Column<string>(nullable: true),
                    Auction = table.Column<string>(nullable: true),
                    Mark = table.Column<double>(nullable: true),
                    AuctionDate = table.Column<DateTime>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Shipped = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
