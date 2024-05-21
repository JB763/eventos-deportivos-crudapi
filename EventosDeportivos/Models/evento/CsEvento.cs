using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static EventosDeportivos.Models.evento.CsEstructuraEvento;

namespace EventosDeportivos.Models.evento
{
    public class CsEvento
    {
        public ResponseEvento InsertarEvento(string idEvento, string idDeporte, string nombre, DateTime FechaIn,
            DateTime FechaFin, double costo, int cupo)
        {
            ResponseEvento result = new ResponseEvento();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "INSERT INTO Evento (idEvento, idDeporte, nombre, FechaIn, FechaFin, costo, cupo) " +
                    "VALUES (@idEvento, @idDeporte, @nombre, @FechaIn, @FechaFin, @costo, @cupo)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idEvento", idEvento);
                cmd.Parameters.AddWithValue("@idDeporte", idDeporte);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@FechaIn", FechaIn);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.Parameters.AddWithValue("@costo", costo);
                cmd.Parameters.AddWithValue("@cupo", cupo);
              
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Evento insertado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al insertar Evento: " + ex.Message.ToString();

            }
            con.Close();
            return result;
        }
        public ResponseEvento ActualizarEvento(string idEvento, string idDeporte, string nombre,
            DateTime fechaIn, DateTime fechaFin, double costo, int cupo)
        {
            ResponseEvento result = new ResponseEvento();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "UPDATE Evento SET idDeporte = @idDeporte, nombre = @nombre, FechaIn = @FechaIn, " +
                    "FechaFin = @FechaFin, costo = @costo, cupo = @cupo WHERE idEvento = @idEvento";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idEvento", idEvento);
                cmd.Parameters.AddWithValue("@idDeporte", idDeporte);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@FechaIn", fechaIn);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@costo", costo);
                cmd.Parameters.AddWithValue("@cupo", cupo);

                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Evento actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al actualizar Evento: " + ex.Message.ToString();
            }
            con.Close();
            return result;

        }
        public ResponseEvento EliminarEvento(string idEvento)
        {
            ResponseEvento result = new ResponseEvento();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "DELETE FROM Evento WHERE idEvento = @idEvento";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idEvento", idEvento);

                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Evento eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al eliminar Evento: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public DataSet ListarEvento()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from evento";
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
        public DataSet ObtenerEvento(string idEvento)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from evento where idEvento = @idEvento";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idEvento", idEvento);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "Evento";
                return dsi;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}