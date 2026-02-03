namespace EntendendoAlgoritmos._0.Recursao
{
    public static class ExemploRecursao
    {
        public static int Fatorial(int numero)
        {
            if (numero <= 1)
            {
                return 1;
            }
            return numero * Fatorial(numero - 1);
        }
    }
}
