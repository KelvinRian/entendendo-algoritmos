namespace EntendendoAlgoritmos._8.AlgoritmoDeDijkstra
{
    public static class AlgoritmoDeDijkstra
    {
        public static int Executar(Dictionary<Vertice, List<Vizinho>> grafo, Vertice inicio, Vertice fim)
        {
            var pesos = new Dictionary<Vertice, int>();
            var pais = new Dictionary<Vertice, Vertice>();
            var processados = new HashSet<Vertice>();

            //Preenche tabelas com valores iniciais com base no vértice de início
            ConfiguracaoInicial(grafo, inicio, pesos, pais);
            
            //Obtém da lista de pesos o vértice com o menor peso
            var verticeComMenorPeso = ObterVerticeComMenorPeso(pesos, processados);
            //Se for nulo, quer dizer que todos os vértices foram processados
            while (verticeComMenorPeso != null)
            {
                //peso do vértice em processamento
                var peso = pesos[verticeComMenorPeso];
                //vizinhos do vértice em processamento
                var vizinhos = grafo[verticeComMenorPeso];

                foreach (var vizinho in vizinhos)
                {
                    //Peso para chegar ao vizinho
                    var novoPeso = peso + vizinho.Peso;
                    //Se o peso novo for menor que o peso atual
                    if (novoPeso < pesos[vizinho.Vertice])
                    {
                        //Atualiza a tabela de pesos com o novo peso
                        pesos[vizinho.Vertice] = novoPeso;
                        //e a tabela de pais, atualizando o caminho para chegar a esse vértice com o menor peso possível
                        pais[vizinho.Vertice] = verticeComMenorPeso;
                    }

                }
                //Adiciona vértice atual à lista de processados
                processados.Add(verticeComMenorPeso);
            }

            //Retorna peso para chegar ao fim
            return pesos[fim];
        }

        private static void ConfiguracaoInicial(Dictionary<Vertice, List<Vizinho>> grafo, Vertice inicio, Dictionary<Vertice, int> pesos, Dictionary<Vertice, Vertice> pais)
        {
            foreach (var vertice in grafo.Keys)
            {
                pesos[vertice] = int.MaxValue;
            }

            foreach (var vizinho in grafo[inicio])
            {
                pesos[vizinho.Vertice] = vizinho.Peso;
                pais[vizinho.Vertice] = inicio;
            }
        }

        private static Vertice? ObterVerticeComMenorPeso(Dictionary<Vertice, int> pesos, HashSet<Vertice> processados)
        {
            var menorPeso = int.MaxValue;
            Vertice verticeComMenorPeso = null;

            foreach (var peso in pesos)
            {
                if (peso.Value < menorPeso && !processados.Contains(peso.Key))
                {
                    menorPeso = peso.Value;
                    verticeComMenorPeso = peso.Key;
                }
            }

            return verticeComMenorPeso;
        }
    }

    public class Vertice
    {
        public string Name { get; set; }
    }

    public class Vizinho
    {
        public Vertice Vertice { get; set; }
        public int Peso { get; set; }
    }
}
