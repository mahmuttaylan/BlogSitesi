using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Concrete.Context;
using BlogProject.DAL.Entities;
using BlogProject.DAL.UnitOfWorks;
using BlogProject.DAL.ViewModels.Users;
using FluentValidation;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Data;

namespace BlogProject.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IValidator<AppUser> _validator;
        private readonly AppIdentityContext _appIdentityContext;

        public RegisterController(UserManager<AppUser> userManager, IValidator<AppUser> validator, AppIdentityContext appIdentityContext)
        {
            _userManager = userManager;
            _validator = validator;
            _appIdentityContext = appIdentityContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(userRegisterVM);
        //    }

        //    Random rnd = new Random();      //mail aktivasyonu için kod ürettik.
        //    int code = rnd.Next(100000, 1000000);

        //    AppUser user = new AppUser() 
        //    { 
        //        FirstName = userRegisterVM.FirstName,
        //        LastName = userRegisterVM.LastName,
        //        UserName = userRegisterVM.Email,
        //        Email = userRegisterVM.Email,
        //        PhoneNumber = userRegisterVM.PhoneNumber,
        //        ConfirmCode = code,
        //        About = userRegisterVM.About
        //    };

        //    if (userRegisterVM.ConfirmPassword == null || userRegisterVM.ConfirmPassword != userRegisterVM.Password)
        //    {
        //        ModelState.AddModelError("", "Doğrulama şifresini yanlış girdiniz.");
        //        return View(userRegisterVM);
        //    }

        //    var validation = await _validator.ValidateAsync(user);
        //    var result = await _userManager.CreateAsync(user, string.IsNullOrEmpty(userRegisterVM.Password) ? "" : userRegisterVM.Password);    //Şifreyi girmeyince hata fırlatıyordu. Ternary If kullanarak şifre boşsa null getirdik. Böylece validasyon hatasına gittik.

        //    if (!result.Succeeded)
        //    {
        //        result.AddToIdentityModelState(this.ModelState);
        //        validation.AddToModelState(this.ModelState);
        //        return View(userRegisterVM);
        //    }

        //    IdentityUserRole<int> role = new IdentityUserRole<int>()    //Üyeye default Author rolü atamak için.
        //    {
        //        UserId =user.Id,
        //        RoleId = userRegisterVM.RoleId
        //    };
        //    _appIdentityContext.UserRoles.Add(role);
        //    _appIdentityContext.SaveChanges();

        //    MimeMessage mimeMessage = new MimeMessage();
        //    MailboxAddress mailboxAddressFrom = new MailboxAddress("BlogProject Admin", "mahmuttaylan3@gmail.com");
        //    MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);
        //    mimeMessage.From.Add(mailboxAddressFrom);
        //    mimeMessage.To.Add(mailboxAddressTo);

        //    var bodyBuilder = new BodyBuilder();
        //    bodyBuilder.TextBody = $"Kayıt işlemini gerçekleştirmek için onay kodunuz: {code}";
        //    mimeMessage.Body = bodyBuilder.ToMessageBody();
        //    mimeMessage.Subject = "BlogProject Üyelik Onay Kodu";

        //    SmtpClient smtpClient = new SmtpClient();

        //    //Gmail Türkiye kodu = 587
        //    smtpClient.Connect("smtp.gmail.com", 587, false);

        //    //Gmail'i aç. ayarlara gel. Güvenlik ayarları çift taraflı doğrulama açık olacak. arama kutusuna uygulama şifreleri yaz. gelen ekranda bir cihaz tanımla çıkan şifreyi buraya yapıştır.
        //    smtpClient.Authenticate("mahmuttaylan3@gmail.com", "cnig febp nlji rkub");
        //    smtpClient.Send(mimeMessage);
        //    smtpClient.Disconnect(true);

        //    TempData["Mail"] = userRegisterVM.Email;

        //    return RedirectToAction("Index", "ConfirmMail");
        //}

        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterVM);
            }

            if (userRegisterVM.ConfirmPassword == null || userRegisterVM.ConfirmPassword != userRegisterVM.Password)
            {
                ModelState.AddModelError("", "Tekrar şifresini yanlış girdiniz.");
                return View(userRegisterVM);
            }

            try
            {
                Random rnd = new Random();
                int code = rnd.Next(100000, 1000000);

                AppUser user = new AppUser()
                {
                    FirstName = userRegisterVM.FirstName,
                    LastName = userRegisterVM.LastName,
                    UserName = userRegisterVM.Email,
                    Email = userRegisterVM.Email,
                    PhoneNumber = userRegisterVM.PhoneNumber,
                    ConfirmCode = code,
                    About = userRegisterVM.About
                };

                var validation = await _validator.ValidateAsync(user);
                var result = await _userManager.CreateAsync(user, string.IsNullOrEmpty(userRegisterVM.Password) ? "" : userRegisterVM.Password);

                if (!result.Succeeded)
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(userRegisterVM);
                }

                IdentityUserRole<int> role = new IdentityUserRole<int>()
                {
                    UserId = user.Id,
                    RoleId = userRegisterVM.RoleId
                };

                _appIdentityContext.UserRoles.Add(role);
                _appIdentityContext.SaveChanges();

                try
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("BlogProject Admin", "mahmuttaylan3@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = $"Kayıt işlemini gerçekleştirmek için onay kodunuz: {code}";
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "BlogProject Üyelik Onay Kodu";

                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        smtpClient.Connect("smtp.gmail.com", 587, false);
                        smtpClient.Authenticate("mahmuttaylan3@gmail.com", "cnig febp nlji rkub");
                        smtpClient.Send(mimeMessage);
                        smtpClient.Disconnect(true);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Mail gönderme işlemi başarısız oldu. Lütfen daha sonra tekrar deneyiniz.");
                    // Hata loglama eklenebilir.
                }

                TempData["Mail"] = userRegisterVM.Email;

                return RedirectToAction("Index", "ConfirmMail");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Kayıt işlemi sırasında bir hata oluştu. Lütfen tekrar deneyiniz.");
                // Hata loglama eklenebilir.
                return View(userRegisterVM);
            }
        }

    }
}
