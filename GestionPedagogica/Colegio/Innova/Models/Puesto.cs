
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
    
public partial class Puesto
{

    public Puesto()
    {

        this.Contrato = new HashSet<Contrato>();

        this.Convocatoria = new HashSet<Convocatoria>();

    }


    public int idPuesto { get; set; }

    public string descripcionPuesto { get; set; }

    public string funcion { get; set; }

    public int idArea { get; set; }

    public Nullable<int> idTipoPuesto { get; set; }



    public virtual Area Area { get; set; }

    public virtual ICollection<Contrato> Contrato { get; set; }

    public virtual ICollection<Convocatoria> Convocatoria { get; set; }

    public virtual TipoPuesto TipoPuesto { get; set; }

}

}
