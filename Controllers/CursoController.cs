
using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context=context;
        }

        [Route("Curso/Index")]
        [Route("Curso/Index/{id}")]
        public IActionResult Index(string id)
        { 
            if(!string.IsNullOrWhiteSpace(id))
            {
                var curso=_context.Cursos.Where(x=> x.Id==id).SingleOrDefault();
                return View(curso);
            }
            else{
                return View("MultiCurso", _context.Cursos);
            }
        }

        public IActionResult MultipleCurso()
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
            return View("MultiCurso", _context.Cursos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(string id)
        {
            var curso=_context.Cursos.Where(x=> x.Id==id).SingleOrDefault();
            return View("Edit", curso);
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            //Si los atributos de validacion se cumplen
            if(ModelState.IsValid)
            {
                var escuela=_context.Escuelas.FirstOrDefault();
                curso.EscuelaId=escuela.Id;
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.Mensaje="Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }

        [HttpPost]
        public IActionResult Edit(Curso curso)
        {
            //Si los atributos de validacion se cumplen
            if(ModelState.IsValid)
            {
                var cursoEdit=_context.Cursos.SingleOrDefault(x=>x.Id==curso.Id);
                if(cursoEdit!=null)
                {
                    cursoEdit.Nombre=curso.Nombre;
                    cursoEdit.Jornada=curso.Jornada;
                    cursoEdit.Dirección=curso.Dirección;
                    _context.SaveChanges();
                    ViewBag.Mensaje="Curso Editado";
                }
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }
    }
}