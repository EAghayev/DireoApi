using Microsoft.EntityFrameworkCore.Migrations;

namespace Direo.Migrations
{
    public partial class UserCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Fullname = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Profile = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 150, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Twitter = table.Column<string>(maxLength: 100, nullable: true),
                    Google = table.Column<string>(maxLength: 100, nullable: true),
                    Youtube = table.Column<string>(maxLength: 100, nullable: true),
                    Linkedin = table.Column<string>(maxLength: 100, nullable: true),
                    About = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
