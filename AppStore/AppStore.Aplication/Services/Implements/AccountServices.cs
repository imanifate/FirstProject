using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Data.Repositoreis;
using AppStore.Domain.Contracts;
using AppStore.Domain.Enums;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;
using Store.Aplication.Security;
using AppStore.Aplication.Utilities;


namespace AppStore.Aplication.Services.Implements
{
    public class AccountServices(IAccountRepository accountRepository): IAccountServices
    {
        public ResultCreat Creat(CreatAccountViewModel creatAccountViewModel)
        {
            if (creatAccountViewModel != null)
            {
                if (accountRepository.EmailDuplicate(creatAccountViewModel.Email)) return ResultCreat.EmailDuplicated;
                if (accountRepository.UserNameDuplicate(creatAccountViewModel.UserName)) return ResultCreat.UsreNameDuplicated;
                accountRepository.Creat(new Account
                {
                    UserName = creatAccountViewModel.UserName,
                    Email = creatAccountViewModel.Email,
                    Password = PasswordHasher.EncodePasswordMd5(creatAccountViewModel.Password),
                    Rules = creatAccountViewModel.Rules,
                    ActiveCode = creatAccountViewModel.ActiveCode
                });
                accountRepository.Save();
                return ResultCreat.Success;
            }
            else return ResultCreat.Null;
        }
            
       
        public ResultActivaAccount UserActivate(string ActiveCode)
        {
            Account account = accountRepository.GetByIsActive(ActiveCode);
            if (account != null)
            {
                account.IsActive = true;
                account.ActiveCode = CodeGenerators.ActiveCode();
                accountRepository.EditAccount(account);
                accountRepository.Save();
                return ResultActivaAccount.Success;
            }
            return ResultActivaAccount.Error;
        }

        public Account Login(LoginAccountViewModel login)
        {
            Account account = accountRepository.Login(login.UserNameOrEmail , PasswordHasher.EncodePasswordMd5(login.Password));
            if (account == null) return null;
            return account;
        }
    }
}
