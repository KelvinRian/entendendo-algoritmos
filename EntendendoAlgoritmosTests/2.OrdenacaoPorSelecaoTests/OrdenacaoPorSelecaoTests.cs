using EntendendoAlgoritmos._2.OrdenacaoPorSelecao;

namespace EntendendoAlgoritmosTests._2.OrdenacaoPorSelecaoTests
{
    public class OrdenacaoPorSelecaoTests
    {
        [Fact]
        public void DeveOrdenarPorMaior()
        {
            // Arrange
            var valores = new List<int> { 5, 3, 8, 1, 2 };
            var resultadoEsperado = new List<int> { 8, 5, 3, 2, 1 };

            // Act
            var resultado = OrdenacaoPorSelecao.OrdenarPorMaior(valores);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
