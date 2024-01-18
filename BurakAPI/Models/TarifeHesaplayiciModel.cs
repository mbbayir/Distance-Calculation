using System.ComponentModel.DataAnnotations;

namespace BurakAPI.Models
{
    public class TarifeHesaplayiciModel
    {
        [Key]
        public int Id { get; set; }

        public string BaslangicAdres { get; set; }

        public string VarisAdres { get; set; }

        public double? Mesafe { get; set; }

        public string HataMesaji { get; set; }
    }
}
