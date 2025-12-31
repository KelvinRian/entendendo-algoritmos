using EntendendoAlgoritmos._1.PesquisaBinária;

namespace EntendendoAlgoritmosTests._1.PesquisaBináriaTests
{
    public class PesquisaBinariaTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 4)]
        [InlineData(6, 5)]
        [InlineData(7, 6)]
        [InlineData(8, 7)]
        [InlineData(9, 8)]
        [InlineData(10, 9)]
        [InlineData(11, null)]
        public void DeveEncontrarItemAcimaDoMeio(int itemAPesquisar, int? posicaoNaLista)
        {
            var lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var resultado = new PesquisaBinaria().BuscarPosicaoNaLista(itemAPesquisar, lista);

            Assert.Equal(posicaoNaLista, resultado);
        }
    }
}
