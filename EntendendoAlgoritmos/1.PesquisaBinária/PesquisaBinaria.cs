namespace EntendendoAlgoritmos._1.PesquisaBinária
{
    public class PesquisaBinaria
    {
        public int? BuscarPosicaoNaLista(int item, List<int> lista)
        {
            var primeiraPosicao = 0;
            var ultimaPosicao = lista.Count - 1;

            while (primeiraPosicao <= ultimaPosicao)
            {
                var posicaoDoMeio = (primeiraPosicao + ultimaPosicao) / 2;
                var itemDoMeio = lista[posicaoDoMeio];

                if (itemDoMeio == item)
                    return posicaoDoMeio;

                if (itemDoMeio > item)
                    ultimaPosicao = posicaoDoMeio - 1;
                else
                    primeiraPosicao = posicaoDoMeio + 1;
            };

            return null;
        }
    }
}
