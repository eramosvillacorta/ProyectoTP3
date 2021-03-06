
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
    
public partial class PlanAsignatura
{

    public PlanAsignatura()
    {

        this.ActividadPlanAsignatura = new HashSet<ActividadPlanAsignatura>();

        this.Meta = new HashSet<Meta>();

    }


    public int idPlanAsignatura { get; set; }

    public string metodologia { get; set; }

    public string documento { get; set; }

    public int idPlanArea { get; set; }

    public int idCurso { get; set; }

    public int idPersona { get; set; }

    public Nullable<System.DateTime> fechaCreacion { get; set; }

    public Nullable<System.DateTime> fechaModificacion { get; set; }

    public int idEmpleado { get; set; }

    public string estado { get; set; }



    public virtual ICollection<ActividadPlanAsignatura> ActividadPlanAsignatura { get; set; }

    public virtual ICollection<Meta> Meta { get; set; }

    public virtual PlanArea PlanArea { get; set; }

    public virtual Curso Curso { get; set; }

    public virtual Empleado Empleado { get; set; }

}

}
