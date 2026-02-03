namespace EntendendoAlgoritmos._0.Recurssao
{
    public static class ExemploRecurssao
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
