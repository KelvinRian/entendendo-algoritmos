using EntendendoAlgoritmos.Exercicios.Capitulo_4;

namespace EntendendoAlgoritmosTests.Exercicios.Capitulo_4
{
    public class _42Tests
    {
        [Fact]
        public static void DeveContarElementosDaLista()
        {
            // Arrange
            var arrayNumeros = new int[] { 1, 2, 3, 4, 5 };

            // Act
            var resultado = _42.ContarElementos(arrayNumeros);
            
            // Assert
            var resultadoEsperado = 5;
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public static void DeveContarElementosDaListaVazia()
        {
            // Arrange
            var arrayNumeros = new int[] { };

            // Act
            var resultado = _42.ContarElementos(arrayNumeros);

            // Assert
            var resultadoEsperado = 0;
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
