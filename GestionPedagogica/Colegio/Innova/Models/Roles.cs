
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
    
public partial class Roles
{

    public Roles()
    {

        this.Usuario1 = new HashSet<Usuario>();

    }


    public int idrol { get; set; }

    public string descripcion { get; set; }

    public Nullable<int> idUser { get; set; }



    public virtual Usuario Usuario { get; set; }

    public virtual ICollection<Usuario> Usuario1 { get; set; }

}

}