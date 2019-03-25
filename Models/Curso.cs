using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NetCore.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Required(ErrorMessage="El nombre del Curso es Requerido")]
        [StringLength(10)]
        public override string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        
        [Display(Prompt="Direccion de Correspondencia", Name="Addres")]
        [Required (ErrorMessage="Se requiere incluir una direccion")]
        [MinLength(7, ErrorMessage="La longitud minima de la direccion es 7 caracteres")]
        public string Dirección { get; set; }
        public string EscuelaId {get;set;}
        public Escuela Escuela {get;set;}
    }
}