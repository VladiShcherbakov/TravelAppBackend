using System.ComponentModel.DataAnnotations;

namespace TravelApp.TravelApp.Models
{
    public class TravelPlanModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime TripStart { get; set; }

        [StringLength(50)]
        public string ImagePath { get; set; }

        public IEnumerable<TravelInfoModel> TravelInfos { get; set; }  
    }
}
