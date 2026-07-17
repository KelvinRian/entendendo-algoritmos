using EntendendoAlgoritmos._4.FuncaoHash;

namespace EntendendoAlgoritmos._5.TabelaHash
{
    public class TabelaHash
    {
        // TODO
        // Adicionar tratamento de colisão
        // Adequar, Busca e Redimensionamento do Array

        public List<Preco>[] ArrayPrecosList { get; set; }
        private int _quantidadeDeItens;

        public TabelaHash(int tamanhoDoArray)
        {
            ArrayPrecosList = new List<Preco>[tamanhoDoArray];
        }

        public void InserirPreco(Preco preco)
        {
            // TODO
            // Com colisões, a quantidade não aumenta todo vez que um item é adicionado, mas sim toda vez que um item é adicionado sem colisões.
            _quantidadeDeItens++;

            var fatorDeCarga = ObterFatorDeCarga();
            if (fatorDeCarga > 0.7)
            {
                RedimensionarArrayERedistribuirItens();
            }

            int indice = ObterIndice(preco.Item, (uint)ArrayPrecosList.Length);

            if (ArrayPrecosList[indice] != null)
                ArrayPrecosList[indice].Add(preco);
            else
                ArrayPrecosList[indice] = new List<Preco>() { preco };
        }

        private double ObterFatorDeCarga()
        {
            return (double)_quantidadeDeItens / ArrayPrecosList.Length;
        }

        private void RedimensionarArrayERedistribuirItens()
        {
            //var novoArray = new Preco[ArrayPrecosList.Length * 2];
            //foreach (var itemNoArrayAntigo in ArrayPrecosList.Where(x => x != null))
            //{
            //    InserirNoNovoArray(novoArray, itemNoArrayAntigo);
            //}

            //ArrayPrecosList = novoArray;
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
            int indice = ObterIndice(item, (uint)ArrayPrecosList.Length);

            return ArrayPrecosList[indice]?.FirstOrDefault();
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
