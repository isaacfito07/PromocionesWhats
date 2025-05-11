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
        private SQLiteHelper sql = new SQLiteHelper();
        private bool noEsImagenInicial = false;
        private int idMensaje = 0;
        public Mensajes(int _idMensaje = 0)
        {
            InitializeComponent();
            this.idMensaje = _idMensaje;
        }

        private void Mensajes_Load(object sender, EventArgs e)
        {
            PBImagen.AllowDrop = true;

            if (this.idMensaje != 0)
            {
                string query = "select * from Mensajes WHERE idMensaje = " + this.idMensaje;
                DataTable dt = this.sql.EjecutarConsulta(query);

                foreach(DataRow r in dt.Rows)
                {
                    txtNombreMensaje.Text = r["nombreMensaje"].ToString();
                    txtMensaje.Text = r["cuerpoMensaje"].ToString();

                    // Verificar si el archivo existe
                    if (r["rutaImagen"].ToString() != string.Empty)
                    {
                        if (File.Exists(r["rutaImagen"].ToString()))
                        {
                            // Cargar la imagen y asignarla al PictureBox
                            PBImagen.Image = Image.FromFile(r["rutaImagen"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("El archivo de imagen no existe o esta corrompido.");
                        }
                    }

                    CheckActivo.Checked = Convert.ToInt32(r["Activo"]) == 1;

                    break;
                }
                noEsImagenInicial = true;
            }
            else
            {
                CheckActivo.Visible = false;
            }
        }

        private void PBImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PBImagen.Image = Image.FromFile(openFileDialog.FileName);
                noEsImagenInicial = true;
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
                noEsImagenInicial = true;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreMensaje.Text == string.Empty)
            {
                MessageBox.Show("Ingresa un nombre a tu mensaje para identificarlo");
                return;
            }
            string nombreMensaje = txtNombreMensaje.Text;

            string rutaImagen = string.Empty;
            if (noEsImagenInicial) {
                // Ruta base
                string carpetaDestino = @"C:\ImagenesPromoWhatsApp";

                // Crear la carpeta si no existe
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                // Generar un nombre aleatorio usando GUID
                string nombreArchivo = Guid.NewGuid().ToString() + ".jpg";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);
                rutaImagen = rutaCompleta;

                // Guardar la imagen
                PBImagen.Image.Save(rutaCompleta, System.Drawing.Imaging.ImageFormat.Jpeg);

            }

            string cuerpoMensaje = txtMensaje.Text;
            int idEstado = CheckActivo.Checked ? 1 : 0;

            string queryMensaje = @"
                    INSERT INTO Mensajes (
                         nombreMensaje,
                         rutaImagen,
                         cuerpoMensaje,
                         Activo
                     )" +
                     "VALUES (" +
                         "'" + nombreMensaje + "'," +
                         "'" + rutaImagen + "'," +
                         "'" + cuerpoMensaje + "'," +
                         "" + idEstado + "" +
                     ");";

            if(this.idMensaje != 0)
            {
                queryMensaje = @"UPDATE Mensajes SET " +
                    "nombreMensaje = '" + nombreMensaje + "', " +
                    "rutaImagen = '" + rutaImagen + "', " +
                    "cuerpoMensaje = '" + cuerpoMensaje + "', " +
                    "Activo = " + idEstado + " " +
                "WHERE idMensaje = " + this.idMensaje;
            }

            SQLiteHelper sql = new SQLiteHelper();
            int correcto = sql.EjecutarComando(queryMensaje);

            if (correcto > 0)
            {
                MessageBox.Show("Mensaje Guardado Correctamente","Guardado Correctamente",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
