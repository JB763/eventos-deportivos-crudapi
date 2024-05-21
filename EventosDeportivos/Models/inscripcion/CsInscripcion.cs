using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static EventosDeportivos.Models.inscripcion.CsEstructuraInscripcion;

namespace EventosDeportivos.Models.inscripcion
{
    public class CsInscripcion
    {
        public ResponseInscripcion InsertarInscripcion(string idInscripcion, string idEvento, string idParticipante,
            string idFormaDePago, DateTime fechaIn, DateTime fechaFin)
        {
            ResponseInscripcion result = new ResponseInscripcion();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "INSERT INTO inscripcion(idInscripcion, idEvento, idParticipante, idFormaDePago, fechaIn, fechaFin) " +
                    "values  (@idInscripcion, @idEvento, @idParticipante, @idFormaDePago, @fechaIn, @fechaFin)";
                
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idInscripcion", idInscripcion);
                cmd.Parameters.AddWithValue("@idEvento", idEvento);
                cmd.Parameters.AddWithValue("@idParticipante", idParticipante);
                cmd.Parameters.AddWithValue("@idFormaDePago", idFormaDePago);
                cmd.Parameters.AddWithValue("@fechaIn", fechaIn);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Inscripcion insertada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al insertar inscripcion: " + ex.Message.ToString();               
            }
            con.Close();
            return result;
            
        }
        public ResponseInscripcion ActualizarInscripcion(string idInscripcion, string idEvento, string idParticipante,
                       string idFormaDePago, DateTime fechaIn, DateTime fechaFin)
        {
            ResponseInscripcion result = new ResponseInscripcion();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "UPDATE inscripcion SET idEvento = @idEvento, idParticipante = @idParticipante, " +
                    "idFormaDePago = @idFormaDePago, fechaIn = @fechaIn, fechaFin = @fechaFin WHERE idInscripcion = @idInscripcion";
                
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idInscripcion", idInscripcion);
                cmd.Parameters.AddWithValue("@idEvento", idEvento);
                cmd.Parameters.AddWithValue("@idParticipante", idParticipante);
                cmd.Parameters.AddWithValue("@idFormaDePago", idFormaDePago);
                cmd.Parameters.AddWithValue("@fechaIn", fechaIn);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Inscripcion actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al actualizar inscripcion: " + ex.Message.ToString();               
            }
            con.Close();
            return result;
        }
        public ResponseInscripcion EliminarInscripcion(string idInscripcion)
        {
            ResponseInscripcion result = new ResponseInscripcion();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "DELETE FROM inscripcion WHERE idInscripcion = @idInscripcion";
                
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idInscripcion", idInscripcion);

                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Inscripcion eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al eliminar inscripcion: " + ex.Message.ToString();               
            }
            con.Close();
            return result;
        }
        public DataSet ListarInscripcion()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from inscripcion ";
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
        public DataSet ObtenerInscripcion(string idInscripcion)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from inscripcion where idInscripcion = @idInscripcion";              
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idInscripcion", idInscripcion);
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