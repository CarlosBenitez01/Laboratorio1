using PrimerLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerLaboratorio.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult Index()
        {
            return View();
        }

        //ClsTbl_estudiante cls = new ClsTbl_estudiante();
        public ActionResult Save(String nombre, String lab1, String lab2, String lab3, String par1, String par2, String par3)
        {
            //this.cls.Est_nombre = nombre;
            //this.cls.Est_lab1 = lab1;
            //this.cls.Est_lab2 = lab2;
            //this.cls.Est_lab3 = lab3;
            //this.cls.Est_par1 = par1;
            //this.cls.Est_par2 = par2;
            //this.cls.Est_par3 = par3;
            ClsTbl_estudiante cls = new ClsTbl_estudiante();
            cls.Est_nombre = nombre;
            cls.Est_lab1 = lab1;
            cls.Est_lab2 = lab2;
            cls.Est_lab3 = lab3;
            cls.Est_par1 = par1;
            cls.Est_par2 = par2;
            cls.Est_par3 = par3;

            using (EstudiantesEntities Est = new EstudiantesEntities()) {
                TblNotasEstudiante tbl = new TblNotasEstudiante();
                tbl.Est_nombre = nombre;
                tbl.Est_lab1 = lab1;
                tbl.Est_lab2 = lab2;
                tbl.Est_lab3 = lab3;
                tbl.Est_lab3 = lab3;
                tbl.Est_par1 = par1;
                tbl.Est_par2 = par2;
                tbl.Est_par3 = par3;
                Est.TblNotasEstudiantes.Add(tbl);
                Est.SaveChanges();

            }

                return RedirectToAction("Resultado", cls);  
        }

        public ActionResult Resultado(TblNotasEstudiante cls){
            //var est = cls;
            Double Lab1 = Convert.ToDouble(cls.Est_lab1);
            Double Lab2 = Convert.ToDouble(cls.Est_lab2);
            Double Lab3 = Convert.ToDouble(cls.Est_lab3);
            Double Par1 = Convert.ToDouble(cls.Est_par1);
            Double Par2 = Convert.ToDouble(cls.Est_par2);
            Double Par3 = Convert.ToDouble(cls.Est_par3);

            Double porLab = 0.40;
            Double porPar = 0.60;

            Double promedio1 = Math.Round((((Lab1 * porLab) + (Par1 * porPar)) / 3), 2);
            Double promedio2 = Math.Round((((Lab2 * porLab) + (Par2 * porPar)) / 3), 2); 
            Double promedio3 = Math.Round((((Lab3 * porLab) + (Par3 * porPar)) / 3), 2);
            Double promFinal = Math.Round((promedio1 + promedio2 + promedio3), 4);

            ViewBag.nombre = cls.Est_nombre;
            ViewBag.prom1 = promedio1;
            ViewBag.prom2 = promedio2;
            ViewBag.prom3 = promedio3;
            ViewBag.promF = promFinal;

            return View();

        }

        public ActionResult ResultadosGenerales()
        {
            using (EstudiantesEntities est = new EstudiantesEntities())
            {
                var listaDeNotas = est.TblNotasEstudiantes.ToList();
                return View(listaDeNotas);
            }
        }
        //public ActionResult Resultado()
        //{
        //    return View();
        //}
    }
}