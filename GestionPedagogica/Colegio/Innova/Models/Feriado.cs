
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
    
public partial class Feriado
{

    public int idFeriado { get; set; }

    public string idAgenda { get; set; }

    public string motivo { get; set; }

    public System.DateTime fechaInicio { get; set; }

    public Nullable<System.DateTime> fechaTermino { get; set; }

    public Nullable<int> repetitivo { get; set; }

    public string usuCreacion { get; set; }

    public System.DateTime fecCreacion { get; set; }

    public string usuModificacion { get; set; }

    public Nullable<System.DateTime> fecModificacion { get; set; }



    public virtual Agenda Agenda { get; set; }

}

}