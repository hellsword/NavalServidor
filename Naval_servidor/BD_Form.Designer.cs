namespace Naval_servidor
{
    partial class BD_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.crear_bd_btn = new System.Windows.Forms.Button();
            this.consultar_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creación BD";
            // 
            // crear_bd_btn
            // 
            this.crear_bd_btn.BackColor = System.Drawing.Color.OliveDrab;
            this.crear_bd_btn.Location = new System.Drawing.Point(111, 396);
            this.crear_bd_btn.Name = "crear_bd_btn";
            this.crear_bd_btn.Size = new System.Drawing.Size(75, 36);
            this.crear_bd_btn.TabIndex = 2;
            this.crear_bd_btn.Text = "Crear BD";
            this.crear_bd_btn.UseVisualStyleBackColor = false;
            this.crear_bd_btn.Click += new System.EventHandler(this.crear_bd_btn_Click);
            // 
            // consultar_btn
            // 
            this.consultar_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.consultar_btn.Location = new System.Drawing.Point(212, 396);
            this.consultar_btn.Name = "consultar_btn";
            this.consultar_btn.Size = new System.Drawing.Size(101, 36);
            this.consultar_btn.TabIndex = 3;
            this.consultar_btn.Text = "Consultar";
            this.consultar_btn.UseVisualStyleBackColor = false;
            this.consultar_btn.Click += new System.EventHandler(this.consultar_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 108);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(528, 239);
            this.textBox1.TabIndex = 4;
            // 
            // BD_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(740, 473);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.consultar_btn);
            this.Controls.Add(this.crear_bd_btn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BD_Form";
            this.Text = "BD_Form";
            this.Load += new System.EventHandler(this.BD_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button crear_bd_btn;
        private System.Windows.Forms.Button consultar_btn;
        private System.Windows.Forms.TextBox textBox1;
    }
}