using EntendendoAlgoritmos._4.FuncaoHash;

namespace EntendendoAlgoritmos._5.TabelaHash
{
    public class TabelaHash
    {
        // TODO
        // Adicionar tratamento de colisão
        // Adicionar redimensionamento e re-hash
        public double[] ArrayDePrecos { get; set; }

        public TabelaHash(int tamanhoDoArray)
        {
            ArrayDePrecos = new double[tamanhoDoArray];
        }

        public void InserirPreco(double preco, string item)
        {
            int indice = ObterIndice(item);

            ArrayDePrecos[indice] = preco;
        }

        public double BuscarPreco(string item)
        {
            int indice = ObterIndice(item);

            return ArrayDePrecos[indice];
        }

        private int ObterIndice(string item)
        {
            var hash = FuncaoHash.FNV1a(item);
            var indice = (int)(hash % (uint)ArrayDePrecos.Length);
            return indice;
        }
    }
}
