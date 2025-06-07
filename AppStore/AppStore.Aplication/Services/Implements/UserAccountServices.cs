using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Contracts;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;

namespace AppStore.Aplication.Services.Implements
{
    public class UserAccountServices (IUserAccountRepository userAccountRepository): IUserAccountServices
    {
        public List<AccountListViewModels> AccountList()
        {
            List<Account> accounts = userAccountRepository.AccountList();
            return accounts.Select( c => new AccountListViewModels()
            {
                AccountId = c.Id,
                UserName = c.UserName,
                Email = c.Email,
                CreatDate= c.CreatDate,
                IsActive = c.IsActive,
                IsAdmin = c.IsAdmin,
                IsDelete = c.IsDelete
            }).ToList();
        }
    }
}
