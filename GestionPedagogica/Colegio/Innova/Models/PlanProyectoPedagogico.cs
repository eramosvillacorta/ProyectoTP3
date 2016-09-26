
//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Innova.Models
{

using System;
    using System.Collections.Generic;
    
public partial class PlanProyectoPedagogico
{

    public PlanProyectoPedagogico()
    {

        this.ActividadPlanProyectoPedagogico = new HashSet<ActividadPlanProyectoPedagogico>();

    }


    public int idProyectoPedagogico { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public string objetivos { get; set; }

    public string estado { get; set; }

    public string documento { get; set; }

    public int idPlanEstudio { get; set; }

    public int idPeriodoAcademico { get; set; }

    public int idAreaCurricular { get; set; }

    public int idGrado { get; set; }

    public System.DateTime fechaCreacion { get; set; }

    public Nullable<System.DateTime> fechaModificacion { get; set; }



    public virtual ICollection<ActividadPlanProyectoPedagogico> ActividadPlanProyectoPedagogico { get; set; }

    public virtual PeriodoAcademico PeriodoAcademico { get; set; }

    public virtual PlanEstudio PlanEstudio { get; set; }

    public virtual AreaCurricular AreaCurricular { get; set; }

    public virtual Grado Grado { get; set; }

}

}
