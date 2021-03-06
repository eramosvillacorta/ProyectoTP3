﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using System.Data;
using InnovaSchool.Entity.Result;

namespace InnovaSchool.DAL
{
    public class DPartidoPostulante
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<SP_GE_ListarPartidoPostulante_Result> ListarPartidoPostulante_DAL()
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarPartidoPostulante", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_GE_ListarPartidoPostulante_Result> list = drd.MapToList<SP_GE_ListarPartidoPostulante_Result>();
            drd.Close();

            cn.Close();

            return list;
        }        

        public SP_GE_ListarPartidoPostulanteById_Result ListarPartidoPostulante_DAL(int IdPartido)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarPartidoPostulanteById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdPartido", IdPartido);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_GE_ListarPartidoPostulanteById_Result> list = drd.MapToList<SP_GE_ListarPartidoPostulanteById_Result>();
            drd.Close();

            cn.Close();

            return list.FirstOrDefault();
        }

        public int RegistrarPartidoPostulante_DAL(EPartidoPostulante objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_RegistrarPartido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartidoID", objEN.idPartido);
                cmd.Parameters.AddWithValue("@Nombre", objEN.Nombre);
                cmd.Parameters.AddWithValue("@Estado", objEN.Estado);
                if (objEN.Logo != null) cmd.Parameters.AddWithValue("@Logo", objEN.Logo);                  

                cn.Open();
                var result = cmd.ExecuteScalar();
                cn.Close();
                return int.Parse(result.ToString());
            }
            catch (Exception)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                throw;
            }
        }

        public Dictionary<string, object> SP_ValidarNombrePartido_DAL(string nombre)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_ValidarNombrePartido", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("Cadena", nombre));
                cmd.Parameters.Add(new SqlParameter("TABLA", "gge.PartidoPostulante"));
                cmd.Parameters.Add(new SqlParameter("cncampo", "Nombre"));
                
                var mess = new SqlParameter("mess", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };                
                var iderror = new SqlParameter("iderror", SqlDbType.Int) { Direction = ParameterDirection.Output };
                
                cmd.Parameters.Add(mess);
                cmd.Parameters.Add(iderror);

                cn.Open();
                Dictionary<string, object> obj = new Dictionary<string, object>();

                using(SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    //var result = drd.MapToList<T>();

                    obj["Mensaje"] = (mess.Value == DBNull.Value ? "" : mess.Value.ToString());
                    obj["IdError"] = (iderror.Value == DBNull.Value) ? 0 : Convert.ToInt32(iderror.Value);                  

                    cn.Close();                    
                }
                
                return obj;
            }
            catch (Exception)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                throw;
            }
        }

        public SP_GE_ValidarIntegrantePartido_Result ValidarIntegranteInscrito_DAL(int idAlumno, int anoAcademico)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_ValidarIntegrantePartido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                cmd.Parameters.AddWithValue("@anoAcademico", anoAcademico);

                cn.Open();
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                var result = drd.MapToList<SP_GE_ValidarIntegrantePartido_Result>();

                cn.Close();
                drd.Close();

                return result.FirstOrDefault();
            }
            catch (Exception)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                throw;
            }
        }

        public List<SP_GE_ListarIntegrantesPartido_Result> ListarIntegrantesPartido_DAL(int idPartido)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarIntegrantesPartido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPartido", idPartido);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            var list = drd.MapToList<SP_GE_ListarIntegrantesPartido_Result>();
            drd.Close();

            cn.Close();

            return list;
        }

        public int RegistrarIntegrante_DAL(EIntegrante objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_RegistrarPartidoIntegrante", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAlumno", objEN.idAlumno);
                cmd.Parameters.AddWithValue("@idCargo", objEN.idCargo);
                cmd.Parameters.AddWithValue("@idPartido", objEN.idPartido);                
               
                cn.Open();
                var result = cmd.ExecuteScalar();
                cn.Close();
                return int.Parse(result.ToString());
            }
            catch (Exception)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                throw;
            }
        }

        public int EliminarIntegrantes_DAL(int idPartido)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_EliminarIntegrantesPartido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPartido", idPartido);               

                cn.Open();
                var result = cmd.ExecuteNonQuery();
                cn.Close();
                return result;
            }
            catch (Exception)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                throw;
            }
        }

        public int EliminarPartidoPostulante_DAL(EPartidoPostulante objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_EliminarPartido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartidoID", objEN.idPartido);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cn.Open();
                int n = cmd.ExecuteNonQuery();
                cn.Close();
                return n;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
