using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



//Agregados
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




public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<string> permisos = (List<string>)Session["Permisos_usuario"];
            bool permisoEncontrado = false;
            Paciente pac = new Paciente();

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

            

            ceFechaFinal.SelectedDate = DateTime.Now;
            ceFechaInicio.SelectedDate = DateTime.Now;
            cargarInstrucciones();
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.StackTrace;
            Response.Redirect("~/Error.aspx", true);
        }
    }


    


    private void cargarInstrucciones()
    {
        try
        {
            BL.Empleados doctores = new BL.Empleados();
            BL.Paciente instrucciones = new BL.Paciente();
            DataTable escolaridades = instrucciones.cargarEscolaridad();

            ddEscolaridad.DataSource = escolaridades;

            ddEscolaridad.DataTextField = "GRADO";
            ddEscolaridad.DataValueField = "ID";
            ddEscolaridad.DataBind();
     


        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }




    protected void btEjecutar_Click(object sender, EventArgs e)
    {
        try
        {

           

            SeguimientoPacientes segPacientes = new SeguimientoPacientes();
            int centroId = (int)long.Parse(Session["Centro_idNum"].ToString());
            gvSeguimientoPaciente.DataSource = segPacientes.BusquedaPorInstruccion(DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFinal.Text), centroId,int.Parse(ddEscolaridad.SelectedValue));
            gvSeguimientoPaciente.DataBind();

            btExportar.Visible = true;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void btExportar_Click(object sender, EventArgs e)
    {
        exportToExcel("Export.xls", gvSeguimientoPaciente);
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
}