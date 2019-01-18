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
                name: "Cavers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cavers", x => x.Id);
                });

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
                    ClubId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    PhotoName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caves_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caves_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Difficulty = table.Column<int>(nullable: false),
                    CaverId = table.Column<int>(nullable: false),
                    CaveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifficultyRatings_Caves_CaveId",
                        column: x => x.CaveId,
                        principalTable: "Caves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DifficultyRatings_Cavers_CaverId",
                        column: x => x.CaverId,
                        principalTable: "Cavers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cavers",
                columns: new[] { "Id", "Created", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 9, 20, 42, 31, 93, DateTimeKind.Local), "Maxim", "Lesy" },
                    { 2, new DateTime(2019, 1, 9, 20, 42, 31, 93, DateTimeKind.Local), "Evi", "De Baets" },
                    { 3, new DateTime(2019, 1, 9, 20, 42, 31, 93, DateTimeKind.Local), "Charlotte", "Janssens" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "City", "Created", "Housenumber", "Name", "PostalCode", "Streetname" },
                values: new object[,]
                {
                    { 1, "Oostende", new DateTime(2019, 1, 9, 20, 42, 30, 910, DateTimeKind.Local), 22, "Speleo Cascade", 8250, "Koebrugstraat" },
                    { 2, "Brugge", new DateTime(2019, 1, 9, 20, 42, 30, 912, DateTimeKind.Local), 33, "Speleo IVO", 8000, "Nijverheidslaan" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Created", "Name", "ShortName" },
                values: new object[] { 1, new DateTime(2019, 1, 9, 20, 42, 30, 912, DateTimeKind.Local), "Belgium", "BE" });

            migrationBuilder.InsertData(
                table: "Caves",
                columns: new[] { "Id", "ClubId", "CountryId", "Created", "Depth", "Description", "Difficulty", "HasFormations", "IsDivingCave", "Latitude", "Length", "Longitude", "Name", "PhotoName" },
                values: new object[] { 1, 1, 1, new DateTime(2019, 1, 9, 20, 42, 30, 913, DateTimeKind.Local), 100, "Awesome cave!", 4, true, true, 30.343432, 123, 3.238184, "Fosse Sin Sin", "caveimg1.jpg" });

            migrationBuilder.InsertData(
                table: "Caves",
                columns: new[] { "Id", "ClubId", "CountryId", "Created", "Depth", "Description", "Difficulty", "HasFormations", "IsDivingCave", "Latitude", "Length", "Longitude", "Name", "PhotoName" },
                values: new object[] { 2, 1, 1, new DateTime(2019, 1, 9, 20, 42, 30, 913, DateTimeKind.Local), 130, "Bears!", 1, false, false, 33.433488, 123, 8.5941, "Fosse Aux Ours", "caveimg2.jpg" });

            migrationBuilder.InsertData(
                table: "Caves",
                columns: new[] { "Id", "ClubId", "CountryId", "Created", "Depth", "Description", "Difficulty", "HasFormations", "IsDivingCave", "Latitude", "Length", "Longitude", "Name", "PhotoName" },
                values: new object[] { 3, 2, 1, new DateTime(2019, 1, 9, 20, 42, 30, 913, DateTimeKind.Local), 4130, "Big cave!", 3, true, false, 1.777777, 1623, 2.777777, "Grottes de Han", "caveimg3.jpg" });

            migrationBuilder.InsertData(
                table: "DifficultyRatings",
                columns: new[] { "Id", "CaveId", "CaverId", "Created", "Difficulty" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2019, 1, 9, 20, 42, 31, 107, DateTimeKind.Local), 5 },
                    { 2, 1, 2, new DateTime(2019, 1, 9, 20, 42, 31, 107, DateTimeKind.Local), 2 },
                    { 3, 1, 3, new DateTime(2019, 1, 9, 20, 42, 31, 107, DateTimeKind.Local), 1 },
                    { 4, 2, 1, new DateTime(2019, 1, 9, 20, 42, 31, 107, DateTimeKind.Local), 4 },
                    { 5, 2, 3, new DateTime(2019, 1, 9, 20, 42, 31, 107, DateTimeKind.Local), 1 },
                    { 6, 2, 3, new DateTime(2019, 1, 9, 20, 42, 31, 107, DateTimeKind.Local), 2 },
                    { 7, 3, 1, new DateTime(2019, 1, 9, 20, 42, 31, 107, DateTimeKind.Local), 1 },
                    { 8, 3, 2, new DateTime(2019, 1, 9, 20, 42, 31, 107, DateTimeKind.Local), 5 },
                    { 9, 3, 1, new DateTime(2019, 1, 9, 20, 42, 31, 108, DateTimeKind.Local), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caves_ClubId",
                table: "Caves",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Caves_CountryId",
                table: "Caves",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyRatings_CaveId",
                table: "DifficultyRatings",
                column: "CaveId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyRatings_CaverId",
                table: "DifficultyRatings",
                column: "CaverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DifficultyRatings");

            migrationBuilder.DropTable(
                name: "Caves");

            migrationBuilder.DropTable(
                name: "Cavers");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
