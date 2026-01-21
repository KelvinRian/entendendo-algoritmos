namespace EntendendoAlgoritmos._2.OrdenacaoPorSelecao
{
    public static class OrdenacaoPorSelecao
    {
        public static List<int> OrdenarPorMaior(List<int> valores)
        {
            var listaOrdenada = new List<int>();
            var quantidadeDeElementos = valores.Count;

            for (int i = 0; i < quantidadeDeElementos; i++)
            {
                var indiceDoMaior = BuscarIndiceDoMaior(valores);
                listaOrdenada.Add(valores[indiceDoMaior]);
                valores.Remove(valores[indiceDoMaior]);
            }

            return listaOrdenada;
        }

        private static int BuscarIndiceDoMaior(List<int> valores)
        {
            var maior = valores[0];
            var indiceDoMaior = 0;
            
            for (int i = 1; i < valores.Count; i++)
            {
                if (valores[i] > maior)
                {
                    maior = valores[i];
                    indiceDoMaior = i;
                }
            }

            return indiceDoMaior;
        }
    }
}
