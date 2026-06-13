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
            var preco = new Preco("Ouro Branco", 2.50);

            int tamanhoArray = 10;
            uint hashDoItem = FuncaoHash.FNV1a(preco.Item);
            int indiceEsperado = (int)(hashDoItem % (uint)tamanhoArray);

            var tabelaHash = new TabelaHash(tamanhoArray);

            //Act
            tabelaHash.InserirPreco(preco);

            //Assert
            Assert.Equal(indiceEsperado, Array.IndexOf(tabelaHash.ArrayDePrecos, preco));
            Assert.Equal(preco, tabelaHash.ArrayDePrecos[indiceEsperado]);
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
            Assert.Equal(tamanhoArrayEsperado, tabelaHash.ArrayDePrecos.Length);

            //Assert Indices
            uint hashDoItem1 = FuncaoHash.FNV1a(preco1.Item);
            int indiceEsperadoParaItem1 = (int)(hashDoItem1 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco1, tabelaHash.ArrayDePrecos[indiceEsperadoParaItem1]);

            uint hashDoItem2 = FuncaoHash.FNV1a(preco2.Item);
            int indiceEsperadoParaItem2 = (int)(hashDoItem2 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco2, tabelaHash.ArrayDePrecos[indiceEsperadoParaItem2]);

            uint hashDoItem3 = FuncaoHash.FNV1a(preco3.Item);
            int indiceEsperadoParaItem3 = (int)(hashDoItem3 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco3, tabelaHash.ArrayDePrecos[indiceEsperadoParaItem3]);

            uint hashDoItem4 = FuncaoHash.FNV1a(preco4.Item);
            int indiceEsperadoParaItem4 = (int)(hashDoItem4 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco4, tabelaHash.ArrayDePrecos[indiceEsperadoParaItem4]);

            uint hashDoItem5 = FuncaoHash.FNV1a(preco5.Item);
            int indiceEsperadoParaItem5 = (int)(hashDoItem5 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco5, tabelaHash.ArrayDePrecos[indiceEsperadoParaItem5]);

            uint hashDoItem6 = FuncaoHash.FNV1a(preco6.Item);
            int indiceEsperadoParaItem6 = (int)(hashDoItem6 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco6, tabelaHash.ArrayDePrecos[indiceEsperadoParaItem6]);

            uint hashDoItem7 = FuncaoHash.FNV1a(preco7.Item);
            int indiceEsperadoParaItem7 = (int)(hashDoItem7 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco7, tabelaHash.ArrayDePrecos[indiceEsperadoParaItem7]);

            uint hashDoItem8 = FuncaoHash.FNV1a(preco8.Item);
            int indiceEsperadoParaItem8 = (int)(hashDoItem8 % (uint)tamanhoArrayEsperado);
            Assert.Equal(preco8, tabelaHash.ArrayDePrecos[indiceEsperadoParaItem8]);
        }
    }
}
