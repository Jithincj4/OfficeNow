using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace officeNow_api.Migrations
{
    public partial class OfficeNowDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyLocation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkStation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyLocationId = table.Column<long>(type: "bigint", nullable: false),
                    SeatNo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkStation_CompanyLocation_CompanyLocationId",
                        column: x => x.CompanyLocationId,
                        principalTable: "CompanyLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLocationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_CompanyLocation_UserLocationId",
                        column: x => x.UserLocationId,
                        principalTable: "CompanyLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkStationTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkStationId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStationTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkStationTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkStationTag_WorkStation_WorkStationId",
                        column: x => x.WorkStationId,
                        principalTable: "WorkStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    WorkStationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingLog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingLog_WorkStation_WorkStationId",
                        column: x => x.WorkStationId,
                        principalTable: "WorkStation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTag_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingLog_UserId",
                table: "BookingLog",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingLog_WorkStationId",
                table: "BookingLog",
                column: "WorkStationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserLocationId",
                table: "User",
                column: "UserLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTag_TagId",
                table: "UserTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTag_UserId",
                table: "UserTag",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkStation_CompanyLocationId",
                table: "WorkStation",
                column: "CompanyLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkStationTag_TagId",
                table: "WorkStationTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkStationTag_WorkStationId",
                table: "WorkStationTag",
                column: "WorkStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingLog");

            migrationBuilder.DropTable(
                name: "UserTag");

            migrationBuilder.DropTable(
                name: "WorkStationTag");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "WorkStation");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "CompanyLocation");
        }
    }
}
