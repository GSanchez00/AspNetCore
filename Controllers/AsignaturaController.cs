
using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        { 
            //Mock
            // return View(new Asignatura()
            // {
            //     Id= Guid.NewGuid().ToString(),
            //     Nombre="Programacion"
            // });

            return View(_context.Asignaturas.FirstOrDefault());
        }
        public IActionResult MultipleAsignatura()
        {
            // var asignaturas = new List<Asignatura>()
            // {
            //     new Asignatura() { Id= Guid.NewGuid().ToString(), Nombre="Programación"},
            //     new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Matemática"},
            //     new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Física"},
            //     new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Química"}
            // };

            // ViewBag.CosaDinamica = "Holis";
            // ViewBag.Fecha = DateTime.Now;
            return View("MultiAsignatura", _context.Asignaturas);
        }
    }
}