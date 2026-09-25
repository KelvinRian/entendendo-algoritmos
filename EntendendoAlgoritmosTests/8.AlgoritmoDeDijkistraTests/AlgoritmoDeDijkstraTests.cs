using EntendendoAlgoritmos._8.AlgoritmoDeDijkstra;

namespace EntendendoAlgoritmosTests._8.AlgoritmoDeDijkistraTests
{
    public class AlgoritmoDeDijkstraTests
    {
        [Fact]
        public void Deve_Obter_MenorCaminho()
        {
            //Grafo
            // A -5- > B -3- > D 
            // |       ^ 
            // 2       |
            // |       |
            // v       |  
            // C -1-----

            // Arrange
            var verticeA = new Vertice("A");
            var verticeB = new Vertice("B");
            var verticeC = new Vertice("C");
            var verticeD = new Vertice("D");
            var grafo = new Dictionary<Vertice, List<Vizinho>>();

            grafo[verticeA] = new List<Vizinho>
            {
                new Vizinho(verticeB, 5),
                new Vizinho(verticeC, 2)
            };

            grafo[verticeB] = new List<Vizinho>
            {
                new Vizinho(verticeD, 3)
            };

            grafo[verticeC] = new List<Vizinho>
            {
                new Vizinho(verticeB, 1)
            };

            grafo[verticeD] = new List<Vizinho>();

            // Act
            var result = AlgoritmoDeDijkstra.Executar(grafo, verticeA, verticeD);

            // Assert
            Assert.Equal(6, result); // O menor caminho de A para D é A -> C -> B -> D com peso 2 + 1 + 3 = 6
        }
    }
}
