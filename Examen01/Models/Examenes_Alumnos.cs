namespace Examen01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Examenes_Alumnos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdExamenes { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAlumnos { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? HoraInitial { get; set; }

        public TimeSpan? HoraFinal { get; set; }

        public int? intento { get; set; }

        public decimal? Calificacion { get; set; }

        public virtual Alumnos Alumnos { get; set; }

        public virtual Examenes Examenes { get; set; }
    }
}
