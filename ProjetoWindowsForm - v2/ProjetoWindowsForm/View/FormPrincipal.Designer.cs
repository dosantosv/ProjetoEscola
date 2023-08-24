using ProjetoWindowsForm.Repository;

namespace ProjetoWindowsForm
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBoletim = new System.Windows.Forms.PictureBox();
            this.btnCalcularMedia = new System.Windows.Forms.PictureBox();
            this.btnProfessores = new System.Windows.Forms.PictureBox();
            this.btnAlunos = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBoletim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalcularMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProfessores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAlunos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(991, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuSair
            // 
            this.menuSair.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(43, 20);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(126)))), ((int)(((byte)(182)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 453);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnBoletim);
            this.panel2.Controls.Add(this.btnCalcularMedia);
            this.panel2.Controls.Add(this.btnProfessores);
            this.panel2.Controls.Add(this.btnAlunos);
            this.panel2.Location = new System.Drawing.Point(110, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(788, 302);
            this.panel2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(126)))), ((int)(((byte)(182)))));
            this.label5.Location = new System.Drawing.Point(63, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(673, 84);
            this.label5.TabIndex = 34;
            this.label5.Text = "GERENCIAMENTO ESCOLAR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(675, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Boletim";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(490, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Calcular Média";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(297, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Professores";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(92, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Alunos";
            // 
            // btnBoletim
            // 
            this.btnBoletim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBoletim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoletim.Image = ((System.Drawing.Image)(resources.GetObject("btnBoletim.Image")));
            this.btnBoletim.Location = new System.Drawing.Point(653, 108);
            this.btnBoletim.Name = "btnBoletim";
            this.btnBoletim.Size = new System.Drawing.Size(83, 82);
            this.btnBoletim.TabIndex = 29;
            this.btnBoletim.TabStop = false;
            this.toolTip2.SetToolTip(this.btnBoletim, "Área liberada apenas para ADMIN");
            this.btnBoletim.Click += new System.EventHandler(this.btnBoletim_Click);
            // 
            // btnCalcularMedia
            // 
            this.btnCalcularMedia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCalcularMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularMedia.Image = ((System.Drawing.Image)(resources.GetObject("btnCalcularMedia.Image")));
            this.btnCalcularMedia.Location = new System.Drawing.Point(484, 108);
            this.btnCalcularMedia.Name = "btnCalcularMedia";
            this.btnCalcularMedia.Size = new System.Drawing.Size(83, 82);
            this.btnCalcularMedia.TabIndex = 28;
            this.btnCalcularMedia.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCalcularMedia, "Área liberada apenas para Professores");
            this.btnCalcularMedia.Click += new System.EventHandler(this.btnCalcularMedia_Click);
            // 
            // btnProfessores
            // 
            this.btnProfessores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProfessores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfessores.Image = ((System.Drawing.Image)(resources.GetObject("btnProfessores.Image")));
            this.btnProfessores.Location = new System.Drawing.Point(289, 108);
            this.btnProfessores.Name = "btnProfessores";
            this.btnProfessores.Size = new System.Drawing.Size(80, 82);
            this.btnProfessores.TabIndex = 27;
            this.btnProfessores.TabStop = false;
            this.toolTip2.SetToolTip(this.btnProfessores, "Área liberada apenas para ADMIN");
            this.btnProfessores.Click += new System.EventHandler(this.btnProfessores_Click);
            // 
            // btnAlunos
            // 
            this.btnAlunos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAlunos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlunos.Image = ((System.Drawing.Image)(resources.GetObject("btnAlunos.Image")));
            this.btnAlunos.Location = new System.Drawing.Point(74, 108);
            this.btnAlunos.Name = "btnAlunos";
            this.btnAlunos.Size = new System.Drawing.Size(80, 82);
            this.btnAlunos.TabIndex = 26;
            this.btnAlunos.TabStop = false;
            this.toolTip2.SetToolTip(this.btnAlunos, "Área liberada apenas para ADMIN");
            this.btnAlunos.Click += new System.EventHandler(this.btnAlunos_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 481);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBoletim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalcularMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProfessores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAlunos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnBoletim;
        private System.Windows.Forms.PictureBox btnCalcularMedia;
        private System.Windows.Forms.PictureBox btnProfessores;
        private System.Windows.Forms.PictureBox btnAlunos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}