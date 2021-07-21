using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVendas.Migrations
{
    public partial class CREATE_ItemVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    VendaId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_VendaId",
                table: "ItemVenda",
                column: "VendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemVenda");
        }
    }
}
