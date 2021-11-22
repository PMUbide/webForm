using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class busqueda_actualizar : System.Web.UI.Page
{
    String cadenaConexion = "Database='bicis'; DataSource='localhost'; User Id='root'; Password='12345678'";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void botonBuscar(object sender, EventArgs e)
    {

        using (MySqlConnection conexionBD = new MySqlConnection(this.cadenaConexion))
        {
            //Creamos String con la consulta
            String sqlquery = "select * from usuario where id_user= " + CodPersona.Text;

            //ejecutamos la consulta
            MySqlDataAdapter da = new MySqlDataAdapter(sqlquery, conexionBD);

            DataSet ds = new DataSet();
            da.Fill(ds, "DatosPersona"); //Le ponemos como nombre datopersona

            //la consulta esta condicionada al campo codigo
            //utilizamos un objeto nuevo: viewState que es como una variable global
            ViewState["consulta"] = sqlquery;
            ViewState["dataset"] = ds;

            if (ds.Tables["DatosPersona"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["DatosPersona"].Rows[0];
                nombre.Text = dr["nombre"].ToString();
                mensaje.ForeColor = System.Drawing.Color.Blue;
                mensaje.Text = "Usuario Encontrado";
            }
            else
            {
                nombre.Text = "";
                mensaje.ForeColor = System.Drawing.Color.Red;
                mensaje.Text = "usuario no encontrado";
            }
        }


    }
    protected void botonActualizar(object sender, EventArgs e)
    {
        using (MySqlConnection conexionBD = new MySqlConnection(this.cadenaConexion))
        {
            MySqlDataAdapter da = new MySqlDataAdapter((string)ViewState["consulta"], conexionBD);

            MySqlCommandBuilder builder = new MySqlCommandBuilder(da);

            DataSet ds = (DataSet)ViewState["dataset"];

            if (ds.Tables["DatosPersona"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["DatosPersona"].Rows[0];
                dr["nombre"] = nombre.Text;
            }

            //Realizamos el update de bbdd, nos devuelve las filas que han sido actualizadas
            int filasActualizadas = da.Update(ds, "DatosPersona");


            if (filasActualizadas > 0)
            {
                mensaje.ForeColor = System.Drawing.Color.Green;
                mensaje.Text = "Persona Actualizada";

            }
            else
            {
                mensaje.ForeColor = System.Drawing.Color.Red;
                mensaje.Text = "Error en actualización";
            }

        }

    }
}