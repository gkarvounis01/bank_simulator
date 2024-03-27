using Intuit.Ipp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Trapeza
{
    internal class Account
    {
        private string owner;
        private int afm;
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
            afm = a;
            pin = p;
            balance = b; 
        }

        public string GetOwner()
        {
            return owner;
        }
        public int GetAfm()
        {
            return afm;
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
        public void SetAfm(int a)
        {
            afm = a;
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

            Console.WriteLine("Νέο υπόλοιπο: " + balance);

            Console.WriteLine();
        }

        public void withdraw(double amount)
        {

            if(amount > balance)
            {
                Console.Clear();

                Console.WriteLine("Προσοχή! Μη επαρκές υπόλοιπο για ανάληψη.");

                Console.WriteLine();
            }

            else
            {
                balance -= amount;

                Console.Clear();

                Console.WriteLine("Νέο υπόλοιπο: " + balance);

                Console.WriteLine();
            }
            
        }

        public void print()
        {
            Console.WriteLine("Ονοματεπώνυμο: " + GetOwner());
            Console.WriteLine("Υπόλοιπο: " + GetBalance());
            //Console.WriteLine(GetAfm());
            //Console.WriteLine(GetPin());

            Console.ReadLine();

            Console.Clear();
        }
    }
}