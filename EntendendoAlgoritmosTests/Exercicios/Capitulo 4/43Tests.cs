using EntendendoAlgoritmos.Exercicios.Capitulo_4;

namespace EntendendoAlgoritmosTests.Exercicios.Capitulo_4
{
    public class _43Tests
    {
        [Fact]
        public void DeveRetornarCasoBase()
        {
            // Arrange
            var arrayVazio = new int[] { };

            // Act
            var resultado = _43.EncontrarValorMaisAlto(arrayVazio);

            // Assert
            Assert.Equal(0, resultado);
        }

        [Fact]
        public void DeveRetornarValorMaisAlto()
        {
            // Arrange
            var arrayNumeros = new int[] { 1, 5, 3, 9, 2 };

            // Act
            var resultado = _43.EncontrarValorMaisAlto(arrayNumeros);

            // Assert
            var resultadoEsperado = 9;
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
