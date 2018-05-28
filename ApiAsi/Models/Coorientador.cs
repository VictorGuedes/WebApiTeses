namespace ApiAsi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coorientador")]
    public partial class Coorientador
    {
        [Key]
        public int id_atribuicao { get; set; }

        public int fk_proposta_submetida { get; set; }

        public int fk_professor_professor_val { get; set; }

        public virtual ProfessorValido ProfessorValido { get; set; }

        public virtual PropostaSubmetida PropostaSubmetida { get; set; }
    }
}
