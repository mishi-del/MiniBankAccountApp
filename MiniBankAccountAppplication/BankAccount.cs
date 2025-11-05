using System;

namespace MiniBankAccountAppplication
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string owner)
        {
            Owner = owner;
            AccountNumber = Guid.NewGuid();
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            Balance += amount;
        }

        // If withdrawal amount > balance → withdraw all
        public decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            decimal withdrawnAmount;

            if (amount >= Balance)
            {
                withdrawnAmount = Balance;
                Balance = 0;
            }
            else
            {
                withdrawnAmount = amount;
                Balance -= amount;
            }

            return withdrawnAmount;
        }
    }
}
