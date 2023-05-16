using System.ComponentModel.DataAnnotations;

namespace TravelApp.TravelApp.Models
{
    public class TravelInfoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public TravelPlanModel PlanModel { get; set; }

        public string Xid { get; set; }

        public DateTime Time { get; set; }
    }
}
