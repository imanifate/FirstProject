using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Data.Context;
using AppStore.Domain.Contracts;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Data.Repositoreis
{
    public class AccountRepository (AppStore_DB_Context _appStore_DB_Context) : IAccountRepository
    {
        public List<Account> List()

        {
            return _appStore_DB_Context.Accounts.ToList();
        }

        public void Creat(Account account)
        {
            _appStore_DB_Context.Add(account);
        }

        public void Save()
        {
            _appStore_DB_Context.SaveChanges();
        }
        public bool EmailExite(string email)
        {
            return _appStore_DB_Context.Accounts.Any(a => a.Email == email);
        }


        public bool UserNameExite(string userName)
        {
            return _appStore_DB_Context.Accounts.Any(a => a.UserName == userName);
        }


        public bool EmailDuplicate(EditAccountViewModel editAccountViewModel)
        {
            return _appStore_DB_Context.Accounts.Any(a => a.Email == editAccountViewModel.Email && a.Id != editAccountViewModel.AccountId);
        }


        public bool UserNameDuplicate(EditAccountViewModel editAccountViewModel)
        {
            return _appStore_DB_Context.Accounts.Any(a => a.UserName == editAccountViewModel.UserName && a.Id != editAccountViewModel.AccountId);
        }
        public Account GetByIsActive(string code)
        {
            return _appStore_DB_Context.Accounts.FirstOrDefault(u => u.IsActive == false && u.ActiveCode == code);
        }
        public Account GetById(int id)
        {
          return  _appStore_DB_Context.Accounts.FirstOrDefault (i => i.Id == id);
            
        }
        public void EditAccount(Account account)
        {
            _appStore_DB_Context.Accounts.Update(account);
        }
        public Account Login(string userNameOrEmail , string password)
        {
            Account account = _appStore_DB_Context.Accounts.FirstOrDefault
                (U => (U.UserName == userNameOrEmail || U.Email == userNameOrEmail)
                              && U.Password == password 
                              && U.IsActive == true
                              && U.IsDelete == false
                              );
            return account;
        }

    }
}
