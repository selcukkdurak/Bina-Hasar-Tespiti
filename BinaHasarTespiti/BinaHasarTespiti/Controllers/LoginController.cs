using BinaHasarTespiti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace BinaHasarTespiti.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn(string kullaniciAdi, string sifre)
        {
            using (BinaHasarDurumEntities db = new BinaHasarDurumEntities())
            {
                var kullanici = db.KullaniciTable.Where(w => w.kullaniciAdi == kullaniciAdi && w.sifre == sifre).FirstOrDefault();

                if (kullanici != null)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.kullaniciAdi, false);
                    Session["kullaniciAdi"] = kullanici.kullaniciAdi;
                    return Redirect("/Adress/Adress");
                }
                else
                {
                    return RedirectToAction("Index", new { hata = "Kullanıcı Bulunamadı!" });
                }
            }
        }
        public ActionResult ResetBasic()
        {
            return View();
        }
        public ActionResult SignUp()
        {

            return View();
        }
        public ActionResult Register(string username, string password, string email)
        {
            using (BinaHasarDurumEntities db = new BinaHasarDurumEntities())
            {
                KullaniciTable yeniKullanici = new KullaniciTable
                {
                    kullaniciAdi = username,
                    sifre = password,
                    email = email
                };
                var result = db.KullaniciTable.Add(yeniKullanici);

                if (result.kullaniciAdi != "abc")
                {
                    db.SaveChanges();
                    return Redirect("/Login/Index");
                }
                else
                {
                    return RedirectToAction("SignUp", new { error = "Kayıt işleminiz başarısız!" });
                }
            }
        }
        public ActionResult SendActivationEmail(string email, string activationCode)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.example.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("selcukkdurak@gmail.com", "password");
                smtpClient.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("selcukkdurak@gmail.com", "Selçuk");
                mail.To.Add(email);
                mail.Subject = "Üyelik Aktivasyon Kodu";
                mail.Body = $"Üyelik aktivasyon kodunuz: {activationCode}";

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderme hatası: {ex.Message}");
            }
            return View();
        }
    }
}