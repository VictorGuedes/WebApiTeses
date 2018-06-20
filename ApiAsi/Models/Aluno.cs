namespace ApiAsi.Models
{
    using Newtonsoft.Json;
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

        [JsonIgnore]
        [Required]
        [StringLength(50)]
        public string curriculo { get; set; }

        [JsonIgnore]
        [Column(TypeName = "date")]
        public DateTime date_nascimento { get; set; }

        [JsonIgnore]
        [Key]
        [StringLength(10)]
        public string numero_mecanografico { get; set; }

        [JsonIgnore]
        public float media_licenciatura { get; set; }

        [JsonIgnore]
        public int fk_curso { get; set; }

        [JsonIgnore]
        [Required]
        [StringLength(128)]
        public string fk_user_login { get; set; }

        [JsonIgnore]
        public bool eramus { get; set; }

        [JsonIgnore]
        [StringLength(10)]
        public string sinc_code_ext { get; set; }
        [JsonIgnore]
        public virtual Curso Curso { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidaturaAluno> CandidaturaAluno { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proposta> Proposta { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultadosAvaliacao> ResultadosAvaliacao { get; set; }
    }
}
