
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
    
public partial class Unidad
{

    public Unidad()
    {

        this.CursoTema = new HashSet<CursoTema>();

    }


    public int IdUnidad { get; set; }

    public string Nombre { get; set; }



    public virtual ICollection<CursoTema> CursoTema { get; set; }

}

}
