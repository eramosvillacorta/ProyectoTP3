
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
    
public partial class Docente
{

    public Docente()
    {

        this.Curso = new HashSet<Curso>();

    }


    public int IdDocente { get; set; }

    public string Nombres { get; set; }

    public string Apellidos { get; set; }



    public virtual ICollection<Curso> Curso { get; set; }

}

}
