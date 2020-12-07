using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class BuscadorPilha
    {
        //private ArvoreAVL<Cidade> arvoreCidades;
        private MatrizCaminhos matrizCidades;
        private List<Caminho> passos;
        private Cidade atual;
        private List<Cidade> passou;
        private Cidade origem, destino;

        public List<List<Caminho>> Solucoes { get; }

        public BuscadorPilha(MatrizCaminhos matrizCidades, Cidade origem, Cidade destino)
        {
            this.matrizCidades = matrizCidades;
            this.origem = origem;
            this.destino = destino;
            this.passou = new List<Cidade>();

            Solucoes = new List<List<Caminho>>();
        }

        public void Solucionar()
        {
            passos = new List<Caminho>();
            //atual = arvoreCidades.Buscar(origem);
            atual = origem;

            bool aindaTemCaminhos = true;

            // enquanto o backtracking não chegou de volta ao início, continue procurando caminhos
            while (aindaTemCaminhos)
            {
                bool andou = Avancar();
                if (!andou)
                    aindaTemCaminhos = Voltar();
            }
        }

        private bool Avancar()
        {
            passou.Add(atual);
            for (int i = 0; i < matrizCidades.Tamanho; i++)
            {
                Caminho tentativa = matrizCidades.BuscarPeloIndice(atual.Id, i);
                if (tentativa != null)
                {
                    if (!atual.Equals(tentativa.Destino) && !passou.Exists(c => c.Equals(tentativa.Destino)))
                    {
                        if (tentativa.Destino.Equals(destino))
                        {
                            passos.Add(tentativa);
                            Solucoes.Add(new List<Caminho>(passos));
                            passos.Remove(tentativa);
                            return false;
                        }
                        else
                        {
                            //passou.Add(tentativa.Destino);
                            passos.Add(tentativa);
                            atual = tentativa.Destino;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool Voltar()
        {
            try
            {
                passos.RemoveAt(passos.Count - 1);
            } catch (Exception) {}

            try
            {
                passou.RemoveAt(passos.Count - 1);
            }
            catch (Exception) { }

            if (passos.Count == 0)
                return false;

            Caminho anterior = passos.Last();
            atual = anterior.Destino;
            return true;
        }

    }
}
