using HBMS.Models.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MODELS.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            BookingDetail = new HashSet<BookingDetail>();
            Room = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public int CityId { get; set; }
        [Required]
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone Number Should be 10 digits long")]
        public long Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Average Rate Per Night")]
        public int AvgRatePerNight { get; set; }

        public virtual City City { get; set; }
        [JsonIgnore]
        public virtual ICollection<BookingDetail> BookingDetail { get; set; }
        [JsonIgnore]
        public virtual ICollection<Room> Room { get; set; }
    }
}
