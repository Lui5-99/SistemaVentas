namespace CapaPresentacion
{
    partial class frmCategoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btBusqueda = new FontAwesome.Sharp.IconButton();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.vacio = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btLimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cbBusqueda = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIndice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btEliminar = new FontAwesome.Sharp.IconButton();
            this.btLimpiar = new FontAwesome.Sharp.IconButton();
            this.btGuardar = new FontAwesome.Sharp.IconButton();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
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
            this.btBusqueda.Location = new System.Drawing.Point(923, 23);
            this.btBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.btBusqueda.Name = "btBusqueda";
            this.btBusqueda.Size = new System.Drawing.Size(34, 24);
            this.btBusqueda.TabIndex = 53;
            this.btBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBusqueda.UseVisualStyleBackColor = false;
            this.btBusqueda.Click += new System.EventHandler(this.btBusqueda_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vacio,
            this.Id,
            this.Descripcion,
            this.EstadoValor,
            this.Estado});
            this.dgvDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvDatos.Location = new System.Drawing.Point(269, 66);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDatos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.RowTemplate.Height = 28;
            this.dgvDatos.Size = new System.Drawing.Size(738, 160);
            this.dgvDatos.TabIndex = 47;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDatos_CellPainting);
            // 
            // vacio
            // 
            this.vacio.HeaderText = "";
            this.vacio.MinimumWidth = 6;
            this.vacio.Name = "vacio";
            this.vacio.ReadOnly = true;
            this.vacio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vacio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.vacio.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 30;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 150;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.MinimumWidth = 6;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            this.EstadoValor.Width = 125;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 125;
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
            this.btLimpiarbuscador.Location = new System.Drawing.Point(963, 22);
            this.btLimpiarbuscador.Margin = new System.Windows.Forms.Padding(2);
            this.btLimpiarbuscador.Name = "btLimpiarbuscador";
            this.btLimpiarbuscador.Size = new System.Drawing.Size(34, 24);
            this.btLimpiarbuscador.TabIndex = 54;
            this.btLimpiarbuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLimpiarbuscador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLimpiarbuscador.UseVisualStyleBackColor = false;
            this.btLimpiarbuscador.Click += new System.EventHandler(this.btLimpiarbuscador_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(745, 27);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(174, 20);
            this.txtBusqueda.TabIndex = 52;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Location = new System.Drawing.Point(562, 27);
            this.cbBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(174, 21);
            this.cbBusqueda.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(490, 29);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Buscar por";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(210, 23);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(30, 20);
            this.txtId.TabIndex = 49;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(269, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(738, 53);
            this.label10.TabIndex = 48;
            this.label10.Text = "Lista de categorías";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIndice
            // 
            this.lblIndice.AutoSize = true;
            this.lblIndice.BackColor = System.Drawing.Color.White;
            this.lblIndice.Location = new System.Drawing.Point(223, 7);
            this.lblIndice.Name = "lblIndice";
            this.lblIndice.Size = new System.Drawing.Size(16, 13);
            this.lblIndice.TabIndex = 55;
            this.lblIndice.Text = "-1";
            this.lblIndice.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 25);
            this.label9.TabIndex = 46;
            this.label9.Text = "Detalle de categoría";
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminar.ForeColor = System.Drawing.Color.White;
            this.btEliminar.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btEliminar.IconColor = System.Drawing.Color.White;
            this.btEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btEliminar.IconSize = 20;
            this.btEliminar.Location = new System.Drawing.Point(18, 197);
            this.btEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(221, 29);
            this.btEliminar.TabIndex = 45;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackColor = System.Drawing.Color.Teal;
            this.btLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpiar.ForeColor = System.Drawing.Color.White;
            this.btLimpiar.IconChar = FontAwesome.Sharp.IconChar.BroomBall;
            this.btLimpiar.IconColor = System.Drawing.Color.White;
            this.btLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btLimpiar.IconSize = 20;
            this.btLimpiar.Location = new System.Drawing.Point(18, 166);
            this.btLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(221, 29);
            this.btLimpiar.TabIndex = 44;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
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
            this.btGuardar.Location = new System.Drawing.Point(18, 134);
            this.btGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(221, 29);
            this.btGuardar.TabIndex = 43;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(18, 99);
            this.cbEstado.Margin = new System.Windows.Forms.Padding(2);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(222, 21);
            this.cbEstado.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(16, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Estado";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(18, 61);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(222, 20);
            this.txtDescripcion.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 243);
            this.label1.TabIndex = 28;
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 243);
            this.Controls.Add(this.btBusqueda);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btLimpiarbuscador);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cbBusqueda);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblIndice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCategoria";
            this.Text = "frmCategoria";
            this.Load += new System.EventHandler(this.frmCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btBusqueda;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewButtonColumn vacio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private FontAwesome.Sharp.IconButton btLimpiarbuscador;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cbBusqueda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblIndice;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton btEliminar;
        private FontAwesome.Sharp.IconButton btLimpiar;
        private FontAwesome.Sharp.IconButton btGuardar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}