using AccesoDatos.Abstract;
using AccesoDatos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatos : AbstractDatos
    {
        public List<ReponseSearch> ObtenerResultladosBusqueda(string prmBusqueda)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("BusquedaInicial", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Agregar parámetros (si es necesario)
                    command.Parameters.AddWithValue("@Descripcion", prmBusqueda);
                    List<ReponseSearch> lstResponse = new List<ReponseSearch>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Procesar los resultados (si es necesario)
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            ReponseSearch response = new ReponseSearch();
                            response.IdInventario = Convert.ToInt32(reader["IdInventario"]);
                            response.Foto = reader["FOTO"].ToString();
                            response.Item = reader["ITEM"].ToString();
                            response.Precio = Convert.ToInt32(reader["PRECIO"]);
                            response.Observaciones = reader["Observaciones"].ToString();
                            response.Personalizado10 = reader["Personalizado10"].ToString();
                            response.Personalizado11 = reader["Personalizado11"].ToString();
                            response.Principal = reader["PRI"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PRI"]); 
                            response.Bombatex = reader["BOM"] == DBNull.Value ? 0: Convert.ToInt32(reader["BOM"]);
                            response.Arreglos = reader["ARR"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ARR"]);
                            response.Ricaurte = reader["RIC"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RIC"]); 
                            response.Separados = reader["PRO"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PRO"]); 
                            response.TotalBodegas = reader["TOT"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TOT"]);
                            response.Grupo_Dos = reader["Grupo_Dos"].ToString();
                            response.Grupo_Tres = reader["Grupo_Tres"].ToString();
                            response.Grupo_Cuatro = reader["Grupo_Cuatro"].ToString();
                            response.Personalizado1 = reader["Personalizado1"].ToString();
                            response.Personalizado2 = reader["Personalizado2"].ToString();
                            response.Personalizado3 = reader["Personalizado3"].ToString();
                            response.Personalizado4 = reader["Personalizado4"].ToString();
                            response.Personalizado5 = reader["Personalizado5"].ToString();
                            response.Personalizado7 = reader["Personalizado7"].ToString();
                            response.Activo = Convert.ToBoolean(reader["Activo"]);

                            lstResponse.Add(response);
                        }
                    }
                    return lstResponse;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            

        }

    }
}
