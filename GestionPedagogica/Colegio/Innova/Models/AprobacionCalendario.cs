
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
    
public partial class AprobacionCalendario
{

    public int idAprobacionCalendario { get; set; }

    public int idCalendario { get; set; }

    public System.DateTime fecha { get; set; }

    public string observacion { get; set; }

    public int estado { get; set; }

    public string usuCreacion { get; set; }

    public System.DateTime fecCreacion { get; set; }

    public string usuModificacion { get; set; }

    public Nullable<System.DateTime> fecModificacion { get; set; }



    public virtual Calendario Calendario { get; set; }

}

}
