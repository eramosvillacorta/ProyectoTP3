
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
    
public partial class DetalleCurriculaTema
{

    public int IdDetalleCurricula { get; set; }

    public int IdDetalleCurriculaTema { get; set; }

    public int IdUnidad { get; set; }

    public int IdCursoTema { get; set; }

    public string NoCursoTema { get; set; }

    public int IdCompetencia { get; set; }

    public string NoCompetencia { get; set; }



    public virtual DetalleCurricula DetalleCurricula { get; set; }

    public virtual Unidad Unidad { get; set; }

}

}
