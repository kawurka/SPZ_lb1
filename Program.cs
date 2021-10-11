using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SPZ_lb1
{
    struct Deposit
    {
       public string name;
       public decimal rate;
       public decimal money;
    }
    class Bank
    {
        private string FIO;
        private string bank_account;
        private decimal balance;
        private List<Deposit> deposits = new List<Deposit>();

        public Bank(string FIO, string bank_account, decimal balance)
        {
            if ( balance < 0)
            {
                Console.WriteLine($"Invalid balance: {balance} !");
                Environment.Exit(1);

            }
            this.FIO = FIO;
            this.bank_account = bank_account;
            this.balance = balance;
        }
        public void add_depos(string name, decimal rate, decimal money)
        {
            Deposit dep = new Deposit();
            dep.name = name;
            dep.rate = rate;
            dep.money = money;
            this.deposits.Add(dep);
        }
        public void dep_per()
        {
            Console.Write("Insert, which deposite you want to use (press 1-3 numbers): ");
            try
            {
                int i = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"\nFrom deposite on {deposits[i-1].name} with year rate {deposits[i-1].rate} you will get {deposits[i-1].money * deposits[i-1].rate / 100 + deposits[i-1].money }");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void add_balance()
        {
            Console.Write("Inser an amount of moeny to add: ");
            try
            {
                decimal money = Int32.Parse(Console.ReadLine());
                this.balance += money;
                Console.WriteLine($"\n Success! You now have {this.balance} c.u.");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void remove_balance()
        {
            Console.Write("Inser an amount of moeny to remove: ");
            try
            {
                decimal money = Int32.Parse(Console.ReadLine());
                if (this.balance >= money)
                {
                    this.balance -= money;
                    Console.WriteLine($"\n{money} were successfully withdrawed, your current balance is now {this.balance} c.u.");
                }
                else
                {
                    Console.WriteLine($"Sorry, but you haven't enough amoun of balance! {this.balance} : {money} ");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void remove_deposite(string name)
        {
            Deposit dp = new Deposit();
            for (int i = 0; i < deposits.Count; i++)
            {
                if (deposits[i].name == name)
                {
                    dp = deposits[i];
                }
            }
            deposits.Remove(dp);
            Console.WriteLine($"Deposite {name} has been removed!");
        }
        public void all_dep_sum()
        {
            decimal sum = 0;
            for (int i = 0; i < deposits.Count; i++)
            {
                sum += deposits[i].money;
            }
            Console.WriteLine($"Total balance on deposits: {sum} c.u.");
        }
        public override string ToString()
        {
            return "Hello, user " + FIO + "#" + bank_account;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello! Please, insert you initials: ");
            string FIO = Console.ReadLine();
            if (String.IsNullOrEmpty(FIO))
            {
                Console.WriteLine("You've inserted nothing... Well, your name is...Dominik Torretto");
                FIO = "Dominik Toretto";
            }
            Console.Write("\nGreat! Now, insert your bank account: ");
            string account = Console.ReadLine();
            if(!Regex.IsMatch(account, @"^[0-9]+$") || account.Length != 8)
            {
                account = "";
                Console.WriteLine("Incorrect output... again... Try again!");
                account = Console.ReadLine();
            }
            Bank acc = new Bank(FIO, account, 348569);
            Console.WriteLine(acc.ToString());
            acc.add_depos("Privatbank",9, 8323);
            acc.add_depos("Sberbank", 5, 2021);
            acc.add_depos("Monobank", 11, 10984);
            acc.dep_per();
            acc.add_balance();
            acc.remove_balance();
            acc.all_dep_sum();
            acc.remove_deposite("Sberbank");
            acc.all_dep_sum();
        }
    }
}
