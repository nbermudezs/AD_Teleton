﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Data;


public partial class HistoPacienteFrame : System.Web.UI.Page
{

    private BL.Paciente PAT = new BL.Paciente();
    private BL.Security Sec = new BL.Security();
    private BL.Permiso Per = new BL.Permiso();
    private static string _strUsuario = "";
    private static int _intExpe = 0;
    private static short _shtPrefijo = 0;
    private static DataTable dt_Hist;
    private static int centro;
    private static int area;
    private static string usuario_logeado;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["expediente"] != null && (string)Session["expediente"] != string.Empty && Session["centro"] != null && (string)Session["centro"] != string.Empty)
        {
            ddl_centro.Text = Session["centro"].ToString();
            txt_buscar.Text = Session["expediente"].ToString();
           
            Session.Remove("centro");
            Session.Remove("expediente");
            cargar_Historial();
        }
       //txtid.Text = Request.QueryString["id"];
       Session["id"] = Request.QueryString["id"];
       //txtid.Text = Session["id"].ToString();*/
        List<String> listaPermisos = Per.getPermisosID();
        bool encontroPermiso = false;
        

        if (PAT.isDoctor(Session["nombre_usuario"].ToString()))
        {

        
        Session["id"] = Request.QueryString["id"];
        if (Session["id"] != null)
        {
            string tmp = Sec.getNameArea(Convert.ToInt32(Request.QueryString["id"]));
            foreach (String strPermiso in listaPermisos)
            {
                //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
                if (strPermiso.Contains(tmp.ToLower()))
                {
                    encontroPermiso = true;
                    break;
                }
            }

            if (!encontroPermiso)
            {
                btn_guardar.Visible = false;
            }
            else
            {
                btn_guardar.Visible = true;
            }

            lb_area.Visible = true;
            lb_area0.Visible = true;
            lb_area.Text = tmp;
            lb_area0.Text = "Area: ";
        }

        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        cargar_Historial();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Usted no posee suficientes privilegios')", true);
        }
    }

    private void cargar_Historial()
    {


        if (Session["expediente"] != null && (string)Session["expediente"] != string.Empty && Session["centro"] != null && (string)Session["centro"] != string.Empty)
            {
                if (Session["id"] != null)
                {
                    try
                    {
                        centro = Convert.ToInt32(Sec.getCentroId(Session["centro"].ToString()));
                        area = Convert.ToInt32(Session["id"].ToString());
                        usuario_logeado = Session["nombre_usuario"].ToString();
                        string expediente = Session["expediente"].ToString();
                        _intExpe = Convert.ToInt32(expediente);
                        string str_temp = expediente;
                        int int_temp = Convert.ToInt32(expediente);
                        string[] str_Inf = new string[2];
                        str_Inf = PAT.nombrePaciente(Convert.ToInt32(expediente), centro);

                        if (str_Inf != null && (str_Inf[0] != null && str_Inf[1] != null))
                        {
                            _strUsuario = str_Inf[0];
                            _shtPrefijo = Convert.ToInt16(str_Inf[1].ToString());
                            if (str_Inf[0] != "")
                            {
                                lb_Paciente.Text = str_Inf[0];
                                dt_Hist = PAT.historial(Convert.ToInt32(expediente), centro, area);
                                if (dt_Hist != null)
                                {
                                    lb_area.Visible = true;
                                    lb_area0.Visible = true;
                                    lb_Expe.Text = "Num. Expe: " + expediente;
                                    lb_area.Text = Sec.getNameArea(Convert.ToInt32(Session["id"].ToString()));
                                    lb_area0.Text = "Area: ";
                                    _intExpe = Convert.ToInt32(expediente);
                                    grd_Historial.DataSource = dt_Hist;
                                    grd_Historial.DataBind();
                                    txt_historial.Enabled = true;
                                    btn_guardar.Enabled = true;
                                }
                                else
                                {
                                    lb_Paciente.Text = "Error al obtener el Historial ...";
                                    txt_historial.Enabled = false;
                                    lb_Expe.Text = "";
                                    btn_guardar.Enabled = false;
                                }
                            }
                            else
                            {
                                lb_Paciente.Text = "Expediente no encontrado ...";
                                txt_historial.Enabled = false;
                                lb_Expe.Text = "";
                                btn_guardar.Enabled = false;
                                dt_Hist = null;
                                grd_Historial.DataBind();
                            }
                        }
                        else
                        {
                            lb_Paciente.Text = "Error al obtener el paciente ...\nAsegúrese que el paciente este en el centro en el que se registro.";
                            //txt_buscar = "";
                            txt_historial.Text = "";
                            txt_historial.Enabled = false;
                            btn_guardar.Enabled = false;
                            lb_Expe.Text = "";
                            dt_Hist = null;
                            grd_Historial.DataBind();
                        }
                    }
                    catch
                    {
                        lb_Paciente.Text = "Error, Tarea no Realizada";
                        txt_historial.Enabled = false;
                        lb_Expe.Text = "";
                        btn_guardar.Enabled = false;
                        dt_Hist = null;
                        grd_Historial.DataBind();
                    }
                }
                else
                {
                    lb_Paciente.Text = "Seleccione un Área...";
                    txt_historial.Enabled = false;
                    lb_Expe.Text = "";
                    btn_guardar.Enabled = false;
                    dt_Hist = null;
                    grd_Historial.DataBind();
                }
            }
            else
            {
                lb_Paciente.Text = "Introduzca un expediente a buscar ...";
                txt_historial.Enabled = false;
                lb_Expe.Text = "";
                btn_guardar.Enabled = false;
                dt_Hist = null;
                grd_Historial.DataBind();
            }

    }

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        if (btn_guardar.Text == "Nuevo")
        {
            txt_historial.ReadOnly = false;
            txt_historial.Font.Bold = false;
            txt_historial.Text = "";
            btn_guardar.Text = "Guardar";
        }
        else
        {
            try
            {
                if (Session["id"] != string.Empty)
                {
                   
                    if (!PAT.guardarHistorial(DateTime.Now, _intExpe, Session["nombre_usuario"].ToString()
                        , txt_historial.Text, _shtPrefijo, Convert.ToInt32(Session["id_empleado"].ToString()), Convert.ToInt32(Session["id"].ToString())))
                    {
                        lb_Paciente.Text = "Error al tratar de guardar ...";
                    }
                    else
                    {
                        txt_historial.Text = "";
                        lb_Expe.Text = "";
                        lb_Paciente.Text = "";
                        cargar_Historial();

                    }
                }
                else
                {
                    lb_Paciente.Text = "Error...";
                }
            }
            catch
            {
                lb_Paciente.Text = "Excepción al tratar de guardar ...";
            }
        }
    }
    protected void grd_Historial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Historial.PageIndex = e.NewPageIndex;
            grd_Historial.DataSource = dt_Hist;
            grd_Historial.DataBind();
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void Ver_Click(object sender, EventArgs e)
    {
       try
        {
            GridViewRow gdv_Hist = (GridViewRow)((ImageButton)sender).Parent.Parent;
            int int_Index = gdv_Hist.RowIndex + (grd_Historial.PageIndex * grd_Historial.PageSize);
            string str_TMP = dt_Hist.Rows[int_Index][3].ToString();
            string histopart = dt_Hist.Rows[int_Index][3].ToString();
            txt_historial.Text = PAT.LeerHistorial(_intExpe,_shtPrefijo,usuario_logeado,area,histopart);
            txt_historial.ReadOnly = true;
            txt_historial.Font.Bold = true;
            btn_guardar.Text = "Nuevo";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('" + dt_Hist.Rows[int_Index][3].ToString() + "')",true);
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
}