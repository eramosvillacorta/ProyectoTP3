
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
    
public partial class Seccion
{

    public Seccion()
    {

        this.Matricula = new HashSet<Matricula>();

    }


    public int idSeccion { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public Nullable<int> capacidad { get; set; }

    public Nullable<int> idGrado { get; set; }



    public virtual ICollection<Matricula> Matricula { get; set; }

    public virtual Grado Grado { get; set; }

}

}
