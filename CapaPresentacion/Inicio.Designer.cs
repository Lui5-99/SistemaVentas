namespace CapaPresentacion
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuUsuario = new FontAwesome.Sharp.IconMenuItem();
            this.menuMantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.MenuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.MenuProducto = new FontAwesome.Sharp.IconMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.menuRegistrarVenta = new FontAwesome.Sharp.IconMenuItem();
            this.menuDetalleVenta = new FontAwesome.Sharp.IconMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.menuRegistar = new FontAwesome.Sharp.IconMenuItem();
            this.menuDetalleCompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuRepVentas = new FontAwesome.Sharp.IconMenuItem();
            this.menuRepCompras = new FontAwesome.Sharp.IconMenuItem();
            this.menuConfiguracion = new FontAwesome.Sharp.IconMenuItem();
            this.menuNegocio = new FontAwesome.Sharp.IconMenuItem();
            this.menuPermiso = new FontAwesome.Sharp.IconMenuItem();
            this.menuAcercade = new FontAwesome.Sharp.IconMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.lblSistema = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuario,
            this.menuMantenedor,
            this.menuVentas,
            this.menuCompras,
            this.menuClientes,
            this.menuProveedores,
            this.menuReportes,
            this.menuConfiguracion,
            this.menuAcercade});
            this.menu.Location = new System.Drawing.Point(0, 48);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1019, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuUsuario
            // 
            this.menuUsuario.AutoSize = false;
            this.menuUsuario.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            this.menuUsuario.IconColor = System.Drawing.Color.Black;
            this.menuUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuario.IconSize = 50;
            this.menuUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuario.Name = "menuUsuario";
            this.menuUsuario.Size = new System.Drawing.Size(80, 69);
            this.menuUsuario.Text = "Usuarios";
            this.menuUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuario.Click += new System.EventHandler(this.menuUsuario_Click);
            // 
            // menuMantenedor
            // 
            this.menuMantenedor.AutoSize = false;
            this.menuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCategoria,
            this.MenuProducto});
            this.menuMantenedor.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            this.menuMantenedor.IconColor = System.Drawing.Color.Black;
            this.menuMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenedor.IconSize = 50;
            this.menuMantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenedor.Name = "menuMantenedor";
            this.menuMantenedor.Size = new System.Drawing.Size(80, 69);
            this.menuMantenedor.Text = "Catálogo";
            this.menuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MenuCategoria
            // 
            this.MenuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MenuCategoria.IconColor = System.Drawing.Color.Black;
            this.MenuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuCategoria.Name = "MenuCategoria";
            this.MenuCategoria.Size = new System.Drawing.Size(125, 22);
            this.MenuCategoria.Text = "Categoría";
            this.MenuCategoria.Click += new System.EventHandler(this.MenuCategoria_Click);
            // 
            // MenuProducto
            // 
            this.MenuProducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MenuProducto.IconColor = System.Drawing.Color.Black;
            this.MenuProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuProducto.Name = "MenuProducto";
            this.MenuProducto.Size = new System.Drawing.Size(125, 22);
            this.MenuProducto.Text = "Producto";
            this.MenuProducto.Click += new System.EventHandler(this.MenuProducto_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.AutoSize = false;
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRegistrarVenta,
            this.menuDetalleVenta});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 50;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(80, 69);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuRegistrarVenta
            // 
            this.menuRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuRegistrarVenta.IconColor = System.Drawing.Color.Black;
            this.menuRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuRegistrarVenta.Name = "menuRegistrarVenta";
            this.menuRegistrarVenta.Size = new System.Drawing.Size(129, 22);
            this.menuRegistrarVenta.Text = "Registrar";
            this.menuRegistrarVenta.Click += new System.EventHandler(this.menuRegistrarVenta_Click);
            // 
            // menuDetalleVenta
            // 
            this.menuDetalleVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuDetalleVenta.IconColor = System.Drawing.Color.Black;
            this.menuDetalleVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuDetalleVenta.Name = "menuDetalleVenta";
            this.menuDetalleVenta.Size = new System.Drawing.Size(129, 22);
            this.menuDetalleVenta.Text = "Ver Detalle";
            this.menuDetalleVenta.Click += new System.EventHandler(this.menuDetalleVenta_Click);
            // 
            // menuCompras
            // 
            this.menuCompras.AutoSize = false;
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRegistar,
            this.menuDetalleCompra});
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.DollyBox;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompras.IconSize = 50;
            this.menuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(80, 69);
            this.menuCompras.Text = "Compras";
            this.menuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuRegistar
            // 
            this.menuRegistar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuRegistar.IconColor = System.Drawing.Color.Black;
            this.menuRegistar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuRegistar.Name = "menuRegistar";
            this.menuRegistar.Size = new System.Drawing.Size(129, 22);
            this.menuRegistar.Text = "Registrar";
            this.menuRegistar.Click += new System.EventHandler(this.menuRegistar_Click);
            // 
            // menuDetalleCompra
            // 
            this.menuDetalleCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuDetalleCompra.IconColor = System.Drawing.Color.Black;
            this.menuDetalleCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuDetalleCompra.Name = "menuDetalleCompra";
            this.menuDetalleCompra.Size = new System.Drawing.Size(129, 22);
            this.menuDetalleCompra.Text = "Ver Detalle";
            this.menuDetalleCompra.Click += new System.EventHandler(this.menuDetalleCompra_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.AutoSize = false;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 50;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(80, 69);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuProveedores
            // 
            this.menuProveedores.AutoSize = false;
            this.menuProveedores.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            this.menuProveedores.IconColor = System.Drawing.Color.Black;
            this.menuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedores.IconSize = 50;
            this.menuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(80, 69);
            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedores.Click += new System.EventHandler(this.menuProveedores_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRepVentas,
            this.menuRepCompras});
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(80, 69);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReportes.Click += new System.EventHandler(this.MenuReportes_Click);
            // 
            // menuRepVentas
            // 
            this.menuRepVentas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuRepVentas.IconColor = System.Drawing.Color.Black;
            this.menuRepVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuRepVentas.Name = "menuRepVentas";
            this.menuRepVentas.Size = new System.Drawing.Size(122, 22);
            this.menuRepVentas.Text = "Ventas";
            this.menuRepVentas.Click += new System.EventHandler(this.menuRepVentas_Click);
            // 
            // menuRepCompras
            // 
            this.menuRepCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuRepCompras.IconColor = System.Drawing.Color.Black;
            this.menuRepCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuRepCompras.Name = "menuRepCompras";
            this.menuRepCompras.Size = new System.Drawing.Size(122, 22);
            this.menuRepCompras.Text = "Compras";
            this.menuRepCompras.Click += new System.EventHandler(this.menuRepCompras_Click);
            // 
            // menuConfiguracion
            // 
            this.menuConfiguracion.AutoSize = false;
            this.menuConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNegocio,
            this.menuPermiso});
            this.menuConfiguracion.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menuConfiguracion.IconColor = System.Drawing.Color.Black;
            this.menuConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuConfiguracion.IconSize = 50;
            this.menuConfiguracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuConfiguracion.Name = "menuConfiguracion";
            this.menuConfiguracion.Size = new System.Drawing.Size(80, 69);
            this.menuConfiguracion.Text = "Configuración";
            this.menuConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuConfiguracion.Click += new System.EventHandler(this.menuConfiguracion_Click);
            // 
            // menuNegocio
            // 
            this.menuNegocio.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuNegocio.IconColor = System.Drawing.Color.Black;
            this.menuNegocio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuNegocio.Name = "menuNegocio";
            this.menuNegocio.Size = new System.Drawing.Size(122, 22);
            this.menuNegocio.Text = "Negocio";
            this.menuNegocio.Click += new System.EventHandler(this.menuNegocio_Click);
            // 
            // menuPermiso
            // 
            this.menuPermiso.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuPermiso.IconColor = System.Drawing.Color.Black;
            this.menuPermiso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuPermiso.Name = "menuPermiso";
            this.menuPermiso.Size = new System.Drawing.Size(122, 22);
            this.menuPermiso.Text = "Permisos";
            this.menuPermiso.Click += new System.EventHandler(this.menuPermiso_Click);
            // 
            // menuAcercade
            // 
            this.menuAcercade.AutoSize = false;
            this.menuAcercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercade.IconColor = System.Drawing.Color.Black;
            this.menuAcercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAcercade.IconSize = 50;
            this.menuAcercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercade.Name = "menuAcercade";
            this.menuAcercade.Size = new System.Drawing.Size(80, 69);
            this.menuAcercade.Text = "Acerca de";
            this.menuAcercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuAcercade.Click += new System.EventHandler(this.menuAcercade_Click);
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.SlateGray;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(1019, 48);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.BackColor = System.Drawing.Color.SlateGray;
            this.lblSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSistema.ForeColor = System.Drawing.Color.White;
            this.lblSistema.Location = new System.Drawing.Point(12, 9);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(241, 31);
            this.lblSistema.TabIndex = 2;
            this.lblSistema.Text = "Sistema de Ventas";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 121);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1019, 492);
            this.contenedor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(831, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.SlateGray;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(890, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(63, 15);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 613);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menuUsuario;
        private FontAwesome.Sharp.IconMenuItem menuMantenedor;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuProveedores;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuConfiguracion;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Panel contenedor;
        private FontAwesome.Sharp.IconMenuItem menuAcercade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconMenuItem MenuCategoria;
        private FontAwesome.Sharp.IconMenuItem MenuProducto;
        private FontAwesome.Sharp.IconMenuItem menuRegistrarVenta;
        private FontAwesome.Sharp.IconMenuItem menuDetalleVenta;
        private FontAwesome.Sharp.IconMenuItem menuRegistar;
        private FontAwesome.Sharp.IconMenuItem menuDetalleCompra;
        private FontAwesome.Sharp.IconMenuItem menuNegocio;
        private FontAwesome.Sharp.IconMenuItem menuPermiso;
        private FontAwesome.Sharp.IconMenuItem menuRepVentas;
        private FontAwesome.Sharp.IconMenuItem menuRepCompras;
    }
}

