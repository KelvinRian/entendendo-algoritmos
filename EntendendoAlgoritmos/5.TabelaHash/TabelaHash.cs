using EntendendoAlgoritmos._4.FuncaoHash;

namespace EntendendoAlgoritmos._5.TabelaHash
{
    public class TabelaHash
    {
        private List<Preco>[] _listasDePrecos;
        public IReadOnlyList<List<Preco>> ListasDePrecos => _listasDePrecos;

        private int _quantidadeDeEspacosOcupados;

        public TabelaHash(int tamanhoDoArray)
        {
            _listasDePrecos = new List<Preco>[tamanhoDoArray];
        }

        public void InserirPreco(Preco preco)
        {
            int indice = ObterIndice(preco.Item, (uint)_listasDePrecos.Length);

            var temColisao = _listasDePrecos[indice] != null;

            if (temColisao)
            {
                _listasDePrecos[indice].Add(preco);
            }
            else
            {
                AdicionaItemEmUmEspacoVazio(preco, indice);
            }
        }

        private int ObterIndice(string item, uint tamanhoDoArray)
        {
            var hash = FuncaoHash.FNV1a(item);
            var indice = (int)(hash % tamanhoDoArray);
            return indice;
        }

        private void AdicionaItemEmUmEspacoVazio(Preco preco, int indice)
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
                _listasDePrecos[indice] = new List<Preco>() { preco };
            }
        }

        private double ObterFatorDeCarga()
        {
            return (double)_quantidadeDeEspacosOcupados / _listasDePrecos.Length;
        }

        private void RedimensionarArrayERedistribuirItens()
        {
            var novoArray = new List<Preco>[_listasDePrecos.Length * 2];
            _quantidadeDeEspacosOcupados = 0;

            foreach (var listaDePreco in _listasDePrecos.Where(x => x != null))
            {
                foreach (var preco in listaDePreco)
                {
                    InserirNoNovoArray(novoArray, preco);
                }
            }

            _listasDePrecos = novoArray;
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

        public Preco? BuscarPreco(string item)
        {
            int indice = ObterIndice(item, (uint)_listasDePrecos.Length);

            return _listasDePrecos[indice]?.FirstOrDefault(x => x.Item == item);
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
