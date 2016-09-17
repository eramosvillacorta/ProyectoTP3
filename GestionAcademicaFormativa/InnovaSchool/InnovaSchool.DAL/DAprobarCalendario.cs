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
    public class DAprobarCalendario
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<EAprobarCalendario> ListaAprobarCalendarioExtra(ECalendario eCalendario)
        {
            List<EAprobarCalendario> retval = new List<EAprobarCalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListaAprobarCalendarioExtra", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", int.Parse(eCalendario.IdAgenda)));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EAprobarCalendario
                        {
                            idMes = int.Parse(reader["idMes"].ToString()),
                            Mes = reader["Mes"].ToString(),
                            ActCulturales = int.Parse(reader["ActCulturales"].ToString()),
                            HorasCulturales = int.Parse(reader["HorasCulturales"].ToString()),
                            ActDeportivas = int.Parse(reader["ActDeportivas"].ToString()),
                            HorasDeportivas = int.Parse(reader["HorasDeportivas"].ToString()),
                            ActRecreativas = int.Parse(reader["ActRecreativas"].ToString()),
                            HorasRecreativas = int.Parse(reader["HorasRecreativas"].ToString()),
                            TotalActividades = int.Parse(reader["TotalActividades"].ToString()),
                            TotalHoras = int.Parse(reader["TotalHoras"].ToString()),

                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<EAprobarCalendario> ListadoActividades(EAprobarCalendario eAprobarCalendario)
        {
            List<EAprobarCalendario> retval = new List<EAprobarCalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListadoActividades", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", int.Parse(eAprobarCalendario.idagenda)));
                cmd.Parameters.Add(new SqlParameter("@mes", eAprobarCalendario.idMes));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EAprobarCalendario
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),
                            TipoActividad = reader["TipoActividad"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Responsable = reader["Responsable"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()),
                            FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()),
                            Estado = reader["Estado"].ToString(),
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }
        public int ActualizarEstadoActividad(EAprobarCalendario eAprobarCalendario)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ActualizarEstadoActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idactividad", eAprobarCalendario.IdActividad));
                cmd.Parameters.Add(new SqlParameter("@estado", int.Parse(eAprobarCalendario.Estado)));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }

        public int ActualizarEstadoCalendario(EAprobarCalendario eAprobarCalendario)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ActualizarEstadoCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idcalendario", int.Parse(eAprobarCalendario.idcalendario)));
                cmd.Parameters.Add(new SqlParameter("@estado", int.Parse(eAprobarCalendario.Estado)));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }

        public List<EAprobarCalendario> ActividadPrincipal(EAprobarCalendario eAprobarCalendario)
        {
            List<EAprobarCalendario> retval = new List<EAprobarCalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ActividadPrincipal", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", eAprobarCalendario.IdActividad));
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EAprobarCalendario
                        {
                            Nombre = reader["Nombre"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()),
                            FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()),
                            Responsable = reader["Responsable"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Alcance = reader["Alcance"].ToString(),
                            Tipo = reader["Tipo"].ToString(),
                            Estado = reader["Estado"].ToString(),
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<EAprobarCalendario> DetalleActividad(EAprobarCalendario eAprobarCalendario)
        {
            List<EAprobarCalendario> retval = new List<EAprobarCalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_DetalleActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", eAprobarCalendario.IdActividad));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EAprobarCalendario
                        {
                            Fecha = Convert.ToDateTime(reader["Fecha"].ToString()),
                            HoraInicial = Convert.ToDateTime(reader["horaInicio"].ToString()),
                            HoraTermino = Convert.ToDateTime(reader["horaTermino"].ToString()),
                            Direccion = reader["Direccion"].ToString(),
                            Ubicacion = reader["Ubicacion"].ToString(),
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<EAprobarCalendario> VerificarAprobarCalendario(EAprobarCalendario eAprobarCalendario)
        {
            List<EAprobarCalendario> retval = new List<EAprobarCalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_VerificarAprobarCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idagenda", int.Parse(eAprobarCalendario.idagenda)));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EAprobarCalendario
                        {
                            TotalActividades = int.Parse(reader["Total"].ToString()),
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }
        public List<EAprobarCalendario> CalendarioActual()
        {
            List<EAprobarCalendario> retval = new List<EAprobarCalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_CalendarioActual", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EAprobarCalendario
                        {
                            idagenda = reader["IdAgenda"].ToString(),
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }
    }
}
