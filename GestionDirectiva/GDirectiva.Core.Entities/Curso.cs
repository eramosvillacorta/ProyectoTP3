//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GDirectiva.Core.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Curso
    {
        public Curso()
        {
            this.PlanAsignatura = new HashSet<PlanAsignatura>();
            this.CursoDocente = new HashSet<CursoDocente>();
        }
    
        public int Id_Asignatura { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Id_Area { get; set; }
    
        public virtual ICollection<PlanAsignatura> PlanAsignatura { get; set; }
        public virtual AreaCurricular AreaCurricular { get; set; }
        public virtual ICollection<CursoDocente> CursoDocente { get; set; }
    }
}
