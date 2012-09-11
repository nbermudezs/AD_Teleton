using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ParametersForm_Con : System.Web.UI.Page
{

    int centroid;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        //Page.Form.DefaultButton = busqueda.UniqueID;
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;
        centroid = (int)long.Parse(Session["Centro_idNum"].ToString());

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pRepCon"))
            {
                encontroPermiso = true;
                break;
            }
        }

        if (!encontroPermiso)
        {
            //Si no tiene permiso redireccionamos
            //Response.Write("<script>alert('Usted no posee permisos suficientes para accesar a este recurso')</script>");
            Response.Redirect("NoAccess.aspx");
        }

    }
    protected void btnGenerar_Click(object sender, EventArgs e)
    {

        
        int yy = int.Parse(this.txtFechaInicio.Text.Substring(6, 4));
        int mm = int.Parse(this.txtFechaInicio.Text.Substring(3, 2));
        int dd = int.Parse(this.txtFechaInicio.Text.Substring(0, 2));
            DateTime fechaIni = new DateTime(yy, mm, dd);

            yy = int.Parse(this.txtFechaInicio0.Text.Substring(6, 4));
            mm = int.Parse(this.txtFechaInicio0.Text.Substring(3, 2));
            dd = int.Parse(this.txtFechaInicio0.Text.Substring(0, 2));
            DateTime fechaFin = new DateTime(yy, mm, dd);

            if (fechaIni.Subtract(fechaFin).Days <= 0)
            {
                this.Session["RepCon_FechaIni"] = fechaIni;
                this.Session["RepCon_FechaFin"] = fechaFin;
                Response.Redirect("Reporte_Estadisticas_Pacientes.aspx");
            }
            else
                Response.Write("<script>alert('La fecha inicial debe ser menor que la fecha final')</script>");
    }
    protected void btnCleanPage_Click(object sender, EventArgs e)
    {

    }
}