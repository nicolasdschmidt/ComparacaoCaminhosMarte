﻿namespace apCaminhosMarte
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRotas = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.gbMetodo = new System.Windows.Forms.GroupBox();
            this.rbDijkstra = new System.Windows.Forms.RadioButton();
            this.rbRecursao = new System.Windows.Forms.RadioButton();
            this.rbPilhas = new System.Windows.Forms.RadioButton();
            this.gbCriterio = new System.Windows.Forms.GroupBox();
            this.rbCusto = new System.Windows.Forms.RadioButton();
            this.rbTempo = new System.Windows.Forms.RadioButton();
            this.rbDistancia = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvMelhorCaminho = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbDestino = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbOrigem = new System.Windows.Forms.ListBox();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.tpArvore = new System.Windows.Forms.TabPage();
            this.pbArvore = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tpRotas.SuspendLayout();
            this.gbMetodo.SuspendLayout();
            this.gbCriterio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMelhorCaminho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.tpArvore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpRotas);
            this.tabControl1.Controls.Add(this.tpArvore);
            this.tabControl1.Location = new System.Drawing.Point(2, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1326, 569);
            this.tabControl1.TabIndex = 0;
            // 
            // tpRotas
            // 
            this.tpRotas.Controls.Add(this.label5);
            this.tpRotas.Controls.Add(this.gbMetodo);
            this.tpRotas.Controls.Add(this.gbCriterio);
            this.tpRotas.Controls.Add(this.btnBuscar);
            this.tpRotas.Controls.Add(this.dgvMelhorCaminho);
            this.tpRotas.Controls.Add(this.dgvCaminhos);
            this.tpRotas.Controls.Add(this.label4);
            this.tpRotas.Controls.Add(this.label3);
            this.tpRotas.Controls.Add(this.label2);
            this.tpRotas.Controls.Add(this.lsbDestino);
            this.tpRotas.Controls.Add(this.label1);
            this.tpRotas.Controls.Add(this.lsbOrigem);
            this.tpRotas.Controls.Add(this.pbMapa);
            this.tpRotas.Location = new System.Drawing.Point(4, 22);
            this.tpRotas.Name = "tpRotas";
            this.tpRotas.Padding = new System.Windows.Forms.Padding(3);
            this.tpRotas.Size = new System.Drawing.Size(1318, 543);
            this.tpRotas.TabIndex = 0;
            this.tpRotas.Text = "Rotas entre cidades";
            this.tpRotas.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1036, 523);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Total do menor percurso: --------";
            // 
            // gbMetodo
            // 
            this.gbMetodo.Controls.Add(this.rbDijkstra);
            this.gbMetodo.Controls.Add(this.rbRecursao);
            this.gbMetodo.Controls.Add(this.rbPilhas);
            this.gbMetodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMetodo.Location = new System.Drawing.Point(1186, 107);
            this.gbMetodo.Margin = new System.Windows.Forms.Padding(2);
            this.gbMetodo.Name = "gbMetodo";
            this.gbMetodo.Padding = new System.Windows.Forms.Padding(2);
            this.gbMetodo.Size = new System.Drawing.Size(124, 89);
            this.gbMetodo.TabIndex = 13;
            this.gbMetodo.TabStop = false;
            this.gbMetodo.Text = "Método";
            // 
            // rbDijkstra
            // 
            this.rbDijkstra.AutoSize = true;
            this.rbDijkstra.Location = new System.Drawing.Point(5, 62);
            this.rbDijkstra.Margin = new System.Windows.Forms.Padding(2);
            this.rbDijkstra.Name = "rbDijkstra";
            this.rbDijkstra.Size = new System.Drawing.Size(81, 21);
            this.rbDijkstra.TabIndex = 2;
            this.rbDijkstra.TabStop = true;
            this.rbDijkstra.Text = "Dijkstra";
            this.rbDijkstra.UseVisualStyleBackColor = true;
            // 
            // rbRecursao
            // 
            this.rbRecursao.AutoSize = true;
            this.rbRecursao.Location = new System.Drawing.Point(5, 40);
            this.rbRecursao.Margin = new System.Windows.Forms.Padding(2);
            this.rbRecursao.Name = "rbRecursao";
            this.rbRecursao.Size = new System.Drawing.Size(95, 21);
            this.rbRecursao.TabIndex = 1;
            this.rbRecursao.TabStop = true;
            this.rbRecursao.Text = "Recursão";
            this.rbRecursao.UseVisualStyleBackColor = true;
            // 
            // rbPilhas
            // 
            this.rbPilhas.AutoSize = true;
            this.rbPilhas.Location = new System.Drawing.Point(5, 18);
            this.rbPilhas.Margin = new System.Windows.Forms.Padding(2);
            this.rbPilhas.Name = "rbPilhas";
            this.rbPilhas.Size = new System.Drawing.Size(70, 21);
            this.rbPilhas.TabIndex = 0;
            this.rbPilhas.TabStop = true;
            this.rbPilhas.Text = "Pilhas";
            this.rbPilhas.UseVisualStyleBackColor = true;
            // 
            // gbCriterio
            // 
            this.gbCriterio.Controls.Add(this.rbCusto);
            this.gbCriterio.Controls.Add(this.rbTempo);
            this.gbCriterio.Controls.Add(this.rbDistancia);
            this.gbCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCriterio.Location = new System.Drawing.Point(1040, 107);
            this.gbCriterio.Margin = new System.Windows.Forms.Padding(2);
            this.gbCriterio.Name = "gbCriterio";
            this.gbCriterio.Padding = new System.Windows.Forms.Padding(2);
            this.gbCriterio.Size = new System.Drawing.Size(126, 89);
            this.gbCriterio.TabIndex = 12;
            this.gbCriterio.TabStop = false;
            this.gbCriterio.Text = "Critério";
            // 
            // rbCusto
            // 
            this.rbCusto.AutoSize = true;
            this.rbCusto.Location = new System.Drawing.Point(5, 62);
            this.rbCusto.Margin = new System.Windows.Forms.Padding(2);
            this.rbCusto.Name = "rbCusto";
            this.rbCusto.Size = new System.Drawing.Size(93, 21);
            this.rbCusto.TabIndex = 2;
            this.rbCusto.TabStop = true;
            this.rbCusto.Text = "Custo ($)";
            this.rbCusto.UseVisualStyleBackColor = true;
            // 
            // rbTempo
            // 
            this.rbTempo.AutoSize = true;
            this.rbTempo.Location = new System.Drawing.Point(5, 40);
            this.rbTempo.Margin = new System.Windows.Forms.Padding(2);
            this.rbTempo.Name = "rbTempo";
            this.rbTempo.Size = new System.Drawing.Size(75, 21);
            this.rbTempo.TabIndex = 1;
            this.rbTempo.TabStop = true;
            this.rbTempo.Text = "Tempo";
            this.rbTempo.UseVisualStyleBackColor = true;
            // 
            // rbDistancia
            // 
            this.rbDistancia.AutoSize = true;
            this.rbDistancia.Location = new System.Drawing.Point(5, 18);
            this.rbDistancia.Margin = new System.Windows.Forms.Padding(2);
            this.rbDistancia.Name = "rbDistancia";
            this.rbDistancia.Size = new System.Drawing.Size(93, 21);
            this.rbDistancia.TabIndex = 0;
            this.rbDistancia.TabStop = true;
            this.rbDistancia.Text = "Distância";
            this.rbDistancia.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(1243, 200);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(68, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // dgvMelhorCaminho
            // 
            this.dgvMelhorCaminho.AllowUserToAddRows = false;
            this.dgvMelhorCaminho.AllowUserToDeleteRows = false;
            this.dgvMelhorCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMelhorCaminho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMelhorCaminho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvMelhorCaminho.Location = new System.Drawing.Point(1037, 441);
            this.dgvMelhorCaminho.Name = "dgvMelhorCaminho";
            this.dgvMelhorCaminho.ReadOnly = true;
            this.dgvMelhorCaminho.RowHeadersWidth = 51;
            this.dgvMelhorCaminho.Size = new System.Drawing.Size(277, 71);
            this.dgvMelhorCaminho.TabIndex = 10;
            this.dgvMelhorCaminho.SelectionChanged += new System.EventHandler(this.dgvMelhorCaminho_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Cidade";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Cidade";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Cidade";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Cidade";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Cidade";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Cidade";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 75;
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.AllowUserToAddRows = false;
            this.dgvCaminhos.AllowUserToDeleteRows = false;
            this.dgvCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvCaminhos.Location = new System.Drawing.Point(1038, 235);
            this.dgvCaminhos.Name = "dgvCaminhos";
            this.dgvCaminhos.ReadOnly = true;
            this.dgvCaminhos.RowHeadersWidth = 51;
            this.dgvCaminhos.Size = new System.Drawing.Size(277, 181);
            this.dgvCaminhos.TabIndex = 9;
            this.dgvCaminhos.SelectionChanged += new System.EventHandler(this.dgvCaminhos_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cidade";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 75;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cidade";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 75;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cidade";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cidade";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 75;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Cidade";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 75;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Cidade";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 75;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1034, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Melhor caminho";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1035, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Caminhos encontrados:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1184, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destino";
            // 
            // lsbDestino
            // 
            this.lsbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbDestino.FormattingEnabled = true;
            this.lsbDestino.ItemHeight = 16;
            this.lsbDestino.Items.AddRange(new object[] {
            "  0 - Acheron          ",
            "  1 - Arena           ",
            "  2 - Arrakeen       ",
            "  3 - Bakhuysen       ",
            "  4 - Bradbury ",
            "  5 - Burroughs       ",
            "  6 - Cairo            "});
            this.lsbDestino.Location = new System.Drawing.Point(1186, 25);
            this.lsbDestino.Name = "lsbDestino";
            this.lsbDestino.Size = new System.Drawing.Size(126, 68);
            this.lsbDestino.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1038, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Origem";
            // 
            // lsbOrigem
            // 
            this.lsbOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbOrigem.FormattingEnabled = true;
            this.lsbOrigem.ItemHeight = 16;
            this.lsbOrigem.Items.AddRange(new object[] {
            "  0 - Acheron          ",
            "  1 - Arena           ",
            "  2 - Arrakeen       ",
            "  3 - Bakhuysen       ",
            "  4 - Bradbury ",
            "  5 - Burroughs       ",
            "  6 - Cairo            "});
            this.lsbOrigem.Location = new System.Drawing.Point(1038, 25);
            this.lsbOrigem.Name = "lsbOrigem";
            this.lsbOrigem.Size = new System.Drawing.Size(129, 68);
            this.lsbOrigem.TabIndex = 1;
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.Image = ((System.Drawing.Image)(resources.GetObject("pbMapa.Image")));
            this.pbMapa.Location = new System.Drawing.Point(7, 7);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(1024, 530);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 0;
            this.pbMapa.TabStop = false;
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // tpArvore
            // 
            this.tpArvore.Controls.Add(this.pbArvore);
            this.tpArvore.Location = new System.Drawing.Point(4, 22);
            this.tpArvore.Name = "tpArvore";
            this.tpArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tpArvore.Size = new System.Drawing.Size(1318, 543);
            this.tpArvore.TabIndex = 1;
            this.tpArvore.Text = "Árvore de Cidades";
            this.tpArvore.UseVisualStyleBackColor = true;
            // 
            // pbArvore
            // 
            this.pbArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbArvore.Location = new System.Drawing.Point(6, 6);
            this.pbArvore.Name = "pbArvore";
            this.pbArvore.Size = new System.Drawing.Size(1305, 531);
            this.pbArvore.TabIndex = 0;
            this.pbArvore.TabStop = false;
            this.pbArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pbArvore_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 572);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Projeto 3 - busca de caminhos entre cidades";
            this.Load += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tpRotas.ResumeLayout(false);
            this.tpRotas.PerformLayout();
            this.gbMetodo.ResumeLayout(false);
            this.gbMetodo.PerformLayout();
            this.gbCriterio.ResumeLayout(false);
            this.gbCriterio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMelhorCaminho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.tpArvore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRotas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbOrigem;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.TabPage tpArvore;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvMelhorCaminho;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox gbMetodo;
        private System.Windows.Forms.RadioButton rbDijkstra;
        private System.Windows.Forms.RadioButton rbRecursao;
        private System.Windows.Forms.RadioButton rbPilhas;
        private System.Windows.Forms.GroupBox gbCriterio;
        private System.Windows.Forms.RadioButton rbCusto;
        private System.Windows.Forms.RadioButton rbTempo;
        private System.Windows.Forms.RadioButton rbDistancia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbArvore;
    }
}

