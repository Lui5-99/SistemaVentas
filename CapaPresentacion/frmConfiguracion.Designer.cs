namespace CapaPresentacion
{
    partial class frmConfiguracion
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
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btImpresora = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cbImpresora = new System.Windows.Forms.ComboBox();
            this.btGuardar = new FontAwesome.Sharp.IconButton();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btSubir = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Detalle del Negocio";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 447);
            this.label1.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btImpresora);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbImpresora);
            this.groupBox1.Controls.Add(this.btGuardar);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtRFC);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btSubir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.picLogo);
            this.groupBox1.Location = new System.Drawing.Point(28, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 342);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // btImpresora
            // 
            this.btImpresora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btImpresora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btImpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImpresora.ForeColor = System.Drawing.Color.White;
            this.btImpresora.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btImpresora.IconColor = System.Drawing.Color.White;
            this.btImpresora.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btImpresora.IconSize = 20;
            this.btImpresora.Location = new System.Drawing.Point(17, 263);
            this.btImpresora.Margin = new System.Windows.Forms.Padding(2);
            this.btImpresora.Name = "btImpresora";
            this.btImpresora.Size = new System.Drawing.Size(164, 29);
            this.btImpresora.TabIndex = 26;
            this.btImpresora.Text = "Guardar impresora";
            this.btImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImpresora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImpresora.UseVisualStyleBackColor = false;
            this.btImpresora.Click += new System.EventHandler(this.btImpresora_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Impresoras disponibles";
            // 
            // cbImpresora
            // 
            this.cbImpresora.FormattingEnabled = true;
            this.cbImpresora.Location = new System.Drawing.Point(17, 237);
            this.cbImpresora.Name = "cbImpresora";
            this.cbImpresora.Size = new System.Drawing.Size(497, 21);
            this.cbImpresora.TabIndex = 24;
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.Color.Green;
            this.btGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGuardar.ForeColor = System.Drawing.Color.White;
            this.btGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btGuardar.IconColor = System.Drawing.Color.White;
            this.btGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btGuardar.IconSize = 20;
            this.btGuardar.Location = new System.Drawing.Point(190, 178);
            this.btGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(324, 29);
            this.btGuardar.TabIndex = 23;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(188, 151);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(326, 20);
            this.txtDireccion.TabIndex = 22;
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(189, 108);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(2);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(325, 20);
            this.txtRFC.TabIndex = 21;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(189, 61);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(325, 20);
            this.txtNombre.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(186, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Dirección";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(187, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "RFC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(187, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Negocio";
            // 
            // btSubir
            // 
            this.btSubir.BackColor = System.Drawing.Color.Teal;
            this.btSubir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSubir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSubir.ForeColor = System.Drawing.Color.White;
            this.btSubir.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.btSubir.IconColor = System.Drawing.Color.White;
            this.btSubir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btSubir.IconSize = 20;
            this.btSubir.Location = new System.Drawing.Point(20, 178);
            this.btSubir.Margin = new System.Windows.Forms.Padding(2);
            this.btSubir.Name = "btSubir";
            this.btSubir.Size = new System.Drawing.Size(164, 29);
            this.btSubir.TabIndex = 16;
            this.btSubir.Text = "Subir";
            this.btSubir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSubir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSubir.UseVisualStyleBackColor = false;
            this.btSubir.Click += new System.EventHandler(this.btSubir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Logo";
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(20, 47);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(164, 126);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Name = "frmConfiguracion";
            this.Text = "frmConfiguracion";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picLogo;
        private FontAwesome.Sharp.IconButton btSubir;
        private FontAwesome.Sharp.IconButton btGuardar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbImpresora;
        private FontAwesome.Sharp.IconButton btImpresora;
    }
}