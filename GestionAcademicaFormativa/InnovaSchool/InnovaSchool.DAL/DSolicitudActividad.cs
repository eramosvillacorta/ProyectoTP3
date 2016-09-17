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
    public class DSolicitudActividad
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public int RegistrarSolicitudActividad(ESolicitudActividad ESolicitudActividad, EUsuario EUsuario, ECalendario ECalendario)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarSolicitudActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdSolicitudActividad", ESolicitudActividad.IdSolicitudActividad));
                cmd.Parameters.Add(new SqlParameter("@Nombre", ESolicitudActividad.EActividad.Nombre));
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", ECalendario.IdAgenda));
                cmd.Parameters.Add(new SqlParameter("@TipoCalendario", ECalendario.Tipo));
                cmd.Parameters.Add(new SqlParameter("@Tipo", ESolicitudActividad.EActividad.Tipo));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", ESolicitudActividad.EActividad.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Motivo", ESolicitudActividad.Motivo));
                cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ESolicitudActividad.EActividad.IdEmpleado));
                cmd.Parameters.Add(new SqlParameter("@Alcance", ESolicitudActividad.EActividad.Alcance));
                cmd.Parameters.Add(new SqlParameter("@FecInicio", ESolicitudActividad.EActividad.FecInicio));
                cmd.Parameters.Add(new SqlParameter("@FecTermino", ESolicitudActividad.EActividad.FecTermino));                                
                cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));
                cmd.Parameters.Add(new SqlParameter("@IdActividad", retval)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@NuevaIdSolicitud", retval)).Direction = ParameterDirection.Output;
                retval = cmd.ExecuteNonQuery();
                ESolicitudActividad.EActividad.IdActividad = Convert.ToInt32(cmd.Parameters["@IdActividad"].Value);
                ESolicitudActividad.IdSolicitudActividad = Convert.ToInt32(cmd.Parameters["@NuevaIdSolicitud"].Value);

                foreach (EDetalleActividad itemDetalleActividad in ESolicitudActividad.EActividad.ListaDetalleActividad)
                {
                    itemDetalleActividad.IdActividad = ESolicitudActividad.EActividad.IdActividad;
                    retval = RegistrarDetalleSolicitudActividad(itemDetalleActividad, EUsuario);
                }
            }
            cn.Close();
            return retval;
        }

        public int RegistrarDetalleSolicitudActividad(EDetalleActividad EDetalleActividad, EUsuario EUsuario)
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
                if (EDetalleActividad.IdAmbiente != 0)
                    cmd.Parameters.Add(new SqlParameter("@IdAmbiente", EDetalleActividad.IdAmbiente));
                else
                    cmd.Parameters.Add(new SqlParameter("@IdAmbiente", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Direccion", EDetalleActividad.Direccion));
                cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));
                retval = cmd.ExecuteNonQuery();
            }
            return retval;
        }

        public int VerificarCruceSolicitudActividad(ESolicitudActividad ESolicitudActividad)
        {
            int retval = 0;

            foreach (EDetalleActividad itemDetalleActividad in ESolicitudActividad.EActividad.ListaDetalleActividad)
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_VerificarCruceSolicitudActividad", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdSolicitudActividad", ESolicitudActividad.IdSolicitudActividad));
                    cmd.Parameters.Add(new SqlParameter("@horaInicio", itemDetalleActividad.HoraInicial));
                    cmd.Parameters.Add(new SqlParameter("@horaTermino", itemDetalleActividad.HoraTermino));
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ESolicitudActividad.EActividad.IdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@Alcance", ESolicitudActividad.EActividad.Alcance));
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

        public int EnviarSolicitudActividad(ESolicitudActividad ESolicitudActividad)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_EnviarSolicitudActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdSolicitudActividad", ESolicitudActividad.IdSolicitudActividad));                
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }

        public List<ESolicitudActividad> ListarSolicitudesAgenda(EAgenda EAgenda, EUsuario EUsuario)
        {
            List<ESolicitudActividad> retval = new List<ESolicitudActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListarSolicitudesAnio", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", EAgenda.IdAgenda));
                cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ESolicitudActividad ESolicitudActividad = new ESolicitudActividad
                        {
                            IdSolicitudActividad = int.Parse(reader["IDSolicitudActividad"].ToString()),
                            Motivo = reader["Motivo"].ToString(),
                            Estado = int.Parse(reader["Estado"].ToString()),
                            Tipo = reader["TipoCalendario"].ToString(),
                        };

                        EActividad EActividad = new EActividad
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),   
                            Nombre = reader["Nombre"].ToString(),
                            Tipo = int.Parse(reader["TipoActividad"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            Alcance = reader["Alcance"].ToString(),
                            FecInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()),
                            FecTermino = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader["FechaTermino"].ToString()),
                            IdEmpleado = int.Parse(reader["IdEmpleado"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString()                        
                        };

                        ESolicitudActividad.EActividad = EActividad;
                        retval.Add(ESolicitudActividad);                       
                    }
                }
            }
            cn.Close();
            return retval;
        }        

        public List<ESolicitudActividad> ListarSolicitudesPendientesAgenda(EAgenda EAgenda)
        {
            List<ESolicitudActividad> retval = new List<ESolicitudActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListarSolicitudesPendientesAnio", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", EAgenda.IdAgenda));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ESolicitudActividad ESolicitudActividad = new ESolicitudActividad
                        {
                            IdSolicitudActividad = int.Parse(reader["IDSolicitudActividad"].ToString()),
                            Motivo = reader["Motivo"].ToString(),
                            Tipo = reader["TipoCalendario"].ToString()
                        };

                        EActividad EActividad = new EActividad
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            Tipo = int.Parse(reader["TipoActividad"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            Alcance = reader["Alcance"].ToString(),
                            FecInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()),
                            FecTermino = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader["FechaTermino"].ToString()),
                            IdEmpleado = int.Parse(reader["IdEmpleado"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString(),
                            Solicitante = reader["Solicitante"].ToString(),
                        };

                        ESolicitudActividad.EActividad = EActividad;
                        retval.Add(ESolicitudActividad);
                    }
                }
            }
            cn.Close();
            return retval;
        }        
    }
}
