
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
    
public partial class Candidato
{

    public Candidato()
    {

        this.Empleado = new HashSet<Empleado>();

    }


    public int idCandidato { get; set; }

    public Nullable<int> idPersona { get; set; }

    public Nullable<int> idEstadoCandidato { get; set; }

    public string rutaImgDni { get; set; }

    public string rutaImgAntecedentesPenales { get; set; }

    public string rutaImgAntecedentesPoliciales { get; set; }

    public string rutaImgDeclaracionJurada { get; set; }

    public string rutaImgTituloProfesional { get; set; }

    public string estado { get; set; }



    public virtual Persona Persona { get; set; }

    public virtual EstadoCandidato EstadoCandidato { get; set; }

    public virtual ICollection<Empleado> Empleado { get; set; }

}

}
