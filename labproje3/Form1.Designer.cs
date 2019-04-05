namespace labproje3
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
            this.btnduzenle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btncsv = new System.Windows.Forms.Button();
            this.btnartan = new System.Windows.Forms.Button();
            this.btnazalan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnduzenle
            // 
            this.btnduzenle.Location = new System.Drawing.Point(24, 464);
            this.btnduzenle.Name = "btnduzenle";
            this.btnduzenle.Size = new System.Drawing.Size(90, 36);
            this.btnduzenle.TabIndex = 0;
            this.btnduzenle.Text = "Düzenleme";
            this.btnduzenle.UseVisualStyleBackColor = true;
            this.btnduzenle.Click += new System.EventHandler(this.btnduzenle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1399, 331);
            this.dataGridView1.TabIndex = 2;
            // 
            // btncsv
            // 
            this.btncsv.Location = new System.Drawing.Point(150, 464);
            this.btncsv.Name = "btncsv";
            this.btncsv.Size = new System.Drawing.Size(90, 36);
            this.btncsv.TabIndex = 1;
            this.btncsv.Text = "CSV Yükle";
            this.btncsv.UseVisualStyleBackColor = true;
            this.btncsv.Click += new System.EventHandler(this.btncsv_Click);
            // 
            // btnartan
            // 
            this.btnartan.Location = new System.Drawing.Point(279, 464);
            this.btnartan.Name = "btnartan";
            this.btnartan.Size = new System.Drawing.Size(101, 49);
            this.btnartan.TabIndex = 2;
            this.btnartan.Text = "Artan Sıralama";
            this.btnartan.UseVisualStyleBackColor = true;
            this.btnartan.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnazalan
            // 
            this.btnazalan.Location = new System.Drawing.Point(416, 464);
            this.btnazalan.Name = "btnazalan";
            this.btnazalan.Size = new System.Drawing.Size(83, 49);
            this.btnazalan.TabIndex = 3;
            this.btnazalan.Text = "Azalan Sıralama";
            this.btnazalan.UseVisualStyleBackColor = true;
            this.btnazalan.Click += new System.EventHandler(this.btnazalan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1423, 575);
            this.Controls.Add(this.btnazalan);
            this.Controls.Add(this.btnartan);
            this.Controls.Add(this.btncsv);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnduzenle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnduzenle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btncsv;
        private System.Windows.Forms.Button btnartan;
        private System.Windows.Forms.Button btnazalan;
    }
}

