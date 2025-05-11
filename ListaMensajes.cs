using ClosedXML.Excel;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PromWhats
{
    public partial class ListaMensajes : Form
    {
        private SQLiteHelper sql = new SQLiteHelper();
        public ListaMensajes()
        {
            InitializeComponent();
        }
        private void ListaMensajes_Load(object sender, EventArgs e)
        {
            int idEstadoActivo = 1;

            string query = "select idMensaje AS id, nombreMensaje AS Nombre, IIF(Activo = 1, 'Activo', 'Inactivo') AS Status from Mensajes WHERE Activo =" + idEstadoActivo;
            DataTable dt = sql.EjecutarConsulta(query);
            GVListaMensajes.DataSource = dt;

            if (!GVListaMensajes.Columns.Contains("btnAccion"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "btnAccion";
                btnCol.HeaderText = "";
                btnCol.Text = "Editar";
                btnCol.UseColumnTextForButtonValue = true; // Usa el mismo texto en cada botón
                GVListaMensajes.Columns.Add(btnCol);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            int idEstado = ((string)CBEstado.Text == "Activos" ? 1 : 0);

            string query = "select idMensaje AS id, nombreMensaje AS Nombre, IIF(Activo = 1, 'Activo', 'Inactivo') AS Status from Mensajes WHERE Activo =" + idEstado;
            DataTable dt = sql.EjecutarConsulta(query);
            GVListaMensajes.DataSource = dt;
            if (!GVListaMensajes.Columns.Contains("btnAccion"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "btnAccion";
                btnCol.HeaderText = "";
                btnCol.Text = "Editar";
                btnCol.UseColumnTextForButtonValue = true; // Usa el mismo texto en cada botón
                GVListaMensajes.Columns.Add(btnCol);
            }
        }

        private void agregarUnoNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensajes msg = new Mensajes();
            msg.ShowDialog();
        }

        private void GVListaMensajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == GVListaMensajes.Columns["btnAccion"].Index)
            {
                // Aquí puedes acceder a los datos de la fila
                var fila = GVListaMensajes.Rows[e.RowIndex];
                string idMensaje = fila.Cells["id"].Value.ToString(); // o el campo que necesites

                Mensajes msg = new Mensajes(Convert.ToInt32(idMensaje));
                msg.ShowDialog();
            }
        }
    }
}
