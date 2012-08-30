using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Web.UI.HtmlControls;
using BL;
using System.Data;
using System.Text;
using System.IO;
/*using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;*/
public partial class Reporte_Genero : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
            pacientes = new BL.SeguimientoPacientes();


            List<string> permisos = (List<string>)Session["Permisos_usuario"];
            bool permisoEncontrado = false;
            Paciente pac = new Paciente();

            foreach (string rol in permisos)
            {
                if (rol.Equals("pRepGen"))
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
           
        //RadioButtonList1.SelectedIndex = 0;

    }
    BL.SeguimientoPacientes pacientes;
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.Items[0].Selected)
            {
                //Response.Redirect("/Reporte_Genero.aspx?op=0");
                gvreportegenero.DataSource = pacientes.Busqueda_pacientes(true, DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFinal.Text));
                //RadioButtonList1.SelectedIndex = 0;
                gvreportegenero.DataBind();
            }
            else if (RadioButtonList1.Items[1].Selected)
            {
                //Response.Redirect("/Reporte_Genero.aspx?op=1");
                gvreportegenero.DataSource = pacientes.Busqueda_pacientes(false, DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFinal.Text));
                //RadioButtonList1.SelectedIndex = 0;
                gvreportegenero.DataBind();
            }
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.StackTrace;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        exportToExcel("Export.xls", gvreportegenero);
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