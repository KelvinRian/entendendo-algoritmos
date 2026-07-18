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
            Assert.Equal(tamanhoDoArray, tabelaHash.PrecosList.Count());
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
            Assert.Equal(preco, tabelaHash.PrecosList[indiceEsperado].FirstOrDefault());
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
            int tamanhoArray = 10;
            var tabelaHash = new TabelaHash(tamanhoArray);

            var preco1 = new Preco("item1", 1);
            var preco2 = new Preco("item2", 2);
            var preco3 = new Preco("item3", 3);
            var preco4 = new Preco("item4", 4);
            var preco5 = new Preco("item5", 5);
            var preco6 = new Preco("item6", 6);
            var preco7 = new Preco("item7", 7);
            var preco8 = new Preco("item8", 8);

            tabelaHash.InserirPreco(preco1);
            tabelaHash.InserirPreco(preco2);
            tabelaHash.InserirPreco(preco3);
            tabelaHash.InserirPreco(preco4);
            tabelaHash.InserirPreco(preco5);
            tabelaHash.InserirPreco(preco6);
            tabelaHash.InserirPreco(preco7);
            
            //Act
            tabelaHash.InserirPreco(preco8);


            //Assert Tamanho do Array
            var tamanhoArrayEsperado = tamanhoArray * 2;
            Assert.Equal(tamanhoArrayEsperado, tabelaHash.PrecosList.Count());

            //Assert Indices
            uint hashDoItem1 = FuncaoHash.FNV1a(preco1.Item);
            int indiceEsperadoParaItem1 = (int)(hashDoItem1 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco1, tabelaHash.PrecosList[indiceEsperadoParaItem1].FirstOrDefault());

            uint hashDoItem2 = FuncaoHash.FNV1a(preco2.Item);
            int indiceEsperadoParaItem2 = (int)(hashDoItem2 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco2, tabelaHash.PrecosList[indiceEsperadoParaItem2].FirstOrDefault());

            uint hashDoItem3 = FuncaoHash.FNV1a(preco3.Item);
            int indiceEsperadoParaItem3 = (int)(hashDoItem3 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco3, tabelaHash.PrecosList[indiceEsperadoParaItem3].FirstOrDefault());

            uint hashDoItem4 = FuncaoHash.FNV1a(preco4.Item);
            int indiceEsperadoParaItem4 = (int)(hashDoItem4 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco4, tabelaHash.PrecosList[indiceEsperadoParaItem4].FirstOrDefault());

            uint hashDoItem5 = FuncaoHash.FNV1a(preco5.Item);
            int indiceEsperadoParaItem5 = (int)(hashDoItem5 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco5, tabelaHash.PrecosList[indiceEsperadoParaItem5].FirstOrDefault());

            uint hashDoItem6 = FuncaoHash.FNV1a(preco6.Item);
            int indiceEsperadoParaItem6 = (int)(hashDoItem6 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco6, tabelaHash.PrecosList[indiceEsperadoParaItem6].FirstOrDefault());

            uint hashDoItem7 = FuncaoHash.FNV1a(preco7.Item);
            int indiceEsperadoParaItem7 = (int)(hashDoItem7 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco7, tabelaHash.PrecosList[indiceEsperadoParaItem7].FirstOrDefault());

            uint hashDoItem8 = FuncaoHash.FNV1a(preco8.Item);
            int indiceEsperadoParaItem8 = (int)(hashDoItem8 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco8, tabelaHash.PrecosList[indiceEsperadoParaItem8].FirstOrDefault());
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
            Assert.Contains(precoBanana, tabelaHash.PrecosList[indiceEsperadoBanana]);
            Assert.Contains(precoLaranja, tabelaHash.PrecosList[indiceEsperadoLaranja]);
        }
    }
}
