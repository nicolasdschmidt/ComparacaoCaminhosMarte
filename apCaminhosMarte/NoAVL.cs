using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
// ENZO FUREGATTI SPINELLA 19168
// NICOLAS DENADAI SCHMIDT 19191
namespace apCaminhosMarte
{
    /// <summary>
    /// Classe que representa um nó da árvore binaria (ArvoreBusca)
    /// usada no programa.
    /// </summary>
    class NoAVL<Dado>
    {
        public Dado Info { get; set; }
        public int Altura { get; set; }
        public int Fator { get; set; }
        public NoAVL<Dado> Pai { get; set; }
        public NoAVL<Dado> Esquerda { get; set; }
        public NoAVL<Dado> Direita { get; set; }

        public NoAVL()
        {
            Altura = 0;
            Fator = 0;
            Pai = null;
            Esquerda = null;
            Direita = null;
        }

        public NoAVL(Dado info)
        {
            Info = info;
            Altura = 0;
            Fator = 0;
            Pai = null;
            Esquerda = null;
            Direita = null;
        }
    }
}
