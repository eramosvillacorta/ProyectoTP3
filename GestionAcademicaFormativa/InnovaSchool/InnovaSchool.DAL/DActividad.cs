using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using InnovaSchool.Entity;

namespace InnovaSchool.DAL
{
    public class DActividad
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<EActividad> ListarActividadesCalendario(EActividad EActividad)
        {
            List<EActividad> retval = new List<EActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListarActividadesCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdCalendario", EActividad.IdCalendario));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EActividad
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()),
                            FechaTermino = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader["FechaTermino"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdEmpleado = int.Parse(reader["IdEmpleado"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString(),
                            Tipo = int.Parse(reader["Tipo"].ToString()),
                            Alcance = reader["Alcance"].ToString(),
                            Estado = int.Parse(reader["Estado"].ToString())
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<EActividad> ConsultarActividadCalendarioFiltro(EActividad EActividad)
        {
            List<EActividad> retval = new List<EActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarActividadCalendarioFiltro", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdCalendario", EActividad.IdCalendario));
                cmd.Parameters.Add(new SqlParameter("@Nombre", EActividad.Nombre));
                cmd.Parameters.Add(new SqlParameter("@FecInicio", EActividad.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@FecTermino", EActividad.FechaTermino));
                cmd.Parameters.Add(new SqlParameter("@IdEmpleado", EActividad.IdEmpleado));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EActividad
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()),
                            FechaTermino = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader["FechaTermino"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdEmpleado = int.Parse(reader["IdEmpleado"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString(),
                            Tipo = int.Parse(reader["Tipo"].ToString()),
                            Estado = int.Parse(reader["Estado"].ToString()),
                            Alcance = reader["Alcance"].ToString()
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public int RegistrarActividad(EActividad EActividad, EUsuario EUsuario, ECalendario ECalendario)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EActividad.IdActividad));
                cmd.Parameters.Add(new SqlParameter("@Nombre", EActividad.Nombre));
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", ECalendario.IdAgenda));
                cmd.Parameters.Add(new SqlParameter("@TipoCalendario", ECalendario.Tipo));
                cmd.Parameters.Add(new SqlParameter("@Tipo", EActividad.Tipo));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", EActividad.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@IdEmpleado", EActividad.IdEmpleado));
                cmd.Parameters.Add(new SqlParameter("@Alcance", EActividad.Alcance));
                cmd.Parameters.Add(new SqlParameter("@FecInicio", EActividad.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@FecTermino", EActividad.FechaTermino));
                cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));
                cmd.Parameters.Add(new SqlParameter("@IdNuevaActividad", retval)).Direction = ParameterDirection.Output;
                retval = cmd.ExecuteNonQuery();

                EActividad.IdActividad = Convert.ToInt32(cmd.Parameters["@IdNuevaActividad"].Value);

                foreach (EDetalleActividad itemDetalleActividad in EActividad.ListaDetalleActividad)
                {
                    itemDetalleActividad.IdActividad = EActividad.IdActividad;
                    retval = RegistrarDetalleActividad(itemDetalleActividad, EUsuario);
                }

            }
            cn.Close();
            return retval;
        }

        public int RegistrarDetalleActividad(EDetalleActividad EDetalleActividad, EUsuario EUsuario)
        {
            int retval = 0;
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarDetalleActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EDetalleActividad.IdActividad));
                cmd.Parameters.Add(new SqlParameter("@IdDetalleActividad", EDetalleActividad.IdDetalleActividad));
                cmd.Parameters.Add(new SqlParameter("@Fecha", EDetalleActividad.Fecha));
                cmd.Parameters.Add(new SqlParameter("@horaInicio", EDetalleActividad.HoraInicial));
                cmd.Parameters.Add(new SqlParameter("@horaTermino", EDetalleActividad.HoraTermino));
                //if (EDetalleActividad.Direccion != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@IdAmbiente", EDetalleActividad.IdAmbiente));
                /*else
                    cmd.Parameters.Add(new SqlParameter("@IdAmbiente", 0));*/
                cmd.Parameters.Add(new SqlParameter("@Direccion", EDetalleActividad.Direccion));
                cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));
                retval = cmd.ExecuteNonQuery();
            }
            return retval;
        }

        public List<EDetalleActividad> ConsultarDetalleActividad(EActividad EActividad)
        {
            List<EDetalleActividad> retval = new List<EDetalleActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarDetalleActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EActividad.IdActividad));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EDetalleActividad EDetalleActividad = new EDetalleActividad
                        {
                            IdDetalleActividad = int.Parse(reader["IdDetalleActividad"].ToString()),
                            Fecha = Convert.ToDateTime(reader["Fecha"].ToString()),
                            HoraInicial = Convert.ToDateTime(reader["horaInicio"].ToString()),
                            HoraTermino = Convert.ToDateTime(reader["horaTermino"].ToString()),
                            Direccion = reader["Direccion"].ToString(),
                            IdAmbiente = reader.IsDBNull(5) ? 0 : int.Parse(reader["IdAmbiente"].ToString())
                        };

                        retval.Add(EDetalleActividad);
                    }
                }
            }
            cn.Close();
            return retval;
        }        

        public int VerificarCruceActividad(EActividad EActividad)
        {
            int retval = 0;

            foreach (EDetalleActividad itemDetalleActividad in EActividad.ListaDetalleActividad)
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_VerificarCruceActividad", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdActividad", EActividad.IdActividad));
                    cmd.Parameters.Add(new SqlParameter("@horaInicio", itemDetalleActividad.HoraInicial));
                    cmd.Parameters.Add(new SqlParameter("@horaTermino", itemDetalleActividad.HoraTermino));
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", EActividad.IdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@Alcance", EActividad.Alcance));
                    cmd.Parameters.Add(new SqlParameter("@IDAmbiente", itemDetalleActividad.IdAmbiente));
                    cmd.Parameters.Add(new SqlParameter("@Resultado", retval)).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    retval = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);

                    if (retval != 0)
                    {
                        cn.Close();
                        break;
                    }
                }
                cn.Close();
            }

            return retval;
        }

        public EActividad ConsultarActividadCalendario(EActividad EActividad)
        {
            EActividad retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarActividadCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EActividad.IdActividad));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retval = new EActividad()
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FecInicio"].ToString()),
                            FechaTermino = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader["FecTermino"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdEmpleado = int.Parse(reader["IdEmpleado"].ToString())
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public int EliminarActividad(EActividad EActividad)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_EliminarActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EActividad.IdActividad));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }

        public List<EActividad> ConsultarActividadesAfectadas(EActividad EActividad)
        {
            List<EActividad> retval = new List<EActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarActividadesAfectadas", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FechaInicio", EActividad.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@FechaTermino", EActividad.FechaTermino));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EActividad
                        {
                            IdActividad = int.Parse(reader["idActividad"].ToString())
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }
    }
}
