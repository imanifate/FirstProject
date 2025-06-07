using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;

namespace AppStore.Domain.Contracts
{
    public interface IAccountRepository
    {
        void Creat(Account account);
        void Save();
        bool EmailDuplicate(string email);
        bool UserNameDuplicate(string userName);
        Account GetByIsActive(string code);
        void EditAccount(Account account);
        Account Login(string userNameOrEmail, string password);
    }
}
