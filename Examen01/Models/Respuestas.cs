namespace Examen01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Respuestas
    {
        [Key]
        public int IdRespuestas { get; set; }

        public int? IdPreguntas { get; set; }

        public string Respuesta { get; set; }

        public bool? Value { get; set; }

        public virtual Preguntas Preguntas { get; set; }
    }
}
