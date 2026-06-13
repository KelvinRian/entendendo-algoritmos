using EntendendoAlgoritmos._4.FuncaoHash;

namespace EntendendoAlgoritmos._5.TabelaHash
{
    public class TabelaHash
    {
        // TODO
        // Adicionar tratamento de colisão
        public Preco[] ArrayDePrecos { get; set; }
        private int _quantidadeDeItens;

        public TabelaHash(int tamanhoDoArray)
        {
            ArrayDePrecos = new Preco[tamanhoDoArray];
        }

        public void InserirPreco(Preco preco)
        {
            _quantidadeDeItens++;

            var fatorDeCarga = ObterFatorDeCarga();
            if (fatorDeCarga > 0.7)
            {
                RedimensionarArrayERedistribuirItens();
            }

            int indice = ObterIndice(preco.Item, (uint)ArrayDePrecos.Length);
            ArrayDePrecos[indice] = preco;

        }

        private double ObterFatorDeCarga()
        {
            return (double)_quantidadeDeItens / ArrayDePrecos.Length;
        }

        private void RedimensionarArrayERedistribuirItens()
        {
            var novoArray = new Preco[ArrayDePrecos.Length * 2];
            foreach (var itemNoArrayAntigo in ArrayDePrecos.Where(x => x != null))
            {
                InserirNoNovoArray(novoArray, itemNoArrayAntigo);
            }

            ArrayDePrecos = novoArray;
        }

        private void InserirNoNovoArray(Preco[] novoArray, Preco itemNoArrayAntigo)
        {
            var indiceNoNovoArray = ObterIndice(itemNoArrayAntigo.Item, (uint)novoArray.Length);
            novoArray[indiceNoNovoArray] = itemNoArrayAntigo;
        }

        private int ObterIndice(string item, uint tamanhoDoArray)
        {
            var hash = FuncaoHash.FNV1a(item);
            var indice = (int)(hash % tamanhoDoArray);
            return indice;
        }

        public Preco BuscarPreco(string item)
        {
            int indice = ObterIndice(item, (uint)ArrayDePrecos.Length);

            return ArrayDePrecos[indice];
        }
    }

    public class Preco
    {
        public string Item { get; set; }
        public double Valor { get; set; }

        public Preco(string item, double valor)
        {
            Item = item;
            Valor = valor;
        }
    }
}
