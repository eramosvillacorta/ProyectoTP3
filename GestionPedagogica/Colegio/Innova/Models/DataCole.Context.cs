﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class InnovaEntities : DbContext
{
    public InnovaEntities()
        : base("name=InnovaEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public DbSet<AreaCurricular> AreaCurricular { get; set; }

    public DbSet<Capacidad> Capacidad { get; set; }

    public DbSet<Competencia> Competencia { get; set; }

    public DbSet<Contrato> Contrato { get; set; }

    public DbSet<Curricula> Curricula { get; set; }

    public DbSet<CurriculaBase> CurriculaBase { get; set; }

    public DbSet<CurriculaBaseCompetencia> CurriculaBaseCompetencia { get; set; }

    public DbSet<Curso> Curso { get; set; }

    public DbSet<CursoTema> CursoTema { get; set; }

    public DbSet<DetalleCurricula> DetalleCurricula { get; set; }

    public DbSet<Docente> Docente { get; set; }

    public DbSet<DocumentoIdentidad> DocumentoIdentidad { get; set; }

    public DbSet<Empleado> Empleado { get; set; }

    public DbSet<Grado> Grado { get; set; }

    public DbSet<Nivel> Nivel { get; set; }

    public DbSet<Persona> Persona { get; set; }

    public DbSet<PlanEstudiosBase> PlanEstudiosBase { get; set; }

    public DbSet<sysdiagrams> sysdiagrams { get; set; }

    public DbSet<Unidad> Unidad { get; set; }

}

}
