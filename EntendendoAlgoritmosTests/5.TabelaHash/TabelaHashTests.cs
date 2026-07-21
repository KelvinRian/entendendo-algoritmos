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
            Assert.Equal(tamanhoDoArray, tabelaHash.ListasDePrecos.Count());
        }

        [Fact]  
        public void DeveIserirPrecoNoArray()
        {
            //Arrange
            var preco = new Preco("Ouro Branco", 2.50);

            int tamanhoArray = 10;
            uint hashDoItem = FuncaoHash.FNV1a(preco.Item);
            int indiceEsperado = (int)(hashDoItem % (uint)tamanhoArray);

            var tabelaHash = new TabelaHash(tamanhoArray);

            //Act
            tabelaHash.InserirPreco(preco);

            //Assert
            Assert.Equal(preco, tabelaHash.ListasDePrecos[indiceEsperado].FirstOrDefault());
        }

        [Fact]
        public void DeveBuscarPrecoNoArray()
        {
            //Arrange
            var preco = new Preco("Ouro Branco", 2.50);

            int tamanhoArray = 10;
            var tabelaHash = new TabelaHash(tamanhoArray);
            
            tabelaHash.InserirPreco(preco);

            //Act
            var precoObtido = tabelaHash.BuscarPreco(preco.Item);

            //Assert
            Assert.Equal(preco, precoObtido);
        }

        [Fact]
        public void DeveBuscarPrecoNoArrayMesmoComColisao()
        {
            //Arrange
            var preco1 = new Preco("Banana", 2.50);
            var preco2 = new Preco("Laranja", 1.50);
            int tamanhoArray = 10;
            var tabelaHash = new TabelaHash(tamanhoArray);
            tabelaHash.InserirPreco(preco1);
            tabelaHash.InserirPreco(preco2);

            //Act
            var precoObtido1 = tabelaHash.BuscarPreco(preco1.Item);
            var precoObtido2 = tabelaHash.BuscarPreco(preco2.Item);

            //Assert
            Assert.Equal(preco1, precoObtido1);
            Assert.Equal(preco2, precoObtido2);
        }

        [Fact]
        public void DeveDobrarTamanhoDoArrayEAplicarReHashQuandoFatorDeCargoForMaiorQue07()
        {
            //Arrange
            int tamanhoArray = 2;
            var tabelaHash = new TabelaHash(tamanhoArray);

            var preco1 = new Preco("item1", 1);
            var preco2 = new Preco("item2", 2);

            tabelaHash.InserirPreco(preco1);

            //Act
            tabelaHash.InserirPreco(preco2);

            //Assert Tamanho do Array
            var tamanhoArrayEsperado = tamanhoArray * 2;
            Assert.Equal(tamanhoArrayEsperado, tabelaHash.ListasDePrecos.Count());

            //Assert Indices
            uint hashDoItem1 = FuncaoHash.FNV1a(preco1.Item);
            int indiceEsperadoParaItem1 = (int)(hashDoItem1 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco1, tabelaHash.ListasDePrecos[indiceEsperadoParaItem1].FirstOrDefault());

            uint hashDoItem2 = FuncaoHash.FNV1a(preco2.Item);
            int indiceEsperadoParaItem2 = (int)(hashDoItem2 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco2, tabelaHash.ListasDePrecos[indiceEsperadoParaItem2].FirstOrDefault());
        }

        [Fact]
        public void DeveGerarColisao()
        {
            //Arrange
            var tamanhoDoArray = 10;
            var tabelaHash = new TabelaHash(tamanhoDoArray);

            var precoBanana = new Preco("Banana", 2.50);
            var precoLaranja = new Preco("Laranja", 1.50);

            var hashBanana = FuncaoHash.FNV1a(precoBanana.Item);
            var hashLaranja = FuncaoHash.FNV1a(precoLaranja.Item);

            int indiceEsperadoBanana = (int)(hashBanana % (uint)tamanhoDoArray);
            int indiceEsperadoLaranja = (int)(hashLaranja % (uint)tamanhoDoArray);

            //Act
            tabelaHash.InserirPreco(precoBanana);
            tabelaHash.InserirPreco(precoLaranja);

            //Assert
            Assert.Equal(indiceEsperadoBanana, indiceEsperadoLaranja);
            Assert.Contains(precoBanana, tabelaHash.ListasDePrecos[indiceEsperadoBanana]);
            Assert.Contains(precoLaranja, tabelaHash.ListasDePrecos[indiceEsperadoLaranja]);
        }
    }
}
