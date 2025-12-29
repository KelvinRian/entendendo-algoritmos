using EntendendoAlgoritmos._1.PesquisaBinária;

namespace EntendendoAlgoritmosTests._1.PesquisaBináriaTests
{
    public class PesquisaBinariaTests
    {
        [Fact]
        public void DeveEncontrarItemNoMeioDaLista()
        {
            var lista = new List<int> { 1, 3, 5, 7, 9 };

            var itemDoMeio = lista[2];

            var result = new PesquisaBinaria().BuscarPosicaoNaLista(itemDoMeio, lista);

            Assert.Equal(2, result);
        }

        [Fact]
        public void DeveEncontrarItemAcimaDoMeio()
        {
            var lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var item = 8;

            var result = new PesquisaBinaria().BuscarPosicaoNaLista(item, lista);

            var posicaoEsperada = lista.IndexOf(item);
            Assert.Equal(posicaoEsperada, result);
        }

        // TODO - DeveEncontrarItemAbaixoDoMeio
        // TODO - DeveEncontrarItemNaPrimeiraPosicao
        // TODO - DeveEncontrarItemNaUltimaPosicao
        // TODO - DeveRetornarNuloQuandoItemNaoExistirNaLista
    }
}
