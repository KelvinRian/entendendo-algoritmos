using EntendendoAlgoritmos._0.Recursao;

namespace EntendendoAlgoritmosTests._0.Recursao
{
    public class ExemploRecursaoTests
    {
        [Fact]
        public void DeveRetornarNoCasoBase()
        {
            var resultado = ExemploRecursao.Fatorial(1);
            var resultadoEsperado = 1;
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveRetornarFatorialChamandoCasoRecurssivo()
        {
            var resultado = ExemploRecursao.Fatorial(3);
            var resultadoEsperado = 6;
            Assert.Equal(resultadoEsperado, resultado);
        }

    }
}
