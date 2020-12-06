using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ENZO FUREGATTI SPINELLA 19168
// NICOLAS DENADAI SCHMIDT 19191
namespace apCaminhosMarte
{
    /// <summary>
    /// Classe que utiliza da técnica do backtracking recursivo
    /// para encontrar Caminhos entre as Cidades
    /// </summary>
    class BuscadorDeCaminhos
    {
        private MatrizCaminhos Matriz { get; set; }
        private List<List<Caminho>> todosCaminhos;
        private List<int> jaVisitados;

        private List<Cidade> verticesCidades;
        private List<Caminho> percursoCaminhos;
        private int criterioDoInicioAteOAtual;

        public BuscadorDeCaminhos(MatrizCaminhos matriz)
        {
            Matriz = matriz;
            criterioDoInicioAteOAtual = 0;
        }

        public List<List<Caminho>> BuscarCaminhoBackTracking(int idOrigem, int idDestino)
        {
            // inicializar as listas necessárias para execução
            todosCaminhos = new List<List<Caminho>>();
            jaVisitados = new List<int>();

            // como estamos na cidade de origem, adicioná-la à lista de cidades visitadas
            jaVisitados.Add(idOrigem);

            // chamar o método interno BuscarCaminho(), passando uma lista de Caminhos vazia para representar o conjunto de Caminhos atual
            BuscarCaminhoBackTracking(new List<Caminho>(), idOrigem, idDestino);

            // se não há caminhos entre as cidades selecionadas, retorna null
            if (todosCaminhos.Count() == 0) return null;

            // senão, retorna os caminhos
            return todosCaminhos;
        }

        public List<List<Caminho>> BuscarCaminhoPilha(int idOrigem, int idDestino)
        {
            // inicializar as listas necessárias para execução
            todosCaminhos = new List<List<Caminho>>();
            jaVisitados = new List<int>();

            // como estamos na cidade de origem, adicioná-la à lista de cidades visitadas
            jaVisitados.Add(idOrigem);

            // chamar o método interno BuscarCaminho(), passando uma lista de Caminhos vazia para representar o conjunto de Caminhos atual
            //BuscaCaminhoPilha(new List<Caminho>(), idOrigem, idDestino);

            // se não há caminhos entre as cidades selecionadas, retorna null
            if (todosCaminhos.Count() == 0) return null;

            // senão, retorna os caminhos
            return todosCaminhos;
        }

        public List<Caminho> BuscarCaminhoDijkstra(int idOrigem, int idDestino, List<Cidade> cidades)
        {
            // inicializar as listas necessárias para execução
            List<Caminho> melhorCaminhoDijkstra = new List<Caminho>();
            jaVisitados = new List<int>();

            // como estamos na cidade de origem, adicioná-la à lista de cidades visitadas
            jaVisitados.Add(idOrigem);

            // chamar o método interno BuscarCaminho(), passando uma lista de Caminhos vazia para representar o conjunto de Caminhos atual
            BuscarCaminhoDijkstra(new List<Caminho>(), idOrigem, idDestino, cidades);

            // se não há caminhos entre as cidades selecionadas, retorna null
            if (todosCaminhos.Count() == 0) return null;

            // senão, retorna os caminhos
            return melhorCaminhoDijkstra;
        }

        private void BuscarCaminhoBackTracking(List<Caminho> caminhoAtual, int cidadeAtual, int cidadeDestino)
        {
            // para todas as cidades que existem,
            for(int i = 0; i < Matriz.Tamanho; i++)
            {
                // gerar um caminho entre a cidade atual e a nova cidade
                Caminho caminhoTeste = Matriz.BuscarPeloIndice(cidadeAtual, i);
                // se esse caminho existir e não fomos pra essa cidade nesse 'braço' da execução,
                if (caminhoTeste != null && caminhoTeste.Distancia > 0 && !jaVisitados.Any(item => item == i))
                {
                    // vamos para a nova cidade, e a adicionamos ao caminho atual
                    caminhoAtual.Add(caminhoTeste);

                    // se chegamos no destino do usuário, salvamos um clone do caminho atual como um dos caminhos possíveis
                    if (i == cidadeDestino)
                        todosCaminhos.Add(caminhoAtual.Select(c => c.Clone()).ToList());
                    else
                    {
                        // senão, usamos recursão:
                        // adicionamos a cidade atual à lista de visitadas
                        jaVisitados.Add(i);
                        // chamamos o mesmo método, passando o caminho atual e começando da cidade em que estamos
                        BuscarCaminhoBackTracking(caminhoAtual, i, cidadeDestino);
                        /* ao finalizar o método, significa que todas as cidades de 'níveis' mais distantes do que essa
                         * ja foram verificadas, então podemos removê-la da lista de cidades visitadas, para que outras
                         * iterações do backtracking possam passar por ela
                         */
                        jaVisitados.Remove(i);
                    }
                    // no fim, temos que remover a ultima etapa do caminho atual, seguindo a lógica de backtracking
                    //caminhoAtual.RemoveAt(caminhoAtual.Count - 1);
                }
            }
        }

