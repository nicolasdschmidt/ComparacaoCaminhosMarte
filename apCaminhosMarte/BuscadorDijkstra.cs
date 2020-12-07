using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class BuscadorDijkstra
    {
        private ArvoreAVL<Cidade> arvore;
        MatrizCaminhos matrizCaminhos;
        private Caminho[,] matriz;
        private int tamanho;
        private string criterio;
        private int infinity = int.MaxValue;

        private Cidade origem, destino;

        private class No<X>
        {
            public X Info { get; set; }
            public No<X> Pai { get; set; }
            public bool Ativo { get; set; }
            public int Peso { get; set; }
        }

        public BuscadorDijkstra(ArvoreAVL<Cidade> arvore, MatrizCaminhos matriz, Cidade origem, Cidade destino, String criterio)
        {
            this.arvore = arvore;
            matrizCaminhos = new MatrizCaminhos(matriz);
            this.matriz = matrizCaminhos.Matriz;
            tamanho = matriz.Tamanho;
            this.origem = origem;
            this.destino = destino;
            this.criterio = criterio;
        }

        public List<Caminho> Solucionar()
        {
            if (criterio != "distancia" && criterio != "tempo" && criterio != "custo")
                throw new Exception("Critério inválido!");

            No<int>[] dados = new No<int>[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                No<int> dado = new No<int>();
                dado.Peso = infinity;
                dado.Ativo = false;
                dado.Info = arvore.Buscar(new Cidade(i)).Info.Id;

                dados[i] = dado;
            }

            dados[origem.Id].Peso = 0;
            dados[origem.Id].Pai = null;

            for (int count = 0; count < tamanho - 1; ++count)
            {
                int maisProx = 0;
                int min = infinity;

                for (int i = 0; i < tamanho; ++i)
                {
                    if (!dados[i].Ativo && dados[i].Peso <= min)
                    {
                        min = dados[i].Peso;
                        maisProx = i;
                    }
                }

                dados[maisProx].Ativo = true;

                for (int i = 0; i < tamanho; ++i)
                {
                    int atual = 0;
                    if (matriz[maisProx, i] != null)
                    {
                        switch (criterio)
                        {
                            case "distancia":
                                atual = matriz[maisProx, i].Distancia;
                                break;

                            case "tempo":
                                atual = matriz[maisProx, i].Tempo;
                                break;

                            case "custo":
                                atual = matriz[maisProx, i].Custo;
                                break;
                        }

                        if (!dados[i].Ativo && dados[maisProx].Peso != infinity && dados[maisProx].Peso + atual < dados[i].Peso)
                        {
                            dados[i].Peso = dados[maisProx].Peso + atual;
                            dados[i].Pai = dados[maisProx];
                        }
                    }
                }
            }

            List<Caminho> caminho = new List<Caminho>();

            No<int> noAtual = dados[destino.Id];
            while (noAtual.Pai != null)
            {
                //Caminho c = matrizCaminhos.BuscarPeloIndice(noAtual.Pai.Info, noAtual.Info);
                Caminho temp = matrizCaminhos.BuscarPeloIndice(noAtual.Pai.Info, noAtual.Info);
                Caminho c = new Caminho(arvore.Buscar(new Cidade(noAtual.Pai.Info)).Info, arvore.Buscar(new Cidade(noAtual.Info)).Info, temp.Distancia, temp.Tempo, temp.Custo);
                caminho.Add(c);
                noAtual = noAtual.Pai;
            }

            caminho.Reverse();

            return caminho;
        }
    }
}
