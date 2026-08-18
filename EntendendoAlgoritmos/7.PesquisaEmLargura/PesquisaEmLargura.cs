using EntendendoAlgoritmos._6.Grafo;

namespace EntendendoAlgoritmos._7.PesquisaEmLargura
{
    public static class PesquisaEmLargura
    {
        public static int ObterMenorCaminhoEntre(Vertice inicio, Vertice fim, Grafo grafo)
        {
            //Cria uma fila de pesquisa onde cada elemento é uma tupla com o vértice a ser analisado
            //e a distância dele em relação ao vértice inicio.
            var filaDePesquisa = new Queue<(Vertice vertice, int distancia)>();

            //Adiciona o vértice inicial na fila de pesquisa com distância 0.
            filaDePesquisa.Enqueue((inicio, 0));

            //Uma lista com vertices verificados para não causar looping infinito na pesquisa.
            var verticesVerificados = new HashSet<Vertice>();

            //Dentro desse while a fila de pesquisa remove cada vertice que é analisado,além
            //de adicionar os vizinhos desse vertice, caso ele não seja o vértice fim.
            //Chegar à 0 significa que todos os vértices e seus vizinhos foram analisados.
            //Se após esse while não for encontrado um caminho mínimo, não existe um caminho entre os vértices inicio e fim.
            while (filaDePesquisa.Count > 0)
            {
                //Remove o primeiro elemento da fila de pesquisa
                var (vertice, distancia) = filaDePesquisa.Dequeue();

                //Se o vertice em questão já foi verificado, passa para o próximo da fila
                if (verticesVerificados.Contains(vertice))
                {
                    continue;
                }
                //Se não, continua a análise
                else
                {
                    //Adiciona o vértice à lista de vértices verificados
                    verticesVerificados.Add(vertice);

                    //Se o vértice atual for o vértice fim, retorna a distância até ele
                    //A distância é calculada no fim do while.
                    //Caso o vertice fim seja o primeiro da fila, a distância seria 0, setada no início do método,
                    //por isso não é necessário um cálculo de distância nesse momento.
                    if (vertice == fim)
                    {
                        return distancia;
                    }
                    //Se não, adiciona os vizinhos dele à fila de pesquisa
                    else
                    {
                        //Obtém os vizinhos do vértice atual a partir do grafo
                        var vizinhos = grafo.Conexoes[vertice];

                        //Adiciona os vizinhos à fila
                        foreach (var vizinho in vizinhos)
                        {
                            if (!verticesVerificados.Contains(vizinho))
                            {
                                //Aqui é onde a distância é setada.
                                //A distância do vizinho em relação ao vértice de início será a distância do vértice atual + 1
                                
                                //Exemplo: Vértice de íncio tem distância 0, seus vizinhos terão distância 1.
                                //Quando analisados esses vértices com distância 1, seus vizinhos terão distância 2 e assim por diante.
                                filaDePesquisa.Enqueue((vizinho, distancia + 1));
                            }
                        }
                    }
                }
            }

            throw new Exception($"Não existe um caminho entre {inicio.Name} e {fim.Name}.");
        }
    }
}
