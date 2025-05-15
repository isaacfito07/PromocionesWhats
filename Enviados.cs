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
                WHERE a.Fecha = " + "'" + FechaHoy + "'";

            DataTable dt = sql.EjecutarConsulta(queryConsultar);

            GVEnviados.DataSource = dt;

            if (!GVEnviados.Columns.Contains("ActivoCheck"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "ActivoCheck";
                checkColumn.HeaderText = "Activo";
                checkColumn.DataPropertyName = "Activo"; // importante si quieres enlazar directamente
                GVEnviados.Columns.Add(checkColumn);
            }

            foreach (DataGridViewRow row in GVEnviados.Rows)
            {
                if (!row.IsNewRow)
                {
                    var valor = Convert.ToInt32(row.Cells["Activo"].Value);
                    row.Cells["ActivoCheck"].Value = (valor == 1);
                }
            }
            GVEnviados.Columns["Activo"].Visible = false;
            GVEnviados.Columns["Status"].Visible = false;
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

