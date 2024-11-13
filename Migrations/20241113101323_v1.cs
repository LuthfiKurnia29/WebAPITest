using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDOT.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaksi_t_produk_produk_id",
                table: "Transaksi");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaksi_t_user_user_id",
                table: "Transaksi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaksi",
                table: "Transaksi");

            migrationBuilder.RenameTable(
                name: "Transaksi",
                newName: "t_transaksi",
                newSchema: "v1");

            migrationBuilder.RenameIndex(
                name: "IX_Transaksi_user_id",
                schema: "v1",
                table: "t_transaksi",
                newName: "IX_t_transaksi_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Transaksi_produk_id",
                schema: "v1",
                table: "t_transaksi",
                newName: "IX_t_transaksi_produk_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_transaksi",
                schema: "v1",
                table: "t_transaksi",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_transaksi_t_produk_produk_id",
                schema: "v1",
                table: "t_transaksi",
                column: "produk_id",
                principalSchema: "v1",
                principalTable: "t_produk",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_transaksi_t_user_user_id",
                schema: "v1",
                table: "t_transaksi",
                column: "user_id",
                principalSchema: "v1",
                principalTable: "t_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_transaksi_t_produk_produk_id",
                schema: "v1",
                table: "t_transaksi");

            migrationBuilder.DropForeignKey(
                name: "FK_t_transaksi_t_user_user_id",
                schema: "v1",
                table: "t_transaksi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_transaksi",
                schema: "v1",
                table: "t_transaksi");

            migrationBuilder.RenameTable(
                name: "t_transaksi",
                schema: "v1",
                newName: "Transaksi");

            migrationBuilder.RenameIndex(
                name: "IX_t_transaksi_user_id",
                table: "Transaksi",
                newName: "IX_Transaksi_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_transaksi_produk_id",
                table: "Transaksi",
                newName: "IX_Transaksi_produk_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaksi",
                table: "Transaksi",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksi_t_produk_produk_id",
                table: "Transaksi",
                column: "produk_id",
                principalSchema: "v1",
                principalTable: "t_produk",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksi_t_user_user_id",
                table: "Transaksi",
                column: "user_id",
                principalSchema: "v1",
                principalTable: "t_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
