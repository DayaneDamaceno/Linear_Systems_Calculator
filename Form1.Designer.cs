namespace Sistemas_Lineares
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
            this.gridSistema = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumVariaveis = new System.Windows.Forms.NumericUpDown();
            this.btnExemplo = new System.Windows.Forms.Button();
            this.btnCalcularSistema = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumVariaveis)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSistema
            // 
            this.gridSistema.AllowUserToAddRows = false;
            this.gridSistema.AllowUserToDeleteRows = false;
            this.gridSistema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSistema.Location = new System.Drawing.Point(21, 25);
            this.gridSistema.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridSistema.Name = "gridSistema";
            this.gridSistema.RowHeadersWidth = 51;
            this.gridSistema.RowTemplate.Height = 24;
            this.gridSistema.Size = new System.Drawing.Size(561, 236);
            this.gridSistema.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Resultado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(606, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Variaveis";
            // 
            // txtNumVariaveis
            // 
            this.txtNumVariaveis.Location = new System.Drawing.Point(608, 49);
            this.txtNumVariaveis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumVariaveis.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtNumVariaveis.Name = "txtNumVariaveis";
            this.txtNumVariaveis.Size = new System.Drawing.Size(155, 25);
            this.txtNumVariaveis.TabIndex = 3;
            this.txtNumVariaveis.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtNumVariaveis.ValueChanged += new System.EventHandler(this.txtNumVariaveis_ValueChanged);
            // 
            // btnExemplo
            // 
            this.btnExemplo.Location = new System.Drawing.Point(608, 101);
            this.btnExemplo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExemplo.Name = "btnExemplo";
            this.btnExemplo.Size = new System.Drawing.Size(154, 35);
            this.btnExemplo.TabIndex = 4;
            this.btnExemplo.Text = "Exemplo 4 variaveis";
            this.btnExemplo.UseVisualStyleBackColor = true;
            this.btnExemplo.Click += new System.EventHandler(this.btnExemplo_Click);
            // 
            // btnCalcularSistema
            // 
            this.btnCalcularSistema.Location = new System.Drawing.Point(609, 162);
            this.btnCalcularSistema.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCalcularSistema.Name = "btnCalcularSistema";
            this.btnCalcularSistema.Size = new System.Drawing.Size(154, 35);
            this.btnCalcularSistema.TabIndex = 5;
            this.btnCalcularSistema.Text = "Calcular Sistema";
            this.btnCalcularSistema.UseVisualStyleBackColor = true;
            this.btnCalcularSistema.Click += new System.EventHandler(this.btnCalcularSistema_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(608, 226);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(154, 35);
            this.btnImportar.TabIndex = 6;
            this.btnImportar.Text = "Importar e Calcular";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(21, 321);
            this.txtResultado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(742, 307);
            this.txtResultado.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 663);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnCalcularSistema);
            this.Controls.Add(this.btnExemplo);
            this.Controls.Add(this.txtNumVariaveis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridSistema);
            this.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistemas Lineares";
            ((System.ComponentModel.ISupportInitialize)(this.gridSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumVariaveis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtNumVariaveis;
        private System.Windows.Forms.Button btnExemplo;
        private System.Windows.Forms.Button btnCalcularSistema;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

