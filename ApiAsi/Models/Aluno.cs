namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aluno")]
    public partial class Aluno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aluno()
        {
            CandidaturaAluno = new HashSet<CandidaturaAluno>();
            Proposta = new HashSet<Proposta>();
            ResultadosAvaliacao = new HashSet<ResultadosAvaliacao>();
        }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Required]
        [StringLength(50)]
        public string curriculo { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_nascimento { get; set; }

        [Key]
        [StringLength(10)]
        public string numero_mecanografico { get; set; }

        public float media_licenciatura { get; set; }

        public int fk_curso { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user_login { get; set; }

        public bool eramus { get; set; }

        [StringLength(10)]
        public string sinc_code_ext { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidaturaAluno> CandidaturaAluno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proposta> Proposta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultadosAvaliacao> ResultadosAvaliacao { get; set; }
    }
}
