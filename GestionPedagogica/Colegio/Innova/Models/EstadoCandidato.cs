
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
    
public partial class EstadoCandidato
{

    public EstadoCandidato()
    {

        this.Candidato = new HashSet<Candidato>();

    }


    public int idEstadoCandidato { get; set; }

    public string estadoCandidato1 { get; set; }



    public virtual ICollection<Candidato> Candidato { get; set; }

}

}
