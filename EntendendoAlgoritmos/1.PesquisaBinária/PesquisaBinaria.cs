namespace EntendendoAlgoritmos._1.PesquisaBinária
{
    public class PesquisaBinaria
    {
        public int? BuscarPosicaoNaLista(int item, List<int> lista)
        {
            var itemNaPrimeiraPosicao = lista[0];
            var itemNaUltimaPosicao = lista[lista.Count - 1];
            var itemNoMeio = lista[lista.Count / 2];

            if (item == itemNoMeio)
            {
                return lista.IndexOf(itemNoMeio);
            }

            if (item > itemNoMeio)
            {
                // TODO
            }

            return null;
        }
    }
}
