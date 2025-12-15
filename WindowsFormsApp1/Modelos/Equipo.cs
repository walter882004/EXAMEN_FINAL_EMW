using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Modelos
{
    internal class Equipo
    {
        public static DataTable Obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                using (SqlConnection conn = cnn.Conectar())
                {
                    cnn.Conectar();
                    string query = "SELECT * FROM Equipos";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable equiposTable = new DataTable();
                    adapter.Fill(equiposTable);
                    return equiposTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener equipos:\n" + ex.Message);
                return null;
            }

            finally
            {
                cnn.Desconectar();
            }
        }
    }
}
