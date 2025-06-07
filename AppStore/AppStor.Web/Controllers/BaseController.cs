using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;

namespace AppStore.Web.Controllers;

public class BaseController : Controller
{
    protected void AlertMessage(string message, TitleAlert titleAlert, IConeAlert iconeAlert)
    {
        TempData["Alert"] = JsonConvert.SerializeObject(new AlertMessageViewModel
        {
            Title = titleAlert.ToString(),
            Text = message,
            Icon = iconeAlert.ToString(),
        });
    }
}
