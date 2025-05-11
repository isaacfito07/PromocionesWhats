namespace PromWhats
{
    partial class ListaMensajes
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            btnVolver = new ToolStripMenuItem();
            agregarUnoNuevoToolStripMenuItem = new ToolStripMenuItem();
            toolStripContainer1 = new ToolStripContainer();
            CBEstado = new ComboBox();
            GVListaMensajes = new DataGridView();
            menuStrip1.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GVListaMensajes).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnVolver, agregarUnoNuevoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnVolver
            // 
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(92, 20);
            btnVolver.Text = "Volver a inicio";
            btnVolver.Click += btnVolver_Click;
            // 
            // agregarUnoNuevoToolStripMenuItem
            // 
            agregarUnoNuevoToolStripMenuItem.Name = "agregarUnoNuevoToolStripMenuItem";
            agregarUnoNuevoToolStripMenuItem.Size = new Size(121, 20);
            agregarUnoNuevoToolStripMenuItem.Text = "Agregar uno nuevo";
            agregarUnoNuevoToolStripMenuItem.Click += agregarUnoNuevoToolStripMenuItem_Click;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(CBEstado);
            toolStripContainer1.ContentPanel.Controls.Add(GVListaMensajes);
            toolStripContainer1.ContentPanel.Size = new Size(800, 401);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 24);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(800, 426);
            toolStripContainer1.TabIndex = 2;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // CBEstado
            // 
            CBEstado.FormattingEnabled = true;
            CBEstado.Items.AddRange(new object[] { "Activos", "Inactivos" });
            CBEstado.Location = new Point(667, 3);
            CBEstado.Name = "CBEstado";
            CBEstado.Size = new Size(121, 23);
            CBEstado.TabIndex = 1;
            CBEstado.Text = "Activos";
            CBEstado.SelectedValueChanged += CBEstado_SelectedValueChanged;
            // 
            // GVListaMensajes
            // 
            GVListaMensajes.AllowUserToAddRows = false;
            GVListaMensajes.AllowUserToDeleteRows = false;
            GVListaMensajes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            GVListaMensajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GVListaMensajes.Dock = DockStyle.Fill;
            GVListaMensajes.Location = new Point(0, 0);
            GVListaMensajes.Name = "GVListaMensajes";
            GVListaMensajes.ReadOnly = true;
            GVListaMensajes.RowHeadersVisible = false;
            GVListaMensajes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GVListaMensajes.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GVListaMensajes.Size = new Size(800, 401);
            GVListaMensajes.TabIndex = 0;
            GVListaMensajes.CellClick += GVListaMensajes_CellClick;
            // 
            // ListaMensajes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStripContainer1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "ListaMensajes";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Promociones WhatsApp";
            Load += ListaMensajes_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GVListaMensajes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem btnVolver;
        private ToolStripContainer toolStripContainer1;
        private ComboBox CBEstado;
        private DataGridView GVListaMensajes;
        private ToolStripMenuItem agregarUnoNuevoToolStripMenuItem;
    }
}
