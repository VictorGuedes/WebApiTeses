namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PeriodoCandidatura")]
    public partial class PeriodoCandidatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PeriodoCandidatura()
        {
            CandidaturaAluno = new HashSet<CandidaturaAluno>();
        }

        [Key]
        public int id_candidatura { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_fim { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tolerancia { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user_criador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidaturaAluno> CandidaturaAluno { get; set; }

        public virtual User User { get; set; }
    }
}
