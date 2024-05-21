using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static EventosDeportivos.Models.usuario.CsEstructuraUsuario;

namespace EventosDeportivos.Models.usuario
{
    public class CsUsuario
    {
        public ResponseUsuario InsertarUsuario(string idUsuario, string idParticipante, string correo,
            string contraseña)
        {
            ResponseUsuario result = new ResponseUsuario();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "insert into usuario(idUsuario, idParticipante, correo, contraseña) values " +
                    "('" + idUsuario + "' , '" + idParticipante + "', '" + correo + "', '" + contraseña + "' )";

                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Usuario insertado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al insertar usuario: " + ex.Message.ToString();               
            }
            con.Close();
            return result;
        }
        public ResponseUsuario ActualizarUsuario(string idUsuario, string idParticipante, string correo,
                       string contraseña)
        {
            ResponseUsuario result = new ResponseUsuario();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "update usuario set idParticipante = '" + idParticipante + "', correo = '" + correo + "', contraseña = '" + contraseña + "' where idUsuario = '" + idUsuario + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Usuario actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al actualizar usuario: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public ResponseUsuario EliminarUsuario(string idUsuario)
        {
            ResponseUsuario result = new ResponseUsuario();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string query = "delete from usuario where idUsuario = '" + idUsuario + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Usuario eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error al eliminar usuario: " + ex.Message.ToString();
            }
            con.Close();
            return result;
        }
        public DataSet ListarUsuarios()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from usuario ";
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
        public DataSet ObtenerUsuario(string idUsuario)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string query = "select * from usuario where idUsuario = '" + idUsuario + "'";
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