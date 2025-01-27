
namespace Donkey_Kong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.prooktatasLBL = new System.Windows.Forms.Label();
            this.kismeretLBL = new System.Windows.Forms.Label();
            this.nagymeretLB = new System.Windows.Forms.Label();
            this.jatek_Inditasa_BTN = new System.Windows.Forms.Button();
            this.toplistBTN = new System.Windows.Forms.Button();
            this.kilepesBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.kilepesBTN);
            this.panel1.Controls.Add(this.toplistBTN);
            this.panel1.Controls.Add(this.jatek_Inditasa_BTN);
            this.panel1.Controls.Add(this.nagymeretLB);
            this.panel1.Controls.Add(this.kismeretLBL);
            this.panel1.Controls.Add(this.prooktatasLBL);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 594);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::Donkey_Kong.Properties.Resources.csharp_logo;
            this.pictureBox3.Location = new System.Drawing.Point(643, 256);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(148, 111);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::Donkey_Kong.Properties.Resources.donkey_kong_promo;
            this.pictureBox2.Location = new System.Drawing.Point(3, 382);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(181, 209);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Donkey_Kong.Properties.Resources.Donkeykong_logo1_svg;
            this.pictureBox1.Location = new System.Drawing.Point(203, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(374, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // prooktatasLBL
            // 
            this.prooktatasLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prooktatasLBL.AutoSize = true;
            this.prooktatasLBL.Location = new System.Drawing.Point(694, 554);
            this.prooktatasLBL.Name = "prooktatasLBL";
            this.prooktatasLBL.Size = new System.Drawing.Size(95, 20);
            this.prooktatasLBL.TabIndex = 3;
            this.prooktatasLBL.Text = "Proooktatás";
            this.prooktatasLBL.Click += new System.EventHandler(this.prooktatasLBL_Click);
            this.prooktatasLBL.MouseEnter += new System.EventHandler(this.kismeretLBL_MouseEnter);
            this.prooktatasLBL.MouseLeave += new System.EventHandler(this.kismeretLBL_MouseLeave);
            // 
            // kismeretLBL
            // 
            this.kismeretLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kismeretLBL.AutoSize = true;
            this.kismeretLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kismeretLBL.Location = new System.Drawing.Point(730, 9);
            this.kismeretLBL.Name = "kismeretLBL";
            this.kismeretLBL.Size = new System.Drawing.Size(19, 20);
            this.kismeretLBL.TabIndex = 4;
            this.kismeretLBL.Text = "_";
            this.kismeretLBL.Click += new System.EventHandler(this.kismeretLBL_Click);
            this.kismeretLBL.MouseEnter += new System.EventHandler(this.kismeretLBL_MouseEnter);
            this.kismeretLBL.MouseLeave += new System.EventHandler(this.kismeretLBL_MouseLeave);
            // 
            // nagymeretLB
            // 
            this.nagymeretLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nagymeretLB.AutoSize = true;
            this.nagymeretLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nagymeretLB.Location = new System.Drawing.Point(765, 9);
            this.nagymeretLB.Name = "nagymeretLB";
            this.nagymeretLB.Size = new System.Drawing.Size(24, 20);
            this.nagymeretLB.TabIndex = 5;
            this.nagymeretLB.Text = "[ ]";
            this.nagymeretLB.Click += new System.EventHandler(this.nagymeretLB_Click);
            this.nagymeretLB.MouseEnter += new System.EventHandler(this.kismeretLBL_MouseEnter);
            this.nagymeretLB.MouseLeave += new System.EventHandler(this.kismeretLBL_MouseLeave);
            // 
            // jatek_Inditasa_BTN
            // 
            this.jatek_Inditasa_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jatek_Inditasa_BTN.BackColor = System.Drawing.Color.Red;
            this.jatek_Inditasa_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jatek_Inditasa_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.jatek_Inditasa_BTN.ForeColor = System.Drawing.Color.Gold;
            this.jatek_Inditasa_BTN.Location = new System.Drawing.Point(251, 218);
            this.jatek_Inditasa_BTN.Name = "jatek_Inditasa_BTN";
            this.jatek_Inditasa_BTN.Size = new System.Drawing.Size(278, 75);
            this.jatek_Inditasa_BTN.TabIndex = 6;
            this.jatek_Inditasa_BTN.Text = "Játék Inditása";
            this.jatek_Inditasa_BTN.UseVisualStyleBackColor = false;
            this.jatek_Inditasa_BTN.Click += new System.EventHandler(this.jatek_Inditasa_BTN_Click);
            this.jatek_Inditasa_BTN.MouseEnter += new System.EventHandler(this.jatek_Inditasa_BTN_MouseEnter);
            this.jatek_Inditasa_BTN.MouseLeave += new System.EventHandler(this.jatek_Inditasa_BTN_MouseLeave);
            // 
            // toplistBTN
            // 
            this.toplistBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toplistBTN.BackColor = System.Drawing.Color.Red;
            this.toplistBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toplistBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toplistBTN.ForeColor = System.Drawing.Color.Gold;
            this.toplistBTN.Location = new System.Drawing.Point(251, 314);
            this.toplistBTN.Name = "toplistBTN";
            this.toplistBTN.Size = new System.Drawing.Size(278, 75);
            this.toplistBTN.TabIndex = 7;
            this.toplistBTN.Text = "Toplista";
            this.toplistBTN.UseVisualStyleBackColor = false;
            this.toplistBTN.Click += new System.EventHandler(this.toplistBTN_Click);
            this.toplistBTN.MouseEnter += new System.EventHandler(this.jatek_Inditasa_BTN_MouseEnter);
            this.toplistBTN.MouseLeave += new System.EventHandler(this.jatek_Inditasa_BTN_MouseLeave);
            // 
            // kilepesBTN
            // 
            this.kilepesBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kilepesBTN.BackColor = System.Drawing.Color.Red;
            this.kilepesBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kilepesBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kilepesBTN.ForeColor = System.Drawing.Color.Gold;
            this.kilepesBTN.Location = new System.Drawing.Point(251, 404);
            this.kilepesBTN.Name = "kilepesBTN";
            this.kilepesBTN.Size = new System.Drawing.Size(278, 75);
            this.kilepesBTN.TabIndex = 8;
            this.kilepesBTN.Text = "Kilépés";
            this.kilepesBTN.UseVisualStyleBackColor = false;
            this.kilepesBTN.Click += new System.EventHandler(this.kilepesBTN_Click);
            this.kilepesBTN.MouseEnter += new System.EventHandler(this.jatek_Inditasa_BTN_MouseEnter);
            this.kilepesBTN.MouseLeave += new System.EventHandler(this.jatek_Inditasa_BTN_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Aqua;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Főmenű";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button kilepesBTN;
        private System.Windows.Forms.Button toplistBTN;
        private System.Windows.Forms.Button jatek_Inditasa_BTN;
        private System.Windows.Forms.Label nagymeretLB;
        private System.Windows.Forms.Label kismeretLBL;
        private System.Windows.Forms.Label prooktatasLBL;
    }
}

