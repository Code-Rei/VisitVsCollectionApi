using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientAPI.Model
{

    [Table("UnitWise", Schema = "dbo")]
    public class UnitWise
    {
        [Key]  // Mark the correct key column
        public string Unit { get; set; }

        public string BH { get; set; }
        public string Funder { get; set; }
        public string State { get; set; }
        public double Visited_Clients { get; set; }
        public double? Reduced { get; set; }
        public double? Collected { get; set; }
        public double? Collected_Amount { get; set; }

        // Add all other actual columns from your table
    }
}