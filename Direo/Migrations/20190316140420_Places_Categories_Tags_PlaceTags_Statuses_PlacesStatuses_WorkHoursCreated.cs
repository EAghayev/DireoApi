using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Direo.Migrations
{
    public partial class Places_Categories_Tags_PlaceTags_Statuses_PlacesStatuses_WorkHoursCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Youtube",
                table: "Users",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                table: "Users",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Linkedin",
                table: "Users",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Google",
                table: "Users",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Facebook = table.Column<string>(maxLength: 150, nullable: true),
                    Instagram = table.Column<string>(maxLength: 150, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 150, nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: true),
                    Twitter = table.Column<string>(maxLength: 150, nullable: true),
                    Youtube = table.Column<string>(maxLength: 150, nullable: true),
                    Lat = table.Column<string>(maxLength: 100, nullable: true),
                    Lon = table.Column<string>(maxLength: 100, nullable: true),
                    CategoryId = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Places_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    PlaceId = table.Column<string>(maxLength: 50, nullable: false),
                    StatusId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceStatuses_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceTags",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    TagId = table.Column<string>(maxLength: 50, nullable: false),
                    PlaceId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceTags_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHours",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    PlaceId = table.Column<string>(maxLength: 50, nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Open = table.Column<TimeSpan>(type: "time", nullable: false),
                    Close = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHours_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_CategoryId",
                table: "Places",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_UserId",
                table: "Places",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceStatuses_PlaceId",
                table: "PlaceStatuses",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceStatuses_StatusId",
                table: "PlaceStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTags_PlaceId",
                table: "PlaceTags",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTags_TagId",
                table: "PlaceTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHours_PlaceId",
                table: "WorkHours",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceStatuses");

            migrationBuilder.DropTable(
                name: "PlaceTags");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Youtube",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Linkedin",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Google",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
