using HBMS.Models.models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MODELS.Models
{
    public partial class Room
    {
        public Room()
        {
            BookingDetail = new HashSet<BookingDetail>();
        }

        public int RoomNo { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int RatePerNight { get; set; }
     
        public int Capacity { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        [JsonIgnore]
        public virtual ICollection<BookingDetail> BookingDetail { get; set; }
    }
}
