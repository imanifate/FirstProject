using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;
using AppStore.Aplication.Utilities;
using AppStore.Web.Controllers;
using AppStore.Domain.Models;


namespace AppStore.Web.Controllers
{
    public class AccountController(IAccountServices accountServices) : BaseController
    {
        [HttpGet("Creat")]
        public IActionResult Creat()
        {
            return View();
        }

        [HttpPost("Creat")]
        public IActionResult Creat(CreatAccountViewModel creatAccountViewModel)
        {
            if(!ModelState.IsValid) return View(nameof(Creat));
            creatAccountViewModel.ActiveCode = CodeGenerators.ActiveCode();
            ResultCreat result=accountServices.Creat(creatAccountViewModel);
            switch (result)
            {
                case ResultCreat.Success:
                    {
                        MessageSender.Email(creatAccountViewModel.Email, "فعال سازی  فروشگاه ساز", $"به فروشگاه ما  خوش آمدید " +
                            $"{Environment.NewLine} کد فعال سازی: {creatAccountViewModel.ActiveCode}");
                        AlertMessage("کد فعال سازی به ایمیل شما ارسال شد", TitleAlert.موفق, IConeAlert.success);
                        return RedirectToAction(nameof(Active));
                    }
                case ResultCreat.EmailDuplicated:
                    AlertMessage("ایمیل وارد شده تکراری است", TitleAlert.خطا, IConeAlert.error);

                    break;
                case ResultCreat.UsreNameDuplicated:
                    AlertMessage("نام کاربری وارد شده تکراری است", TitleAlert.خطا, IConeAlert.error);

                    break;
                case ResultCreat.Error:
                    AlertMessage("ثبت نام با خطا مواجه شد", TitleAlert.هشدار, IConeAlert.warning);

                    break;
                default:
                    AlertMessage("ثبت نام با خطا مواجه شد", TitleAlert.هشدار, IConeAlert.error);

                    break;
            }
            return View();
        }

        [HttpGet("Active")]
        public IActionResult Active()
        {
            return View(); 
        }

        [HttpPost("Active")]
        public IActionResult Active(ActiveViewModel active)
        {
            if (!ModelState.IsValid) return View(nameof(Active));
            ResultActivaAccount result = accountServices.UserActivate(active.ActiveCode);
            switch (result)
            {
                case ResultActivaAccount.Success: return RedirectToAction(nameof(Login));
                case ResultActivaAccount.Error:
                    AlertMessage("کد فعال سازی اشتباه است", TitleAlert.هشدار, IConeAlert.error); break;
            }

            return View(active);
        }

        [HttpGet ("Login")]
        public IActionResult Login()
        { 
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginAccountViewModel login)
        {
            if (!ModelState.IsValid) return View(nameof(Creat));
            Account account = accountServices.Login(login);
            if (account == null)
            {
                AlertMessage("نام کاربری یا رمز عبور اشتباه است", TitleAlert.خطا, IConeAlert.error);
                return View(login);
            }
            List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Email, account.Email),
            new Claim(ClaimTypes.Name, account.UserName),
            new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new Claim("IsAdmin", account.IsAdmin.ToString())
        };

            ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);
            AuthenticationProperties properties = new() { IsPersistent = login.RemmberMe };
            HttpContext.SignInAsync(claimsPrincipal, properties);
            if (account.IsAdmin) return Redirect("/admin");
            return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
