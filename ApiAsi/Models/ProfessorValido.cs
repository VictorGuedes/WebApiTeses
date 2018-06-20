namespace ApiAsi.Models
{
    using Newtonsoft.Json;
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

        [JsonIgnore]
        [Key]
        public int id_atribuicao { get; set; }

        [JsonIgnore]
        [Required]
        [StringLength(10)]
        public string fk_professor { get; set; }

        [JsonIgnore]
        public int fk_curso { get; set; }

        [JsonIgnore]
        [Column(TypeName = "date")]
        public DateTime date_inicio { get; set; }

        [JsonIgnore]
        [Column(TypeName = "date")]
        public DateTime? date_fim { get; set; }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coorientador> Coorientador { get; set; }

        [JsonIgnore]
        public virtual Curso Curso { get; set; }

        [JsonIgnore]
        public virtual Professor Professor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropostaSubmetida> PropostaSubmetida { get; set; }
    }
}
