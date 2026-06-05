namespace EntendendoAlgoritmos._3.Quicksort
{
    public static class Quicksort
    {
        public static int[] RunQuicksort(int[] array)
        {
            if (array.Length < 2)
            {
                return array;
            }
            else
            {
                var pivot = array[0];
                var menores = array.Skip(1).Where(x => x <= pivot).ToArray();
                var maiores = array.Skip(1).Where(x => x > pivot).ToArray();

                return RunQuicksort(menores).Append(pivot).Concat(RunQuicksort(maiores)).ToArray();
            }
        }
    }
}
