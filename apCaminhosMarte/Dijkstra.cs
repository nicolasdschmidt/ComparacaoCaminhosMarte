using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class Dijkstra
    {
        private List<Cidade> cidades;
        private MatrizCaminhos adjMatrix;
        //private int[,] adjMatrix;
        int numVerts;

        /// DIJKSTRA
        List<Caminho> percurso;
        int infinity = int.MaxValue;
        Cidade verticeAtual;  // global usada para indicar o vértice atualmente sendo visitado
        int doInicioAteAtual; // global usada para ajustar menor caminho com Djikstra

        public Dijkstra(int numCidades, List<Cidade> cidades, MatrizCaminhos matriz)
        {
            this.cidades = cidades;
            //adjMatrix = new MatrizCaminhos(numCidades);
            adjMatrix = matriz;

            numVerts = numCidades;
            for (int j = 1; j < numCidades; j++) // zera toda a matriz
                for (int k = 1; k < numCidades; k++)
                    adjMatrix.BuscarPeloIndice(j, k).Distancia = infinity; // distância tão grande que não existe

            percurso = new List<Caminho>(numCidades);
        }
        public List<Caminho> Caminho(int inicioDoPercurso, int finalDoPercurso)
        {
            for (int j = 0; j < numVerts; j++)
                cidades[j].Visitada = false;

            cidades[inicioDoPercurso].Visitada = true;

            for (int j = 1; j < numVerts; j++)
            {
                // anotamos no vetor percurso a distância entre o inicioDoPercurso e cada vértice
                // se não há ligação direta, o valor da distância será infinity
                int tempDist = adjMatrix.BuscarPeloIndice(inicioDoPercurso, j).Distancia;
                percurso.Add(new Caminho(new Cidade(inicioDoPercurso), tempDist, 0, 0));
            }
            for (int nTree = 0; nTree < numVerts; nTree++)
            {
                // Procuramos a saída não visitada do vértice inicioDoPercurso com a menor distância
                int indiceDoMenor = ObterMenor();
                // e anotamos essa menor distância
                int distanciaMinima = percurso[indiceDoMenor].Distancia;
                // o vértice com a menor distância passa a ser o vértice atual
                // para compararmos com a distância calculada em AjustarMenorCaminho()
                verticeAtual = new Cidade(indiceDoMenor);
                doInicioAteAtual = percurso[indiceDoMenor].Distancia;
            }

            return percurso;
        }

        public int ObterMenor()
        {
            int distanciaMinima = infinity;
            int indiceDaMinima = 0;
            for (int j = 0; j < numVerts-1; j++)
                if (!(cidades[j].Visitada) && (percurso[j].Distancia < distanciaMinima))
                {
                    distanciaMinima = percurso[j].Distancia;
                    indiceDaMinima = j;
                }
            return indiceDaMinima;
        }
        public void AjustarMenorCaminho()
        {
            for (int coluna = 0; coluna < numVerts; coluna++)
                if (!cidades[coluna].Visitada) // para cada vértice ainda não visitado
                {
                    // acessamos a distância desde o vértice atual (pode ser infinity)
                    int atualAteMargem = adjMatrix.BuscarPeloIndice(verticeAtual.Id, coluna).Distancia;
                    // calculamos a distância desde inicioDoPercurso passando por vertice atual até
                    // esta saída
                    int doInicioAteMargem = doInicioAteAtual + atualAteMargem;
                    // quando encontra uma distância menor, marca o vértice a partir do
                    // qual chegamos no vértice de índice coluna, e a soma da distância
                    // percorrida para nele chegar
                    int distanciaDoCaminho = percurso[coluna].Distancia;
                    if (doInicioAteMargem < distanciaDoCaminho)
                    {
                        percurso[coluna].Destino = verticeAtual;
                        percurso[coluna].Distancia = doInicioAteMargem;
                    }
                }
        }
    }
}
