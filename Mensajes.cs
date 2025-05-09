using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromWhats
{
    public partial class Mensajes : Form
    {
        public Mensajes()
        {
            InitializeComponent();
        }

        private void Mensajes_Load(object sender, EventArgs e)
        {
            PBImagen.AllowDrop = true;
        }

        private void PBImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PBImagen.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void PBImagen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && EsArchivoDeImagen(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PBImagen_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && EsArchivoDeImagen(files[0]))
            {
                PBImagen.Image = Image.FromFile(files[0]);
            }
        }

        private bool EsArchivoDeImagen(string ruta)
        {
            string ext = Path.GetExtension(ruta).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
        }

        private void primerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
