using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Webinars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ScheduledOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webinars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Webinars",
                columns: new[] { "Id", "Name", "ScheduledOn" },
                values: new object[,]
                {
                    { new Guid("1a64834f-a7cb-4664-98b8-8049c402bb23"), "sayed", new DateTime(2000, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63f3a725-5b5a-4dca-8171-f1b946b13a18"), "pepo", new DateTime(2000, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76245aa3-4bc7-49e6-b208-836af053ad96"), "ali", new DateTime(2000, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("892852b0-eda6-4616-8932-d6efe0888afd"), "ahmed", new DateTime(2000, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6700d5a-964e-47a0-b428-844745e31f4c"), "kareem", new DateTime(2000, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d14fa399-6f62-4636-89c6-7265f6c1304d"), "mohamed", new DateTime(2000, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Webinars");
        }
    }
}
