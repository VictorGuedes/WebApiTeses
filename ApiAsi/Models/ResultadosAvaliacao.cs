namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResultadosAvaliacao")]
    public partial class ResultadosAvaliacao
    {
        [Key]
        public int id_resultado { get; set; }

        [Required]
        [StringLength(10)]
        public string fk_aluno { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_atribuicao { get; set; }

        public float nota { get; set; }

        public int fk_avaliacao { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Avaliacao Avaliacao { get; set; }
    }
}
