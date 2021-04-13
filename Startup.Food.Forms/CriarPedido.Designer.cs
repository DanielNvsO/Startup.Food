namespace Startup.Food.Forms
{
    partial class CriarPedido
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        /// 
        public string Pedido;

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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IngredientesGrid = new System.Windows.Forms.DataGridView();
            this.AdicionarLanche = new System.Windows.Forms.Button();
            this.LanchesGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FinalizarPedido = new System.Windows.Forms.Button();
            this.LanchesAdicionadoGrid = new System.Windows.Forms.DataGridView();
            this.LabelValorPedido = new System.Windows.Forms.Label();
            this.ValorPedido = new System.Windows.Forms.TextBox();
            this.LabelDesconto = new System.Windows.Forms.Label();
            this.ValorDesconto = new System.Windows.Forms.TextBox();
            this.LabelValorTotal = new System.Windows.Forms.Label();
            this.ValorTotal = new System.Windows.Forms.TextBox();
            this.IniciarPedido = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Tempo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LanchesGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LanchesAdicionadoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IngredientesGrid);
            this.groupBox1.Controls.Add(this.AdicionarLanche);
            this.groupBox1.Controls.Add(this.LanchesGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Escolher Lanche";
            // 
            // IngredientesGrid
            // 
            this.IngredientesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IngredientesGrid.Location = new System.Drawing.Point(405, 33);
            this.IngredientesGrid.Name = "IngredientesGrid";
            this.IngredientesGrid.Size = new System.Drawing.Size(349, 137);
            this.IngredientesGrid.TabIndex = 2;
            // 
            // AdicionarLanche
            // 
            this.AdicionarLanche.Location = new System.Drawing.Point(776, 36);
            this.AdicionarLanche.Name = "AdicionarLanche";
            this.AdicionarLanche.Size = new System.Drawing.Size(74, 44);
            this.AdicionarLanche.TabIndex = 1;
            this.AdicionarLanche.Text = "Adicionar Lanche";
            this.AdicionarLanche.UseVisualStyleBackColor = true;
            this.AdicionarLanche.Click += new System.EventHandler(this.AdicionarLanche_Click);
            // 
            // LanchesGrid
            // 
            this.LanchesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LanchesGrid.Location = new System.Drawing.Point(13, 33);
            this.LanchesGrid.Name = "LanchesGrid";
            this.LanchesGrid.ReadOnly = true;
            this.LanchesGrid.Size = new System.Drawing.Size(380, 137);
            this.LanchesGrid.TabIndex = 0;
            this.LanchesGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LanchesGrid_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FinalizarPedido);
            this.groupBox2.Controls.Add(this.LanchesAdicionadoGrid);
            this.groupBox2.Location = new System.Drawing.Point(12, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(880, 198);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lanches Escolhidos";
            // 
            // FinalizarPedido
            // 
            this.FinalizarPedido.Location = new System.Drawing.Point(776, 22);
            this.FinalizarPedido.Name = "FinalizarPedido";
            this.FinalizarPedido.Size = new System.Drawing.Size(74, 44);
            this.FinalizarPedido.TabIndex = 3;
            this.FinalizarPedido.Text = "Finalizar Pedido";
            this.FinalizarPedido.UseVisualStyleBackColor = true;
            this.FinalizarPedido.Click += new System.EventHandler(this.FinalizarPedido_Click);
            // 
            // LanchesAdicionadoGrid
            // 
            this.LanchesAdicionadoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LanchesAdicionadoGrid.Location = new System.Drawing.Point(13, 22);
            this.LanchesAdicionadoGrid.Name = "LanchesAdicionadoGrid";
            this.LanchesAdicionadoGrid.Size = new System.Drawing.Size(741, 135);
            this.LanchesAdicionadoGrid.TabIndex = 0;
            this.LanchesAdicionadoGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.LanchesAdicionadoGrid_UserDeletingRow);
            this.LanchesAdicionadoGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LanchesAdicionadoGrid_KeyDown);
            // 
            // LabelValorPedido
            // 
            this.LabelValorPedido.AutoSize = true;
            this.LabelValorPedido.Location = new System.Drawing.Point(367, 11);
            this.LabelValorPedido.Name = "LabelValorPedido";
            this.LabelValorPedido.Size = new System.Drawing.Size(67, 13);
            this.LabelValorPedido.TabIndex = 2;
            this.LabelValorPedido.Text = "Valor Pedido";
            // 
            // ValorPedido
            // 
            this.ValorPedido.Location = new System.Drawing.Point(440, 8);
            this.ValorPedido.Name = "ValorPedido";
            this.ValorPedido.ReadOnly = true;
            this.ValorPedido.Size = new System.Drawing.Size(86, 20);
            this.ValorPedido.TabIndex = 3;
            this.ValorPedido.Text = "0";
            // 
            // LabelDesconto
            // 
            this.LabelDesconto.AutoSize = true;
            this.LabelDesconto.Location = new System.Drawing.Point(535, 10);
            this.LabelDesconto.Name = "LabelDesconto";
            this.LabelDesconto.Size = new System.Drawing.Size(53, 13);
            this.LabelDesconto.TabIndex = 4;
            this.LabelDesconto.Text = "Desconto";
            // 
            // ValorDesconto
            // 
            this.ValorDesconto.Location = new System.Drawing.Point(595, 8);
            this.ValorDesconto.Name = "ValorDesconto";
            this.ValorDesconto.ReadOnly = true;
            this.ValorDesconto.Size = new System.Drawing.Size(94, 20);
            this.ValorDesconto.TabIndex = 5;
            this.ValorDesconto.Text = "0";
            // 
            // LabelValorTotal
            // 
            this.LabelValorTotal.AutoSize = true;
            this.LabelValorTotal.Location = new System.Drawing.Point(695, 11);
            this.LabelValorTotal.Name = "LabelValorTotal";
            this.LabelValorTotal.Size = new System.Drawing.Size(58, 13);
            this.LabelValorTotal.TabIndex = 6;
            this.LabelValorTotal.Text = "Valor Total";
            // 
            // ValorTotal
            // 
            this.ValorTotal.Location = new System.Drawing.Point(759, 8);
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            this.ValorTotal.Size = new System.Drawing.Size(103, 20);
            this.ValorTotal.TabIndex = 7;
            this.ValorTotal.Text = "0";
            // 
            // IniciarPedido
            // 
            this.IniciarPedido.Location = new System.Drawing.Point(25, 7);
            this.IniciarPedido.Name = "IniciarPedido";
            this.IniciarPedido.Size = new System.Drawing.Size(108, 24);
            this.IniciarPedido.TabIndex = 8;
            this.IniciarPedido.Text = "Iniciar Pedido";
            this.IniciarPedido.UseVisualStyleBackColor = true;
            this.IniciarPedido.Click += new System.EventHandler(this.IniciarPedido_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Tempo
            // 
            this.Tempo.AutoSize = true;
            this.Tempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tempo.Location = new System.Drawing.Point(150, 6);
            this.Tempo.Name = "Tempo";
            this.Tempo.Size = new System.Drawing.Size(0, 25);
            this.Tempo.TabIndex = 9;
            // 
            // CriarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 462);
            this.Controls.Add(this.Tempo);
            this.Controls.Add(this.IniciarPedido);
            this.Controls.Add(this.ValorTotal);
            this.Controls.Add(this.LabelValorTotal);
            this.Controls.Add(this.ValorDesconto);
            this.Controls.Add(this.LabelDesconto);
            this.Controls.Add(this.ValorPedido);
            this.Controls.Add(this.LabelValorPedido);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CriarPedido";
            this.Text = "Criar Pedido do Lanche";
            this.Load += new System.EventHandler(this.CriarPedido_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IngredientesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LanchesGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LanchesAdicionadoGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView IngredientesGrid;
        private System.Windows.Forms.Button AdicionarLanche;
        private System.Windows.Forms.DataGridView LanchesGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LabelValorPedido;
        private System.Windows.Forms.TextBox ValorPedido;
        private System.Windows.Forms.Label LabelDesconto;
        private System.Windows.Forms.TextBox ValorDesconto;
        private System.Windows.Forms.Label LabelValorTotal;
        private System.Windows.Forms.TextBox ValorTotal;
        private System.Windows.Forms.Button FinalizarPedido;
        private System.Windows.Forms.Button IniciarPedido;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Tempo;
        private System.Windows.Forms.DataGridView LanchesAdicionadoGrid;
    }
}

