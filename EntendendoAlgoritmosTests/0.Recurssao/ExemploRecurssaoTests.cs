using EntendendoAlgoritmos._0.Recurssao;

namespace EntendendoAlgoritmosTests._0.Recurssao
{
    public class ExemploRecurssaoTests
    {
        [Fact]
        public void DeveRetornarNoCasoBase()
        {
            var resultado = ExemploRecurssao.Fatorial(1);
            var resultadoEsperado = 1;
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveRetornarFatorialChamandoCasoRecurssivo()
        {
            var resultado = ExemploRecurssao.Fatorial(3);
            var resultadoEsperado = 6;
            Assert.Equal(resultadoEsperado, resultado);
        }

    }
}
