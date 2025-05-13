using ClosedXML.Excel;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace PromWhats
{
    public partial class PromoWhats : Form
    {
        private SQLiteHelper sql = new SQLiteHelper();
        private bool cancelarProceso = false;

        public PromoWhats()
        {
            InitializeComponent();
            dETENERPROCESOToolStripMenuItem.Visible = false;
        }

        private void mensajesPersonalizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaMensajes listaMensajes = new ListaMensajes();
            listaMensajes.ShowDialog();
        }

        private void cargarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            openFileDialog.Title = "Seleccionar archivo de Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                using (var workbook = new XLWorkbook(rutaArchivo))
                {
                    var hoja = workbook.Worksheets.Worksheet(1); // Primera hoja
                    DataTable dataTable = new DataTable();

                    bool primeraFila = true;
                    foreach (var fila in hoja.RowsUsed())
                    {
                        if (primeraFila)
                        {
                            // Crear columnas a partir de la primera fila
                            foreach (var celda in fila.Cells())
                                dataTable.Columns.Add(celda.Value.ToString());
                            primeraFila = false;
                        }
                        else
                        {
                            // Agregar datos
                            var dataRow = dataTable.NewRow();
                            int i = 0;
                            foreach (var celda in fila.Cells(1, dataTable.Columns.Count))
                            {
                                dataRow[i++] = celda.Value;
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                    }

                    DataTable dt = this.sql.EjecutarConsulta("select * from Mensajes WHERE Activo = 1");
                    if (dt.Rows.Count > 0)
                    {
                        dataTable.Columns.Add("idMensaje");
                        dataTable.Columns.Add("Mensaje");
                        dataTable.Columns.Add("rutaImagen");
                        dataTable.Columns.Add("cuerpoMensaje");

                        foreach (DataRow r in dataTable.Rows)
                        {
                            Random rand = new Random();
                            int index = rand.Next(dt.Rows.Count);
                            DataRow randomRow = dt.Rows[index];

                            r["idMensaje"] = randomRow["idMensaje"];
                            r["Mensaje"] = randomRow["nombreMensaje"];
                            r["rutaImagen"] = randomRow["rutaImagen"];
                            r["cuerpoMensaje"] = randomRow["cuerpoMensaje"];
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen  mensajes Activos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dataTable.Columns.Add("Status");
                    GVExcel.ColumnHeadersDefaultCellStyle.Font = new Font(
                        GVExcel.Font,
                        FontStyle.Bold
                    );
                    GVExcel.DataSource = dataTable;
                    GVExcel.Columns["idMensaje"].Visible = false;
                    GVExcel.Columns["rutaImagen"].Visible = false;
                    GVExcel.Columns["cuerpoMensaje"].Visible = false;

                    GVExcel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    GVExcel.AllowUserToResizeRows = false;
                    GVExcel.AllowUserToAddRows = false;

                    foreach (DataGridViewColumn column in GVExcel.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }

                MessageBox.Show("Archivo cargado correctamente", "Excel Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void eJECUTARToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (GVExcel.Rows.Count < 1)
            {
                MessageBox.Show("Carga un excel antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Se va iniciar el proceso de envio, ¿deseas continuar? (Recuerda tener WhatsApp Web abierto)", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.TopMost = true;
                cancelarProceso = false;

                string FechaHoy = DateTime.Now.ToString("yyyy-MM-dd");

                dETENERPROCESOToolStripMenuItem.Visible = true;
                foreach (DataGridViewRow row in GVExcel.Rows)
                {
                    if (cancelarProceso)
                    {
                        MessageBox.Show("Proceso detenido por el usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dETENERPROCESOToolStripMenuItem.Visible = false;
                        this.TopMost = false;
                        return;
                    }

                    if (!row.IsNewRow)
                    {
                        string querySelect = "SELECT * FROM WhatsApp WHERE Celular = '" + row.Cells["CELULAR"].Value + "' AND Fecha = '" + FechaHoy + "'";
                        DataTable dtConsula = this.sql.EjecutarConsulta(querySelect);

                        if (dtConsula.Rows.Count > 0)
                        {
                            row.Cells["Status"].Value = "ENVIADO HOY";
                        }
                        else
                        {

                            string numero = "52" + row.Cells["CELULAR"].Value?.ToString();
                            string mensaje = row.Cells["cuerpoMensaje"].Value?.ToString();

                            Clipboard.SetText(mensaje);

                            string url = "https://api.whatsapp.com/send?phone=" + numero + "&text=" + "" + "&type=phone_number&app_absent=0";

                            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                            {
                                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                            }
                            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                            {
                                Process.Start("xdg-open", url);
                            }
                            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                            {
                                Process.Start("open", url);
                            }

                            await Task.Delay(5000);
                            SendKeys.Send("{ENTER}");
                            await Task.Delay(5000);
                            SendKeys.Send("^v");

                            string RutaImagen = row.Cells["rutaImagen"].Value.ToString();
                            if (!string.IsNullOrEmpty(RutaImagen))
                            {
                                using (Image img = Image.FromFile(RutaImagen))
                                {
                                    Clipboard.SetImage(img);
                                }
                                await Task.Delay(5000);
                                SendKeys.Send("^v");
                                await Task.Delay(5000);
                            }

                            SendKeys.Send("{ENTER}");
                            row.Cells["Status"].Value = "ENVIADO";

                            string queryInsert = @"INSERT INTO WhatsApp (
                            Nombre,
                            Celular,
                            Status,
                            idMensaje,
                            Mensaje,
                            Activo,
                            Fecha
                            )
                            VALUES (" +
                                "'" + row.Cells["NOMBRE (S)"].Value + "'," +
                                "'" + row.Cells["CELULAR"].Value + "'," +
                                "'ENVIADO'," +
                                row.Cells["idMensaje"].Value + "," +
                                "'" + row.Cells["Mensaje"].Value + "'," +
                                "1," +
                                "'" + FechaHoy + "');";

                            this.sql.EjecutarComando(queryInsert);
                            await Task.Delay(5000);

                            foreach (var process in Process.GetProcessesByName("chrome"))
                            {
                                process.Kill();
                            }
                            await Task.Delay(5000);
                        }
                    }
                }

                this.TopMost = false;
                dETENERPROCESOToolStripMenuItem.Visible = false;
                DialogResult R = MessageBox.Show("Proceso terminado correctamente, ¿Desea Exportar a Excel?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (R == DialogResult.Yes)
                {
                    ExportarAExcel(GVExcel);
                }
            }
        }

        private void dETENERPROCESOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cancelarProceso = true;
        }

        private void ExportarAExcel(DataGridView dgv)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet worksheet = excelApp.ActiveSheet;

            int colIndex = 0;

            // Encabezados de columnas visibles
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    colIndex++;
                    var headerCell = worksheet.Cells[1, colIndex];
                    headerCell.Value = dgv.Columns[i].HeaderText;
                    headerCell.Font.Bold = true; // ?? Negrita
                }
            }

            // Filas con columnas visibles
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                colIndex = 0;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Visible)
                    {
                        colIndex++;
                        var cell = worksheet.Cells[i + 2, colIndex];
                        cell.NumberFormat = "@"; // ?? Formato texto
                        cell.Value = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }
            }

            // Ajustar ancho de columnas y alto de filas automáticamente
            worksheet.Columns.AutoFit(); // ?? Ajusta ancho columnas
            worksheet.Rows.AutoFit();    // ?? Ajusta alto de filas

            excelApp.Visible = true;
        }



        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GVExcel.Rows.Count < 1)
            {
                MessageBox.Show("Carga un excel antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExportarAExcel(GVExcel);
        }
    }
}

