namespace EntendendoAlgoritmos._6.Grafo
{
    public class Grafo
    {
        public Dictionary<Vertice, IList<Vertice>> Conexoes { get; set; }

        public Grafo(Dictionary<Vertice, IList<Vertice>> conexoes)
        {
            Conexoes = conexoes;
        }
    }

    public class Vertice
    {
        public string Name { get; set; }
    }
}