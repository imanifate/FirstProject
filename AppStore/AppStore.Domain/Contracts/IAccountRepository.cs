using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;

namespace AppStore.Domain.Contracts
{
    public interface IAccountRepository
    {
        List<Account> List();
        void Creat(Account account);
        void Save();
        bool EmailDuplicate(EditAccountViewModel editAccountViewModel);
        bool UserNameDuplicate(EditAccountViewModel editAccountViewModel);
        Account GetByIsActive(string code);
         Account GetById(int id);
        string GetByEmail(string email);
        Account GetByActiveCode(string activeCode);

        void EditAccount(Account account);
        Account Login(string userNameOrEmail, string password);
        bool EmailExite(string email);
        bool UserNameExite(string userName);

    }
}
