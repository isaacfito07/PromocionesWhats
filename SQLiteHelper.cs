using Microsoft.Data.Sqlite;
using System.Data;

namespace PromWhats
{
    public class SQLiteHelper
    {
        private readonly string _cadenaConexion;

        public SQLiteHelper()
        {
            _cadenaConexion = AppConfig.GetConnectionString("MiConexion");
        }

        // SELECT → Devuelve tabla de resultados
        public DataTable EjecutarConsulta(string sql)
        {
            var tabla = new DataTable();

            using var conexion = new SqliteConnection(_cadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = sql;

            using var lector = comando.ExecuteReader();
            tabla.Load(lector);
            conexion.Close();

            return tabla;
        }

        // INSERT, UPDATE, DELETE → No devuelven resultados
        public int EjecutarComando(string sql)
        {
            using var conexion = new SqliteConnection(_cadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = sql;

            // Devuelve número de filas afectadas
            int Rows = comando.ExecuteNonQuery();
            conexion.Close();
            return Rows;
        }

        // Devuelve un valor escalar (ej: COUNT, MAX, etc.)
        public object EjecutarEscalar(string sql)
        {
            using var conexion = new SqliteConnection(_cadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = sql;
            var Obj = comando.ExecuteScalar();
            conexion.Close();

            return Obj;
        }
    }
}
