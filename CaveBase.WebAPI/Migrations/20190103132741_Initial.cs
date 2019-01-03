using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaveBase.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true),
                    Streetname = table.Column<string>(nullable: true),
                    Housenumber = table.Column<int>(nullable: false),
                    PostalCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    IsDivingCave = table.Column<bool>(nullable: false),
                    HasFormations = table.Column<bool>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    ResponsibleClubId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    PhotoName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caves_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Caves_Clubs_ResponsibleClubId",
                        column: x => x.ResponsibleClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "City", "Created", "Housenumber", "Name", "PostalCode", "Streetname" },
                values: new object[] { 1, "Oostende", new DateTime(2019, 1, 3, 14, 27, 41, 479, DateTimeKind.Local), 22, "Speleo Cascade", 8250, "Koebrugstraat" });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "City", "Created", "Housenumber", "Name", "PostalCode", "Streetname" },
                values: new object[] { 2, "Brugge", new DateTime(2019, 1, 3, 14, 27, 41, 480, DateTimeKind.Local), 33, "Speleo IVO", 8000, "Nijverheidslaan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Created", "Name", "ShortName" },
                values: new object[] { 1, new DateTime(2019, 1, 3, 14, 27, 41, 480, DateTimeKind.Local), "Belgium", "BE" });

            migrationBuilder.InsertData(
                table: "Caves",
                columns: new[] { "Id", "CountryId", "Created", "Depth", "Description", "Difficulty", "HasFormations", "IsDivingCave", "Latitude", "Length", "Longitude", "Name", "PhotoName", "ResponsibleClubId" },
                values: new object[] { 1, 1, new DateTime(2019, 1, 3, 14, 27, 41, 477, DateTimeKind.Local), 100, "Awesome cave!", 4, true, true, 30.343432, 123, 3.238184, "Fosse Sin Sin", "caveimg1.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Caves",
                columns: new[] { "Id", "CountryId", "Created", "Depth", "Description", "Difficulty", "HasFormations", "IsDivingCave", "Latitude", "Length", "Longitude", "Name", "PhotoName", "ResponsibleClubId" },
                values: new object[] { 2, 1, new DateTime(2019, 1, 3, 14, 27, 41, 479, DateTimeKind.Local), 130, "Bears!", 1, false, false, 33.433488, 123, 8.5941, "Fosse Aux Ours", "caveimg2.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Caves",
                columns: new[] { "Id", "CountryId", "Created", "Depth", "Description", "Difficulty", "HasFormations", "IsDivingCave", "Latitude", "Length", "Longitude", "Name", "PhotoName", "ResponsibleClubId" },
                values: new object[] { 3, 1, new DateTime(2019, 1, 3, 14, 27, 41, 479, DateTimeKind.Local), 4130, "Big cave!", 3, true, false, 1.777777, 1623, 2.777777, "Grottes de Han", "caveimg3.jpg", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Caves_CountryId",
                table: "Caves",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Caves_ResponsibleClubId",
                table: "Caves",
                column: "ResponsibleClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caves");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
