using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    MakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Abrv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.MakeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Abrv = table.Column<string>(nullable: true),
                    MakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleMakes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "VehicleMakes",
                        principalColumn: "MakeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "MakeId", "Abrv", "Name" },
                values: new object[,]
                {
                    { 1, "Germany", "Audi" },
                    { 2, "Germany", "BMW" },
                    { 3, "Japan", "Honda" },
                    { 4, "Italy", "Alfa Romeo" },
                    { 5, "Spain", "Seat" },
                    { 6, "Japan", "Subaru" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "ModelId", "Abrv", "MakeId", "Name" },
                values: new object[,]
                {
                    { 1, "Germany", 1, "A3" },
                    { 2, "Germany", 1, "A6" },
                    { 3, "Germany", 2, "M3" },
                    { 4, "Germany", 2, "530" },
                    { 6, "Japan", 3, "Civic" },
                    { 5, "Spain", 5, "Leon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_MakeId",
                table: "VehicleModels",
                column: "MakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleMakes");
        }
    }
}
