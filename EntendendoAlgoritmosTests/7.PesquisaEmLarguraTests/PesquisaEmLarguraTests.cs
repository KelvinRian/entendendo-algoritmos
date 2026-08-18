using EntendendoAlgoritmos._6.Grafo;
using EntendendoAlgoritmos._7.PesquisaEmLargura;

namespace EntendendoAlgoritmosTests._7.PesquisaEmLarguraTests
{
    public class PesquisaEmLarguraTests
    {
        [Fact]
        public void DeveObterMenorCaminhoEntreDoisVerticesDeUmGrafo()
        {
            //Visualização do grafo implementado
            // A - B - D
            //     |   |
            //     C - E
            var a = new Vertice { Name = "A" };
            var b = new Vertice { Name = "B" };
            var c = new Vertice { Name = "C" };
            var d = new Vertice { Name = "D" };
            var e = new Vertice { Name = "E" };
            var conexoes = new Dictionary<Vertice, IList<Vertice>>
            {
                { a, new List<Vertice> { b } },
                { b, new List<Vertice> { a, c, d } },
                { c, new List<Vertice> { b, e } },
                { d, new List<Vertice> { b, e } },
                { e, new List<Vertice> { c, d } }
            };

            var grafo = new Grafo(conexoes);
            
            var menorCaminho = PesquisaEmLargura.ObterMenorCaminhoEntre(a, d, grafo);
            Assert.Equal(2, menorCaminho);
        }

        [Fact]
        public void DeveObterMenorCaminhoQuandoVerticeDeIncioEFimForemOMesmo()
        {
            //Visualização do grafo implementado
            // A
            var a = new Vertice { Name = "A" };
            var conexoes = new Dictionary<Vertice, IList<Vertice>>
            {
                { a, new List<Vertice>() },
            };

            var grafo = new Grafo(conexoes);

            var menorCaminho = PesquisaEmLargura.ObterMenorCaminhoEntre(a, a, grafo);
            Assert.Equal(0, menorCaminho);
        }

        [Fact]
        public void DeveObterExceptionQuandoNaoHaCaminho()
        {
            //Visualização do grafo implementado
            // A - B
            //     C 
            var a = new Vertice { Name = "A" };
            var b = new Vertice { Name = "B" };
            var c = new Vertice { Name = "C" };
            var conexoes = new Dictionary<Vertice, IList<Vertice>>
            {
                { a, new List<Vertice> { b } },
                { b, new List<Vertice> { a } },
                { c, new List<Vertice>() },
            };

            var grafo = new Grafo(conexoes);

            var exception = Assert.Throws<Exception>(() =>
                PesquisaEmLargura.ObterMenorCaminhoEntre(a, c, grafo)
            );

            Assert.Equal("Não existe um caminho entre A e C.", exception.Message);
        }
    }
}
