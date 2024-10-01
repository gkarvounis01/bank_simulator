using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bank
{
    internal class Account
    {
        private string owner;
        private int tin;
        private int pin;
        private double balance;

        //Default constructor
        public Account()
        {

        }

        //Custom constructor
        public Account(string o, int a, int p, double b)
        {
            owner = o;
            tin = a;
            pin = p;
            balance = b; 
        }

        public string GetOwner()
        {
            return owner;
        }
        public int GetTin()
        {
            return tin;
        }
        public int GetPin()
        {
            return pin;
        }
        public double GetBalance()
        {
            return balance;
        }

        public void SetOwner(string o)
        {
            owner = o;
        }
        public void SetTin(int a)
        {
            tin = a;
        }
        public void SetPin(int p)
        {
            pin = p;
        }

        public void SetBalance(double b)
        {
            balance = b;
        }

        public void deposit(double amount)
        {
            balance += amount;

            Console.Clear();

            Console.WriteLine("New balance: " + balance);

            Console.WriteLine();
        }

        public void withdraw(double amount)
        {

            if(amount > balance)
            {
                Console.Clear();

                Console.WriteLine("Error! Not enough funds for withdrawal.");

                Console.WriteLine();
            }

            else
            {
                balance -= amount;

                Console.Clear();

                Console.WriteLine("New balance: " + balance);

                Console.WriteLine();
            }
            
        }

        public void print()
        {
            Console.WriteLine("Customer: " + GetOwner());
            Console.WriteLine("Balance: " + GetBalance());
            //Console.WriteLine(GetTin());
            //Console.WriteLine(GetPin());

            Console.ReadLine();

            Console.Clear();
        }
    }
}