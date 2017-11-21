namespace Examen01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Examenes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Examenes()
        {
            Examenes_Alumnos = new HashSet<Examenes_Alumnos>();
            Preguntas = new HashSet<Preguntas>();
        }

        [Key]
        public int IdExamenes { get; set; }

        [StringLength(10)]
        public string CodExamenes { get; set; }

        [StringLength(50)]
        public string Curso { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? Hora { get; set; }

        public TimeSpan? Duration { get; set; }

        public int? Intentos { get; set; }

        public int? IdProfesores { get; set; }

        public int? NumPreguntas { get; set; }

        public decimal? CalifMax { get; set; }

        public bool? estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Examenes_Alumnos> Examenes_Alumnos { get; set; }

        public virtual Profesores Profesores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Preguntas> Preguntas { get; set; }
    }
}
