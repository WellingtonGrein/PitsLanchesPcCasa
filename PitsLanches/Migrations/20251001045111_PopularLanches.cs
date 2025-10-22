using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitsLanches.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemURL, ImagemThumvnailUrl, IsLanchePreferido, EmEstoque, CategoriaId) " +
                     "VALUES('X-Burger Duplo', 'Pão, hambúrguer duplo, queijo', 'Delicioso pão com dois suculentos hambúrgueres de 180g e queijo cheddar derretido', 25.50, '', '', 1, 1, 1)");

            migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemURL, ImagemThumvnailUrl, IsLanchePreferido, EmEstoque, CategoriaId) " +
                                 "VALUES('Sanduíche Natural', 'Pão integral, peito de peru e salada', 'Leve e saudável sanduíche no pão integral com peito de peru, alface, tomate e cenoura', 18.00, '', '', 0, 1, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
