using BankApp.entities;

namespace BankApp.services
{
    interface IAccountService {
        void add(Account account);
        Dictionary<int, Account> getAll();
        Account? getById(int id);
        Dictionary<int, Account> getDebited();
        double getBalanceAvg();
    }
}