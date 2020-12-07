using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class BuscadorDijkstra
    {
        private Caminho[,] matriz;
        private int tamanho;
        private string criterio;
        private int infinity = int.MaxValue;
        private List<int> caminho;

        private Cidade origem, destino;

        private class No<X>
        {
            public X Info { get; set; }
            public No<X> Pai { get; set; }
            public bool Ativo { get; set; }
            public int Distancia { get; set; }
        }

        public BuscadorDijkstra(MatrizCaminhos matriz, Cidade origem, Cidade destino, String criterio)
        {
            this.matriz = new MatrizCaminhos(matriz).Matriz;
            tamanho = matriz.Tamanho;
            this.origem = origem;
            this.destino = destino;
            this.criterio = criterio;
            this.caminho = new List<int>();
        }

        public void Solucionar()
        {
            if (criterio != "distancia" && criterio != "tempo" && criterio != "custo")
                throw new Exception("Critério inválido!");

            No<int>[] dados = new No<int>[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                No<int> dado = new No<int>();
                dado.Distancia = infinity;
                dado.Ativo = false;

                dados[i] = dado;
            }

            dados[origem.Id].Distancia = 0;
            dados[origem.Id].Pai = null;

            for (int count = 0; count < tamanho - 1; ++count)
            {
                int maisProx = 0;
                int min = infinity;

                for (int i = 0; i < tamanho; ++i)
                {
                    if (!dados[i].Ativo && dados[i].Distancia <= min)
                    {
                        min = dados[i].Distancia;
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

                        if (!dados[i].Ativo && dados[maisProx].Distancia != infinity && dados[maisProx].Distancia + atual < dados[i].Distancia)
                        {
                            dados[i].Distancia = dados[maisProx].Distancia + atual;
                        }
                    }
                }
            }
        }

        private int MaisProximo(int[] dist, bool[] ativo, int tamanho)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < tamanho; ++v)
            {
                if (ativo[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }
}
