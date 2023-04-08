using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Model_Entity_Add_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "model_year",
                table: "models",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "speed",
                table: "models",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 8, 11, 10, 43, 346, DateTimeKind.Utc).AddTicks(9010),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 6, 19, 34, 49, 452, DateTimeKind.Utc).AddTicks(6530));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "model_year",
                table: "models");

            migrationBuilder.DropColumn(
                name: "speed",
                table: "models");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 19, 34, 49, 452, DateTimeKind.Utc).AddTicks(6530),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 8, 11, 10, 43, 346, DateTimeKind.Utc).AddTicks(9010));
        }
    }
}
