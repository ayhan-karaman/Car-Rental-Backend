using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Add_CardHolderName_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "credit_cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 29, 12, 44, 54, 969, DateTimeKind.Utc).AddTicks(5320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 29, 11, 13, 28, 513, DateTimeKind.Utc).AddTicks(1240));

            migrationBuilder.AddColumn<string>(
                name: "card_holder_name",
                table: "credit_cards",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 29, 12, 44, 54, 968, DateTimeKind.Utc).AddTicks(8690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 29, 11, 13, 28, 512, DateTimeKind.Utc).AddTicks(5270));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "card_holder_name",
                table: "credit_cards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "credit_cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 29, 11, 13, 28, 513, DateTimeKind.Utc).AddTicks(1240),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 29, 12, 44, 54, 969, DateTimeKind.Utc).AddTicks(5320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 29, 11, 13, 28, 512, DateTimeKind.Utc).AddTicks(5270),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 29, 12, 44, 54, 968, DateTimeKind.Utc).AddTicks(8690));
        }
    }
}
