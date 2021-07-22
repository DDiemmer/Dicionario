using System.Windows.Forms;
namespace LetsTalkAbout
{
    partial class Form1
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
            this.tb_palavra = new System.Windows.Forms.TextBox();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.tb_traducao = new System.Windows.Forms.TextBox();
            this.lb_podeSer = new System.Windows.Forms.Label();
            this.lbr_oqPodeser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_countVogais = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_countVogaisClasse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_palavra
            // 
            this.tb_palavra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb_palavra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_palavra.Location = new System.Drawing.Point(16, 16);
            this.tb_palavra.Margin = new System.Windows.Forms.Padding(4);
            this.tb_palavra.Name = "tb_palavra";
            this.tb_palavra.Size = new System.Drawing.Size(851, 22);
            this.tb_palavra.TabIndex = 0;
            this.tb_palavra.Leave += new System.EventHandler(this.tb_palavra_TextChanged);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Location = new System.Drawing.Point(881, 12);
            this.bt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(100, 28);
            this.bt_buscar.TabIndex = 1;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // tb_traducao
            // 
            this.tb_traducao.Location = new System.Drawing.Point(16, 59);
            this.tb_traducao.Margin = new System.Windows.Forms.Padding(4);
            this.tb_traducao.Multiline = true;
            this.tb_traducao.Name = "tb_traducao";
            this.tb_traducao.Size = new System.Drawing.Size(964, 192);
            this.tb_traducao.TabIndex = 2;
            // 
            // lb_podeSer
            // 
            this.lb_podeSer.AutoSize = true;
            this.lb_podeSer.Location = new System.Drawing.Point(16, 270);
            this.lb_podeSer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_podeSer.Name = "lb_podeSer";
            this.lb_podeSer.Size = new System.Drawing.Size(115, 17);
            this.lb_podeSer.TabIndex = 3;
            this.lb_podeSer.Text = "O que pode ser: ";
            // 
            // lbr_oqPodeser
            // 
            this.lbr_oqPodeser.AutoSize = true;
            this.lbr_oqPodeser.Location = new System.Drawing.Point(139, 270);
            this.lbr_oqPodeser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbr_oqPodeser.Name = "lbr_oqPodeser";
            this.lbr_oqPodeser.Size = new System.Drawing.Size(20, 17);
            this.lbr_oqPodeser.TabIndex = 4;
            this.lbr_oqPodeser.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vogais";
            // 
            // lb_countVogais
            // 
            this.lb_countVogais.AutoSize = true;
            this.lb_countVogais.Location = new System.Drawing.Point(139, 297);
            this.lb_countVogais.Name = "lb_countVogais";
            this.lb_countVogais.Size = new System.Drawing.Size(20, 17);
            this.lb_countVogais.TabIndex = 6;
            this.lb_countVogais.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Silabas da classe";
            // 
            // lb_countVogaisClasse
            // 
            this.lb_countVogaisClasse.AutoSize = true;
            this.lb_countVogaisClasse.Location = new System.Drawing.Point(139, 327);
            this.lb_countVogaisClasse.Name = "lb_countVogaisClasse";
            this.lb_countVogaisClasse.Size = new System.Drawing.Size(20, 17);
            this.lb_countVogaisClasse.TabIndex = 8;
            this.lb_countVogaisClasse.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 409);
            this.Controls.Add(this.lb_countVogaisClasse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_countVogais);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbr_oqPodeser);
            this.Controls.Add(this.lb_podeSer);
            this.Controls.Add(this.tb_traducao);
            this.Controls.Add(this.bt_buscar);
            this.Controls.Add(this.tb_palavra);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Dicionario ?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_palavra;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.TextBox tb_traducao;
        private AutoCompleteStringCollection dadosLista;
        private Label lb_podeSer;
        private Label lbr_oqPodeser;
        private Label label1;
        private Label lb_countVogais;
        private Label label2;
        private Label lb_countVogaisClasse;
    }
}

