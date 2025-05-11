namespace PromWhats
{
    partial class Mensajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mensajes));
            tableLayoutPanel1 = new TableLayoutPanel();
            PBImagen = new PictureBox();
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            txtMensaje = new TextBox();
            btnGuardar = new Button();
            txtNombreMensaje = new TextBox();
            menuStrip1 = new MenuStrip();
            primerToolStripMenuItem = new ToolStripMenuItem();
            CheckActivo = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(PBImagen, 1, 0);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnGuardar, 1, 1);
            tableLayoutPanel1.Controls.Add(txtNombreMensaje, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(1071, 549);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // PBImagen
            // 
            PBImagen.Dock = DockStyle.Fill;
            PBImagen.Image = (Image)resources.GetObject("PBImagen.Image");
            PBImagen.Location = new Point(538, 3);
            PBImagen.Name = "PBImagen";
            PBImagen.Size = new Size(530, 488);
            PBImagen.SizeMode = PictureBoxSizeMode.Zoom;
            PBImagen.TabIndex = 0;
            PBImagen.TabStop = false;
            PBImagen.Click += PBImagen_Click;
            PBImagen.DragDrop += PBImagen_DragDrop;
            PBImagen.DragEnter += PBImagen_DragEnter;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(CheckActivo);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtMensaje);
            splitContainer1.Size = new Size(529, 488);
            splitContainer1.SplitterDistance = 37;
            splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(185, 25);
            label1.TabIndex = 0;
            label1.Text = "Escribe un mensaje:";
            // 
            // txtMensaje
            // 
            txtMensaje.Dock = DockStyle.Fill;
            txtMensaje.Location = new Point(0, 0);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(529, 447);
            txtMensaje.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Dock = DockStyle.Fill;
            btnGuardar.Font = new Font("Product Sans", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(538, 497);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(530, 49);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombreMensaje
            // 
            txtNombreMensaje.Anchor = AnchorStyles.None;
            txtNombreMensaje.BackColor = SystemColors.Window;
            txtNombreMensaje.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreMensaje.Location = new Point(3, 504);
            txtNombreMensaje.Name = "txtNombreMensaje";
            txtNombreMensaje.PlaceholderText = "Escribe un nombre";
            txtNombreMensaje.Size = new Size(529, 35);
            txtNombreMensaje.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { primerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1071, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // primerToolStripMenuItem
            // 
            primerToolStripMenuItem.Name = "primerToolStripMenuItem";
            primerToolStripMenuItem.Size = new Size(51, 20);
            primerToolStripMenuItem.Text = "Volver";
            primerToolStripMenuItem.Click += primerToolStripMenuItem_Click;
            // 
            // CheckActivo
            // 
            CheckActivo.AutoSize = true;
            CheckActivo.Checked = true;
            CheckActivo.CheckState = CheckState.Checked;
            CheckActivo.Location = new Point(407, -7);
            CheckActivo.Name = "CheckActivo";
            CheckActivo.Size = new Size(119, 41);
            CheckActivo.TabIndex = 1;
            CheckActivo.Text = "Activo";
            CheckActivo.UseVisualStyleBackColor = true;
            // 
            // Mensajes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 573);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Mensajes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mensaje";
            Load += Mensajes_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBImagen).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem primerToolStripMenuItem;
        private PictureBox PBImagen;
        private SplitContainer splitContainer1;
        private Label label1;
        private TextBox txtMensaje;
        private Button btnGuardar;
        private TextBox txtNombreMensaje;
        private CheckBox CheckActivo;
    }
}