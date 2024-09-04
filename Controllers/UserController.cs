using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using UserUsing.Models;

namespace UserUsing.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel model)
        {
            SHA384 sha = new SHA384CryptoServiceProvider();

            // Sifre1 için hashleme
            string SifrelenmisSifre1 = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Sifre)));

            // Sifre2 için hashleme
            string SifrelenmisSifre2 = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Sifre2)));

            // Hashlenmiş şifreleri modelde saklayabilirsiniz
            model.Sifre = SifrelenmisSifre1;
            model.Sifre2 = SifrelenmisSifre2;

            // Şifrelerin kaydedilmesi işlemi burada yapılabilir
            ViewBag.Message = "Şifreler başarıyla hashlenip saklandı!";
            if (ModelState.IsValid)
            {
                if (model.Sifre != model.Sifre2)
                {
                    ViewBag.ErrorMessage = "Şifreler Eşleşmiyor";
                    ViewBag.Mesaj = model.Sifre2;
                }

                
            }

            return View(model);
        }
    }
}
