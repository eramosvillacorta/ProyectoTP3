
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
    
public partial class CurriculaBase
{

    public CurriculaBase()
    {

        this.Curricula = new HashSet<Curricula>();

        this.CurriculaBaseCompetencia = new HashSet<CurriculaBaseCompetencia>();

        this.PlanEstudiosBase = new HashSet<PlanEstudiosBase>();

    }


    public int IdCurriculaBase { get; set; }

    public int Año { get; set; }

    public string NumeroResolucion { get; set; }

    public string Descripcion { get; set; }

    public Nullable<bool> Vigencia { get; set; }



    public virtual ICollection<Curricula> Curricula { get; set; }

    public virtual ICollection<CurriculaBaseCompetencia> CurriculaBaseCompetencia { get; set; }

    public virtual ICollection<PlanEstudiosBase> PlanEstudiosBase { get; set; }

}

}
