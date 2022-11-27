using NoteApp.Services.DAL;
using NoteApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Services.BUS
{
    public class AccountBLL
    {
        public AccountsDAL dalAccount;

        public AccountBLL()
        {
            dalAccount = new AccountsDAL();
        }

        public DataTable getAllAccounts()
        {
            return dalAccount.getAllAccounts();
        }

        public bool AddAccount(AccountDTO sv)
        {
            return dalAccount.AddAccount(sv);
        }
        
    }
}
