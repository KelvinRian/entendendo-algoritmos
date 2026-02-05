namespace EntendendoAlgoritmos.Exercicios.Capitulo_4
{
    public static class _42
    {
        public static int ContarElementos(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            else
            {
                int[] arrayReduzido = array.Skip(1).ToArray();
                return 1 + ContarElementos(arrayReduzido);
            }
        }
    }
}
