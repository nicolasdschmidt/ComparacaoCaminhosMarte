using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ENZO FUREGATTI SPINELLA 19168
// NICOLAS DENADAI SCHMIDT 19191

namespace apCaminhosMarte
{
    public partial class Form1 : Form
    {
        private ArvoreAVL<Cidade> arvoreCidades;
        private ArvoreGrafica arvoreGrafica;
        private MatrizCaminhos matrizCidades;
        private List<List<Caminho>> todosCaminhos;
        private List<Caminho> melhorCaminho;
        private List<Caminho> caminhoSelecionado;
        private Dijkstra dijkstra;
        private List<Cidade> cidades;

        private double proporcaoX, proporcaoY;

        public Form1()
        {
            InitializeComponent();
            // DgvMelhorCaminho só pode ter uma linha
            dgvMelhorCaminho.RowCount = 1;
            // Resetar o DgvCaminhos
            dgvCaminhos.RowCount = 0;
            // Cor de fundo da demonstração da árvore
            tpArvore.BackColor = Color.LightGreen;
        }

        // Lendo os arquivosTexto e inicializando as estruturas de dados
        private void Form1_Shown(object sender, EventArgs e)
        {
            arvoreCidades = new ArvoreAVL<Cidade>();
            LerArquivoCidades("CidadesMarteOrdenado.txt");
            LerArquivoCidadesOrdenado("CidadesMarteOrdenado.txt");
            arvoreGrafica = new ArvoreGrafica(arvoreCidades);
            matrizCidades = new MatrizCaminhos(arvoreCidades.Qtd);
            LerArquivoCaminhos("CaminhosEntreCidadesMarte.txt");
            Application.DoEvents();
            pbMapa.Refresh();
            pbArvore.Refresh();
        }

        // Método para ler o CidadesMarte.txt
        private void LerArquivoCidades(string nomeArquivo)
        {
            cidades = new List<Cidade>();
            // Exceção caso o arquivo não exista - o que não ocorrerá
            if (!File.Exists(nomeArquivo))
                throw new Exception($"Arquivo {nomeArquivo} não encontrado");

            var reader = new StreamReader(nomeArquivo);

            string linhaAtual;
            while ((linhaAtual = reader.ReadLine()) != null)
            {
                var id = int.Parse(linhaAtual.Substring(0, 3).Trim()); // Espaço da string onde ta o id
                var nome = linhaAtual.Substring(3, 15).Trim(); // Espaço da string onde ta o nome
                var x = int.Parse(linhaAtual.Substring(18, 5).Trim()); // Espaço da string onde ta a coordenada X
                var y = int.Parse(linhaAtual.Substring(23, 5).Trim()); // Espaço da string onde ta a coordenada Y

                // Inclusão da cidade na árvore binária AVL
                var cidadeAtual = new Cidade(id, nome, x, y);
                cidades.Add(cidadeAtual);
                arvoreCidades.Incluir(cidadeAtual);
            }
        }

        // Método para ler o CidadesMarteOrdenado.txt e colocar nos ListBoxs
        private void LerArquivoCidadesOrdenado(string nomeArquivo)
        {
            // Exceção caso o arquivo não exista - o que não ocorrerá
            if (!File.Exists(nomeArquivo))
                throw new Exception($"Arquivo {nomeArquivo} não encontrado");

            var reader = new StreamReader(nomeArquivo);

            // Resetando os ListBoxs
            lsbOrigem.Items.Clear();
            lsbDestino.Items.Clear();

            string linhaAtual;
            while ((linhaAtual = reader.ReadLine()) != null)
            {
                var id = int.Parse(linhaAtual.Substring(0, 3).Trim()); // Espaço da string onde ta o id
                var nome = linhaAtual.Substring(3, 15).Trim(); // Espaço da string onde ta o nome

                // Adicionando o id e o nome de cada Cidade
                lsbOrigem.Items.Add(id + " - " + nome);
                lsbDestino.Items.Add(id + " - " + nome);
            }
        }

        // Método para ler o CaminhosEntreCidadesMarte.txt
        private void LerArquivoCaminhos(string nomeArquivo)
        {
            // Exceção caso o arquivo não exista - o que não ocorrerá
            if (!File.Exists(nomeArquivo))
                throw new Exception($"Arquivo {nomeArquivo} não encontrado");

            var reader = new StreamReader(nomeArquivo);

            string linhaAtual;
            while ((linhaAtual = reader.ReadLine()) != null && linhaAtual.TrimEnd() != "")
            {
                var idOrigem = int.Parse(linhaAtual.Substring(0, 3).Trim()); // Espaço da string onde ta o idOrigem
                var idDestino = int.Parse(linhaAtual.Substring(3, 3).Trim()); // Espaço da string onde ta o idDestino
                var distancia = int.Parse(linhaAtual.Substring(6, 5).Trim()); // Espaço da string onde ta a distancia
                var tempo = int.Parse(linhaAtual.Substring(11, 4).Trim()); // Espaço da string onde ta o tempo
                var custo = int.Parse(linhaAtual.Substring(15, 5).Trim()); // Espaço da string onde ta o custo

                // Inclusão do caminho
                Cidade cidadeOrigem = new Cidade(idOrigem);
                Cidade cidadeDestino = new Cidade(idDestino);
                var caminhoAtual = new Caminho(cidadeOrigem, cidadeDestino, distancia, tempo, custo);
                matrizCidades.Incluir(caminhoAtual);
            }
        }

