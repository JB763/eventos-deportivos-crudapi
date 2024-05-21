using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static EventosDeportivos.Models.participante.CsEstructuraParticipante;
namespace EventosDeportivos.Models.participante
{
    public class CsParticipante
    {
        public ResponseParticipante InsertarParticipante(string idParticipante, string nombre,
            string apellido, string sexo, int edad, string telefono)
        {
            ResponseParticipante result = new ResponseParticipante();
            string conexion = "";
            SqlConnection con = null;
            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();
                string query = "insert into participante(idParticipante, nombre, apellido, sexo, edad, telefono) values " +
                    "('" + idParticipante + "' , '" + nombre + "', '" + apellido + "', '" + sexo + "', " + edad + ", '" + telefono + "' )";
                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Participante insertado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al insertar participante: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public ResponseParticipante ActualizarParticipante(string idParticipante, string nombre,
                       string apellido, string sexo, int edad, string telefono)
        {
            ResponseParticipante result = new ResponseParticipante();
            string conexion = "";
            SqlConnection con = null;
            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();
                string query = "update participante set nombre = '" + nombre + "', apellido = '" + apellido + "', sexo = '" + sexo + "', edad = " + edad + ", telefono = '" + telefono + "' where idParticipante = '" + idParticipante + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Participante actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al actualizar participante: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public ResponseParticipante EliminarParticipante(string idParticipante)
        {
            ResponseParticipante result = new ResponseParticipante();
            string conexion = "";
            SqlConnection con = null;
            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();
                string query = "delete from participante where idParticipante = '" + idParticipante + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Participante eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al eliminar participante: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public DataSet ListarParticipantes()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from participante";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "Lista";
                return dsi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ObtenerParticipante(string idParticipante)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from participante where idParticipante = '" + idParticipante + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "Lista";
                return dsi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}