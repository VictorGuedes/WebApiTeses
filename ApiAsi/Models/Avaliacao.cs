namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Avaliacao")]
    public partial class Avaliacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Avaliacao()
        {
            ResultadosAvaliacao = new HashSet<ResultadosAvaliacao>();
            SubmissaoAvaliacao = new HashSet<SubmissaoAvaliacao>();
        }

        [Key]
        public int id_avaliacao { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user_criador { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_fim { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_resumissao { get; set; }

        [Required]
        [StringLength(25)]
        public string epoca { get; set; }

        [StringLength(500)]
        public string descricao { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultadosAvaliacao> ResultadosAvaliacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmissaoAvaliacao> SubmissaoAvaliacao { get; set; }
    }
}
