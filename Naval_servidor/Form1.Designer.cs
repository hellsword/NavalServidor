namespace Naval_servidor
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bd_btn = new System.Windows.Forms.Button();
            this.chat_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lista_jugadores = new System.Windows.Forms.DataGridView();
            this.emparejar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lista_jugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // bd_btn
            // 
            this.bd_btn.BackColor = System.Drawing.Color.Coral;
            this.bd_btn.Location = new System.Drawing.Point(53, 650);
            this.bd_btn.Name = "bd_btn";
            this.bd_btn.Size = new System.Drawing.Size(75, 27);
            this.bd_btn.TabIndex = 0;
            this.bd_btn.Text = "BD";
            this.bd_btn.UseVisualStyleBackColor = false;
            this.bd_btn.Click += new System.EventHandler(this.bd_btn_Click);
            // 
            // chat_text
            // 
            this.chat_text.Location = new System.Drawing.Point(53, 479);
            this.chat_text.Multiline = true;
            this.chat_text.Name = "chat_text";
            this.chat_text.Size = new System.Drawing.Size(671, 141);
            this.chat_text.TabIndex = 2;
            this.chat_text.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Salón de Jugadores";
            // 
            // lista_jugadores
            // 
            this.lista_jugadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.lista_jugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lista_jugadores.DefaultCellStyle = dataGridViewCellStyle13;
            this.lista_jugadores.Location = new System.Drawing.Point(53, 141);
            this.lista_jugadores.Name = "lista_jugadores";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista_jugadores.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.lista_jugadores.RowHeadersVisible = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Black;
            this.lista_jugadores.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.lista_jugadores.RowTemplate.Height = 24;
            this.lista_jugadores.Size = new System.Drawing.Size(671, 314);
            this.lista_jugadores.TabIndex = 4;
            // 
            // emparejar
            // 
            this.emparejar.BackColor = System.Drawing.Color.DodgerBlue;
            this.emparejar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emparejar.ForeColor = System.Drawing.Color.GhostWhite;
            this.emparejar.Location = new System.Drawing.Point(440, 638);
            this.emparejar.Name = "emparejar";
            this.emparejar.Size = new System.Drawing.Size(273, 34);
            this.emparejar.TabIndex = 5;
            this.emparejar.Text = "Realizar emparejamiento";
            this.emparejar.UseVisualStyleBackColor = false;
            this.emparejar.Click += new System.EventHandler(this.emparejar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(791, 684);
            this.Controls.Add(this.emparejar);
            this.Controls.Add(this.lista_jugadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chat_text);
            this.Controls.Add(this.bd_btn);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lista_jugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bd_btn;
        private System.Windows.Forms.TextBox chat_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView lista_jugadores;
        private System.Windows.Forms.Button emparejar;
    }
}

