using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientAPI.Model
{

        [Table("odNPA")]
        public class odNPA
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string BH { get; set; }

            [Required]
            public string Funder { get; set; }

            [Required]
            public string State { get; set; }

            [Required]
            public string UnitName { get; set; }

            public bool isReduction { get; set; }
            public bool iscollection { get; set; }
            public decimal Collection_Amount { get; set; }
        }
    }

