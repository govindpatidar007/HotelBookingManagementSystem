using MODELS.Models;
using MODELS.Models.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HBMS.Models.models
{
    //public static int Compare(DateTime Bookedfrom, DateTime BookedTo)
    //{ }
    public partial class BookingDetail
    {
        public int BookingId { get; set; }
        [Display(Name = "RoomNo")]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        [Required]
        [CustomDate(ErrorMessage = " Date must be greater than or equal to Today's Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "From")]
        public DateTime BookedFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "To")]
        public DateTime BookedTo { get; set; }


        [Required]
        public int ChildrenNo { get; set; }
        [Required]
        public int AdultNo { get; set; }
        
        public int Amount { get; set; }
        [Display(Name = "Status")]
        public bool BookingStatus { get; set; }

        public virtual Hotel Hotel { get; set; }   /// <summary>
        //virtual
        /// </summary>
        public virtual Room Room { get; set; }//virtual
    }
}
