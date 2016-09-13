using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.DAL
{
    public class DEmpleado
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<EEmpleado> ListarResponsable(EEmpleado EEmpleado)
        {
            List<EEmpleado> retval = new List<EEmpleado>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListarResponsable", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Alcance", EEmpleado.IdPuesto));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EEmpleado
                        {
                            IdEmpleado = int.Parse(reader["IdEmpleado"].ToString()),
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<EEmpleado> ListarResponsableSemana(EEmpleado EEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            List<EEmpleado> retval = new List<EEmpleado>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListarResponsableSemana", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Alcance", EEmpleado.IdPuesto));
                cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
                cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EEmpleado
                        {
                            IdEmpleado = int.Parse(reader["IdEmpleado"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            HorasAsignadas = int.Parse(reader["Horas"].ToString())
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }        
    }
}
