using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MODELS.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Room = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Room> Room { get; set; }
    }
}
