using EntendendoAlgoritmos._3.Quicksort;

namespace EntendendoAlgoritmosTests._3.QuicksortTests
{
    public class QuicksortTests
    {
        [Fact]
        public void QuicksortArrayVazio()
        {
            // Arrange
            var arrayVazio = new int[] { };

            // Act
            var resultado = Quicksort.RunQuicksort(arrayVazio);

            // Assert
            Assert.Empty(resultado);
        }

        [Fact]
        public void QuicksortArrayComUmElemento()
        {
            // Arrange
            var arrayVazio = new int[] { 1 };

            // Act
            var resultado = Quicksort.RunQuicksort(arrayVazio);

            // Assert
            Assert.Equal(arrayVazio, resultado);
        }

        [Fact]
        public void QuicksortArrayComDoisElementos()
        {
            // Arrange
            var array = new int[] { 2, 1 };
            var resultadoEsperado = new int[] { 1, 2 };

            // Act
            var resultado = Quicksort.RunQuicksort(array);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void QuicksortArrayComTresElementos()
        {
            // Arrange
            var array = new int[] { 5, 2, 1, };
            var resultadoEsperado = new int[] { 1, 2, 5 };

            // Act
            var resultado = Quicksort.RunQuicksort(array);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
