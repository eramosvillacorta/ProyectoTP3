
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
    
public partial class AlumnoEmpadronado
{

    public int idalumnoempadronado { get; set; }

    public Nullable<long> codalumnoempadronado { get; set; }

    public string estado { get; set; }

    public Nullable<int> añoescolar { get; set; }

    public Nullable<int> idAlumno { get; set; }

    public Nullable<int> idProceso { get; set; }

    public string usuario { get; set; }

    public string claveAcceso { get; set; }



    public virtual Alumno Alumno { get; set; }

    public virtual DetalleProceso DetalleProceso { get; set; }

}

}