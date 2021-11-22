using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Caching;
using System.Data;
using MySql.Data.MySqlClient;

//Para convertir a csv
using System.Text;

public partial class carga_volcado : System.Web.UI.Page
{
    String cadenaConexion = "Database='practica_xml'; DataSource='localhost'; User Id='root'; Password=''";
    protected void Page_Load(object sender, EventArgs e)
    {





    }

    //Método para leer el XML
    protected void leeXML(object sender, EventArgs e)
    {
        using (MySqlConnection conexionBD = new MySqlConnection(this.cadenaConexion))
        {
            //cremos dataset
            DataSet ds = new DataSet();
            //leemos el xml
            ds.ReadXml(Server.MapPath("~/datos/XMLFile.xml"));
            //DataTable dt_provincia = ds.Tables["Provincia"];
            DataTable dt_persona = ds.Tables["Persona"];
            if (dt_persona.Rows.Count > 0)
            {
                mensaje.ForeColor = System.Drawing.Color.Blue;
                mensaje.Text = "XML leído Encontrado";
            }
            ViewState["dataset"] = ds;
            //ViewState["dt_provincia"] = dt_provincia;
            ViewState["dt_persona"] = dt_persona;
        }

    }

    //vuelca con csv y bulk
    protected void convierteCSV(object sender, EventArgs e)
    {

        DataTable tabla = (DataTable)ViewState["dt_persona"];

        StringBuilder sb = new StringBuilder();

        IEnumerable<string> columnNames = tabla.Columns.Cast<DataColumn>().
                                          Select(column => column.ColumnName);
        sb.AppendLine(string.Join("\t", columnNames));

        foreach (DataRow row in tabla.Rows)
        {
            IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
            sb.AppendLine(string.Join("\t", fields));
        }

        File.WriteAllText(Server.MapPath("~/datos/csvFile.csv"), sb.ToString());

        //string tempCsvFileSpec = @"C:\dam_pablo\actividadMier\practica\practica\datos\csvFile.csv";

        using (MySqlConnection conexionBD = new MySqlConnection(this.cadenaConexion))
        { 
            var bl = new MySqlBulkLoader(conexionBD)
            {
                Local = true,
                TableName = "persona",
                Timeout = 600,
                FieldTerminator = "\t",
                LineTerminator = "\n",
                FileName = Server.MapPath("~/datos/XMLFile.xml"),
                NumberOfLinesToSkip = 1
            };
            var numberOfInsertedRows = bl.Load();


            /*bl.Local = true;
            bl.TableName = "persona";
            bl.FieldTerminator = "\t";
            bl.LineTerminator = "\n";
            bl.FileName = Server.MapPath("~/datos/XMLFile.xml");
            bl.NumberOfLinesToSkip = 1;
            int count = bl.Load();
            System.IO.File.Delete(tempCsvFileSpec);*/
        
        
        }



    }




    protected void vuelcaXML(object sender, EventArgs e)
    {
        try
        {

            String Command = "INSERT INTO persona (id, DNI, Nombre, Provincia) VALUES (@id, @DNI, @Nombre, @Provincia);";

            using (MySqlConnection conn = new MySqlConnection(this.cadenaConexion))
            {

                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    using (MySqlCommand myCmd = new MySqlCommand(Command, conn, trans))
                    {
                        DataTable tabla = (DataTable)ViewState["dt_persona"];
                        foreach (DataRow fila in tabla.Rows)
                        {
                            myCmd.CommandType = CommandType.Text;
                            myCmd.Parameters.Clear();
                            myCmd.Parameters.AddWithValue("@id", fila[3]);
                            myCmd.Parameters.AddWithValue("@DNI", fila[0].ToString());
                            myCmd.Parameters.AddWithValue("@Nombre", fila[1].ToString());
                            myCmd.Parameters.AddWithValue("@Provincia", fila[2].ToString());
                            myCmd.ExecuteNonQuery();
                        }
                        //inserting items
                        trans.Commit();

                    }

                }


            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}








