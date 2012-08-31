using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

using System.Web.UI.HtmlControls;
using BL;
using System.Data;
using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;


public partial class ReporteEdades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<string> permisos = (List<string>)Session["Permisos_usuario"];
            bool permisoEncontrado = false;
            //Paciente pac = new Paciente();

            foreach (string rol in permisos)
            {
                if (rol.Equals("pRepEdades"))
                {
                    permisoEncontrado = true;
                    break;
                }
            }

            if (!permisoEncontrado)
            {
                //Si no tiene permiso redireccionamos
                //Response.Write("<script>alert('Usted no posee permisos suficientes para accesar a este recurso')</script>");
                Response.Redirect("NoAccess.aspx");
            }

          /*  if (!IsPostBack)
            {
                if (!pac.isDoctor(Session.Contents["nombre_usuario"].ToString()))
                    cargarDoctores();
                else
                    cargarDoctor();
            }*/

            ceFechaFinal.SelectedDate = DateTime.Now;
            ceFechaInicio.SelectedDate = DateTime.Now;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message+"\n"+error.StackTrace;
            Response.Redirect("~/Error.aspx", true);
        }
         
    }
    protected void btEjecutar_Click(object sender, EventArgs e)
    {
        try
        {
            SeguimientoPacientes segPacientes = new SeguimientoPacientes();
            int centroId = (int)long.Parse(Session["Centro_idNum"].ToString());

            int yy = int.Parse(this.txtFechaInicio.Text.Substring(6, 4));
            int mm = int.Parse(this.txtFechaInicio.Text.Substring(3, 2));
            int dd = int.Parse(this.txtFechaInicio.Text.Substring(0, 2));
            DateTime fechaIni = new DateTime(yy, mm, dd);

            yy = int.Parse(this.txtFechaFinal.Text.Substring(6, 4));
            mm = int.Parse(this.txtFechaFinal.Text.Substring(3, 2));
            dd = int.Parse(this.txtFechaFinal.Text.Substring(0, 2));
            DateTime fechaFin = new DateTime(yy, mm, dd);

            gvSeguimientoPaciente.DataSource = segPacientes.BusquedaporEdades(fechaIni, fechaFin , centroId,edadfecha(Convert.ToInt32(edad1.Text)),edadfecha(Convert.ToInt32(edad2.Text)));
            gvSeguimientoPaciente.DataBind();

            btExportar.Visible = true;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }

    }
    private DateTime edadfecha(int edad) 
    {
            
            DateTime hoy = DateTime.Today;
            DateTime nacfech= (hoy.AddDays(-365*edad));
            return nacfech;
    }

    private void exportToExcel(string nameReport, GridView fuente)
    {
        HttpResponse response = Response;
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page pageToRender = new Page();
        HtmlForm form = new HtmlForm();
        form.Controls.Add(fuente);
        pageToRender.Controls.Add(form);
        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
        response.Charset = "UTF-8";
        response.ContentEncoding = Encoding.Default;
        pageToRender.RenderControl(htw);
        response.Write(sw.ToString());
        response.End();
    }
    protected void btExportar_Click(object sender, EventArgs e)
    {
        exportToExcel("Export.xls", gvSeguimientoPaciente);
    }
}