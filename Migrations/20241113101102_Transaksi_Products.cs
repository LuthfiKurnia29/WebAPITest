using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDOT.Migrations
{
    /// <inheritdoc />
    public partial class Transaksi_Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_produk",
                schema: "v1",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jumlah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_produk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transaksi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    produk_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    jumlah_beli = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaksi", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transaksi_t_produk_produk_id",
                        column: x => x.produk_id,
                        principalSchema: "v1",
                        principalTable: "t_produk",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaksi_t_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "v1",
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaksi_produk_id",
                table: "Transaksi",
                column: "produk_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transaksi_user_id",
                table: "Transaksi",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaksi");

            migrationBuilder.DropTable(
                name: "t_produk",
                schema: "v1");
        }
    }
}
