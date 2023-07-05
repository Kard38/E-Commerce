using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MvcWebUI.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage ="Geçerli bir eposta adresi giriniz.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Parola tekrar")]
        [Compare("Password",ErrorMessage ="Parolalar uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}