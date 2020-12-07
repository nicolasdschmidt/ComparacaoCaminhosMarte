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
        private List<int> caminho;

        private Cidade origem, destino;

        private class No<X>
        {
            public X Info { get; set; }
            public No<X> Pai { get; set; }
            public bool Ativo { get; set; }
            public bool Distancia { get; set; }
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

            int[] dist = new int[tamanho];
            bool[] ativo = new bool[tamanho];

            for (int i = 0; i < tamanho; ++i)
            {
                dist[i] = int.MaxValue;
                ativo[i] = false;
            }

            dist[origem.Id] = 0;

            for (int count = 0; count < tamanho - 1; ++count)
            {
                int maisProx = MaisProximo(dist, ativo, tamanho);
                ativo[maisProx] = true;

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

                        if (!ativo[i] && dist[maisProx] != int.MaxValue && dist[maisProx] + atual < dist[i])
                        {
                            dist[i] = dist[maisProx] + atual;
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
