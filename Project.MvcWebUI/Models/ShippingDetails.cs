using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MvcWebUI.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }

        [Required(ErrorMessage ="Adres tanımı boş bırakılamaz.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Adres bilgisi boş bırakılamaz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Sehir bilgisi boş bırakılamaz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Semt bilgisi boş bırakılamaz.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Mahelle bilgisi boş bırakılamaz.")]
        public string Mahelle { get; set; }
        public string PostaKodu { get; set; }
    }
}