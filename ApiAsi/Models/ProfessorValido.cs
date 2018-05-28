namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfessorValido")]
    public partial class ProfessorValido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProfessorValido()
        {
            Coorientador = new HashSet<Coorientador>();
            PropostaSubmetida = new HashSet<PropostaSubmetida>();
        }

        [Key]
        public int id_atribuicao { get; set; }

        [Required]
        [StringLength(10)]
        public string fk_professor { get; set; }

        public int fk_curso { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_fim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coorientador> Coorientador { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Professor Professor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropostaSubmetida> PropostaSubmetida { get; set; }
    }
}
