using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static EventosDeportivos.Models.premiacion.CsEstructuraPremiacion;

namespace EventosDeportivos.Models.premiacion
{
    public class CsPremiacion
    {
        public ResponsePremiacion InsertarPremiacion(string idPremiacion, string idEvento,
    int posicion, string descripcion, DateTime fecha)
        {
            ResponsePremiacion result = new ResponsePremiacion();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "INSERT INTO Premiacion (idPremiacion, idEvento, posicion, descripcion, fecha) " +
                    "VALUES (@idPremiacion, @idEvento, @posicion, @descripcion, @fecha)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idPremiacion", idPremiacion);
                cmd.Parameters.AddWithValue("@idEvento", idEvento);
                cmd.Parameters.AddWithValue("@posicion", posicion);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Premiacion insertada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al insertar Premiacion: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public ResponsePremiacion ActualizarPremiacion(string idPremiacion, string idEvento,
                       int posicion, string descripcion, DateTime fecha)
        {
            ResponsePremiacion result = new ResponsePremiacion();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "UPDATE Premiacion SET idEvento = @idEvento, posicion = @posicion, descripcion = @descripcion, fecha = @fecha " +
                    "WHERE idPremiacion = @idPremiacion";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idPremiacion", idPremiacion);
                cmd.Parameters.AddWithValue("@idEvento", idEvento);
                cmd.Parameters.AddWithValue("@posicion", posicion);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Premiacion actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al actualizar Premiacion: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public ResponsePremiacion EliminarPremiacion(string idPremiacion)
        {
            ResponsePremiacion result = new ResponsePremiacion();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "DELETE FROM Premiacion WHERE idPremiacion = @idPremiacion";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idPremiacion", idPremiacion);

                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Premiacion eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al eliminar Premiacion: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public DataSet ListarPremiacion()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from premiacion ";
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
        public DataSet ObtenerPremiacion(string idPremiacion)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from premiacion where idPremiacion = @idPremiacion ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idPremiacion", idPremiacion);
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