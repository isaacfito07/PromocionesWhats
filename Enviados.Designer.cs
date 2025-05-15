namespace PromWhats
{
    partial class Enviados
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
            btnVolverInicio = new ToolStripMenuItem();
            toolStripContainer1 = new ToolStripContainer();
            GVEnviados = new DataGridView();
            menuStrip1.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GVEnviados).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnVolverInicio });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnVolverInicio
            // 
            btnVolverInicio.Name = "btnVolverInicio";
            btnVolverInicio.Size = new Size(64, 20);
            btnVolverInicio.Text = "← Volver";
            btnVolverInicio.Click += btnVolverInicio_Click;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(GVEnviados);
            toolStripContainer1.ContentPanel.Size = new Size(884, 412);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 24);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(884, 437);
            toolStripContainer1.TabIndex = 2;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // GVEnviados
            // 
            GVEnviados.AllowUserToAddRows = false;
            GVEnviados.AllowUserToDeleteRows = false;
            GVEnviados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            GVEnviados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GVEnviados.Dock = DockStyle.Fill;
            GVEnviados.Location = new Point(0, 0);
            GVEnviados.Name = "GVEnviados";
            GVEnviados.ReadOnly = true;
            GVEnviados.RowHeadersVisible = false;
            GVEnviados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GVEnviados.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GVEnviados.Size = new Size(884, 412);
            GVEnviados.TabIndex = 0;
            // 
            // Enviados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 461);
            Controls.Add(toolStripContainer1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(900, 500);
            MinimumSize = new Size(816, 489);
            Name = "Enviados";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mensajes Enviados";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GVEnviados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem btnVolverInicio;
        private ToolStripContainer toolStripContainer1;
        private DataGridView GVEnviados;
    }
}
