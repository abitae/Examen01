namespace Examen01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PreguntaRespuesta")]
    public partial class PreguntaRespuesta
    {
        public int? IdExamenes { get; set; }

        public int? IdPreguntas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRespuestas { get; set; }

        [StringLength(10)]
        public string CodExamenes { get; set; }

        [StringLength(50)]
        public string Curso { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? Duration { get; set; }

        public int? Intentos { get; set; }

        public int? NumPreguntas { get; set; }

        public string Pregunta { get; set; }

        public string Respuesta { get; set; }

        public bool? Value { get; set; }
    }
}
