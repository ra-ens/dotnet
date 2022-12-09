using BankApp.services;
using BankApp.entities;

AccountService accountService = new AccountService();

for (int i = 0; i < 10; i++)
{
    Account account = new Account();

    account.id = i+1;
    account.currency = "MAD";

    Random random = new Random();

    double initialBalance = random.Next(1, 150000);

    account.balance = random.NextDouble() > 0.5 ? (-1 * initialBalance) / 5 : initialBalance;

    accountService.add(account);
}

// print all accounts
Console.WriteLine("=>> All Accounts:");
printAccounts(accountService.getAll());

// print debited accounts
Console.WriteLine("\n=>> All Debited Accounts:");
printAccounts(accountService.getDebited());

// print accounts avg
Console.WriteLine("\n=>> Accounts AVG: {0:0.00} MAD", accountService.getBalanceAvg());

// print get account by id
int id;
Console.WriteLine("\n=>> Get account by id:");
Console.Write("\tAccount id: ");
id = Convert.ToInt32(Console.ReadLine());
Account? acc = accountService.getById(id);
if(acc != null)
    Console.WriteLine("\tAccount[{0}]: {1}", acc.id, acc.ToString());
else
    Console.WriteLine("\tNo account found");

/**
* Print list of accounts
*/
void printAccounts(Dictionary<int, Account> list) {
    foreach( KeyValuePair<int, Account> account in list )
    {
        Console.WriteLine("Account[{0}]: {1}", account.Key, account.Value.ToString());
    }
}