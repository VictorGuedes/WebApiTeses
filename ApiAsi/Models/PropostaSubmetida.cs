namespace ApiAsi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PropostaSubmetida")]
    public partial class PropostaSubmetida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PropostaSubmetida()
        {
            CandidaturaAluno = new HashSet<CandidaturaAluno>();
            Coorientador = new HashSet<Coorientador>();
            Proposta = new HashSet<Proposta>();
        }

        [Key]
        public int id_proposta_submetida { get; set; }

        [Required]
        [StringLength(25)]
        public string titulo { get; set; }

        [Required]
        [StringLength(25)]
        public string palavras_chaves { get; set; }

        [Required]
        [StringLength(500)]
        public string objetivo { get; set; }

        [Required]
        [StringLength(1000)]
        public string descricao_adicional { get; set; }

        [Required]
        [StringLength(1000)]
        public string metodologia { get; set; }

        [Required]
        [StringLength(500)]
        public string recursos_necessarios { get; set; }

        [JsonIgnore]
        public DateTime data_criaçao { get; set; }

        [JsonIgnore]
        public bool criadaaluno { get; set; }

        [Required]
        [StringLength(128)]
        public string fk_user { get; set; }

        [JsonIgnore]
        public int fk_curso { get; set; }

        public int orientador { get; set; }

        public int? isRejected { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidaturaAluno> CandidaturaAluno { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coorientador> Coorientador { get; set; }

        [JsonIgnore]
        public virtual Curso Curso { get; set; }

        [JsonIgnore]
        public virtual ProfessorValido ProfessorValido { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proposta> Proposta { get; set; }

        public virtual User User { get; set; }
    }
}
