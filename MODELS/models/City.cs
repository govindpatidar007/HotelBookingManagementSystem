using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MODELS.Models
{
    public partial class City
    {
        public City()
        {
            Hotel = new HashSet<Hotel>();
        }

        public int CityId { get; set; }
        [Required]

        [Display(Name = "City")]
        public string CityName { get; set; }
        [JsonIgnore]

        public virtual ICollection<Hotel> Hotel { get; set; }
    }
}
