using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Model_Entity_Add_IsBabySeat_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_baby_seat",
                table: "models",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 8, 11, 43, 4, 632, DateTimeKind.Utc).AddTicks(2020),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 8, 11, 10, 43, 346, DateTimeKind.Utc).AddTicks(9010));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_baby_seat",
                table: "models");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 8, 11, 10, 43, 346, DateTimeKind.Utc).AddTicks(9010),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 8, 11, 43, 4, 632, DateTimeKind.Utc).AddTicks(2020));
        }
    }
}
