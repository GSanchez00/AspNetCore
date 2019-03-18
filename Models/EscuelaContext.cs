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

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var escuela= new Escuela();
            escuela.AñoDeCreación=2005;
            escuela.Id= Guid.NewGuid().ToString();
            escuela.Nombre="Platzi School";
            escuela.Pais="Argentina";
            escuela.Ciudad="Bs As";
            escuela.Dirección="Av Cordoba 2400";
            escuela.TipoEscuela=TiposEscuela.Secundaria;

            //Inserta la escuela en la BD. Pero es agnostico de la base de datos. Puede ser una base Sql, Oracle, MySql.
            //Con el ORM estamos independientes de la base de datos. En el Startup.cs se especifica la base de datos. 
            modelBuilder.Entity<Escuela>().HasData(escuela);


            var asignaturas = new List<Asignatura>()
            {
                new Asignatura() { Id= Guid.NewGuid().ToString(), Nombre="Programación"},
                new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Matemática"},
                new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Física"},
                new Asignatura() { Id= Guid.NewGuid().ToString(),Nombre="Química"}
            };

            modelBuilder.Entity<Asignatura>().HasData(asignaturas);

            var alumnos = new List<Alumno>()
            {
                new Alumno() { Id= Guid.NewGuid().ToString(), Nombre="Patricia Daiello"},
                new Alumno() { Id= Guid.NewGuid().ToString(), Nombre="Hugo Sanchez"},
                new Alumno() { Id= Guid.NewGuid().ToString(), Nombre="Raquel Muriega"},
                new Alumno() { Id= Guid.NewGuid().ToString(), Nombre="Pablo Gilardenghi"}
            };

            modelBuilder.Entity<Alumno>().HasData(alumnos);
        }
    }
}