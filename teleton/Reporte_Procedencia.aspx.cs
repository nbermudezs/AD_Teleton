﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Nestor Bermudez 05/08/2012
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

public partial class Reporte_Procedencia : System.Web.UI.Page
{
    private HSSFWorkbook Libro;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<string> permisos = (List<string>)Session["Permisos_usuario"];
            bool permisoEncontrado = false;
            Paciente pac = new Paciente();

            foreach (string rol in permisos)
            {
                if (rol.Equals("pRepPro"))
                {
                    permisoEncontrado = true;
                    break;
                }
            }

            if (!permisoEncontrado)
            {
                //Si no tiene permiso redirecciona
                Response.Redirect("NoAccess.aspx");
            }

            if (!IsPostBack) {
                cargarProcedencia();
            }

            ceFechaFinal.SelectedDate = DateTime.Now;
            ceFechaInicio.SelectedDate = DateTime.Now;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    private void cargarProcedencia() {
        BL.SeguimientoPacientes sp = new SeguimientoPacientes();
        List<string> procs = sp.GetProcedencias();
        foreach (string pro in procs)
            ddlProcedencia.Items.Add(pro);
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
        exportToExcel("Export_Procedencias.xls", gvProcedencia);
    }

    protected void btEjecutar_Click(object sender, EventArgs e)
    {
        try
        {
            SeguimientoPacientes segPacientes = new SeguimientoPacientes();
            int centroId = (int)long.Parse(Session["Centro_idNum"].ToString());

            gvProcedencia.DataSource = segPacientes.BusquedaporProcedencia(ddlProcedencia.Text,
                DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFinal.Text), centroId);
            gvProcedencia.DataBind();

            btExportar.Visible = true;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
}