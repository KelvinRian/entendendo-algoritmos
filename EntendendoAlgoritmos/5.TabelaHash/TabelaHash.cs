using EntendendoAlgoritmos._4.FuncaoHash;

namespace EntendendoAlgoritmos._5.TabelaHash
{
    public class TabelaHash
    {
        // TODO
        // Refatorar com Clean Code

        private List<Preco>[] _precosList;
        public IReadOnlyList<List<Preco>> PrecosList => _precosList;

        private int _quantidadeDeEspacosOcupados;

        public TabelaHash(int tamanhoDoArray)
        {
            _precosList = new List<Preco>[tamanhoDoArray];
        }

        public void InserirPreco(Preco preco)
        {
            int indice = ObterIndice(preco.Item, (uint)_precosList.Length);

            var temColisao = _precosList[indice] != null;

            if (temColisao)
            {
                _precosList[indice].Add(preco);
            }
            else
            {
                _quantidadeDeEspacosOcupados++;
                var fatorDeCarga = ObterFatorDeCarga();
                if (fatorDeCarga > 0.7)
                {
                    RedimensionarArrayERedistribuirItens();
                    InserirPreco(preco);
                }
                else
                {
                    _precosList[indice] = new List<Preco>() { preco };
                }
            }
        }

        private double ObterFatorDeCarga()
        {
            return (double)_quantidadeDeEspacosOcupados / _precosList.Length;
        }

        private void RedimensionarArrayERedistribuirItens()
        {
            var novoArray = new List<Preco>[_precosList.Length * 2];
            _quantidadeDeEspacosOcupados = 0;

            foreach (var itemNoArrayAntigo in _precosList.Where(x => x != null))
            {
                foreach (var preco in itemNoArrayAntigo)
                {
                    InserirNoNovoArray(novoArray, preco);
                }
            }

            _precosList = novoArray;
        }

        private void InserirNoNovoArray(List<Preco>[] novoArray, Preco itemNoArrayAntigo)
        {
            var indiceNoNovoArray = ObterIndice(itemNoArrayAntigo.Item, (uint)novoArray.Length);

            var temColisao = novoArray[indiceNoNovoArray] != null;
            if (temColisao)
            {
                novoArray[indiceNoNovoArray].Add(itemNoArrayAntigo);
            }
            else
            {
                novoArray[indiceNoNovoArray] = new List<Preco>() { itemNoArrayAntigo };
                _quantidadeDeEspacosOcupados++;
            }
        }

        private int ObterIndice(string item, uint tamanhoDoArray)
        {
            var hash = FuncaoHash.FNV1a(item);
            var indice = (int)(hash % tamanhoDoArray);
            return indice;
        }

        public Preco? BuscarPreco(string item)
        {
            int indice = ObterIndice(item, (uint)_precosList.Length);

            return _precosList[indice]?.FirstOrDefault(x => x.Item == item);
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
