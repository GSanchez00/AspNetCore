using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NetCore.Models
{
    [Table("Evaluaciones")]
    public class Evaluacion:ObjetoEscuelaBase
    {
        public string AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public string AsignaturaId { get; set; }
        public Asignatura Asignatura  { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}