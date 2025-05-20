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
            const int MAX_RETRIES = 3;
            const int DELAY_MS = 200;

            for (int intento = 1; intento <= MAX_RETRIES; intento++)
            {
                try
                {
                    using var conexion = new SqliteConnection(_cadenaConexion);
                    conexion.Open();

                    using var comando = conexion.CreateCommand();
                    comando.CommandText = sql;

                    return comando.ExecuteNonQuery();
                }
                catch (SqliteException ex) when (ex.SqliteErrorCode == 5)
                {
                    if (intento == MAX_RETRIES)
                        throw; // si ya lo intentaste varias veces, relanza la excepción

                    Thread.Sleep(DELAY_MS); // espera un poco antes de reintentar
                }
            }

            return 0; // no debería llegar aquí
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
