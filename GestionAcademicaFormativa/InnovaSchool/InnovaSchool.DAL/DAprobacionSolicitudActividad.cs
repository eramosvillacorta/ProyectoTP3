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
    public class DAprobacionSolicitudActividad
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public int RegistrarAprobacionSolicitudActividad(EAprobacionSolicitudActividad EAprobacionSolicitudActividad, EUsuario EUsuario, int IdEmpleado)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarAprobacionSolicitudActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdSolicitudActividad", EAprobacionSolicitudActividad.IdSolicitudActividad));
                cmd.Parameters.Add(new SqlParameter("@IdEmpleado", IdEmpleado));                
                cmd.Parameters.Add(new SqlParameter("@Observacion", EAprobacionSolicitudActividad.Observacion));
                cmd.Parameters.Add(new SqlParameter("@Estado", EAprobacionSolicitudActividad.Estado));
                cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }
    }
}
