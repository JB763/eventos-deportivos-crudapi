using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using static EventosDeportivos.Models.formaDePago.CsEstructuraFormaDePago;

namespace EventosDeportivos.Models.formaDePago
{
    public class CsFormaDePago
    {
        public ResponseFormaDePago InsertarFormaDePago(string idFormaDePago, string tipoPago)
        {
            ResponseFormaDePago result = new ResponseFormaDePago();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "insert into formaDePago(idFormaDePago, tipoPago) values " +
                    "('" + idFormaDePago + "' , '" + tipoPago + "')";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Forma de pago insertada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al insertar la forma de pago: " + ex.Message.ToString();

            }
            con.Close();
            return result;
        }
        public ResponseFormaDePago ActualizarFormaDePago(string idFormaDePago, string tipoPago)
        {
            ResponseFormaDePago result = new ResponseFormaDePago();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "update formaDePago set tipoPago = '" + tipoPago + "' where idFormaDePago = '" + idFormaDePago + "'";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Forma de pago actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al actualizar la forma de pago: " + ex.Message.ToString();

            }
            con.Close();
            return result;

        }
        public ResponseFormaDePago EliminarFormaDePago(string idFormaDePago)
        {
            ResponseFormaDePago result = new ResponseFormaDePago();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "delete from formaDePago where idFormaDePago = '" + idFormaDePago + "'";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Forma de pago eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al eliminar la forma de pago: " + ex.Message.ToString();

            }
            con.Close();
            return result;
        }
        public DataSet ListarFormaDePago()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            try
            {
                string cadena = "select * from formaDePago";
                SqlCommand cmd = new SqlCommand(cadena, con);
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
        public DataSet ObtenerFormaDePago(string idFormaDePago)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            try
            {
                string cadena = "select * from formaDePago where idFormaDePago = '" + idFormaDePago + "'";
                SqlCommand cmd = new SqlCommand(cadena, con);
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