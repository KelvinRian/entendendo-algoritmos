namespace EntendendoAlgoritmosTests._4.FuncaoHash
{
    public class FuncaoHashTests
    {
        [Fact]
        public void DeveRetornarNumeroSeguindoAlgoritmoFNV1a()
        {
            var texto = "Teste";

            //hashEsperado de "Teste" segundo o algoritmo FNV-1a é igual a 3940528416
            var hashEsperado = AlgoritmoFNV1a(texto);

            var hashObtido = EntendendoAlgoritmos._4.FuncaoHash.FuncaoHash.FNV1a(texto);

            Assert.Equal(hashEsperado, hashObtido);
        }

        private static uint AlgoritmoFNV1a(string texto)
        {
            uint hash = 2166136261;
            
            foreach (char c in texto)
            {
                hash ^= c;
                hash *= 16777619;
            }

            return hash;
        }
    }
}
