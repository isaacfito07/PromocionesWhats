using ClosedXML.Excel;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PromWhats
{
    public partial class PromoWhats : Form
    {
        public PromoWhats()
        {
            InitializeComponent();
        }


        private void btnCargaExcel_Click(object sender, EventArgs e)
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
                    dataTable.Columns.Add("Status");
                    GVExcel.ColumnHeadersDefaultCellStyle.Font = new Font(
                        GVExcel.Font,
                        FontStyle.Bold
                    );
                    GVExcel.DataSource = dataTable;
                    GVExcel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    GVExcel.AllowUserToResizeRows = false;
                    GVExcel.AllowUserToAddRows = false;

                    foreach (DataGridViewColumn column in GVExcel.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }

                MessageBox.Show("Archivo seleccionado:\n" + rutaArchivo);

            }
        }

        private void mensajesPersonalizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Mensajes mensajes = new Mensajes();
            mensajes.ShowDialog();*/

            ListaMensajes listaMensajes = new ListaMensajes();
            listaMensajes.ShowDialog();
        }
    }
}
