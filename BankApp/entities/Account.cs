namespace BankApp.entities
{
    class Account {

        public int id {get; set;}
        public string? currency {get; set;}
        public double balance {get; set;}

        public Account() {}

        public Account(int id, string currency, double balance) {
            this.id = id;
            this.currency = currency;
            this.balance = balance;
        }

        public override string ToString()
        {
            return String.Format("Id: {0}, Currency: {1}, Balance: {2}", this.id, this.currency, this.balance);
        }
    }
}