using System.ComponentModel.DataAnnotations;

namespace UserUsing.Models
{
    public class UserModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Giriniz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Şifre Giriniz")]
        public string Sifre {  get; set; }
        public string Sifre2 { get; set; }

    }
}
