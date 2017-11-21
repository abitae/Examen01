namespace Examen01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Examenes> Examenes { get; set; }
        public virtual DbSet<Examenes_Alumnos> Examenes_Alumnos { get; set; }
        public virtual DbSet<Preguntas> Preguntas { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }
        public virtual DbSet<Respuestas> Respuestas { get; set; }
        public virtual DbSet<PreguntaRespuesta> PreguntaRespuesta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Alumnos>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Alumnos>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Alumnos>()
                .HasMany(e => e.Examenes_Alumnos)
                .WithRequired(e => e.Alumnos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Examenes>()
                .Property(e => e.CodExamenes)
                .IsUnicode(false);

            modelBuilder.Entity<Examenes>()
                .Property(e => e.Curso)
                .IsUnicode(false);

            modelBuilder.Entity<Examenes>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Examenes>()
                .Property(e => e.CalifMax)
                .HasPrecision(2, 2);

            modelBuilder.Entity<Examenes>()
                .HasMany(e => e.Examenes_Alumnos)
                .WithRequired(e => e.Examenes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Examenes_Alumnos>()
                .Property(e => e.Calificacion)
                .HasPrecision(2, 2);

            modelBuilder.Entity<Preguntas>()
                .Property(e => e.Pregunta)
                .IsUnicode(false);

            modelBuilder.Entity<Profesores>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Profesores>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Profesores>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Respuestas>()
                .Property(e => e.Respuesta)
                .IsUnicode(false);

            modelBuilder.Entity<PreguntaRespuesta>()
                .Property(e => e.CodExamenes)
                .IsUnicode(false);

            modelBuilder.Entity<PreguntaRespuesta>()
                .Property(e => e.Curso)
                .IsUnicode(false);

            modelBuilder.Entity<PreguntaRespuesta>()
                .Property(e => e.Pregunta)
                .IsUnicode(false);

            modelBuilder.Entity<PreguntaRespuesta>()
                .Property(e => e.Respuesta)
                .IsUnicode(false);
        }
    }
}
