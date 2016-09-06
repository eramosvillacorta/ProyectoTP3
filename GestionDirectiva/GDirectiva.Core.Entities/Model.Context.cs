﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_INNOVASCHOOLSEntities : DbContext
    {
        public DB_INNOVASCHOOLSEntities()
            : base("name=DB_INNOVASCHOOLSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<ActividadPlanAsignatura> ActividadPlanAsignatura { get; set; }
        public virtual DbSet<ActividadPlanProyectoPedagogico> ActividadPlanProyectoPedagogico { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Asignatura> Asignatura { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<PeriodoAcademico> PeriodoAcademico { get; set; }
        public virtual DbSet<PlanArea> PlanArea { get; set; }
        public virtual DbSet<PlanAsignatura> PlanAsignatura { get; set; }
        public virtual DbSet<PlanEstudio> PlanEstudio { get; set; }
        public virtual DbSet<PlanProyectoPedagogico> PlanProyectoPedagogico { get; set; }
    
        public virtual ObjectResult<PA_AREA_LISTA_Result> PA_AREA_LISTA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_AREA_LISTA_Result>("PA_AREA_LISTA");
        }
    
        public virtual ObjectResult<PA_GRADO_LISTA_Result> PA_GRADO_LISTA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_GRADO_LISTA_Result>("PA_GRADO_LISTA");
        }
    
        public virtual ObjectResult<PA_PERIODO_ACADEMICO_LISTA_Result> PA_PERIODO_ACADEMICO_LISTA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_PERIODO_ACADEMICO_LISTA_Result>("PA_PERIODO_ACADEMICO_LISTA");
        }
    
        public virtual ObjectResult<PA_PERIODO_ACADEMICO_LISTA_VIGENTE_Result> PA_PERIODO_ACADEMICO_LISTA_VIGENTE()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_PERIODO_ACADEMICO_LISTA_VIGENTE_Result>("PA_PERIODO_ACADEMICO_LISTA_VIGENTE");
        }
    
        public virtual ObjectResult<PA_PLAN_AREA_LISTA_Result> PA_PLAN_AREA_LISTA(Nullable<int> iD_PERIODOACADEMICO, Nullable<int> iD_GRADO, Nullable<int> iD_AREA, Nullable<int> pAGINA_INICIO, Nullable<int> tAMANIO_PAGINA)
        {
            var iD_PERIODOACADEMICOParameter = iD_PERIODOACADEMICO.HasValue ?
                new ObjectParameter("ID_PERIODOACADEMICO", iD_PERIODOACADEMICO) :
                new ObjectParameter("ID_PERIODOACADEMICO", typeof(int));
    
            var iD_GRADOParameter = iD_GRADO.HasValue ?
                new ObjectParameter("ID_GRADO", iD_GRADO) :
                new ObjectParameter("ID_GRADO", typeof(int));
    
            var iD_AREAParameter = iD_AREA.HasValue ?
                new ObjectParameter("ID_AREA", iD_AREA) :
                new ObjectParameter("ID_AREA", typeof(int));
    
            var pAGINA_INICIOParameter = pAGINA_INICIO.HasValue ?
                new ObjectParameter("PAGINA_INICIO", pAGINA_INICIO) :
                new ObjectParameter("PAGINA_INICIO", typeof(int));
    
            var tAMANIO_PAGINAParameter = tAMANIO_PAGINA.HasValue ?
                new ObjectParameter("TAMANIO_PAGINA", tAMANIO_PAGINA) :
                new ObjectParameter("TAMANIO_PAGINA", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_PLAN_AREA_LISTA_Result>("PA_PLAN_AREA_LISTA", iD_PERIODOACADEMICOParameter, iD_GRADOParameter, iD_AREAParameter, pAGINA_INICIOParameter, tAMANIO_PAGINAParameter);
        }
    
        public virtual ObjectResult<PA_PLAN_AREA_SEL_Result> PA_PLAN_AREA_SEL(Nullable<int> planAreaId)
        {
            var planAreaIdParameter = planAreaId.HasValue ?
                new ObjectParameter("PlanAreaId", planAreaId) :
                new ObjectParameter("PlanAreaId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_PLAN_AREA_SEL_Result>("PA_PLAN_AREA_SEL", planAreaIdParameter);
        }
    
        public virtual ObjectResult<PA_PLAN_ESTUDIO_SEL_Result> PA_PLAN_ESTUDIO_SEL()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_PLAN_ESTUDIO_SEL_Result>("PA_PLAN_ESTUDIO_SEL");
        }
    
        public virtual ObjectResult<PA_PLAN_AREA_LISTA_VIGENTE_Result> PA_PLAN_AREA_LISTA_VIGENTE(Nullable<int> iD_PERIODOACADEMICO)
        {
            var iD_PERIODOACADEMICOParameter = iD_PERIODOACADEMICO.HasValue ?
                new ObjectParameter("ID_PERIODOACADEMICO", iD_PERIODOACADEMICO) :
                new ObjectParameter("ID_PERIODOACADEMICO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_PLAN_AREA_LISTA_VIGENTE_Result>("PA_PLAN_AREA_LISTA_VIGENTE", iD_PERIODOACADEMICOParameter);
        }
    }
}
