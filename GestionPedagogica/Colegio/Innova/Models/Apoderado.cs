
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
    
public partial class Apoderado
{

    public Apoderado()
    {

        this.Alumno = new HashSet<Alumno>();

    }


    public int idApoderado { get; set; }

    public Nullable<int> idParentesco { get; set; }

    public string email { get; set; }

    public string telefono_2 { get; set; }

    public Nullable<int> idPersona { get; set; }



    public virtual ICollection<Alumno> Alumno { get; set; }

    public virtual Parentesco Parentesco { get; set; }

    public virtual Persona Persona { get; set; }

}

}
