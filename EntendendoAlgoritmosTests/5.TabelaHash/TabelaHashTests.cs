using EntendendoAlgoritmos._5.TabelaHash;
using EntendendoAlgoritmos._4.FuncaoHash;

namespace EntendendoAlgoritmosTests._5.TabelaHashTest
{
    public class TabelaHashTests
    {
        [Fact]
        public void DeveCriarUmaTabelaHash()
        {
            var tamanhoDoArray = 10;
            var tabelaHash = new TabelaHash(tamanhoDoArray);
            Assert.Equal(tamanhoDoArray, tabelaHash.ArrayDePrecos.Length);
        }

        [Fact]
        public void DeveIserirPrecoNoArray()
        {
            //Arrange
            var item = "Ouro Branco";
            var preco = 2.50;
            
            int tamanhoArray = 10;
            uint hashDoItem = FuncaoHash.FNV1a(item);
            int indiceEsperado = (int)(hashDoItem % (uint)tamanhoArray);

            var tabelaHash = new TabelaHash(tamanhoArray);

            //Act
            tabelaHash.InserirPreco(preco, item);

            //Assert
            Assert.Equal(indiceEsperado, Array.IndexOf(tabelaHash.ArrayDePrecos, preco));
            Assert.Equal(preco, tabelaHash.ArrayDePrecos[indiceEsperado]);
        }

        [Fact]
        public void DeveBuscarPrecoNoArray()
        {
            //Arrange
            var item = "Ouro Branco";
            var preco = 2.50;

            int tamanhoArray = 10;
            var tabelaHash = new TabelaHash(tamanhoArray);
            
            tabelaHash.InserirPreco(preco, item);

            //Act
            var precoObtido = tabelaHash.BuscarPreco(item);

            //Assert
            Assert.Equal(preco, precoObtido);
        }
    }
}
