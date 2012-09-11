using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reporte_Estadisticas_Pacientes : System.Web.UI.Page
{
    private BL.SeguimientoPacientes pacientes;
 
    private DataTable table;
    private int male, female, babies, children, teens, adults;
    private int urbano, rural;
    private int sinEdu, eduPreInc, eduPreCom, eduBasInc, eduBasCom, eduMedInc, eduMedCom, eduSupInc, eduSupCom, noCorresponde, sinInstruccion;
    private int alta, noAlta, nuevo, subsecuente;
    DateTime fechaIni, fechaFin;
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

        fechaIni = (DateTime)Session["RepCon_FechaIni"];
        fechaFin = (DateTime)Session["RepCon_FechaFin"];

        male = female = babies = children = teens = adults = urbano = rural = sinEdu = eduPreInc = eduPreCom = eduBasInc = eduBasCom = eduMedInc = eduMedCom = eduSupInc = eduSupCom = noCorresponde = sinInstruccion = alta = noAlta =  nuevo  = subsecuente = 0;
        
        pacientes = new BL.SeguimientoPacientes();
        table = pacientes.GetDataReporteConsolidado(fechaIni, fechaFin, centroid);

        if(table.Rows.Count >0 )       
            CalcularData();

        this.totMasc.Text = male + " pacientes";
        this.totFem.Text = female + " pacientes";
        this.totBabies.Text = babies + " pacientes";
        this.totChildren.Text = children + " pacientes";
        this.totTeens.Text = teens + " pacientes";
        this.totAdults.Text = adults + " pacientes";
        this.totalP.Text = table.Rows.Count + " pacientes";
        this.totUrban.Text = urbano + " pacientes";
        this.totRural.Text = rural + " pacientes";
        this.noEdu.Text = sinEdu + " pacientes";
        this.preInc.Text = eduPreInc + " pacientes";
        this.preCom.Text = eduPreCom + " pacientes";
        this.basInc.Text = eduBasInc + " pacientes";
        this.basCom.Text = eduBasCom + " pacientes";
        this.medInc.Text = eduMedInc + " pacientes";
        this.medCom.Text = eduMedCom + " pacientes";
        this.supInc.Text = eduSupInc + " pacientes";
        this.supCom.Text = eduSupCom + " pacientes";
        this.noCorresp.Text = noCorresponde + " pacientes";
        this.noInst.Text = sinInstruccion + " pacientes";
        this.nuevos.Text = nuevo + " pacientes";
        this.totSubsecuentes.Text = subsecuente + " pacientes";
        this.totAlta.Text = alta + " pacientes";
            
    }

    private void CalcularData()
    {
        alta = table.Select("id_estado_alta=1").Count();
        noAlta = table.Select("id_estado_alta=0").Count();

        nuevo = table.Select("condicion1='Nuevo'").Count();
        subsecuente = table.Select("condicion1='Subsecuente'").Count();

        sinEdu = table.Select("id_escolaridad=0").Count();
        eduPreInc = table.Select("id_escolaridad=1").Count();
        eduPreCom = table.Select("id_escolaridad=2").Count();
        eduBasInc = table.Select("id_escolaridad=3").Count();
        eduBasCom = table.Select("id_escolaridad=4").Count();
        eduMedInc = table.Select("id_escolaridad=5").Count();
        eduMedCom = table.Select("id_escolaridad=6").Count();
        eduSupInc = table.Select("id_escolaridad=7").Count();
        eduSupCom = table.Select("id_escolaridad=8").Count();
        noCorresponde = table.Select("id_escolaridad=9").Count();
        sinInstruccion = table.Select("id_escolaridad=99").Count();        

        urbano = table.Select("procedencia1='Urbano'").Count();
        rural = table.Select("procedencia1='Rural'").Count();

        male     = table.Select("sexo=1").Count();
        female   = table.Select("sexo=0").Count();

        for (int i=0; i<table.Rows.Count; i++)
        {
            int days = GetDays((DateTime)table.Rows[i]["fecha_nac"]);
            int years = days/365;

            if (days > 0 && days <= 365)
                babies++;

            if (years > 1 && years <= 12)
                children++;
            else if (years > 12 && years <= 20)
                teens++;
            else if (years >= 21)
                adults++;
        }


    }

    private int GetDays(DateTime bornDate)
    {
        return (DateTime.Now.Subtract(bornDate).Days);
    }


}