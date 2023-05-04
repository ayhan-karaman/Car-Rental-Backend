using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Add_CreditCard_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 29, 11, 13, 28, 512, DateTimeKind.Utc).AddTicks(5270),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 21, 18, 15, 23, 236, DateTimeKind.Utc).AddTicks(360));

            migrationBuilder.CreateTable(
                name: "credit_cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    card_number = table.Column<string>(type: "text", nullable: false),
                    ExpDate = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2023, 4, 29, 11, 13, 28, 513, DateTimeKind.Utc).AddTicks(1240)),
                    state = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_cards", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "credit_cards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 21, 18, 15, 23, 236, DateTimeKind.Utc).AddTicks(360),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 4, 29, 11, 13, 28, 512, DateTimeKind.Utc).AddTicks(5270));
        }
    }
}
