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
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;

public partial class ReporteNuevoSubsecuente : System.Web.UI.Page
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
            if (rol.Equals("pSegPac"))
            {
                permisoEncontrado = true;
                break;
            }
        }
        if (!permisoEncontrado)
        {
            Response.Redirect("NoAccess.aspx");
        }

        if (!IsPostBack)
        {
            cargarDoctores();
        }

        ceFechaFinal.SelectedDate = DateTime.Now;
        ceFechaInicio.SelectedDate = DateTime.Now;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message+"\n"+error.StackTrace;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    private void cargarDoctores()
    {
        try
        {
            BL.Empleados doctores = new BL.Empleados();
            Usuarios usuarios = new Usuarios();
            Paciente pac = new Paciente();

            List<string> usuariosTemp = usuarios.RetrieveUserNames();
            List<string> usersDocs = new List<string>();
            List<long> ids = new List<long>();
            List<string> nombres = new List<string>();
            List<string> apellido = new List<string>();
            List<string> segundoApellido = new List<string>();

            foreach (string doc in usuariosTemp)
            {
                if (pac.isDoctor(doc))
                {
                    ids.Add(usuarios.retriveEmpId(doc));
                    usersDocs.Add(doc);
                }
            }

            foreach (long codigo in ids)
            {
                nombres.Add(doctores.obtenerNombresDoctores(codigo));
                apellido.Add(doctores.obtenerApellidoDoctores(codigo));
                segundoApellido.Add(doctores.obtenerSegundoApellidoDoctores(codigo));
            }

            ListItem temporal = new ListItem();
            temporal.Text = "--- Todos ---";
            temporal.Value = "todos";
            temporal.Selected = true;
            ddlDoctor.Items.Add(temporal);

            for (int i = 0; i < nombres.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = nombres[i] + " " + apellido[i] + " " + segundoApellido[i];
                item.Value = usersDocs[i].ToString();
                ddlDoctor.Items.Add(item);
            }
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
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


    protected void btEjecutar_Click(object sender, EventArgs e)
    {
        try
        {
            SeguimientoPacientes segPacientes = new SeguimientoPacientes();
            int centroId = (int)long.Parse(Session["Centro_idNum"].ToString());

            gvReporteNSPaciente.DataSource = segPacientes.ReportarNuevoSubsecuente(DateTime.Parse("2012/05/29"), DateTime.Parse("2012/09/14"), centroId, ddlDoctor.SelectedValue, rbList.SelectedValue);
            gvReporteNSPaciente.DataBind();


            btExportar.Visible = true;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }


    protected void btExportar_Click1(object sender, EventArgs e)
    {
        exportToExcel("Export.xls", gvReporteNSPaciente);
    }
 
}