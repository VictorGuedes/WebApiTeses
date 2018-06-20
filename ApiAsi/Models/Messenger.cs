namespace ApiAsi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Messenger")]
    public partial class Messenger
    {
        [Key]
        public int id_messsenger { get; set; }

        [JsonIgnore]
        public int fk_proposta { get; set; }

       
        public virtual Proposta Proposta { get; set; }
    }
}
