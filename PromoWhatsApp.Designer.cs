namespace PromWhats
{
    partial class PromoWhats
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
            btnCargaExcel = new ToolStripMenuItem();
            mensajesPersonalizadosToolStripMenuItem = new ToolStripMenuItem();
            toolStripContainer1 = new ToolStripContainer();
            GVExcel = new DataGridView();
            menuStrip1.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GVExcel).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnCargaExcel, mensajesPersonalizadosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnCargaExcel
            // 
            btnCargaExcel.Name = "btnCargaExcel";
            btnCargaExcel.Size = new Size(84, 20);
            btnCargaExcel.Text = "Cargar Excel";
            btnCargaExcel.Click += btnCargaExcel_Click;
            // 
            // mensajesPersonalizadosToolStripMenuItem
            // 
            mensajesPersonalizadosToolStripMenuItem.Name = "mensajesPersonalizadosToolStripMenuItem";
            mensajesPersonalizadosToolStripMenuItem.Size = new Size(149, 20);
            mensajesPersonalizadosToolStripMenuItem.Text = "Mensajes Personalizados";
            mensajesPersonalizadosToolStripMenuItem.Click += mensajesPersonalizadosToolStripMenuItem_Click;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(GVExcel);
            toolStripContainer1.ContentPanel.Size = new Size(800, 401);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 24);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(800, 426);
            toolStripContainer1.TabIndex = 2;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // GVExcel
            // 
            GVExcel.AllowUserToAddRows = false;
            GVExcel.AllowUserToDeleteRows = false;
            GVExcel.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            GVExcel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GVExcel.Dock = DockStyle.Fill;
            GVExcel.Location = new Point(0, 0);
            GVExcel.Name = "GVExcel";
            GVExcel.ReadOnly = true;
            GVExcel.RowHeadersVisible = false;
            GVExcel.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GVExcel.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GVExcel.Size = new Size(800, 401);
            GVExcel.TabIndex = 0;
            // 
            // PromoWhats
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
            Name = "PromoWhats";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Promociones WhatsApp";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GVExcel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem btnCargaExcel;
        private ToolStripContainer toolStripContainer1;
        private DataGridView GVExcel;
        private ToolStripMenuItem mensajesPersonalizadosToolStripMenuItem;
    }
}
