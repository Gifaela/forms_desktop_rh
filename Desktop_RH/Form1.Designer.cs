namespace Desktop_RH
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            txtURI = new System.Windows.Forms.TextBox();
            dgvDados = new System.Windows.Forms.DataGridView();
            btnObterFuncionario = new System.Windows.Forms.Button();
            btnFuncionarioPorId = new System.Windows.Forms.Button();
            btnIncluirFuncionario = new System.Windows.Forms.Button();
            btnAtualizaFuncionario = new System.Windows.Forms.Button();
            btnDeletarFuncionario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "URI - Web API";
            // 
            // txtURI
            // 
            txtURI.Location = new System.Drawing.Point(115, 32);
            txtURI.Name = "txtURI";
            txtURI.Size = new System.Drawing.Size(647, 23);
            txtURI.TabIndex = 1;
            txtURI.Text = "https://localhost:44320/api/Funcionarios";
            // 
            // dgvDados
            // 
            dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDados.Location = new System.Drawing.Point(27, 61);
            dgvDados.Name = "dgvDados";
            dgvDados.RowTemplate.Height = 25;
            dgvDados.Size = new System.Drawing.Size(735, 317);
            dgvDados.TabIndex = 2;
            dgvDados.CellContentClick += dgvDados_CellContentClick;
            // 
            // btnObterFuncionario
            // 
            btnObterFuncionario.Location = new System.Drawing.Point(28, 390);
            btnObterFuncionario.Name = "btnObterFuncionario";
            btnObterFuncionario.Size = new System.Drawing.Size(134, 30);
            btnObterFuncionario.TabIndex = 3;
            btnObterFuncionario.Text = "Retornar Funcionário";
            btnObterFuncionario.UseVisualStyleBackColor = true;
            btnObterFuncionario.Click += btnObterFuncionario_Click;
            // 
            // btnFuncionarioPorId
            // 
            btnFuncionarioPorId.Location = new System.Drawing.Point(176, 390);
            btnFuncionarioPorId.Name = "btnFuncionarioPorId";
            btnFuncionarioPorId.Size = new System.Drawing.Size(134, 30);
            btnFuncionarioPorId.TabIndex = 4;
            btnFuncionarioPorId.Text = "Obter Funcionário Por ID";
            btnFuncionarioPorId.UseVisualStyleBackColor = true;
            btnFuncionarioPorId.Click += btnFuncionarioPorId_Click;
            // 
            // btnIncluirFuncionario
            // 
            btnIncluirFuncionario.Location = new System.Drawing.Point(326, 390);
            btnIncluirFuncionario.Name = "btnIncluirFuncionario";
            btnIncluirFuncionario.Size = new System.Drawing.Size(134, 30);
            btnIncluirFuncionario.TabIndex = 5;
            btnIncluirFuncionario.Text = "Incluir Funcionário";
            btnIncluirFuncionario.UseVisualStyleBackColor = true;
            btnIncluirFuncionario.Click += btnIncluirFuncionario_Click;
            // 
            // btnAtualizaFuncionario
            // 
            btnAtualizaFuncionario.Location = new System.Drawing.Point(478, 390);
            btnAtualizaFuncionario.Name = "btnAtualizaFuncionario";
            btnAtualizaFuncionario.Size = new System.Drawing.Size(134, 30);
            btnAtualizaFuncionario.TabIndex = 6;
            btnAtualizaFuncionario.Text = "Atualiza Funcionário";
            btnAtualizaFuncionario.UseVisualStyleBackColor = true;
            btnAtualizaFuncionario.Click += btnAtualizaFuncionario_Click;
            // 
            // btnDeletarFuncionario
            // 
            btnDeletarFuncionario.Location = new System.Drawing.Point(628, 390);
            btnDeletarFuncionario.Name = "btnDeletarFuncionario";
            btnDeletarFuncionario.Size = new System.Drawing.Size(134, 30);
            btnDeletarFuncionario.TabIndex = 7;
            btnDeletarFuncionario.Text = "Deletar Funcionário";
            btnDeletarFuncionario.UseVisualStyleBackColor = true;
            btnDeletarFuncionario.Click += btnDeletarFuncionario_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnDeletarFuncionario);
            Controls.Add(btnAtualizaFuncionario);
            Controls.Add(btnIncluirFuncionario);
            Controls.Add(btnFuncionarioPorId);
            Controls.Add(btnObterFuncionario);
            Controls.Add(dgvDados);
            Controls.Add(txtURI);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnObterFuncionario;
        private System.Windows.Forms.Button btnFuncionarioPorId;
        private System.Windows.Forms.Button btnIncluirFuncionario;
        private System.Windows.Forms.Button btnAtualizaFuncionario;
        private System.Windows.Forms.Button btnDeletarFuncionario;
    }
}
