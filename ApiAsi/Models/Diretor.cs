namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diretor")]
    public partial class Diretor
    {
        [Key]
        public int id_atribuicao { get; set; }

        public int fk_curso { get; set; }

        [Required]
        [StringLength(10)]
        public string fk_professor { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        public bool iscurrent { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Professor Professor { get; set; }
    }
}
