using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;

namespace Innova.Models
{
    public class AreaModel1
    {

        public static List<AreaCurricular> ListarAreaCurricular()
        {
            using (var cn = new InnovaEntities())
            {
                var lista = (from c in cn.AreaCurricular
                             select c).ToList();
                return lista;
            }
        }
        public static List<AreaCurricular> ListarAreaCurricularById(int id)
        {
            using (var cn = new InnovaEntities())
            {
                var lista = (from c in cn.AreaCurricular
                             where c.IdAreaCurricular == id
                             select c).ToList();
                return lista;
            }
        }
    }


    public class PlanPrimariaModel
    {
        public int idAreaCurricular { get; set; }
        public string DescAreaCurricular { get; set; }
        public decimal HorasGrado1 { get; set; }
        public decimal HorasGrado2 { get; set; }
        public decimal HorasGrado3 { get; set; }
        public decimal HorasGrado4 { get; set; }
        public decimal HorasGrado5 { get; set; }
        public decimal HorasGrado6 { get; set; }

        public int idCurriculaBase { get; set; }
    }

    public class PlanSecundariaModel
    {
        public int idAreaCurricular { get; set; }
        public string DescAreaCurricular { get; set; }
        public decimal HorasGrado1 { get; set; }
        public decimal HorasGrado2 { get; set; }
        public decimal HorasGrado3 { get; set; }
        public decimal HorasGrado4 { get; set; }
        public decimal HorasGrado5 { get; set; }

        public int idCurriculaBase { get; set; }
    }
    public class Plan
    {
        public static PlanPrimariaModel ListarPlanPrimariaByIdArea(int IdCurriculaBase, int IdAreaCurricular)
        {
            List<PlanPrimariaModel> Lista = new List<PlanPrimariaModel>();
            using (var cn = new InnovaEntities())
            {
                var lista = (from a in cn.AreaCurricular
                             join p1 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p1.IdAreaCurricular
                             join p2 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p2.IdAreaCurricular
                             join p3 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p3.IdAreaCurricular
                             join p4 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p4.IdAreaCurricular
                             join p5 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p5.IdAreaCurricular
                             join p6 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p6.IdAreaCurricular
                             where p1.IdCurriculaBase == IdCurriculaBase
                             && p2.IdCurriculaBase == IdCurriculaBase
                             && p3.IdCurriculaBase == IdCurriculaBase
                             && p4.IdCurriculaBase == IdCurriculaBase
                             && p5.IdCurriculaBase == IdCurriculaBase
                             && p6.IdCurriculaBase == IdCurriculaBase
                             && p1.IdGrado == 3
                             && p2.IdGrado == 4
                             && p3.IdGrado == 5
                             && p4.IdGrado == 6
                             && p5.IdGrado == 7
                             && p6.IdGrado == 8
                             && a.IdAreaCurricular == IdAreaCurricular
                             select new PlanPrimariaModel
                             {
                                 idAreaCurricular = a.IdAreaCurricular,
                                 DescAreaCurricular = a.Nombre,
                                 HorasGrado1 = p1.Horas,
                                 HorasGrado2 = p2.Horas,
                                 HorasGrado3 = p3.Horas,
                                 HorasGrado4 = p4.Horas,
                                 HorasGrado5 = p5.Horas,
                                 HorasGrado6 = p6.Horas
                             }).FirstOrDefault();

                return lista;
            }
        }

        public static PlanSecundariaModel ListarPlanSecundariaByIdArea(int IdCurriculaBase, int IdAreaCurricular)
        {
            List<PlanSecundariaModel> Lista = new List<PlanSecundariaModel>();
            using (var cn = new InnovaEntities())
            {
                var lista = (from a in cn.AreaCurricular
                             join p1 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p1.IdAreaCurricular
                             join p2 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p2.IdAreaCurricular
                             join p3 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p3.IdAreaCurricular
                             join p4 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p4.IdAreaCurricular
                             join p5 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p5.IdAreaCurricular
                             join p6 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p6.IdAreaCurricular
                             where p1.IdCurriculaBase == IdCurriculaBase
                             && p2.IdCurriculaBase == IdCurriculaBase
                             && p3.IdCurriculaBase == IdCurriculaBase
                             && p4.IdCurriculaBase == IdCurriculaBase
                             && p5.IdCurriculaBase == IdCurriculaBase
                             && p1.IdGrado == 9
                             && p2.IdGrado == 10
                             && p3.IdGrado == 11
                             && p4.IdGrado == 12
                             && p5.IdGrado == 13
                             && a.IdAreaCurricular == IdAreaCurricular
                             select new PlanSecundariaModel
                             {
                                 idAreaCurricular = a.IdAreaCurricular,
                                 DescAreaCurricular = a.Nombre,
                                 HorasGrado1 = p1.Horas,
                                 HorasGrado2 = p2.Horas,
                                 HorasGrado3 = p3.Horas,
                                 HorasGrado4 = p4.Horas,
                                 HorasGrado5 = p5.Horas
                             }).FirstOrDefault();

                return lista;
            }
        }

