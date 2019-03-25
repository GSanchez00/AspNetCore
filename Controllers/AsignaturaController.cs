
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
        // public IActionResult Index()
        // { 
        //     //Mock
        //     // return View(new Asignatura()
        //     // {
        //     //     Id= Guid.NewGuid().ToString(),
        //     //     Nombre="Programacion"
        //     // });

        //     return View(_context.Asignaturas.FirstOrDefault());
        // }

        //Al ver nuestra regla en Startup.cs vemos que el routing tiene un 
        //template: "{controller=Escuela}/{action=Index}/{id?}");
        //Ese {id?} indica que es un parametro de entrada opcional, pero indica que en el controller debe llamarse asi.
        //O sea que si a esta accion le colocamos Index(string asignaturaId) no va a funcionar. 

        // public IActionResult Index(string id)
        // { 
        //     var asignatura=_context.Asignaturas.Where(x=> x.Id==id).SingleOrDefault();
        //     return View(asignatura);
        // }

        //En este caso va a tener 2 puntos de entrada. 
        //Al colocar {asignaturaId} entre llaves indica que es un parametro de entrada
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        { 
            if(!string.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura=_context.Asignaturas.Where(x=> x.Id==asignaturaId).SingleOrDefault();
                return View(asignatura);
            }
            else{
                return View("MultiAsignatura", _context.Asignaturas);
            }
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
            var asignaturas=from a in _context.Asignaturas
            join c in _context.Cursos on a.CursoId equals c.Id
            select new Asignatura{ 
                         Nombre=a.Nombre,
                         CursoId=a.CursoId,
                         Id=a.Id,
                         Curso=c
                        };

            return View("MultiAsignatura", asignaturas);
        }

        public IActionResult Create()
        {
            ViewBag.Cursos=_context.Cursos;
            return View();
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Cursos=_context.Cursos;
            var asignatura=_context.Asignaturas.Where(x=> x.Id==id).SingleOrDefault();
            return View("Edit", asignatura);
        }

        public IActionResult Delete(string id)
        {
            ViewBag.Cursos=_context.Cursos;
            var asignatura=_context.Asignaturas.Where(x=> x.Id==id).SingleOrDefault();
            return View("Delete", asignatura);
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            //Si los atributos de validacion se cumplen
            if(ModelState.IsValid)
            {
                var escuela=_context.Escuelas.FirstOrDefault();
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();
                ViewBag.Mensaje="Asignatura Creada";
                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }

        [HttpPost]
        public IActionResult Edit(Asignatura asignatura)
        {
            //Si los atributos de validacion se cumplen
            if(ModelState.IsValid)
            {
                var asignaturaEdit=_context.Asignaturas.SingleOrDefault(x=>x.Id==asignatura.Id);
                if(asignaturaEdit!=null)
                {
                    asignaturaEdit.Nombre=asignatura.Nombre;
                    asignaturaEdit.CursoId=asignatura.CursoId;
                    _context.SaveChanges();
                    ViewBag.Mensaje="Asignatura Editado";
                }
                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }

        [HttpPost]
        public IActionResult Delete(Asignatura asignatura)
        {
            var asignaturaDelete=_context.Asignaturas.SingleOrDefault(x=>x.Id==asignatura.Id);
            if(asignaturaDelete!=null)
            {
                _context.Asignaturas.Remove(asignaturaDelete);
                _context.SaveChanges();
                //ViewBag.Mensaje="Alumno Borrado";
            }
            return View("MultiAsignatura", _context.Asignaturas);
        }
    }
}