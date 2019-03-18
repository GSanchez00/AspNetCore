
using System;
using System.Linq;
using ASP.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetCore.Controllers
{
    public class EscuelaController: Controller
    {
        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            var escuela=_context.Escuelas.FirstOrDefault();
            //ViewBag.CosaDinamica="Holis";
            return View(escuela); 
        }


        

    }


}