        public static List<PlanPrimariaModel> ListarPlanPrimaria(int IdCurriculaBase)
        {
            List<PlanPrimariaModel> Lista = new List<PlanPrimariaModel>();
            using (var cn = new InnovaEntities())
            {
                var lista = (from a in cn.AreaCurricular
                             join p1 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p1.IdAreaCurricular
                             join p2 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p2.IdAreaCurricular
                             join p3 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p3.IdAreaCurricular
                             join p4 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p4.IdAreaCurricular
                             join p5 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p5.IdAreaCurricular
                             join p6 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p6.IdAreaCurricular
                             where p1.IdCurriculaBase == IdCurriculaBase
                             && p2.IdCurriculaBase == IdCurriculaBase
                             && p3.IdCurriculaBase == IdCurriculaBase
                             && p4.IdCurriculaBase == IdCurriculaBase
                             && p5.IdCurriculaBase == IdCurriculaBase
                             && p6.IdCurriculaBase == IdCurriculaBase
                             && p1.IdGrado == 3
                             && p2.IdGrado == 4
                             && p3.IdGrado == 5
                             && p4.IdGrado == 6
                             && p5.IdGrado == 7
                             && p6.IdGrado == 8
                             select new PlanPrimariaModel
                             {
                                 idAreaCurricular = a.IdAreaCurricular,
                                 DescAreaCurricular = a.Nombre,
                                 HorasGrado1 = p1.Horas,
                                 HorasGrado2 = p2.Horas,
                                 HorasGrado3 = p3.Horas,
                                 HorasGrado4 = p4.Horas,
                                 HorasGrado5 = p5.Horas,
                                 HorasGrado6 = p6.Horas,
                             }).ToList();

                return lista;
            }
        }

        public static List<PlanSecundariaModel> ListarPlanSecundaria(int IdCurriculaBase)
        {
            using (var cn = new InnovaEntities())
            {
                var lista = (from a in cn.AreaCurricular
                             join p1 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p1.IdAreaCurricular
                             join p2 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p2.IdAreaCurricular
                             join p3 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p3.IdAreaCurricular
                             join p4 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p4.IdAreaCurricular
                             join p5 in cn.PlanEstudiosBase on a.IdAreaCurricular equals p5.IdAreaCurricular
                             where p1.IdCurriculaBase == IdCurriculaBase
                             && p2.IdCurriculaBase == IdCurriculaBase
                             && p3.IdCurriculaBase == IdCurriculaBase
                             && p4.IdCurriculaBase == IdCurriculaBase
                             && p5.IdCurriculaBase == IdCurriculaBase
                             && p1.IdGrado == 9
                             && p2.IdGrado == 10
                             && p3.IdGrado == 11
                             && p4.IdGrado == 12
                             && p5.IdGrado == 13
                             select new PlanSecundariaModel
                             {
                                 idAreaCurricular = a.IdAreaCurricular,
                                 DescAreaCurricular = a.Nombre,
                                 HorasGrado1 = p1.Horas,
                                 HorasGrado2 = p2.Horas,
                                 HorasGrado3 = p3.Horas,
                                 HorasGrado4 = p4.Horas,
                                 HorasGrado5 = p5.Horas
                             }).ToList();

                return lista;
            }
        }

        public static bool RegistrarPlanPrimaria(PlanPrimariaModel plan)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    bool exito1 = true, exito2 = true, exito3 = true, exito4 = true, exito5 = true, exito6 = true;
                    decimal suma = 0;
                    exito1 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 3, plan.HorasGrado1);
                    exito2 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 4, plan.HorasGrado2);
                    exito3 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 5, plan.HorasGrado3);
                    exito4 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 6, plan.HorasGrado4);
                    exito5 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 7, plan.HorasGrado5);
                    exito6 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 8, plan.HorasGrado6);
                    suma = plan.HorasGrado1 + plan.HorasGrado2 + plan.HorasGrado3 + plan.HorasGrado4 + plan.HorasGrado5 + plan.HorasGrado6;
                    if (exito1 && exito2 && exito3 && exito4 && exito5 && exito6 && suma > 0)
                    {
                        transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception Ex)
                {
                    return false;
                    throw;
                }
            }
        }

        public static bool RegistrarPlanSecundaria(PlanSecundariaModel plan)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    bool exito1 = true, exito2 = true, exito3 = true, exito4 = true, exito5 = true;
                    decimal suma = 0;
                    exito1 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 9, plan.HorasGrado1);
                    exito2 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 10, plan.HorasGrado2);
                    exito3 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 11, plan.HorasGrado3);
                    exito4 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 12, plan.HorasGrado4);
                    exito5 = RegistrarPlanByIdGrado(plan.idCurriculaBase, plan.idAreaCurricular, 13, plan.HorasGrado5);
                    suma = plan.HorasGrado1 + plan.HorasGrado2 + plan.HorasGrado3 + plan.HorasGrado4 + plan.HorasGrado5;
                    if (exito1 && exito2 && exito3 && exito4 && exito5 && suma > 0)
                    {
                        transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception Ex)
                {
                    return false;
                    throw;
                }
            }
        }

        public static bool RegistrarPlanByIdGrado(int idCurriculaBase, int idAreaCurricular, int IdGrado, decimal Horas)
        {
            using (var cn = new InnovaEntities())
            {
                try
                {
                    var PlanEdit = (from c in cn.PlanEstudiosBase
                                    where c.IdCurriculaBase == idCurriculaBase
                                    && c.IdAreaCurricular == idAreaCurricular
                                    && c.IdGrado == IdGrado
                                    select c).FirstOrDefault();
                    if (PlanEdit != null)
                    {
                        PlanEdit.Horas = Horas;
                        cn.SaveChanges();
                    }
                    else
                    {
                        cn.PlanEstudiosBase.Add(new PlanEstudiosBase
                        {
                            IdCurriculaBase = idCurriculaBase,
                            IdAreaCurricular = idAreaCurricular,
                            IdGrado = IdGrado,
                            Horas = Horas
                        });
                        cn.SaveChanges();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
    }
}