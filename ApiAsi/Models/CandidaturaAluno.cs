namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CandidaturaAluno")]
    public partial class CandidaturaAluno
    {
        [Key]
        public int id_candidaturaaluno { get; set; }

        [Required]
        [StringLength(10)]
        public string fk_aluno { get; set; }

        public int fk_proposta { get; set; }

        public int fk_periodocandidatura { get; set; }

        public DateTime data_submissao { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual PeriodoCandidatura PeriodoCandidatura { get; set; }

        public virtual PropostaSubmetida PropostaSubmetida { get; set; }
    }
}
