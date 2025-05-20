using System.Data;



namespace PromWhats
{
    public partial class Enviados : Form
    {
        private SQLiteHelper sql = new SQLiteHelper();

        public Enviados()
        {
            InitializeComponent();
            string FechaHoy = DateTime.Now.ToString("yyyy-MM-dd");

            string queryConsultar = @"SELECT a.idWhatsApp AS id,
        a.Nombre,
        a.Celular,
        a.Status,
        a.Activo,
        b.nombreMensaje AS Mensaje
        FROM WhatsApp a
        INNER JOIN Mensajes b ON a.idMensaje = b.idMensaje 
        WHERE a.Fecha = '" + FechaHoy + "'";

            DataTable dt = sql.EjecutarConsulta(queryConsultar);

            GVEnviados.ReadOnly = false; // <-- HABILITAR edición en general
            GVEnviados.DataSource = dt;

            if (!GVEnviados.Columns.Contains("ActivoCheck"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "ActivoCheck";
                checkColumn.HeaderText = "Activo";
                checkColumn.DataPropertyName = "Activo"; // Enlaza con el campo de la tabla
                checkColumn.ReadOnly = false; // <-- HABILITAR edición en el checkbox
                GVEnviados.Columns.Add(checkColumn);
            }

            // Ya no es necesario asignar manualmente el valor del checkbox si usas DataPropertyName

            GVEnviados.Columns["Activo"].Visible = false;
            GVEnviados.Columns["Status"].Visible = false;

            // Eventos para detectar cambios
            GVEnviados.CellValueChanged += GVEnviados_CellValueChanged;
            GVEnviados.CurrentCellDirtyStateChanged += GVEnviados_CurrentCellDirtyStateChanged;
        }


        private void GVEnviados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (GVEnviados.IsCurrentCellDirty)
            {
                GVEnviados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void GVEnviados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GVEnviados.Columns[e.ColumnIndex].Name == "ActivoCheck")
            {
                DataGridViewRow row = GVEnviados.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["id"].Value); // "id" viene del SELECT
                object valorCelda = row.Cells["ActivoCheck"].Value;
                bool nuevoValor = false;
                if (valorCelda != DBNull.Value && valorCelda != null)
                {
                    nuevoValor = Convert.ToBoolean(valorCelda);
                }
                int valorSQL = nuevoValor ? 1 : 0;

                string queryUpdate = $"UPDATE WhatsApp SET Activo = {valorSQL} WHERE idWhatsApp = {id}";
                sql.EjecutarComando(queryUpdate);
            }
        }


        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

