using System.Collections.Generic;
using BankApp.entities;

namespace BankApp.services
{
    class AccountService : IAccountService {

        private Dictionary<int, Account> list;

        public AccountService() {
            this.list = new Dictionary<int, Account>();
        }

        public void add(Account account) {
            list.Add(account.id, account);
        }

        public Dictionary<int, Account> getAll() {
            return list;
        }

        public Account? getById(int id) {
            return list.ContainsKey(id) ? list[id] : null;
        }

        public Dictionary<int, Account> getDebited() {
            return list
                .Where(account => account.Value.balance < 0)
                .ToDictionary(item => item.Value.id, item => item.Value);
        }

        public double getBalanceAvg() {
            return list.Average(account => account.Value.balance);
        }
    }
}