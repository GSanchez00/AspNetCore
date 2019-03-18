
using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        { 
            return View(_context.Alumnos.FirstOrDefault());
        }
        public IActionResult MultipleAlumno()
        {
            // var alumnos = new List<Alumno>()
            // {
            //     new Alumno() { Id= Guid.NewGuid().ToString(), Nombre="Patricia Daiello"},
            //     new Alumno() { Id= Guid.NewGuid().ToString(), Nombre="Hugo Sanchez"},
            //     new Alumno() { Id= Guid.NewGuid().ToString(), Nombre="Raquel Muriega"},
            //     new Alumno() { Id= Guid.NewGuid().ToString(), Nombre="Pablo Gilardenghi"}
            // };

            // ViewBag.CosaDinamica = "Holis";
            // ViewBag.Fecha = DateTime.Now;
            return View("MultiAlumno", _context.Alumnos);
        }
    }
}