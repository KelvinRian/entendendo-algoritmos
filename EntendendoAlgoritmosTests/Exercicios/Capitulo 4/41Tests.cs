using EntendendoAlgoritmos.Exercicios.Capitulo_4;

namespace EntendendoAlgoritmosTests.Exercicios.Capitulo_4
{
    public class _41Tests
    {
        [Fact]
        public void DeveSomarLista()
        {
            // Arrange
            var arrayNumeros = new int[] { 1, 2, 3 };

            // Act
            var resultado = _41.Somar(arrayNumeros);

            // Assert
            var resultadoEsperado = 6;
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveSomarListaDeUmItem()
        {
            // Arrange
            var arrayNumeros = new int[] { 5 };

            // Act
            var resultado = _41.Somar(arrayNumeros);

            // Assert
            var resultadoEsperado = 5;
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveSomarListaVazia()
        {
            // Arrange
            var arrayNumeros = new int[] { };

            // Act
            var resultado = _41.Somar(arrayNumeros);

            // Assert
            var resultadoEsperado = 0;
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
