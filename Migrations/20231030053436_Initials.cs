using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectKFWebApi.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Molecules",
                columns: table => new
                {
                    IdMolecules = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoleculesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MolDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molecules", x => x.IdMolecules);
                });

            migrationBuilder.CreateTable(
                name: "Study",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VersionID = table.Column<int>(type: "int", nullable: false),
                    ProtocolTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProtocolCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MoleculesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusStudyID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Study", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Molecules",
                columns: new[] { "IdMolecules", "IsActive", "MolDescription", "MoleculesName", "State" },
                values: new object[] { new Guid("0ec8061c-594b-496a-b7bb-99190cfea9fa"), 1, "Vaccine against TB antigen", "TB vaccine", "-" });

            migrationBuilder.InsertData(
                table: "StudyStatus",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Start up" },
                    { 2, "Sites initiated" },
                    { 3, "Recruiting" },
                    { 4, "Recruiting Close" },
                    { 5, "Last Site Recruiting" },
                    { 6, "CSR Closed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Molecules");

            migrationBuilder.DropTable(
                name: "Study");

            migrationBuilder.DropTable(
                name: "StudyStatus");
        }
    }
}
