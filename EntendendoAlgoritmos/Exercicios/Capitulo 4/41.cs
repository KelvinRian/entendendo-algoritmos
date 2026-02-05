namespace EntendendoAlgoritmos.Exercicios.Capitulo_4
{
    public static class _41
    {
        public static int Somar(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            else
            {
                int primeiroElemento = array[0];
                int[] arrayReduzido = array.Skip(1).ToArray();

                return primeiroElemento + Somar(arrayReduzido);
            }
        }
    }
}
