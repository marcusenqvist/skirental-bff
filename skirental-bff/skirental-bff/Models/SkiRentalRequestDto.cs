using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace skirental_bff.Models
{
    public class SkiRentalRequestDto
    {
        [Required]
        [Range(0, 250)]
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [Required]
        [JsonPropertyName("ageCategory")]
        public string? AgeCategory { get; set; }

        [Required]
        [JsonPropertyName("skiType")]
        public string? SkiType { get; set; }
    }
}