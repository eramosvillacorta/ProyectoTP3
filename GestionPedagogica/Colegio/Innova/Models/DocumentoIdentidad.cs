
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Innova.Models
{

using System;
    using System.Collections.Generic;
    
public partial class DocumentoIdentidad
{

    public DocumentoIdentidad()
    {

        this.Persona = new HashSet<Persona>();

    }


    public int idDocumentoIdentidad { get; set; }

    public string descripcion { get; set; }



    public virtual ICollection<Persona> Persona { get; set; }

}

}
