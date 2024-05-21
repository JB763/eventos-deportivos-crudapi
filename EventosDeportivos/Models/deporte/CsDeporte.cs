using EventosDeportivos.Models.formaDePago;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using static EventosDeportivos.Models.deporte.CsEstructuraDeporte;

namespace EventosDeportivos.Models.deporte
{
    public class CsDeporte
    {
        public ResponseDeporte InsertarDeporte(string idDeporte, string tipoDeporte, string categoria)
        {
            ResponseDeporte result = new ResponseDeporte();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "insert into deporte(idDeporte, tipoDeporte, categoria) values " +
                    "('" + idDeporte + "' , '" + tipoDeporte + "', '" + categoria + "' )";

                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Deporte insertado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al insertar deporte: " + ex.Message.ToString();

            }
            con.Close();
            return result;
        }
        public ResponseDeporte ActualizarDeporte(string idDeporte, string tipoDeporte, string categoria)
        {
            ResponseDeporte result = new ResponseDeporte();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "update deporte set tipoDeporte = '" + tipoDeporte + "', categoria = '" + categoria + "' where idDeporte = '" + idDeporte + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Deporte actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al actualizar deporte: " + ex.Message.ToString();

            }
            con.Close();
            return result;
        }
        public ResponseDeporte EliminarDeporte(string idDeporte)
        {
            ResponseDeporte result = new ResponseDeporte();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "delete from deporte where idDeporte = '" + idDeporte + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Deporte eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al eliminar deporte: " + ex.Message.ToString();

            }
            con.Close();
            return result;
        }
        public DataSet ListarDeportes()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {               
                string query = "select * from deporte";
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
        public DataSet ObtenerDeporte(string idDeporte)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            try
            {
                string query = "select * from deporte where idDeporte = '" + idDeporte + "'";
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
