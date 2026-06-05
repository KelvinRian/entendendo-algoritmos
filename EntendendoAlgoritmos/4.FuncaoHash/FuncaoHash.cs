namespace EntendendoAlgoritmos._4.FuncaoHash
{
    public static class FuncaoHash
    {
        /// <summary>
        /// FNV-1a (Fowler-Noll-Vo) é um algoritmo conhecido de hash rápido e simples
        /// que converte uma sequência de caracteres em um valor numérico,
        /// buscando distribuir os resultados de forma uniforme e reduzir colisões.
        /// PS: É case sensitive, ou seja, "Teste" e "teste" gerarão hashes diferentes.
        /// </summary>
        public static uint FNV1a(string texto)
        {
            //Offset Basis; Valor inicial do Hash
            uint hash = 2166136261;

            //Percorre cada caractere do texto, aplicando operações de XOR e multiplicação
            foreach (char c in texto)
            {
                // Pega o unicode do caractere atual e faz um XOR com o hash atual,
                // misturando os bits dos dois e gerando um novo valor para o hash
                hash ^= c;

                // Multiplica o hash para que pequenas mudanças no texto resultem em grandes mudanças no hash
                hash *= 16777619;
            }

            return hash;
        }
    }
}
