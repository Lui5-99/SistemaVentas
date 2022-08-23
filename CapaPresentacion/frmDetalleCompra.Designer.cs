namespace CapaPresentacion
{
    partial class frmDetalleCompra
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
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoDocto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNumeroDocto = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btPDF = new FontAwesome.Sharp.IconButton();
            this.btBusqueda = new FontAwesome.Sharp.IconButton();
            this.btLimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(220, 19);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Detalle Compra";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(209, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(596, 470);
            this.label1.TabIndex = 21;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(549, 18);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(174, 20);
            this.txtBusqueda.TabIndex = 82;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(443, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "Número Documento";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTipoDocto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Location = new System.Drawing.Point(225, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 100);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Compra";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(349, 50);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(187, 20);
            this.txtUsuario.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Usuario";
            // 
            // txtTipoDocto
            // 
            this.txtTipoDocto.Location = new System.Drawing.Point(143, 50);
            this.txtTipoDocto.Name = "txtTipoDocto";
            this.txtTipoDocto.Size = new System.Drawing.Size(187, 20);
            this.txtTipoDocto.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tipo Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(7, 50);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(117, 20);
            this.txtFecha.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtNumeroDocto);
            this.groupBox3.Controls.Add(this.txtRazon);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtDocumento);
            this.groupBox3.Location = new System.Drawing.Point(225, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 100);
            this.groupBox3.TabIndex = 86;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información Proveedor";
            // 
            // txtNumeroDocto
            // 
            this.txtNumeroDocto.Location = new System.Drawing.Point(502, 19);
            this.txtNumeroDocto.Name = "txtNumeroDocto";
            this.txtNumeroDocto.Size = new System.Drawing.Size(30, 20);
            this.txtNumeroDocto.TabIndex = 56;
            this.txtNumeroDocto.Visible = false;
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(203, 47);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(333, 20);
            this.txtRazon.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Razon Social";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Proveedor";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(6, 47);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(175, 20);
            this.txtDocumento.TabIndex = 0;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioCompra,
            this.Cantidad,
            this.SubTotal});
            this.dgvDatos.GridColor = System.Drawing.Color.White;
            this.dgvDatos.Location = new System.Drawing.Point(225, 259);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(574, 166);
            this.dgvDatos.TabIndex = 87;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.Width = 180;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.Name = "PrecioCompra";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(222, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Monto Total: $";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(307, 432);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(109, 20);
            this.txtMonto.TabIndex = 89;
            this.txtMonto.Text = "0.00";
            // 
            // btPDF
            // 
            this.btPDF.BackColor = System.Drawing.SystemColors.Control;
            this.btPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPDF.FlatAppearance.BorderSize = 0;
            this.btPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPDF.ForeColor = System.Drawing.Color.IndianRed;
            this.btPDF.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btPDF.IconColor = System.Drawing.Color.IndianRed;
            this.btPDF.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btPDF.IconSize = 20;
            this.btPDF.Location = new System.Drawing.Point(708, 432);
            this.btPDF.Name = "btPDF";
            this.btPDF.Size = new System.Drawing.Size(91, 30);
            this.btPDF.TabIndex = 90;
            this.btPDF.Text = "PDF";
            this.btPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPDF.UseVisualStyleBackColor = false;
            this.btPDF.Click += new System.EventHandler(this.btPDF_Click);
            // 
            // btBusqueda
            // 
            this.btBusqueda.BackColor = System.Drawing.Color.White;
            this.btBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBusqueda.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btBusqueda.FlatAppearance.BorderSize = 0;
            this.btBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBusqueda.ForeColor = System.Drawing.Color.White;
            this.btBusqueda.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btBusqueda.IconColor = System.Drawing.Color.Black;
            this.btBusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btBusqueda.IconSize = 20;
            this.btBusqueda.Location = new System.Drawing.Point(727, 18);
            this.btBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.btBusqueda.Name = "btBusqueda";
            this.btBusqueda.Size = new System.Drawing.Size(34, 24);
            this.btBusqueda.TabIndex = 83;
            this.btBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBusqueda.UseVisualStyleBackColor = false;
            this.btBusqueda.Click += new System.EventHandler(this.btBusqueda_Click);
            // 
            // btLimpiarbuscador
            // 
            this.btLimpiarbuscador.BackColor = System.Drawing.Color.White;
            this.btLimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLimpiarbuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btLimpiarbuscador.FlatAppearance.BorderSize = 0;
            this.btLimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpiarbuscador.ForeColor = System.Drawing.Color.White;
            this.btLimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btLimpiarbuscador.IconColor = System.Drawing.Color.Black;
            this.btLimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btLimpiarbuscador.IconSize = 20;
            this.btLimpiarbuscador.Location = new System.Drawing.Point(765, 18);
            this.btLimpiarbuscador.Margin = new System.Windows.Forms.Padding(2);
            this.btLimpiarbuscador.Name = "btLimpiarbuscador";
            this.btLimpiarbuscador.Size = new System.Drawing.Size(34, 24);
            this.btLimpiarbuscador.TabIndex = 84;
            this.btLimpiarbuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLimpiarbuscador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLimpiarbuscador.UseVisualStyleBackColor = false;
            this.btLimpiarbuscador.Click += new System.EventHandler(this.btLimpiarbuscador_Click);
            // 
            // frmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 510);
            this.Controls.Add(this.btPDF);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btBusqueda);
            this.Controls.Add(this.btLimpiarbuscador);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Name = "frmDetalleCompra";
            this.Text = "frmDetalleCompra";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btBusqueda;
        private FontAwesome.Sharp.IconButton btLimpiarbuscador;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipoDocto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNumeroDocto;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMonto;
        private FontAwesome.Sharp.IconButton btPDF;
    }
}