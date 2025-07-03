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
        ResultCreatAccount Register(RegisterAccountViewModel creatAccountViewModel);
        ResultCreatAccount Creat(CreatAccountViewModel creatAccountByAdminViewModel);
        EditAccountViewModel GetByIdForEdit(int id);
        ResultEditAccount Edit(EditAccountViewModel editAccountViewModel);
        ResultDeleteAccount Delete(int accountId);

        ResultActivaAccount UserActivate(string ActiveCode);
        Account Login(LoginAccountViewModel login);
        List<ListAccountViewModels> List();
        ResultChangePassword ChangePassword(ChangePasswordViewModel changePassword);
        string GetActivCode(ForgetPasswordViewModel forgetPasswordViewModel);
        ResultResetPassword ResetPassword(ResetPasswordViewMdel resetPasswordViewMdel);


    }
}