        private void BuscarCaminhoDijkstra(List<Caminho> caminhoAtual, int inicioDoPercurso, int finalDoPercurso, List<Cidade> cidades)
        {
            verticesCidades = cidades;
            percursoCaminhos = new List<Caminho>(verticesCidades.Count);
            int numVertices = verticesCidades.Count;
            Cidade verticeAtual;
            List<Caminho> melhorCaminho = new List<Caminho>();
            for (int j = 0; j < numVertices; j++)
                verticesCidades[j].Visitada = false;

            verticesCidades[inicioDoPercurso].Visitada = true;
            for (int j = 0; j < numVertices; j++)
            {
                // anotamos no vetor percurso a distância entre o inicioDoPercurso e cada vértice
                // se não há ligação direta, o valor da distância será infinity
                var arestaAtual = Matriz.BuscarPeloIndice(inicioDoPercurso, j);
                if (arestaAtual != null)
                {
                    int distancia = arestaAtual.Distancia;
                    int custo = arestaAtual.Custo;
                    int tempo = arestaAtual.Tempo;
                    percursoCaminhos.Add(new Caminho(new Cidade(inicioDoPercurso), new Cidade(j), distancia, custo, tempo));
                }
                else
                {
                    percursoCaminhos.Add(new Caminho(int.MaxValue, int.MaxValue, int.MaxValue));
                }
            }
            for (int nTree = 0; nTree < numVertices; nTree++)
            {
                // Procuramos a saída não visitada do vértice inicioDoPercurso com a menor distância
                int indiceDoMenor = ObterMenor(true, false, false, numVertices);
                // e anotamos essa menor distância
                int distanciaMinima = percursoCaminhos[indiceDoMenor].Distancia;
                int custoMinimo = percursoCaminhos[indiceDoMenor].Custo;
                int tempoMinimo = percursoCaminhos[indiceDoMenor].Tempo;
                // o vértice com a menor distância passa a ser o vértice atual
                // para compararmos com a distância calculada em AjustarMenorCaminho()
                verticeAtual = new Cidade(indiceDoMenor);
                criterioDoInicioAteOAtual = percursoCaminhos[indiceDoMenor].Distancia;
                melhorCaminho.Add(percursoCaminhos[indiceDoMenor].Clone());
                // visitamos o vértice com a menor distância desde o inicioDoPercurso
                verticesCidades[verticeAtual.Id].Visitada = true;
                AjustarMenorCaminho(numVertices, verticeAtual);
            }
            //return melhorCaminho;
        }
        private int ObterMenor(bool criterioDistancia, bool criterioCusto, bool criterioTempo, int numVerts)
        {
            int criterioMinimo = int.MaxValue;
            int indiceDaMinima = 0;
            if (criterioDistancia)
            {
                for (int j = 0; j < numVerts; j++)
                    if (!(verticesCidades[j].Visitada) && (percursoCaminhos[j].Distancia < criterioMinimo))
                    {
                        criterioMinimo = percursoCaminhos[j].Distancia;
                        indiceDaMinima = j;
                    }
            }
            else if (criterioCusto)
            {
                for (int j = 0; j < numVerts; j++)
                    if (!(verticesCidades[j].Visitada) && (percursoCaminhos[j].Custo < criterioMinimo))
                    {
                        criterioMinimo = percursoCaminhos[j].Custo;
                        indiceDaMinima = j;
                    }
            }
            else if(criterioTempo)
            {
                for (int j = 0; j < numVerts; j++)
                    if (!(verticesCidades[j].Visitada) && (percursoCaminhos[j].Tempo < criterioMinimo))
                    {
                        criterioMinimo = percursoCaminhos[j].Tempo;
                        indiceDaMinima = j;
                    }
            }
            return indiceDaMinima;
        }

        private void AjustarMenorCaminho(int numVerts, Cidade verticeAtual)
        {
            for (int coluna = 0; coluna < numVerts; coluna++)
                if (!verticesCidades[coluna].Visitada) // para cada vértice ainda não visitado
                {
                    // acessamos a distância desde o vértice atual (pode ser infinity)
                    var atualAteMargem = Matriz.BuscarPeloIndice(verticeAtual.Id, coluna);
                    if (atualAteMargem != null)
                    {
                        int distanciaAtualAteMargem = atualAteMargem.Distancia;
                        // calculamos a distância desde inicioDoPercurso passando por vertice atual até
                        // esta saída
                        int doInicioAteMargem = criterioDoInicioAteOAtual + distanciaAtualAteMargem;
                        // quando encontra uma distância menor, marca o vértice a partir do
                        // qual chegamos no vértice de índice coluna, e a soma da distância
                        // percorrida para nele chegar
                        int distanciaDoCaminho = percursoCaminhos[coluna].Distancia;
                        if (doInicioAteMargem < distanciaDoCaminho)
                        {
                            percursoCaminhos[coluna].Origem = verticeAtual;
                            percursoCaminhos[coluna].Distancia = doInicioAteMargem;
                        }
                    }
                }
        }

    }
}
