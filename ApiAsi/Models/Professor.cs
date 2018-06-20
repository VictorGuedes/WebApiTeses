namespace ApiAsi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Professor")]
    public partial class Professor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Professor()
        {
            Diretor = new HashSet<Diretor>();
            ProfessorValido = new HashSet<ProfessorValido>();
        }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [JsonIgnore]
        [Column(TypeName = "date")]
        public DateTime data_nascimento { get; set; }

        [JsonIgnore]
        [Key]
        [StringLength(10)]
        public string numero_meca { get; set; }

        [JsonIgnore]
        public int fk_departamento { get; set; }

        [JsonIgnore]
        [Required]
        [StringLength(30)]
        public string curriculo_vitae { get; set; }

        [JsonIgnore]
        [Required]
        [StringLength(128)]
        public string fk_user { get; set; }

        [JsonIgnore]
        public int fk_categoria { get; set; }

        [JsonIgnore]
        public virtual Categoriaprofessor Categoriaprofessor { get; set; }

        [JsonIgnore]
        public virtual Departamento Departamento { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diretor> Diretor { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfessorValido> ProfessorValido { get; set; }
    }
}
