using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetCore.Models
{
    public class EscuelaContext: DbContext
    {
        public DbSet<Escuela> Escuelas {get;set;}
        public DbSet<Asignatura> Asignaturas {get;set;}
        public DbSet<Alumno> Alumnos {get;set;}
        public DbSet<Curso> Cursos {get;set;}
        public DbSet<Evaluacion> Evaluaciones {get;set;}

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var escuela = CargarEscuela();
            //Cargar Cursos de la escuela
            var cursos = CargarCursos(escuela);
            //X Cada Curso Cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);
            //X Cada Curso Cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            var evaluaciones = CargarEvaluaciones(asignaturas, alumnos);

            //Inserta la escuela en la BD. Pero es agnostico de la base de datos. Puede ser una base Sql, Oracle, MySql.
            //Con el ORM estamos independientes de la base de datos. En el Startup.cs se especifica la base de datos. 
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            modelBuilder.Entity<Evaluacion>().HasData(evaluaciones.ToArray());
        }

        private static Escuela CargarEscuela()
        {
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Pais = "Argentina";
            escuela.Ciudad = "Bs As";
            escuela.Dirección = "Av Cordoba 2400";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            return escuela;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var asignaturas = new List<Asignatura>();
            foreach (Curso curso in cursos)
            {
                asignaturas.AddRange(new List<Asignatura>()
                {
                    new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Programación", CursoId=curso.Id},
                    new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Matemática", CursoId=curso.Id},
                    new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Física", CursoId=curso.Id},
                    new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Química", CursoId=curso.Id}
                });
            }
            return asignaturas;
        }

        private static List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var alumnos = new List<Alumno>();
            foreach (Curso curso in cursos)
            {
                alumnos.AddRange(new List<Alumno>()
                {
                    new Alumno() { Id= Guid.NewGuid().ToString(),Nombre="Patricia Daiello", CursoId=curso.Id},
                    new Alumno() { Id= Guid.NewGuid().ToString(),Nombre="Hugo Sanchez", CursoId=curso.Id},
                    new Alumno() { Id= Guid.NewGuid().ToString(),Nombre="Raquel Muriega", CursoId=curso.Id},
                    new Alumno() { Id= Guid.NewGuid().ToString(),Nombre="Pablo Gilardenghi", CursoId=curso.Id}
                });
            }
            return alumnos;
        }
        
        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>()
            {
                new Curso() { Id= Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="101", Jornada=TiposJornada.Mañana, Dirección="Av Siempre Viva"},
                new Curso() { Id= Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="201", Jornada=TiposJornada.Mañana, Dirección="Av Siempre Viva"},
                new Curso() { Id= Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="301", Jornada=TiposJornada.Mañana, Dirección="Av Siempre Viva"},
                new Curso() { Id= Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="401", Jornada=TiposJornada.Tarde, Dirección="Av Siempre Viva"},
                new Curso() { Id= Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="501", Jornada=TiposJornada.Tarde, Dirección="Av Siempre Viva"}
            };
        }


        private static List<Evaluacion> CargarEvaluaciones(List<Asignatura> asignaturas, List<Alumno> alumnos)
        {
            List<Evaluacion> evaluaciones= new List<Evaluacion>();
            foreach(Alumno alumno in alumnos)
            {
                foreach (Asignatura asignatura in asignaturas)
                {
                    evaluaciones.Add(new Evaluacion() { Id= Guid.NewGuid().ToString(), AsignaturaId=asignatura.Id, Nota=7, AlumnoId=alumno.Id});
                }
            }
            return evaluaciones;
        }
    }
}