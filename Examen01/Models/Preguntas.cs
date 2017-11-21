namespace Examen01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Preguntas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Preguntas()
        {
            Respuestas = new HashSet<Respuestas>();
        }

        [Key]
        public int IdPreguntas { get; set; }

        public int? IdExamenes { get; set; }

        public string Pregunta { get; set; }

        public virtual Examenes Examenes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Respuestas> Respuestas { get; set; }
    }
}
