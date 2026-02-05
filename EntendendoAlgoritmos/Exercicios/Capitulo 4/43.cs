namespace EntendendoAlgoritmos.Exercicios.Capitulo_4
{
    public static class _43
    {
        public static int? EncontrarValorMaisAlto(int[] array)
        {
            if (array.Length == 0) return 0;

            int primeiroValor = array[0];
            int[] arrayReduzido = array.Skip(1).ToArray();

            var valorMaisAlto = EncontrarValorMaisAlto(arrayReduzido);

            if (primeiroValor > valorMaisAlto)
                return primeiroValor;
            else
                return valorMaisAlto;
        }
    }
}
