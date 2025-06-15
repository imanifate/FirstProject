using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Enums;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;

namespace AppStore.Aplication.Services.Interfaces
{
    public interface IAccountServices
    {
        ResultCreat Register(RegisterAccountViewModel creatAccountViewModel);
        ResultCreat Creat(CreatAccountViewModel creatAccountByAdminViewModel);
        EditAccountViewModel GetByIdForEdit(int id);
        ResultEdit Edit(EditAccountViewModel editAccountViewModel);
        ResultDelete Delete(int accountId);

        ResultActivaAccount UserActivate(string ActiveCode);
        Account Login(LoginAccountViewModel login);
        List<ListAccountViewModels> List();



    }
}