        // Event do btnBuscar para acionar o BuscadorDeCaminhos e aplicar o Backtracking
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //dijkstra = new Dijkstra(arvoreCidades.Qtd, cidades, matrizCidades);
            // verifica se algum radio button do groupbox criterio ou metodo está checked...
            var criterioExiste = gbCriterio.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked);
            var metodoExiste = gbMetodo.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            if (criterioExiste == null)
            {
                MessageBox.Show("Nenhum Critério foi escolhido. Escolha um!", "Critério", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (metodoExiste == null)
            {
                MessageBox.Show("Nenhum método foi escolhido. Escolha um!", "Método", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // resetando os dgvs
            dgvCaminhos.Rows.Clear();
            dgvMelhorCaminho.Rows.Clear();
            dgvMelhorCaminho.RowCount = 1;
            // pegando as cidades selecionadas nos ListBoxs
            int origem = lsbOrigem.SelectedIndex;
            int destino = lsbDestino.SelectedIndex;
            // verificando se alguma cidade destino e alguma cidade origem estão selecionadas
            if (origem < 0)
            {
                MessageBox.Show("Cidade Origem não foi selecionada. Escolhe-a!", "Cidade Origem Indefinida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (destino < 0)
            {
                MessageBox.Show("Cidade Destino não foi selecionada. Escolhe-a!", "Método", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Variável para conter o critério definido pelo Usuário
            int criterio = int.MaxValue;

            var buscador = new BuscadorDeCaminhos(matrizCidades);

            todosCaminhos = new List<List<Caminho>>();

            var todosCaminhosTemp = new List<List<Caminho>>();
            // buscando os caminhos
            if (rbPilhas.Checked)
            {
                //todosCaminhosTemp = buscador.BuscarCaminhoPilhas(origem, destino);
            }
            else if(rbRecursao.Checked)
            {
                todosCaminhosTemp = buscador.BuscarCaminhoBackTracking(origem, destino);
            }
            

            if (todosCaminhosTemp == null) MessageBox.Show("Nenhum caminho encontrado!");
            else if(rbDijkstra.Checked)
            {
                //var melhorCaminho = dijkstra.Caminho(origem, destino);
                var melhorCaminho = buscador.BuscarCaminhoDijkstra(origem, destino, cidades);
                // Adicionando o melhor caminho no dgvMelhorCaminho
                dgvMelhorCaminho.ColumnCount = melhorCaminho.Count + 1;
                int k;
                for (k = 0; k < melhorCaminho.Count; k++)
                {
                    dgvMelhorCaminho.Rows[0].Cells[k].Value = melhorCaminho[k].Origem.Nome + " (" + melhorCaminho[k].Origem.Id + ")";
                }
                dgvMelhorCaminho.Rows[0].Cells[k].Value = melhorCaminho[k - 1].Destino.Nome + " (" + melhorCaminho[k - 1].Destino.Id + ")";
            }
            else
            {
                // Lógica para criar uma lista de listas, isto é, uma lista dos caminhos, que em si, é uma lista com todos as cidades em que ele passa
                foreach (List<Caminho> lista in todosCaminhosTemp)
                {
                    var listaTemp = new List<Caminho>();
                    foreach (Caminho c in lista)
                    {
                        var cidadeOrigemTemp = arvoreCidades.Buscar(c.Origem).Info;
                        var cidadeDestinoTemp = arvoreCidades.Buscar(c.Destino).Info;
                        var caminhoTemp = new Caminho(cidadeOrigemTemp, cidadeDestinoTemp, c.Distancia, c.Tempo, c.Custo);
                        listaTemp.Add(caminhoTemp);
                    }
                    todosCaminhos.Add(listaTemp);
                }

                // Variáveis e lógica para achar o menor caminho e colocar todos os caminhos no dgvCaminhos, além do melhor caminho no 
                // dgvMelhorCaminho
                melhorCaminho = null;

                int colunas = 0;
                for (int i = 0; i < todosCaminhos.Count; i++)
                {
                    // Determinando os limites de células de cada linha
                    dgvCaminhos.RowCount += 1;
                    int novasColunas = todosCaminhos[i].Count + 1;
                    if (novasColunas > colunas)
                    {
                        dgvCaminhos.ColumnCount = todosCaminhos[i].Count + 1;
                        colunas = novasColunas;
                    }

                    // Adicionando os caminhos no dgvCaminhos
                    int distanciaAtual = 0;
                    int custoAtual = 0;
                    int tempoAtual = 0;
                    int j;
                    for (j = 0; j < todosCaminhos[i].Count; j++)
                    {
                        distanciaAtual += todosCaminhos[i][j].Distancia;
                        custoAtual += todosCaminhos[i][j].Custo;
                        tempoAtual += todosCaminhos[i][j].Tempo;

                        dgvCaminhos.Rows[i].Cells[j].Value = todosCaminhos[i][j].Origem.Nome + " (" + todosCaminhos[i][j].Origem.Id + ")";
                    }
                    dgvCaminhos.Rows[i].Cells[j].Value = todosCaminhos[i][j - 1].Destino.Nome + " (" + todosCaminhos[i][j - 1].Destino.Id + ")";

                    // Definindo o melhorCaminho através da menor critério
                    if(rbDistancia.Checked)
                    {
                        if (distanciaAtual < criterio || distanciaAtual < 0)
                        {
                            criterio = distanciaAtual;
                            melhorCaminho = todosCaminhos[i];
                        }
                    }
                    else if(rbCusto.Checked)
                    {
                        if (custoAtual < criterio || custoAtual < 0)
                        {
                            criterio = custoAtual;
                            melhorCaminho = todosCaminhos[i];
                        }
                    }
                    else
                    {
                        if (tempoAtual < criterio || tempoAtual < 0)
                        {
                            criterio = tempoAtual;
                            melhorCaminho = todosCaminhos[i];
                        }
                    }
                }

                // Adicionando o melhor caminho no dgvMelhorCaminho
                dgvMelhorCaminho.ColumnCount = melhorCaminho.Count + 1;
                int k;
                for (k = 0; k < melhorCaminho.Count; k++)
                {
                    dgvMelhorCaminho.Rows[0].Cells[k].Value = melhorCaminho[k].Origem.Nome + " (" + melhorCaminho[k].Origem.Id + ")";
                }
                dgvMelhorCaminho.Rows[0].Cells[k].Value = melhorCaminho[k - 1].Destino.Nome + " (" + melhorCaminho[k - 1].Destino.Id + ")";
            }
            caminhoSelecionado = melhorCaminho;
        }

        // Método para pintar
        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            if (arvoreCidades == null) return;

            var larguraOriginal = 4096;
            var alturaOriginal = 2048;

            var largura = pbMapa.Width;
            var altura = pbMapa.Height;

            // Fazendo a proporção
            proporcaoX = (double)largura / larguraOriginal;
            proporcaoY = (double)altura / alturaOriginal;

            // Desenhando os caminhos e as cidades no pbMapa
            arvoreGrafica.DesenharCaminhos(matrizCidades, e.Graphics, pbMapa, proporcaoX, proporcaoY);
            arvoreGrafica.DesenharCidades(e.Graphics, pbMapa, proporcaoX, proporcaoY);

            // Destacando o caminho selecionado em qualquer dgv
            if (caminhoSelecionado != null)
                arvoreGrafica.DesenharCaminho(caminhoSelecionado, e.Graphics, pbArvore, proporcaoX, proporcaoY);
        }

        // Evento paint do pb da árvore binária
        private void pbArvore_Paint(object sender, PaintEventArgs e)
        {
            // Se for nula não fazer nada
            if (arvoreCidades == null) return;
            // Desenhando a árvore em si
            arvoreGrafica.DesenharArvore(true, e.Graphics, pbArvore.Width / 2, 0, Math.PI / 2, Math.PI / 2.2, 300);
        }

        // Disparando o evento quando o melhorCaminho é selecionado para destacá-lo, dando um refresh no pbMapa
        private void dgvMelhorCaminho_SelectionChanged(object sender, EventArgs e)
        {
            if (todosCaminhos == null) return;
            try
            {
                // Mudando o caminhoSelecionado para o melhor caminho
                caminhoSelecionado = melhorCaminho;
                pbMapa.Refresh();
            }
            catch (Exception) { }
        }

        private void rbDistancia_Click(object sender, EventArgs e)
        {

        }

        private void rbTempo_Click(object sender, EventArgs e)
        {

        }

        private void rbCusto_Click(object sender, EventArgs e)
        {

        }

        // Disparando o evento quando algum caminho do dgvCaminhos é selecionado para destacá-lo, dando um refresh no pbMapa
        private void dgvCaminhos_SelectionChanged(object sender, EventArgs e)
        {
            if (todosCaminhos == null) return;
            try
            {
                // Buscando através do indice selecionado do dgvCaminhos, que é o mesmo índice da lista de listas todosCaminhos
                caminhoSelecionado = todosCaminhos[dgvCaminhos.CurrentCell.RowIndex];
                pbMapa.Refresh();
            }
            catch (Exception) { }
        }
    }
}
;