
namespace valuta_atvalto
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
            this.atvaltandoNum = new System.Windows.Forms.NumericUpDown();
            this.atvaaltottNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.atvaltandoNemCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AtvaltottNemCB = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.atvaltandoNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atvaaltottNum)).BeginInit();
            this.SuspendLayout();
            // 
            // atvaltandoNum
            // 
            this.atvaltandoNum.DecimalPlaces = 8;
            this.atvaltandoNum.Location = new System.Drawing.Point(123, 65);
            this.atvaltandoNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.atvaltandoNum.Name = "atvaltandoNum";
            this.atvaltandoNum.Size = new System.Drawing.Size(120, 20);
            this.atvaltandoNum.TabIndex = 0;
            // 
            // atvaaltottNum
            // 
            this.atvaaltottNum.DecimalPlaces = 8;
            this.atvaaltottNum.Location = new System.Drawing.Point(490, 65);
            this.atvaaltottNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.atvaaltottNum.Name = "atvaaltottNum";
            this.atvaaltottNum.Size = new System.Drawing.Size(120, 20);
            this.atvaaltottNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Átváltandó pénz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Átváltott pénz";
            // 
            // atvaltandoNemCB
            // 
            this.atvaltandoNemCB.FormattingEnabled = true;
            this.atvaltandoNemCB.Location = new System.Drawing.Point(122, 104);
            this.atvaltandoNemCB.Name = "atvaltandoNemCB";
            this.atvaltandoNemCB.Size = new System.Drawing.Size(121, 21);
            this.atvaltandoNemCB.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Átváltás";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AtvaltottNemCB
            // 
            this.AtvaltottNemCB.FormattingEnabled = true;
            this.AtvaltottNemCB.Location = new System.Drawing.Point(489, 104);
            this.AtvaltottNemCB.Name = "AtvaltottNemCB";
            this.AtvaltottNemCB.Size = new System.Drawing.Size(121, 21);
            this.AtvaltottNemCB.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 171);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(484, 252);
            this.textBox1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(616, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mentés neve(.txt formátumban)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(616, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 39);
            this.button2.TabIndex = 10;
            this.button2.Text = "Mentés";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(616, 261);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 20);
            this.textBox2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AtvaltottNemCB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.atvaltandoNemCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atvaaltottNum);
            this.Controls.Add(this.atvaltandoNum);
            this.Name = "Form1";
            this.Text = "Valuta_Atvalto";
            ((System.ComponentModel.ISupportInitialize)(this.atvaltandoNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atvaaltottNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown atvaltandoNum;
        private System.Windows.Forms.NumericUpDown atvaaltottNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox atvaltandoNemCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox AtvaltottNemCB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
    }
}

