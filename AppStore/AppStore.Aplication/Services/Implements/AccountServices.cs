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
        public List<ListAccountViewModels> List()
        {

            List<Account> accounts = accountRepository.List();
            
            return accounts.Select(c => new ListAccountViewModels()
            {
                AccountId = c.Id,
                UserName = c.UserName,
                Email = c.Email,
                CreatDate = c.CreatDate,
                IsActive = c.IsActive,
                IsAdmin = c.IsAdmin,
                IsDelete = c.IsDelete
            }).ToList();
        }

        public ResultCreat Register(RegisterAccountViewModel registerAccountViewModel)
        {
            if (registerAccountViewModel != null)
            {
                if (accountRepository.EmailExite(registerAccountViewModel.Email)) return ResultCreat.EmailDuplicated;
                if (accountRepository.UserNameExite(registerAccountViewModel.UserName)) return ResultCreat.UsreNameDuplicated;
                accountRepository.Creat(new Account
                {
                    UserName = registerAccountViewModel.UserName,
                    Email = registerAccountViewModel.Email,
                    Password = PasswordHasher.EncodePasswordMd5(registerAccountViewModel.Password),
                    Rules = registerAccountViewModel.Rules,
                    ActiveCode = registerAccountViewModel.ActiveCode
                });
                accountRepository.Save();
                return ResultCreat.Success;
            }
            else return ResultCreat.Null;
        }
        public ResultCreat Creat(CreatAccountViewModel creatAccountViewModel)
        {
            if (creatAccountViewModel != null)
            {
                if (accountRepository.UserNameExite(creatAccountViewModel.Email)) return ResultCreat.EmailDuplicated;
                if (accountRepository.UserNameExite(creatAccountViewModel.UserName)) return ResultCreat.UsreNameDuplicated;
                accountRepository.Creat(new Account
                {
                    UserName = creatAccountViewModel.UserName,
                    Email = creatAccountViewModel.Email,
                    Password = PasswordHasher.EncodePasswordMd5(creatAccountViewModel.Password),
                    Rules = true,
                    ActiveCode = creatAccountViewModel.ActiveCode,
                    IsActive = creatAccountViewModel.IsActive,
                    IsAdmin =   creatAccountViewModel.IsAdmin,
                });
                accountRepository.Save();
                return ResultCreat.Success;
            }
            else return ResultCreat.Null;
        }

        
        public EditAccountViewModel GetByIdForEdit(int id)
        {
           Account account = accountRepository.GetById(id);
            if (account == null) return null;
            return new EditAccountViewModel()
            {
                AccountId= account.Id,
               UserName= account.UserName,
               Email = account.Email,
               IsActive= account.IsActive,
               IsAdmin= account.IsAdmin,
               IsDelete = account.IsDelete
            };

        }

       public ResultEdit Edit(EditAccountViewModel editAccountViewModel)
        {
            Account account = accountRepository.GetById(editAccountViewModel.AccountId);
            if(account==null) return ResultEdit.Null;
            if(accountRepository.EmailDuplicate(editAccountViewModel) ) return ResultEdit.EmailDuplicated;
            if (accountRepository.UserNameDuplicate(editAccountViewModel) ) return ResultEdit.UsreNameDuplicated;
            account.UserName = editAccountViewModel.UserName;
            account.Email = editAccountViewModel.Email;
            account.IsActive = editAccountViewModel.IsActive;
            account.IsAdmin = editAccountViewModel.IsAdmin;
            account.IsDelete = editAccountViewModel.IsDelete;
            account.ModifiedDate = editAccountViewModel.ModifiedDate;
            accountRepository.EditAccount(account);
            accountRepository.Save();
            return ResultEdit.Success;
        }

        public ResultDelete Delete(int accountId)
        {
            Account account=accountRepository.GetById(accountId);   
            if( account==null ) return ResultDelete.Null;
            account.IsDelete= true;
            accountRepository.EditAccount(account);
            accountRepository.Save();
            return ResultDelete.Success;
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
