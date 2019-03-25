
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
        // public IActionResult Index()
        // { 
        //     return View(_context.Alumnos.FirstOrDefault());
        // }

        [Route("Alumno/Index")]
        [Route("Alumno/Index/{id}")]
        public IActionResult Index(string id)
        { 
            if(!string.IsNullOrWhiteSpace(id))
            {
                var alumno=_context.Alumnos.Where(x=> x.Id==id).SingleOrDefault();
                return View(alumno);
            }
            else{
                return View("MultiAlumno", _context.Alumnos);
            }
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

        public IActionResult Create()
        {
            ViewBag.Cursos=_context.Cursos;
            return View();
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Cursos=_context.Cursos;
            var alumno=_context.Alumnos.Where(x=> x.Id==id).SingleOrDefault();
            return View("Edit", alumno);
        }

        public IActionResult Delete(string id)
        {
            ViewBag.Cursos=_context.Cursos;
            var alumno=_context.Alumnos.Where(x=> x.Id==id).SingleOrDefault();
            return View("Delete", alumno);
        }

        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            //Si los atributos de validacion se cumplen
            if(ModelState.IsValid)
            {
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
                ViewBag.Mensaje="Alumno Creado";
                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        [HttpPost]
        public IActionResult Edit(Alumno alumno)
        {
            //Si los atributos de validacion se cumplen
            if(ModelState.IsValid)
            {
                var alumnoEdit=_context.Alumnos.SingleOrDefault(x=>x.Id==alumno.Id);
                if(alumnoEdit!=null)
                {
                    alumnoEdit.Nombre=alumno.Nombre;
                    alumnoEdit.CursoId=alumno.CursoId;
                    _context.SaveChanges();
                    ViewBag.Mensaje="Alumno Editado";
                }
                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        [HttpPost]
        public IActionResult Delete(Alumno alumno)
        {
            var alumnoDelete=_context.Alumnos.SingleOrDefault(x=>x.Id==alumno.Id);
            if(alumnoDelete!=null)
            {
                _context.Alumnos.Remove(alumnoDelete);
                _context.SaveChanges();
                //ViewBag.Mensaje="Alumno Borrado";
            }
            return View("MultiAlumno", _context.Alumnos);
        }
    }
}