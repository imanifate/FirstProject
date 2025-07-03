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
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;


namespace AppStore.Web.Controllers
{
    public class AccountController(IAccountServices accountServices) : BaseController
    {
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterAccountViewModel creatAccountViewModel)
        {
            if(!ModelState.IsValid) return View(nameof(Register));
            creatAccountViewModel.ActiveCode = CodeGenerators.ActiveCode();
            ResultCreatAccount result=accountServices.Register(creatAccountViewModel);
            switch (result)
            {
                case ResultCreatAccount.Success:
                    {
                        MessageSender.Email(creatAccountViewModel.Email, "فعال سازی  فروشگاه ساز", $"به فروشگاه ما  خوش آمدید " +
                            $"{Environment.NewLine} کد فعال سازی: {creatAccountViewModel.ActiveCode}");
                        AlertMessage("کد فعال سازی به ایمیل شما ارسال شد", TitleAlert.موفق, IConeAlert.success);
                        return RedirectToAction(nameof(Active));
                    }
                case ResultCreatAccount.EmailDuplicated:
                    AlertMessage("ایمیل وارد شده تکراری است", TitleAlert.خطا, IConeAlert.error);

                    break;
                case ResultCreatAccount.UsreNameDuplicated:
                    AlertMessage("نام کاربری وارد شده تکراری است", TitleAlert.خطا, IConeAlert.error);

                    break;
                case ResultCreatAccount.Error:
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

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginAccountViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);  

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

            AuthenticationProperties properties = new()
            {
                IsPersistent = login.RememberMe  
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, properties);

            if (account.IsAdmin)
                return Redirect("/admin");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }



        [HttpGet("ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordViewModel changePasswoed)
        {

            ResultChangePassword result = accountServices.ChangePassword(changePasswoed);
            switch (result)
            {
                case ResultChangePassword.Success:
                    {
                        Logout();
                        AlertMessage("تغییر رمز عبور با موفقیت انجام شد", TitleAlert.موفق, IConeAlert.success);

                        return RedirectToAction(nameof(Login));
                    }
                case ResultChangePassword.OldPasswordInvalid:
                    AlertMessage("رمز وارد شده اشتباه میباشد", TitleAlert.خطا, IConeAlert.error); break;

                case ResultChangePassword.Error:
                    AlertMessage("خطا", TitleAlert.خطا, IConeAlert.error); break;

            }

            return View(nameof(ChangePassword));
        }
        [HttpGet("ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost("ForgetPassword")]
        public IActionResult ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            string activeCode = accountServices.GetActivCode(forgetPasswordViewModel);
            if(activeCode == null)  ModelState.AddModelError("Error", "کد فعال سازی را وارد کنید");
                MessageSender.Email(forgetPasswordViewModel.Email, "فعال سازی آسان بوک", $"به   خوش آمدید " +
                              $"{Environment.NewLine} کد فعال سازی: {activeCode}");
                return View(nameof(ResetPassword));
        }

        [HttpGet("ResetPassword")]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword(ResetPasswordViewMdel resetPasswordViewMdel)
        {
            if(!ModelState.IsValid) return View(nameof(Active));
            ResultResetPassword result = accountServices.ResetPassword(resetPasswordViewMdel);
            switch (result)
            {
                case ResultResetPassword.Success: return RedirectToAction(nameof(Login));
                case ResultResetPassword.Null:
                    AlertMessage("کد فعال سازی معتبر نیست!", TitleAlert.خطا, IConeAlert.error); break;
            }

            return View(resetPasswordViewMdel);
        }

    }
}
