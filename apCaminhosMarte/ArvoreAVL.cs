using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ENZO FUREGATTI SPINELLA 19168
// NICOLAS DENADAI SCHMIDT 19191

namespace apCaminhosMarte
{
    /// <summary>
    /// Classe que armazena Dados na forma de uma Árvore
    /// Binária de Busca, como pedido na proposta do projeto.
    /// </summary>
    /// <typeparam name="Dado">Tipo</typeparam>

    class ArvoreAVL<Dado> where Dado : IComparable<Dado>
    {
        public NoAVL<Dado> Raiz { get; set; }
        public int Qtd { get; set; }

        public ArvoreAVL()
        {
            Raiz = null;
            Qtd  = 0;
        }

        // método público de inclusão
        public void Incluir(Dado info)
        {
            // se a raiz for nula, definimos info como o primeiro Nó
            if (Raiz == null)
            {
                Raiz = new NoAVL<Dado>(info);
                Qtd  = 1;
            }
            // senão, chamamos a função interna recursiva Incluir e balanceamos a Árvore para cima partindo do Nó inserido
            else {
                NoAVL<Dado> no = Incluir(Raiz, info);
                BalancearAcima(no);
            }
            CalcularAlturas();
        }

        // método público de busca
        public NoAVL<Dado> Buscar(Dado info)
        {
            // chamamos a função interna recursiva Buscar
            NoAVL<Dado> encontrado = Buscar(Raiz, info);
            return encontrado;
        }

        private void BalancearAcima(NoAVL<Dado> no)
        {
            if (no == null) return;
            Balancear(no);
            if (no.Pai != null)
                BalancearAcima(no.Pai);
        }

        private void Balancear(NoAVL<Dado> no)
        {
            int fatorBalanceamento = CalcularFator(no);

            if (fatorBalanceamento < -1)
            {
                if (CalcularFator(no.Esquerda) > 0)
                {
                    RotacionarParaEsquerda(no.Esquerda);
                }
                RotacionarParaDireita(no);
            } else if (fatorBalanceamento > 1)
            {
                if (CalcularFator(no.Direita) < 0)
                {
                    RotacionarParaDireita(no.Direita);
                }
                RotacionarParaEsquerda(no);
            }
        }

        private int CalcularFator(NoAVL<Dado> no)
        {
            if (no == null) return 0;
            CalcularAlturas();
            int alturaEsq = -1;
            int alturaDir = -1;

            if (no.Esquerda != null)
                alturaEsq = no.Esquerda.Altura;

            if (no.Direita != null)
                alturaDir = no.Direita.Altura;

            return alturaDir - alturaEsq;
        }

        private void CalcularAlturas()
        {
            CalcularAlturasAux(Raiz);
        }

        private void CalcularAlturasAux(NoAVL<Dado> no)
        {
            if (no == null) return;

            if (no.Esquerda == null && no.Direita == null)
                CalcularAlturas(no);
            else
            {
                CalcularAlturasAux(no.Esquerda);
                CalcularAlturasAux(no.Direita);
            }
        }

        private void CalcularAlturas(NoAVL<Dado> no)
        {
            int alturaEsq = -1;
            int alturaDir = -1;

            if (no.Esquerda != null)
                alturaEsq = no.Esquerda.Altura;

            if (no.Direita != null)
                alturaDir = no.Direita.Altura;

            if (alturaEsq > alturaDir)
                no.Altura = alturaEsq + 1;
            else no.Altura = alturaDir + 1;

            if (no.Pai != null)
                CalcularAlturas(no.Pai);
        }

        private void RotacionarParaEsquerda(NoAVL<Dado> no)
        {
            NoAVL<Dado> direita = no.Direita;

            no.Direita = direita.Esquerda;

            if (direita.Esquerda == null)
                direita.Esquerda = new NoAVL<Dado>();
            direita.Esquerda.Pai = no;
            direita.Esquerda = no;
            direita.Pai = no.Pai;
            no.Pai = direita;

            if (no != Raiz)
            {
                if (direita.Pai.Esquerda == no)
                    direita.Pai.Esquerda = direita;
                else direita.Pai.Direita = direita;
            }
            else Raiz = direita;
        }

        private void RotacionarParaDireita(NoAVL<Dado> no)
        {
            NoAVL<Dado> esquerda = no.Esquerda;

            no.Esquerda = esquerda.Direita;
            if (esquerda.Direita == null)
                esquerda.Direita = new NoAVL<Dado>();
            esquerda.Direita.Pai = no;
            esquerda.Direita = no;
            esquerda.Pai = no.Pai;
            no.Pai = esquerda;

            if (no != Raiz)
            {
                if (esquerda.Pai.Esquerda == no)
                    esquerda.Pai.Esquerda = esquerda;
                else esquerda.Pai.Direita = esquerda;
            }
            else
                Raiz = esquerda;
        }

        // método interno de inclusão recursiva
        private NoAVL<Dado> Incluir(NoAVL<Dado> noAtual, Dado info)
        {
            // compara o valor armazenado no Nó atual com o valor que queremos armazenar
            int equals = info.CompareTo(noAtual.Info);

            // se for o mesmo
            if (equals == 0) throw new Exception("Nó já existe");

            // senão, se o nosso valor for menor que o do Nó atual, o valor deve 'ir' para a esquerda:
            if (equals < 0)
            {
                // se o Nó da esquerda for null, armazenamos lá
                if (noAtual.Esquerda == null) {
                    noAtual.Esquerda = new NoAVL<Dado>(info);
                    noAtual.Esquerda.Pai = noAtual;
                    Qtd++;
                    return noAtual.Esquerda;
                }
                // senão, chamamos o mesmo método no Nó da esquerda
                else return Incluir(noAtual.Esquerda, info);
            }
            // mas se o valor for maior do que o do Nó atual, o valor deve 'ir' para a direita:
            else
            {
                // se o Nó da direita for null, armazenamos lá
                if (noAtual.Direita == null) {
                    noAtual.Direita = new NoAVL<Dado>(info);
                    noAtual.Direita.Pai = noAtual;
                    Qtd++;
                    return noAtual.Direita;
                }
                // senão, chamamos o mesmo método no Nó da direita
                else return Incluir(noAtual.Direita, info);
            }
        }

        // método interno de busca recursiva, usado, por exemplo, para adquirir os dados completos de uma Cidade sobre a qual só sabemos o id
        private NoAVL<Dado> Buscar(NoAVL<Dado> noAtual, Dado info)
        {
            // se chegamos numa das folhas e ainda não encontramos o dado, ele não está nessa Árvore
            if (noAtual == null) throw new Exception("Dado não encontrado");

            // compara o valor armazenado no Nó atual com o valor que estamos procurando
            int equals = info.CompareTo(noAtual.Info);

            // se encontramos, retornamos o Dado
            if (equals == 0) return noAtual;

            // senão, se o nosso valor for menor que o do Nó atual, a busca continua para a esquerda:
            if (equals < 0) return Buscar(noAtual.Esquerda, info);
            // mas se o nosso valor for maior que o do Nó atual, a busca continua para a direita:
            else return Buscar(noAtual.Direita, info);
        }

    }
}
